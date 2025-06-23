using Microsoft.Web.WebView2.Core;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using Timer = System.Windows.Forms.Timer;
using SistemaNotifica.src.Models;

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
        }

        private async void TemplateEditForm_Load(object sender, EventArgs e)
        {
            if (isInitializing) return;
            isInitializing = true;

            try
            {
                await InitializeEditor();

                // Se há um template, carregá-lo no editor
                if (_currentTemplate != null && !string.IsNullOrEmpty(_currentTemplate.ConteudoHtml))
                {
                    await SetEditorContent(_currentTemplate.ConteudoHtml);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na inicialização: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isInitializing = false;
            }
        }

        private async Task InitializeEditor()
        {
            try
            {
                // Configurar timer para atualização
                updateTimer = new Timer();
                updateTimer.Interval = 500; // 500ms de delay
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
            catch (Exception ex)
            {
                throw new Exception($"Erro na inicialização do editor: {ex.Message}", ex);
            }
        }

        private void ConfigureButtons()
        {
            btnSave.Click += BtnSave_Click;
            btnBack.Click += BtnBack_Click;
            btnCacelar.Click += BtnCancelar_Click;
            btnPreview.Click += BtnPreview_Click;

            // Habilitar botões depois que o Monaco estiver pronto
            btnPreview.Enabled = false;
            btnCacelar.Enabled = false;
        }

        private async Task InitializeMonacoEditor()
        {
            try
            {
                // Verificar se o WebView2 está disponível
                if (webView2 == null || webView2.IsDisposed)
                    return;

                // Garantir que o WebView2 está inicializado
                await webView2.EnsureCoreWebView2Async(null);

                // Aguardar um pouco após a inicialização
                await Task.Delay(50);

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
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inicializar Monaco Editor: {ex.Message}", ex);
            }
        }

        private async Task InitializePreviewWebView()
        {
            try
            {
                // Verificar se o WebView2 está disponível
                if (webView2Preview == null || webView2Preview.IsDisposed)
                    return;

                // Garantir que o WebView2 de preview está inicializado
                await webView2Preview.EnsureCoreWebView2Async(null);

                // Aguardar um pouco após a inicialização
                await Task.Delay(50);

                // Configurar eventos do WebView2 de preview
                webView2Preview.CoreWebView2.NavigationCompleted += PreviewWebView2_NavigationCompleted;

                // Configurar configurações do WebView2 Preview
                webView2Preview.CoreWebView2.Settings.IsGeneralAutofillEnabled = false;
                webView2Preview.CoreWebView2.Settings.IsPasswordAutosaveEnabled = false;

                isPreviewReady = true;

                // Carregar conteúdo inicial
                await UpdatePreview(GetDefaultHtml());
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inicializar Preview: {ex.Message}", ex);
            }
        }

        private void PreviewWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                isPreviewReady = true;
            }
            else
            {
                Console.WriteLine("Erro no carregamento do Preview");
            }
        }

        private async void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            try
            {
                if (e.IsSuccess)
                {
                    // Aguardar um pouco para garantir que tudo foi carregado
                    await Task.Delay(200);

                    // Monaco Editor carregado com sucesso
                    isMonacoReady = true;

                    // Habilitar botões na thread da UI
                    this.Invoke(() =>
                    {
                        btnPreview.Enabled = true;
                        btnCacelar.Enabled = true;
                    });

                    // Definir conteúdo inicial
                    await SetEditorContent(GetDefaultHtml());
                }
                else
                {
                    Console.WriteLine("Erro no carregamento do Monaco Editor");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no NavigationCompleted: {ex.Message}");
            }
        }

        private void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            try
            {
                string message = e.TryGetWebMessageAsString();

                if (message.StartsWith("content:"))
                {
                    // Conteúdo do editor foi alterado
                    string newContent = message.Substring(8); // Remove "content:"
                    if (currentHtmlContent != newContent)
                    {
                        currentHtmlContent = newContent;

                        // Atualizar Preview com delay
                        updateTimer.Stop();
                        updateTimer.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar mensagem: {ex.Message}");
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
                if (!isPreviewReady || string.IsNullOrEmpty(htmlContent))
                    return;

                if (webView2Preview == null || webView2Preview.IsDisposed)
                    return;

                // Navegar para o novo conteúdo HTML
                webView2Preview.NavigateToString(htmlContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar preview: {ex.Message}");
            }
        }

        private async Task<string> GetEditorContent()
        {
            if (!isMonacoReady) return "";

            try
            {
                string script = "window.chrome.webview.postMessage('content:' + editor.getValue());";
                await webView2.CoreWebView2.ExecuteScriptAsync(script);

                // Aguardar um pouco para receber a mensagem
                await Task.Delay(100);

                return currentHtmlContent;
            }
            catch
            {
                return currentHtmlContent;
            }
        }

        private async Task SetEditorContent(string content)
        {
            if (!isMonacoReady) return;

            try
            {
                // Escapar o conteúdo para JavaScript
                string escapedContent = content.Replace("\\", "\\\\")
                                             .Replace("'", "\\'")
                                             .Replace("\n", "\\n")
                                             .Replace("\r", "\\r");

                string script = $"if (editor) {{ editor.setValue('{escapedContent}'); }}";
                await webView2.CoreWebView2.ExecuteScriptAsync(script);

                currentHtmlContent = content;

                // Atualizar preview também
                await UpdatePreview(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao definir conteúdo: {ex.Message}");
            }
        }

        // Método para salvar alterações no template atual
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string content = await GetEditorContent();

                if (string.IsNullOrEmpty(content))
                {
                    MessageBox.Show("Nenhum conteúdo para salvar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_currentTemplate != null)
                {
                    // Salvar no servidor via API
                    _currentTemplate.ConteudoHtml = content;

                    // Aqui você chamaria seu ApiService para salvar
                    // await _apiService.UpdateTemplateAsync(_currentTemplate);

                    // Disparar evento para atualizar a lista no form pai
                    TemplateUpdated?.Invoke(this, _currentTemplate);

                    MessageBox.Show("Template salvo com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Salvar como novo arquivo
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "Arquivos HTML (*.html)|*.html|Todos os arquivos (*.*)|*.*";
                        saveDialog.DefaultExt = "html";
                        saveDialog.FileName = "template.html";

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            await File.WriteAllTextAsync(saveDialog.FileName, content, Encoding.UTF8);
                            MessageBox.Show("📁 Template salvo com sucesso!", "Salvar",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erro ao salvar: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modificar o método de voltar para usar evento
        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Verificar se há alterações não salvas
            if (!string.IsNullOrEmpty(currentHtmlContent) &&
                (_currentTemplate == null || currentHtmlContent != _currentTemplate.ConteudoHtml))
            {
                var result = MessageBox.Show("Existem alterações não salvas. Deseja sair mesmo assim?",
                    "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;
            }

            // Disparar evento para o form pai
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        private async void BtnCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja cancelar todas as alterações?",
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await SetEditorContent(GetDefaultHtml());
            }
        }

        private async void BtnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string content = await GetEditorContent();

                if (string.IsNullOrEmpty(content))
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
            catch (Exception ex)
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
            if (_currentTemplate == null)
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
                if (File.Exists(tempHtmlFile))
                    File.Delete(tempHtmlFile);

                // Limpar WebViews
                if (webView2?.CoreWebView2 != null)
                {
                    webView2.CoreWebView2.NavigationCompleted -= CoreWebView2_NavigationCompleted;
                    webView2.CoreWebView2.WebMessageReceived -= CoreWebView2_WebMessageReceived;
                }

                if (webView2Preview?.CoreWebView2 != null)
                {
                    webView2Preview.CoreWebView2.NavigationCompleted -= PreviewWebView2_NavigationCompleted;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no fechamento: {ex.Message}");
            }

            base.OnFormClosing(e);
        }

        // Override para garantir que o form seja exibido corretamente
        protected override void SetVisibleCore(bool value)
        {
            if (this.WindowState == FormWindowState.Minimized)
                value = false;

            base.SetVisibleCore(value);
        }
    }
}