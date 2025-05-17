namespace SistemaNotifica.src.Forms.Principal
{
    partial class FormData
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
            btnDados2 = new Button();
            btnAbaRelatorios = new Button();
            panelDados = new Panel();
            btnAcaoRelatorio = new Button();
            btnGrafico = new Button();
            viewDist = new DataGridView();
            viewDataDist = new DataGridView();
            viewDocDev = new DataGridView();
            viewDocCred = new DataGridView();
            viewDataImport = new DataGridView();
            lblDist = new Label();
            lblDataDist = new Label();
            lblDocDev = new Label();
            lblDocCred = new Label();
            lblDataImport = new Label();
            ((System.ComponentModel.ISupportInitialize)viewDist).BeginInit();
            ((System.ComponentModel.ISupportInitialize)viewDataDist).BeginInit();
            ((System.ComponentModel.ISupportInitialize)viewDocDev).BeginInit();
            ((System.ComponentModel.ISupportInitialize)viewDocCred).BeginInit();
            ((System.ComponentModel.ISupportInitialize)viewDataImport).BeginInit();
            SuspendLayout();
            // 
            // btnDados2
            // 
            btnDados2.Location = new Point(49, 9);
            btnDados2.Margin = new Padding(3, 4, 3, 4);
            btnDados2.Name = "btnDados2";
            btnDados2.Size = new Size(401, 31);
            btnDados2.TabIndex = 11;
            btnDados2.Text = "DADOS";
            btnDados2.UseVisualStyleBackColor = true;
            btnDados2.Click += btnDados2_Click;
            // 
            // btnAbaRelatorios
            // 
            btnAbaRelatorios.Location = new Point(457, 9);
            btnAbaRelatorios.Margin = new Padding(3, 4, 3, 4);
            btnAbaRelatorios.Name = "btnAbaRelatorios";
            btnAbaRelatorios.Size = new Size(401, 31);
            btnAbaRelatorios.TabIndex = 12;
            btnAbaRelatorios.Text = "RELATÓRIOS";
            btnAbaRelatorios.UseVisualStyleBackColor = true;
            btnAbaRelatorios.Click += btnAbaRelatorios_Click;
            // 
            // panelDados
            // 
            panelDados.BackColor = Color.White;
            panelDados.Location = new Point(49, 141);
            panelDados.Margin = new Padding(3, 4, 3, 4);
            panelDados.Name = "panelDados";
            panelDados.Size = new Size(809, 443);
            panelDados.TabIndex = 13;
            panelDados.Paint += panelDados_Paint;
            // 
            // btnAcaoRelatorio
            // 
            btnAcaoRelatorio.Font = new Font("Segoe UI", 7F);
            btnAcaoRelatorio.Location = new Point(189, 48);
            btnAcaoRelatorio.Margin = new Padding(3, 4, 3, 4);
            btnAcaoRelatorio.Name = "btnAcaoRelatorio";
            btnAcaoRelatorio.Size = new Size(148, 32);
            btnAcaoRelatorio.TabIndex = 1;
            btnAcaoRelatorio.Text = "EXPORTAR RELATORIO";
            btnAcaoRelatorio.UseVisualStyleBackColor = true;
            // 
            // btnGrafico
            // 
            btnGrafico.Font = new Font("Segoe UI", 7F);
            btnGrafico.Location = new Point(49, 48);
            btnGrafico.Margin = new Padding(3, 4, 3, 4);
            btnGrafico.Name = "btnGrafico";
            btnGrafico.Size = new Size(133, 32);
            btnGrafico.TabIndex = 0;
            btnGrafico.Text = "GERAR GRAFICO";
            btnGrafico.UseVisualStyleBackColor = true;
            // 
            // viewDist
            // 
            viewDist.BackgroundColor = Color.White;
            viewDist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewDist.Location = new Point(49, 104);
            viewDist.Margin = new Padding(3, 4, 3, 4);
            viewDist.Name = "viewDist";
            viewDist.RowHeadersWidth = 51;
            viewDist.Size = new Size(165, 29);
            viewDist.TabIndex = 14;
            // 
            // viewDataDist
            // 
            viewDataDist.BackgroundColor = Color.White;
            viewDataDist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewDataDist.Location = new Point(221, 104);
            viewDataDist.Margin = new Padding(3, 4, 3, 4);
            viewDataDist.Name = "viewDataDist";
            viewDataDist.RowHeadersWidth = 51;
            viewDataDist.Size = new Size(154, 29);
            viewDataDist.TabIndex = 15;
            // 
            // viewDocDev
            // 
            viewDocDev.BackgroundColor = Color.White;
            viewDocDev.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewDocDev.Location = new Point(382, 104);
            viewDocDev.Margin = new Padding(3, 4, 3, 4);
            viewDocDev.Name = "viewDocDev";
            viewDocDev.RowHeadersWidth = 51;
            viewDocDev.Size = new Size(154, 29);
            viewDocDev.TabIndex = 16;
            // 
            // viewDocCred
            // 
            viewDocCred.BackgroundColor = Color.White;
            viewDocCred.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewDocCred.Location = new Point(543, 104);
            viewDocCred.Margin = new Padding(3, 4, 3, 4);
            viewDocCred.Name = "viewDocCred";
            viewDocCred.RowHeadersWidth = 51;
            viewDocCred.Size = new Size(154, 29);
            viewDocCred.TabIndex = 17;
            viewDocCred.CellContentClick += dataGridView4_CellContentClick;
            // 
            // viewDataImport
            // 
            viewDataImport.BackgroundColor = Color.White;
            viewDataImport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewDataImport.Location = new Point(704, 104);
            viewDataImport.Margin = new Padding(3, 4, 3, 4);
            viewDataImport.Name = "viewDataImport";
            viewDataImport.RowHeadersWidth = 51;
            viewDataImport.Size = new Size(154, 29);
            viewDataImport.TabIndex = 18;
            // 
            // lblDist
            // 
            lblDist.AutoSize = true;
            lblDist.Font = new Font("Segoe UI", 7F);
            lblDist.Location = new Point(49, 84);
            lblDist.Name = "lblDist";
            lblDist.Size = new Size(84, 15);
            lblDist.TabIndex = 19;
            lblDist.Text = "DITRISBUIÇÃO";
            // 
            // lblDataDist
            // 
            lblDataDist.AutoSize = true;
            lblDataDist.Font = new Font("Segoe UI", 7F);
            lblDataDist.Location = new Point(221, 84);
            lblDataDist.Name = "lblDataDist";
            lblDataDist.Size = new Size(116, 15);
            lblDataDist.TabIndex = 20;
            lblDataDist.Text = "DATA DISTRIBUIÇÃO";
            // 
            // lblDocDev
            // 
            lblDocDev.AutoSize = true;
            lblDocDev.Font = new Font("Segoe UI", 7F);
            lblDocDev.Location = new Point(382, 84);
            lblDocDev.Name = "lblDocDev";
            lblDocDev.Size = new Size(86, 15);
            lblDocDev.TabIndex = 21;
            lblDocDev.Text = "DOC DEVEDOR";
            // 
            // lblDocCred
            // 
            lblDocCred.AutoSize = true;
            lblDocCred.Font = new Font("Segoe UI", 7F);
            lblDocCred.Location = new Point(543, 84);
            lblDocCred.Name = "lblDocCred";
            lblDocCred.Size = new Size(80, 15);
            lblDocCred.TabIndex = 22;
            lblDocCred.Text = "DOC CREDOR";
            // 
            // lblDataImport
            // 
            lblDataImport.AutoSize = true;
            lblDataImport.Font = new Font("Segoe UI", 7F);
            lblDataImport.Location = new Point(704, 84);
            lblDataImport.Name = "lblDataImport";
            lblDataImport.Size = new Size(133, 15);
            lblDataImport.TabIndex = 23;
            lblDataImport.Text = "DATA DA IMPORTAÇÃO";
            // 
            // FormData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1330, 855);
            Controls.Add(btnAcaoRelatorio);
            Controls.Add(btnGrafico);
            Controls.Add(lblDataImport);
            Controls.Add(lblDocCred);
            Controls.Add(lblDocDev);
            Controls.Add(lblDataDist);
            Controls.Add(lblDist);
            Controls.Add(viewDataImport);
            Controls.Add(viewDocCred);
            Controls.Add(viewDocDev);
            Controls.Add(viewDataDist);
            Controls.Add(viewDist);
            Controls.Add(panelDados);
            Controls.Add(btnAbaRelatorios);
            Controls.Add(btnDados2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormData";
            Text = "FormData";
            ((System.ComponentModel.ISupportInitialize)viewDist).EndInit();
            ((System.ComponentModel.ISupportInitialize)viewDataDist).EndInit();
            ((System.ComponentModel.ISupportInitialize)viewDocDev).EndInit();
            ((System.ComponentModel.ISupportInitialize)viewDocCred).EndInit();
            ((System.ComponentModel.ISupportInitialize)viewDataImport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnDados2;
        private Button btnAbaRelatorios;
        private Panel panelDados;
        private Button btnAcaoRelatorio;
        private Button btnGrafico;
        private DataGridView viewDist;
        private DataGridView viewDataDist;
        private DataGridView viewDocDev;
        private DataGridView viewDocCred;
        private DataGridView viewDataImport;
        private Label lblDist;
        private Label lblDataDist;
        private Label lblDocDev;
        private Label lblDocCred;
        private Label lblDataImport;
    }
}