using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormNotification : Form
    {
        private Common _common;
        private List<Notificacao> dados = [];

        public FormNotification()
        {
            InitializeComponent();
            ConfigDataGridView();
            ConfigmaskedTextBox();
            ConfigDateTimePickers();
            ConfigCheckBoxes();
            _common = new Common();
            LoadDistribData();
        }

        private void ConfigDataGridView()
        {
            dataGridViewDataNotification.Rows.Clear();
            dataGridViewDataNotification.RowHeadersVisible = false;
            dataGridViewDataNotification.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDataNotification.AllowUserToAddRows = false;
            dataGridViewDataNotification.MultiSelect = false;
            dataGridViewDataNotification.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewDataNotification.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDataNotification.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewDataNotification.AllowUserToResizeRows = false;
            dataGridViewDataNotification.AllowUserToResizeColumns = true;
            dataGridViewDataNotification.ReadOnly = false;
            ConfigurarColunas();
        }

        private void ConfigurarColunas()
        {
            // Tornar todas as colunas ReadOnly exceto a de checkbox
            foreach (DataGridViewColumn column in dataGridViewDataNotification.Columns)
            {
                if (column.Name == "ColumnSelect")
                {
                    column.ReadOnly = false; // Permitir edição do checkbox
                }
                else
                {
                    column.ReadOnly = true; // Bloquear edição das outras colunas
                }
            }
        }

        private void ConfigmaskedTextBox()
        {
            // Configurar data inicial (início do mês atual)
            DateTime inicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            maskedTextBoxInitialDate.Mask = "00/00/0000";
            maskedTextBoxInitialDate.ValidatingType = typeof(DateTime);
            maskedTextBoxInitialDate.Text = inicioMes.ToString("dd/MM/yyyy");
            maskedTextBoxInitialDate.ResetOnPrompt = false;
            maskedTextBoxInitialDate.ResetOnSpace = false;
            maskedTextBoxInitialDate.SkipLiterals = true;
            maskedTextBoxInitialDate.Leave += MaskedTextBoxInitialDate_Leave;

            // Configurar data final (fim do mês atual)
            DateTime fimMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            maskedTextBoxFinalDate.Mask = "00/00/0000";
            maskedTextBoxFinalDate.ValidatingType = typeof(DateTime);
            maskedTextBoxFinalDate.Text = fimMes.ToString("dd/MM/yyyy");
            maskedTextBoxFinalDate.ResetOnPrompt = false;
            maskedTextBoxFinalDate.ResetOnSpace = false;
            maskedTextBoxFinalDate.SkipLiterals = true;
            maskedTextBoxFinalDate.Leave += MaskedTextBoxFinalDate_Leave;
        }

        private void ConfigDateTimePickers()
        {
            // Configurar DateTimePickers para sincronizar com MaskedTextBox
            DateTime inicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime fimMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            dateTimePickerInitialDate.Value = inicioMes;
            dateTimePickerFinalDate.Value = fimMes;

            dateTimePickerInitialDate.ValueChanged += DateTimePickerInitialDate_ValueChanged;
            dateTimePickerFinalDate.ValueChanged += DateTimePickerFinalDate_ValueChanged;
        }

        private void ConfigCheckBoxes()
        {
            chkBoxNotNaoEnviadas.Checked = true;
            chkBoxNotSended.Checked = false;

            // Eventos já existem no designer, mas garantir que estão configurados
            chkBoxNotNaoEnviadas.CheckedChanged += ChkBoxNotNaoEnviadas_CheckedChanged;
            chkBoxNotSended.CheckedChanged += ChkBoxNotSended_CheckedChanged;
        }

        // Eventos para sincronizar MaskedTextBox com DateTimePicker
        private void MaskedTextBoxInitialDate_Leave(object sender, EventArgs e)
        {
            if (TryParseDateWithDefaults(maskedTextBoxInitialDate.Text, out DateTime date))
            {
                dateTimePickerInitialDate.Value = date;
                maskedTextBoxInitialDate.Text = date.ToString("dd/MM/yyyy");
                ApplyFilters();
            }
        }

        private void MaskedTextBoxFinalDate_Leave(object sender, EventArgs e)
        {
            if (TryParseDateWithDefaults(maskedTextBoxFinalDate.Text, out DateTime date))
            {
                dateTimePickerFinalDate.Value = date;
                maskedTextBoxFinalDate.Text = date.ToString("dd/MM/yyyy");
                ApplyFilters();
            }
        }

        private void DateTimePickerInitialDate_ValueChanged(object sender, EventArgs e)
        {
            maskedTextBoxInitialDate.Text = dateTimePickerInitialDate.Value.ToString("dd/MM/yyyy");
            ApplyFilters();
        }

        private void DateTimePickerFinalDate_ValueChanged(object sender, EventArgs e)
        {
            maskedTextBoxFinalDate.Text = dateTimePickerFinalDate.Value.ToString("dd/MM/yyyy");
            ApplyFilters();
        }

        // Eventos dos CheckBoxes
        private void ChkBoxNotNaoEnviadas_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ChkBoxNotSended_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Método para interpretar datas com valores padrão
        private bool TryParseDateWithDefaults(string dateText, out DateTime result)
        {
            result = DateTime.MinValue;

            if (string.IsNullOrWhiteSpace(dateText))
                return false;

            // Remover caracteres de máscara
            string cleanDate = dateText.Replace("/", "").Replace("_", "");

            if (cleanDate.Length < 2)
                return false;

            try
            {
                int day = 1, month = 1, year = DateTime.Now.Year;

                // Extrair dia
                if (cleanDate.Length >= 2)
                {
                    if (int.TryParse(cleanDate.Substring(0, 2), out int d) && d >= 1 && d <= 31)
                        day = d;
                }

                // Extrair mês
                if (cleanDate.Length >= 4)
                {
                    if (int.TryParse(cleanDate.Substring(2, 2), out int m) && m >= 1 && m <= 12)
                        month = m;
                }

                // Extrair ano
                if (cleanDate.Length >= 8)
                {
                    if (int.TryParse(cleanDate.Substring(4, 4), out int y) && y >= 1900)
                        year = y;
                }
                else if (cleanDate.Length >= 6)
                {
                    // Se só tem 2 dígitos do ano, assumir 20XX
                    if (int.TryParse(cleanDate.Substring(4, 2), out int y2))
                        year = 2000 + y2;
                }

                // Validar se a data é válida
                if (day > DateTime.DaysInMonth(year, month))
                    day = DateTime.DaysInMonth(year, month);

                result = new DateTime(year, month, day);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task LoadDistribData()
        {
            try
            {
                dados = JsonSerializer.Deserialize<List<Notificacao>>(jsonData);
                ApplyFilters();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro em LoadDistribData: {ex.Message}");
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
                MessageBox.Show($"Erro ao carregar dados da API: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            try
            {
                // Limpar grid
                dataGridViewDataNotification.Rows.Clear();

                // Obter dados filtrados
                List<Notificacao> dadosFiltrados = FilterData();

                // Adicionar dados filtrados ao grid
                foreach (var item in dadosFiltrados)
                {
                    AdicionarLinhaApiTabela(item);
                }

                // Atualizar status na interface (opcional)
                // lblTotalRegistros.Text = $"Total: {dadosFiltrados.Count} registros";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao aplicar filtros: {ex.Message}");
                MessageBox.Show($"Erro ao aplicar filtros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Notificacao> FilterData()
        {
            if (dados == null || dados.Count == 0)
                return new List<Notificacao>();

            var resultado = dados.AsEnumerable();

            // Filtro por status de envio
            bool mostrarNaoEnviados = chkBoxNotNaoEnviadas.Checked;
            bool mostrarEnviados = chkBoxNotSended.Checked;

            // Se nenhum checkbox estiver marcado, não mostrar nada
            if (!mostrarNaoEnviados && !mostrarEnviados)
                return new List<Notificacao>();

            // Aplicar filtro de status
            if (!(mostrarNaoEnviados && mostrarEnviados))
            {
                // Aplicar filtro baseado no que está marcado
                List<Notificacao> registrosFiltrados = new List<Notificacao>();

                if (mostrarNaoEnviados)
                {
                    registrosFiltrados.AddRange(resultado.Where(n => !n.emailEnviado));
                }

                if (mostrarEnviados)
                {
                    registrosFiltrados.AddRange(resultado.Where(n => n.emailEnviado));
                }

                resultado = registrosFiltrados.AsEnumerable();
            }


            // Filtro por data
            DateTime? dataInicial = null;
            DateTime? dataFinal = null;

            if (TryParseDateWithDefaults(maskedTextBoxInitialDate.Text, out DateTime dtInicial))
                dataInicial = dtInicial;

            if (TryParseDateWithDefaults(maskedTextBoxFinalDate.Text, out DateTime dtFinal))
                dataFinal = dtFinal.Date.AddDays(1).AddTicks(-1); // Incluir todo o dia final

            // Aplicar filtro de data se pelo menos uma data for válida
            if (dataInicial.HasValue || dataFinal.HasValue)
            {
                resultado = resultado.Where(n =>
                {
                    bool dentroIntervalo = true;

                    if (dataInicial.HasValue)
                        dentroIntervalo = dentroIntervalo && n.dataDistribuicao >= dataInicial.Value;

                    if (dataFinal.HasValue)
                        dentroIntervalo = dentroIntervalo && n.dataDistribuicao <= dataFinal.Value;

                    return dentroIntervalo;
                });
            }
            return resultado.ToList();
        }

        private void AdicionarLinhaApiTabela(Notificacao dado)
        {
            try
            {
                int rowIndex = dataGridViewDataNotification.Rows.Add();
                DataGridViewRow row = dataGridViewDataNotification.Rows[rowIndex];

                // Configurar checkbox (desmarcado por padrão)
                row.Cells["ColumnSelect"].Value = false;

                // Armazenar o ID na Tag da linha para referência
                row.Tag = dado.logNotificacaoId;
                //row.Tag = status;

                row.Cells["ColumnId"].Value = dado.logNotificacaoId;
                row.Cells["ColumnDate"].Value = dado.dataDistribuicao;
                row.Cells["ColumnDist"].Value = dado.distribuicao;
                row.Cells["ColumnNumTitulo"].Value = dado.numTitulo;
                row.Cells["ColumnTotal"].Value = dado.valorTotal; // Corrigido para valorTotal
                row.Cells["ColumnDev"].Value = dado.nomeDevedor;
                row.Cells["ColumnDocDev"].Value = _common.FormatarDocumento(dado.docDevedor);
                row.Cells["ColumnDevEmail"].Value = dado.devedorEmail;
                row.Cells["ColumnCred"].Value = dado.credor;
                row.Cells["ColumnSended"].Value = dado.emailEnviado ? "Sim" : "Não";
                row.Cells["ColumnDateSend"].Value = dado.dataEnvio;
                row.Cells["ColumnLido"].Value = dado.emailLido ? "Sim" : "Não"; // Corrigido para lido
                row.Cells["ColumnTabelionato"].Value = dado.tabelionato;
                row.Cells["ColumnPortador"].Value = dado.portador;
                if (dado.emailEnviado)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao adicionar linha da API: {ex.Message}");
            }
        }

        // Eventos originais mantidos para compatibilidade
        private void chkBoxNotNaoEnviadas_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void chkBoxNotSended_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }



        






        // Obter IDs das linhas selecionadas
        public List<int> ObterLinhasSelecionadas()
        {
            List<int> idsSelecionados = new List<int>();

            foreach (DataGridViewRow row in dataGridViewDataNotification.Rows)
            {
                // CORREÇÃO: Verificar se o checkbox está marcado
                if (row.Cells["ColumnSelect"].Value != null &&
                    Convert.ToBoolean(row.Cells["ColumnSelect"].Value) == true)
                {
                    if (row.Tag != null)
                    {
                        idsSelecionados.Add((int)row.Tag);
                    }
                }
            }
            return idsSelecionados;
        }



        // Selecionar/Deselecionar todas
        private void SelecionarTodas(bool selecionar)
        {
            foreach (DataGridViewRow row in dataGridViewDataNotification.Rows)
            {
                row.Cells["ColumnSelect"].Value = selecionar;
            }
        }

        private void btnSendSelected_Click(object sender, EventArgs e)
        {
            //ObterLinhasSelecionadas();
            Debug.WriteLine($"IDs selecionados: {string.Join(", ", ObterLinhasSelecionadas())}");
        }













        // JSON de exemplo mantido
        string jsonData = @"
        [
            {
            ""logNotificacaoId"": 1,
            ""nomeDevedor"": ""SANTA INTERMEDIACOES DE CONSORCIOS - EIRELI"",
            ""devedorEmail"": ""emailcliente@gmail.com"",
            ""docDevedor"": ""89674486000157"",
            ""numTitulo"": ""1234a"",
            ""distribuicao"": ""4564862"",
            ""dataDistribuicao"": ""2025-07-18T03:00:00.000Z"",
            ""valorTotal"": 223936,
            ""dataVencimento"": ""11/03/2022"",
            ""tabelionato"": ""3° Oficio de Protesto de Títulos de Curitiba"",
            ""credor"": ""PREFEITURA MUNICIPAL DE PINHAIS"",
            ""portador"": ""Prefeitura do Município de Curitiba"",
            ""dataEnvio"": ""2022-03-08T03:00:00.000Z"",
            ""emailEnviado"": true,
            ""lido"": true
          },
          {
            ""logNotificacaoId"": 2,
            ""nomeDevedor"": ""CLEUZA DE MORAIS COSTA"",
            ""devedorEmail"": ""emailcliente@gmail.com"",
            ""docDevedor"": ""54322656000150"",
            ""distribuicao"": ""123456"",
            ""numTitulo"": ""1234a"",
            ""dataDistribuicao"": ""2025-07-10T03:00:00.000Z"",
            ""valorTotal"": 60651,
            ""dataVencimento"": ""20/10/2019"",
            ""tabelionato"": ""1° Oficio de Protesto de Títulos de Curitiba"",
            ""credor"": ""SECRETARIA DE ESTADO DA FAZENDA PUBLICA"",
            ""portador"": ""PGE - PROCURADORIA GERAL DO ESTADO"",
            ""dataEnvio"": ""2022-03-08T03:00:00.000Z"",
            ""emailEnviado"": false,
            ""lido"": false  
          },
          {
            ""logNotificacaoId"": 3,
            ""nomeDevedor"": ""FELIPE AUGUSTO ZIMMERMANN SACHSER"",
            ""devedorEmail"": ""emailcliente@hotmail.com"",
            ""docDevedor"": ""31191927000180"",
            ""distribuicao"": ""654548"",
            ""numTitulo"": ""1234a"",
            ""dataDistribuicao"": ""2025-07-01T03:00:00.000Z"",
            ""valorTotal"": 85218,
            ""dataVencimento"": ""11/03/2022"",
            ""tabelionato"": ""2° Oficio de Protesto de Títulos de Curitiba"",
            ""credor"": ""PREFEITURA MUNICIPAL DE CURITIBA"",
            ""portador"": ""Prefeitura do Município de Curitiba"",
            ""dataEnvio"": null,
            ""emailEnviado"": false,
            ""lido"": false
          }
        ]";

        
    }
}