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
        private TemplateService _templateService;
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
            //_apiService = new ApiService("http://localhost:3000/");

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panelEdit, new object[] { true });

            _templateService = Program.TemplateService;
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
                //BackColor = Color.FromArgb(248, 249, 250),
                //Padding = new Padding(8)
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
                _templates = await _templateService.GetTemplatesAsync();
                Debug.WriteLine($"Templates carregados:::::::::: {_templates.Count}");

                // Limpa cards existentes
                _flowLayoutTemplates.Controls.Clear();
                _templateCards.Clear();

                // Se não há templates, exibe mensagem
                if ( _templates.Count == 0 )
                {
                    webPreview.DocumentText = "<html><body style='display:flex;align-items:center;justify-content:center;height:100vh;font-family:Segoe UI;color:#6c757d;'><div>Nenhum template disponível</div></body></html>";
                    SetStatus("Nenhum template encontrado");
                    return;
                }

                // Cria cards para cada template
                TemplateCard templatePadraoCard = null;

                foreach ( var template in _templates )
                {
                    Debug.WriteLine($"Criando card para template: {template.Id} - {template.NomeArquivo} - Padrão: {template.EhPadrao}");

                    var card = new TemplateCard
                    {
                        Template = template,
                        Width = _flowLayoutTemplates.ClientSize.Width - 5
                    };

                    card.CardClicked += Card_CardClicked;
                    card.PadraoChanged += Card_PadraoChanged;

                    _templateCards.Add(card);
                    _flowLayoutTemplates.Controls.Add(card);

                    // Guarda referência do template padrão
                    if ( template.EhPadrao )
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

                if ( cardParaSelecionar != null )
                {
                    SelectTemplate(cardParaSelecionar);
                    await ExibirPreview(cardParaSelecionar.Template);
                }
            }
            catch ( Exception ex )
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
                await _templateService.SetTemplatePadraoAsync(template.Id);

                // Atualiza os dados locais
                foreach ( var t in _templates )
                {
                    t.EhPadrao = t.Id == template.Id;
                }

                // Atualiza a exibição dos cards
                foreach ( var card in _templateCards )
                {
                    card.Template = card.Template; // Força refresh
                }

                SetStatus("Template padrão definido com sucesso");

                MessageBox.Show($"Template '{template.NomeArquivo}' definido como padrão!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"Erro ao definir template padrão: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Reverte o checkbox em caso de erro
                var card = sender as TemplateCard;
                if ( card != null )
                {
                    card.Template = card.Template; // Força refresh para reverter
                }
            }
        }

        private void SelectTemplate(TemplateCard selectedCard)
        {
            // Desmarca todos os cards
            foreach ( var card in _templateCards )
            {
                card.IsSelected = false;
            }

            // Marca o card selecionado
            if ( selectedCard != null )
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

                if ( string.IsNullOrEmpty(conteudoHtml) )
                {
                    Debug.WriteLine("Conteúdo HTML vazio, buscando template completo...");
                    var templateCompleto = await _templateService.GetTemplateAsync(template.Id);
                    conteudoHtml = templateCompleto.ConteudoHtml;
                }

                if ( string.IsNullOrEmpty(conteudoHtml) )
                {
                    throw new Exception("Template não possui conteúdo HTML");
                }

                Debug.WriteLine($"Conteúdo HTML obtido: {conteudoHtml.Length} caracteres");

                // Processa o template localmente com dados de teste
                var dadosTeste = GetDadosTeste();
                var htmlProcessado = _templateService.ProcessarTemplate(conteudoHtml, dadosTeste);

                Debug.WriteLine($"HTML processado: {htmlProcessado.Length} caracteres");

                // Exibe no WebBrowser
                webPreview.DocumentText = htmlProcessado;
                SetStatus("Preview carregado com sucesso");
            }
            catch ( Exception ex )
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
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if ( _selectedTemplate == null ) return;

            if ( _selectedTemplate.EhPadrao )
            {
                MessageBox.Show("Não é possível excluir o template padrão!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Tem certeza que deseja excluir o template '{_selectedTemplate.NomeArquivo}'?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if ( result == DialogResult.Yes )
            {
                try
                {
                    SetStatus("Excluindo template...");
                    await _templateService.DeleteTemplateAsync(_selectedTemplate.Id);
                    await CarregarTemplates();
                    SetStatus("Template excluído");
                }
                catch ( Exception ex )
                {
                    MessageBox.Show($"Erro ao excluir template: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSetPadrao_Click(object sender, EventArgs e)
        {
            if ( _selectedTemplate == null ) return;

            try
            {
                SetStatus("Definindo template padrão...");
                await _templateService.SetTemplatePadraoAsync(_selectedTemplate.Id);
                await CarregarTemplates();
                MessageBox.Show($"Template '{_selectedTemplate.NomeArquivo}' definido como padrão!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"Erro ao definir template padrão: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnPreview_Click(object sender, EventArgs e)
        {
            if ( _selectedTemplate != null )
            {
                await ExibirPreview(_selectedTemplate);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            var btnRefresh = sender as Button;

            try
            {
                // Desabilitar o botão durante o refresh
                if ( btnRefresh != null )
                {
                    btnRefresh.Enabled = false;
                    btnRefresh.Text = "Atualizando..."; // Se o botão tiver texto
                }
                SetStatus("Atualizando lista de templates...");
                // Recarregar templates da API
                await CarregarTemplates();
                if ( btnRefresh != null )
                {
                    btnRefresh.Text = "✓ Atualizado"; // Feedback temporário
                    await Task.Delay(1000); // Mostra por 1 segundo
                    btnRefresh.Text = "Atualizar"; // Volta ao texto original
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"❌ Erro ao atualizar templates: {ex.Message}");
                MessageBox.Show($"Erro ao atualizar templates: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatus("Erro ao atualizar templates");
            }
            finally
            {
                // Reabilitar o botão
                if ( btnRefresh != null )
                {
                    btnRefresh.Enabled = true;
                }
            }
        }

        // Upload permanece igual ao código original
        private async void btnUpload_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("CLICK no botão upload de template...");
            using ( var openFileDialog = new OpenFileDialog() )
            {
                openFileDialog.Filter = "Arquivos HTML (*.html)|*.html|Todos os arquivos (*.*)|*.*";
                openFileDialog.Title = "Selecionar Template HTML";
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;

                if ( openFileDialog.ShowDialog() == DialogResult.OK )
                {
                    string caminhoArquivoSelecionado = openFileDialog.FileName;
                    Debug.WriteLine($"Arquivo selecionado: {caminhoArquivoSelecionado}");

                    try
                    {
                        var fileInfo = new FileInfo(caminhoArquivoSelecionado);

                        if ( !fileInfo.Exists )
                        {
                            MessageBox.Show(
                                "O arquivo selecionado não foi encontrado no caminho especificado.",
                                "Arquivo Não Encontrado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }

                        byte[] fileBytes;
                        try
                        {
                            fileBytes = await File.ReadAllBytesAsync(caminhoArquivoSelecionado);
                        }
                        catch ( UnauthorizedAccessException )
                        {
                            MessageBox.Show(
                                "Sem permissão para ler o arquivo selecionado.",
                                "Erro de Permissão",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        catch ( IOException ex )
                        {
                            MessageBox.Show(
                                $"Erro ao acessar o arquivo: {ex.Message}",
                                "Erro de Acesso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }

                        if ( fileBytes.Length == 0 )
                        {
                            MessageBox.Show(
                                "O arquivo selecionado está vazio.",
                                "Arquivo Vazio",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }

                        const long tamanhoMaximo = 20 * 1024 * 1024;
                        if ( fileBytes.Length > tamanhoMaximo )
                        {
                            MessageBox.Show(
                                $"Arquivo muito grande. Tamanho máximo: 20MB",
                                "Arquivo Muito Grande",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }

                        var nomeArquivo = Path.GetFileName(caminhoArquivoSelecionado);
                        var tamanhoMB = Math.Round(fileBytes.Length / ( 1024.0 * 1024.0 ), 2);

                        var confirmacao = MessageBox.Show(
                            $"Deseja fazer upload do template?\n\n" +
                            $"Arquivo: {nomeArquivo}\n" +
                            $"Tamanho: {tamanhoMB} MB",
                            "Confirmar Upload",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if ( confirmacao == DialogResult.Yes )
                        {
                            SetStatus("Enviando template...");

                            var btnUpload = sender as Button;
                            if ( btnUpload != null )
                            {
                                btnUpload.Enabled = false;
                            }

                            try
                            {
                                var template = await _templateService.UploadTemplateAsync(fileBytes, nomeArquivo);

                                MessageBox.Show(
                                    $"Template '{template.NomeArquivo}' enviado com sucesso!",
                                    "Sucesso no Upload",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );

                                SetStatus("Upload concluído com sucesso.");
                                await CarregarTemplates();
                            }
                            catch ( Exception ex )
                            {
                                Debug.WriteLine($"ERRO NO UPLOAD: {ex}");

                                // ✅ Exibir erro formatado em modal com scroll
                                TemplateValidationHelper.ShowTemplateValidationError(this, ex.Message);

                                SetStatus("Erro no upload.");
                            }
                            finally
                            {
                                if ( btnUpload != null )
                                {
                                    btnUpload.Enabled = true;
                                }
                            }
                        }
                    }
                    catch ( Exception ex )
                    {
                        MessageBox.Show(
                            $"Ocorreu um erro inesperado: {ex.Message}",
                            "Erro Inesperado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        Debug.WriteLine($"ERRO INESPERADO: {ex}");
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
            //_apiService?.Dispose();
            base.OnFormClosed(e);
        }

        private void webPreview_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }



        //EDIT --> panelEdit
        private async void btnEdit_ClickAsync(object sender, EventArgs e)
        {
            if ( isAnimating ) return;

            if ( pnlFormExpanded && pnlForm != null )
            {
                ContractPanel();
                return;
            }

            if ( _selectedTemplate == null )
            {
                MessageBox.Show("Selecione um template para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                panelEdit.BringToFront();
                timerTransition.Stop();

                CleanupForm();

                bool formCreated = await CreateAndConfigureFormAsync();
                if ( !formCreated ) return;

                // ✅ AGUARDAR SIDEBAR CONTRAIR COMPLETAMENTE
                await WaitForSidebarContraction();

                // ✅ ANIMAR COM A LARGURA CORRETA
                await AnimateExpansionAsync();
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"❌ Erro: {ex.Message}");
                MessageBox.Show($"Erro ao abrir editor: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanupForm();
                isAnimating = false;
            }
        }
        private async Task WaitForSidebarContraction()
        {
            // Buscar o FormOrigin (form pai)
            var parentForm = this.ParentForm as FormOrigin;

            if ( parentForm != null )
            {
                // Verificar se a sidebar está expandida através de reflection ou propriedade pública
                var sidebarField = parentForm.GetType().GetField("sidebarMenu",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if ( sidebarField != null )
                {
                    var sidebar = sidebarField.GetValue(parentForm) as Control;

                    if ( sidebar != null && sidebar.Width > 50 ) // Se sidebar está expandida
                    {
                        Debug.WriteLine("⏳ Aguardando sidebar contrair...");

                        // Aguardar até a sidebar contrair (máximo 500ms)
                        int attempts = 0;
                        while ( sidebar.Width > 50 && attempts < 50 ) // 50 * 10ms = 500ms
                        {
                            await Task.Delay(10);
                            attempts++;
                        }

                        // Aguardar mais um pouco para garantir estabilidade
                        await Task.Delay(50);

                        Debug.WriteLine($"✅ Sidebar contraída para {sidebar.Width}px");
                    }
                }
            }

            // Aguardar um frame extra para garantir que o layout foi atualizado
            await Task.Delay(16); // ~1 frame a 60fps
        }

        private async Task AnimateExpansionAsync()
        {
            isAnimating = true;
            pnlFormExpanded = false;

            int duration = 300; // 300ms - rápido mas suave
            int fps = 60;
            int frames = ( duration * fps ) / 1000;
            int delayPerFrame = duration / frames;

            panelEdit.Width = 0;
            panelEdit.Visible = true;

            // ✅ Suspender layout durante animação
            panelEdit.SuspendLayout();
            if ( pnlForm != null ) pnlForm.SuspendLayout();

            try
            {
                for ( int i = 0; i <= frames; i++ )
                {
                    // ✅ RECALCULAR largura alvo a cada frame (em caso de resize/sidebar)
                    int currentTargetWidth = this.ClientSize.Width;

                    // Interpolação suave (easing out)
                    float progress = ( float ) i / frames;
                    float eased = 1f - ( float ) Math.Pow(1 - progress, 3); // Cubic ease-out

                    int newWidth = ( int ) ( currentTargetWidth * eased );
                    panelEdit.Width = newWidth;

                    if ( pnlForm != null && !pnlForm.IsDisposed && isFormLoaded )
                    {
                        pnlForm.Width = newWidth;
                        pnlForm.Height = panelEdit.Height;
                    }

                    await Task.Delay(delayPerFrame);
                }

                // ✅ Garantir largura final exata (recalcular uma última vez)
                int finalWidth = this.ClientSize.Width;
                panelEdit.Width = finalWidth;

                if ( pnlForm != null && !pnlForm.IsDisposed && isFormLoaded )
                {
                    pnlForm.Dock = DockStyle.Fill; // Agora sim aplicar Dock
                }
            }
            finally
            {
                panelEdit.ResumeLayout(true);
                if ( pnlForm != null && !pnlForm.IsDisposed ) pnlForm.ResumeLayout(true);

                pnlFormExpanded = true;
                isAnimating = false;
                Debug.WriteLine("✅ Animação concluída");
            }
        }

        private void CleanupForm()
        {
            if ( pnlForm != null && !pnlForm.IsDisposed )
            {
                pnlForm.Close();
                pnlForm.Dispose();
                pnlForm = null;
            }
            panelEdit.Controls.Clear();
            isFormLoaded = false;
        }

        private async Task<bool> CreateAndConfigureFormAsync()
        {
            try
            {
                SetStatus("Preparando template para edição...");
                Debug.WriteLine($"📋 Template selecionado: ID={_selectedTemplate.Id}, Nome={_selectedTemplate.NomeArquivo}");

                // ✅ Garantir que temos o template completo
                EmailTemplate templateCompleto = _selectedTemplate;

                // ✅ Se o template não tem conteúdo HTML, buscar do servidor
                if ( string.IsNullOrEmpty(_selectedTemplate.ConteudoHtml) )
                {
                    SetStatus("Carregando template completo do servidor...");
                    Debug.WriteLine("🌐 Buscando template do servidor...");

                    try
                    {
                        templateCompleto = await _templateService.GetTemplateAsync(_selectedTemplate.Id);
                        Debug.WriteLine($"✅ Template carregado: {templateCompleto?.ConteudoHtml?.Length ?? 0} chars");
                    }
                    catch ( Exception ex )
                    {
                        Debug.WriteLine($"❌ Erro ao carregar template: {ex.Message}");
                        MessageBox.Show($"Erro ao carregar template: {ex.Message}", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    Debug.WriteLine($"✅ Usando template em memória: {templateCompleto.ConteudoHtml.Length} chars");
                }

                // ✅ Verificar se conseguimos obter o template
                if ( templateCompleto == null || string.IsNullOrEmpty(templateCompleto.ConteudoHtml) )
                {
                    Debug.WriteLine("❌ Template vazio ou nulo");
                    MessageBox.Show("Não foi possível carregar o template ou ele está vazio.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                SetStatus("Criando editor de template...");
                Debug.WriteLine("🏗️ Criando TemplateEditForm...");

                // ✅ Criar o form de edição com o template completo
                _currentEditForm = new TemplateEditForm(templateCompleto)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.None,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right,
                    WindowState = FormWindowState.Normal,
                    Location = new Point(0, 0),
                    Size = new Size(0, panelEdit.Height) // Começar com largura 0 para a animação
                };

                Debug.WriteLine($"✅ TemplateEditForm criado com template ID: {templateCompleto.Id}");

                // ✅ Configurar eventos
                _currentEditForm.CloseRequested += EditForm_CloseRequested;
                _currentEditForm.TemplateUpdated += EditForm_TemplateUpdated;
                Debug.WriteLine("✅ Eventos configurados");

                // ✅ Limpar o panel antes de adicionar o novo form
                panelEdit.Controls.Clear();

                // ✅ Adicionar o form ao panel
                panelEdit.Controls.Add(_currentEditForm);
                Debug.WriteLine("✅ Form adicionado ao panel");

                // ✅ Aguardar um pouco para garantir que foi adicionado
                await Task.Delay(100);

                // ✅ Mostrar o form
                _currentEditForm.Show();
                _currentEditForm.BringToFront();
                Debug.WriteLine("✅ Form exibido");

                // ✅ Definir referência
                pnlForm = _currentEditForm;

                // ✅ Aguardar um pouco mais para garantir que tudo está carregado
                await Task.Delay(200);

                // ✅ Marcar como carregado
                isFormLoaded = true;
                Debug.WriteLine("✅ isFormLoaded = true");

                SetStatus("Editor de template carregado com sucesso");
                return true;
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"❌ Erro em CreateAndConfigureFormAsync: {ex.Message}");
                Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                MessageBox.Show($"Erro ao carregar template para edição: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatus("Erro ao carregar editor");
                return false;
            }
        }

        private void EditForm_CloseRequested(object sender, EventArgs e)
        {
            // Fechar o painel de edição
            ContractPanel(force: true);
        }

        private async void EditForm_TemplateUpdated(object sender, EmailTemplate updatedTemplate)
        {
            try
            {
                SetStatus("Atualizando lista de templates...");

                // Atualizar template na lista local
                var index = _templates.FindIndex(t => t.Id == updatedTemplate.Id);
                if ( index >= 0 )
                {
                    _templates[index] = updatedTemplate;
                }

                // Atualizar card correspondente
                var card = _templateCards.FirstOrDefault(c => c.Template.Id == updatedTemplate.Id);
                if ( card != null )
                {
                    card.Template = updatedTemplate;
                }

                // Atualizar preview se este template estiver selecionado
                if ( _selectedTemplate?.Id == updatedTemplate.Id )
                {
                    _selectedTemplate = updatedTemplate;
                    await ExibirPreview(updatedTemplate);
                }

                SetStatus("Template atualizado com sucesso");
            }
            catch ( Exception ex )
            {
                SetStatus($"Erro ao atualizar template: {ex.Message}");
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

        private async Task AnimateContractionAsync()
        {
            isAnimating = true;

            int duration = 250; // Contração mais rápida
            int fps = 60;
            int frames = ( duration * fps ) / 1000;
            int delayPerFrame = duration / frames;

            int startWidth = panelEdit.Width;

            panelEdit.SuspendLayout();
            if ( pnlForm != null && !pnlForm.IsDisposed )
            {
                pnlForm.Dock = DockStyle.None;
                pnlForm.SuspendLayout();
            }

            try
            {
                for ( int i = frames; i >= 0; i-- )
                {
                    float progress = ( float ) i / frames;
                    float eased = ( float ) Math.Pow(progress, 2); // Quadratic ease-in

                    int newWidth = ( int ) ( startWidth * eased );
                    panelEdit.Width = newWidth;

                    if ( pnlForm != null && !pnlForm.IsDisposed )
                    {
                        pnlForm.Width = newWidth;
                    }

                    await Task.Delay(delayPerFrame);
                }

                panelEdit.Width = 0;
                panelEdit.Visible = false;
            }
            finally
            {
                panelEdit.ResumeLayout(true);
                if ( pnlForm != null && !pnlForm.IsDisposed ) pnlForm.ResumeLayout(true);

                CleanupForm();
                pnlFormExpanded = false;
                isAnimating = false;
                SetStatus("Editor fechado");
                Debug.WriteLine("✅ Contração concluída");
            }
        }

        // Método para fechar o painel de edição
        private async void ContractPanel(bool force = false)
        {
            if ( !pnlFormExpanded || pnlForm == null ) return;

            try
            {
                if ( !force )
                {
                    var editForm = pnlForm as TemplateEditForm;
                    if ( editForm?.HasUnsavedChanges() == true )
                    {
                        var result = MessageBox.Show(
                            "Existem alterações não salvas. Deseja sair mesmo assim?",
                            "Confirmação",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if ( result == DialogResult.No ) return;
                    }
                }

                await AnimateContractionAsync();
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"Erro ao fechar editor: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método utilitário para verificar se o template precisa ser recarregado
        private bool NeedsFullTemplateData(EmailTemplate template)
        {
            return string.IsNullOrEmpty(template.ConteudoHtml) ||
                   template.ConteudoHtml.Length < 100; // Exemplo de critério
        }

        // Método para pré-carregar dados do template se necessário
        private async Task<EmailTemplate> EnsureTemplateComplete(EmailTemplate template)
        {
            if ( NeedsFullTemplateData(template) )
            {
                return await _templateService.GetTemplateAsync(template.Id);
            }
            return template;
        }

        // Override do evento Resize para manter responsividade
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Se o painel estiver totalmente expandido, ajustar largura
            if ( pnlFormExpanded && !isAnimating && panelEdit.Width > 0 )
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

        private void btnShowLegend_Click(object sender, EventArgs e)
        {
            //sobrepor o panel ou list de variáveis em cima de pnlPreviewTemplate e label1
        }

        
    }
}