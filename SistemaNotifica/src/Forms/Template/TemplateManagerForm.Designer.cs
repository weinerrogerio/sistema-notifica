namespace SistemaNotifica.src.Forms.Template
{
    partial class TemplateManagerForm
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
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            btnRefresh = new Button();
            btnPreview = new Button();
            btnSetPadrao = new Button();
            btnDelete = new Button();
            btnUpload = new Button();
            dgvTemplates = new DataGridView();
            label1 = new Label();
            webPreview = new WebBrowser();
            toolbarPanel = new Panel();
            panelMain = new Panel();
            pnlPreviewTemplateMain = new Panel();
            pnlPreviewTemplate = new Panel();
            panelTemplatesMain = new Panel();
            panelTableTamplates = new Panel();
            label3 = new Label();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTemplates).BeginInit();
            toolbarPanel.SuspendLayout();
            panelMain.SuspendLayout();
            pnlPreviewTemplateMain.SuspendLayout();
            pnlPreviewTemplate.SuspendLayout();
            panelTemplatesMain.SuspendLayout();
            panelTableTamplates.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip.Location = new Point(0, 539);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(898, 22);
            statusStrip.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 17);
            lblStatus.Text = "Carregando...";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(96, 125, 139);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(499, 1);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "🔄 Atualizar";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // btnPreview
            // 
            btnPreview.BackColor = Color.FromArgb(33, 150, 243);
            btnPreview.Enabled = false;
            btnPreview.FlatStyle = FlatStyle.Flat;
            btnPreview.ForeColor = Color.White;
            btnPreview.Location = new Point(389, 1);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(100, 30);
            btnPreview.TabIndex = 3;
            btnPreview.Text = "👁️ Visualizar";
            btnPreview.UseVisualStyleBackColor = false;
            btnPreview.Click += BtnPreview_Click;
            // 
            // btnSetPadrao
            // 
            btnSetPadrao.BackColor = Color.FromArgb(255, 193, 7);
            btnSetPadrao.Enabled = false;
            btnSetPadrao.FlatStyle = FlatStyle.Flat;
            btnSetPadrao.ForeColor = Color.Black;
            btnSetPadrao.Location = new Point(239, 1);
            btnSetPadrao.Name = "btnSetPadrao";
            btnSetPadrao.Size = new Size(140, 30);
            btnSetPadrao.TabIndex = 2;
            btnSetPadrao.Text = "⭐ Definir como Padrão";
            btnSetPadrao.UseVisualStyleBackColor = false;
            btnSetPadrao.Click += BtnSetPadrao_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(244, 67, 54);
            btnDelete.Enabled = false;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(149, 1);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 30);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "🗑️ Excluir";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.FromArgb(76, 175, 80);
            btnUpload.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnUpload.FlatAppearance.BorderSize = 0;
            btnUpload.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 50, 60);
            btnUpload.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 80, 90);
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.ForeColor = Color.White;
            btnUpload.Location = new Point(9, 1);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(130, 30);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "📁 Upload Template";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += BtnUpload_Click;
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
            dgvTemplates.Size = new Size(198, 473);
            dgvTemplates.TabIndex = 0;
            dgvTemplates.SelectionChanged += DgvTemplates_SelectionChanged;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(245, 245, 245);
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(10, 0, 0, 0);
            label1.Size = new Size(698, 30);
            label1.TabIndex = 2;
            label1.Text = "Preview do Template";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // webPreview
            // 
            webPreview.Dock = DockStyle.Fill;
            webPreview.Location = new Point(0, 0);
            webPreview.Name = "webPreview";
            webPreview.Size = new Size(698, 475);
            webPreview.TabIndex = 0;
            // 
            // toolbarPanel
            // 
            toolbarPanel.BorderStyle = BorderStyle.FixedSingle;
            toolbarPanel.Controls.Add(btnUpload);
            toolbarPanel.Controls.Add(btnDelete);
            toolbarPanel.Controls.Add(btnRefresh);
            toolbarPanel.Controls.Add(btnSetPadrao);
            toolbarPanel.Controls.Add(btnPreview);
            toolbarPanel.Dock = DockStyle.Top;
            toolbarPanel.Location = new Point(0, 0);
            toolbarPanel.Name = "toolbarPanel";
            toolbarPanel.Size = new Size(898, 34);
            toolbarPanel.TabIndex = 0;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(pnlPreviewTemplateMain);
            panelMain.Controls.Add(panelTemplatesMain);
            panelMain.Controls.Add(toolbarPanel);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(898, 539);
            panelMain.TabIndex = 4;
            // 
            // pnlPreviewTemplateMain
            // 
            pnlPreviewTemplateMain.Controls.Add(pnlPreviewTemplate);
            pnlPreviewTemplateMain.Controls.Add(label1);
            pnlPreviewTemplateMain.Dock = DockStyle.Fill;
            pnlPreviewTemplateMain.Location = new Point(200, 34);
            pnlPreviewTemplateMain.Name = "pnlPreviewTemplateMain";
            pnlPreviewTemplateMain.Size = new Size(698, 505);
            pnlPreviewTemplateMain.TabIndex = 5;
            // 
            // pnlPreviewTemplate
            // 
            pnlPreviewTemplate.Controls.Add(webPreview);
            pnlPreviewTemplate.Dock = DockStyle.Fill;
            pnlPreviewTemplate.Location = new Point(0, 30);
            pnlPreviewTemplate.Name = "pnlPreviewTemplate";
            pnlPreviewTemplate.Size = new Size(698, 475);
            pnlPreviewTemplate.TabIndex = 3;
            // 
            // panelTemplatesMain
            // 
            panelTemplatesMain.BackColor = SystemColors.Control;
            panelTemplatesMain.BorderStyle = BorderStyle.FixedSingle;
            panelTemplatesMain.Controls.Add(panelTableTamplates);
            panelTemplatesMain.Controls.Add(label3);
            panelTemplatesMain.Dock = DockStyle.Left;
            panelTemplatesMain.Location = new Point(0, 34);
            panelTemplatesMain.Name = "panelTemplatesMain";
            panelTemplatesMain.Size = new Size(200, 505);
            panelTemplatesMain.TabIndex = 4;
            // 
            // panelTableTamplates
            // 
            panelTableTamplates.Controls.Add(dgvTemplates);
            panelTableTamplates.Dock = DockStyle.Fill;
            panelTableTamplates.Location = new Point(0, 30);
            panelTableTamplates.Name = "panelTableTamplates";
            panelTableTamplates.Size = new Size(198, 473);
            panelTableTamplates.TabIndex = 5;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(245, 245, 245);
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(10, 0, 0, 0);
            label3.Size = new Size(198, 30);
            label3.TabIndex = 6;
            label3.Text = "Templates Disponíveis";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TemplateManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 561);
            Controls.Add(panelMain);
            Controls.Add(statusStrip);
            MinimumSize = new Size(800, 600);
            Name = "TemplateManagerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerenciador de Templates";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTemplates).EndInit();
            toolbarPanel.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            pnlPreviewTemplateMain.ResumeLayout(false);
            pnlPreviewTemplate.ResumeLayout(false);
            panelTemplatesMain.ResumeLayout(false);
            panelTableTamplates.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        // DataGridView columns
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEhPadrao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeArquivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriadoEm;
        private Button btnUpload;
        private Button btnDelete;
        private Button btnSetPadrao;
        private Button btnPreview;
        private Button btnRefresh;
        private FlowLayoutPanel pnlTemplates;
        private Label label2;
        private DataGridView dgvTemplates;
        private Label label1;
        private WebBrowser webPreview;
        private Panel toolbarPanel;
        private Panel panelMain;
        private Panel panelTableTamplates;
        private Panel pnlPreviewTemplateMain;
        private Panel pnlPreviewTemplate;
        private Label label3;
        private Panel panelTemplatesMain;
    }
}