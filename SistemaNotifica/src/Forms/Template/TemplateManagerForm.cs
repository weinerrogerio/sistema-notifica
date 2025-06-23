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
using SistemaNotifica.src.Styles;
using SistemaNotifica.src.Controls;
using SistemaNotifica.src.Forms.Template.Controls;

namespace SistemaNotifica.src.Forms.Template
{
    public partial class TemplateManagerForm : Form
    {
        private ApiService _apiService;
        private List<EmailTemplate> _templates;
        private FlowLayoutPanel _flowLayoutTemplates;
        private EmailTemplate _selectedTemplate;
        private List<TemplateCard> _templateCards;
        public Form pnlForm;
        private bool pnlFormExpanded = false;
        private int targetWidth = 0; // Largura alvo para a animação
        private bool isAnimating = false; // Controle de animação
        private bool isFormLoaded = false; // Controle de carregamento do formulário

        private TemplateEditForm _currentEditForm;

        public TemplateManagerForm()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _templates = new List<EmailTemplate>();
            _templateCards = new List<TemplateCard>();
            SetupTemplatePanel();
            InitializeAsync();
        }

        private void SetupTemplatePanel()
        {
            // Remove o DataGridView e substitui por FlowLayoutPanel
            panelTableTamplates.Controls.Clear();

            _flowLayoutTemplates = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = Color.FromArgb(248, 249, 250),
                Padding = new Padding(8)
            };

            panelTableTamplates.Controls.Add(_flowLayoutTemplates);
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

                // Busca todos os templates
                _templates = await _apiService.GetTemplatesAsync();
                Debug.WriteLine($"Templates carregados:::::::::: {_templates.Count}");

                // Limpa cards existentes
                _flowLayoutTemplates.Controls.Clear();
                _templateCards.Clear();

                // Se não há templates, exibe mensagem
                if (_templates.Count == 0)
                {
                    webPreview.DocumentText = "<html><body style='display:flex;align-items:center;justify-content:center;height:100vh;font-family:Segoe UI;color:#6c757d;'><div>Nenhum template disponível</div></body></html>";
                    SetStatus("Nenhum template encontrado");
                    return;
                }

                // Cria cards para cada template
                TemplateCard templatePadraoCard = null;

                foreach (var template in _templates)
                {
                    Debug.WriteLine($"Criando card para template: {template.Id} - {template.NomeArquivo} - Padrão: {template.EhPadrao}");

                    var card = new TemplateCard
                    {
                        Template = template
                    };

                    card.CardClicked += Card_CardClicked;
                    card.PadraoChanged += Card_PadraoChanged;

                    _templateCards.Add(card);
                    _flowLayoutTemplates.Controls.Add(card);

                    // Guarda referência do template padrão
                    if (template.EhPadrao)
                    {
                        templatePadraoCard = card;
                    }
                }

                // Força o refresh do layout
                _flowLayoutTemplates.Refresh();
                _flowLayoutTemplates.PerformLayout();

                SetStatus($"{_templates.Count} template(s) carregado(s)");

                // Seleciona automaticamente o template padrão, ou o primeiro
                var cardParaSelecionar = templatePadraoCard ?? _templateCards[0];

                if (cardParaSelecionar != null)
                {
                    SelectTemplate(cardParaSelecionar);
                    await ExibirPreview(cardParaSelecionar.Template);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao carregar templates: {ex}");
                MessageBox.Show($"Erro ao carregar templates: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatus("Erro ao carregar templates");
            }
        }


        private async void Card_CardClicked(object sender, EmailTemplate template)
        {
            var clickedCard = sender as TemplateCard;
            SelectTemplate(clickedCard);
            await ExibirPreview(template); // Chamará o método ExibirPreview
        }

        private async void Card_PadraoChanged(object sender, EmailTemplate template)
        {
            try
            {
                SetStatus("Definindo template padrão...");
                await _apiService.SetTemplatePadraoAsync(template.Id);

                // Atualiza os dados locais
                foreach (var t in _templates)
                {
                    t.EhPadrao = t.Id == template.Id;
                }

                // Atualiza a exibição dos cards
                foreach (var card in _templateCards)
                {
                    card.Template = card.Template; // Força refresh
                }

                SetStatus("Template padrão definido com sucesso");

                MessageBox.Show($"Template '{template.NomeArquivo}' definido como padrão!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao definir template padrão: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Reverte o checkbox em caso de erro
                var card = sender as TemplateCard;
                if (card != null)
                {
                    card.Template = card.Template; // Força refresh para reverter
                }
            }
        }

        private void SelectTemplate(TemplateCard selectedCard)
        {
            // Desmarca todos os cards
            foreach (var card in _templateCards)
            {
                card.IsSelected = false;
            }

            // Marca o card selecionado
            if (selectedCard != null)
            {
                selectedCard.IsSelected = true;
                _selectedTemplate = selectedCard.Template;
            }

            // Atualiza botões
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = _selectedTemplate != null;

            btnDelete.Enabled = hasSelection && !_selectedTemplate.EhPadrao;
            btnSetPadrao.Enabled = hasSelection && !_selectedTemplate.EhPadrao;
            btnPreview.Enabled = hasSelection;
        }

        private async Task ExibirPreview(EmailTemplate template)
        {
            try
            {
                SetStatus("Carregando preview do template...");
                Debug.WriteLine($"Exibindo preview do template {template.Id}");

                // Busca o template completo se não tiver conteúdo
                string conteudoHtml = template.ConteudoHtml;

                if (string.IsNullOrEmpty(conteudoHtml))
                {
                    Debug.WriteLine("Conteúdo HTML vazio, buscando template completo...");
                    var templateCompleto = await _apiService.GetTemplateAsync(template.Id);
                    conteudoHtml = templateCompleto.ConteudoHtml;
                }

                if (string.IsNullOrEmpty(conteudoHtml))
                {
                    throw new Exception("Template não possui conteúdo HTML");
                }

                Debug.WriteLine($"Conteúdo HTML obtido: {conteudoHtml.Length} caracteres");

                // Processa o template localmente com dados de teste
                var dadosTeste = GetDadosTeste();
                var htmlProcessado = _apiService.ProcessarTemplate(conteudoHtml, dadosTeste);

                Debug.WriteLine($"HTML processado: {htmlProcessado.Length} caracteres");

                // Exibe no WebBrowser
                webPreview.DocumentText = htmlProcessado;
                SetStatus("Preview carregado com sucesso");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao exibir preview: {ex}");

                var errorHtml = $@"
                <html>
                <head>
                    <style>
                        body {{
                            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                            display: flex;
                            align-items: center;
                            justify-content: center;
                            height: 100vh;
                            margin: 0;
                            background-color: #f8f9fa;
                            color: #dc3545;
                        }}
                        .error-container {{
                            text-align: center;
                            padding: 20px;
                            border: 1px solid #f5c6cb;
                            background-color: #f8d7da;
                            border-radius: 8px;
                            max-width: 500px;
                        }}
                        .error-title {{ font-size: 18px; font-weight: bold; margin-bottom: 10px; }}
                        .error-message {{ font-size: 14px; word-break: break-word; }}
                    </style>
                </head>
                <body>
                    <div class='error-container'>
                        <div class='error-title'>Erro ao gerar preview</div>
                        <div class='error-message'>{ex.Message}</div>
                        <div style='margin-top: 10px; font-size: 12px; color: #6c757d;'>
                            Verifique os logs para mais detalhes
                        </div>
                    </div>
                </body>
                </html>";

                webPreview.DocumentText = errorHtml;
                SetStatus($"Erro ao gerar preview: {ex.Message}");
            }
        }



        // Métodos de botões atualizados
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedTemplate == null) return;

            if (_selectedTemplate.EhPadrao)
            {
                MessageBox.Show("Não é possível excluir o template padrão!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Tem certeza que deseja excluir o template '{_selectedTemplate.NomeArquivo}'?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    SetStatus("Excluindo template...");
                    await _apiService.DeleteTemplateAsync(_selectedTemplate.Id);
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
            if (_selectedTemplate == null) return;

            try
            {
                SetStatus("Definindo template padrão...");
                await _apiService.SetTemplatePadraoAsync(_selectedTemplate.Id);
                await CarregarTemplates();
                MessageBox.Show($"Template '{_selectedTemplate.NomeArquivo}' definido como padrão!", "Sucesso",
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
            if (_selectedTemplate != null)
            {
                await ExibirPreview(_selectedTemplate);
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await CarregarTemplates();
        }

        // Upload permanece igual ao código original
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
                        var fileInfo = new FileInfo(caminhoArquivoSelecionado);

                        if (!fileInfo.Exists)
                        {
                            MessageBox.Show("O arquivo selecionado não foi encontrado no caminho especificado. Por favor, verifique.", "Arquivo Não Encontrado",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Debug.WriteLine($"ERRO: Arquivo não encontrado: {caminhoArquivoSelecionado}");
                            return;
                        }

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
                        catch (IOException ex) when ((ex.HResult & 0xFFFF) == 32)
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

                        if (fileBytes.Length == 0)
                        {
                            MessageBox.Show("O arquivo selecionado está vazio ou não pôde ser lido em sua totalidade. Por favor, selecione um arquivo com conteúdo.", "Arquivo Vazio",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Debug.WriteLine($"ERRO: Arquivo vazio após leitura: {caminhoArquivoSelecionado}");
                            return;
                        }

                        const long tamanhoMaximo = 20 * 1024 * 1024; // 20MB
                        if (fileBytes.Length > tamanhoMaximo)
                        {
                            MessageBox.Show($"Arquivo muito grande. Tamanho máximo permitido: {tamanhoMaximo / (1024 * 1024)}MB. Tamanho do arquivo: {Math.Round(fileBytes.Length / (1024.0 * 1024.0), 2)}MB.", "Arquivo Muito Grande",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Debug.WriteLine($"ERRO: Arquivo muito grande: {caminhoArquivoSelecionado} - {fileBytes.Length} bytes");
                            return;
                        }

                        var nomeArquivo = Path.GetFileName(caminhoArquivoSelecionado);
                        var tamanhoMB = Math.Round(fileBytes.Length / (1024.0 * 1024.0), 2);

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

                            var btnUpload = sender as Button;
                            if (btnUpload != null)
                            {
                                btnUpload.Enabled = false;
                            }

                            try
                            {
                                var template = await _apiService.UploadTemplateAsync(fileBytes, nomeArquivo);

                                MessageBox.Show(
                                    $"Template '{template.NomeArquivo}' enviado com sucesso!",
                                    "Sucesso no Upload",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );

                                SetStatus("Upload concluído com sucesso.");
                                await CarregarTemplates();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao fazer upload do template: {ex.Message}", "Erro no Upload",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Debug.WriteLine($"ERRO CRÍTICO NO UPLOAD: {ex}");
                                SetStatus("Erro no upload.");
                            }
                            finally
                            {
                                if (btnUpload != null)
                                {
                                    btnUpload.Enabled = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Inesperado",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Debug.WriteLine($"ERRO INESPERADO NA FUNÇÃO DE UPLOAD: {ex}");
                        SetStatus("Erro inesperado.");
                    }
                }
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
                    ["credor"] = "Empresa ABC Ltda",
                    ["numeroFatura"] = "FAT-2024-001"
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

        private void webPreview_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        //EDIT --> panelEdit
        private void btnEdit_Click(object sender, EventArgs e)
        {

            // Prevenir múltiplos cliques durante animação
            if (isAnimating)
                return;

            // Se já existe um formulário expandido, contrair primeiro
            if (pnlFormExpanded && pnlForm != null)
            {
                ContractPanel();
                return;
            }

            // Parar qualquer animação em andamento
            timerTransition.Stop();

            // 1. Limpar formulário existente
            CleanupForm();

            // 2. Criar e configurar o novo formulário
            CreateAndConfigureForm();

            // 3. Configurar animação
            SetupAnimation();

            // 4. Iniciar animação
            StartAnimation();
        }

        private void CleanupForm()
        {
            if (pnlForm != null && !pnlForm.IsDisposed)
            {
                pnlForm.Close();
                pnlForm.Dispose();
                pnlForm = null;
            }
            panelEdit.Controls.Clear();
            isFormLoaded = false;
        }

        private async void CreateAndConfigureForm() 
        {
            try
            {
                // Criar o formulário
                pnlForm = new TemplateEditForm
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.None,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom,
                    WindowState = FormWindowState.Normal // Garantir que não está maximizado
                };

                // Definir tamanho inicial
                pnlForm.Location = new Point(0, 0);
                pnlForm.Size = new Size(0, panelEdit.Height);

                // Adicionar ao painel ANTES de mostrar
                panelEdit.Controls.Add(pnlForm);
                //panelEdit.BringToFront();

                // Aguardar um frame para garantir que o controle foi adicionado
                await Task.Delay(1);

                // Mostrar o formulário
                pnlForm.Show();
                pnlForm.BringToFront();

                // Aguardar a inicialização dos WebView2 (importante!)
                await Task.Delay(100);

                isFormLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar formulário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupAnimation()
        {
            // Definir largura inicial do painel para 0
            panelEdit.Width = 0;

            // Definir largura alvo
            targetWidth = this.ClientSize.Width;

            // Estado inicial da animação
            pnlFormExpanded = false;
            isAnimating = true;
        }

        private void StartAnimation()
        {
            // Iniciar timer de animação
            timerTransition.Start();
        }

        private void timerTransition_Tick(object sender, EventArgs e)
        {
            const int step = 20;
            const int minStep = 3;

            if (!pnlFormExpanded) // Expandindo
            {
                int remainingWidth = targetWidth - panelEdit.Width;
                int currentStep = Math.Max(minStep, Math.Min(step, remainingWidth / 8));

                panelEdit.Width += currentStep;

                // Atualizar tamanho do formulário para acompanhar o painel
                if (pnlForm != null && !pnlForm.IsDisposed && isFormLoaded)
                {
                    try
                    {
                        pnlForm.Width = panelEdit.Width;
                        pnlForm.Height = panelEdit.Height;
                        pnlForm.Refresh(); // Forçar redesenho
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao redimensionar: {ex.Message}");
                    }
                }

                if (panelEdit.Width >= targetWidth)
                {
                    // Animação de expansão concluída
                    panelEdit.Width = targetWidth;
                    pnlFormExpanded = true;
                    isAnimating = false;
                    timerTransition.Stop();

                    // Agora sim, aplicar Dock.Fill para responsividade
                    if (pnlForm != null && !pnlForm.IsDisposed && isFormLoaded)
                    {
                        try
                        {
                            pnlForm.Dock = DockStyle.Fill;
                            pnlForm.Refresh();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao aplicar Dock.Fill: {ex.Message}");
                        }
                    }
                }
            }
            else // Contraindo
            {
                int currentStep = Math.Max(minStep, panelEdit.Width / 10);
                panelEdit.Width -= currentStep;

                // Atualizar tamanho do formulário durante contração
                if (pnlForm != null && !pnlForm.IsDisposed)
                {
                    try
                    {
                        pnlForm.Dock = DockStyle.None; // Remover Dock para controlar manualmente
                        pnlForm.Width = panelEdit.Width;
                        pnlForm.Height = panelEdit.Height;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao redimensionar na contração: {ex.Message}");
                    }
                }

                if (panelEdit.Width <= 0)
                {
                    // Animação de contração concluída
                    panelEdit.Width = 0;
                    pnlFormExpanded = false;
                    isAnimating = false;
                    timerTransition.Stop();

                    // Limpar formulário após contração
                    CleanupForm();
                }
            }
        }

        // Método público para contrair o painel
        public void ContractPanel()
        {
            if (panelEdit.Width > 0 && !isAnimating)
            {
                isAnimating = true;
                pnlFormExpanded = true; // Definir como true para iniciar contração
                timerTransition.Start();
            }
        }

        // Override do evento Resize para manter responsividade
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Se o painel estiver totalmente expandido, ajustar largura
            if (pnlFormExpanded && !isAnimating && panelEdit.Width > 0)
            {
                targetWidth = this.ClientSize.Width;
                panelEdit.Width = targetWidth;

                // O Dock.Fill já cuida do redimensionamento do formulário
            }
        }

        // Método para tratar fechamento do formulário interno
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerTransition.Stop();
            CleanupForm();
            base.OnFormClosing(e);
        }
    }
}