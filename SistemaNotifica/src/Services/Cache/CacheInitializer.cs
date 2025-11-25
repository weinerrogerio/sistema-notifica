using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Services.Cache
{
    public static class CacheInitializer
    {
        private static bool _isInitialized = false;
        private static CancellationTokenSource _cts;
        private static readonly object _lock = new object();

        /// <summary>
        /// Inicia o carregamento do cache em segundo plano após o login
        /// </summary>
        public static void StartBackgroundCacheInitialization()
        {

            lock ( _lock )
            {
                if ( _isInitialized )
                {
                    Debug.WriteLine("CacheInitializer: Cache já está inicializado ou em processo de inicialização");
                    return;
                }
                _isInitialized = true;
            }

            _cts = new CancellationTokenSource();

            // Executa em uma thread de background com baixa prioridade
            Task.Run(async () =>
            {
                try
                {
                    // Pequeno delay para garantir que a UI principal carregue primeiro
                    await Task.Delay(1000, _cts.Token);

                    Debug.WriteLine("CacheInitializer: Iniciando carregamento do cache em segundo plano...");

                    var protestoService = Program.ProtestoService;

                    await ProtestoDataCache.LoadCacheAsync(
                        async (page, pageSize) => await protestoService.GetAsJObjectAsync(
                            page.ToString(),
                            pageSize.ToString()
                        ),
                        pageSize: 50, // Páginas menores para menos impacto
                        cancellationToken: _cts.Token
                    );

                    Debug.WriteLine($"CacheInitializer: Cache carregado com sucesso. Total de registros: {ProtestoDataCache.Count}");
                }
                catch ( OperationCanceledException )
                {
                    Debug.WriteLine("CacheInitializer: Carregamento do cache foi cancelado");
                }
                catch ( Exception ex )
                {
                    Debug.WriteLine($"CacheInitializer: Erro ao carregar cache: {ex.Message}");
                    Debug.WriteLine($"StackTrace: {ex.StackTrace}");

                    // Permite nova tentativa em caso de erro
                    lock ( _lock )
                    {
                        _isInitialized = false;
                    }
                }
            }, _cts.Token);
        }

        /// <summary>
        /// Cancela o carregamento do cache em andamento
        /// </summary>
        public static void CancelInitialization()
        {
            lock ( _lock )
            {
                _cts?.Cancel();
                _cts?.Dispose();
                _cts = null;
                _isInitialized = false;
            }
            Debug.WriteLine("CacheInitializer: Inicialização cancelada");
        }

        /// <summary>
        /// Verifica se o cache está inicializado e com dados
        /// </summary>
        public static bool IsReady()
        {
            lock ( _lock )
            {
                return _isInitialized && ProtestoDataCache.Count > 0;
            }
        }

        /// <summary>
        /// Força uma reinicialização do cache (limpa e recarrega)
        /// </summary>
        public static async Task ForceReInitialization()
        {
            Debug.WriteLine("CacheInitializer: Forçando reinicialização do cache");

            // Cancela qualquer carregamento em andamento
            CancelInitialization();

            // Limpa o cache atual
            ProtestoDataCache.Clear();

            // Aguarda um pouco para garantir cancelamento
            await Task.Delay(100);

            // Reinicia o carregamento
            StartBackgroundCacheInitialization();
        }
    }
}