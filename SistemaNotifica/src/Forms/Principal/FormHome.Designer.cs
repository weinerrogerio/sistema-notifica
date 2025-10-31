namespace SistemaNotifica.src.Forms
{
    partial class FormHome
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            labelHome = new Label();
            panelHome = new Panel();
            mainTableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanelTop = new TableLayoutPanel();
            panel3 = new Panel();
            flowLayoutPanel = new FlowLayoutPanel();
            btnImport = new Button();
            dataGridViewProtesto = new DataGridView();
            ColumnDataDist = new DataGridViewTextBoxColumn();
            ColumnNumDist = new DataGridViewTextBoxColumn();
            ColumnDevedor = new DataGridViewTextBoxColumn();
            ColumnDocDev = new DataGridViewTextBoxColumn();
            ColumnEmail = new DataGridViewTextBoxColumn();
            ColumnStatus = new DataGridViewTextBoxColumn();
            tableLayoutPanelBotton = new TableLayoutPanel();
            chartDist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panelArq = new Panel();
            dataGridViewImports = new DataGridView();
            ColumnArquivo = new DataGridViewTextBoxColumn();
            ColumnDataImport = new DataGridViewTextBoxColumn();
            ColumnUser = new DataGridViewTextBoxColumn();
            ColumnStatusArquivo = new DataGridViewTextBoxColumn();
            panelHeader = new Panel();
            btnRefresh = new Button();
            panelHome.SuspendLayout();
            mainTableLayoutPanel.SuspendLayout();
            tableLayoutPanelTop.SuspendLayout();
            panel3.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewProtesto ).BeginInit();
            tableLayoutPanelBotton.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) chartDist ).BeginInit();
            panelArq.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewImports ).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // labelHome
            // 
            labelHome.Anchor =       AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            labelHome.AutoSize = true;
            labelHome.Location = new Point(378, 7);
            labelHome.Name = "labelHome";
            labelHome.Size = new Size(77, 15);
            labelHome.TabIndex = 0;
            labelHome.Text = "TELA INICIAL";
            // 
            // panelHome
            // 
            panelHome.BackColor = SystemColors.Control;
            panelHome.Controls.Add(mainTableLayoutPanel);
            panelHome.Dock = DockStyle.Fill;
            panelHome.Location = new Point(0, 0);
            panelHome.Name = "panelHome";
            panelHome.Padding = new Padding(10, 40, 10, 10);
            panelHome.Size = new Size(800, 450);
            panelHome.TabIndex = 1;
            // 
            // mainTableLayoutPanel
            // 
            mainTableLayoutPanel.ColumnCount = 1;
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainTableLayoutPanel.Controls.Add(tableLayoutPanelTop, 0, 0);
            mainTableLayoutPanel.Controls.Add(tableLayoutPanelBotton, 0, 1);
            mainTableLayoutPanel.Dock = DockStyle.Fill;
            mainTableLayoutPanel.Location = new Point(10, 40);
            mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            mainTableLayoutPanel.RowCount = 2;
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainTableLayoutPanel.Size = new Size(780, 400);
            mainTableLayoutPanel.TabIndex = 2;
            // 
            // tableLayoutPanelTop
            // 
            tableLayoutPanelTop.BackColor = Color.Transparent;
            tableLayoutPanelTop.ColumnCount = 2;
            tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.9487152F));
            tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.0512829F));
            tableLayoutPanelTop.Controls.Add(panel3, 1, 0);
            tableLayoutPanelTop.Controls.Add(dataGridViewProtesto, 0, 0);
            tableLayoutPanelTop.Dock = DockStyle.Fill;
            tableLayoutPanelTop.Location = new Point(1, 1);
            tableLayoutPanelTop.Margin = new Padding(1);
            tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            tableLayoutPanelTop.RowCount = 1;
            tableLayoutPanelTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelTop.Size = new Size(778, 198);
            tableLayoutPanelTop.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(flowLayoutPanel);
            panel3.Dock = DockStyle.Fill;
            panel3.ForeColor = Color.Transparent;
            panel3.Location = new Point(570, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(205, 192);
            panel3.TabIndex = 1;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.BackColor = SystemColors.Control;
            flowLayoutPanel.Controls.Add(btnRefresh);
            flowLayoutPanel.Controls.Add(btnImport);
            flowLayoutPanel.Dock = DockStyle.Right;
            flowLayoutPanel.Location = new Point(5, 0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(200, 192);
            flowLayoutPanel.TabIndex = 7;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.FromArgb(      64,       64,       64);
            btnImport.FlatAppearance.BorderSize = 0;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point,    0);
            btnImport.ForeColor = Color.White;
            btnImport.Location = new Point(3, 49);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(200, 40);
            btnImport.TabIndex = 6;
            btnImport.Text = "IMPORTAR NOVO ARQUIVO";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click +=  btnImport_Click ;
            // 
            // dataGridViewProtesto
            // 
            dataGridViewProtesto.AllowUserToAddRows = false;
            dataGridViewProtesto.AllowUserToDeleteRows = false;
            dataGridViewProtesto.AllowUserToOrderColumns = true;
            dataGridViewProtesto.BackgroundColor = SystemColors.Control;
            dataGridViewProtesto.BorderStyle = BorderStyle.None;
            dataGridViewProtesto.Columns.AddRange(new DataGridViewColumn[] { ColumnDataDist, ColumnNumDist, ColumnDevedor, ColumnDocDev, ColumnEmail, ColumnStatus });
            dataGridViewProtesto.Dock = DockStyle.Fill;
            dataGridViewProtesto.Location = new Point(3, 3);
            dataGridViewProtesto.Name = "dataGridViewProtesto";
            dataGridViewProtesto.ReadOnly = true;
            dataGridViewProtesto.Size = new Size(561, 192);
            dataGridViewProtesto.TabIndex = 2;
            // 
            // ColumnDataDist
            // 
            ColumnDataDist.FillWeight = 60F;
            ColumnDataDist.HeaderText = "Data Distribuição";
            ColumnDataDist.Name = "ColumnDataDist";
            ColumnDataDist.ReadOnly = true;
            // 
            // ColumnNumDist
            // 
            ColumnNumDist.FillWeight = 55F;
            ColumnNumDist.HeaderText = "Distribuição";
            ColumnNumDist.Name = "ColumnNumDist";
            ColumnNumDist.ReadOnly = true;
            // 
            // ColumnDevedor
            // 
            ColumnDevedor.FillWeight = 135F;
            ColumnDevedor.HeaderText = "Devedor";
            ColumnDevedor.Name = "ColumnDevedor";
            ColumnDevedor.ReadOnly = true;
            // 
            // ColumnDocDev
            // 
            ColumnDocDev.HeaderText = "Doc. Devedor";
            ColumnDocDev.Name = "ColumnDocDev";
            ColumnDocDev.ReadOnly = true;
            // 
            // ColumnEmail
            // 
            ColumnEmail.HeaderText = "Email";
            ColumnEmail.Name = "ColumnEmail";
            ColumnEmail.ReadOnly = true;
            // 
            // ColumnStatus
            // 
            ColumnStatus.FillWeight = 45F;
            ColumnStatus.HeaderText = "Status da Notificação";
            ColumnStatus.Name = "ColumnStatus";
            ColumnStatus.ReadOnly = true;
            // 
            // tableLayoutPanelBotton
            // 
            tableLayoutPanelBotton.BackColor = SystemColors.Control;
            tableLayoutPanelBotton.ColumnCount = 2;
            tableLayoutPanelBotton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelBotton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelBotton.Controls.Add(chartDist, 1, 0);
            tableLayoutPanelBotton.Controls.Add(panelArq, 0, 0);
            tableLayoutPanelBotton.Dock = DockStyle.Fill;
            tableLayoutPanelBotton.Location = new Point(3, 203);
            tableLayoutPanelBotton.Name = "tableLayoutPanelBotton";
            tableLayoutPanelBotton.RowCount = 1;
            tableLayoutPanelBotton.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelBotton.Size = new Size(774, 194);
            tableLayoutPanelBotton.TabIndex = 1;
            // 
            // chartDist
            // 
            chartDist.BackColor = SystemColors.Control;
            chartDist.BorderlineColor = SystemColors.Control;
            chartArea1.BackColor = SystemColors.Control;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            chartArea1.Name = "ChartArea1";
            chartDist.ChartAreas.Add(chartArea1);
            chartDist.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartDist.Legends.Add(legend1);
            chartDist.Location = new Point(390, 3);
            chartDist.Name = "chartDist";
            chartDist.Padding = new Padding(0, 0, 0, 5);
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartDist.Series.Add(series1);
            chartDist.Size = new Size(381, 188);
            chartDist.TabIndex = 1;
            chartDist.Text = " ";
            // 
            // panelArq
            // 
            panelArq.BackColor = Color.SlateGray;
            panelArq.Controls.Add(dataGridViewImports);
            panelArq.Dock = DockStyle.Fill;
            panelArq.Location = new Point(3, 3);
            panelArq.Name = "panelArq";
            panelArq.Size = new Size(381, 188);
            panelArq.TabIndex = 0;
            // 
            // dataGridViewImports
            // 
            dataGridViewImports.AllowUserToAddRows = false;
            dataGridViewImports.BackgroundColor = SystemColors.Control;
            dataGridViewImports.BorderStyle = BorderStyle.None;
            dataGridViewImports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewImports.Columns.AddRange(new DataGridViewColumn[] { ColumnArquivo, ColumnDataImport, ColumnUser, ColumnStatusArquivo });
            dataGridViewImports.Dock = DockStyle.Fill;
            dataGridViewImports.Location = new Point(0, 0);
            dataGridViewImports.Name = "dataGridViewImports";
            dataGridViewImports.ReadOnly = true;
            dataGridViewImports.Size = new Size(381, 188);
            dataGridViewImports.TabIndex = 0;
            // 
            // ColumnArquivo
            // 
            ColumnArquivo.HeaderText = "Arquivo";
            ColumnArquivo.Name = "ColumnArquivo";
            ColumnArquivo.ReadOnly = true;
            // 
            // ColumnDataImport
            // 
            ColumnDataImport.HeaderText = "Importação";
            ColumnDataImport.Name = "ColumnDataImport";
            ColumnDataImport.ReadOnly = true;
            // 
            // ColumnUser
            // 
            ColumnUser.HeaderText = "Importado por";
            ColumnUser.Name = "ColumnUser";
            ColumnUser.ReadOnly = true;
            // 
            // ColumnStatusArquivo
            // 
            ColumnStatusArquivo.FillWeight = 50F;
            ColumnStatusArquivo.HeaderText = "Status do Upload";
            ColumnStatusArquivo.Name = "ColumnStatusArquivo";
            ColumnStatusArquivo.ReadOnly = true;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(labelHome);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 25);
            panelHeader.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(      64,       64,       64);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point,    0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(3, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(200, 40);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "ATUALIZAR";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelHeader);
            Controls.Add(panelHome);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormHome";
            Text = "FormHome";
            panelHome.ResumeLayout(false);
            mainTableLayoutPanel.ResumeLayout(false);
            tableLayoutPanelTop.ResumeLayout(false);
            panel3.ResumeLayout(false);
            flowLayoutPanel.ResumeLayout(false);
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewProtesto ).EndInit();
            tableLayoutPanelBotton.ResumeLayout(false);
            ( ( System.ComponentModel.ISupportInitialize ) chartDist ).EndInit();
            panelArq.ResumeLayout(false);
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewImports ).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelHome;
        private Panel panelHome;
        private Panel panelHeader;
        private TableLayoutPanel tableLayoutPanelTop; // Mude de Panel para TableLayoutPanel
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanelBotton;
        private Panel panelArq;
        private Button btnImport;
        private FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDist;
        private TableLayoutPanel mainTableLayoutPanel;
        private DataGridView dataGridViewProtesto;
        private DataGridView dataGridViewImports;
        private DataGridViewTextBoxColumn ColumnDataDist;
        private DataGridViewTextBoxColumn ColumnNumDist;
        private DataGridViewTextBoxColumn ColumnDevedor;
        private DataGridViewTextBoxColumn ColumnDocDev;
        private DataGridViewTextBoxColumn ColumnEmail;
        private DataGridViewTextBoxColumn ColumnStatus;
        private DataGridViewTextBoxColumn ColumnArquivo;
        private DataGridViewTextBoxColumn ColumnDataImport;
        private DataGridViewTextBoxColumn ColumnUser;
        private DataGridViewTextBoxColumn ColumnStatusArquivo;
        private Button btnRefresh;
    }
}
