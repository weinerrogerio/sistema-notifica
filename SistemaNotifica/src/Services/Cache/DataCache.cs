using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Services.Cache
{
    public static class ProtestoDataCache
    {
        private static readonly object _lock = new object();
        private static List<JObject> _data = new List<JObject>();
        private static volatile bool _isLoaded = false;
        private static volatile bool _isLoading = false;
        private static int _lastLoadedPage = 0;
        private static int _totalPages = 0;

        // Limite máximo de registros no cache
        private const int MAX_CACHE_SIZE = 100;

        // Eventos para notificar atualizações
        public static event Action<List<JObject>> OnDataUpdated;
        public static event Action<bool> OnLoadingStateChanged;

        // Propriedades públicas
        public static bool IsLoaded
        {
            get { lock ( _lock ) { return _isLoaded; } }
            private set { lock ( _lock ) { _isLoaded = value; } }
        }

        public static bool IsLoading
        {
            get { lock ( _lock ) { return _isLoading; } }
            private set
            {
                lock ( _lock )
                {
                    _isLoading = value;
                    OnLoadingStateChanged?.Invoke(value);
                }
            }
        }

        public static int Count
        {
            get { lock ( _lock ) { return _data.Count; } }
        }

        public static int LastLoadedPage
        {
            get { lock ( _lock ) { return _lastLoadedPage; } }
        }

        public static int TotalPages
        {
            get { lock ( _lock ) { return _totalPages; } }
        }

        /// Limpa completamente o cache
        public static void Clear()
        {
            lock ( _lock )
            {
                Debug.WriteLine("ProtestoDataCache: Limpando cache");
                _data.Clear();
                _isLoaded = false;
                _lastLoadedPage = 0;
                _totalPages = 0;
            }
            OnDataUpdated?.Invoke(new List<JObject>());
        }

        /// Obtém todos os dados do cache de forma thread-safe
        public static List<JObject> GetAllData()
        {
            lock ( _lock )
            {
                return new List<JObject>(_data);
            }
        }

        /// Obtém um range específico de dados do cache
        public static List<JObject> GetDataRange(int startIndex, int count)
        {
            lock ( _lock )
            {
                if ( startIndex >= _data.Count ) return new List<JObject>();

                int actualCount = Math.Min(count, _data.Count - startIndex);
                return _data.Skip(startIndex).Take(actualCount).ToList();
            }
        }

        /// Obtém os últimos N dados adicionados ao cache
        public static List<JObject> GetLastAddedData(int count)
        {
            lock ( _lock )
            {
                if ( _data.Count == 0 ) return new List<JObject>();

                int startIndex = Math.Max(0, _data.Count - count);
                return _data.Skip(startIndex).Take(count).ToList();
            }
        }

        /// Adiciona novos dados ao cache (usado durante o carregamento progressivo)
        public static List<JObject> AddDataBatch(JArray newData, int currentPage, int totalPages)
        {
            List<JObject> newItems = new List<JObject>();
            bool hasNewData = false;

            lock ( _lock )
            {
                _totalPages = totalPages;
                _lastLoadedPage = currentPage;

                foreach ( JObject item in newData )
                {
                    int itemId = item["id"]?.Value<int>() ?? 0;

                    if ( !_data.Any(cachedItem => cachedItem["id"]?.Value<int>() == itemId) )
                    {
                        if ( _data.Count >= MAX_CACHE_SIZE )
                        {
                            Debug.WriteLine($"ProtestoDataCache: Limite de {MAX_CACHE_SIZE} registros atingido");
                            break;
                        }
                        _data.Add(item);
                        newItems.Add(item);
                        hasNewData = true;
                    }
                }

                // Se não há dados novos, assumir que terminou a paginação
                if ( !hasNewData && currentPage > 1 )
                {
                    _isLoaded = true;
                    Debug.WriteLine($"ProtestoDataCache: Nenhum dado novo encontrado na página {currentPage}. Assumindo fim da paginação.");
                }
                else if ( currentPage >= totalPages || _data.Count >= MAX_CACHE_SIZE )
                {
                    _isLoaded = true;
                    Debug.WriteLine($"ProtestoDataCache: Cache totalmente carregado. Total: {_data.Count} registros");
                }
            }

            if ( newItems.Count > 0 )
            {
                OnDataUpdated?.Invoke(newItems);
            }

            return newItems;
        }

        /// <summary>
        /// Inicia o processo de carregamento assíncrono do cache
        /// </summary>
        public static async Task LoadCacheAsync(Func<int, int, Task<JObject>> dataLoader, int pageSize = 50, CancellationToken cancellationToken = default)
        {
            if ( IsLoading )
            {
                Debug.WriteLine("ProtestoDataCache: Carregamento já em andamento");
                return;
            }

            IsLoading = true;

            try
            {
                Debug.WriteLine("ProtestoDataCache: Iniciando carregamento do cache");

                int currentPage = 1;
                int totalPagesToLoad = 0;
                int maxPagesToLoad = ( int ) Math.Ceiling(( double ) MAX_CACHE_SIZE / pageSize);
                int pagesWithoutNewData = 0; // Contador para páginas sem dados novos
                const int MAX_PAGES_WITHOUT_DATA = 3; // Máximo de páginas consecutivas sem dados novos

                do
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    JObject response = await dataLoader(currentPage, pageSize);
                    var dados = response["data"] as JArray;

                    if ( dados == null || dados.Count == 0 )
                    {
                        Debug.WriteLine($"ProtestoDataCache: Página {currentPage} retornou dados vazios");
                        break;
                    }

                    // Atualiza informações de paginação na primeira execução
                    if ( currentPage == 1 )
                    {
                        int totalPagesFromApi = response["lastPage"]?.Value<int>() ?? 1;
                        totalPagesToLoad = Math.Min(totalPagesFromApi, maxPagesToLoad);

                        Debug.WriteLine($"ProtestoDataCache: Total de páginas da API: {totalPagesFromApi}, Páginas a carregar: {totalPagesToLoad}");
                    }

                    // Adiciona os dados ao cache
                    var newItems = AddDataBatch(dados, currentPage, totalPagesToLoad);

                    // Verifica se houve dados novos
                    if ( newItems.Count == 0 )
                    {
                        pagesWithoutNewData++;
                        Debug.WriteLine($"ProtestoDataCache: Página {currentPage} não trouxe dados novos ({pagesWithoutNewData}/{MAX_PAGES_WITHOUT_DATA})");

                        if ( pagesWithoutNewData >= MAX_PAGES_WITHOUT_DATA )
                        {
                            Debug.WriteLine("ProtestoDataCache: Muitas páginas consecutivas sem dados novos, parando carregamento");
                            break;
                        }
                    }
                    else
                    {
                        pagesWithoutNewData = 0; // Reset contador
                    }

                    // Para se atingiu o limite de cache
                    if ( Count >= MAX_CACHE_SIZE )
                    {
                        Debug.WriteLine("ProtestoDataCache: Limite de cache atingido, parando carregamento");
                        break;
                    }

                    currentPage++;

                    // Pequeno delay para não sobrecarregar a API
                    await Task.Delay(100, cancellationToken); // 100ms

                } while ( currentPage <= totalPagesToLoad && !cancellationToken.IsCancellationRequested );

                Debug.WriteLine($"ProtestoDataCache: Carregamento concluído. Total: {Count} registros");
            }
            catch ( OperationCanceledException )
            {
                Debug.WriteLine("ProtestoDataCache: Carregamento cancelado");
                throw;
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"ProtestoDataCache: Erro durante carregamento: {ex.Message}");
                throw;
            }
            finally
            {
                IsLoading = false;
            }
        }

        /// <summary>
        /// Atualiza o cache em background (usado após upload)
        /// </summary>
        public static async Task RefreshCacheInBackground(Func<int, int, Task<JObject>> dataLoader, int pageSize = 50)
        {
            try
            {
                Debug.WriteLine("ProtestoDataCache: Iniciando atualização em background");

                // Limpa o cache atual
                Clear();

                // Recarrega os dados em background
                await Task.Run(async () =>
                {
                    using ( var cts = new CancellationTokenSource(TimeSpan.FromMinutes(5)) ) // Timeout de 5 minutos
                    {
                        await LoadCacheAsync(dataLoader, pageSize, cts.Token);
                    }
                });

                Debug.WriteLine("ProtestoDataCache: Atualização em background concluída");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"ProtestoDataCache: Erro na atualização em background: {ex.Message}");
            }
        }

        /// <summary>
        /// Verifica se o cache precisa ser atualizado
        /// </summary>
        public static bool NeedsRefresh()
        {
            lock ( _lock )
            {
                return !_isLoaded && _data.Count == 0;
            }
        }

        /// <summary>
        /// Obtém estatísticas do cache para debug
        /// </summary>
        public static string GetCacheStats()
        {
            lock ( _lock )
            {
                return $"Cache Stats - Registros: {_data.Count}/{MAX_CACHE_SIZE}, " +
                       $"Carregado: {_isLoaded}, Carregando: {_isLoading}, " +
                       $"Página: {_lastLoadedPage}/{_totalPages}";
            }
        }








    }
}