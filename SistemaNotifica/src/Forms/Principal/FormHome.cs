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
using Newtonsoft.Json;
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;


namespace SistemaNotifica.src.Forms
{
    public partial class FormHome : Form
    {
        private readonly ProtestoService _protestoService;

        public FormHome()
        {
            InitializeComponent();
            _protestoService = Program.ProtestoService;              
            ConfigurarDataGridView();
            CarregarGrafico();
            
            LoadProtestoDatagrid();
            LoadDistribData();// teste carregar os dados da API
        }

        private void ConfigurarDataGridView() // Renomeei e centralizei as configurações aqui
        {
            dataGridViewProtesto.Rows.Clear();
            // Ocultar a coluna de cabeçalho de linha (a coluna vazia à esquerda)
            dataGridViewProtesto.RowHeadersVisible = false;

            // Fazer com que o clique selecione a linha inteira
            dataGridViewProtesto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Desabilitar a adição de novas linhas pelo usuário
            dataGridViewProtesto.AllowUserToAddRows = false;

            // Desabilitar a seleção múltipla de linhas
            dataGridViewProtesto.MultiSelect = false;

            // Desabilitar a edição direta das células
            dataGridViewProtesto.ReadOnly = true;
            dataGridViewProtesto.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewProtesto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProtesto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewProtesto.Columns["ColumnNumDist"].MinimumWidth = 20;
            //dataGridViewProtesto.Columns["ColumnNumDist"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
                

        private async Task LoadDistribData()
        {
            try
            {
                Debug.WriteLine("Iniciando LoadDistribData...");
                List<Protesto> dados = await _protestoService.SearchDistAsync();

                //Debug.WriteLine("TESTE TESTE TESTE-----------------------");
                //foreach (Protesto protesto in dados)
                //{
                //    Debug.WriteLine($"Protesto ID: {protesto.id}");
                //    Debug.WriteLine($"Número Distribuição: {protesto.numDistribuicao}");
                //    Debug.WriteLine($"Cartório: {protesto.cartProtesto}");
                //    Debug.WriteLine($"Valor: {protesto.valor}");
                //}
                //Debug.WriteLine("TESTE TESTE TESTE-----------------------");


                if (dados == null)
                {
                    Debug.WriteLine("LoadDistribData: dados retornados são NULL");
                    return;
                }

                Debug.WriteLine($"LoadDistribData - Sucesso: {dados}");                


            }
            catch (Exception ex)
            {
                // ARRUMAR ESSAS EXEPTIONS
                Debug.WriteLine($"Erro em LoadDistribData: {ex.Message}");
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }


        // Carregar os dados da API
        private void LoadProtestoDatagrid()
        {
            // Simulação de dados da sua API
            string json = @"
        [
            {
                ""id"": 13,
                ""numDistribuicao"": ""181"",
                ""dataDistribuicao"": ""2022-11-10T03:00:00.000Z"",
                ""dataApresentacao"": ""2022-11-28T03:00:00.000Z"",
                ""cartProtesto"": ""1° Oficio de Protesto de Títulos de Curitiba"",
                ""numTitulo"": ""90421080357"",
                ""valor"": 354701,
                ""saldo"": 354701,
                ""vencimento"": ""A VISTA"",
                ""devedor"": {
                    ""id"": 13,
                    ""nome"": ""SONIA FRANCA DOS SANTOS"",
                    ""docDevedor"": ""17844209000134"",
                    ""email"": ""meuemail@gmail.com"",
                    ""devedorPj"": true
                },
                ""apresentante"": {
                    ""id"": 4,
                    ""nome"": ""PGFN - Procuradoria Geral da Fazenda Nacional""
                },
                ""credores"": [
                    {
                        ""id"": 4,
                        ""sacador"": ""FAZENDA NACIONAL - DIV.ATIVA-IRPJ"",
                        ""cedente"": ""FAZENDA NACIONAL - DIV.ATIVA-IRPJ""
                    }
                ],
                ""statusNotificacao"": {
                    ""emailEnviado"": false,
                    ""dataEnvio"": null,
                    ""lido"": false,
                    ""dataLeitura"": null,
                    ""trackingToken"": null
                }
            },
            {
                ""id"": 3,
                ""numDistribuicao"": ""47"",
                ""dataDistribuicao"": ""2022-11-03T03:00:00.000Z"",
                ""dataApresentacao"": ""2022-11-29T03:00:00.000Z"",
                ""cartProtesto"": ""1° Oficio de Protesto de Títulos de Curitiba"",
                ""numTitulo"": ""90587"",
                ""valor"": 42642,
                ""saldo"": 42642,
                ""vencimento"": ""07/11/2022"",
                ""devedor"": {
                    ""id"": 3,
                    ""nome"": ""KARIN BARCZYSZYN ODONTOLOGIA EIRELI"",
                    ""docDevedor"": ""31391977000100"",
                    ""email"": ""emailcliente@gmail.com"",
                    ""devedorPj"": true
                },
                ""apresentante"": {
                    ""id"": 1,
                    ""nome"": ""Prefeitura do Município de Curitiba""
                },
                ""credores"": [
                    {
                        ""id"": 1,
                        ""sacador"": ""PREFEITURA MUNICIPAL DE CURITIBA"",
                        ""cedente"": ""PREFEITURA MUNICIPAL DE CURITIBA""
                    }
                ],
                ""statusNotificacao"": {
                    // Sem dados de notificação para este exemplo
                }
            }
        ]";

            try
            {
                // Desserializa o JSON para uma lista de objetos dinâmicos
                List<dynamic> protestos = JsonConvert.DeserializeObject<List<dynamic>>(json);

                // Limpar dados existentes
                dataGridViewProtesto.Rows.Clear();

                // Adicionar cada protesto como uma linha na tabela
                foreach (var protesto in protestos)
                {
                    AdicionarLinhaTabela(protesto);
                }

                // Aplicar cores baseadas no status
                AplicarCoresStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarLinhaTabela(dynamic protesto)
        {
            try
            {
                // Converter data de distribuição
                DateTime dataDistribuicao = DateTime.Parse(protesto.dataDistribuicao.ToString());

                // Determinar status baseado na notificação
                string status = DeterminarStatus(protesto.statusNotificacao);

                // MÉTODO 1: Usando Add direto (mais seguro)
                int rowIndex = dataGridViewProtesto.Rows.Add();
                DataGridViewRow row = dataGridViewProtesto.Rows[rowIndex];

                // Preencher dados usando os nomes das colunas
                row.Cells["ColumnDataDist"].Value = dataDistribuicao;
                row.Cells["ColumnNumDist"].Value = protesto.numDistribuicao.ToString();
                row.Cells["ColumnDevedor"].Value = protesto.devedor.nome.ToString();
                row.Cells["ColumnDocDev"].Value = FormatarDocumento(protesto.devedor.docDevedor.ToString());
                row.Cells["ColumnEmail"].Value = protesto.devedor.email.ToString();

                // Armazenar o status na Tag da linha para usar na coloração
                row.Tag = status;

                Console.WriteLine($"Linha adicionada com sucesso: {protesto.devedor.nome}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MÉTODO 1 falhou: {ex.Message}");
                // MÉTODO 2: Fallback usando índices
                try
                {
                    AdicionarLinhaComIndices(protesto);
                }
                catch (Exception err)
                {                    
                    Console.WriteLine($"Todos os métodos para adicionar COLUNAS falharam ${err.Message}");
                    return;
                }
            }
        }

        // Método alternativo usando índices
        private void AdicionarLinhaComIndices(dynamic protesto)
        {
            DateTime dataDistribuicao = DateTime.Parse(protesto.dataDistribuicao.ToString());
            string status = DeterminarStatus(protesto.statusNotificacao);

            // Adicionar linha vazia primeiro
            int rowIndex = dataGridViewProtesto.Rows.Add();
            DataGridViewRow row = dataGridViewProtesto.Rows[rowIndex];

            // Preencher por índice
            row.Cells[0].Value = dataDistribuicao;
            row.Cells[1].Value = protesto.numDistribuicao.ToString();
            row.Cells[2].Value = protesto.devedor.nome.ToString();
            row.Cells[3].Value = FormatarDocumento(protesto.devedor.docDevedor.ToString());
            row.Cells[4].Value = protesto.devedor.email.ToString();

            row.Tag = status;
            Console.WriteLine($"Linha adicionada por índices: {protesto.devedor.nome}");
        }


        // Determinar status baseado na notificação
        private string DeterminarStatus(dynamic statusNotificacao)
        {
            try
            {
                if (statusNotificacao == null)
                    return "Pendente";

                bool emailEnviado = statusNotificacao.emailEnviado ?? false;
                bool lido = statusNotificacao.lido ?? false;

                if (lido)
                    return "Lido";
                else if (emailEnviado)
                    return "Enviado";
                else
                    return "Pendente";
            }
            catch
            {
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
        private void AplicarCoresStatus()
        {
            foreach (DataGridViewRow row in dataGridViewProtesto.Rows)
            {
                if (row.Tag != null)
                {
                    string status = row.Tag.ToString();

                    switch (status)
                    {
                        case "Lido":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                            break;
                        case "Enviado":
                            row.DefaultCellStyle.BackColor = Color.LightBlue;
                            row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                            break;
                        case "Pendente":
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            row.DefaultCellStyle.ForeColor = Color.DarkOrange;
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
        public void AtualizarDadosTabela(List<dynamic> novosProtestos)
        {
            dataGridViewProtesto.Rows.Clear();

            foreach (var protesto in novosProtestos)
            {
                AdicionarLinhaTabela(protesto);
            }

            AplicarCoresStatus();
        }
    


        //chartDist
        private void CarregarGrafico()
        {
            chartDist.Series.Clear();
            chartDist.ChartAreas.Clear();
            chartDist.Titles.Clear();

            // Criar área do gráfico
            ChartArea areaGrafico = new ChartArea();
            areaGrafico.AxisX.IntervalType = DateTimeIntervalType.Number;
            areaGrafico.AxisX.Interval = 1;
            areaGrafico.AxisX.MajorGrid.Enabled = false;
            areaGrafico.AxisY.MajorGrid.Enabled = false;

            // ALTERAR COR DE FUNDO DA ÁREA INTERNA DO GRÁFICO            
            areaGrafico.BackColor = Color.FromArgb(240, 240, 240); // Cor personalizada --> control.
            chartDist.ChartAreas.Add(areaGrafico);

            // Criar série
            Series serieDados = new Series("Dados da API");
            serieDados.ChartType = SeriesChartType.Column;
            serieDados.IsValueShownAsLabel = true;
            serieDados.LabelFormat = "#";

            // ALTERAR COR DAS COLUNAS
            serieDados.Color = Color.DodgerBlue; // Cor das colunas
                                                 // serieDados.Color = Color.FromArgb(54, 162, 235); // Cor personalizada

            // OPCIONAL: Cor da borda das colunas
            serieDados.BorderColor = Color.DarkBlue;
            serieDados.BorderWidth = 1;

            // VERSÃO DINÂMICA: Arrays com seus dados
            string[] labels = { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
            double[] valores = { 100, 150, 80, 120, 90, 110, 140, 75, 95 };

            // Adicionar pontos dinamicamente
            for (int i = 0; i < labels.Length && i < valores.Length; i++)
            {
                int pontoIndex = serieDados.Points.AddXY(i + 1, valores[i]);
                serieDados.Points[pontoIndex].AxisLabel = labels[i];
            }

            chartDist.Series.Add(serieDados);

            // Adicionar título
            Title titulo = new Title("Gráfico de Dados da API");
            chartDist.Titles.Add(titulo);
        }
    }
}
