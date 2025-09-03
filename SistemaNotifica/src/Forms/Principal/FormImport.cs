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
        }

        private async Task LoadDataImport()
        {
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

        // Lógica de importação separada para reuso
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
                // Erros específicos de requisição HTTP (ex: 4xx, 5xx)
                MessageBox.Show($"Erro na requisição à API: {httpEx.Message}\nVerifique o console para mais detalhes.", "Erro de Comunicação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseLoadingOverlay();
                return false;
            }
            catch ( Exception ex )
            {
                // Outros erros
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseLoadingOverlay();
                return false;
            }
            finally
            {
                toolStripProgressBarImport.Visible = false;
            }
        }

        // MODIFICAÇÃO: Lógica para iniciar a importação.
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
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                string fileName = System.IO.Path.GetFileName(filePath);

                _lastFileBytes = fileBytes;
                _lastFileName = fileName;

                // Executar importação sem allowPartialImport
                await ExecuteImportAsync(fileBytes, fileName, false);
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"Erro ao ler o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                await LoadDataImport(); // Recarrega os dados para mostrar o status "falha"
            }

            _awaitingUserDecision = false;
        }

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            // Lógica para aplicar filtro
        }

        private void btnDatails_Click(object sender, EventArgs e)
        {
            // Lógica para exibir detalhes
        }

        //-------------------------------------- FUNÇÕES DO PANEL PROGRESS BAR -------------------------------

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

        private void SetProgressBarValue(int value)
        {
            if ( progressBar.InvokeRequired )
            {
                progressBar.Invoke(new Action(() => SetProgressBarValue(value)));
                return;
            }

            if ( value >= progressBar.Minimum && value <= progressBar.Maximum )
            {
                Debug.WriteLine($"Set ProgressBar: {value}");
                progressBar.Value = value;
            }

            if ( value >= 100 )
            {
                progressBar.Value = 100;
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

        // MODIFICAÇÃO: Lógica do timer com tratamento de decisão do usuário
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

                // Verifica o status final do processamento
                string status = data["status"].ToString();

                if ( status == "falha" || status == "parcial" )
                {
                    CloseLoadingOverlay();
                    timerProgressBar.Stop();

                    // Se a falha ocorreu na primeira tentativa (sem allowPartialImport)
                    // e houver erros/duplicidades, perguntar ao usuário.
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
                    else if ( status == "parcial" || status == "falha" )
                    {
                        // Se o status é parcial, a segunda importação foi concluída.
                        // Ou se a falha é de outro tipo (não por erro/duplicado).
                        MessageBox.Show("Importação finalizada com status: " + status, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        await LoadDataImport();
                        return;
                    }
                }

                // Se não houve falha, continua a checagem de progresso
                int total = ( int ) ( data["total_registros"] ?? 0 );
                int processado = ( int ) ( data["registros_processados"] ?? 0 );

                if ( total > 0 )
                {
                    int progresso = ( processado * 100 ) / total;
                    SetProgressBarValue(progresso);

                    if ( processado >= total )
                    {
                        Debug.WriteLine("Processamento concluído!");
                        SetProgressBarValue(100);

                        await LoadDataImport();
                    }
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao verificar progresso: {ex.Message}");
                CloseLoadingOverlay();
            }
        }
    }
}