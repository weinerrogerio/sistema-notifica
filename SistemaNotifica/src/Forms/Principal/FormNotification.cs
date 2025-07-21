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
        private NotificationService _notificacaoService;

        public FormNotification()
        {
            InitializeComponent();
            ConfigDataGridView();
            ConfigmaskedTextBox();
            ConfigDateTimePickers();
            ConfigCheckBoxes();
            _common = new Common();
            _notificacaoService = Program.NotificationService;
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
            chkBoxNotSended.Checked = true;
            chkBoxSended.Checked = false;

            // Eventos já existem no designer, mas garantir que estão configurados
            chkBoxNotSended.CheckedChanged += chkBoxNotSended_CheckedChanged;
            chkBoxSended.CheckedChanged += chkBoxSended_CheckedChanged;
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
        private void chkBoxNotSended_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void chkBoxSended_CheckedChanged(object sender, EventArgs e)
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

                dados = await _notificacaoService.SearchNotAsync();
                Debug.WriteLine($"LoadDistribData - Sucesso: {dados.Count} registros encontrados {dados}");
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

            bool mostrarNaoEnviados = chkBoxNotSended.Checked;
            bool mostrarEnviados = chkBoxSended.Checked;

            // Se ambos os checkboxes estiverem desmarcados, retornar uma lista vazia
            if (!mostrarNaoEnviados && !mostrarEnviados)
            {
                return new List<Notificacao>();
            }
            // Se ambos estiverem marcados, não aplicar filtro por status (mostrar todos)
            else if (mostrarNaoEnviados && mostrarEnviados)
            {
                // Não faz nada, resultado já contém todos os dados.
                // O filtro de data será aplicado em seguida.
            }
            // Se apenas 'Não Enviados' estiver marcado
            else if (mostrarNaoEnviados)
            {
                resultado = resultado.Where(n => !n.emailEnviado);
            }
            // Se apenas 'Enviados' estiver marcado
            else if (mostrarEnviados)
            {
                resultado = resultado.Where(n => n.emailEnviado);
            }

            // Filtro por data de criação (createdAt)
            DateTime? dataInicial = null;
            DateTime? dataFinal = null;

            if (TryParseDateWithDefaults(maskedTextBoxInitialDate.Text, out DateTime dtInicial))
                dataInicial = dtInicial.Date; // Assegura que é apenas a data, sem hora

            if (TryParseDateWithDefaults(maskedTextBoxFinalDate.Text, out DateTime dtFinal))
                dataFinal = dtFinal.Date.AddDays(1).AddTicks(-1); // Incluir todo o dia final

            // Aplicar filtro de data se pelo menos uma data for válida
            if (dataInicial.HasValue || dataFinal.HasValue)
            {
                resultado = resultado.Where(n =>
                {
                    // Pega a data de criação e normaliza para comparar apenas a data
                    DateTime createdAtDate = n.createdAt.Date;

                    bool dentroIntervalo = true;

                    if (dataInicial.HasValue)
                        dentroIntervalo = dentroIntervalo && createdAtDate >= dataInicial.Value;

                    if (dataFinal.HasValue)
                        dentroIntervalo = dentroIntervalo && createdAtDate <= dataFinal.Value.Date;

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
                row.Cells["ColumnCreatedAt"].Value = dado.createdAt;
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
            //NOTA: Elaborar melhor essa mensagem
            DialogResult result = MessageBox.Show("Alerta: Ao confirmar, as notificações serão enviadas aos destinatários. Seus dados serão tratados conforme nossa Política de Privacidade, em conformidade com a LGPD. " +
                "\n É totalmente desaconceslhavel enviar duas notificações da mesma distribuição para o mesmo destinatário.","Deseja enviar as notificações marcadas?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var selecionados = ObterLinhasSelecionadas();
                Debug.WriteLine($"IDs selecionados: {string.Join(", ", ObterLinhasSelecionadas())}");

                // TODO: Implementar envio de notificação para os IDs selecionados depois
            }
            else if (result == DialogResult.No)
            {
                // Código a ser executado se o usuário clicar em "Não"
                MessageBox.Show("Você clicou em Não!");
            }
            
        }

    }
}