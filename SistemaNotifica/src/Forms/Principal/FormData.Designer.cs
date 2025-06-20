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
            panelRelatorios = new Panel();
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
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)viewDist).BeginInit();
            ((System.ComponentModel.ISupportInitialize)viewDataDist).BeginInit();
            ((System.ComponentModel.ISupportInitialize)viewDocDev).BeginInit();
            ((System.ComponentModel.ISupportInitialize)viewDocCred).BeginInit();
            ((System.ComponentModel.ISupportInitialize)viewDataImport).BeginInit();
            SuspendLayout();
            // 
            // btnDados2
            // 
            btnDados2.BackColor = SystemColors.Control;
            btnDados2.FlatStyle = FlatStyle.Flat;
            btnDados2.Location = new Point(250, 93);
            btnDados2.Name = "btnDados2";
            btnDados2.Size = new Size(351, 23);
            btnDados2.TabIndex = 11;
            btnDados2.Text = "DADOS";
            btnDados2.UseVisualStyleBackColor = false;
            btnDados2.Click += btnDados2_Click;
            // 
            // btnAbaRelatorios
            // 
            btnAbaRelatorios.BackColor = SystemColors.Control;
            btnAbaRelatorios.FlatStyle = FlatStyle.Flat;
            btnAbaRelatorios.Location = new Point(607, 93);
            btnAbaRelatorios.Name = "btnAbaRelatorios";
            btnAbaRelatorios.Size = new Size(351, 23);
            btnAbaRelatorios.TabIndex = 12;
            btnAbaRelatorios.Text = "RELATÓRIOS";
            btnAbaRelatorios.UseVisualStyleBackColor = false;
            btnAbaRelatorios.Click += btnAbaRelatorios_Click;
            // 
            // panelDados
            // 
            panelDados.BackColor = SystemColors.Control;
            panelDados.Location = new Point(250, 192);
            panelDados.Name = "panelDados";
            panelDados.Size = new Size(708, 332);
            panelDados.TabIndex = 13;
            panelDados.Paint += panelDados_Paint;
            // 
            // panelRelatorios
            // 
            panelRelatorios.BackColor = SystemColors.Control;
            panelRelatorios.Location = new Point(250, 195);
            panelRelatorios.Name = "panelRelatorios";
            panelRelatorios.Size = new Size(708, 332);
            panelRelatorios.TabIndex = 14;
            panelRelatorios.Paint += panelRelatorios_Paint;
            // 
            // btnAcaoRelatorio
            // 
            btnAcaoRelatorio.BackColor = SystemColors.Control;
            btnAcaoRelatorio.FlatStyle = FlatStyle.Flat;
            btnAcaoRelatorio.Font = new Font("Segoe UI", 8F);
            btnAcaoRelatorio.Location = new Point(372, 122);
            btnAcaoRelatorio.Name = "btnAcaoRelatorio";
            btnAcaoRelatorio.Size = new Size(130, 24);
            btnAcaoRelatorio.TabIndex = 1;
            btnAcaoRelatorio.Text = "EXPORTAR RELATORIO";
            btnAcaoRelatorio.UseVisualStyleBackColor = false;
            // 
            // btnGrafico
            // 
            btnGrafico.BackColor = SystemColors.Control;
            btnGrafico.FlatStyle = FlatStyle.Flat;
            btnGrafico.Font = new Font("Segoe UI", 8F);
            btnGrafico.Location = new Point(250, 122);
            btnGrafico.Name = "btnGrafico";
            btnGrafico.Size = new Size(116, 24);
            btnGrafico.TabIndex = 0;
            btnGrafico.Text = "GERAR GRAFICO";
            btnGrafico.UseVisualStyleBackColor = false;
            // 
            // viewDist
            // 
            viewDist.BackgroundColor = SystemColors.Control;
            viewDist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewDist.Location = new Point(250, 164);
            viewDist.Name = "viewDist";
            viewDist.RowHeadersWidth = 51;
            viewDist.Size = new Size(144, 22);
            viewDist.TabIndex = 14;
            // 
            // viewDataDist
            // 
            viewDataDist.BackgroundColor = SystemColors.Control;
            viewDataDist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewDataDist.Location = new Point(400, 164);
            viewDataDist.Name = "viewDataDist";
            viewDataDist.RowHeadersWidth = 51;
            viewDataDist.Size = new Size(135, 22);
            viewDataDist.TabIndex = 15;
            // 
            // viewDocDev
            // 
            viewDocDev.BackgroundColor = SystemColors.Control;
            viewDocDev.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewDocDev.Location = new Point(541, 164);
            viewDocDev.Name = "viewDocDev";
            viewDocDev.RowHeadersWidth = 51;
            viewDocDev.Size = new Size(135, 22);
            viewDocDev.TabIndex = 16;
            // 
            // viewDocCred
            // 
            viewDocCred.BackgroundColor = SystemColors.Control;
            viewDocCred.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewDocCred.Location = new Point(682, 164);
            viewDocCred.Name = "viewDocCred";
            viewDocCred.RowHeadersWidth = 51;
            viewDocCred.Size = new Size(135, 22);
            viewDocCred.TabIndex = 17;
            viewDocCred.CellContentClick += dataGridView4_CellContentClick;
            // 
            // viewDataImport
            // 
            viewDataImport.BackgroundColor = SystemColors.Control;
            viewDataImport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewDataImport.Location = new Point(823, 164);
            viewDataImport.Name = "viewDataImport";
            viewDataImport.RowHeadersWidth = 51;
            viewDataImport.Size = new Size(135, 22);
            viewDataImport.TabIndex = 18;
            // 
            // lblDist
            // 
            lblDist.AutoSize = true;
            lblDist.Font = new Font("Segoe UI", 7F);
            lblDist.Location = new Point(250, 149);
            lblDist.Name = "lblDist";
            lblDist.Size = new Size(70, 12);
            lblDist.TabIndex = 19;
            lblDist.Text = "DITRISBUIÇÃO";
            // 
            // lblDataDist
            // 
            lblDataDist.AutoSize = true;
            lblDataDist.Font = new Font("Segoe UI", 7F);
            lblDataDist.Location = new Point(400, 149);
            lblDataDist.Name = "lblDataDist";
            lblDataDist.Size = new Size(95, 12);
            lblDataDist.TabIndex = 20;
            lblDataDist.Text = "DATA DISTRIBUIÇÃO";
            // 
            // lblDocDev
            // 
            lblDocDev.AutoSize = true;
            lblDocDev.Font = new Font("Segoe UI", 7F);
            lblDocDev.Location = new Point(541, 149);
            lblDocDev.Name = "lblDocDev";
            lblDocDev.Size = new Size(73, 12);
            lblDocDev.TabIndex = 21;
            lblDocDev.Text = "DOC DEVEDOR";
            // 
            // lblDocCred
            // 
            lblDocCred.AutoSize = true;
            lblDocCred.Font = new Font("Segoe UI", 7F);
            lblDocCred.Location = new Point(682, 149);
            lblDocCred.Name = "lblDocCred";
            lblDocCred.Size = new Size(67, 12);
            lblDocCred.TabIndex = 22;
            lblDocCred.Text = "DOC CREDOR";
            // 
            // lblDataImport
            // 
            lblDataImport.AutoSize = true;
            lblDataImport.Font = new Font("Segoe UI", 7F);
            lblDataImport.Location = new Point(823, 149);
            lblDataImport.Name = "lblDataImport";
            lblDataImport.Size = new Size(108, 12);
            lblDataImport.TabIndex = 23;
            lblDataImport.Text = "DATA DA IMPORTAÇÃO";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(586, 21);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 24;
            label1.Text = "Tela dados";
            // 
            // FormData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1164, 591);
            Controls.Add(panelRelatorios);
            Controls.Add(label1);
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
        private Label label1;
        private Panel panelRelatorios;
    }
}