using Microsoft.Web.WebView2.Core;
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace SistemaNotifica.src.Forms.Template
{
    public partial class TemplateEditForm : Form
    {
        private string currentHtmlContent = "";
        private string tempHtmlFile;
        private Timer updateTimer;
        private bool isMonacoReady = false;
        private bool isPreviewReady = false;
        private bool isInitializing = false;
        private bool isContentLoaded = false; // ✅ Novo flag para controlar se o conteúdo foi carregado

        private bool isLoadingPlaceholders = false;
        private DateTime lastToggleTime = DateTime.MinValue;
        private const int TOGGLE_DELAY_MS = 500; // Delay de 500ms entre toggles

        private TemplateService _templateService;

        private EmailTemplate _currentTemplate;
        // Adicionar evento para comunicação com o form pai
        public event EventHandler<EmailTemplate> TemplateUpdated;
        public event EventHandler CloseRequested;

        // Construtor modificado para receber o template
        public TemplateEditForm(EmailTemplate template = null)
        {
            InitializeComponent();
            _currentTemplate = template;

            this.BackColor = SystemColors.Control;
            this.MinimumSize = new Size(300, 200);
            this.Load += TemplateEditForm_Load;

            listViewPlaceholders.SendToBack();
            listViewPlaceholders.Visible = false;
            _templateService = Program.TemplateService;

            // ✅ Debug para verificar se o template está chegando
            Debug.WriteLine($"TemplateEditForm Construtor - Template: {template?.Id}, ConteudoHtml: {template?.ConteudoHtml?.Length ?? 0} chars");
        }

        private async void TemplateEditForm_Load(object sender, EventArgs e)
        {
            if ( isInitializing ) return;
            isInitializing = true;

            Debug.WriteLine($"TemplateEditForm_Load - Template: {_currentTemplate?.Id}, ConteudoHtml: {_currentTemplate?.ConteudoHtml?.Length ?? 0} chars");

            try
            {
                await InitializeEditor();

                // ✅ Aguardar um pouco mais para garantir que tudo está pronto
                await Task.Delay(500);

                // ✅ Carregar conteúdo do template após tudo estar pronto
                await LoadTemplateContent();
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"Erro na inicialização: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isInitializing = false;
            }
            splitContainerMain.Panel2.Resize += (s, ev) =>
            {
                if ( listViewPlaceholders.Visible )
                {
                    AdjustListViewPosition();
                }
            };
        }

        private void AdjustListViewPosition()
        {
            int margin = 10;
            int listWidth = 500;

            listViewPlaceholders.Location = new Point(
                splitContainerMain.Panel2.Width - listWidth - margin,
                margin
            );

            listViewPlaceholders.Size = new Size(
                listWidth,
                splitContainerMain.Panel2.Height - ( margin * 2 )
            );
        }

        // ✅ Novo método para carregar o conteúdo do template
        private async Task LoadTemplateContent()
        {
            try
            {
                string contentToLoad = GetDefaultHtml(); // Conteúdo padrão

                // Se há um template e ele tem conteúdo HTML, usar esse conteúdo
                if ( _currentTemplate != null && !string.IsNullOrEmpty(_currentTemplate.ConteudoHtml) )
                {
                    contentToLoad = _currentTemplate.ConteudoHtml;
                    Debug.WriteLine($"Carregando conteúdo do template: {contentToLoad.Substring(0, Math.Min(100, contentToLoad.Length))}...");
                }
                else
                {
                    Debug.WriteLine("Carregando conteúdo padrão");
                }

                // Aguardar Monaco estar pronto
                int attempts = 0;
                while ( !isMonacoReady && attempts < 20 )
                {
                    await Task.Delay(100);
                    attempts++;
                }

                if ( isMonacoReady )
                {
                    await SetEditorContent(contentToLoad);
                    isContentLoaded = true;
                    Debug.WriteLine("Conteúdo carregado com sucesso no editor");
                }
                else
                {
                    Debug.WriteLine("Monaco não ficou pronto a tempo");
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao carregar conteúdo do template: {ex.Message}");
            }
        }

        private async Task InitializeEditor()
        {
            try
            {
                // Configurar timer para atualização
                updateTimer = new Timer();
                updateTimer.Interval = 300; // 300ms de delay
                updateTimer.Tick += UpdateTimer_Tick;

                // Arquivo temporário para preview
                tempHtmlFile = Path.Combine(Path.GetTempPath(), "template_preview.html");

                // Configurar eventos dos botões
                ConfigureButtons();

                // Aguardar um pouco antes de inicializar os WebViews
                await Task.Delay(100);

                // Inicializar Monaco Editor e Preview de forma sequencial
                await InitializeMonacoEditor();
                await InitializePreviewWebView();
            }
            catch ( Exception ex )
            {
                throw new Exception($"Erro na inicialização do editor: {ex.Message}", ex);
            }
        }

        private void ConfigureButtons()
        {
            btnSave.Click += btnSave_Click;
            btnBack.Click += btnBack_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnPreview.Click += btnPreview_Click;

            // Habilitar botões depois que o Monaco estiver pronto
            btnPreview.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private async Task InitializeMonacoEditor()
        {
            try
            {
                // Verificar se o WebView2 está disponível
                if ( webView2 == null || webView2.IsDisposed )
                    return;

                // Garantir que o WebView2 está inicializado
                await webView2.EnsureCoreWebView2Async(null);

                // Aguardar um pouco após a inicialização
                await Task.Delay(100);

                // Configurar eventos do WebView2
                webView2.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
                webView2.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

                // Configurar configurações do WebView2
                webView2.CoreWebView2.Settings.IsGeneralAutofillEnabled = false;
                webView2.CoreWebView2.Settings.IsPasswordAutosaveEnabled = false;
                webView2.CoreWebView2.Settings.AreDevToolsEnabled = true;

                // Carregar Monaco Editor
                string monacoHtml = GetMonacoEditorHtml();
                webView2.NavigateToString(monacoHtml);
            }
            catch ( Exception ex )
            {
                throw new Exception($"Erro ao inicializar Monaco Editor: {ex.Message}", ex);
            }
        }

        private async Task InitializePreviewWebView()
        {
            try
            {
                // Verificar se o WebView2 está disponível
                if ( webView2Preview == null || webView2Preview.IsDisposed )
                    return;

                // Garantir que o WebView2 de preview está inicializado
                await webView2Preview.EnsureCoreWebView2Async(null);

                // Aguardar um pouco após a inicialização
                await Task.Delay(100);

                // Configurar eventos do WebView2 de preview
                webView2Preview.CoreWebView2.NavigationCompleted += PreviewWebView2_NavigationCompleted;

                // Configurar configurações do WebView2 Preview
                webView2Preview.CoreWebView2.Settings.IsGeneralAutofillEnabled = false;
                webView2Preview.CoreWebView2.Settings.IsPasswordAutosaveEnabled = false;

                isPreviewReady = true;
                Debug.WriteLine("Preview WebView inicializado");
            }
            catch ( Exception ex )
            {
                throw new Exception($"Erro ao inicializar Preview: {ex.Message}", ex);
            }
        }

        private void PreviewWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if ( e.IsSuccess )
            {
                isPreviewReady = true;
                Debug.WriteLine("Preview WebView carregado com sucesso");
            }
            else
            {
                Debug.WriteLine("Erro no carregamento do Preview");
            }
        }

        private async void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            try
            {
                if ( e.IsSuccess )
                {
                    // Aguardar um pouco para garantir que tudo foi carregado
                    await Task.Delay(300);

                    // Monaco Editor carregado com sucesso
                    isMonacoReady = true;
                    Debug.WriteLine("Monaco Editor carregado com sucesso");

                    // Habilitar botões na thread da UI
                    this.Invoke(() =>
                    {
                        btnPreview.Enabled = true;
                        btnCancelar.Enabled = true;
                    });

                    // ✅ Não definir conteúdo padrão aqui - será feito no LoadTemplateContent
                }
                else
                {
                    Debug.WriteLine("Erro no carregamento do Monaco Editor");
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro no NavigationCompleted: {ex.Message}");
            }
        }

        private void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            try
            {
                string message = e.TryGetWebMessageAsString();

                if ( message.StartsWith("content:") )
                {
                    // Conteúdo do editor foi alterado
                    string newContent = message.Substring(8); // Remove "content:"
                    if ( currentHtmlContent != newContent )
                    {
                        currentHtmlContent = newContent;

                        // ✅ Só atualizar preview se não estiver carregando conteúdo inicial
                        if ( isContentLoaded )
                        {
                            // Atualizar Preview com delay
                            updateTimer.Stop();
                            updateTimer.Start();
                        }
                    }
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao processar mensagem: {ex.Message}");
            }
        }

        private async void UpdateTimer_Tick(object sender, EventArgs e)
        {
            updateTimer.Stop();
            await UpdatePreview(currentHtmlContent);
        }

        private async Task UpdatePreview(string htmlContent)
        {
            try
            {
                if ( !isPreviewReady || string.IsNullOrEmpty(htmlContent) )
                    return;

                if ( webView2Preview == null || webView2Preview.IsDisposed )
                    return;

                // Navegar para o novo conteúdo HTML
                webView2Preview.NavigateToString(htmlContent);
                Debug.WriteLine($"Preview atualizado com {htmlContent.Length} caracteres");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao atualizar preview: {ex.Message}");
            }
        }

        private async Task<string> GetEditorContent()
        {
            if ( !isMonacoReady ) return currentHtmlContent;

            try
            {
                string script = "window.chrome.webview.postMessage('content:' + editor.getValue());";
                await webView2.CoreWebView2.ExecuteScriptAsync(script);

                // Aguardar um pouco para receber a mensagem
                await Task.Delay(100);

                return currentHtmlContent;
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao obter conteúdo do editor: {ex.Message}");
                return currentHtmlContent;
            }
        }

        private async Task SetEditorContent(string content)
        {
            if ( !isMonacoReady )
            {
                Debug.WriteLine("Monaco não está pronto para receber conteúdo");
                return;
            }

            try
            {
                // ✅ Melhor escape de conteúdo para JavaScript
                string escapedContent = EscapeForJavaScript(content);

                string script = $"if (editor) {{ editor.setValue(`{escapedContent}`); }}";
                await webView2.CoreWebView2.ExecuteScriptAsync(script);

                currentHtmlContent = content;
                Debug.WriteLine($"Conteúdo definido no editor: {content.Length} caracteres");

                // Aguardar um pouco e depois atualizar preview
                await Task.Delay(200);
                await UpdatePreview(content);
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao definir conteúdo: {ex.Message}");
            }
        }

        // ✅ Método melhorado para escapar conteúdo JavaScript
        private string EscapeForJavaScript(string content)
        {
            if ( string.IsNullOrEmpty(content) ) return "";

            return content.Replace("\\", "\\\\")
                         .Replace("`", "\\`")
                         .Replace("$", "\\$")
                         .Replace("\n", "\\n")
                         .Replace("\r", "\\r")
                         .Replace("\t", "\\t");
        }

        // Método para salvar alterações no template atual
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string content = await GetEditorContent();

                if ( string.IsNullOrEmpty(content) )
                {
                    MessageBox.Show("Nenhum conteúdo para salvar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if ( _currentTemplate != null )
                {
                    try
                    {
                        SetStatus("Salvando template...");

                        // ✅ Desabilitar botão durante salvamento
                        btnSave.Enabled = false;

                        // ✅ Validar e salvar no servidor via API
                        var updatedTemplate = await _templateService.UpdateTemplateAsync(
                            _currentTemplate.Id,
                            content,
                            _currentTemplate.NomeArquivo // Manter nome original
                        );

                        // ✅ Atualizar template local
                        _currentTemplate.ConteudoHtml = updatedTemplate.ConteudoHtml;
                        _currentTemplate.AtualizadoEm = updatedTemplate.AtualizadoEm;

                        // ✅ Atualizar o conteúdo atual para evitar avisos de "não salvo"
                        currentHtmlContent = content;

                        // ✅ Disparar evento para atualizar a lista no form pai
                        TemplateUpdated?.Invoke(this, _currentTemplate);

                        SetStatus("Template salvo com sucesso");
                        MessageBox.Show("Template salvo com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch ( Exception ex )
                    {
                        Debug.WriteLine($"Erro ao salvar template: {ex}");
                        SetStatus("Erro ao salvar template");

                        // ✅ Usar a classe utilitária para mostrar erro de validação
                        TemplateValidationHelper.ShowTemplateValidationError(this, ex.Message);
                    }
                    finally
                    {
                        btnSave.Enabled = true;
                    }
                }
                else
                {
                    // Salvar como novo arquivo local
                    using ( SaveFileDialog saveDialog = new SaveFileDialog() )
                    {
                        saveDialog.Filter = "Arquivos HTML (*.html)|*.html|Todos os arquivos (*.*)|*.*";
                        saveDialog.DefaultExt = "html";
                        saveDialog.FileName = "template.html";

                        if ( saveDialog.ShowDialog() == DialogResult.OK )
                        {
                            await File.WriteAllTextAsync(saveDialog.FileName, content, Encoding.UTF8);
                            MessageBox.Show("📁 Template salvo com sucesso!", "Salvar",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"❌ Erro ao salvar: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetStatus(string message)
        {
            // Se você tem uma StatusStrip, atualize aqui
            Debug.WriteLine($"[Status] {message}");
        }

        // Modificar o método de voltar para usar evento
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Verificar se há alterações não salvas
            if ( !string.IsNullOrEmpty(currentHtmlContent) &&
                ( _currentTemplate == null || currentHtmlContent != _currentTemplate?.ConteudoHtml ) )
            {
                var result = MessageBox.Show("Existem alterações não salvas. Deseja sair mesmo assim?",
                    "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if ( result == DialogResult.No )
                    return;
            }

            // Disparar evento para o form pai
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja cancelar e descartar todas as alterações?",
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if ( result == DialogResult.Yes )
            {
                // ✅ Restaurar conteúdo original do template ou padrão
                string originalContent = _currentTemplate?.ConteudoHtml ?? GetDefaultHtml();
                await SetEditorContent(originalContent);
            }
        }

        private async void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string content = await GetEditorContent();

                if ( string.IsNullOrEmpty(content) )
                {
                    MessageBox.Show("Nenhum conteúdo para visualizar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Salvar em arquivo temporário e abrir no navegador padrão
                await File.WriteAllTextAsync(tempHtmlFile, content, Encoding.UTF8);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = tempHtmlFile,
                    UseShellExecute = true
                });
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"❌ Erro ao abrir preview: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para obter o template atual (útil para o form pai)
        public EmailTemplate GetCurrentTemplate()
        {
            return _currentTemplate;
        }

        // Método para verificar se há alterações pendentes
        public bool HasUnsavedChanges()
        {
            if ( _currentTemplate == null )
                return !string.IsNullOrEmpty(currentHtmlContent);

            return currentHtmlContent != _currentTemplate.ConteudoHtml;
        }

        private string GetMonacoEditorHtml()
        {
            return @"<!DOCTYPE html>
<html lang='pt-br'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Monaco Editor</title>
    <style>
        body { margin: 0; padding: 0; overflow: hidden; }
        #container { width: 100%; height: 100vh; }
    </style>
</head>
<body>
    <div id='container'></div>
    <script src='https://cdnjs.cloudflare.com/ajax/libs/monaco-editor/0.36.1/min/vs/loader.min.js'></script>
    <script>
        require.config({ 
            paths: { 
                'vs': 'https://cdnjs.cloudflare.com/ajax/libs/monaco-editor/0.36.1/min/vs' 
            } 
        });
        
        require(['vs/editor/editor.main'], function () {
            window.editor = monaco.editor.create(document.getElementById('container'), {
                value: '',
                language: 'html',
                theme: 'vs-dark',
                automaticLayout: true,
                minimap: { enabled: true },
                wordWrap: 'on',
                fontSize: 14,
                lineNumbers: 'on',
                folding: true,
                scrollBeyondLastLine: false
            });

            // Enviar conteúdo quando houver mudanças
            editor.onDidChangeModelContent(function () {
                const content = editor.getValue();
                window.chrome.webview.postMessage('content:' + content);
            });
        });
    </script>
</body>
</html>";
        }

        private string GetDefaultHtml()
        {
            return @"<!DOCTYPE html>
<html lang=""pt-br"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Template de Notificação</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }
        
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            line-height: 1.6;
            color: #333;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
        }
        
        .notification-container {
            background: white;
            border-radius: 15px;
            box-shadow: 0 20px 40px rgba(0,0,0,0.1);
            padding: 2rem;
            max-width: 500px;
            width: 90%;
            text-align: center;
        }
        
        .icon {
            font-size: 3rem;
            margin-bottom: 1rem;
        }
        
        h1 {
            color: #333;
            margin-bottom: 1rem;
            font-size: 1.8rem;
        }
        
        p {
            color: #666;
            margin-bottom: 1.5rem;
            font-size: 1.1rem;
        }
        
        .button {
            background: linear-gradient(45deg, #667eea, #764ba2);
            color: white;
            border: none;
            padding: 12px 30px;
            border-radius: 25px;
            font-size: 1rem;
            cursor: pointer;
            transition: transform 0.2s;
        }
        
        .button:hover {
            transform: translateY(-2px);
        }
    </style>
</head>
<body>
    <div class=""notification-container"">
        <div class=""icon"">🔔</div>
        <h1>Notificação</h1>
        <p>Esta é uma mensagem de exemplo para o template de notificação.</p>
        <button class=""button"">Entendi</button>
    </div>
</body>
</html>";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                // Parar timer
                updateTimer?.Stop();
                updateTimer?.Dispose();

                // Limpar arquivo temporário
                if ( File.Exists(tempHtmlFile) )
                    File.Delete(tempHtmlFile);

                // Limpar WebViews
                if ( webView2?.CoreWebView2 != null )
                {
                    webView2.CoreWebView2.NavigationCompleted -= CoreWebView2_NavigationCompleted;
                    webView2.CoreWebView2.WebMessageReceived -= CoreWebView2_WebMessageReceived;
                }

                if ( webView2Preview?.CoreWebView2 != null )
                {
                    webView2Preview.CoreWebView2.NavigationCompleted -= PreviewWebView2_NavigationCompleted;
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro no fechamento: {ex.Message}");
            }

            base.OnFormClosing(e);
        }

        // Override para garantir que o form seja exibido corretamente
        private async void btnShowLegend_Click(object sender, EventArgs e)
        {
            // Anti-spam: verificar se passou tempo suficiente desde último toggle
            var timeSinceLastToggle = DateTime.Now - lastToggleTime;
            if ( timeSinceLastToggle.TotalMilliseconds < TOGGLE_DELAY_MS )
            {
                Debug.WriteLine($"⏱️ Toggle ignorado - aguarde {TOGGLE_DELAY_MS}ms entre cliques");
                return;
            }

            lastToggleTime = DateTime.Now;

            // Se já está carregando, ignorar
            if ( isLoadingPlaceholders )
            {
                Debug.WriteLine("⏳ Já carregando placeholders...");
                return;
            }

            // Toggle visibility
            if ( listViewPlaceholders.Visible )
            {
                // ✅ Esconder e limpar
                listViewPlaceholders.Visible = false;
                listViewPlaceholders.SendToBack();
                listViewPlaceholders.Items.Clear();
                btnShowLegend.Text = "Mostrar variáveis válidas";
                Debug.WriteLine("🔽 Lista de placeholders ocultada");
            }
            else
            {
                // ✅ Mostrar e carregar
                btnShowLegend.Text = "Esconder variáveis válidas";
                listViewPlaceholders.BringToFront();
                listViewPlaceholders.Visible = true;
                Debug.WriteLine("🔼 Lista de placeholders exibida");

                // Carregar dados se a lista estiver vazia
                if ( listViewPlaceholders.Items.Count == 0 )
                {
                    await LoadPlaceholdersAsync();
                }
            }
        }

       

        private async Task LoadPlaceholdersAsync()
        {
            if ( _templateService == null )
            {
                MessageBox.Show("Serviço de templates não disponível.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                isLoadingPlaceholders = true;
                listViewPlaceholders.Items.Clear();

                // Adicionar item de "Carregando..."
                listViewPlaceholders.Items.Add(new ListViewItem(new[] { "Carregando...", "" }));

                // Buscar da API
                var placeholders = await _templateService.GetPlaceholderDescriptionsAsync();

                // Limpar e popular
                listViewPlaceholders.Items.Clear();

                foreach ( var kvp in placeholders.OrderBy(x => x.Key) )
                {
                    var item = new ListViewItem(new[]
                    {
                kvp.Value,              // Coluna 1: Descrição
                $"{{{{{kvp.Key}}}}}"    // Coluna 2: {{placeholder}}
            });

                    listViewPlaceholders.Items.Add(item);
                }

                Debug.WriteLine($"✅ {placeholders.Count} placeholders carregados");
            }
            catch ( Exception ex )
            {
                listViewPlaceholders.Items.Clear();
                listViewPlaceholders.Items.Add(new ListViewItem(new[]
                {
            "❌ Erro ao carregar",
            ex.Message
        }));

                Debug.WriteLine($"Erro ao carregar placeholders: {ex.Message}");
            }
            finally
            {
                isLoadingPlaceholders = false;
            }
        }
    }
}