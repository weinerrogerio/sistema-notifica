using Newtonsoft.Json.Linq;
using SistemaNotifica.src.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormData : Form
    {
        private readonly ProtestoService _protestoService;
        //CommonClasses common = new CommonClasses();

        // Variáveis para controle de paginação
        private int currentPage = 1;
        private int pageSize = 100;
        private int totalPages = 1;
        private bool isLoadingData = false;

        public FormData()
        {
            InitializeComponent();
            _protestoService = Program.ProtestoService;
            ConfigDataGridView();
            LoadDistribData();
        }

        private void ConfigDataGridView()
        {
            dataGridViewProtesto.Rows.Clear();
            dataGridViewProtesto.RowHeadersVisible = false;
            dataGridViewProtesto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProtesto.AllowUserToAddRows = false;
            dataGridViewProtesto.MultiSelect = false;
            dataGridViewProtesto.ReadOnly = true;
            dataGridViewProtesto.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // CONFIGURAÇÕES DE SCROLL HORIZONTAL E VERTICAL
            dataGridViewProtesto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Mudança importante!
            dataGridViewProtesto.ScrollBars = ScrollBars.Both; // Habilita ambos os scrolls
            dataGridViewProtesto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewProtesto.AllowUserToResizeRows = false;
            dataGridViewProtesto.AllowUserToResizeColumns = true;

            // Configurar larguras mínimas das colunas para forçar scroll horizontal
            ConfigurarLargurasColunas();

            // Adicionar evento para rolagem infinita
            dataGridViewProtesto.Scroll += DataGridViewProtesto_Scroll;
        }

        private void ConfigurarLargurasColunas()
        {
            // Definir larguras específicas para cada coluna (ajuste conforme necessário)
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

            foreach (DataGridViewColumn coluna in dataGridViewProtesto.Columns)
            {
                if (configColunas.ContainsKey(coluna.Name))
                {
                    coluna.Width = configColunas[coluna.Name];
                    coluna.MinimumWidth = configColunas[coluna.Name] - 20; // Permite redimensionamento mas com limite
                }
            }
        }

        // Evento para detectar rolagem e implementar scroll infinito
        private async void DataGridViewProtesto_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll && !isLoadingData)
            {
                // Verificar se chegou próximo ao final
                var grid = sender as DataGridView;
                if (grid != null)
                {
                    int visibleRows = grid.DisplayedRowCount(false);
                    int firstDisplayedRowIndex = grid.FirstDisplayedScrollingRowIndex;
                    int totalRows = grid.RowCount;

                    // Se está nos últimos 10 registros visíveis e ainda há páginas para carregar
                    if (firstDisplayedRowIndex + visibleRows >= totalRows - 10 && currentPage < totalPages)
                    {
                        Debug.WriteLine($"Carregando próxima página. Página atual: {currentPage}, Total páginas: {totalPages}");
                        await LoadNextPage();
                    }
                }
            }
        }

        private async Task LoadDistribData()
        {
            try
            {
                if (_protestoService == null)
                {
                    Debug.WriteLine("ProtestoService não foi inicializado!");
                    MessageBox.Show("Erro: Serviço não disponivel, verifique sua conexão.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                isLoadingData = true;
                currentPage = 1; // Reset para primeira página

                Debug.WriteLine("Iniciando LoadDistribData...");

                JObject response = await .FindByPagination(currentPage, pageSize);
                Debug.WriteLine("RESPONSE LoadData:::::::::::::::" + response);

                var dados = response["data"] as JArray;
                if (dados == null || dados.Count == 0)
                {
                    Debug.WriteLine("LoadDistribData: dados retornados são NULL ou vazios");
                    return;
                }

                // Atualizar informações de paginação
                totalPages = response["totalPages"]?.Value<int>() ?? 1;

                Debug.WriteLine($"LoadDistribData - Sucesso: {dados.Count} registros encontrados");
                Debug.WriteLine($"Página atual: {currentPage}, Total páginas: {totalPages}");

                // Limpar dados existentes no grid apenas na primeira carga
                dataGridViewProtesto.Rows.Clear();

                // Adicionar dados ao grid
                AdicionarDadosAoGrid(dados);

                isLoadingData = false;
            }
            catch (Exception ex)
            {
                isLoadingData = false;
                Debug.WriteLine($"Erro em LoadDistribData: {ex.Message}");
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");

                MessageBox.Show($"Erro ao carregar dados da API: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadNextPage()
        {
            try
            {
                if (isLoadingData || currentPage >= totalPages)
                    return;

                isLoadingData = true;
                currentPage++;

                Debug.WriteLine($"Carregando página {currentPage} de {totalPages}");

                JObject response = await _protestoService.FindByPagination(currentPage, pageSize);
                var dados = response["data"] as JArray;

                if (dados != null && dados.Count > 0)
                {
                    // Adicionar novos dados sem limpar os existentes
                    AdicionarDadosAoGrid(dados);
                    Debug.WriteLine($"Página {currentPage} carregada com {dados.Count} registros");
                }

                isLoadingData = false;
            }
            catch (Exception ex)
            {
                isLoadingData = false;
                currentPage--; // Reverter em caso de erro
                Debug.WriteLine($"Erro ao carregar próxima página: {ex.Message}");
            }
        }

        private void AdicionarDadosAoGrid(JArray dados)
        {
            // Para cada protesto, adicionar uma linha para cada notificação/devedor
            foreach (JObject protesto in dados)
            {
                var notificacoes = protesto["notificacao"] as JArray;

                if (notificacoes != null && notificacoes.Count > 0)
                {
                    // Se houver notificações, criar uma linha para cada devedor
                    foreach (JObject notificacao in notificacoes)
                    {
                        AdicionarLinhaApiTabela(protesto, notificacao);
                    }
                }
                else
                {
                    // Se não houver notificações, ainda assim adiciona uma linha (com dados de devedor vazios)
                    AdicionarLinhaApiTabela(protesto, null);
                }
            }

            Debug.WriteLine($"Total de linhas no grid: {dataGridViewProtesto.Rows.Count}");
        }

        private void AdicionarLinhaApiTabela(JObject protesto, JObject notificacao)
        {
            try
            {
                // Adicionar nova linha
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
                row.Cells["distrib_createdAt"].Value = FormatarData(protesto["createdAt"]?.ToString());

                // Dados do apresentante
                var apresentante = protesto["apresentante"] as JObject;
                if (apresentante != null)
                {
                    row.Cells["ColumnNomeApresentante"].Value = apresentante["nome"]?.ToString() ?? string.Empty;
                    row.Cells["ColumnCodApresentante"].Value = apresentante["cod_apresentante"]?.ToString() ?? string.Empty;
                }

                // Dados do credor (primeiro credor da lista)
                var credores = protesto["credores"] as JArray;
                if (credores != null && credores.Count > 0)
                {
                    var primeiroCredor = credores[0]["credor"] as JObject;
                    if (primeiroCredor != null)
                    {
                        row.Cells["ColumnSacador"].Value = primeiroCredor["sacador"]?.ToString() ?? string.Empty;
                        row.Cells["ColumnCedente"].Value = primeiroCredor["cedente"]?.ToString() ?? string.Empty;
                        row.Cells["ColumnDocCredor"].Value = FormatarDocumento(primeiroCredor["doc_credor"]?.ToString());
                    }
                }

                // Dados do devedor (se houver notificação)
                if (notificacao != null)
                {
                    var devedor = notificacao["devedor"] as JObject;
                    if (devedor != null)
                    {
                        row.Cells["ColumNomeDevedor"].Value = devedor["nome"]?.ToString() ?? string.Empty;
                        row.Cells["ColumnDocDevedor"].Value = FormatarDocumento(devedor["doc_devedor"]?.ToString());
                    }

                    // Dados da notificação
                    row.Cells["ColumnEmailEnviado"].Value = (notificacao["email_enviado"]?.Value<bool>() == true) ? "Sim" : "Não";
                    row.Cells["ColumnDataEnvio"].Value = FormatarData(notificacao["data_envio"]?.ToString());
                }
                else
                {
                    // Valores vazios para devedor quando não há notificação
                    row.Cells["ColumNomeDevedor"].Value = string.Empty;
                    row.Cells["ColumnDocDevedor"].Value = string.Empty;
                    row.Cells["ColumnEmailEnviado"].Value = "Não";
                    row.Cells["ColumnDataEnvio"].Value = string.Empty;
                }

                // Dados do arquivo
                var file = protesto["file"] as JObject;
                if (file != null)
                {
                    row.Cells["nome_arquivo"].Value = file["nome_arquivo"]?.ToString() ?? string.Empty;
                    row.Cells["file_data_importacao"].Value = FormatarData(file["data_importacao"]?.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao adicionar linha da API: {ex.Message}");
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        // Métodos auxiliares para formatação
        private string FormatarData(string dataString)
        {
            if (string.IsNullOrEmpty(dataString))
                return string.Empty;

            try
            {
                if (DateTime.TryParse(dataString, out DateTime data))
                {
                    return data.ToString("dd/MM/yyyy HH:mm");
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
            if (string.IsNullOrEmpty(valorString))
                return "R$ 0,00";

            try
            {
                if (decimal.TryParse(valorString, out decimal valor))
                {
                    // Converter centavos para reais (dividir por 100)
                    decimal valorEmReais = valor / 100;
                    return valorEmReais.ToString("C2"); // Formato de moeda
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
            if (string.IsNullOrEmpty(documento))
                return string.Empty;

            // Remove caracteres não numéricos
            documento = System.Text.RegularExpressions.Regex.Replace(documento, @"[^\d]", "");

            // Formatar CPF ou CNPJ
            if (documento.Length == 11) // CPF
            {
                return Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00");
            }
            else if (documento.Length == 14) // CNPJ
            {
                return Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
            }

            return documento;
        }

        // Método público para atualizar dados (útil para refresh)
        public async Task RefreshData()
        {
            await LoadDistribData();
        }

        // Método para mostrar indicador de carregamento (opcional)
        private void ShowLoadingIndicator(bool show)
        {
            // Você pode implementar um indicador visual de carregamento aqui
            // Por exemplo, mudar o cursor ou mostrar uma mensagem no status bar
            this.Cursor = show ? Cursors.WaitCursor : Cursors.Default;
        }

        private void FormData_Load(object sender, EventArgs e)
        {

        }


    }
}
