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
using Newtonsoft.Json.Linq;

namespace SistemaNotifica.src.Forms.Principal
{


    public partial class FormNotification : Form
    {
        private Common _common;
        private List<Notificacao> dados = [];
        private NotificationService _notificationService;
        private DevedorService _devedorService;
        private string currentSessionId = null;

        // Variáveis para manter a referência da conexão SSE
        private CancellationTokenSource sseCancelToken;
        private HttpResponseMessage sseResponse;

        public FormNotification()
        {
            InitializeComponent();
            ConfigDataGridView();
            ConfigMaskedTextBox();
            ConfigDateTimePickers();
            ConfigCheckBoxes();
            _common = new Common();
            _notificationService = Program.NotificationService;
            _devedorService = Program.DevedorService;

            _devedorService.OnLogReceived += HandleLogReceived;

            LoadDistribData();                       
            
            mainPanelLogSearchConfig();
            this.Resize += FormNotification_Resize;
            this.SizeChanged += FormNotification_Resize;
        }


        private void FormNotification_Resize(object sender, EventArgs e)
        {
            if ( mainPanelLogSearch.Visible )
            {
                CenterOverlayPanel();
            }
        }

        private void mainPanelLogSearchConfig()
        {
            panelGrid.Controls.Remove(mainPanelLogSearch);
            this.Controls.Add(mainPanelLogSearch);
            CloseOverlay();
            dataGridViewDataNotification.SendToBack();
            mainPanelLogSearch.BringToFront();

            //mainPanelLogSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            mainPanelLogSearch.Anchor = AnchorStyles.None;
            mainPanelLogSearch.Height = this.ClientSize.Height; 
            CenterOverlayHorizontally(); 

        }

        private void CenterOverlayHorizontally()
        {
            int x = ( this.ClientSize.Width - mainPanelLogSearch.Width ) / 2;
            mainPanelLogSearch.Location = new Point(x, 0); // Y sempre em 0
            mainPanelLogSearch.Height = this.ClientSize.Height; // Altura total da janela
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
            foreach ( DataGridViewColumn column in dataGridViewDataNotification.Columns )
            {
                if ( column.Name == "ColumnSelect" )
                {
                    column.ReadOnly = false; // Permitir edição do checkbox
                }
                else
                {
                    column.ReadOnly = true; // Bloquear edição das outras colunas
                }
            }
        }

        private void ConfigMaskedTextBox()
        {
            // Configurar data inicial (início do mês atual)
            DateTime inicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            // NÃO ESQUECER DE AJUSTAR A DATA INICIAL - AddYeas, AddMonths, AddDays - agora->5 anos
            inicioMes = inicioMes.AddYears(-5);
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
            if ( TryParseDateWithDefaults(maskedTextBoxInitialDate.Text, out DateTime date) )
            {
                dateTimePickerInitialDate.Value = date;
                maskedTextBoxInitialDate.Text = date.ToString("dd/MM/yyyy");
                ApplyFilters();
            }
        }

        private void MaskedTextBoxFinalDate_Leave(object sender, EventArgs e)
        {
            if ( TryParseDateWithDefaults(maskedTextBoxFinalDate.Text, out DateTime date) )
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

            if ( string.IsNullOrWhiteSpace(dateText) )
                return false;

            // Remover caracteres de máscara
            string cleanDate = dateText.Replace("/", "").Replace("_", "");

            if ( cleanDate.Length < 2 )
                return false;

            try
            {
                int day = 1, month = 1, year = DateTime.Now.Year;

                // Extrair dia
                if ( cleanDate.Length >= 2 )
                {
                    if ( int.TryParse(cleanDate.Substring(0, 2), out int d) && d >= 1 && d <= 31 )
                        day = d;
                }

                // Extrair mês
                if ( cleanDate.Length >= 4 )
                {
                    if ( int.TryParse(cleanDate.Substring(2, 2), out int m) && m >= 1 && m <= 12 )
                        month = m;
                }

                // Extrair ano
                if ( cleanDate.Length >= 8 )
                {
                    if ( int.TryParse(cleanDate.Substring(4, 4), out int y) && y >= 1900 )
                        year = y;
                }
                else if ( cleanDate.Length >= 6 )
                {
                    // Se só tem 2 dígitos do ano, assumir 20XX
                    if ( int.TryParse(cleanDate.Substring(4, 2), out int y2) )
                        year = 2000 + y2;
                }

                // Validar se a data é válida
                if ( day > DateTime.DaysInMonth(year, month) )
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
                dados = await _notificationService.SearchNotAsync();
                Debug.WriteLine($"LoadDistribData - Sucesso: {dados.Count} registros encontrados {dados}");
                ApplyFilters();
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro em LoadDistribData {ex.Message}");
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

                Debug.WriteLine($"ApplyFilters - {dadosFiltrados.Count} registros encontrados {dadosFiltrados}");

                // Adicionar dados filtrados ao grid
                foreach ( var item in dadosFiltrados )
                {
                    Debug.WriteLine($"AdicionarLinhaApiTabela - Sucesso: {item}");
                    AdicionarLinhaApiTabela(item);
                }

                // Atualizar status na interface (opcional)
                // lblTotalRegistros.Text = $"Total: {dadosFiltrados.Count} registros";
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao aplicar filtros: {ex.Message}");
                MessageBox.Show($"Erro ao aplicar filtros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Notificacao> FilterData()
        {
            if ( dados == null || dados.Count == 0 )
                return new List<Notificacao>();

            Debug.WriteLine($"FilterData dados - {dados.Count} registros encontrados {dados}");

            var resultado = dados.AsEnumerable();

            Debug.WriteLine($"FilterData resultado - {resultado.Count()} registros encontrados {resultado}");
            
            bool mostrarNaoEnviados = chkBoxNotSended.Checked;
            bool mostrarEnviados = chkBoxSended.Checked;

            // Se ambos os checkboxes estiverem desmarcados, retornar uma lista vazia
            if ( !mostrarNaoEnviados && !mostrarEnviados )
            {
                return new List<Notificacao>();
            }
            // Se ambos estiverem marcados, não aplicar filtro por status (mostrar todos)
            else if ( mostrarNaoEnviados && mostrarEnviados )
            {
                // Não faz nada, resultado já contém todos os dados.
                // O filtro de data será aplicado em seguida.
            }
            // Se apenas 'Não Enviados' estiver marcado
            else if ( mostrarNaoEnviados )
            {
                resultado = resultado.Where(n => !n.emailEnviado);
            }
            // Se apenas 'Enviados' estiver marcado
            else if ( mostrarEnviados )
            {
                resultado = resultado.Where(n => n.emailEnviado);
            }

            // Filtro por data de criação (createdAt)
            DateTime? dataInicial = null;
            DateTime? dataFinal = null;

            if ( TryParseDateWithDefaults(maskedTextBoxInitialDate.Text, out DateTime dtInicial) )
                dataInicial = dtInicial.Date; // Assegura que é apenas a data, sem hora

            if ( TryParseDateWithDefaults(maskedTextBoxFinalDate.Text, out DateTime dtFinal) )
                dataFinal = dtFinal.Date.AddDays(1).AddTicks(-1); // Incluir todo o dia final

            // Aplicar filtro de data se pelo menos uma data for válida
            if ( dataInicial.HasValue || dataFinal.HasValue )
            {
                resultado = resultado.Where(n =>
                {
                    // Pega a data de criação e normaliza para comparar apenas a data
                    DateTime createdAtDate = n.createdAt.Date;

                    bool dentroIntervalo = true;

                    if ( dataInicial.HasValue )
                        dentroIntervalo = dentroIntervalo && createdAtDate >= dataInicial.Value;

                    if ( dataFinal.HasValue )
                        dentroIntervalo = dentroIntervalo && createdAtDate <= dataFinal.Value.Date;

                    return dentroIntervalo;
                });
            }
            //Por que não funciona?
            Debug.WriteLine($"FilterData resultado.tolist - {resultado.Count()} registros encontrados {resultado}");
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
                if ( dado.emailEnviado )
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao adicionar linha da API: {ex.Message}");
            }
        }

        // Selecionar/Deselecionar todas
        private void SelecionarTodas()
        {
            foreach ( DataGridViewRow row in dataGridViewDataNotification.Rows )
            {
                row.Cells["ColumnSelect"].Value = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SelecionarTodas();
        }



        private void btnSendSelected_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar se há registros selecionados
                var registrosSelecionados = ObterRegistrosSelecionados();

                if ( registrosSelecionados.Count == 0 )
                {
                    MessageBox.Show("Nenhuma notificação foi selecionada. Por favor, selecione pelo menos uma notificação para enviar.",
                                  "Nenhum registro selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Verificar se algum registro já foi enviado
                var registrosJaEnviados = registrosSelecionados.Where(r => r.emailEnviado).ToList();

                if ( registrosJaEnviados.Any() )
                {
                    DialogResult resultJaEnviados = MessageBox.Show("\n Existem registros selecionados que ja foram enviados anteriormente.\n  " +
                        "Ao continuar os registros ja enviados serao ignorados.\n\n" +
                        "Deseja continuar enviando apenas as notificações que ainda nao foram enviadas?\n",
                        "Registros ja enviados detectados",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if ( resultJaEnviados == DialogResult.No )
                    {
                        return;
                    }
                    // Remove os já enviados da lista
                    registrosSelecionados = registrosSelecionados.Where(r => !r.emailEnviado).ToList();
                }

                // 3. Verificar se ainda restam registros para enviar
                if ( registrosSelecionados.Count == 0 )
                {
                    MessageBox.Show("Todos os registros selecionados já foram enviados anteriormente.",
                                  "Nenhum registro para enviar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 4. Mostrar confirmação final 
                int quantidadeRegistros = registrosSelecionados.Count;
                string mensagemConfirmacao = "Ao confirmar, as notificações serão enviadas aos ${quantidadeRegistros} destinatários.\n" +
                    "As notificações serão tratadas conforme nossa Política de Privacidade, em conformidade com a LGPD.\n\n" +
                    "É totalmente NÃO RECOMENDADO enviar mais de uma notificação da mesma distribuição para o mesmo destinatário.\n\n" +
                    "Confirma o envio das notificações?";

                DialogResult resultFinal = MessageBox.Show(mensagemConfirmacao,
                                                          "Confirmar envio de notificações",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                if ( resultFinal == DialogResult.Yes )
                {
                    // TODO: Implementar envio das notificações
                    EnviarNotificacoes(registrosSelecionados);
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"Erro ao processar envio de notificações: {ex.Message}",
                               "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Erro em btnSendSelected_Click: {ex.Message}");
            }
        }

        public List<Notificacao> ObterRegistrosSelecionados()
        {
            List<Notificacao> registrosSelecionados = new List<Notificacao>();

            foreach ( DataGridViewRow row in dataGridViewDataNotification.Rows )
            {
                if ( row.Cells["ColumnSelect"].Value != null &&
                    Convert.ToBoolean(row.Cells["ColumnSelect"].Value) == true )
                {
                    if ( row.Tag != null )
                    {
                        var registro = new Notificacao
                        {
                            logNotificacaoId = ( int ) row.Tag,
                            nomeDevedor = row.Cells["ColumnDev"].Value?.ToString() ?? "",
                            devedorEmail = row.Cells["ColumnDevEmail"].Value?.ToString() ?? "",
                            distribuicao = row.Cells["ColumnDist"].Value?.ToString() ?? "",
                            numTitulo = row.Cells["ColumnNumTitulo"].Value?.ToString() ?? "",
                            emailEnviado = row.Cells["ColumnSended"].Value?.ToString() == "Sim"
                        };

                        registrosSelecionados.Add(registro);
                    }
                }
            }
            return registrosSelecionados;
        }




        private async void EnviarNotificacoes(List<Notificacao> registros)
        {
            int sucessos = 0;
            int falhas = 0;
            List<ErroDetalhado> errosDetalhados = new List<ErroDetalhado>();

            // Criar arquivo de log com timestamp
            string nomeArquivoLog = $"envio_notificacoes_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string caminhoLog = Path.Combine(Application.StartupPath, "Logs", nomeArquivoLog);

            // Garantir que a pasta Logs existe
            Directory.CreateDirectory(Path.GetDirectoryName(caminhoLog));

            try
            {
                // Escrever cabeçalho do log
                await File.WriteAllTextAsync(caminhoLog,
                    $"=== LOG DE ENVIO DE NOTIFICAÇÕES ===\n" +
                    $"Data/Hora: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                    $"Total de registros: {registros.Count}\n\n");

                foreach ( var registro in registros )
                {
                    try
                    {
                        var response = await _notificationService.SendNotification(registro.logNotificacaoId);

                        if ( response.success )
                        {
                            sucessos++;
                            AtualizarLinhaComoEnviada(registro.logNotificacaoId);

                            // Log de sucesso (opcional, apenas para auditoria)
                            await File.AppendAllTextAsync(caminhoLog,
                                $"✅ SUCESSO - {registro.nomeDevedor} ({registro.docDevedor}) - {registro.devedorEmail}\n");
                        }
                        else
                        {
                            falhas++;
                            var erro = new ErroDetalhado
                            {
                                NomeDevedor = registro.nomeDevedor,
                                Documento = registro.docDevedor,
                                Email = registro.devedorEmail,
                                MensagemErro = response.message,
                                TipoErro = "Resposta de Falha do Serviço"
                            };
                            errosDetalhados.Add(erro);

                            // Log detalhado do erro
                            await File.AppendAllTextAsync(caminhoLog,
                                $"❌ FALHA - {registro.nomeDevedor} ({registro.docDevedor}) - {registro.devedorEmail}\n" +
                                $"   Erro: {response.message}\n\n");
                        }
                    }
                    catch ( Exception ex )
                    {
                        falhas++;
                        var erro = new ErroDetalhado
                        {
                            NomeDevedor = registro.nomeDevedor,
                            Documento = registro.docDevedor,
                            Email = registro.devedorEmail,
                            MensagemErro = ex.Message,
                            TipoErro = "Exceção"
                        };
                        errosDetalhados.Add(erro);

                        // Log detalhado da exceção
                        await File.AppendAllTextAsync(caminhoLog,
                            $"💥 EXCEÇÃO - {registro.nomeDevedor} ({registro.docDevedor}) - {registro.devedorEmail}\n" +
                            $"   Erro: {ex.Message}\n" +
                            $"   Stack: {ex.StackTrace}\n\n");

                        Debug.WriteLine($"Erro ao enviar notificação para {registro.nomeDevedor}: {ex.Message}");
                    }
                }

                // Escrever resumo no log
                await File.AppendAllTextAsync(caminhoLog,
                    $"\n=== RESUMO ===\n" +
                    $"Sucessos: {sucessos}\n" +
                    $"Falhas: {falhas}\n" +
                    $"Total: {registros.Count}\n");

                // Exibir resultado
                ExibirResultado(sucessos, falhas, errosDetalhados, caminhoLog);
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"Erro crítico durante o envio: {ex.Message}",
                               "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExibirResultado(int sucessos, int falhas, List<ErroDetalhado> errosDetalhados, string caminhoLog)
        {
            string mensagemResultado = $"Envio concluído!\n\n";
            mensagemResultado += $"✅ Sucessos: {sucessos}\n";
            mensagemResultado += $"❌ Falhas: {falhas}";

            if ( falhas == 0 )
            {
                MessageBox.Show(mensagemResultado, "Resultado do Envio",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Se há falhas, dar opções ao usuário
                mensagemResultado += $"\n\nLog salvo em: {Path.GetFileName(caminhoLog)}";

                var result = MessageBox.Show(
                    mensagemResultado + "\n\nDeseja visualizar os detalhes dos erros?",
                    "Resultado do Envio",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if ( result == DialogResult.Yes )
                {
                    // Abrir form com detalhes dos erros
                    var formErros = new FormDetalhesErrosNotification(errosDetalhados, caminhoLog);
                    formErros.ShowDialog();
                }
            }
        }

        private void AtualizarLinhaComoEnviada(int logNotificacaoId)
        {
            foreach ( DataGridViewRow row in dataGridViewDataNotification.Rows )
            {
                if ( row.Tag != null && ( int ) row.Tag == logNotificacaoId )
                {
                    row.Cells["ColumnSended"].Value = "Sim";
                    row.Cells["ColumnDateSend"].Value = DateTime.Now;
                    row.DefaultCellStyle.BackColor = Color.Green;
                    break;
                }
            }
        }


        private void DisableMainControls(bool disable)
        {
            maskedTextBoxFinalDate.Enabled = !disable;
            dateTimePickerFinalDate.Enabled = !disable;
            dateTimePickerInitialDate.Enabled = !disable;
            maskedTextBoxInitialDate.Enabled = !disable;
            chkBoxSended.Enabled = !disable;
            chkBoxNotSended.Enabled = !disable;
            btnSearchEmails.Enabled = !disable;
            btnSendAll.Enabled = !disable;
            btnSendSelected.Enabled = !disable;
        }


        // --------------- AÇOES DE BUSCA DE EMAILS ---------------

        private void CenterOverlayPanel()
        {
            int x = ( this.ClientSize.Width - mainPanelLogSearch.Width ) / 2;
            int y = ( this.ClientSize.Height - mainPanelLogSearch.Height ) / 2;
            mainPanelLogSearch.Location = new Point(x, y);
        }

        public void ShowOverlay(string message = "Processando arquivo...")
        {
            mainPanelLogSearch.Visible = true;
            mainPanelLogSearch.BringToFront();
            DisableMainControls(true);
            CenterOverlayPanel(); // Centralizar ao mostrar
            this.Refresh();
            Application.DoEvents();
        }



        private void CloseOverlay()
        {
            Debug.WriteLine("Fechando overlay...");
            //timerProgressBar.Stop();
            mainPanelLogSearch.Visible = false;
            DisableMainControls(false);
        }

        private async void btnSearchEmails_Click(object sender, EventArgs e)
        {
            ShowOverlay();
            richTextBoxLogs.Clear(); // Limpa logs anteriores

            // 1. Criar sessão
            bool sessionCreated = await CreateEmailSearchSession();
            if ( !sessionCreated )
            {
                CloseOverlay();
                return;
            }

            // 2. Conectar ao SSE
            if ( !await ConnectToSSE() )
            {
                CloseOverlay();
                return;
            }

            // 3. Aguardar um pouco e iniciar busca
            await Task.Delay(2000); // Aguarda conexão estabilizar
            await StartEmailSearch();
        }

        
        private async void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                AddLogToRichTextBox("warn", "Cancelando busca...", DateTime.Now);

                // ⭐ CORRIGIDO: Agora passa o sessionId
                await _devedorService.CancelSSE(currentSessionId);
                MessageBox.Show("Busca de emails cancelada!", "Busca cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CloseOverlay();
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"Erro ao cancelar o envio: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddLogToRichTextBox(string logLevel, string message, DateTime timestamp, string cnpj = null, string email = null)
        {
            // Definir cores por tipo de log
            Color logColor = logLevel.ToLower() switch
            {
                "log" => Color.Green,
                "warn" => Color.Orange,
                "error" => Color.Red,
                "connection" => Color.Blue,
                "ready" => Color.Blue,
                "session_ended" => Color.DarkBlue,
                _ => Color.Black
            };

            // Formatar mensagem
            string formattedMessage = $"[{timestamp:HH:mm:ss}] {message}";

            if ( !string.IsNullOrEmpty(cnpj) )
                formattedMessage += $" CNPJ: {cnpj}";

            if ( !string.IsNullOrEmpty(email) )
                formattedMessage += $" Email: {email}";

            // Adicionar ao RichTextBox
            richTextBoxLogs.SelectionStart = richTextBoxLogs.TextLength;
            richTextBoxLogs.SelectionLength = 0;
            richTextBoxLogs.SelectionColor = logColor;
            richTextBoxLogs.AppendText(formattedMessage + Environment.NewLine);
            richTextBoxLogs.SelectionColor = richTextBoxLogs.ForeColor; // Resetar cor

            // Auto scroll
            richTextBoxLogs.ScrollToCaret();
        }


        // -------------------------- FUNÇÕES PARA COMUNICAÇÃO COM A API - PARA BUSCA DE EMAILS ---------------------------


        //Handler para receber os logs do DevedorService
        private void HandleLogReceived(string logLevel, string message, DateTime timestamp, string cnpj = null, string email = null)
        {
            // O Invoke é fundamental, pois este evento será disparado pela thread do SSE
            this.Invoke(( Action ) ( () =>
            {
                AddLogToRichTextBox(logLevel, message, timestamp, cnpj, email);

                // Lógica para fechar overlay quando a sessão termina ou dá erro fatal
                if ( logLevel == "session_ended" || logLevel == "error" )
                {
                    CloseOverlay();
                }
            } ));
        }
        public async Task<bool> CreateEmailSearchSession()
        {
            try
            {
                AddLogToRichTextBox("connection", "Criando sessão...", DateTime.Now);

                // Chama o Service, que agora tem a responsabilidade do endpoint
                var response = await _devedorService.CreateEmailSearchSession();

                if ( response["success"]?.Value<bool>() == true )
                {
                    currentSessionId = response["sessionId"]?.Value<string>();
                    AddLogToRichTextBox("connection", $"Sessão criada: {currentSessionId}", DateTime.Now);
                    return true;
                }

                AddLogToRichTextBox("error", $"Erro ao criar sessão: {response["message"]}", DateTime.Now);
                return false;
            }
            catch ( Exception ex )
            {
                AddLogToRichTextBox("error", $"Erro ao criar sessão: {ex.Message}", DateTime.Now);
                return false;
            }
        }

        public async Task<bool> ConnectToSSE()
        {
            try
            {
                AddLogToRichTextBox("connection", "Conectando aos logs...", DateTime.Now);

                // Chama o Service para obter a resposta e o token
                var result = await _devedorService.ConnectToSSE(currentSessionId);
                sseResponse = result.Response;
                sseCancelToken = result.CancelSource;

                if ( sseResponse != null && sseResponse.IsSuccessStatusCode )
                {
                    // ⭐️ Dispara o Processamento do Stream em background, mas dentro do DevedorService
                    _ = Task.Run(() => _devedorService.ProcessSSEStream(sseResponse, sseCancelToken.Token));
                    return true;
                }

                // O log de erro já é tratado dentro do DevedorService em caso de falha HTTP
                return false;
            }
            catch ( Exception )
            {
                // Erros aqui já foram logados via HandleLogReceived. Apenas retorna false.
                return false;
            }
        }

        public async Task StartEmailSearch()
        {
            if ( string.IsNullOrEmpty(currentSessionId) )
            {
                MessageBox.Show("Primeiro, crie uma sessão!");
                return;
            }

            try
            {
                AddLogToRichTextBox("connection", "Iniciando busca de emails...", DateTime.Now);

                // Chama o Service, que tem a responsabilidade do endpoint
                var response = await _devedorService.StartEmailSearch(currentSessionId);

                if ( response["success"]?.Value<bool>() == true )
                {
                    AddLogToRichTextBox("connection", "Busca iniciada com sucesso", DateTime.Now);
                }
                else
                {
                    AddLogToRichTextBox("error", $"Erro ao iniciar busca: {response["message"]}", DateTime.Now);
                }
            }
            catch ( Exception ex )
            {
                AddLogToRichTextBox("error", $"Erro ao iniciar busca: {ex.Message}", DateTime.Now);
            }
        }





    }
}