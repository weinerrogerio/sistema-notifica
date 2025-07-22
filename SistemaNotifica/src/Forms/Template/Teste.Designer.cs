namespace SistemaNotifica.src.Forms.Template
{
    partial class Teste
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
            components = new System.ComponentModel.Container();
            panelMain = new Panel();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            panel1 = new Panel();
            panel2 = new Panel();
            pnlPreviewTemplateMain = new Panel();
            pnlPreviewTemplate = new Panel();
            webPreview = new WebBrowser();
            label1 = new Label();
            panelTemplatesMain = new Panel();
            panelTableTamplates = new Panel();
            dgvTemplates = new DataGridView();
            label3 = new Label();
            toolbarPanel = new Panel();
            btnEdit = new Button();
            btnUpload = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnSetPadrao = new Button();
            btnPreview = new Button();
            panelAux = new Panel();
            timerTransition = new System.Windows.Forms.Timer(components);
            timer1 = new System.Windows.Forms.Timer(components);
            panelMain.SuspendLayout();
            statusStrip.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            pnlPreviewTemplateMain.SuspendLayout();
            pnlPreviewTemplate.SuspendLayout();
            panelTemplatesMain.SuspendLayout();
            panelTableTamplates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTemplates).BeginInit();
            toolbarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(statusStrip);
            panelMain.Controls.Add(panel1);
            panelMain.Controls.Add(panelAux);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(940, 450);
            panelMain.TabIndex = 1;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(940, 22);
            statusStrip.TabIndex = 5;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 17);
            lblStatus.Text = "Carregando...";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(940, 450);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(pnlPreviewTemplateMain);
            panel2.Controls.Add(panelTemplatesMain);
            panel2.Controls.Add(toolbarPanel);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(940, 450);
            panel2.TabIndex = 6;
            // 
            // pnlPreviewTemplateMain
            // 
            pnlPreviewTemplateMain.Controls.Add(pnlPreviewTemplate);
            pnlPreviewTemplateMain.Controls.Add(label1);
            pnlPreviewTemplateMain.Dock = DockStyle.Fill;
            pnlPreviewTemplateMain.Location = new Point(199, 35);
            pnlPreviewTemplateMain.Name = "pnlPreviewTemplateMain";
            pnlPreviewTemplateMain.Size = new Size(741, 415);
            pnlPreviewTemplateMain.TabIndex = 5;
            // 
            // pnlPreviewTemplate
            // 
            pnlPreviewTemplate.Controls.Add(webPreview);
            pnlPreviewTemplate.Dock = DockStyle.Fill;
            pnlPreviewTemplate.Location = new Point(0, 30);
            pnlPreviewTemplate.Name = "pnlPreviewTemplate";
            pnlPreviewTemplate.Size = new Size(741, 385);
            pnlPreviewTemplate.TabIndex = 3;
            // 
            // webPreview
            // 
            webPreview.Dock = DockStyle.Fill;
            webPreview.Location = new Point(0, 0);
            webPreview.Name = "webPreview";
            webPreview.Size = new Size(741, 385);
            webPreview.TabIndex = 0;
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
            label1.Size = new Size(741, 30);
            label1.TabIndex = 2;
            label1.Text = "Preview do Template";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelTemplatesMain
            // 
            panelTemplatesMain.BackColor = SystemColors.Control;
            panelTemplatesMain.BorderStyle = BorderStyle.FixedSingle;
            panelTemplatesMain.Controls.Add(panelTableTamplates);
            panelTemplatesMain.Controls.Add(label3);
            panelTemplatesMain.Dock = DockStyle.Left;
            panelTemplatesMain.Location = new Point(0, 35);
            panelTemplatesMain.Name = "panelTemplatesMain";
            panelTemplatesMain.Size = new Size(199, 415);
            panelTemplatesMain.TabIndex = 4;
            // 
            // panelTableTamplates
            // 
            panelTableTamplates.Controls.Add(dgvTemplates);
            panelTableTamplates.Dock = DockStyle.Fill;
            panelTableTamplates.Location = new Point(0, 30);
            panelTableTamplates.Name = "panelTableTamplates";
            panelTableTamplates.Size = new Size(197, 383);
            panelTableTamplates.TabIndex = 5;
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
            dgvTemplates.Size = new Size(197, 383);
            dgvTemplates.TabIndex = 0;
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
            label3.Size = new Size(197, 30);
            label3.TabIndex = 6;
            label3.Text = "Templates Disponíveis";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolbarPanel
            // 
            toolbarPanel.BorderStyle = BorderStyle.FixedSingle;
            toolbarPanel.Controls.Add(btnEdit);
            toolbarPanel.Controls.Add(btnUpload);
            toolbarPanel.Controls.Add(btnDelete);
            toolbarPanel.Controls.Add(btnRefresh);
            toolbarPanel.Controls.Add(btnSetPadrao);
            toolbarPanel.Controls.Add(btnPreview);
            toolbarPanel.Dock = DockStyle.Top;
            toolbarPanel.Location = new Point(0, 0);
            toolbarPanel.Name = "toolbarPanel";
            toolbarPanel.Size = new Size(940, 35);
            toolbarPanel.TabIndex = 0;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(33, 150, 243);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(568, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(90, 27);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Editar";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click_1;
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
            btnUpload.Location = new Point(4, 4);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(130, 25);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "📁 Upload Template";
            btnUpload.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(244, 67, 54);
            btnDelete.Enabled = false;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.Transparent;
            btnDelete.Location = new Point(140, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 27);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "🗑️ Excluir";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(96, 125, 139);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(474, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 27);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "🔄 Atualizar";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnSetPadrao
            // 
            btnSetPadrao.BackColor = Color.FromArgb(255, 193, 7);
            btnSetPadrao.Enabled = false;
            btnSetPadrao.FlatStyle = FlatStyle.Flat;
            btnSetPadrao.ForeColor = Color.Transparent;
            btnSetPadrao.Location = new Point(225, 3);
            btnSetPadrao.Name = "btnSetPadrao";
            btnSetPadrao.Size = new Size(140, 27);
            btnSetPadrao.TabIndex = 2;
            btnSetPadrao.Text = "⭐ Definir como Padrão";
            btnSetPadrao.UseVisualStyleBackColor = false;
            // 
            // btnPreview
            // 
            btnPreview.BackColor = Color.FromArgb(33, 150, 243);
            btnPreview.Enabled = false;
            btnPreview.FlatStyle = FlatStyle.Flat;
            btnPreview.ForeColor = Color.White;
            btnPreview.Location = new Point(370, 3);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(100, 27);
            btnPreview.TabIndex = 3;
            btnPreview.Text = "👁️ Visualizar";
            btnPreview.UseVisualStyleBackColor = false;
            // 
            // panelAux
            // 
            panelAux.BackColor = Color.FromArgb(192, 0, 0);
            panelAux.Dock = DockStyle.Right;
            panelAux.Location = new Point(940, 0);
            panelAux.Name = "panelAux";
            panelAux.Size = new Size(0, 450);
            panelAux.TabIndex = 1;
            // 
            // timerTransition
            // 
            timerTransition.Interval = 8;
            timerTransition.Tick += timerTransition_Tick;
            // 
            // Teste
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 450);
            Controls.Add(panelMain);
            Name = "Teste";
            Text = "Teste";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            pnlPreviewTemplateMain.ResumeLayout(false);
            pnlPreviewTemplate.ResumeLayout(false);
            panelTemplatesMain.ResumeLayout(false);
            panelTableTamplates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTemplates).EndInit();
            toolbarPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMain;
        private Panel panelAux;
        private System.Windows.Forms.Timer timerTransition;
        private Panel panel1;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private Panel panel2;
        private Panel pnlPreviewTemplateMain;
        private Panel pnlPreviewTemplate;
        private WebBrowser webPreview;
        private Label label1;
        private Panel panelTemplatesMain;
        private Panel panelTableTamplates;
        private DataGridView dgvTemplates;
        private Label label3;
        private Panel toolbarPanel;
        private Button btnEdit;
        private Button btnUpload;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnSetPadrao;
        private Button btnPreview;
        private System.Windows.Forms.Timer timer1;
    }
}