namespace SistemaNotifica.src.Forms.Template
{
    partial class TemplateEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            metroPanelTop = new ReaLTaiizor.Controls.MetroPanel();
            btnSave = new Button();
            btnBack = new Button();
            btnCacelar = new Button();
            btnPreview = new Button();
            splitContainerMain = new SplitContainer();
            webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            webView2Preview = new Microsoft.Web.WebView2.WinForms.WebView2();
            metroPanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView2Preview).BeginInit();
            SuspendLayout();
            // 
            // metroPanelTop
            // 
            metroPanelTop.BackgroundColor = Color.White;
            metroPanelTop.BorderColor = Color.FromArgb(150, 150, 150);
            metroPanelTop.BorderThickness = 1;
            metroPanelTop.Controls.Add(btnSave);
            metroPanelTop.Controls.Add(btnBack);
            metroPanelTop.Controls.Add(btnCacelar);
            metroPanelTop.Controls.Add(btnPreview);
            metroPanelTop.Dock = DockStyle.Top;
            metroPanelTop.IsDerivedStyle = true;
            metroPanelTop.Location = new Point(0, 0);
            metroPanelTop.Name = "metroPanelTop";
            metroPanelTop.Size = new Size(831, 35);
            metroPanelTop.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroPanelTop.StyleManager = null;
            metroPanelTop.TabIndex = 1;
            metroPanelTop.ThemeAuthor = "Taiizor";
            metroPanelTop.ThemeName = "MetroLight";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 50, 60);
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 80, 90);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(101, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 27);
            btnSave.TabIndex = 5;
            btnSave.Text = "📁 Salvar";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(96, 125, 139);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(6, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(90, 27);
            btnBack.TabIndex = 9;
            btnBack.Text = "🔄 Voltar";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;
            // 
            // btnCacelar
            // 
            btnCacelar.BackColor = Color.FromArgb(244, 67, 54);
            btnCacelar.Enabled = false;
            btnCacelar.FlatStyle = FlatStyle.Flat;
            btnCacelar.ForeColor = Color.White;
            btnCacelar.Location = new Point(236, 4);
            btnCacelar.Name = "btnCacelar";
            btnCacelar.Size = new Size(80, 27);
            btnCacelar.TabIndex = 6;
            btnCacelar.Text = "🗑️ Cancelar";
            btnCacelar.UseVisualStyleBackColor = false;
            // 
            // btnPreview
            // 
            btnPreview.BackColor = Color.FromArgb(33, 150, 243);
            btnPreview.Enabled = false;
            btnPreview.FlatStyle = FlatStyle.Flat;
            btnPreview.ForeColor = Color.White;
            btnPreview.Location = new Point(321, 4);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(127, 27);
            btnPreview.TabIndex = 8;
            btnPreview.Text = "🌐 Abrir no Navegador";
            btnPreview.UseVisualStyleBackColor = false;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 35);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(webView2);
            splitContainerMain.Panel1MinSize = 300;
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(webView2Preview);
            splitContainerMain.Panel2MinSize = 300;
            splitContainerMain.Size = new Size(831, 446);
            splitContainerMain.SplitterDistance = 401;
            splitContainerMain.TabIndex = 2;
            // 
            // webView2
            // 
            webView2.AllowExternalDrop = true;
            webView2.CreationProperties = null;
            webView2.DefaultBackgroundColor = Color.FromArgb(30, 30, 30);
            webView2.Dock = DockStyle.Fill;
            webView2.Location = new Point(0, 0);
            webView2.Name = "webView2";
            webView2.Size = new Size(401, 446);
            webView2.TabIndex = 0;
            webView2.ZoomFactor = 1D;
            // 
            // webView2Preview
            // 
            webView2Preview.AllowExternalDrop = true;
            webView2Preview.CreationProperties = null;
            webView2Preview.DefaultBackgroundColor = Color.White;
            webView2Preview.Dock = DockStyle.Fill;
            webView2Preview.Location = new Point(0, 0);
            webView2Preview.Name = "webView2Preview";
            webView2Preview.Size = new Size(426, 446);
            webView2Preview.TabIndex = 1;
            webView2Preview.ZoomFactor = 1D;
            // 
            // TemplateEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 481);
            Controls.Add(splitContainerMain);
            Controls.Add(metroPanelTop);
            Name = "TemplateEditForm";
            Text = "Template Editor - Monaco + Preview";
            WindowState = FormWindowState.Maximized;
            metroPanelTop.ResumeLayout(false);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView2Preview).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ReaLTaiizor.Controls.MetroPanel metroPanelTop;
        private Button btnSave;
        private Button btnCacelar;
        private Button btnBack;
        private Button btnPreview;
        private SplitContainer splitContainerMain;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2Preview;
    }
}