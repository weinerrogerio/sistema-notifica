using Microsoft.Web.WebView2.Core;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
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

        public TemplateEditForm()
        {
            InitializeComponent();
            InitializeEditor();
        }

        private void InitializeEditor()
        {
            // Configurar timer para atualização
            updateTimer = new Timer();
            updateTimer.Interval = 500; // 500ms de delay
            updateTimer.Tick += UpdateTimer_Tick;

            // Arquivo temporário para preview
            tempHtmlFile = Path.Combine(Path.GetTempPath(), "template_preview.html");

            // Configurar eventos dos botões
            ConfigureButtons();

            // Inicializar Monaco Editor
            InitializeMonacoEditor();

            // Inicializar Preview WebView
            InitializePreviewWebView();
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

        private async void InitializeMonacoEditor()
        {
            try
            {
                // Garantir que o WebView2 está inicializado
                await webView2.EnsureCoreWebView2Async(null);

                // Configurar eventos do WebView2
                webView2.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
                webView2.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

                // Carregar Monaco Editor
                string monacoHtml = GetMonacoEditorHtml();
                webView2.NavigateToString(monacoHtml);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar Monaco Editor: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void InitializePreviewWebView()
        {
            try
            {
                // Garantir que o WebView2 de preview está inicializado
                await webView2Preview.EnsureCoreWebView2Async(null);

                // Configurar eventos do WebView2 de preview
                webView2Preview.CoreWebView2.NavigationCompleted += PreviewWebView2_NavigationCompleted;

                isPreviewReady = true;

                // Carregar conteúdo inicial
                await UpdatePreview(GetDefaultHtml());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar Preview: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreviewWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                isPreviewReady = true;
            }
        }

        private async void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                // Monaco Editor carregado com sucesso
                isMonacoReady = true;
                btnPreview.Enabled = true;
                btnCacelar.Enabled = true;

                // Definir conteúdo inicial
                await SetEditorContent(GetDefaultHtml());
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

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Obter conteúdo atual do editor
                string content = await GetEditorContent();

                if (string.IsNullOrEmpty(content))
                {
                    MessageBox.Show("Nenhum conteúdo para salvar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erro ao salvar: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Verificar se há alterações não salvas
            if (!string.IsNullOrEmpty(currentHtmlContent))
            {
                var result = MessageBox.Show("Existem alterações não salvas. Deseja sair mesmo assim?",
                    "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;
            }

            this.Close();
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

        private string GetMonacoEditorHtml()
        {
            return @"<!DOCTYPE html>
<html lang='pt-br'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Monaco Editor</title>
    <style>
        body {
            margin: 0;
            padding: 0;
            overflow: hidden;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }
        
        #container {
            width: 100vw;
            height: 100vh;
            position: relative;
        }
        
        #editor {
            width: 100%;
            height: 100%;
        }
        
        .loading {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background: #1e1e1e;
            color: #fff;
            font-size: 18px;
        }
    </style>
</head>
<body>
    <div id='container'>
        <div class='loading' id='loading'>
            🚀 Carregando Monaco Editor...
        </div>
        <div id='editor' style='display: none;'></div>
    </div>

    <script src='https://cdnjs.cloudflare.com/ajax/libs/monaco-editor/0.44.0/min/vs/loader.min.js'></script>
    <script>
        let editor;
        let isInitialized = false;
        
        require.config({ 
            paths: { 
                vs: 'https://cdnjs.cloudflare.com/ajax/libs/monaco-editor/0.44.0/min/vs' 
            } 
        });
        
        require(['vs/editor/editor.main'], function () {
            // Ocultar loading
            document.getElementById('loading').style.display = 'none';
            document.getElementById('editor').style.display = 'block';
            
            editor = monaco.editor.create(document.getElementById('editor'), {
                value: '',
                language: 'html',
                theme: 'vs-dark',
                automaticLayout: true,
                fontSize: 14,
                fontFamily: 'Consolas, Monaco, monospace',
                minimap: { 
                    enabled: true,
                    side: 'right'
                },
                wordWrap: 'on',
                formatOnPaste: true,
                formatOnType: true,
                autoIndent: 'full',
                scrollBeyondLastLine: false,
                renderWhitespace: 'selection',
                smoothScrolling: true,
                cursorBlinking: 'smooth',
                cursorSmoothCaretAnimation: true,
                dragAndDrop: true,
                copyWithSyntaxHighlighting: true,
                colorDecorators: true,
                codeLens: true,
                folding: true,
                foldingHighlight: true,
                showFoldingControls: 'always',
                unfoldOnClickAfterEndOfLine: true,
                disableLayerHinting: false,
                enableSplitViewResizing: false,
                hideCursorInOverviewRuler: false,
                highlightActiveIndentGuide: true,
                bracketPairColorization: {
                    enabled: true
                }
            });
            
            isInitialized = true;
            
            // Enviar alterações para o C# em tempo real
            let changeTimeout;
            editor.onDidChangeModelContent(() => {
                clearTimeout(changeTimeout);
                changeTimeout = setTimeout(() => {
                    if (window.chrome && window.chrome.webview) {
                        window.chrome.webview.postMessage('content:' + editor.getValue());
                    }
                }, 150); // Reduzido para 150ms para preview mais responsivo
            });
            
            // Comandos adicionais
            editor.addCommand(monaco.KeyMod.CtrlCmd | monaco.KeyCode.KeyS, function() {
                // Ctrl+S para salvar
                if (window.chrome && window.chrome.webview) {
                    window.chrome.webview.postMessage('save:' + editor.getValue());
                }
            });
            
            // Melhorar experiência do usuário
            editor.focus();
        });
        
        // Função para definir conteúdo externamente
        function setContent(content) {
            if (isInitialized && editor) {
                editor.setValue(content);
            }
        }
        
        // Função para obter conteúdo
        function getContent() {
            if (isInitialized && editor) {
                return editor.getValue();
            }
            return '';
        }
        
        // Função para formatar código
        function formatCode() {
            if (isInitialized && editor) {
                editor.getAction('editor.action.formatDocument').run();
            }
        }
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
            padding: 20px;
        }
        
        .container {
            background: white;
            max-width: 600px;
            margin: 0 auto;
            padding: 40px;
            border-radius: 15px;
            box-shadow: 0 10px 30px rgba(0,0,0,0.2);
        }
        
        .header {
            text-align: center;
            margin-bottom: 30px;
            padding-bottom: 20px;
            border-bottom: 2px solid #f0f0f0;
        }
        
        .header h1 {
            color: #4a5568;
            margin-bottom: 10px;
        }
        
        .content {
            margin: 20px 0;
        }
        
        .footer {
            margin-top: 30px;
            padding-top: 20px;
            border-top: 1px solid #e0e0e0;
            text-align: center;
            color: #666;
            font-size: 14px;
        }
        
        .btn {
            background: #667eea;
            color: white;
            padding: 12px 24px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            font-size: 16px;
            text-decoration: none;
            display: inline-block;
            transition: all 0.3s ease;
        }
        
        .btn:hover {
            background: #5a67d8;
            transform: translateY(-2px);
        }
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""header"">
            <h1>🔔 Notificação do Sistema</h1>
            <p>Template editável para notificações</p>
        </div>
        
        <div class=""content"">
            <h2>Olá, {{NOME_USUARIO}}!</h2>
            <p>Esta é uma notificação do sistema <strong>{{NOME_SISTEMA}}</strong>.</p>
            
            <p>Detalhes da notificação:</p>
            <ul>
                <li>Data: {{DATA_ATUAL}}</li>
                <li>Tipo: {{TIPO_NOTIFICACAO}}</li>
                <li>Status: {{STATUS}}</li>
            </ul>
            
            <p>Para mais informações, clique no botão abaixo:</p>
            <a href=""{{LINK_DETALHES}}"" class=""btn"">Ver Detalhes</a>
        </div>
        
        <div class=""footer"">
            <p>Este é um email automático. Não responda a esta mensagem.</p>
            <p>&copy; 2025 {{NOME_EMPRESA}}. Todos os direitos reservados.</p>
        </div>
    </div>
</body>
</html>";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Limpar arquivo temporário
            try
            {
                if (File.Exists(tempHtmlFile))
                    File.Delete(tempHtmlFile);
            }
            catch { }

            updateTimer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}