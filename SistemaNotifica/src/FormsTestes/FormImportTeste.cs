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
using ReaLTaiizor.Controls;
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormImportTeste : Form
    {
        private readonly ImportService _importService;

        public FormImportTeste()
        {
            InitializeComponent();
            _importService = Program.ImportService;
            ConfigDataGridView();
            //ShowProgressPanel();
            groupBoxImportHistory.Controls.Remove(overlayPanel);
            this.Controls.Add(overlayPanel);
            // Configurar eventos para centralizar o painel quando necessário
            //this.Load += FormImportTeste_Load;
            //this.Resize += FormImportTeste_Resize;
        }

        private void ShowOverlay_Click(object sender, EventArgs e)
        {
            // Calcular posição para centralizar no form inteiro
            CenterOverlayPanel();

            // Mostrar overlay
            overlayPanel.Visible = true;

            // CRUCIAL: Trazer para frente para ficar por cima de TUDO
            overlayPanel.BringToFront();
            //DisableMainControls(true);
        }       

        private void CenterOverlayPanel()
        {
            // Centralizar no Form inteiro (não apenas no mainPanel)
            int x = ( this.ClientSize.Width - overlayPanel.Width ) / 2;
            int y = ( this.ClientSize.Height - overlayPanel.Height ) / 2;
            overlayPanel.Location = new Point(x, y);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if ( overlayPanel != null && overlayPanel.Visible )
            {
                CenterOverlayPanel();
            }
        }

        // Opcional: Método para simular loading como nas imagens
        public void ShowLoadingOverlay(string message = "Carregando...")
        {
            // Atualizar texto do overlay
            if ( overlayPanel.Controls.Count > 1 && overlayPanel.Controls[1] is Label contentLabel )
            {
                contentLabel.Text = message;
            }

            ShowOverlay_Click(null, null);

            // Forçar atualização da interface
            this.Refresh();
            Application.DoEvents();
        }

        //public void HideLoadingOverlay()
        //{
        //    HideOverlay_Click(null, null);
        //}


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
            dataGridViewDataImport.AllowUserToResizeColumns = false;
        }

        private void dialogImport()
        {
            using ( OpenFileDialog openFileDialog = new OpenFileDialog() )
            {
                // RETIRAR ESSE DIRETÓRIO -- TESTES
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
                        // Remover o uso da toolStripProgressBarImport pois agora usamos nosso painel customizado
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

        private async void buttonImport_Click(object sender, EventArgs e)
        {
            ShowLoadingOverlay();
            //string filePath = smallTextBoxSelectFile.Text;

            //if ( string.IsNullOrWhiteSpace(filePath) || !System.IO.File.Exists(filePath) )
            //{
            //    MessageBox.Show("Por favor, selecione um arquivo válido para importar.", "Arquivo Não Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //try
            //{
            //    // Usar nosso novo painel de progresso em vez do toolStripProgressBarImport
            //    ShowProgressPanelMarquee("Iniciando upload do arquivo...");

            //    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            //    string fileName = System.IO.Path.GetFileName(filePath);

            //    // Simular progresso de upload (substitua por sua lógica real)
            //    UpdateProgress(25, "Preparando arquivo...");
            //    await Task.Delay(500); // Simular trabalho

            //    UpdateProgress(50, "Enviando para servidor...");
            //    ImportResponse response = await _importService.UploadFileAsync(fileBytes, fileName);

            //    UpdateProgress(75, "Processando dados...");
            //    await Task.Delay(500); // Simular processamento

            //    UpdateProgress(100, "Finalizando...");
            //    await Task.Delay(300);

            //    HideProgressPanel();

            //    int loId = response.LogImportId;
            //    MessageBox.Show($"Arquivo importado com sucesso!\nRegistros: {response.processedCount}\nErros encontrados: {response.errorCount}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    smallTextBoxSelectFile.Text = "Selecione um arquivo...";
            //}
            //catch ( HttpRequestException httpEx )
            //{
            //    HideProgressPanel();
            //    MessageBox.Show($"Erro na requisição à API: {httpEx.Message}\nVerifique o console para mais detalhes.", "Erro de Comunicação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch ( Exception ex )
            //{
            //    HideProgressPanel();
            //    MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {

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
    }
}