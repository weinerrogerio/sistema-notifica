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
using Newtonsoft.Json.Linq;
using ReaLTaiizor.Controls;
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormImport : Form
    {
        private readonly ImportService _importService;
        private int _currentLogId = 0;

        private byte[] _lastFileBytes;
        private string _lastFileName;
        private bool _awaitingUserDecision = false;

        private bool _cacheUpdateInProgress = false;

        public FormImport()
        {
            InitializeComponent();
            _importService = Program.ImportService;
            ConfigDataGridView();
            LoadDataImport();

            groupBoxImportHistory.Controls.Remove(overlayUploadPanel);
            this.Controls.Add(overlayUploadPanel);

            timerProgressBar.Interval = 1000;
            timerProgressBar.Enabled = false;
        }

        //dataGridViewDataImport
        private void ConfigDataGridView()
        {
            dataGridViewDataImport.Rows.Clear();
            dataGridViewDataImport.RowHeadersVisible = false;
            dataGridViewDataImport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDataImport.AllowUserToAddRows = false;
            dataGridViewDataImport.MultiSelect = false;
            dataGridViewDataImport.ReadOnly = true;
            dataGridViewDataImport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewDataImport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDataImport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewDataImport.AllowUserToOrderColumns = false;
            dataGridViewDataImport.AllowUserToResizeRows = false;
            dataGridViewDataImport.AllowUserToResizeColumns = true;
            
            var id = new DataGridViewTextBoxColumn
            {
                Name = "id",
                Visible = false // Torna a coluna invisível
            };
            dataGridViewDataImport.Columns.Add(id);
        }

        private async Task LoadDataImport()
        {
            dataGridViewDataImport.Rows.Clear();
            try
            {
                if ( _importService == null )
                {
                    Debug.WriteLine("ImportService não foi inicializado!");
                    MessageBox.Show("Erro: Serviço não disponivel, verifique sua conexão.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Debug.WriteLine("Iniciando LoadDataImport...");
                List<DataImportsUser> dados = await _importService.SearchImportsAsync();

                if ( dados == null || dados.Count == 0 )
                {
                    Debug.WriteLine("LoadDataImport: dados retornados são NULL ou vazios");
                    return;
                }

                Debug.WriteLine($"LoadgDataImport - Sucesso: {dados.Count} registros encontrados");

                dataGridViewDataImport.Rows.Clear();

                foreach ( var file in dados )
                {
                    if ( file != null )
                    {
                        AdicionarLinhaApiTabelaFile(file);
                    }
                }

                AplicarCoresImportStatus();
            }
            catch ( Exception ex )
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

                int rowIndex = dataGridViewDataImport.Rows.Add();
                DataGridViewRow row = dataGridViewDataImport.Rows[rowIndex];

                row.Cells["id"].Value = data.id;
                row.Cells["ColumnFile"].Value = data.nome_arquivo;
                row.Cells["ColumnDate"].Value = data.data_importacao;
                row.Cells["ColumnStatus"].Value = data.status;
                row.Cells["ColumnUser"].Value = data.usuario?.Nome ?? "N/A";
                row.Cells["ColumnRecordsCount"].Value = data.total_registros;
                row.Cells["ColumnErrorCount"].Value = data.registros_com_erro;
                row.Cells["ColumnDuplicatesCount"].Value = data.registros_duplicados;
                row.Cells["ColumnFileSize"].Value = data.tamanho_arquivo;
                row.Cells["ColumnDetalhesErros"].Value = data.detalhes_erro;
                row.Cells["ColumnDetalhesDuplicidades"].Value = data.detalhes_duplicidade;
                row.Tag = status;

                Debug.WriteLine($"Linha de importação adicionada: {data.nome_arquivo} - Status: {status}");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao adicionar linha da API de importações: {ex.Message}");
            }
        }

        private void AplicarCoresImportStatus()
        {
            foreach ( DataGridViewRow row in dataGridViewDataImport.Rows )
            {
                if ( row.Tag != null )
                {
                    string status = row.Tag.ToString();

                    switch ( status )
                    {
                        case "sucesso":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case "parcial":
                            row.DefaultCellStyle.BackColor = Color.LightGray;
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

        private void dialogImport()
        {
            using ( OpenFileDialog openFileDialog = new OpenFileDialog() )
            {
                openFileDialog.InitialDirectory = "C:\\Users\\Dist02\\js\\Nest.js\\sistema-notifica-nestjs";
                openFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Arquivos CSV (*.csv)|*.csv|Todos os Arquivos (*.*)|*.*";
                openFileDialog.FilterIndex = 3;
                openFileDialog.RestoreDirectory = true;

                if ( openFileDialog.ShowDialog() == DialogResult.OK )
                {
                    string filePath = openFileDialog.FileName;

                    smallTextBoxSelectFile.Text = filePath;

                    if ( string.IsNullOrWhiteSpace(filePath) || !System.IO.File.Exists(filePath) )
                    {
                        MessageBox.Show("Por favor, selecione um arquivo válido para importar.", "Arquivo Não Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    try
                    {
                        toolStripProgressBarImport.Visible = true;
                        toolStripProgressBarImport.Style = ProgressBarStyle.Marquee;
                        byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                        string fileName = System.IO.Path.GetFileName(filePath);
                    }
                    catch ( Exception ex )
                    {
                        MessageBox.Show("Ocorreu um erro ao Selecionar o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            dialogImport();
        }

        private void smallTextBoxSelectFile_Click(object sender, EventArgs e)
        {
            dialogImport();
        }

        private void smallTextBoxSelectFile_MouseClick(object sender, MouseEventArgs e)
        {
            dialogImport();
        }

        private async Task<bool> ExecuteImportAsync(byte[] fileBytes, string fileName, bool allowPartialImport = false)
        {
            try
            {
                Debug.WriteLine($"Executando importação - allowPartialImport: {allowPartialImport}");
                DisableMainControls(true);

                ImportResponse response = await _importService.UploadFileAsync(fileBytes, fileName, allowPartialImport);
                _currentLogId = response.logId;

                Debug.WriteLine($"LogId recebido: {response.logId}");
                Debug.WriteLine($"LogImportId : {_currentLogId}");

                smallTextBoxSelectFile.Text = "Selecione um arquivo...";

                string mensagemOverlay = allowPartialImport
                    ? "Processando arquivo (salvando apenas dados válidos)..."
                    : "Processando arquivo...";

                ShowLoadingOverlay(mensagemOverlay);
                return true;
            }
            catch ( HttpRequestException httpEx )
            {
                MessageBox.Show($"Erro na requisição à API: {httpEx.Message}\nVerifique o console para mais detalhes.", "Erro de Comunicação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseLoadingOverlay();
                return false;
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseLoadingOverlay();
                return false;
            }
            finally
            {
                toolStripProgressBarImport.Visible = false;
            }
        }

        private async void buttonImport_Click(object sender, EventArgs e)
        {
            string filePath = smallTextBoxSelectFile.Text;

            if ( string.IsNullOrWhiteSpace(filePath) || !System.IO.File.Exists(filePath) )
            {
                MessageBox.Show("Por favor, selecione um arquivo válido para importar.", "Arquivo Não Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // NOVO: Limpa o cache antes de iniciar o upload
                Debug.WriteLine("FormImport: Limpando cache antes do upload");
                ProtestoDataCache.Clear();

                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                string fileName = System.IO.Path.GetFileName(filePath);

                _lastFileBytes = fileBytes;
                _lastFileName = fileName;

                await ExecuteImportAsync(fileBytes, fileName, false);
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"Erro ao ler o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await LoadDataImport();
            }
        }

        private async void HandlePartialImportDecision()
        {
            if ( _lastFileBytes == null || string.IsNullOrEmpty(_lastFileName) )
            {
                MessageBox.Show("Dados do arquivo não disponíveis para reenvio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                "O arquivo contém registros com erro ou duplicados.\n\n" +
                "Deseja prosseguir importando apenas os dados válidos?\n\n" +
                "• SIM: Salva apenas registros válidos\n" +
                "• NÃO: Cancela a importação",
                "Importação Parcial",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if ( result == DialogResult.Yes )
            {
                Debug.WriteLine("Usuário escolheu prosseguir com importação parcial");

                // NOVO: Limpa o cache antes da importação parcial
                Debug.WriteLine("FormImport: Limpando cache antes da importação parcial");
                ProtestoDataCache.Clear();

                await ExecuteImportAsync(_lastFileBytes, _lastFileName, true);
            }
            else
            {
                Debug.WriteLine("Usuário cancelou a importação");
                MessageBox.Show("Importação cancelada pelo usuário.", "Importação Cancelada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _lastFileBytes = null;
                _lastFileName = null;
                CloseLoadingOverlay();
                await LoadDataImport();
            }

            _awaitingUserDecision = false;
        }

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            // Lógica para aplicar filtro
        }

        private void btnDatails_Click(object sender, EventArgs e)
        {
            if ( dataGridViewDataImport.SelectedRows.Count == 0 )
            {
                MessageBox.Show("Por favor, selecione uma linha para ver os detalhes.", "Nenhuma linha selecionada",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow linhaSelecionada = dataGridViewDataImport.SelectedRows[0];

            string detalhesErros = linhaSelecionada.Cells["ColumnDetalhesErros"]?.Value?.ToString() ?? "";
            string detalhesDuplicidades = linhaSelecionada.Cells["ColumnDetalhesDuplicidades"]?.Value?.ToString() ?? "";
            string nomeArquivo = linhaSelecionada.Cells["ColumnFile"]?.Value?.ToString() ?? "Arquivo";

            bool temErros = !string.IsNullOrEmpty(detalhesErros) && detalhesErros != "[null]";
            bool temDuplicidades = !string.IsNullOrEmpty(detalhesDuplicidades) && detalhesDuplicidades != "[null]";

            if ( !temErros && !temDuplicidades )
            {
                MessageBox.Show("Esse Arquivo não possui detalhes de erros ou duplicidades.", "Sem detalhes",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using ( FormDetalhesErros formDetalhes = new FormDetalhesErros() )
            {
                formDetalhes.Text = $"Detalhes dos Erros - {nomeArquivo}";
                formDetalhes.ExibirDetalhes(detalhesErros, detalhesDuplicidades);
                formDetalhes.ShowDialog(this);
            }
        }

        //-------------------------------------- FUNÇÕES DO PPANEL PROGRESS BAR -------------------------------

        private void DisableMainControls(bool disable)
        {
            buttonImport.Enabled = !disable;
            buttonSelect.Enabled = !disable;
            buttonRefresh.Enabled = !disable;
            buttonExportLog.Enabled = !disable;
            btnDelete.Enabled = !disable;
            buttonApplyFilter.Enabled = !disable;
            buttonClearFilter.Enabled = !disable;
            btnDatails.Enabled = !disable;
        }

        private void CenterOverlayPanel()
        {
            int x = ( this.ClientSize.Width - overlayUploadPanel.Width ) / 2;
            int y = ( this.ClientSize.Height - overlayUploadPanel.Height ) / 2;
            overlayUploadPanel.Location = new Point(x, y);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if ( overlayUploadPanel != null && overlayUploadPanel.Visible )
            {
                CenterOverlayPanel();
            }
        }

        public void ShowLoadingOverlay(string message = "Processando arquivo...")
        {
            if ( overlayUploadPanel.Controls.Count > 1 && overlayUploadPanel.Controls[1] is Label contentLabel )
            {
                contentLabel.Text = message;
            }

            CenterOverlayPanel();
            overlayUploadPanel.Visible = true;
            overlayUploadPanel.BringToFront();
            DisableMainControls(true);
            progressBar.Value = 0;
            labelUploadPercent.Text = "0%";
            labelStatusUpload.Text = "Iniciando...";

            this.Refresh();
            Application.DoEvents();

            Debug.WriteLine("Chamando ProgressBar...");
            Debug.WriteLine($"Timer habilitado: {timerProgressBar.Enabled}");
            Debug.WriteLine($"Timer intervalo: {timerProgressBar.Interval}");
            Debug.WriteLine($"CurrentLogId: {_currentLogId}");

            timerProgressBar.Stop();
            timerProgressBar.Interval = 1000;
            timerProgressBar.Start();

            Debug.WriteLine($"Timer iniciado: {timerProgressBar.Enabled}");
        }

        private void CloseLoadingOverlay()
        {
            Debug.WriteLine("Fechando overlay e parando timer");
            timerProgressBar.Stop();
            overlayUploadPanel.Visible = false;
            DisableMainControls(false);
        }

        // MODIFICAÇÃO: Método para setar o valor da barra de progresso e atualizar os labels
        private void SetProgressBarValue(int value, string statusText)
        {
            if ( progressBar.InvokeRequired )
            {
                progressBar.Invoke(new Action(() => SetProgressBarValue(value, statusText)));
                return;
            }

            // Garante que o valor da barra esteja entre 0 e 100
            value = Math.Max(0, Math.Min(100, value));

            progressBar.Value = value;
            labelUploadPercent.Text = $"{value}%";
            labelStatusUpload.Text = statusText;

            Debug.WriteLine($"Set ProgressBar: {value}% - Status: {statusText}");

            if ( value >= 100 )
            {
                Debug.WriteLine("Processamento concluído, exibindo 100%...");
                // Aguarda um momento para o usuário ver o 100%
                System.Threading.Tasks.Task.Delay(1000).ContinueWith(_ =>
                {
                    if ( this.InvokeRequired )
                        this.Invoke(new Action(CloseLoadingOverlay));
                    else
                        CloseLoadingOverlay();
                });
            }
        }

        private async Task<JObject> GetDataStatusUpload(int id)
        {
            try
            {
                Debug.WriteLine($"Buscando status para ID: {id}");
                var result = await _importService.SearhLogImportsAsync(id);
                Debug.WriteLine($"Status recebido: {result}");
                return result;
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao buscar status: {ex.Message}");
                throw;
            }
        }

        private async void timerProgressBar_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine($"Timer tick executado - LogId: {_currentLogId}");

            if ( _currentLogId == 0 || _currentLogId <= 0 || _awaitingUserDecision )
            {
                Debug.WriteLine("LogId é inválido ou aguardando decisão, parando timer");
                timerProgressBar.Stop();
                return;
            }

            try
            {
                var data = await GetDataStatusUpload(_currentLogId);

                if ( data == null || data["status"] == null )
                {
                    Debug.WriteLine("Dados de status inválidos, parando timer");
                    CloseLoadingOverlay();
                    return;
                }

                string status = data["status"].ToString();
                int total = ( int ) ( data["total_registros"] ?? 0 );
                int processado = ( int ) ( data["registros_processados"] ?? 0 );
                string detalhesProgresso = data["detalhes_progresso"]?.ToString() ?? "Processando...";

                int progresso = 0;
                if ( total > 0 )
                {
                    progresso = ( processado * 100 ) / total;
                }

                SetProgressBarValue(progresso, detalhesProgresso);

                // Se o processo de importação terminou
                if ( status == "sucesso" || status == "falha" || status == "parcial" && detalhesProgresso == "concluido" )
                {
                    CloseLoadingOverlay();
                    timerProgressBar.Stop();
                    Debug.WriteLine("Processamento finalizado. Recarregando dados.");

                    if ( status == "falha" && data["detalhes_erro"] != null && data["detalhes_erro"].ToString().Contains("Arquivo contém registro(s) com erro(s) ou duplicados.") )
                    {
                        _awaitingUserDecision = true;
                        if ( this.InvokeRequired )
                        {
                            this.Invoke(new Action(HandlePartialImportDecision));
                        }
                        else
                        {
                            HandlePartialImportDecision();
                        }
                        return;
                    }

                    // NOVO: Atualizar o cache em background após upload bem-sucedido
                    if ( status == "sucesso" || status == "parcial" )
                    {
                        _ = Task.Run(async () =>
                        {
                            try
                            {
                                if ( !_cacheUpdateInProgress )
                                {
                                    _cacheUpdateInProgress = true;
                                    Debug.WriteLine("FormImport: Iniciando atualização do cache após upload");

                                    // Atualiza o cache em background
                                    await FormData.RefreshCacheAfterUpload(Program.ProtestoService);

                                    Debug.WriteLine("FormImport: Cache atualizado com sucesso após upload");
                                }
                            }
                            catch ( Exception ex )
                            {
                                Debug.WriteLine($"FormImport: Erro ao atualizar cache: {ex.Message}");
                            }
                            finally
                            {
                                _cacheUpdateInProgress = false;
                            }
                        });
                    }

                    await LoadDataImport();
                    string message = data["message"]?.ToString() ?? "Importação finalizada.";

                    // NOVO: Mensagem adicional sobre atualização do cache
                    if ( status == "sucesso" || status == "parcial" )
                    {
                        message += "\n\nOs dados foram atualizados em segundo plano.";
                    }

                    MessageBox.Show(message, "Status da Importação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao verificar progresso: {ex.Message}");
                CloseLoadingOverlay();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if ( dataGridViewDataImport.SelectedRows.Count == 0 )
            {
                MessageBox.Show("Por favor, selecione um arquivo para excluir.", "Nenhum Arquivo Selecionado",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dataGridViewDataImport.SelectedRows[0];
            var logId = selectedRow.Cells["id"].Value;
            var fileName = selectedRow.Cells["ColumnFile"].Value?.ToString() ?? "Arquivo selecionado";

            var result = MessageBox.Show(
                $"Ao prosseguir o arquivo {fileName} e seus registros importados anteriormente serão PERMANENTEMENTE EXCLUÍDOS.\n\n" +
                "Tem certeza que deseja excluir o arquivo selecionado?\n\n" +
                "• ATENÇÃO: Essa operação NÃO pode ser revertida",
                "ALERTA",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error
            );

            if ( result == DialogResult.Yes )
            {
                if ( logId != null && int.TryParse(logId.ToString(), out int idToDelete) )
                {
                    try
                    {
                        Debug.WriteLine($"Excluindo arquivo com ID: {idToDelete}");
                        await _importService.DeleteFileAsync(idToDelete);

                        // NOVO: Limpa o cache após exclusão
                        Debug.WriteLine("FormImport: Limpando cache após exclusão de arquivo"); 
                        ProtestoDataCache.Clear();

                        await LoadDataImport();

                        // NOVO: Atualiza o cache em background após exclusão
                        _ = Task.Run(async () =>
                        {
                            try
                            {
                                Debug.WriteLine("FormImport: Atualizando cache após exclusão");
                                await FormData.RefreshCacheAfterUpload(Program.ProtestoService);

                                // Notifica outros formulários
                                this.Invoke(new Action(NotifyFormsAboutCacheUpdate));
                            }
                            catch ( Exception ex )
                            {
                                Debug.WriteLine($"FormImport: Erro ao atualizar cache após exclusão: {ex.Message}");
                            }
                        });

                        MessageBox.Show("Arquivo excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch ( Exception ex )
                    {
                        MessageBox.Show($"Erro ao excluir arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível obter o ID do arquivo para exclusão.", "Erro",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void NotifyFormsAboutCacheUpdate()
        {
            try
            {
                // Procura por formulários FormData abertos e os notifica sobre a atualização
                foreach ( Form form in Application.OpenForms )
                {
                    if ( form is FormData formData && form != this )
                    {
                        Debug.WriteLine("FormImport: Notificando FormData sobre atualização do cache");

                        // O FormData já está inscrito nos eventos do cache, então a atualização será automática
                        // Mas podemos forçar uma verificação se necessário
                        Task.Run(async () =>
                        {
                            try
                            {
                                await Task.Delay(2000); // Aguarda um pouco para o cache ser atualizado

                                if ( form.InvokeRequired )
                                {
                                    form.Invoke(new Action(() => form.Text = "Sistema Notifica - Dados atualizados"));
                                }
                                else
                                {
                                    form.Text = "Sistema Notifica - Dados atualizados";
                                }

                                await Task.Delay(3000); // Mostra a mensagem por 3 segundos

                                if ( form.InvokeRequired )
                                {
                                    form.Invoke(new Action(() => form.Text = "Sistema Notifica"));
                                }
                                else
                                {
                                    form.Text = "Sistema Notifica";
                                }
                            }
                            catch ( Exception ex )
                            {
                                Debug.WriteLine($"FormImport: Erro ao notificar FormData: {ex.Message}");
                            }
                        });
                    }
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"FormImport: Erro ao procurar formulários: {ex.Message}");
            }
        }




    }
}