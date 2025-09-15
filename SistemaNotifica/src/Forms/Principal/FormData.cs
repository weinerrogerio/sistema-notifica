using Newtonsoft.Json.Linq;
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;
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

        // Variáveis para controle de paginação otimizada
        private int currentPage = 1;
        private int pageSize = 50; // Aumentado para balance entre performance e memória
        private int totalPages = 1;
        private bool isLoadingData = false;

        // Controle de carregamento progressivo otimizado
        private CancellationTokenSource _cancellationTokenSource;
        private const int BATCH_DELAY_MS = 100; // Delay entre batches para não travar UI
        private const int VIRTUAL_MODE_THRESHOLD = 1000; // Limite para ativar modo virtual

        // Cache para modo virtual (se necessário)
        private List<JObject> _dataCache = new List<JObject>();
        private bool _isVirtualMode = false;

        public FormData()
        {
            InitializeComponent();
            _protestoService = Program.ProtestoService;
            ConfigDataGridView();
            LoadDistribData();
        }

        private void ConfigDataGridView()
        {
            // Suspender layout para melhor performance
            dataGridViewProtesto.SuspendLayout();

            dataGridViewProtesto.Rows.Clear();
            dataGridViewProtesto.RowHeadersVisible = false;
            dataGridViewProtesto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProtesto.AllowUserToAddRows = false;
            dataGridViewProtesto.MultiSelect = false;
            dataGridViewProtesto.ReadOnly = true;
            dataGridViewProtesto.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // OTIMIZAÇÕES DE PERFORMANCE
            dataGridViewProtesto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewProtesto.ScrollBars = ScrollBars.Both;
            dataGridViewProtesto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewProtesto.AllowUserToResizeRows = false;
            dataGridViewProtesto.AllowUserToResizeColumns = true;

            // CONFIGURAÇÕES CRÍTICAS PARA PERFORMANCE
            // Reduz flickering
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, dataGridViewProtesto, new object[] { true });
            dataGridViewProtesto.EnableHeadersVisualStyles = false; // Melhora performance
            dataGridViewProtesto.CellPainting += DataGridViewProtesto_CellPainting; // Pintura customizada se necessário

            ConfigurarLargurasColunas();

            dataGridViewProtesto.ResumeLayout();
        }

        private void DataGridViewProtesto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Otimização de pintura - implementar apenas se necessário
            // Para grandes volumes de dados, pode ser útil customizar a pintura
        }

        private void ConfigurarLargurasColunas()
        {
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
                    coluna.MinimumWidth = configColunas[coluna.Name] - 20;
                }
            }
        }

        private async Task LoadDistribData()
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

                // Cancela qualquer carregamento anterior
                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource = new CancellationTokenSource();

                isLoadingData = true;
                currentPage = 1;
                totalPages = 1;
                _dataCache.Clear();

                // Limpa a grade e suspende atualizações para melhor performance
                dataGridViewProtesto.SuspendLayout();
                dataGridViewProtesto.Rows.Clear();
                dataGridViewProtesto.ResumeLayout();

                ShowLoadingIndicator(true);

                Debug.WriteLine("Iniciando LoadDistribData otimizado...");

                // Verifica se deve usar modo virtual baseado no total estimado
                await LoadAllPagesProgressively(_cancellationTokenSource.Token);

                Debug.WriteLine($"LoadDistribData concluído. Total de registros: {dataGridViewProtesto.Rows.Count}");
            }
            catch ( OperationCanceledException )
            {
                Debug.WriteLine("Carregamento cancelado pelo usuário");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro em LoadDistribData: {ex.Message}");
                MessageBox.Show($"Erro ao carregar dados da API: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingData = false;
                ShowLoadingIndicator(false);
            }
        }

        private async Task LoadAllPagesProgressively(CancellationToken cancellationToken)
        {
            currentPage = 1;
            var batchRows = new List<DataGridViewRow>();
            const int BATCH_SIZE = 100; // Processa em lotes de 100 registros

            do
            {
                cancellationToken.ThrowIfCancellationRequested();

                Debug.WriteLine($"Carregando página {currentPage}...");

                JObject response = await _protestoService.GetAsJObjectAsync(currentPage.ToString(), pageSize.ToString());
                var dados = response["data"] as JArray;

                if ( dados != null && dados.Count > 0 )
                {
                    // Atualizar informações de paginação na primeira execução
                    if ( currentPage == 1 )
                    {
                        totalPages = response["lastPage"]?.Value<int>() ?? 1;
                        var totalRecords = response["total"]?.Value<int>() ?? 0;

                        Debug.WriteLine($"Total de páginas: {totalPages}, Total registros: {totalRecords}");

                        // Decide se usar modo virtual para grandes volumes
                        if ( totalRecords > VIRTUAL_MODE_THRESHOLD )
                        {
                            _isVirtualMode = true;
                            Debug.WriteLine("Ativando modo virtual para grande volume de dados");
                        }
                    }

                    // Processar dados em batch para não travar a UI
                    await ProcessDataInBatches(dados, cancellationToken);

                    Debug.WriteLine($"Página {currentPage} processada. Total no grid: {dataGridViewProtesto.Rows.Count}");

                    // Atualiza a UI para mostrar progresso
                    UpdateProgressStatus(currentPage, totalPages);

                    // Delay controlado entre páginas para não sobrecarregar a UI
                    await Task.Delay(BATCH_DELAY_MS, cancellationToken);
                }
                else
                {
                    Debug.WriteLine($"Página {currentPage} retornou dados vazios");
                    break;
                }

                currentPage++;

                // Força garbage collection periodicamente para grandes volumes
                if ( currentPage % 10 == 0 )
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

            } while ( currentPage <= totalPages && !cancellationToken.IsCancellationRequested );

            Debug.WriteLine($"Carregamento concluído. Páginas: {currentPage - 1}/{totalPages}");
        }

        private async Task ProcessDataInBatches(JArray data, CancellationToken cancellationToken)
        {
            dataGridViewProtesto.SuspendLayout();

            try
            {
                foreach ( JObject item in data )
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    // Adiciona linha diretamente no grid
                    AdicionarLinhaApiTabela(item);

                    // A cada 10 registros, permite que a UI se atualize
                    if ( dataGridViewProtesto.Rows.Count % 10 == 0 )
                    {
                        dataGridViewProtesto.ResumeLayout();
                        await Task.Delay(5, cancellationToken); // Delay mínimo
                        dataGridViewProtesto.SuspendLayout();
                    }
                }
            }
            finally
            {
                dataGridViewProtesto.ResumeLayout();
            }
        }

        private async Task AdicionarLinhasEmLote(List<DataGridViewRow> rows)
        {
            if ( rows.Count == 0 ) return;

            // Suspende o layout durante a adição em lote
            dataGridViewProtesto.SuspendLayout();

            try
            {
                // Adiciona todas as rows de uma vez
                DataGridViewRow[] rowArray = rows.ToArray();
                dataGridViewProtesto.Rows.AddRange(rowArray);
            }
            finally
            {
                dataGridViewProtesto.ResumeLayout();
            }

            // Permite que a UI se atualize
            await Task.Yield();
        }

        private void AdicionarLinhaApiTabela(JObject protesto)
        {
            try
            {
                // Adicionar nova linha diretamente no grid
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

                // Dados do credor (primeiro credor da lista)
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

                var file = protesto["file"] as JObject;
                if ( file != null )
                {
                    row.Cells["nome_arquivo"].Value = file["nome_arquivo"]?.ToString() ?? string.Empty;
                    row.Cells["file_data_importacao"].Value = FormatarData(file["data_importacao"]?.ToString());
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao adicionar linha da API: {ex.Message}");
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        // Cache dos índices das colunas para performance
        private Dictionary<string, int> _columnIndicesCache;

        private Dictionary<string, int> GetColumnIndices()
        {
            if ( _columnIndicesCache == null )
            {
                _columnIndicesCache = new Dictionary<string, int>();
                for ( int i = 0; i < dataGridViewProtesto.Columns.Count; i++ )
                {
                    _columnIndicesCache[dataGridViewProtesto.Columns[i].Name] = i;
                }
            }
            return _columnIndicesCache;
        }

        // Método otimizado para atualizar status do progresso
        private void UpdateProgressStatus(int currentPage, int totalPages)
        {
            if ( totalPages > 0 )
            {
                int percentual = ( int ) ( ( double ) currentPage / totalPages * 100 );
                int registrosCarregados = dataGridViewProtesto.Rows.Count;

                this.Text = $"Sistema Notifica - Carregando... {percentual}% ({registrosCarregados} registros)";

                // Força atualização da UI sem travar
                Application.DoEvents();
            }
        }

        // Método para cancelar o carregamento
        public void CancelLoading()
        {
            _cancellationTokenSource?.Cancel();
        }

        // Métodos auxiliares para formatação (otimizados)
        private readonly Dictionary<string, string> _dataCache_formatted = new Dictionary<string, string>();

        private string FormatarData(string dataString)
        {
            if ( string.IsNullOrEmpty(dataString) )
                return string.Empty;

            // Cache para datas já formatadas
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

        // Método público para atualizar dados
        public async Task RefreshData()
        {
            await LoadDistribData();
        }

        // Método para mostrar indicador de carregamento
        private void ShowLoadingIndicator(bool show)
        {
            this.Cursor = show ? Cursors.WaitCursor : Cursors.Default;

            if ( !show )
            {
                this.Text = "Sistema Notifica";

                // Limpa cache de formatação periodicamente
                if ( _dataCache_formatted.Count > 1000 )
                {
                    _dataCache_formatted.Clear();
                }
            }
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            // Configurações adicionais de performance se necessário
        }

        // Limpar recursos ao fechar o form
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _dataCache?.Clear();
            _dataCache_formatted?.Clear();
            base.OnFormClosed(e);
        }

        // Método para implementar scroll infinito se necessário
        public void EnableInfiniteScroll()
        {
            dataGridViewProtesto.Scroll += async (sender, e) =>
            {
                if ( e.ScrollOrientation == ScrollOrientation.VerticalScroll && !isLoadingData )
                {
                    var grid = sender as DataGridView;
                    if ( grid != null )
                    {
                        int visibleRows = grid.DisplayedRowCount(false);
                        int firstDisplayedRowIndex = grid.FirstDisplayedScrollingRowIndex;
                        int totalRows = grid.RowCount;

                        // Carrega mais dados quando próximo do final
                        if ( firstDisplayedRowIndex + visibleRows >= totalRows - 50 )
                        {
                            // Implementar carregamento de mais páginas se necessário
                        }
                    }
                }
            };
        }
    }
}