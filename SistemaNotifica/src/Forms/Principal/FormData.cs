using Newtonsoft.Json.Linq;
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;
using SistemaNotifica.src.Services.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormData : Form
    {
        private readonly ProtestoService _protestoService;
        private CancellationTokenSource _cancellationTokenSource;
        private bool _isInitializing = false;
        private int _lastAddedRowCount = 0;

        // Configurações de cache
        private const int CACHE_PAGE_SIZE = 50;
        private const int UI_UPDATE_BATCH_SIZE = 10;
        private const int UI_UPDATE_DELAY_MS = 50;

        public FormData()
        {
            InitializeComponent();
            _protestoService = Program.ProtestoService;
            tableLayoutPanel.Dock = DockStyle.Fill;
            this.Resize += FormData_Resize;
            ConfigDataGridView();

            // Inscreve nos eventos do cache
            ProtestoDataCache.OnDataUpdated += OnCacheDataUpdated;
            ProtestoDataCache.OnLoadingStateChanged += OnCacheLoadingStateChanged;

            //LoadDataWithCache();

        }

        private void FormData_Resize(object sender, EventArgs e)
        {
            // Força atualização do layout do DataGridView
            if ( dataGridViewProtesto != null )
            {
                dataGridViewProtesto.Invalidate();
                dataGridViewProtesto.Update();
            }
        }

        private void ConfigDataGridView()
        {
            dataGridViewProtesto.SuspendLayout();

            dataGridViewProtesto.Rows.Clear();
            dataGridViewProtesto.RowHeadersVisible = false;
            dataGridViewProtesto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProtesto.AllowUserToAddRows = false;
            dataGridViewProtesto.MultiSelect = false;
            dataGridViewProtesto.ReadOnly = true;
            dataGridViewProtesto.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewProtesto.Dock = DockStyle.Fill;

            // Otimizações de performance
            dataGridViewProtesto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProtesto.ScrollBars = ScrollBars.Both;
            dataGridViewProtesto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewProtesto.AllowUserToResizeRows = false;
            dataGridViewProtesto.AllowUserToResizeColumns = true;
            dataGridViewProtesto.Rows.Clear();
            dataGridViewProtesto.RowHeadersVisible = false;

            // Configurações críticas para performance
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, dataGridViewProtesto, new object[] { true });
            dataGridViewProtesto.EnableHeadersVisualStyles = false;

            ConfigurarLargurasColunas();
            dataGridViewProtesto.ResumeLayout();
        }

        private void ConfigurarLargurasColunas()
        {
            int larguraDisponivel = dataGridViewProtesto.ClientSize.Width - 20; // 20px para scroll
            int totalColunas = dataGridViewProtesto.Columns.Count;

            var configColunas = new Dictionary<string, int>
            {
                {"ColumnId", 50},
                {"ColumnDataApresentacao", 120},
                {"ColumnDataDistribuicao", 130},
                {"ColumnNumDistribuicao", 100},
                {"ColumnCartProtesto", 200},
                {"ColumnNumTitulo", 100},
                {"ColumnValor", 100},
                {"ColumnSaldo", 100},
                {"ColumnVencimento", 100},
                {"ColumNomeDevedor", 200},
                {"ColumnDocDevedor", 120},
                {"ColumnNomeApresentante", 180},
                {"ColumnCodApresentante", 120},
                {"nome_arquivo", 150},
                {"file_data_importacao", 130},
                {"ColumnSacador", 180},
                {"ColumnCedente", 180},
                {"ColumnDocCredor", 120},
                {"ColumnEmailEnviado", 120},
                {"ColumnDataEnvio", 120}
            };

            foreach ( DataGridViewColumn coluna in dataGridViewProtesto.Columns )
            {
                if ( configColunas.ContainsKey(coluna.Name) )
                {
                    coluna.Width = configColunas[coluna.Name];
                    coluna.MinimumWidth = Math.Max(50, configColunas[coluna.Name] - 20);

                    // ADICIONE: Permitir redimensionamento automático da última coluna
                    if ( coluna == dataGridViewProtesto.Columns[dataGridViewProtesto.Columns.Count - 1] )
                    {
                        coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
        }


        /// Carrega dados usando o sistema de cache

        private async Task LoadDataWithCache()
        {
            try
            {
                if ( _protestoService == null )
                {
                    Debug.WriteLine("ProtestoService não foi inicializado!");
                    MessageBox.Show("Erro: Serviço não disponivel, verifique sua conexão.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource = new CancellationTokenSource();
                _isInitializing = true;

                Debug.WriteLine("FormData: Iniciando carregamento com cache");
                Debug.WriteLine($"Cache Stats: {ProtestoDataCache.GetCacheStats()}");

                // Verifica se o cache já tem dados
                if ( ProtestoDataCache.Count > 0 )
                {
                    Debug.WriteLine("FormData: Carregando dados existentes do cache");
                    await LoadDataFromCache();
                }
                else
                {
                    Debug.WriteLine("FormData: Cache vazio, iniciando carregamento da API");
                    ShowLoadingIndicator(true, "Carregando dados...");

                    // Inicia o carregamento do cache em background
                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            await ProtestoDataCache.LoadCacheAsync(LoadPageFromApi, CACHE_PAGE_SIZE, _cancellationTokenSource.Token);
                        }
                        catch ( OperationCanceledException )
                        {
                            Debug.WriteLine("FormData: Carregamento cancelado");
                        }
                        catch ( Exception ex )
                        {
                            Debug.WriteLine($"FormData: Erro no carregamento: {ex.Message}");
                            this.Invoke(new Action(() =>
                            {
                                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }
                    });
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"FormData: Erro em LoadDataWithCache: {ex.Message}");
                MessageBox.Show($"Erro ao inicializar carregamento: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isInitializing = false;
            }
        }


        /// Carrega uma página da API (usado pelo cache)

        private async Task<JObject> LoadPageFromApi(int page, int pageSize)
        {
            Debug.WriteLine($"FormData: Carregando página {page} da API");
            return await _protestoService.GetAsJObjectAsync(page.ToString(), pageSize.ToString());
        }


        /// Carrega dados existentes do cache para o grid

        private async Task LoadDataFromCache()
        {
            try
            {
                var cachedData = ProtestoDataCache.GetAllData();

                if ( cachedData.Count == 0 )
                {
                    Debug.WriteLine("FormData: Cache não contém dados");
                    return;
                }

                Debug.WriteLine($"FormData: Carregando {cachedData.Count} registros do cache");

                dataGridViewProtesto.SuspendLayout();
                dataGridViewProtesto.Rows.Clear();
                _lastAddedRowCount = 0;

                // Adiciona os dados em lotes para não travar a UI
                await AddDataToGridInBatches(cachedData);

                dataGridViewProtesto.ResumeLayout();

                Debug.WriteLine($"FormData: {cachedData.Count} registros carregados do cache para o grid");
                UpdateStatusLabel($"{cachedData.Count} registros carregados do cache");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"FormData: Erro ao carregar dados do cache: {ex.Message}");
            }
        }


        /// Evento chamado quando novos dados são adicionados ao cache

        private async void OnCacheDataUpdated(List<JObject> newData)
        {
            if ( newData.Count == 0 ) return;

            try
            {
                if ( this.InvokeRequired )
                {
                    this.Invoke(new Action(async () => await OnCacheDataUpdated_Internal(newData)));
                }
                else
                {
                    await OnCacheDataUpdated_Internal(newData);
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"FormData: Erro em OnCacheDataUpdated: {ex.Message}");
            }
        }

        private async Task OnCacheDataUpdated_Internal(List<JObject> newData)
        {
            Debug.WriteLine($"FormData: Adicionando {newData.Count} novos registros ao grid");

            // Remove a chamada recursiva de AddDataToGridInBatches
            // Apenas adicione as linhas ao grid diretamente
            AddDataBatch(newData);

            int totalRecords = dataGridViewProtesto.Rows.Count;
            UpdateStatusLabel($"{totalRecords} registros carregados");

            Debug.WriteLine($"FormData: Grid agora tem {totalRecords} registros");
        }

        private void AddDataBatch(List<JObject> data)
        {
            dataGridViewProtesto.SuspendLayout();
            foreach ( var item in data )
            {
                AdicionarLinhaApiTabela(item);
            }
            dataGridViewProtesto.ResumeLayout();
        }

        private void OnCacheLoadingStateChanged(bool isLoading)
        {
            try
            {
                if ( this.InvokeRequired )
                {
                    this.Invoke(new Action(() => OnCacheLoadingStateChanged_Internal(isLoading)));
                }
                else
                {
                    OnCacheLoadingStateChanged_Internal(isLoading);
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"FormData: Erro em OnCacheLoadingStateChanged: {ex.Message}");
            }
        }

        private void OnCacheLoadingStateChanged_Internal(bool isLoading)
        {
            if ( !isLoading )
            {
                ShowLoadingIndicator(false);
                Debug.WriteLine("FormData: Carregamento do cache finalizado");

                int totalRecords = dataGridViewProtesto.Rows.Count;
                UpdateStatusLabel($"{totalRecords} registros carregados");
            }
        }


        /// Adiciona dados ao grid em lotes para não travar a UI
        private async Task AddDataToGridInBatches(List<JObject> data, bool clearGrid = true)
        {
            if ( data.Count == 0 ) return;

            if ( clearGrid )
            {
                dataGridViewProtesto.Rows.Clear();
                _lastAddedRowCount = 0;
            }

            int currentIndex = 0;

            while ( currentIndex < data.Count )
            {
                int batchSize = Math.Min(UI_UPDATE_BATCH_SIZE, data.Count - currentIndex);
                var batch = data.Skip(currentIndex).Take(batchSize).ToList();

                dataGridViewProtesto.SuspendLayout();

                foreach ( var item in batch )
                {
                    AdicionarLinhaApiTabela(item);
                }

                dataGridViewProtesto.ResumeLayout();

                currentIndex += batchSize;
                _lastAddedRowCount += batchSize;

                // Permite que a UI se atualize
                await Task.Delay(UI_UPDATE_DELAY_MS);
                Application.DoEvents();

                // Atualiza o status periodicamente
                if ( currentIndex % ( UI_UPDATE_BATCH_SIZE * 5 ) == 0 )
                {
                    UpdateStatusLabel($"Carregando... {currentIndex}/{data.Count} registros");
                }
            }
        }


        /// Adiciona uma linha individual ao grid (método existente otimizado)

        private void AdicionarLinhaApiTabela(JObject protesto)
        {
            try
            {
                int rowIndex = dataGridViewProtesto.Rows.Add();
                DataGridViewRow row = dataGridViewProtesto.Rows[rowIndex];

                // Dados básicos do protesto
                row.Cells["ColumnId"].Value = protesto["id"]?.ToString() ?? string.Empty;
                row.Cells["ColumnDataApresentacao"].Value = FormatarData(protesto["data_apresentacao"]?.ToString());
                row.Cells["ColumnDataDistribuicao"].Value = FormatarData(protesto["data_distribuicao"]?.ToString());
                row.Cells["ColumnNumDistribuicao"].Value = protesto["num_distribuicao"]?.ToString() ?? string.Empty;
                row.Cells["ColumnCartProtesto"].Value = protesto["cart_protesto"]?.ToString() ?? string.Empty;
                row.Cells["ColumnNumTitulo"].Value = protesto["num_titulo"]?.ToString() ?? string.Empty;
                row.Cells["ColumnValor"].Value = FormatarValor(protesto["valor"]?.ToString());
                row.Cells["ColumnSaldo"].Value = FormatarValor(protesto["saldo"]?.ToString());
                row.Cells["ColumnVencimento"].Value = protesto["vencimento"]?.ToString() ?? string.Empty;

                // Dados do apresentante
                var apresentante = protesto["apresentante"] as JObject;
                if ( apresentante != null )
                {
                    row.Cells["ColumnNomeApresentante"].Value = apresentante["nome"]?.ToString() ?? string.Empty;
                    row.Cells["ColumnCodApresentante"].Value = apresentante["cod_apresentante"]?.ToString() ?? string.Empty;
                }

                // Dados do credor
                var credores = protesto["credores"] as JArray;
                if ( credores != null && credores.Count > 0 )
                {
                    var primeiroCredor = credores[0]["credor"] as JObject;
                    if ( primeiroCredor != null )
                    {
                        row.Cells["ColumnSacador"].Value = primeiroCredor["sacador"]?.ToString() ?? string.Empty;
                        row.Cells["ColumnCedente"].Value = primeiroCredor["cedente"]?.ToString() ?? string.Empty;
                        row.Cells["ColumnDocCredor"].Value = FormatarDocumento(primeiroCredor["doc_credor"]?.ToString());
                    }
                }

                // Dados das notificações
                var notificacoes = protesto["notificacao"] as JArray;
                if ( notificacoes != null && notificacoes.Count > 0 )
                {
                    var notificacao = notificacoes[0] as JObject;
                    if ( notificacao != null )
                    {
                        var devedor = notificacao["devedor"] as JObject;
                        if ( devedor != null )
                        {
                            row.Cells["ColumNomeDevedor"].Value = devedor["nome"]?.ToString() ?? string.Empty;
                            row.Cells["ColumnDocDevedor"].Value = FormatarDocumento(devedor["doc_devedor"]?.ToString());
                        }

                        row.Cells["ColumnEmailEnviado"].Value = ( notificacao["email_enviado"]?.Value<bool>() == true ) ? "Sim" : "Não";
                        row.Cells["ColumnDataEnvio"].Value = FormatarData(notificacao["data_envio"]?.ToString());
                    }
                }

                // Dados do arquivo
                var file = protesto["file"] as JObject;
                if ( file != null )
                {
                    row.Cells["nome_arquivo"].Value = file["nome_arquivo"]?.ToString() ?? string.Empty;
                    row.Cells["file_data_importacao"].Value = FormatarData(file["data_importacao"]?.ToString());
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"FormData: Erro ao adicionar linha: {ex.Message}");
            }
        }
        /// Atualiza o cache em background após upload
        public static async Task RefreshCacheAfterUpload(ProtestoService protestoService)
        {
            try
            {
                Debug.WriteLine("FormData: Iniciando atualização do cache após upload");

                await ProtestoDataCache.RefreshCacheInBackground(
                    async (page, pageSize) => await protestoService.GetAsJObjectAsync(page.ToString(), pageSize.ToString()),
                    CACHE_PAGE_SIZE
                );

                Debug.WriteLine("FormData: Cache atualizado com sucesso após upload");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"FormData: Erro ao atualizar cache após upload: {ex.Message}");
            }
        }
        /// Método público para atualizar dados
        public async Task RefreshData()
        {
            Debug.WriteLine("FormData: Solicitação de refresh de dados");
            await LoadDataWithCache();
        }

        /// Força uma atualização completa do cache
        public async Task ForceRefreshCache()
        {
            Debug.WriteLine("FormData: Forçando atualização completa do cache");

            ProtestoDataCache.Clear();
            await LoadDataWithCache();
        }

        /// Mostra/oculta indicador de carregamento
        private void ShowLoadingIndicator(bool show, string message = "Carregando...")
        {
            this.Cursor = show ? Cursors.WaitCursor : Cursors.Default;

            if ( show )
            {
                this.Text = $"Sistema Notifica - {message}";
            }
            else
            {
                this.Text = "Sistema Notifica";
            }
        }

        /// Atualiza label de status
        private void UpdateStatusLabel(string message)
        {
            this.Text = $"Sistema Notifica - {message}";
        }

        // Cache de formatação (métodos existentes mantidos)
        private readonly Dictionary<string, string> _dataCache_formatted = new Dictionary<string, string>();

        private string FormatarData(string dataString)
        {
            if ( string.IsNullOrEmpty(dataString) )
                return string.Empty;

            if ( _dataCache_formatted.ContainsKey(dataString) )
                return _dataCache_formatted[dataString];

            try
            {
                if ( DateTime.TryParse(dataString, out DateTime data) )
                {
                    string resultado = data.ToString("dd/MM/yyyy HH:mm");
                    _dataCache_formatted[dataString] = resultado;
                    return resultado;
                }
                return dataString;
            }
            catch
            {
                return dataString;
            }
        }

        private string FormatarValor(string valorString)
        {
            if ( string.IsNullOrEmpty(valorString) )
                return "R$ 0,00";

            try
            {
                if ( decimal.TryParse(valorString, out decimal valor) )
                {
                    decimal valorEmReais = valor / 100;
                    return valorEmReais.ToString("C2");
                }
                return valorString;
            }
            catch
            {
                return valorString;
            }
        }

        private string FormatarDocumento(string documento)
        {
            if ( string.IsNullOrEmpty(documento) )
                return string.Empty;

            documento = System.Text.RegularExpressions.Regex.Replace(documento, @"[^\d]", "");

            if ( documento.Length == 11 )
            {
                return Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00");
            }
            else if ( documento.Length == 14 )
            {
                return Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
            }

            return documento;
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            // Configurações adicionais de performance se necessário
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Limpa recursos e cancela operações
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();

            // Remove os event handlers do cache
            ProtestoDataCache.OnDataUpdated -= OnCacheDataUpdated;
            ProtestoDataCache.OnLoadingStateChanged -= OnCacheLoadingStateChanged;

            _dataCache_formatted?.Clear();
            base.OnFormClosed(e);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DialogResult question = MessageBox.Show("Refazer busca?",
                "Tem certeza que deseja refazer a busca no banco de dados? \n" +
                "Dependendo a quandiade de dados que voce tem, isso pode levar algum tempo",
                MessageBoxButtons.YesNo);

            if ( question ==DialogResult.Yes )
            {
                // TODO --> reafazer a busca na a api e atualizar os dados no grid
            }
            else
            {
                // TODO --> apenas cancelar a busca
            }
        }
    }
}