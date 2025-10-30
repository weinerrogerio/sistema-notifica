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

            InitializeFields();
            //LoadDataWithCache();
            _ = LoadDataFromCache();
            
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

        // Adiciona uma linha individual ao grid 
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
            // Remove eventos de validação
            textBoxField1.KeyPress -= TextBoxDocument_KeyPress;
            textBoxField1.KeyPress -= TextBoxAlphaNumeric_KeyPress;
            textBoxField2.KeyPress -= TextBoxDocument_KeyPress;
            textBoxField2.KeyPress -= TextBoxAlphaNumeric_KeyPress;

            // Limpa recursos e cancela operações
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();

            // Remove os event handlers do cache
            ProtestoDataCache.OnDataUpdated -= OnCacheDataUpdated;
            ProtestoDataCache.OnLoadingStateChanged -= OnCacheLoadingStateChanged;

            _dataCache_formatted?.Clear();
            base.OnFormClosed(e);
        }


        // -------------------------------------- FILTROS E AÇÕES DE FILTROS --------------------------------------   

        // -------------------------------------- FILTROS E AÇÕES DE FILTROS --------------------------------------   

        // Estrutura para configuração dos campos
        private class FieldConfig
        {
            public string Label1 { get; set; }
            public string Placeholder1 { get; set; }
            public bool IsMask1Doc { get; set; }
            public bool IsMask1Date { get; set; } // Embora não usado atualmente, é boa prática ter

            public string Label2 { get; set; }
            public string Placeholder2 { get; set; }
            public bool IsMask2Date { get; set; }
            public bool ShowField2 { get; set; }

            public string Label3 { get; set; }
            public string Placeholder3 { get; set; }
            public bool ShowField3 { get; set; }
        }

        // Configurações de campos - cada opção em comboBoxOptions deve ter um FieldConfig
        private readonly Dictionary<string, FieldConfig> _fieldConfigs = new Dictionary<string, FieldConfig>
        {
            ["Distribuição/Apontamento"] = new FieldConfig
            {
                Label1 = "Distribuição/Apontamento:",
                Placeholder1 = "Digite a distribuição ou apontamento",
                ShowField2 = false,
                ShowField3 = false
            },
            ["Apontamento e Data apontamento"] = new FieldConfig
            {
                Label1 = "Apontamento:",
                Placeholder1 = "Digite o apontamento",
                Label2 = "Data Apontamento:",
                Placeholder2 = "dd/MM/yyyy",
                IsMask2Date = true,
                ShowField2 = true,
                ShowField3 = false
            },
            ["CPF ou CNPJ do Devedor"] = new FieldConfig
            {
                Label1 = "CPF/CNPJ Devedor:",
                Placeholder1 = "Digite o CPF ou CNPJ",
                IsMask1Doc = true,
                ShowField2 = false,
                ShowField3 = false
            },
            ["CPF ou CNPJ do Devedor e Data do protocolo"] = new FieldConfig
            {
                Label1 = "CPF/CNPJ Devedor:",
                Placeholder1 = "Digite o CPF ou CNPJ",
                IsMask1Doc = true,
                Label2 = "Data do Protocolo:",
                Placeholder2 = "dd/MM/yyyy",
                IsMask2Date = true,
                ShowField2 = true,
                ShowField3 = false
            },
            ["Nome do devedor"] = new FieldConfig
            {
                Label1 = "Nome do Devedor:",
                Placeholder1 = "Digite o nome do devedor",
                ShowField2 = false,
                ShowField3 = false
            },
            ["CPF ou CNPJ do Credor"] = new FieldConfig
            {
                Label1 = "CPF/CNPJ Credor:",
                Placeholder1 = "Digite o CPF ou CNPJ",
                IsMask1Doc = true,
                ShowField2 = false,
                ShowField3 = false
            },
            ["Numero do Titulo"] = new FieldConfig
            {
                Label1 = "Número do Título:",
                Placeholder1 = "Digite o número do título",
                ShowField2 = false,
                ShowField3 = false
            },
            ["Numero do Titulo e Data de Distribuição"] = new FieldConfig
            {
                Label1 = "Número do Título:",
                Placeholder1 = "Digite o número do título",
                Label2 = "Data de Distribuição:",
                Placeholder2 = "dd/MM/yyyy",
                IsMask2Date = true,
                ShowField2 = true,
                ShowField3 = false
            },
            ["Numero do Titulo e Vencimento"] = new FieldConfig
            {
                Label1 = "Número do Título:",
                Placeholder1 = "Digite o número do título",
                Label2 = "Data de Vencimento:",
                Placeholder2 = "dd/MM/yyyy",
                IsMask2Date = true,
                ShowField2 = true,
                ShowField3 = false
            }
        };

        private void InitializeFields()
        {
            // Configurar evento do ComboBox
            comboBoxOptions.SelectedIndexChanged += comboBoxOptions_SelectedIndexChanged;

            // Configurar eventos dos TextBoxes
            textBoxField1.Enter += TextBox_Enter;
            textBoxField1.Leave += TextBox_Leave;
            textBoxField1.TextChanged += textBoxField1_TextChanged; // Handler com timer

            textBoxField2.Enter += TextBox_Enter;
            textBoxField2.Leave += TextBox_Leave;
            textBoxField2.TextChanged += textBoxField2_TextChanged; // Handler com timer e máscara

            textBoxField3.Enter += TextBox_Enter;
            textBoxField3.Leave += TextBox_Leave;
            textBoxField3.TextChanged += textBoxField3_TextChanged; // Handler com timer

            // Inicializar campos ocultos
            HideAllFields();
        }

        private void ConfigureFields(FieldConfig config)
        {
            // Campo 1 - sempre visível
            labelField1.Text = config.Label1;
            labelField1.Visible = true;
            textBoxField1.Visible = true;

            // Remove eventos anteriores
            textBoxField1.KeyPress -= TextBoxDocument_KeyPress;
            textBoxField1.KeyPress -= TextBoxAlphaNumeric_KeyPress;

            // Guarda configuração ANTES de definir placeholder
            textBoxField1.Tag = new TextBoxData { Config = config };
            SetPlaceholder(textBoxField1, config.Placeholder1);

            RemoveMask(textBoxField1); // Apenas limpa o texto

            // ADICIONA validação se for campo de documento
            if ( config.IsMask1Doc )
            {
                textBoxField1.KeyPress += TextBoxDocument_KeyPress;
            }
            else if ( config.Label1.Contains("Nome") )
            {
                textBoxField1.KeyPress += TextBoxAlphaNumeric_KeyPress;
            }

            // Campo 2
            if ( config.ShowField2 )
            {
                labelField2.Text = config.Label2;
                labelField2.Visible = true;
                textBoxField2.Visible = true;

                textBoxField2.Tag = new TextBoxData { Config = config };
                SetPlaceholder(textBoxField2, config.Placeholder2);
            }
            else
            {
                labelField2.Visible = false;
                textBoxField2.Visible = false;
            }

            // Campo 3
            if ( config.ShowField3 )
            {
                labelField3.Text = config.Label3;
                labelField3.Visible = true;
                textBoxField3.Visible = true;

                textBoxField3.Tag = new TextBoxData { Config = config };
                SetPlaceholder(textBoxField3, config.Placeholder3);
            }
            else
            {
                labelField3.Visible = false;
                textBoxField3.Visible = false;
            }
        }


        private void HideAllFields()
        {
            labelField1.Visible = false;
            textBoxField1.Visible = false;
            labelField2.Visible = false;
            textBoxField2.Visible = false;
            labelField3.Visible = false;
            textBoxField3.Visible = false;
        }

        private class TextBoxData
        {
            public string Placeholder { get; set; }
            public FieldConfig Config { get; set; }
        }

        private void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            // Remove eventos anteriores
            textBox.Enter -= TextBox_Enter;
            textBox.Leave -= TextBox_Leave;

            // Preserva o FieldConfig se já existir
            var existingData = textBox.Tag as TextBoxData;
            var config = existingData?.Config ?? ( textBox.Tag as FieldConfig ); // Fallback para Tag antiga

            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;
            textBox.Tag = new TextBoxData
            {
                Placeholder = placeholderText,
                Config = config
            };

            textBox.Enter += TextBox_Enter;
            textBox.Leave += TextBox_Leave;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            var textBox = ( TextBox ) sender;
            var data = textBox.Tag as TextBoxData;

            if ( textBox.ForeColor == Color.Gray && data?.Placeholder != null )
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            var textBox = ( TextBox ) sender;
            var data = textBox.Tag as TextBoxData;

            if ( string.IsNullOrWhiteSpace(textBox.Text) && data?.Placeholder != null )
            {
                textBox.Text = data.Placeholder;
                textBox.ForeColor = Color.Gray;
            }
        }

        private bool IsPlaceholder(TextBox textBox)
        {
            var data = textBox.Tag as TextBoxData;
            // Verifica também se o texto é igual ao placeholder, caso o foco nunca tenha saído
            return textBox.ForeColor == Color.Gray && ( data?.Placeholder == null || data.Placeholder == textBox.Text );
        }


        /**
         * Lógica de máscara de documento (CPF/CNPJ) corrigida.
         * Chamada a partir de textBoxField1_TextChanged.
         */
        private void ApplyDocumentMask(TextBox textBox)
        {
            // Salva a posição atual do cursor
            int selStart = textBox.SelectionStart;
            string oldText = textBox.Text;

            // 1. Remove tudo que não for dígito
            string text = new string(textBox.Text.Where(char.IsDigit).ToArray());

            // 2. Limita o tamanho
            if ( text.Length > 14 )
            {
                text = text.Substring(0, 14);
            }

            // 3. Aplica a máscara
            if ( text.Length <= 11 ) // CPF: 000.000.000-00
            {
                if ( text.Length > 9 ) text = text.Insert(9, "-");
                if ( text.Length > 6 ) text = text.Insert(6, ".");
                if ( text.Length > 3 ) text = text.Insert(3, ".");
            }
            else // CNPJ: 00.000.000/0000-00
            {
                // text já está limitado a 14 dígitos
                if ( text.Length > 12 ) text = text.Insert(12, "-");
                if ( text.Length > 8 ) text = text.Insert(8, "/");
                if ( text.Length > 5 ) text = text.Insert(5, ".");
                if ( text.Length > 2 ) text = text.Insert(2, ".");
            }

            // 4. Define o texto e restaura o cursor
            if ( textBox.Text != text )
            {
                textBox.Text = text;

                // Ajusta a posição do cursor
                int newSelStart = selStart + ( text.Length - oldText.Length );
                textBox.SelectionStart = Math.Max(0, Math.Min(newSelStart, text.Length));
            }
        }

        // REMOVIDO: Método ApplyDateMask. A lógica agora está em textBoxField2_TextChanged.

        private void RemoveMask(TextBox textBox)
        {
            // Esta função agora é usada apenas para limpar o texto
            // Handlers de máscara são gerenciados em ConfigureFields ou nos próprios TextChanged
            textBox.Text = "";
        }

        //----------------------------------------------------------------------------------------------

        // botão para refazer buscas --> descarta dados em cache e refaz a busca
        private async void buttonRefresh_Click(object sender, EventArgs e)
        {
            DialogResult question = MessageBox.Show("Refazer busca?",
                "Tem certeza que deseja refazer a busca no banco de dados? \n" +
                "Isso limpará os dados atuais e buscará tudo novamente, o que pode levar algum tempo.",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if ( question == DialogResult.Yes )
            {
                // Limpa filtros de texto
                LimparFiltros();

                // Força a atualização do cache
                await ForceRefreshCache();
            }
            else
            {
                // Ação cancelada pelo usuário
            }
        }

        // -------------------------------  FILTROS  - LOGICA COM TIMER/DEBOUNCE  -------------------------------------

        // Mapeamento: Opção ComboBox -> (Coluna1, Coluna2, Coluna3)
        private readonly Dictionary<string, (string col1, string col2, string col3)> _filterMapping = new()
        {
            ["Distribuição/Apontamento"] = ("ColumnNumDistribuicao", null, null),
            ["Apontamento e Data apontamento"] = ("ColumnNumDistribuicao", "ColumnDataApresentacao", null),
            ["CPF ou CNPJ do Devedor"] = ("ColumnDocDevedor", null, null),
            ["CPF ou CNPJ do Devedor e Data do protocolo"] = ("ColumnDocDevedor", "ColumnDataApresentacao", null),
            ["Nome do devedor"] = ("ColumNomeDevedor", null, null),
            ["CPF ou CNPJ do Credor"] = ("ColumnDocCredor", null, null),
            ["Numero do Titulo"] = ("ColumnNumTitulo", null, null),
            ["Numero do Titulo e Data de Distribuição"] = ("ColumnNumTitulo", "ColumnDataDistribuicao", null),
            ["Numero do Titulo e Vencimento"] = ("ColumnNumTitulo", "ColumnVencimento", null)
        };

        /**
         * NOVO: Helper para formatar datas ISO (cache) para comparação com datas dd/MM/yyyy (input).
         */
        private string FormatarDataParaComparacao(string dataStringIso)
        {
            if ( string.IsNullOrEmpty(dataStringIso) )
                return "";

            // Tenta parsear a data ISO
            if ( DateTime.TryParse(dataStringIso, null, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime data) )
            {
                // Formata para "ddMMyyyy"
                return data.ToString("ddMMyyyy");
            }

            // Fallback: se não for data, apenas limpa
            return RemoveMaskForComparison(dataStringIso);
        }

        private JArray FilterData(JArray data)
        {
            if ( data == null || data.Count == 0 )
                return new JArray();

            string selectedOption = comboBoxOptions.SelectedItem?.ToString();
            if ( string.IsNullOrEmpty(selectedOption) || !_filterMapping.ContainsKey(selectedOption) )
                return data;

            // Pega a configuração do campo para saber quais campos são datas
            _fieldConfigs.TryGetValue(selectedOption, out var config);

            var (col1, col2, col3) = _filterMapping[selectedOption];

            // Obtém valores dos filtros (ignora placeholders)
            string filter1 = IsPlaceholder(textBoxField1) ? "" : textBoxField1.Text.Trim();
            string filter2 = IsPlaceholder(textBoxField2) ? "" : textBoxField2.Text.Trim();
            string filter3 = IsPlaceholder(textBoxField3) ? "" : textBoxField3.Text.Trim();

            // Remove máscaras para comparação (mantém apenas letras e números)
            filter1 = RemoveMaskForComparison(filter1);
            filter2 = RemoveMaskForComparison(filter2); // Para datas, isso resulta em "ddMMyyyy"
            filter3 = RemoveMaskForComparison(filter3);

            bool hasFilter1 = !string.IsNullOrWhiteSpace(filter1);
            bool hasFilter2 = !string.IsNullOrWhiteSpace(filter2) && col2 != null;
            bool hasFilter3 = !string.IsNullOrWhiteSpace(filter3) && col3 != null;

            // Se não há filtros ativos, retorna todos os dados
            if ( !hasFilter1 && !hasFilter2 && !hasFilter3 )
                return data;

            Debug.WriteLine($"[FILTRO] Aplicando filtros:");
            if ( hasFilter1 ) Debug.WriteLine($"  - Campo 1 ({col1}): '{filter1}'");
            if ( hasFilter2 ) Debug.WriteLine($"  - Campo 2 ({col2}): '{filter2}' (É Data: {config?.IsMask2Date})");
            if ( hasFilter3 ) Debug.WriteLine($"  - Campo 3 ({col3}): '{filter3}'");

            JArray resultado = new JArray();

            foreach ( JObject item in data )
            {
                bool match = true;

                // Filtro 1 (Nunca é data, baseado em _fieldConfigs)
                if ( hasFilter1 )
                {
                    string valor = GetValueFromPath(item, col1);
                    string valorLimpo = RemoveMaskForComparison(valor);
                    match &= valorLimpo.IndexOf(filter1, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                // Filtro 2 (Pode ser data)
                if ( hasFilter2 && match )
                {
                    string valor = GetValueFromPath(item, col2);
                    string valorLimpo;

                    // CORREÇÃO: Verifica se o campo é uma data
                    if ( config != null && config.IsMask2Date )
                    {
                        // Converte a data do cache (ISO) para "ddMMyyyy" para comparar
                        valorLimpo = FormatarDataParaComparacao(valor);
                    }
                    else
                    {
                        valorLimpo = RemoveMaskForComparison(valor);
                    }
                    match &= valorLimpo.IndexOf(filter2, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                // Filtro 3 (Nunca é data, baseado em _fieldConfigs)
                if ( hasFilter3 && match )
                {
                    string valor = GetValueFromPath(item, col3);
                    string valorLimpo = RemoveMaskForComparison(valor);
                    match &= valorLimpo.IndexOf(filter3, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                if ( match )
                    resultado.Add(item);
            }

            Debug.WriteLine($"[FILTRO] Encontrados {resultado.Count} de {data.Count} registros");
            return resultado;
        }

        private string GetValueFromPath(JObject item, string columnName)
        {
            if ( string.IsNullOrEmpty(columnName) ) return "";

            try
            {
                // Mapeamento: Nome da coluna -> caminho no JSON
                switch ( columnName )
                {
                    // Campos diretos do protesto
                    case "ColumnNumDistribuicao":
                        return item["num_distribuicao"]?.ToString() ?? "";

                    case "ColumnDataApresentacao":
                        return item["data_apresentacao"]?.ToString() ?? ""; // Retorna ISO String

                    case "ColumnDataDistribuicao":
                        return item["data_distribuicao"]?.ToString() ?? ""; // Retorna ISO String

                    case "ColumnNumTitulo":
                        return item["num_titulo"]?.ToString() ?? "";

                    case "ColumnVencimento":
                        return item["vencimento"]?.ToString() ?? ""; // Pode ser ISO ou outro formato

                    // Campos do devedor (navega no array notificacao)
                    case "ColumNomeDevedor":
                        var notificacoes = item["notificacao"] as JArray;
                        if ( notificacoes != null && notificacoes.Count > 0 )
                        {
                            var notificacao = notificacoes[0] as JObject;
                            var devedor = notificacao?["devedor"] as JObject;
                            return devedor?["nome"]?.ToString() ?? "";
                        }
                        return "";

                    case "ColumnDocDevedor":
                        var notifDev = item["notificacao"] as JArray;
                        if ( notifDev != null && notifDev.Count > 0 )
                        {
                            var notif = notifDev[0] as JObject;
                            var dev = notif?["devedor"] as JObject;
                            return dev?["doc_devedor"]?.ToString() ?? "";
                        }
                        return "";

                    // Campos do credor (navega no array credores)
                    case "ColumnDocCredor":
                        var credores = item["credores"] as JArray;
                        if ( credores != null && credores.Count > 0 )
                        {
                            var credorObj = credores[0]["credor"] as JObject;
                            return credorObj?["doc_credor"]?.ToString() ?? "";
                        }
                        return "";

                    case "ColumnSacador":
                        var credSac = item["credores"] as JArray;
                        if ( credSac != null && credSac.Count > 0 )
                        {
                            var credObj = credSac[0]["credor"] as JObject;
                            return credObj?["sacador"]?.ToString() ?? "";
                        }
                        return "";

                    case "ColumnCedente":
                        var credCed = item["credores"] as JArray;
                        if ( credCed != null && credCed.Count > 0 )
                        {
                            var credObj = credCed[0]["credor"] as JObject;
                            return credObj?["cedente"]?.ToString() ?? "";
                        }
                        return "";

                    default:
                        // Fallback: tenta buscar diretamente
                        return item[columnName]?.ToString() ?? "";
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao obter valor de {columnName}: {ex.Message}");
                return "";
            }
        }

        // Novo método: remove TUDO exceto letras e números (sem espaços!)
        private string RemoveMaskForComparison(string text)
        {
            if ( string.IsNullOrEmpty(text) ) return "";
            // Remove TUDO que não for letra ou número
            return new string(text.Where(c => char.IsLetterOrDigit(c)).ToArray());
        }

        private void ApplyFilters()
        {
            try
            {
                ShowLoadingIndicator(true, "Aplicando filtros...");

                dataGridViewProtesto.SuspendLayout();
                dataGridViewProtesto.Rows.Clear();

                // Obtém dados do cache
                List<JObject> dadosCache = ProtestoDataCache.GetAllData();

                if ( dadosCache.Count == 0 )
                {
                    Debug.WriteLine("Cache vazio - nenhum dado para filtrar");
                    dataGridViewProtesto.ResumeLayout();
                    UpdateStatusLabel("Nenhum dado disponível");
                    ShowLoadingIndicator(false);
                    return;
                }

                // Aplica filtros
                JArray dados = new JArray(dadosCache);
                JArray dadosFiltrados = FilterData(dados);

                if ( dadosFiltrados.Count == 0 )
                {
                    Debug.WriteLine("Nenhum dado encontrado após filtragem");
                    dataGridViewProtesto.ResumeLayout();
                    UpdateStatusLabel($"Nenhum resultado encontrado (Total: {dados.Count})");
                    ShowLoadingIndicator(false);
                    return;
                }

                // Adiciona os dados filtrados
                // NOTA: A lógica de carregar em background foi removida para simplicidade
                // Se houver problemas de performance com muitos resultados de filtro,
                // a lógica de "AddDataToGridInBatches" pode ser usada aqui.
                foreach ( JObject item in dadosFiltrados )
                {
                    AdicionarLinhaApiTabela(item);
                }
                UpdateStatusLabel($"Exibindo {dadosFiltrados.Count} de {dados.Count} registros");


                if ( dataGridViewProtesto.Rows.Count > 0 )
                {
                    dataGridViewProtesto.Rows[0].Selected = false;
                    dataGridViewProtesto.ClearSelection();
                }

                dataGridViewProtesto.ResumeLayout();
                ShowLoadingIndicator(false);

                Debug.WriteLine($"Filtro aplicado - Resultados: {dadosFiltrados.Count}/{dados.Count}");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao aplicar filtros: {ex.Message}");
                ShowLoadingIndicator(false);
            }
        }

        // Este método não é usado pelo FilterData, que usa RemoveMaskForComparison
        private string RemoveMask(string text)
        {
            if ( string.IsNullOrEmpty(text) ) return "";
            return new string(text.Where(c => char.IsLetterOrDigit(c) || c == ' ').ToArray());
        }


        // --------------------------------- EVENTOS ---------------------------------


        private void TextBoxDocument_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) )
            {
                // Se não for nem dígito nem controle, bloqueia a tecla
                e.Handled = true;
            }
        }

        private void TextBoxAlphaNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // CORREÇÃO: Permite letras, dígitos, espaço OU qualquer caractere de controle
            if ( !char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != ' ' &&
                !char.IsControl(e.KeyChar) )
            {
                // Se não for nenhum dos permitidos, bloqueia a tecla
                e.Handled = true;
            }
        }


        private void textBoxField1_TextChanged(object sender, EventArgs e)
        {
            if ( IsPlaceholder(textBoxField1) ) return;

            var data = textBoxField1.Tag as TextBoxData;

            // Para o timer antes de aplicar a máscara
            _filterTimer.Stop();

            if ( data?.Config?.IsMask1Doc == true )
            {
                ApplyDocumentMask(textBoxField1);
            }

            _filterTimer.Start();
        }

        private void textBoxField2_TextChanged(object sender, EventArgs e)
        {
            if ( IsPlaceholder(textBoxField2) ) return;

            var data = textBoxField2.Tag as TextBoxData;
            bool isDate = data?.Config?.IsMask2Date == true;

            // Para o timer antes de aplicar a máscara
            _filterTimer.Stop();

            // CORREÇÃO: Lógica da máscara de data movida para cá
            if ( isDate )
            {
                string text = new string(textBoxField2.Text.Where(char.IsDigit).ToArray());
                int selStart = textBoxField2.SelectionStart;
                string oldText = textBoxField2.Text;

                if ( text.Length > 8 ) text = text.Substring(0, 8); // Limita a 8 dígitos (ddmmyyyy)

                if ( text.Length > 4 ) text = text.Insert(4, "/"); // ddmm/yyyy
                if ( text.Length > 2 ) text = text.Insert(2, "/"); // dd/mm/yyyy

                if ( textBoxField2.Text != text )
                {
                    textBoxField2.Text = text;
                    // Ajusta o cursor
                    int newSelStart = selStart + ( text.Length - oldText.Length );
                    textBoxField2.SelectionStart = Math.Max(0, Math.Min(newSelStart, text.Length));
                }
            }

            _filterTimer.Start();
        }

        private void textBoxField3_TextChanged(object sender, EventArgs e)
        {
            if ( IsPlaceholder(textBoxField3) ) return;

            _filterTimer.Stop();
            _filterTimer.Start();
        }

        private void comboBoxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Atualiza configuração dos campos
            if ( comboBoxOptions.SelectedItem == null ) return;

            string selected = comboBoxOptions.SelectedItem.ToString();
            if ( _fieldConfigs.TryGetValue(selected, out var config) )
            {
                ConfigureFields(config);
            }

            // Limpa filtros de texto e aplica (para mostrar todos os dados)
            LimparFiltros();
            ApplyFilters(); // Aplica o filtro "vazio"
        }

        private void _filterTimer_Tick(object sender, EventArgs e)
        {
            _filterTimer.Stop();

            string f1 = IsPlaceholder(textBoxField1) ? "" : textBoxField1.Text;
            string f2 = IsPlaceholder(textBoxField2) ? "" : textBoxField2.Text;
            string f3 = IsPlaceholder(textBoxField3) ? "" : textBoxField3.Text;

            Debug.WriteLine($"[FILTRO] Timer tick. Aplicando: F1='{f1}' | F2='{f2}' | F3='{f3}'");
            ApplyFilters();
        }


        private void buttonLimparFiltros_Click(object sender, EventArgs e)
        {
            LimparFiltros();
            ApplyFilters(); // Aplica o filtro "vazio"
        }

        private void LimparFiltros()
        {
            if ( comboBoxOptions.SelectedItem != null )
            {
                string selected = comboBoxOptions.SelectedItem.ToString();
                if ( _fieldConfigs.TryGetValue(selected, out var config) )
                {
                    // Redefine os campos para seus placeholders
                    SetPlaceholder(textBoxField1, config.Placeholder1);
                    if ( config.ShowField2 )
                        SetPlaceholder(textBoxField2, config.Placeholder2);
                    if ( config.ShowField3 )
                        SetPlaceholder(textBoxField3, config.Placeholder3);
                }
            }
            else
            {
                // Fallback se nada estiver selecionado
                SetPlaceholder(textBoxField1, "");
                SetPlaceholder(textBoxField2, "");
                SetPlaceholder(textBoxField3, "");
            }
        }
    }
}