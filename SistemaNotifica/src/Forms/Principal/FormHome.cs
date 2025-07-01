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
            //LoadProtestoDatagrid();
            LoadDistribData(); // carregar os dados da API e preencher o grid
            //CarregarGrafico();
            //getDataToChart(startDate: new DateTime(2025, 6, 2), endDate: new DateTime(2025, 6, 17));
            CarregarGrafico();
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
            //dataGridViewProtesto.Columns["ColumnNumDist"].MinimumWidth = 20;
            //dataGridViewProtesto.Columns["ColumnNumDist"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }


        private async Task LoadDistribData()
        {
            try
            {
                Debug.WriteLine("Iniciando LoadDistribData...");
                List<Protesto> dados = await _protestoService.SearchDistAsync();

                if (dados == null || dados.Count == 0)
                {
                    Debug.WriteLine("LoadDistribData: dados retornados são NULL ou vazios");
                    return;
                }

                Debug.WriteLine($"LoadDistribData - Sucesso: {dados.Count} registros encontrados");

                // Limpar dados existentes no grid
                dataGridViewProtesto.Rows.Clear();

                // Para cada protesto, adicionar uma linha para cada devedor
                foreach (var protesto in dados)
                {
                    if (protesto.devedor != null && protesto.devedor.Count > 0)
                    {
                        foreach (var devedor in protesto.devedor)
                        {
                            AdicionarLinhaApiTabela(protesto, devedor);
                        }
                    }
                    else
                    {
                        // Se não houver devedores, ainda assim adiciona uma linha (com dados de devedor vazios)
                        AdicionarLinhaApiTabela(protesto, null);
                    }
                }

                // Aplicar cores baseadas no status
                AplicarCoresStatus();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro em LoadDistribData: {ex.Message}");
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");

                MessageBox.Show($"Erro ao carregar dados da API: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        private void AdicionarLinhaApiTabela(Protesto protesto, Devedor devedor)
        {
            try
            {
                // Determinar status baseado na notificação
                string status = DeterminarStatus(protesto.statusNotificacao);

                // Adicionar nova linha
                int rowIndex = dataGridViewProtesto.Rows.Add();
                DataGridViewRow row = dataGridViewProtesto.Rows[rowIndex];

                // Preencher dados usando os nomes das colunas
                row.Cells["ColumnDataDist"].Value = protesto.dataDistribuicao;
                row.Cells["ColumnNumDist"].Value = protesto.numDistribuicao;

                // Dados do devedor (se existir)
                if (devedor != null)
                {
                    row.Cells["ColumnDevedor"].Value = devedor.nome;
                    row.Cells["ColumnDocDev"].Value = FormatarDocumento(devedor.docDevedor);
                    row.Cells["ColumnEmail"].Value = devedor.email;
                    row.Cells["ColumnStatus"].Value = status;
                }
                else
                {
                    row.Cells["ColumnDevedor"].Value = "Erro - Sem devedor";
                    row.Cells["ColumnDocDev"].Value = "-";
                    row.Cells["ColumnEmail"].Value = "-";
                    row.Cells["ColumnStatus"].Value = status;
                }

                // Armazenar o status na Tag da linha para usar na coloração
                row.Tag = status;

                Debug.WriteLine($"Linha adicionada com sucesso: {devedor?.nome ?? "Sem devedor"} - Distribuição: {protesto.numDistribuicao}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao adicionar linha da API: {ex.Message}");

                // Método alternativo usando índices
                try
                {
                    AdicionarLinhaApiComIndices(protesto, devedor);
                }
                catch (Exception err)
                {
                    Debug.WriteLine($"Todos os métodos para adicionar linha da API falharam: {err.Message}");
                }
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



        // Determinar status baseado na notificação
        private string DeterminarStatus(StatusNotificacao statusNotificacao)
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
        private void AtualizarDadosTabela(List<dynamic> novosProtestos)
        {
            dataGridViewProtesto.Rows.Clear();

            foreach (var protesto in novosProtestos)
            {
                AdicionarLinhaApiTabela(protesto, protesto.devedor);
            }

            AplicarCoresStatus();
        }



        //chartDist
        private async Task CarregarGrafico()
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
            areaGrafico.BackColor = Color.FromArgb(240, 240, 240);
            chartDist.ChartAreas.Add(areaGrafico);

            // Criar série     
            Series serieDados = new Series("Quantidade por Data");
            serieDados.ChartType = SeriesChartType.Column;
            serieDados.IsValueShownAsLabel = true;
            serieDados.LabelFormat = "#";
            serieDados.Color = Color.DodgerBlue;

            try
            {
                // Obter dados da API
                List<DocProtesto> dados = await GetDataToChart(
                    startDate: new DateTime(2025, 6, 2),
                    endDate: new DateTime(2025, 6, 17)
                );

                // Debug: Verificar os dados recebidos
                Debug.WriteLine($"Total de registros recebidos: {dados.Count}");
                foreach (var item in dados.Take(3)) // Mostra apenas os 3 primeiros
                {
                    Debug.WriteLine($"createdAt: {item.createdAt:yyyy-MM-dd HH:mm:ss}");
                }

                // Agrupar dados por data e contar quantidade - VERSÃO CORRIGIDA
                var dadosAgrupados = dados
                    .GroupBy(d => d.createdAt.Date) // Agrupa apenas pela data (sem hora)
                    .Select(g => new
                    {
                        Data = g.Key,
                        Quantidade = g.Count()
                    })
                    .OrderBy(x => x.Data) // Ordena por data
                    .ToList();

                // Debug: Verificar o agrupamento
                Debug.WriteLine($"Grupos criados: {dadosAgrupados.Count}");
                foreach (var grupo in dadosAgrupados)
                {
                    Debug.WriteLine($"Data: {grupo.Data:dd/MM/yyyy}, Quantidade: {grupo.Quantidade}");
                }

                // Adicionar pontos ao gráfico
                for (int i = 0; i < dadosAgrupados.Count; i++)
                {
                    int pontoIndex = serieDados.Points.AddXY(i + 1, dadosAgrupados[i].Quantidade);
                    serieDados.Points[pontoIndex].AxisLabel = dadosAgrupados[i].Data.ToString("dd/MM/yyyy");
                }

                chartDist.Series.Add(serieDados);

                // Adicionar título     
                Title titulo = new Title("Quantidade de Registros por Data");
                chartDist.Titles.Add(titulo);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao carregar gráfico: {ex.Message}");
                // Opcional: Mostrar mensagem de erro para o usuário
            }
        }

        private async Task<List<DocProtesto>> GetDataToChart(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                Debug.WriteLine("Iniciando getDataToChart...");                
                List<DocProtesto> dados = await _protestoService.FindByDateRange(startDate, endDate);
                Debug.WriteLine($"getDataToChart - Sucesso: {dados.Count} registros encontrados");
                return dados;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro: {ex.Message}");
                return new List<DocProtesto>();
            }
            
        }


    }
}
