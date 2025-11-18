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
            components = new System.ComponentModel.Container();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            panelMain = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panelTemplatesMain = new Panel();
            panelTableTamplates = new Panel();
            label3 = new Label();
            pnlPreviewTemplateMain = new Panel();
            pnlPreviewTemplate = new Panel();
            webPreview = new WebBrowser();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnEdit = new Button();
            btnUpload = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnSetPadrao = new Button();
            btnPreview = new Button();
            btnShowLegend = new Button();
            panelEdit = new Panel();
            timerTransition = new System.Windows.Forms.Timer(components);
            statusStrip.SuspendLayout();
            panelMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panelTemplatesMain.SuspendLayout();
            pnlPreviewTemplateMain.SuspendLayout();
            pnlPreviewTemplate.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            // panelMain
            // 
            panelMain.Controls.Add(tableLayoutPanel1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(898, 539);
            panelMain.TabIndex = 4;
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
            tableLayoutPanel1.Size = new Size(898, 539);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(panelTemplatesMain, 0, 0);
            tableLayoutPanel2.Controls.Add(pnlPreviewTemplateMain, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 36);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(898, 503);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // panelTemplatesMain
            // 
            panelTemplatesMain.BackColor = SystemColors.Control;
            panelTemplatesMain.Controls.Add(panelTableTamplates);
            panelTemplatesMain.Controls.Add(label3);
            panelTemplatesMain.Dock = DockStyle.Fill;
            panelTemplatesMain.Location = new Point(0, 0);
            panelTemplatesMain.Margin = new Padding(0);
            panelTemplatesMain.Name = "panelTemplatesMain";
            panelTemplatesMain.Size = new Size(173, 503);
            panelTemplatesMain.TabIndex = 4;
            // 
            // panelTableTamplates
            // 
            panelTableTamplates.BackColor = Color.White;
            panelTableTamplates.Dock = DockStyle.Fill;
            panelTableTamplates.Location = new Point(0, 30);
            panelTableTamplates.Name = "panelTableTamplates";
            panelTableTamplates.Size = new Size(173, 473);
            panelTableTamplates.TabIndex = 5;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(      245,       245,       245);
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(10, 0, 0, 0);
            label3.Size = new Size(173, 30);
            label3.TabIndex = 6;
            label3.Text = "Templates Disponíveis";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlPreviewTemplateMain
            // 
            pnlPreviewTemplateMain.Controls.Add(pnlPreviewTemplate);
            pnlPreviewTemplateMain.Controls.Add(label1);
            pnlPreviewTemplateMain.Dock = DockStyle.Fill;
            pnlPreviewTemplateMain.Location = new Point(173, 0);
            pnlPreviewTemplateMain.Margin = new Padding(0);
            pnlPreviewTemplateMain.Name = "pnlPreviewTemplateMain";
            pnlPreviewTemplateMain.Size = new Size(725, 503);
            pnlPreviewTemplateMain.TabIndex = 5;
            // 
            // pnlPreviewTemplate
            // 
            pnlPreviewTemplate.Controls.Add(webPreview);
            pnlPreviewTemplate.Dock = DockStyle.Fill;
            pnlPreviewTemplate.Location = new Point(0, 30);
            pnlPreviewTemplate.Name = "pnlPreviewTemplate";
            pnlPreviewTemplate.Size = new Size(725, 473);
            pnlPreviewTemplate.TabIndex = 3;
            // 
            // webPreview
            // 
            webPreview.Dock = DockStyle.Fill;
            webPreview.Location = new Point(0, 0);
            webPreview.Margin = new Padding(0);
            webPreview.Name = "webPreview";
            webPreview.Size = new Size(725, 473);
            webPreview.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(      245,       245,       245);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Padding = new Padding(10, 0, 0, 0);
            label1.Size = new Size(725, 30);
            label1.TabIndex = 2;
            label1.Text = "Preview do Template";
            label1.TextAlign = ContentAlignment.MiddleLeft;
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
            flowLayoutPanel1.Size = new Size(898, 36);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(      33,       150,       243);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = SystemColors.Control;
            btnEdit.Location = new Point(3, 6);
            btnEdit.Margin = new Padding(3, 6, 3, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 27);
            btnEdit.TabIndex = 14;
            btnEdit.Text = "Editar";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click +=  btnEdit_ClickAsync ;
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.FromArgb(      76,       175,       80);
            btnUpload.FlatStyle = FlatStyle.Flat;
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
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(215, 6);
            btnDelete.Margin = new Padding(3, 6, 3, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 27);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "🗑️ Excluir";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click +=  btnDelete_Click ;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(      96,       125,       139);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(321, 6);
            btnRefresh.Margin = new Padding(3, 6, 3, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 27);
            btnRefresh.TabIndex = 16;
            btnRefresh.Text = "🔄 Atualizar";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click +=  btnRefresh_Click ;
            // 
            // btnSetPadrao
            // 
            btnSetPadrao.BackColor = Color.FromArgb(      255,       193,       7);
            btnSetPadrao.Enabled = false;
            btnSetPadrao.FlatStyle = FlatStyle.Flat;
            btnSetPadrao.ForeColor = Color.Transparent;
            btnSetPadrao.Location = new Point(427, 6);
            btnSetPadrao.Margin = new Padding(3, 6, 3, 3);
            btnSetPadrao.Name = "btnSetPadrao";
            btnSetPadrao.Size = new Size(140, 27);
            btnSetPadrao.TabIndex = 17;
            btnSetPadrao.Text = "⭐ Definir como Padrão";
            btnSetPadrao.UseVisualStyleBackColor = false;
            btnSetPadrao.Click +=  btnSetPadrao_Click ;
            // 
            // btnPreview
            // 
            btnPreview.BackColor = Color.FromArgb(      33,       150,       243);
            btnPreview.Enabled = false;
            btnPreview.FlatStyle = FlatStyle.Flat;
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
            btnShowLegend.FlatStyle = FlatStyle.Flat;
            btnShowLegend.ForeColor = Color.White;
            btnShowLegend.Location = new Point(679, 6);
            btnShowLegend.Margin = new Padding(3, 6, 3, 3);
            btnShowLegend.Name = "btnShowLegend";
            btnShowLegend.Size = new Size(177, 27);
            btnShowLegend.TabIndex = 13;
            btnShowLegend.Text = "Mostrar variáveis válidas";
            btnShowLegend.UseVisualStyleBackColor = false;
            // 
            // panelEdit
            // 
            panelEdit.BackColor = Color.Red;
            panelEdit.Dock = DockStyle.Right;
            panelEdit.Location = new Point(898, 0);
            panelEdit.Name = "panelEdit";
            panelEdit.Size = new Size(0, 539);
            panelEdit.TabIndex = 6;
            // 
            // timerTransition
            // 
            timerTransition.Interval = 8;
            timerTransition.Tick +=  timerTransition_Tick ;
            // 
            // TemplateManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 561);
            Controls.Add(panelEdit);
            Controls.Add(panelMain);
            Controls.Add(statusStrip);
            Name = "TemplateManagerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerenciador de Templates";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panelTemplatesMain.ResumeLayout(false);
            pnlPreviewTemplateMain.ResumeLayout(false);
            pnlPreviewTemplate.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
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
        private FlowLayoutPanel pnlTemplates;
        private Panel panelMain;
        private Panel panelEdit;
        private System.Windows.Forms.Timer timerTransition;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panelTemplatesMain;
        private Panel panelTableTamplates;
        private Label label3;
        private Panel pnlPreviewTemplateMain;
        private Panel pnlPreviewTemplate;
        private WebBrowser webPreview;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnPreview;
        private Button btnShowLegend;
        private Button btnEdit;
        private Button btnUpload;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnSetPadrao;
    }
}