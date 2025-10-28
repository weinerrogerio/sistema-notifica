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


        // -------------------------------------- FILTROS E AÇÕES DE FILTROS --------------------------------------   

               

        // Estrutura para configuração dos campos
        private class FieldConfig
        {
            public string Label1 { get; set; }
            public string Placeholder1 { get; set; }
            public bool IsMask1Doc { get; set; }
            public bool IsMask1Date { get; set; }

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
            comboBoxOptions.SelectedIndexChanged += ComboBoxOptions_SelectedIndexChanged;

            // Configurar eventos dos TextBoxes
            textBoxField1.Enter += TextBox_Enter;
            textBoxField1.Leave += TextBox_Leave;
            textBoxField1.TextChanged += TextBoxField1_TextChanged;

            textBoxField2.Enter += TextBox_Enter;
            textBoxField2.Leave += TextBox_Leave;
            textBoxField2.TextChanged += TextBoxField2_TextChanged;

            textBoxField3.Enter += TextBox_Enter;
            textBoxField3.Leave += TextBox_Leave;

            // Inicializar campos ocultos
            HideAllFields();
        }

        private void ComboBoxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( comboBoxOptions.SelectedItem == null ) return;

            string selected = comboBoxOptions.SelectedItem.ToString();

            if ( _fieldConfigs.TryGetValue(selected, out var config) )
            {
                ConfigureFields(config);
            }
        }

        private void ConfigureFields(FieldConfig config)
        {
            // Campo 1 - sempre visível
            labelField1.Text = config.Label1;
            SetPlaceholder(textBoxField1, config.Placeholder1);
            labelField1.Visible = true;
            textBoxField1.Visible = true;
            RemoveMask(textBoxField1);

            // Campo 2
            if ( config.ShowField2 )
            {
                labelField2.Text = config.Label2;
                SetPlaceholder(textBoxField2, config.Placeholder2);
                labelField2.Visible = true;
                textBoxField2.Visible = true;

                if ( config.IsMask2Date )
                    ApplyDateMask(textBoxField2);
                else
                    RemoveMask(textBoxField2);
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
                SetPlaceholder(textBoxField3, config.Placeholder3);
                labelField3.Visible = true;
                textBoxField3.Visible = true;
            }
            else
            {
                labelField3.Visible = false;
                textBoxField3.Visible = false;
            }

            // Guarda configuração para aplicar máscaras dinâmicas
            textBoxField1.Tag = config;
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

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            textBox.Tag = new { Placeholder = placeholder, Config = textBox.Tag };
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            var textBox = ( TextBox ) sender;
            var tag = textBox.Tag as dynamic;

            if ( textBox.ForeColor == Color.Gray && tag?.Placeholder != null )
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            var textBox = ( TextBox ) sender;
            var tag = textBox.Tag as dynamic;

            if ( string.IsNullOrWhiteSpace(textBox.Text) && tag?.Placeholder != null )
            {
                textBox.Text = tag.Placeholder;
                textBox.ForeColor = Color.Gray;
            }
        }

        private void TextBoxField1_TextChanged(object sender, EventArgs e)
        {
            if ( textBoxField1.ForeColor == Color.Gray ) return; // Ignorar placeholder

            var config = textBoxField1.Tag as FieldConfig;
            if ( config?.IsMask1Doc == true && !string.IsNullOrWhiteSpace(textBoxField1.Text) )
            {
                ApplyDocumentMask(textBoxField1);
            }
        }

        private void TextBoxField2_TextChanged(object sender, EventArgs e)
        {
            // Máscara de data já aplicada no ConfigureFields se necessário
        }

        private void ApplyDocumentMask(TextBox textBox)
        {
            string text = new string(textBox.Text.Where(char.IsDigit).ToArray());

            if ( text.Length <= 11 ) // CPF
            {
                if ( text.Length > 3 ) text = text.Insert(3, ".");
                if ( text.Length > 7 ) text = text.Insert(7, ".");
                if ( text.Length > 11 ) text = text.Insert(11, "-");
            }
            else // CNPJ
            {
                if ( text.Length > 2 ) text = text.Insert(2, ".");
                if ( text.Length > 6 ) text = text.Insert(6, ".");
                if ( text.Length > 10 ) text = text.Insert(10, "/");
                if ( text.Length > 15 ) text = text.Insert(15, "-");
            }

            int cursorPos = textBox.SelectionStart;
            textBox.Text = text;
            textBox.SelectionStart = Math.Min(cursorPos, text.Length);
        }

        private void ApplyDateMask(TextBox textBox)
        {
            textBox.TextChanged += (s, e) =>
            {
                if ( textBox.ForeColor == Color.Gray ) return;

                string text = new string(textBox.Text.Where(char.IsDigit).ToArray());

                if ( text.Length > 2 ) text = text.Insert(2, "/");
                if ( text.Length > 5 ) text = text.Insert(5, "/");
                if ( text.Length > 10 ) text = text.Substring(0, 10);

                int cursorPos = textBox.SelectionStart;
                textBox.Text = text;
                textBox.SelectionStart = Math.Min(cursorPos, text.Length);
            };
        }

        private void RemoveMask(TextBox textBox)
        {
            // Remove handlers de máscara anteriores recriando o controle se necessário
            textBox.Text = "";
        }








        //----------------------------------------------------------------------------------------------


        // botão para refazer buscas --> descarta dados em cache e refaz a busca
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DialogResult question = MessageBox.Show("Refazer busca?",
                "Tem certeza que deseja refazer a busca no banco de dados? \n" +
                "Dependendo a quandiade de dados que voce tem, isso pode levar algum tempo",
                MessageBoxButtons.YesNo);

            if ( question == DialogResult.Yes )
            {
                // TODO --> reafazer a busca na a api e atualizar os dados no grid
                // --> refaz busca, limpa os dados em cache, adiciona os novos e atualiza o grid
            }
            else
            {
                // TODO --> apenas cancelar a busca
            }
        }

        private void textBoxFiled1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxField2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFiled3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}