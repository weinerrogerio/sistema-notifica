namespace SistemaNotifica.src.Forms.Principal.ConfigMenu
{
    partial class UC_TrackingEmailService
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            label2 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            textBox1 = new TextBox();
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label4 = new Label();
            textBox2 = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(851, 392);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 0, 3);
            tableLayoutPanel2.Controls.Add(label3, 0, 1);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1, 0, 2);
            tableLayoutPanel2.Controls.Add(panel1, 0, 4);
            tableLayoutPanel2.Location = new Point(111, 0);
            tableLayoutPanel2.Margin = new Padding(0, 0, 0, 20);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 45.7516327F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 54.2483673F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(629, 287);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(73, 104);
            label3.Margin = new Padding(3, 8, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(483, 15);
            label3.TabIndex = 3;
            label3.Text = "Insira abaixo as informações: variáveis ambiente de serviço com tracking externo (brevo,...)";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(207, 30);
            label2.Margin = new Padding(3, 8, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(215, 15);
            label2.TabIndex = 2;
            label2.Text = "Configurações Serviço de envio externo";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 148);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(629, 38);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 7);
            label1.Margin = new Padding(3, 7, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 0;
            label1.Text = "Chave do Serviço: ";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Location = new Point(113, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(504, 23);
            textBox1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(200, 240);
            panel1.Name = "panel1";
            panel1.Size = new Size(228, 35);
            panel1.TabIndex = 12;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Right;
            button2.Location = new Point(121, 0);
            button2.Name = "button2";
            button2.Size = new Size(107, 35);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Left;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(115, 35);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label4);
            flowLayoutPanel2.Controls.Add(textBox2);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 186);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(629, 42);
            flowLayoutPanel2.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 7);
            label4.Margin = new Padding(3, 7, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(96, 15);
            label4.TabIndex = 0;
            label4.Text = "Email remetente:";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.None;
            textBox2.Location = new Point(105, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(323, 23);
            textBox2.TabIndex = 1;
            // 
            // UC_TrackingEmailService
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UC_TrackingEmailService";
            Size = new Size(851, 392);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label3;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private TextBox textBox1;
        private Panel panel1;
        private Button button2;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label4;
        private TextBox textBox2;
    }
}
