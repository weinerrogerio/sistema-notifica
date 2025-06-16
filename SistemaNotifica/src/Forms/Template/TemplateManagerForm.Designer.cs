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
            this.components = new System.ComponentModel.Container();

            // Configurações básicas do form
            this.SuspendLayout();

            this.Text = "Gerenciador de Templates";
            this.Size = new System.Drawing.Size(1200, 800);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Status Strip
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus.Text = "Carregando...";
            this.statusStrip.Items.Add(this.lblStatus);

            // Main Split Container
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer.SplitterDistance = 400;
            this.splitContainer.BeginInit();
            this.splitContainer.SuspendLayout();

            // Toolbar Panel
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.toolbarPanel.Height = 50;
            this.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarPanel.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            // Upload Button
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnUpload.Text = "📁 Upload Template";
            this.btnUpload.Location = new System.Drawing.Point(10, 12);
            this.btnUpload.Size = new System.Drawing.Size(130, 30);
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.BtnUpload_Click);

            // Delete Button
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDelete.Text = "🗑️ Excluir";
            this.btnDelete.Location = new System.Drawing.Point(150, 12);
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Enabled = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // Set Default Button
            this.btnSetPadrao = new System.Windows.Forms.Button();
            this.btnSetPadrao.Text = "⭐ Definir como Padrão";
            this.btnSetPadrao.Location = new System.Drawing.Point(240, 12);
            this.btnSetPadrao.Size = new System.Drawing.Size(140, 30);
            this.btnSetPadrao.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnSetPadrao.ForeColor = System.Drawing.Color.Black;
            this.btnSetPadrao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPadrao.UseVisualStyleBackColor = false;
            this.btnSetPadrao.Enabled = false;
            this.btnSetPadrao.Click += new System.EventHandler(this.BtnSetPadrao_Click);

            // Preview Button
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPreview.Text = "👁️ Visualizar";
            this.btnPreview.Location = new System.Drawing.Point(390, 12);
            this.btnPreview.Size = new System.Drawing.Size(100, 30);
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Enabled = false;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);

            // Refresh Button
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRefresh.Text = "🔄 Atualizar";
            this.btnRefresh.Location = new System.Drawing.Point(500, 12);
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(96, 125, 139);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // Add buttons to toolbar
            this.toolbarPanel.Controls.Add(this.btnUpload);
            this.toolbarPanel.Controls.Add(this.btnDelete);
            this.toolbarPanel.Controls.Add(this.btnSetPadrao);
            this.toolbarPanel.Controls.Add(this.btnPreview);
            this.toolbarPanel.Controls.Add(this.btnRefresh);

            // DataGridView
            this.dgvTemplates = new System.Windows.Forms.DataGridView();
            this.dgvTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTemplates.AutoGenerateColumns = false;
            this.dgvTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTemplates.MultiSelect = false;
            this.dgvTemplates.ReadOnly = true;
            this.dgvTemplates.AllowUserToAddRows = false;
            this.dgvTemplates.AllowUserToDeleteRows = false;
            this.dgvTemplates.BackgroundColor = System.Drawing.Color.White;
            this.dgvTemplates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Create and add columns
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId.Name = "Id";
            this.colId.HeaderText = "ID";
            this.colId.DataPropertyName = "Id";
            this.colId.Width = 60;
            this.dgvTemplates.Columns.Add(this.colId);

            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome.Name = "Nome";
            this.colNome.HeaderText = "Nome";
            this.colNome.DataPropertyName = "Nome";
            this.colNome.Width = 200;
            this.dgvTemplates.Columns.Add(this.colNome);

            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao.Name = "Descricao";
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.DataPropertyName = "Descricao";
            this.colDescricao.Width = 300;
            this.dgvTemplates.Columns.Add(this.colDescricao);

            this.colEhPadrao = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEhPadrao.Name = "EhPadrao";
            this.colEhPadrao.HeaderText = "Padrão";
            this.colEhPadrao.DataPropertyName = "EhPadrao";
            this.colEhPadrao.Width = 70;
            this.dgvTemplates.Columns.Add(this.colEhPadrao);

            this.colNomeArquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomeArquivo.Name = "NomeArquivo";
            this.colNomeArquivo.HeaderText = "Arquivo";
            this.colNomeArquivo.DataPropertyName = "NomeArquivo";
            this.colNomeArquivo.Width = 150;
            this.dgvTemplates.Columns.Add(this.colNomeArquivo);

            this.colCriadoEm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriadoEm.Name = "CriadoEm";
            this.colCriadoEm.HeaderText = "Criado em";
            this.colCriadoEm.DataPropertyName = "CriadoEm";
            this.colCriadoEm.Width = 120;
            this.colCriadoEm.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            this.dgvTemplates.Columns.Add(this.colCriadoEm);

            this.dgvTemplates.SelectionChanged += new System.EventHandler(this.DgvTemplates_SelectionChanged);

            // Add controls to top panel
            this.splitContainer.Panel1.Controls.Add(this.dgvTemplates);
            this.splitContainer.Panel1.Controls.Add(this.toolbarPanel);

            // Preview Label
            this.previewLabel = new System.Windows.Forms.Label();
            this.previewLabel.Text = "Preview do Template";
            this.previewLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.previewLabel.Height = 30;
            this.previewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.previewLabel.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.previewLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.previewLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // WebBrowser
            this.webPreview = new System.Windows.Forms.WebBrowser();
            this.webPreview.Dock = System.Windows.Forms.DockStyle.Fill;

            // Add controls to bottom panel
            this.splitContainer.Panel2.Controls.Add(this.webPreview);
            this.splitContainer.Panel2.Controls.Add(this.previewLabel);

            // Add main controls to form
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);

            // Complete initialization
            this.splitContainer.EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
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
    }
}