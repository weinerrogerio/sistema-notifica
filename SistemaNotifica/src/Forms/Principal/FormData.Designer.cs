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
            tableLayoutPanel1 = new TableLayoutPanel();
            dataGridViewProtesto = new DataGridView();
            ColumnId = new DataGridViewTextBoxColumn();
            ColumnDataApresentacao = new DataGridViewTextBoxColumn();
            ColumnDataDistribuicao = new DataGridViewTextBoxColumn();
            ColumnNumDistribuicao = new DataGridViewTextBoxColumn();
            ColumnCartProtesto = new DataGridViewTextBoxColumn();
            ColumnNumTitulo = new DataGridViewTextBoxColumn();
            ColumnValor = new DataGridViewTextBoxColumn();
            ColumnSaldo = new DataGridViewTextBoxColumn();
            ColumnVencimento = new DataGridViewTextBoxColumn();
            ColumNomeDevedor = new DataGridViewTextBoxColumn();
            ColumnDocDevedor = new DataGridViewTextBoxColumn();
            ColumnNomeApresentante = new DataGridViewTextBoxColumn();
            ColumnCodApresentante = new DataGridViewTextBoxColumn();
            ColumnSacador = new DataGridViewTextBoxColumn();
            ColumnCedente = new DataGridViewTextBoxColumn();
            ColumnDocCredor = new DataGridViewTextBoxColumn();
            ColumnEmailEnviado = new DataGridViewTextBoxColumn();
            ColumnDataEnvio = new DataGridViewTextBoxColumn();
            nome_arquivo = new DataGridViewTextBoxColumn();
            file_data_importacao = new DataGridViewTextBoxColumn();
            tableLayoutPanel1.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewProtesto ).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(dataGridViewProtesto, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.8888893F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 85.1111145F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridViewProtesto
            // 
            dataGridViewProtesto.AllowUserToAddRows = false;
            dataGridViewProtesto.AllowUserToDeleteRows = false;
            dataGridViewProtesto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProtesto.Columns.AddRange(new DataGridViewColumn[] { ColumnId, ColumnDataApresentacao, ColumnDataDistribuicao, ColumnNumDistribuicao, ColumnCartProtesto, ColumnNumTitulo, ColumnValor, ColumnSaldo, ColumnVencimento, ColumNomeDevedor, ColumnDocDevedor, ColumnNomeApresentante, ColumnCodApresentante, ColumnSacador, ColumnCedente, ColumnDocCredor, ColumnEmailEnviado, ColumnDataEnvio, nome_arquivo, file_data_importacao });
            dataGridViewProtesto.Dock = DockStyle.Fill;
            dataGridViewProtesto.Location = new Point(3, 70);
            dataGridViewProtesto.Name = "dataGridViewProtesto";
            dataGridViewProtesto.Size = new Size(794, 377);
            dataGridViewProtesto.TabIndex = 0;
            // 
            // ColumnId
            // 
            ColumnId.HeaderText = "ColumnId";
            ColumnId.Name = "ColumnId";
            ColumnId.Visible = false;
            // 
            // ColumnDataApresentacao
            // 
            ColumnDataApresentacao.HeaderText = "Data";
            ColumnDataApresentacao.Name = "ColumnDataApresentacao";
            // 
            // ColumnDataDistribuicao
            // 
            ColumnDataDistribuicao.HeaderText = "Data Distribuicao";
            ColumnDataDistribuicao.Name = "ColumnDataDistribuicao";
            // 
            // ColumnNumDistribuicao
            // 
            ColumnNumDistribuicao.HeaderText = "Distribuicao";
            ColumnNumDistribuicao.Name = "ColumnNumDistribuicao";
            // 
            // ColumnCartProtesto
            // 
            ColumnCartProtesto.HeaderText = "Cartório";
            ColumnCartProtesto.Name = "ColumnCartProtesto";
            // 
            // ColumnNumTitulo
            // 
            ColumnNumTitulo.HeaderText = "Num. Titulo";
            ColumnNumTitulo.Name = "ColumnNumTitulo";
            // 
            // ColumnValor
            // 
            ColumnValor.HeaderText = "Valor";
            ColumnValor.Name = "ColumnValor";
            // 
            // ColumnSaldo
            // 
            ColumnSaldo.HeaderText = "Saldo";
            ColumnSaldo.Name = "ColumnSaldo";
            // 
            // ColumnVencimento
            // 
            ColumnVencimento.HeaderText = "Vencimento";
            ColumnVencimento.Name = "ColumnVencimento";
            // 
            // ColumNomeDevedor
            // 
            ColumNomeDevedor.HeaderText = "Devedor";
            ColumNomeDevedor.Name = "ColumNomeDevedor";
            // 
            // ColumnDocDevedor
            // 
            ColumnDocDevedor.HeaderText = "Doc. Devedor";
            ColumnDocDevedor.Name = "ColumnDocDevedor";
            // 
            // ColumnNomeApresentante
            // 
            ColumnNomeApresentante.HeaderText = "Apresentante";
            ColumnNomeApresentante.Name = "ColumnNomeApresentante";
            // 
            // ColumnCodApresentante
            // 
            ColumnCodApresentante.HeaderText = "Cod. Apresentante";
            ColumnCodApresentante.Name = "ColumnCodApresentante";
            ColumnCodApresentante.ReadOnly = true;
            // 
            // ColumnSacador
            // 
            ColumnSacador.HeaderText = "Sacador";
            ColumnSacador.Name = "ColumnSacador";
            // 
            // ColumnCedente
            // 
            ColumnCedente.HeaderText = "Cedente";
            ColumnCedente.Name = "ColumnCedente";
            // 
            // ColumnDocCredor
            // 
            ColumnDocCredor.HeaderText = "Doc. Credor";
            ColumnDocCredor.Name = "ColumnDocCredor";
            ColumnDocCredor.ReadOnly = true;
            // 
            // ColumnEmailEnviado
            // 
            ColumnEmailEnviado.HeaderText = "Notificação Enviada";
            ColumnEmailEnviado.Name = "ColumnEmailEnviado";
            // 
            // ColumnDataEnvio
            // 
            ColumnDataEnvio.HeaderText = "Data Envio";
            ColumnDataEnvio.Name = "ColumnDataEnvio";
            // 
            // nome_arquivo
            // 
            nome_arquivo.HeaderText = "Arquivo";
            nome_arquivo.Name = "nome_arquivo";
            // 
            // file_data_importacao
            // 
            file_data_importacao.HeaderText = "Data Importacao";
            file_data_importacao.Name = "file_data_importacao";
            // 
            // FormData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "FormData";
            Text = "FormData";
            Load +=  FormData_Load ;
            tableLayoutPanel1.ResumeLayout(false);
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewProtesto ).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridViewProtesto;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnDataApresentacao;
        private DataGridViewTextBoxColumn ColumnDataDistribuicao;
        private DataGridViewTextBoxColumn ColumnNumDistribuicao;
        private DataGridViewTextBoxColumn ColumnCartProtesto;
        private DataGridViewTextBoxColumn ColumnNumTitulo;
        private DataGridViewTextBoxColumn ColumnValor;
        private DataGridViewTextBoxColumn ColumnSaldo;
        private DataGridViewTextBoxColumn ColumnVencimento;
        private DataGridViewTextBoxColumn ColumNomeDevedor;
        private DataGridViewTextBoxColumn ColumnDocDevedor;
        private DataGridViewTextBoxColumn ColumnNomeApresentante;
        private DataGridViewTextBoxColumn ColumnCodApresentante;
        private DataGridViewTextBoxColumn ColumnSacador;
        private DataGridViewTextBoxColumn ColumnCedente;
        private DataGridViewTextBoxColumn ColumnDocCredor;
        private DataGridViewTextBoxColumn ColumnEmailEnviado;
        private DataGridViewTextBoxColumn ColumnDataEnvio;
        private DataGridViewTextBoxColumn nome_arquivo;
        private DataGridViewTextBoxColumn file_data_importacao;
    }
}