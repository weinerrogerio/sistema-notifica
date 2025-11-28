using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;
using SistemaNotifica.src.Utils;
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
using System.Windows.Forms.DataVisualization.Charting;


namespace SistemaNotifica.src.Forms
{
    public partial class FormHome : Form
    {
        private readonly ProtestoService _protestoService;
        private readonly ImportService _importService;

        public event Action OnNavigateToImport;
        public event Action OnNavigateToNotification;

        public FormHome()
        {
            InitializeComponent();
            _protestoService = Program.ProtestoService;
            _importService = Program.ImportService;
            ConfigDataGridView();//Configurando o DataGrid
            LoadDistribData(); // carega dados de distribuição
            LoadDataImport(); // carrega dados de importação -> arquivos impoartados
            CarregarGrafico(); // carrega dados de registros por dia(15 dias ou menos) para gráfico
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
            dataGridViewProtesto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProtesto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewProtesto.AllowUserToResizeRows = false;
            dataGridViewProtesto.AllowUserToResizeColumns = false;

            dataGridViewImports.Rows.Clear();
            dataGridViewImports.RowHeadersVisible = false;
            dataGridViewImports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewImports.AllowUserToAddRows = false;
            dataGridViewImports.MultiSelect = false;
            dataGridViewImports.ReadOnly = true;
            dataGridViewImports.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewImports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewImports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewImports.AllowUserToOrderColumns = false;
            dataGridViewImports.AllowUserToResizeRows = false;
            dataGridViewImports.AllowUserToResizeColumns = false;
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
                var queryParams = new Dictionary<string, string>();
                queryParams.Add("limit", "100");
                queryParams.Add("email", true.ToString());
                Debug.WriteLine("Iniciando LoadDistribData...");
                var dados = await _protestoService.SearchDistAsJArrayAsync(queryParams);

                if ( dados == null || dados.Count == 0 ) return;

                dataGridViewProtesto.Rows.Clear();

                foreach ( var itemProtesto in dados )
                {
                    // Converte para JObject
                    JObject jsonProtesto = JObject.FromObject(itemProtesto);

                    // Passa o objeto inteiro. A função lá dentro vai se virar para achar o devedor.
                    AdicionarLinhaApiTabela(jsonProtesto);
                }

                AplicarCoresGidProtestoStatus();
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro em LoadDistribData: {ex.Message}");
            }
        }

        private void AdicionarLinhaApiTabela(JObject protesto)
        {
            try
            {
                int rowIndex = dataGridViewProtesto.Rows.Add();
                DataGridViewRow row = dataGridViewProtesto.Rows[rowIndex];

                // 1. Dados do Protesto (Raiz)
                // Usamos a classe Format estática conforme sua refatoração anterior
                row.Cells["ColumnDataDistribuicao"].Value = Format.ParaData(protesto["data_distribuicao"]?.ToString());
                row.Cells["ColumnNumDistribuicao"].Value = protesto["num_distribuicao"]?.ToString() ?? string.Empty;

                // 2. Extração dos dados aninhados (Logica do FormData)
                // No FormData, o devedor e o status ficam dentro de "notificacao"
                var notificacoes = protesto["notificacao"] as JArray;

                bool dadosDevedorEncontrados = false;

                if ( notificacoes != null && notificacoes.Count > 0 )
                {
                    // Pega a primeira notificação (ou itere se necessário, mas geralmente é 1 para 1 no grid principal)
                    var notificacao = notificacoes[0] as JObject;

                    if ( notificacao != null )
                    {
                        // Busca o objeto Devedor dentro da Notificação
                        var devedor = notificacao["devedor"] as JObject;

                        if ( devedor != null )
                        {
                            row.Cells["ColumNomeDevedor"].Value = devedor["nome"]?.ToString() ?? string.Empty;
                            row.Cells["ColumnDocDevedor"].Value = Format.ParaDocumento(devedor["doc_devedor"]?.ToString());
                            row.Cells["ColumnEmail"].Value = devedor["email"]?.ToString() ?? string.Empty;
                            dadosDevedorEncontrados = true;
                        }

                        // 3. Lógica de Status (Baseado na Notificação)
                        bool lido = notificacao["lido"]?.Value<bool>() ?? false; // Campo 'lido' geralmente fica na notificação
                        bool enviado = notificacao["email_enviado"]?.Value<bool>() ?? false;

                        string status = lido ? "Lido" : ( enviado ? "Enviado" : "Pendente" );
                        row.Cells["ColumnStatus"].Value = status;
                        row.Tag = status; // Para coloração
                    }
                }

                // Fallback se não achou devedor/notificação
                if ( !dadosDevedorEncontrados )
                {
                    row.Cells["ColumNomeDevedor"].Value = "Sem devedor";
                    row.Cells["ColumnDocDevedor"].Value = "-";
                    row.Cells["ColumnEmail"].Value = "-";
                    row.Cells["ColumnStatus"].Value = "Pendente";
                    row.Tag = "Pendente";
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"FormHome: Erro ao adicionar linha: {ex.Message}");
            }
        }

        // Método alternativo usando índices para dados da API
        private void AdicionarLinhaApiComIndices(Protesto protesto, Devedor devedor)
        {
            string status = DeterminarStatus(protesto.statusNotificacao);

            // Adicionar linha vazia primeiro
            int rowIndex = dataGridViewProtesto.Rows.Add();
            DataGridViewRow row = dataGridViewProtesto.Rows[rowIndex];

            // Preencher por índice (assumindo a ordem: Data, Distribuição, Devedor, Doc.Devedor, Email)
            row.Cells[0].Value = protesto.dataDistribuicao;
            row.Cells[1].Value = protesto.numDistribuicao;

            if (devedor != null)
            {
                row.Cells[2].Value = devedor.nome;
                row.Cells[3].Value = FormatarDocumento(devedor.docDevedor);
                row.Cells[4].Value = devedor.email;
                row.Cells[5].Value = status;
            }
            else
            {
                row.Cells[2].Value = "Sem devedor";
                row.Cells[3].Value = "-";
                row.Cells[4].Value = "-";
                row.Cells[5].Value = status;
            }

            row.Tag = status;
            Debug.WriteLine($"Linha adicionada por índices: {devedor?.nome ?? "Sem devedor"} - Distribuição: {protesto.numDistribuicao}");
        }

        //TABELA DE ARQUIVOS IMPORTADOS E USUÁRIOS

        //dataGridViewImports
        private async void LoadDataImport()
        {
            try
            {
                if (_protestoService == null)
                {
                    Debug.WriteLine("ImportService não foi inicializado!");
                    MessageBox.Show("Erro: Serviço não disponivel, verifique sua conexão.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Debug.WriteLine("Iniciando LoadDataImport...");
                List<DataImportsUser> dados = await _importService.SearchImportsAsync();

                if (dados == null || dados.Count == 0)
                {
                    Debug.WriteLine("LoadDataImport: dados retornados são NULL ou vazios");
                    return;
                }

                Debug.WriteLine($"LoadgDataImport - Sucesso: {dados.Count} registros encontrados");

                // Limpar dados existentes no grid
                dataGridViewImports.Rows.Clear();

                // CORREÇÃO: Loop simples, sem aninhamento desnecessário
                foreach (var file in dados)
                {
                    if (file != null)
                    {
                        AdicionarLinhaApiTabelaFile(file);
                    }
                }

                // Aplicar cores baseadas no status
                AplicarCoresImportStatus();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro em ConfigDataImport: {ex.Message}");
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");

                MessageBox.Show($"Erro ao carregar dados da API de importações: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarLinhaApiTabelaFile(DataImportsUser data)
        {
            try
            {
                string status = data.status;

                // CORREÇÃO: Adicionar linha no grid correto (dataGridViewImports)
                int rowIndex = dataGridViewImports.Rows.Add();
                DataGridViewRow row = dataGridViewImports.Rows[rowIndex];

                // Preencher dados usando os nomes das colunas
                row.Cells["ColumnArquivo"].Value = data.nome_arquivo;
                row.Cells["ColumnDataImport"].Value = data.data_importacao;
                row.Cells["ColumnUser"].Value = data.usuario?.Nome ?? "N/A"; // Proteção contra null
                row.Cells["ColumnStatusArquivo"].Value = data.status;
                // Armazenar o status na Tag da linha para usar na coloração
                row.Tag = status;

                Debug.WriteLine($"Linha de importação adicionada: {data.nome_arquivo} - Status: {status}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao adicionar linha da API de importações: {ex.Message}");

                // Método alternativo usando índices
                try
                {
                    AdicionarLinhaImportComIndices(data);
                }
                catch (Exception err)
                {
                    Debug.WriteLine($"Todos os métodos para adicionar linha de importação falharam: {err.Message}");
                }
            }
        }

        // Método alternativo usando índices
        private void AdicionarLinhaImportComIndices(DataImportsUser data)
        {
            try
            {
                string status = data.status;

                // Adicionar linha vazia primeiro
                int rowIndex = dataGridViewImports.Rows.Add();
                DataGridViewRow row = dataGridViewImports.Rows[rowIndex];

                // Preencher por índice (assumindo ordem: file, dataImportacao, user, status)
                row.Cells[0].Value = data.nome_arquivo;
                row.Cells[1].Value = data.data_importacao;
                row.Cells[2].Value = data.usuario?.Nome ?? "N/A"; // Proteção contra null
                row.Cells[3].Value = data.status;
                row.Tag = status;
                Debug.WriteLine($"Linha de importação adicionada por índices: {data.nome_arquivo} - Status: {status}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao adicionar linha por índices: {ex.Message}");
            }
        }



        // Determinar status baseado na notificação
        private static string DeterminarStatus(StatusNotificacao statusNotificacao)
        {
            try
            {
                if (statusNotificacao == null)
                    return "Pendente";

                if (statusNotificacao.lido)
                    return "Lido";
                else if (statusNotificacao.emailEnviado)
                    return "Enviado";
                else
                    return "Pendente";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao determinar status: {ex.Message}");
                return "Pendente";
            }
        }

        // Formatar documento (CPF/CNPJ)
        private string FormatarDocumento(string documento)
        {
            if (string.IsNullOrEmpty(documento))
                return documento;

            // Remove caracteres não numéricos
            documento = documento.Replace(".", "").Replace("-", "").Replace("/", "");

            if (documento.Length == 11) // CPF
            {
                return $"{documento.Substring(0, 3)}.{documento.Substring(3, 3)}.{documento.Substring(6, 3)}-{documento.Substring(9, 2)}";
            }
            else if (documento.Length == 14) // CNPJ
            {
                return $"{documento.Substring(0, 2)}.{documento.Substring(2, 3)}.{documento.Substring(5, 3)}/{documento.Substring(8, 4)}-{documento.Substring(12, 2)}";
            }

            return documento;
        }

        // Aplicar cores baseadas no status
        private void AplicarCoresImportStatus()
        {
            foreach (DataGridViewRow row in dataGridViewImports.Rows)
            {
                if (row.Tag != null)
                {
                    string status = row.Tag.ToString();

                    switch (status)
                    {
                        case "sucesso":
                            row.DefaultCellStyle.BackColor = Color.Green;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case "parcial":
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case "falha":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 142, 136);
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                    }
                }
            }
        }

        private void AplicarCoresGidProtestoStatus()
        {
            foreach (DataGridViewRow row in dataGridViewProtesto.Rows)
            {
                if (row.Tag != null)
                {
                    string status = row.Tag.ToString();

                    switch (status)
                    {
                        case "Lido":
                            row.DefaultCellStyle.BackColor = Color.Green;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case "Enviado":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case "Pendente":
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                    }
                }
            }
        }

        // Método para atualizar dados (útil para quando os dados reais vierem da API)
        //private void AtualizarDadosTabela(List<dynamic> novosProtestos)
        //{
        //    dataGridViewProtesto.Rows.Clear();

        //    foreach (var protesto in novosProtestos)
        //    {
        //        AdicionarLinhaApiTabela(protesto, protesto.devedor);
        //    }

        //    AplicarCoresGidProtestoStatus();
        //}



        //chartDist
        private async Task CarregarGrafico()
        {
            chartDist.Series.Clear();
            chartDist.ChartAreas.Clear();
            chartDist.Titles.Clear();

            // Criar área do gráfico
            ChartArea areaGrafico = new();
            areaGrafico.AxisX.IntervalType = DateTimeIntervalType.Number;
            areaGrafico.AxisX.Interval = 1;
            areaGrafico.AxisX.MajorGrid.Enabled = false;
            areaGrafico.AxisY.MajorGrid.Enabled = false;
            areaGrafico.BackColor = Color.FromArgb(240, 240, 240);
            chartDist.ChartAreas.Add(areaGrafico);

            // Criar série
            Series serieDados = new("Quantidade por Data")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LabelFormat = "#",
                Color = Color.DodgerBlue
            };

            chartDist.Legends.Clear();
            chartDist.TabStop = false;
            chartDist.Cursor = Cursors.Default;
            chartDist.Enabled = false;

            try
            {
                // 🔥 NOVA CHAMADA - Busca os últimos 15 dias com dados
                List<ChartDataPoint> dadosGrafico = await _protestoService.GetLastDaysWithDataAsync(15);

                Debug.WriteLine($"Total de dias com dados recebidos: {dadosGrafico.Count}");

                if ( dadosGrafico == null || dadosGrafico.Count == 0 )
                {
                    Debug.WriteLine("Nenhum dado encontrado para o gráfico");

                    // Adicionar mensagem no gráfico
                    Title tituloSemDados = new Title("Nenhum dado encontrado nos últimos registros")
                    {
                        Font = new Font("Arial", 10, FontStyle.Italic),
                        ForeColor = Color.Gray
                    };
                    chartDist.Titles.Add(tituloSemDados);
                    return;
                }

                // Adicionar pontos ao gráfico
                for ( int i = 0; i < dadosGrafico.Count; i++ )
                {
                    var ponto = dadosGrafico[i];
                    int pontoIndex = serieDados.Points.AddXY(i + 1, ponto.quantidade);
                    serieDados.Points[pontoIndex].AxisLabel = ponto.data.ToString("dd/MM/yyyy");

                    Debug.WriteLine($"Ponto {i + 1}: Data: {ponto.data:dd/MM/yyyy}, Quantidade: {ponto.quantidade}");
                }

                chartDist.Series.Add(serieDados);

                // Adicionar título com informação contextual
                string periodoInicio = dadosGrafico[0].data.ToString("dd/MM/yyyy");
                string periodoFim = dadosGrafico[^1].data.ToString("dd/MM/yyyy");

                Title titulo = new Title($"Últimos {dadosGrafico.Count} dias com registros ({periodoInicio} - {periodoFim})")
                {
                    Font = new Font("Arial", 11, FontStyle.Bold)
                };
                chartDist.Titles.Add(titulo);
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao carregar gráfico: {ex.Message}");
                Debug.WriteLine($"StackTrace: {ex.StackTrace}");

                // Exibir mensagem de erro no gráfico
                Title tituloErro = new Title($"Erro ao carregar dados: {ex.Message}")
                {
                    Font = new Font("Arial", 9, FontStyle.Italic),
                    ForeColor = Color.Red
                };
                chartDist.Titles.Add(tituloErro);
            }
        }
        

        // fazer evento de transição para form de importação - -> não exibir form, APENAS PUXAR A FUNÇÃO DE IMPORTAÇÃO
        private void btnImport_Click(object sender, EventArgs e)
        {
            OnNavigateToImport?.Invoke();
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            OnNavigateToNotification?.Invoke();
        }
    }
}
