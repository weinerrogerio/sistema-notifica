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
            tableLayoutPanel = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            labelField1 = new Label();
            textBoxFiled1 = new TextBox();
            labelField2 = new Label();
            textBoxField2 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            flowLayoutPanelOptions = new FlowLayoutPanel();
            labelFieldSelected = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            buttonRefresh = new Button();
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
            tableLayoutPanel.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanelOptions.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewProtesto ).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel.Controls.Add(flowLayoutPanelOptions, 0, 0);
            tableLayoutPanel.Controls.Add(dataGridViewProtesto, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(927, 489);
            tableLayoutPanel.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(labelField1);
            flowLayoutPanel2.Controls.Add(textBoxFiled1);
            flowLayoutPanel2.Controls.Add(labelField2);
            flowLayoutPanel2.Controls.Add(textBoxField2);
            flowLayoutPanel2.Controls.Add(label1);
            flowLayoutPanel2.Controls.Add(textBox1);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 36);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(3);
            flowLayoutPanel2.Size = new Size(927, 35);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // labelField1
            // 
            labelField1.AutoSize = true;
            labelField1.Location = new Point(6, 11);
            labelField1.Margin = new Padding(3, 8, 3, 3);
            labelField1.Name = "labelField1";
            labelField1.Size = new Size(53, 15);
            labelField1.TabIndex = 0;
            labelField1.Text = "campo1:";
            // 
            // textBoxFiled1
            // 
            textBoxFiled1.Location = new Point(65, 6);
            textBoxFiled1.Name = "textBoxFiled1";
            textBoxFiled1.Size = new Size(280, 23);
            textBoxFiled1.TabIndex = 1;
            // 
            // labelField2
            // 
            labelField2.AutoSize = true;
            labelField2.Location = new Point(351, 11);
            labelField2.Margin = new Padding(3, 8, 3, 3);
            labelField2.Name = "labelField2";
            labelField2.Size = new Size(56, 15);
            labelField2.TabIndex = 2;
            labelField2.Text = "campo2: ";
            // 
            // textBoxField2
            // 
            textBoxField2.Location = new Point(413, 6);
            textBoxField2.Name = "textBoxField2";
            textBoxField2.Size = new Size(170, 23);
            textBoxField2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(589, 11);
            label1.Margin = new Padding(3, 8, 3, 3);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 4;
            label1.Text = "campo2: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(651, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(170, 23);
            textBox1.TabIndex = 5;
            // 
            // flowLayoutPanelOptions
            // 
            flowLayoutPanelOptions.AutoSize = true;
            flowLayoutPanelOptions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelOptions.Controls.Add(labelFieldSelected);
            flowLayoutPanelOptions.Controls.Add(comboBox1);
            flowLayoutPanelOptions.Controls.Add(button1);
            flowLayoutPanelOptions.Controls.Add(buttonRefresh);
            flowLayoutPanelOptions.Dock = DockStyle.Fill;
            flowLayoutPanelOptions.Location = new Point(0, 0);
            flowLayoutPanelOptions.Margin = new Padding(0);
            flowLayoutPanelOptions.Name = "flowLayoutPanelOptions";
            flowLayoutPanelOptions.Padding = new Padding(3);
            flowLayoutPanelOptions.Size = new Size(927, 36);
            flowLayoutPanelOptions.TabIndex = 2;
            // 
            // labelFieldSelected
            // 
            labelFieldSelected.AutoSize = true;
            labelFieldSelected.Location = new Point(6, 11);
            labelFieldSelected.Margin = new Padding(3, 8, 3, 3);
            labelFieldSelected.Name = "labelFieldSelected";
            labelFieldSelected.Size = new Size(52, 15);
            labelFieldSelected.TabIndex = 0;
            labelFieldSelected.Text = "Campo: ";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Distribuição/Apontamento", "Apontamento e Data apontamento", "CPF ou CNPJ do Devedor", "CPF ou CNPJ do Devedor e Data do protocolo", "Nome do devedor", "CPF ou CNPJ do Credor", "Numero do Titulo", "Numero do Titulo e Data de Distribuição", "Numero do Titulo e Vencimento" });
            comboBox1.Location = new Point(64, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(381, 23);
            comboBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(448, 3);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(135, 30);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(583, 3);
            buttonRefresh.Margin = new Padding(0);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(196, 30);
            buttonRefresh.TabIndex = 4;
            buttonRefresh.Text = "Refazer busca e atualizar dados";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click +=  buttonRefresh_Click ;
            // 
            // dataGridViewProtesto
            // 
            dataGridViewProtesto.AllowUserToAddRows = false;
            dataGridViewProtesto.AllowUserToDeleteRows = false;
            dataGridViewProtesto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProtesto.Columns.AddRange(new DataGridViewColumn[] { ColumnId, ColumnDataApresentacao, ColumnDataDistribuicao, ColumnNumDistribuicao, ColumnCartProtesto, ColumnNumTitulo, ColumnValor, ColumnSaldo, ColumnVencimento, ColumNomeDevedor, ColumnDocDevedor, ColumnNomeApresentante, ColumnCodApresentante, ColumnSacador, ColumnCedente, ColumnDocCredor, ColumnEmailEnviado, ColumnDataEnvio, nome_arquivo, file_data_importacao });
            dataGridViewProtesto.Dock = DockStyle.Fill;
            dataGridViewProtesto.Location = new Point(3, 74);
            dataGridViewProtesto.Name = "dataGridViewProtesto";
            dataGridViewProtesto.Size = new Size(921, 412);
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
            ClientSize = new Size(927, 489);
            Controls.Add(tableLayoutPanel);
            Name = "FormData";
            Text = "FormData";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanelOptions.ResumeLayout(false);
            flowLayoutPanelOptions.PerformLayout();
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewProtesto ).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
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
        private FlowLayoutPanel flowLayoutPanel2;
        private Label labelField1;
        private TextBox textBoxFiled1;
        private Label labelField2;
        private TextBox textBoxField2;
        private Label label1;
        private TextBox textBox1;
        private FlowLayoutPanel flowLayoutPanelOptions;
        private Label labelFieldSelected;
        private ComboBox comboBox1;
        private Button button1;
        private Button buttonRefresh;
    }
}