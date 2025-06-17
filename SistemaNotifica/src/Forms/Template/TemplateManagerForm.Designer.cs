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
            splitContainer = new SplitContainer();
            roundedButton1 = new SistemaNotifica.src.Controls.RoundedButton();
            dgvTemplates = new DataGridView();
            toolbarPanel = new Panel();
            btnUpload = new Button();
            btnDelete = new Button();
            btnSetPadrao = new Button();
            btnPreview = new Button();
            btnRefresh = new Button();
            webPreview = new WebBrowser();
            previewLabel = new Label();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTemplates).BeginInit();
            toolbarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip.Location = new Point(0, 727);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1184, 22);
            statusStrip.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 17);
            lblStatus.Text = "Carregando...";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(roundedButton1);
            splitContainer.Panel1.Controls.Add(dgvTemplates);
            splitContainer.Panel1.Controls.Add(toolbarPanel);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(webPreview);
            splitContainer.Panel2.Controls.Add(previewLabel);
            splitContainer.Size = new Size(1184, 727);
            splitContainer.SplitterDistance = 516;
            splitContainer.TabIndex = 0;
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = Color.Transparent;
            roundedButton1.Font = new Font("Segoe UI", 9F);
            roundedButton1.Location = new Point(22, 68);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(100, 35);
            roundedButton1.TabIndex = 2;
            // 
            // dgvTemplates
            // 
            dgvTemplates.AllowUserToAddRows = false;
            dgvTemplates.AllowUserToDeleteRows = false;
            dgvTemplates.BackgroundColor = Color.White;
            dgvTemplates.BorderStyle = BorderStyle.None;
            dgvTemplates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTemplates.Dock = DockStyle.Fill;
            dgvTemplates.Location = new Point(0, 50);
            dgvTemplates.MultiSelect = false;
            dgvTemplates.Name = "dgvTemplates";
            dgvTemplates.ReadOnly = true;
            dgvTemplates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTemplates.Size = new Size(1184, 466);
            dgvTemplates.TabIndex = 0;
            dgvTemplates.SelectionChanged += DgvTemplates_SelectionChanged;
            // 
            // toolbarPanel
            // 
            toolbarPanel.BackColor = Color.FromArgb(240, 240, 240);
            toolbarPanel.Controls.Add(btnUpload);
            toolbarPanel.Controls.Add(btnDelete);
            toolbarPanel.Controls.Add(btnSetPadrao);
            toolbarPanel.Controls.Add(btnPreview);
            toolbarPanel.Controls.Add(btnRefresh);
            toolbarPanel.Dock = DockStyle.Top;
            toolbarPanel.Location = new Point(0, 0);
            toolbarPanel.Name = "toolbarPanel";
            toolbarPanel.Size = new Size(1184, 50);
            toolbarPanel.TabIndex = 1;
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
            btnUpload.Location = new Point(10, 12);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(130, 30);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "📁 Upload Template";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += BtnUpload_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(244, 67, 54);
            btnDelete.Enabled = false;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(150, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 30);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "🗑️ Excluir";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnSetPadrao
            // 
            btnSetPadrao.BackColor = Color.FromArgb(255, 193, 7);
            btnSetPadrao.Enabled = false;
            btnSetPadrao.FlatStyle = FlatStyle.Flat;
            btnSetPadrao.ForeColor = Color.Black;
            btnSetPadrao.Location = new Point(240, 12);
            btnSetPadrao.Name = "btnSetPadrao";
            btnSetPadrao.Size = new Size(140, 30);
            btnSetPadrao.TabIndex = 2;
            btnSetPadrao.Text = "⭐ Definir como Padrão";
            btnSetPadrao.UseVisualStyleBackColor = false;
            btnSetPadrao.Click += BtnSetPadrao_Click;
            // 
            // btnPreview
            // 
            btnPreview.BackColor = Color.FromArgb(33, 150, 243);
            btnPreview.Enabled = false;
            btnPreview.FlatStyle = FlatStyle.Flat;
            btnPreview.ForeColor = Color.White;
            btnPreview.Location = new Point(390, 12);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(100, 30);
            btnPreview.TabIndex = 3;
            btnPreview.Text = "👁️ Visualizar";
            btnPreview.UseVisualStyleBackColor = false;
            btnPreview.Click += BtnPreview_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(96, 125, 139);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(500, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "🔄 Atualizar";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // webPreview
            // 
            webPreview.Dock = DockStyle.Fill;
            webPreview.Location = new Point(0, 30);
            webPreview.Name = "webPreview";
            webPreview.Size = new Size(1184, 177);
            webPreview.TabIndex = 0;
            // 
            // previewLabel
            // 
            previewLabel.BackColor = Color.FromArgb(245, 245, 245);
            previewLabel.Dock = DockStyle.Top;
            previewLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            previewLabel.Location = new Point(0, 0);
            previewLabel.Name = "previewLabel";
            previewLabel.Padding = new Padding(10, 0, 0, 0);
            previewLabel.Size = new Size(1184, 30);
            previewLabel.TabIndex = 1;
            previewLabel.Text = "Preview do Template";
            previewLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TemplateManagerForm
            // 
            ClientSize = new Size(1184, 749);
            Controls.Add(splitContainer);
            Controls.Add(statusStrip);
            Name = "TemplateManagerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerenciador de Templates";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTemplates).EndInit();
            toolbarPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Controls declaration
        private System.Windows.Forms.DataGridView dgvTemplates;
        private System.Windows.Forms.WebBrowser webPreview;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSetPadrao;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel toolbarPanel;
        private System.Windows.Forms.Label previewLabel;

        // DataGridView columns
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEhPadrao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeArquivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriadoEm;
        private Controls.RoundedButton roundedButton1;
    }
}