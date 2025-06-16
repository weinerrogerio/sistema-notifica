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
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;

namespace SistemaNotifica.src.Forms.Template
{
    public partial class TemplateManagerForm : Form
    {
        private ApiService _apiService;
        private List<EmailTemplate> _templates;

        
        public TemplateManagerForm()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _templates = new List<EmailTemplate>();
            InitializeAsync();
        }

        

        private async void InitializeAsync()
        {
            await CarregarTemplates();
        }

        private async Task CarregarTemplates()
        {
            try
            {
                SetStatus("Carregando templates...");
                _templates = await _apiService.GetTemplatesAsync();
                dgvTemplates.DataSource = _templates;
                SetStatus($"{_templates.Count} template(s) carregado(s)");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar templates: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatus("Erro ao carregar templates");
            }
        }

        private async void BtnUpload_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos HTML (*.html)|*.html|Todos os arquivos (*.*)|*.*";
                openFileDialog.Title = "Selecionar Template HTML";
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoArquivoSelecionado = openFileDialog.FileName;
                    Debug.WriteLine($"Arquivo selecionado: {caminhoArquivoSelecionado}");

                    try
                    {
                        // 1. Validar se o arquivo existe e pode ser lido (primeira checagem)
                        // FileInfo.Exists é rápido e não tenta abrir o arquivo.
                        var fileInfo = new FileInfo(caminhoArquivoSelecionado);

                        if (!fileInfo.Exists)
                        {
                            MessageBox.Show("O arquivo selecionado não foi encontrado no caminho especificado. Por favor, verifique.", "Arquivo Não Encontrado",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Debug.WriteLine($"ERRO: Arquivo não encontrado: {caminhoArquivoSelecionado}");
                            return;
                        }

                        // 2. Tentar ler o arquivo para verificar acessibilidade e tamanho real
                        byte[] fileBytes;
                        try
                        {
                            fileBytes = await File.ReadAllBytesAsync(caminhoArquivoSelecionado);
                            Debug.WriteLine($"Bytes lidos no frontend (File.ReadAllBytesAsync): {fileBytes.Length} bytes");
                        }
                        catch (UnauthorizedAccessException)
                        {
                            MessageBox.Show("Sem permissão para ler o arquivo selecionado. Verifique as permissões de acesso ao arquivo.", "Erro de Permissão",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Debug.WriteLine($"ERRO: Sem permissão para ler o arquivo: {caminhoArquivoSelecionado}");
                            return;
                        }
                        catch (IOException ex) when ((ex.HResult & 0xFFFF) == 32) // Error code for "The process cannot access the file because it is being used by another process."
                        {
                            MessageBox.Show($"O arquivo está sendo usado por outro processo. Por favor, feche-o e tente novamente.\n\nDetalhes: {ex.Message}", "Arquivo em Uso",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Debug.WriteLine($"ERRO: Arquivo em uso: {caminhoArquivoSelecionado} - {ex.Message}");
                            return;
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show($"Erro de I/O ao acessar o arquivo: {ex.Message}", "Erro de Acesso ao Arquivo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Debug.WriteLine($"ERRO: Erro de I/O: {caminhoArquivoSelecionado} - {ex.Message}");
                            return;
                        }

                        // 3. Verificar se o arquivo está vazio APÓS a leitura bem-sucedida
                        // Usamos fileBytes.Length que é o tamanho real lido
                        if (fileBytes.Length == 0)
                        {
                            MessageBox.Show("O arquivo selecionado está vazio ou não pôde ser lido em sua totalidade. Por favor, selecione um arquivo com conteúdo.", "Arquivo Vazio",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Debug.WriteLine($"ERRO: Arquivo vazio após leitura: {caminhoArquivoSelecionado}");
                            return;
                        }

                        // 4. Verificar tamanho máximo (20MB conforme backend)
                        const long tamanhoMaximo = 20 * 1024 * 1024; // 20MB
                        if (fileBytes.Length > tamanhoMaximo)
                        {
                            MessageBox.Show($"Arquivo muito grande. Tamanho máximo permitido: {tamanhoMaximo / (1024 * 1024)}MB. Tamanho do arquivo: {Math.Round(fileBytes.Length / (1024.0 * 1024.0), 2)}MB.", "Arquivo Muito Grande",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Debug.WriteLine($"ERRO: Arquivo muito grande: {caminhoArquivoSelecionado} - {fileBytes.Length} bytes");
                            return;
                        }

                        // Mostrar confirmação com informações do arquivo
                        var nomeArquivo = Path.GetFileName(caminhoArquivoSelecionado);
                        var tamanhoMB = Math.Round(fileBytes.Length / (1024.0 * 1024.0), 2); // Usa o tamanho real lido

                        var confirmacao = MessageBox.Show(
                            $"Deseja fazer upload do template?\n\n" +
                            $"Arquivo: {nomeArquivo}\n" +
                            $"Tamanho: {tamanhoMB} MB\n" +
                            $"Caminho: {caminhoArquivoSelecionado}",
                            "Confirmar Upload",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (confirmacao == DialogResult.Yes)
                        {
                            SetStatus("Preparando para enviar o template...");

                            // Desabilitar botão durante upload
                            var btnUpload = sender as Button;
                            if (btnUpload != null)
                            {
                                btnUpload.Enabled = false;
                            }

                            try
                            {
                                // Passa os bytes e o nome do arquivo para o serviço, evitando reler o arquivo
                                var template = await _apiService.UploadTemplateAsync(fileBytes, nomeArquivo);

                                MessageBox.Show(
                                    $"Template '{template.NomeArquivo}' enviado com sucesso!",
                                    "Sucesso no Upload",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );

                                SetStatus("Upload concluído com sucesso.");
                                await CarregarTemplates(); // Atualiza a lista ou UI
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao fazer upload do template: {ex.Message}", "Erro no Upload",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Debug.WriteLine($"ERRO CRÍTICO NO UPLOAD: {ex}"); // Log completo da exceção
                                SetStatus("Erro no upload.");
                            }
                            finally
                            {
                                // Reabilitar botão
                                if (btnUpload != null)
                                {
                                    btnUpload.Enabled = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex) // Captura qualquer exceção não tratada acima
                    {
                        MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Inesperado",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Debug.WriteLine($"ERRO INESPERADO NA FUNÇÃO DE UPLOAD: {ex}");
                        SetStatus("Erro inesperado.");
                    }
                }
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTemplates.SelectedRows.Count == 0) return;

            var template = (EmailTemplate)dgvTemplates.SelectedRows[0].DataBoundItem;

            if (template.EhPadrao)
            {
                MessageBox.Show("Não é possível excluir o template padrão!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Tem certeza que deseja excluir o template '{template.NomeArquivo}'?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    SetStatus("Excluindo template...");
                    await _apiService.DeleteTemplateAsync(template.Id);
                    await CarregarTemplates();
                    SetStatus("Template excluído");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir template: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BtnSetPadrao_Click(object sender, EventArgs e)
        {
            if (dgvTemplates.SelectedRows.Count == 0) return;

            var template = (EmailTemplate)dgvTemplates.SelectedRows[0].DataBoundItem;

            try
            {
                SetStatus("Definindo template padrão...");
                await _apiService.SetTemplatePadraoAsync(template.Id);
                await CarregarTemplates();
                MessageBox.Show($"Template '{template.NomeArquivo}' definido como padrão!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao definir template padrão: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnPreview_Click(object sender, EventArgs e)
        {
            if (dgvTemplates.SelectedRows.Count == 0) return;

            var template = (EmailTemplate)dgvTemplates.SelectedRows[0].DataBoundItem;

            try
            {
                SetStatus("Gerando preview...");
                var dadosTeste = GetDadosTeste();
                var htmlPreview = await _apiService.GetPreviewAsync(template.ConteudoHtml, dadosTeste);
                webPreview.DocumentText = htmlPreview;
                SetStatus("Preview gerado");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar preview: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await CarregarTemplates();
        }

        private void DgvTemplates_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvTemplates.SelectedRows.Count > 0;
            btnDelete.Enabled = hasSelection;
            btnSetPadrao.Enabled = hasSelection;
            btnPreview.Enabled = hasSelection;

            if (hasSelection)
            {
                var template = (EmailTemplate)dgvTemplates.SelectedRows[0].DataBoundItem;
                btnDelete.Enabled = !template.EhPadrao; // Não pode excluir o padrão
                btnSetPadrao.Enabled = !template.EhPadrao; // Não precisa definir se já é padrão
            }
        }

        private Dictionary<string, object> GetDadosTeste()
        {
            return new Dictionary<string, object>
            {
                ["dados"] = new Dictionary<string, object>
                {
                    ["nomeDevedor"] = "João Silva",
                    ["docDevedor"] = "123.456.789-00",
                    ["valorTotal"] = "1.500,00",
                    ["dataVencimento"] = "15/12/2024",
                    ["credor"] = "Empresa ABC Ltda"
                }
            };
        }

        private void SetStatus(string message)
        {
            lblStatus.Text = message;
            statusStrip.Refresh();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _apiService?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
