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
            components = new System.ComponentModel.Container();
            tableLayoutPanel = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            labelField1 = new Label();
            textBoxField1 = new TextBox();
            labelField2 = new Label();
            textBoxField2 = new TextBox();
            labelField3 = new Label();
            textBoxField3 = new TextBox();
            flowLayoutPanelOptions = new FlowLayoutPanel();
            labelFieldSelected = new Label();
            comboBoxOptions = new ComboBox();
            buttonLimparFiltros = new Button();
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
            _filterTimer = new System.Windows.Forms.Timer(components);
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
            flowLayoutPanel2.Controls.Add(textBoxField1);
            flowLayoutPanel2.Controls.Add(labelField2);
            flowLayoutPanel2.Controls.Add(textBoxField2);
            flowLayoutPanel2.Controls.Add(labelField3);
            flowLayoutPanel2.Controls.Add(textBoxField3);
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
            // textBoxField1
            // 
            textBoxField1.Location = new Point(65, 6);
            textBoxField1.Name = "textBoxField1";
            textBoxField1.Size = new Size(280, 23);
            textBoxField1.TabIndex = 1;
            textBoxField1.TextChanged +=  textBoxField1_TextChanged ;
            textBoxField1.KeyDown +=  textBoxField1_KeyDown ;
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
            textBoxField2.TextChanged +=  textBoxField2_TextChanged ;
            textBoxField2.KeyDown +=  textBoxField2_KeyDown ;
            // 
            // labelField3
            // 
            labelField3.AutoSize = true;
            labelField3.Location = new Point(589, 11);
            labelField3.Margin = new Padding(3, 8, 3, 3);
            labelField3.Name = "labelField3";
            labelField3.Size = new Size(56, 15);
            labelField3.TabIndex = 4;
            labelField3.Text = "campo3: ";
            // 
            // textBoxField3
            // 
            textBoxField3.Location = new Point(651, 6);
            textBoxField3.Name = "textBoxField3";
            textBoxField3.Size = new Size(170, 23);
            textBoxField3.TabIndex = 5;
            textBoxField3.TextChanged +=  textBoxField3_TextChanged ;
            textBoxField3.KeyDown +=  textBoxField3_KeyDown ;
            // 
            // flowLayoutPanelOptions
            // 
            flowLayoutPanelOptions.AutoSize = true;
            flowLayoutPanelOptions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelOptions.Controls.Add(labelFieldSelected);
            flowLayoutPanelOptions.Controls.Add(comboBoxOptions);
            flowLayoutPanelOptions.Controls.Add(buttonLimparFiltros);
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
            // comboBoxOptions
            // 
            comboBoxOptions.FormattingEnabled = true;
            comboBoxOptions.Items.AddRange(new object[] { "Distribuição/Apontamento", "Apontamento e Data apontamento", "CPF ou CNPJ do Devedor", "CPF ou CNPJ do Devedor e Data do protocolo", "Nome do devedor", "CPF ou CNPJ do Credor", "Numero do Titulo", "Numero do Titulo e Data de Distribuição", "Numero do Titulo e Vencimento" });
            comboBoxOptions.Location = new Point(64, 6);
            comboBoxOptions.Name = "comboBoxOptions";
            comboBoxOptions.Size = new Size(381, 23);
            comboBoxOptions.TabIndex = 2;
            // 
            // buttonLimparFiltros
            // 
            buttonLimparFiltros.Location = new Point(448, 3);
            buttonLimparFiltros.Margin = new Padding(0);
            buttonLimparFiltros.Name = "buttonLimparFiltros";
            buttonLimparFiltros.Size = new Size(146, 30);
            buttonLimparFiltros.TabIndex = 3;
            buttonLimparFiltros.Text = "Limpar filtros";
            buttonLimparFiltros.UseVisualStyleBackColor = true;
            buttonLimparFiltros.Click +=  buttonLimparFiltros_Click ;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(594, 3);
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
            dataGridViewProtesto.AllowUserToOrderColumns = true;
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
            // _filterTimer
            // 
            _filterTimer.Interval = 300;
            _filterTimer.Tick +=  _filterTimer_Tick ;
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
        private TextBox textBoxField1;
        private Label labelField2;
        private TextBox textBoxField2;
        private Label labelField3;
        private TextBox textBoxField3;
        private FlowLayoutPanel flowLayoutPanelOptions;
        private Label labelFieldSelected;
        private ComboBox comboBoxOptions;
        private Button buttonLimparFiltros;
        private Button buttonRefresh;
        private System.Windows.Forms.Timer _filterTimer;
    }
}