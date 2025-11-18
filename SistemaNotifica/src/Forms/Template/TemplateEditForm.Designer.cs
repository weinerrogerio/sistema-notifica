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
            btnShowLegend = new Button();
            btnSave = new Button();
            btnBack = new Button();
            btnCancelar = new Button();
            btnPreview = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            splitContainerMain = new SplitContainer();
            webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            listViewPlaceholders = new ListView();
            columnHeaderPlaceholder = new ColumnHeader();
            columnHeaderDesc = new ColumnHeader();
            webView2Preview = new Microsoft.Web.WebView2.WinForms.WebView2();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) splitContainerMain ).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) webView2 ).BeginInit();
            ( ( System.ComponentModel.ISupportInitialize ) webView2Preview ).BeginInit();
            SuspendLayout();
            // 
            // btnShowLegend
            // 
            btnShowLegend.BackColor = Color.Gray;
            btnShowLegend.FlatStyle = FlatStyle.Flat;
            btnShowLegend.ForeColor = Color.White;
            btnShowLegend.Location = new Point(493, 3);
            btnShowLegend.Name = "btnShowLegend";
            btnShowLegend.Size = new Size(177, 27);
            btnShowLegend.TabIndex = 10;
            btnShowLegend.Text = "Mostrar variáveis válidas";
            btnShowLegend.UseVisualStyleBackColor = false;
            btnShowLegend.Click +=  btnShowLegend_Click ;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(      76,       175,       80);
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(      0,       255,       255,       255);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(      40,       50,       60);
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(      70,       80,       90);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(357, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 27);
            btnSave.TabIndex = 5;
            btnSave.Text = "📁 Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click +=  btnSave_Click ;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(      96,       125,       139);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(3, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(90, 27);
            btnBack.TabIndex = 9;
            btnBack.Text = "🔄 Voltar";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click +=  btnBack_Click ;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(      244,       67,       54);
            btnCancelar.Enabled = false;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(271, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(80, 27);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "🗑️ Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click +=  btnCancelar_Click ;
            // 
            // btnPreview
            // 
            btnPreview.BackColor = Color.FromArgb(      33,       150,       243);
            btnPreview.Enabled = false;
            btnPreview.FlatStyle = FlatStyle.Flat;
            btnPreview.ForeColor = Color.White;
            btnPreview.Location = new Point(99, 3);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(166, 27);
            btnPreview.TabIndex = 8;
            btnPreview.Text = "🌐 Abrir no Navegador";
            btnPreview.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(splitContainerMain, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(838, 491);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(btnBack);
            flowLayoutPanel1.Controls.Add(btnPreview);
            flowLayoutPanel1.Controls.Add(btnCancelar);
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Controls.Add(btnShowLegend);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(838, 33);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 33);
            splitContainerMain.Margin = new Padding(0);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(webView2);
            splitContainerMain.Panel1MinSize = 300;
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(listViewPlaceholders);
            splitContainerMain.Panel2.Controls.Add(webView2Preview);
            splitContainerMain.Panel2MinSize = 300;
            splitContainerMain.Size = new Size(838, 458);
            splitContainerMain.SplitterDistance = 399;
            splitContainerMain.TabIndex = 2;
            // 
            // webView2
            // 
            webView2.AllowExternalDrop = true;
            webView2.CreationProperties = null;
            webView2.DefaultBackgroundColor = Color.FromArgb(      30,       30,       30);
            webView2.Dock = DockStyle.Fill;
            webView2.Location = new Point(0, 0);
            webView2.Margin = new Padding(0);
            webView2.Name = "webView2";
            webView2.Size = new Size(399, 458);
            webView2.TabIndex = 0;
            webView2.ZoomFactor = 1D;
            // 
            // listViewPlaceholders
            // 
            listViewPlaceholders.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Right ;
            listViewPlaceholders.BorderStyle = BorderStyle.FixedSingle;
            listViewPlaceholders.Columns.AddRange(new ColumnHeader[] { columnHeaderPlaceholder, columnHeaderDesc });
            listViewPlaceholders.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewPlaceholders.Location = new Point(113, -2);
            listViewPlaceholders.MultiSelect = false;
            listViewPlaceholders.Name = "listViewPlaceholders";
            listViewPlaceholders.Size = new Size(322, 460);
            listViewPlaceholders.TabIndex = 11;
            listViewPlaceholders.UseCompatibleStateImageBehavior = false;
            listViewPlaceholders.View = View.Details;
            listViewPlaceholders.Visible = false;
            // 
            // columnHeaderPlaceholder
            // 
            columnHeaderPlaceholder.Text = "Placeholder";
            columnHeaderPlaceholder.Width = 150;
            // 
            // columnHeaderDesc
            // 
            columnHeaderDesc.Text = "Descrição";
            columnHeaderDesc.Width = 200;
            // 
            // webView2Preview
            // 
            webView2Preview.AllowExternalDrop = true;
            webView2Preview.CreationProperties = null;
            webView2Preview.DefaultBackgroundColor = Color.White;
            webView2Preview.Dock = DockStyle.Fill;
            webView2Preview.Location = new Point(0, 0);
            webView2Preview.Margin = new Padding(0);
            webView2Preview.Name = "webView2Preview";
            webView2Preview.Size = new Size(435, 458);
            webView2Preview.TabIndex = 1;
            webView2Preview.ZoomFactor = 1D;
            // 
            // TemplateEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 491);
            Controls.Add(tableLayoutPanel1);
            Name = "TemplateEditForm";
            Text = "Template Editor - Monaco + Preview";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ( ( System.ComponentModel.ISupportInitialize ) splitContainerMain ).EndInit();
            splitContainerMain.ResumeLayout(false);
            ( ( System.ComponentModel.ISupportInitialize ) webView2 ).EndInit();
            ( ( System.ComponentModel.ISupportInitialize ) webView2Preview ).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnSave;
        private Button btnCancelar;
        private Button btnBack;
        private Button btnPreview;
        private Button btnShowLegend;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private SplitContainer splitContainerMain;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2Preview;
        private ListView listViewPlaceholders;
        private ColumnHeader columnHeaderPlaceholder;
        private ColumnHeader columnHeaderDesc;
    }
}