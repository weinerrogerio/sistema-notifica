namespace SistemaNotifica.src.FormsTestes
{
    partial class MainFormOnTop
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
            if ( disposing && ( components != null ) )
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
            components = new System.ComponentModel.Container();
            timerTransition = new System.Windows.Forms.Timer(components);
            btnEdit = new Button();
            btnUpload = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnSetPadrao = new Button();
            btnPreview = new Button();
            btnShowLegend = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panelEdit = new Panel();
            pnlPreviewTemplate = new Panel();
            webPreview = new WebBrowser();
            label3 = new Label();
            label1 = new Label();
            dgvTemplates = new DataGridView();
            panelTableTamplates = new Panel();
            panelTemplatesMain = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            pnlPreviewTemplateMain = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelMain = new Panel();
            lblStatus = new ToolStripStatusLabel();
            statusStrip = new StatusStrip();
            webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            webView2Preview = new Microsoft.Web.WebView2.WinForms.WebView2();
            splitContainerMain = new SplitContainer();
            flowLayoutPanel1.SuspendLayout();
            pnlPreviewTemplate.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) dgvTemplates ).BeginInit();
            panelTableTamplates.SuspendLayout();
            panelTemplatesMain.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            pnlPreviewTemplateMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelMain.SuspendLayout();
            statusStrip.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) webView2 ).BeginInit();
            ( ( System.ComponentModel.ISupportInitialize ) webView2Preview ).BeginInit();
            ( ( System.ComponentModel.ISupportInitialize ) splitContainerMain ).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            SuspendLayout();
            // 
            // timerTransition
            // 
            timerTransition.Interval = 8;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(      33,       150,       243);
            btnEdit.FlatStyle = FlatStyle.Popup;
            btnEdit.ForeColor = SystemColors.Control;
            btnEdit.Location = new Point(3, 6);
            btnEdit.Margin = new Padding(3, 6, 3, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 27);
            btnEdit.TabIndex = 14;
            btnEdit.Text = "Editar";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.FromArgb(      76,       175,       80);
            btnUpload.FlatStyle = FlatStyle.Popup;
            btnUpload.ForeColor = Color.White;
            btnUpload.Location = new Point(109, 6);
            btnUpload.Margin = new Padding(3, 6, 3, 3);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(100, 27);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "📁 Upload Template";
            btnUpload.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(      244,       67,       54);
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(215, 6);
            btnDelete.Margin = new Padding(3, 6, 3, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 27);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "🗑️ Excluir";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(      96,       125,       139);
            btnRefresh.FlatStyle = FlatStyle.Popup;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(321, 6);
            btnRefresh.Margin = new Padding(3, 6, 3, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 27);
            btnRefresh.TabIndex = 16;
            btnRefresh.Text = "🔄 Atualizar";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnSetPadrao
            // 
            btnSetPadrao.BackColor = Color.FromArgb(      255,       193,       7);
            btnSetPadrao.Enabled = false;
            btnSetPadrao.FlatStyle = FlatStyle.Popup;
            btnSetPadrao.ForeColor = Color.Transparent;
            btnSetPadrao.Location = new Point(427, 6);
            btnSetPadrao.Margin = new Padding(3, 6, 3, 3);
            btnSetPadrao.Name = "btnSetPadrao";
            btnSetPadrao.Size = new Size(140, 27);
            btnSetPadrao.TabIndex = 17;
            btnSetPadrao.Text = "⭐ Definir como Padrão";
            btnSetPadrao.UseVisualStyleBackColor = false;
            // 
            // btnPreview
            // 
            btnPreview.BackColor = Color.FromArgb(      33,       150,       243);
            btnPreview.Enabled = false;
            btnPreview.FlatStyle = FlatStyle.Popup;
            btnPreview.ForeColor = Color.White;
            btnPreview.Location = new Point(573, 6);
            btnPreview.Margin = new Padding(3, 6, 3, 3);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(100, 27);
            btnPreview.TabIndex = 18;
            btnPreview.Text = "👁️ Visualizar";
            btnPreview.UseVisualStyleBackColor = false;
            // 
            // btnShowLegend
            // 
            btnShowLegend.BackColor = Color.Gray;
            btnShowLegend.FlatStyle = FlatStyle.Popup;
            btnShowLegend.ForeColor = Color.White;
            btnShowLegend.Location = new Point(679, 6);
            btnShowLegend.Margin = new Padding(3, 6, 3, 3);
            btnShowLegend.Name = "btnShowLegend";
            btnShowLegend.Size = new Size(177, 27);
            btnShowLegend.TabIndex = 13;
            btnShowLegend.Text = "Mostrar variáveis válidas";
            btnShowLegend.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(btnEdit);
            flowLayoutPanel1.Controls.Add(btnUpload);
            flowLayoutPanel1.Controls.Add(btnDelete);
            flowLayoutPanel1.Controls.Add(btnRefresh);
            flowLayoutPanel1.Controls.Add(btnSetPadrao);
            flowLayoutPanel1.Controls.Add(btnPreview);
            flowLayoutPanel1.Controls.Add(btnShowLegend);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(977, 36);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // panelEdit
            // 
            panelEdit.BackColor = Color.Red;
            panelEdit.Dock = DockStyle.Right;
            panelEdit.Location = new Point(977, 0);
            panelEdit.Name = "panelEdit";
            panelEdit.Size = new Size(0, 428);
            panelEdit.TabIndex = 9;
            // 
            // pnlPreviewTemplate
            // 
            pnlPreviewTemplate.Controls.Add(splitContainerMain);
            pnlPreviewTemplate.Controls.Add(webPreview);
            pnlPreviewTemplate.Dock = DockStyle.Fill;
            pnlPreviewTemplate.Location = new Point(0, 30);
            pnlPreviewTemplate.Name = "pnlPreviewTemplate";
            pnlPreviewTemplate.Size = new Size(776, 356);
            pnlPreviewTemplate.TabIndex = 3;
            // 
            // webPreview
            // 
            webPreview.Dock = DockStyle.Fill;
            webPreview.Location = new Point(0, 0);
            webPreview.Name = "webPreview";
            webPreview.Size = new Size(776, 356);
            webPreview.TabIndex = 0;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(      245,       245,       245);
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(10, 0, 0, 0);
            label3.Size = new Size(187, 30);
            label3.TabIndex = 6;
            label3.Text = "Templates Disponíveis";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(      245,       245,       245);
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(10, 0, 0, 0);
            label1.Size = new Size(776, 30);
            label1.TabIndex = 2;
            label1.Text = "Preview do Template";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvTemplates
            // 
            dgvTemplates.AllowUserToAddRows = false;
            dgvTemplates.AllowUserToDeleteRows = false;
            dgvTemplates.BackgroundColor = Color.White;
            dgvTemplates.BorderStyle = BorderStyle.None;
            dgvTemplates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTemplates.Dock = DockStyle.Fill;
            dgvTemplates.Location = new Point(0, 0);
            dgvTemplates.MultiSelect = false;
            dgvTemplates.Name = "dgvTemplates";
            dgvTemplates.ReadOnly = true;
            dgvTemplates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTemplates.Size = new Size(187, 354);
            dgvTemplates.TabIndex = 0;
            // 
            // panelTableTamplates
            // 
            panelTableTamplates.Controls.Add(dgvTemplates);
            panelTableTamplates.Dock = DockStyle.Fill;
            panelTableTamplates.Location = new Point(0, 30);
            panelTableTamplates.Name = "panelTableTamplates";
            panelTableTamplates.Size = new Size(187, 354);
            panelTableTamplates.TabIndex = 5;
            // 
            // panelTemplatesMain
            // 
            panelTemplatesMain.BackColor = SystemColors.Control;
            panelTemplatesMain.BorderStyle = BorderStyle.FixedSingle;
            panelTemplatesMain.Controls.Add(panelTableTamplates);
            panelTemplatesMain.Controls.Add(label3);
            panelTemplatesMain.Dock = DockStyle.Fill;
            panelTemplatesMain.Location = new Point(3, 3);
            panelTemplatesMain.Name = "panelTemplatesMain";
            panelTemplatesMain.Size = new Size(189, 386);
            panelTemplatesMain.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel2.Controls.Add(panelTemplatesMain, 0, 0);
            tableLayoutPanel2.Controls.Add(pnlPreviewTemplateMain, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 36);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(977, 392);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // pnlPreviewTemplateMain
            // 
            pnlPreviewTemplateMain.Controls.Add(pnlPreviewTemplate);
            pnlPreviewTemplateMain.Controls.Add(label1);
            pnlPreviewTemplateMain.Dock = DockStyle.Fill;
            pnlPreviewTemplateMain.Location = new Point(198, 3);
            pnlPreviewTemplateMain.Name = "pnlPreviewTemplateMain";
            pnlPreviewTemplateMain.Size = new Size(776, 386);
            pnlPreviewTemplateMain.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(977, 428);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(tableLayoutPanel1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(977, 428);
            panelMain.TabIndex = 8;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 17);
            lblStatus.Text = "Carregando...";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(977, 22);
            statusStrip.TabIndex = 7;
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
            webView2.Size = new Size(300, 356);
            webView2.TabIndex = 0;
            webView2.ZoomFactor = 1D;
            // 
            // webView2Preview
            // 
            webView2Preview.AllowExternalDrop = true;
            webView2Preview.CreationProperties = null;
            webView2Preview.DefaultBackgroundColor = Color.White;
            webView2Preview.Location = new Point(0, 30);
            webView2Preview.Margin = new Padding(0);
            webView2Preview.Name = "webView2Preview";
            webView2Preview.Size = new Size(452, 441);
            webView2Preview.TabIndex = 1;
            webView2Preview.ZoomFactor = 1D;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
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
            splitContainerMain.Panel2.Controls.Add(webView2Preview);
            splitContainerMain.Panel2MinSize = 300;
            splitContainerMain.Size = new Size(776, 356);
            splitContainerMain.SplitterDistance = 300;
            splitContainerMain.TabIndex = 3;
            // 
            // MainFormOnTop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 450);
            Controls.Add(panelEdit);
            Controls.Add(panelMain);
            Controls.Add(statusStrip);
            Name = "MainFormOnTop";
            Text = "MainFormOnTop";
            flowLayoutPanel1.ResumeLayout(false);
            pnlPreviewTemplate.ResumeLayout(false);
            ( ( System.ComponentModel.ISupportInitialize ) dgvTemplates ).EndInit();
            panelTableTamplates.ResumeLayout(false);
            panelTemplatesMain.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            pnlPreviewTemplateMain.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ( ( System.ComponentModel.ISupportInitialize ) webView2 ).EndInit();
            ( ( System.ComponentModel.ISupportInitialize ) webView2Preview ).EndInit();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ( ( System.ComponentModel.ISupportInitialize ) splitContainerMain ).EndInit();
            splitContainerMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timerTransition;
        private Button btnEdit;
        private Button btnUpload;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnSetPadrao;
        private Button btnPreview;
        private Button btnShowLegend;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panelEdit;
        private Panel pnlPreviewTemplate;
        private WebBrowser webPreview;
        private Label label3;
        private Label label1;
        private DataGridView dgvTemplates;
        private Panel panelTableTamplates;
        private Panel panelTemplatesMain;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel pnlPreviewTemplateMain;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelMain;
        private ToolStripStatusLabel lblStatus;
        private StatusStrip statusStrip;
        private SplitContainer splitContainerMain;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2Preview;
    }
}