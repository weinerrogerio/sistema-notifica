namespace SistemaNotifica.src.FormsTestes
{
    partial class FormTesteLayout
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
            if ( disposing && ( components != null ) )
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
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            comboBox2 = new ComboBox();
            button3 = new Button();
            button4 = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label5 = new Label();
            textBox4 = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 78);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(922, 374);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(922, 452);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(comboBox2);
            flowLayoutPanel1.Controls.Add(button3);
            flowLayoutPanel1.Controls.Add(button4);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(922, 39);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 13);
            label2.Margin = new Padding(3, 8, 3, 3);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 0;
            label2.Text = "Campo: ";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Distribuição/Apontamento", "Apontamento e Data apontamento", "CPF ou CNPJ do Devedor", "CPF ou CNPJ do Devedor e Data do protocolo", "Nome do devedor", "CPF ou CNPJ do Credor", "Numero do Titulo", "Numero do Titulo e Data de Distribuição", "Numero do Titulo e Vencimento" });
            comboBox2.Location = new Point(66, 8);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(381, 23);
            comboBox2.TabIndex = 2;
            // 
            // button3
            // 
            button3.Location = new Point(453, 8);
            button3.Name = "button3";
            button3.Size = new Size(115, 23);
            button3.TabIndex = 3;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(574, 8);
            button4.Name = "button4";
            button4.Size = new Size(100, 23);
            button4.TabIndex = 4;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(label3);
            flowLayoutPanel3.Controls.Add(textBox2);
            flowLayoutPanel3.Controls.Add(label4);
            flowLayoutPanel3.Controls.Add(textBox3);
            flowLayoutPanel3.Controls.Add(label5);
            flowLayoutPanel3.Controls.Add(textBox4);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(0, 39);
            flowLayoutPanel3.Margin = new Padding(0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Padding = new Padding(5);
            flowLayoutPanel3.Size = new Size(922, 39);
            flowLayoutPanel3.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 13);
            label3.Margin = new Padding(3, 8, 3, 3);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 0;
            label3.Text = "campo1:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(67, 8);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(277, 23);
            textBox2.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(350, 13);
            label4.Margin = new Padding(3, 8, 3, 3);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 2;
            label4.Text = "campo2: ";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(412, 8);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(215, 23);
            textBox3.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(633, 13);
            label5.Margin = new Padding(3, 8, 3, 3);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 4;
            label5.Text = "campo2: ";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(695, 8);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(197, 23);
            textBox4.TabIndex = 5;
            // 
            // FormTesteLayout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 452);
            Controls.Add(tableLayoutPanel1);
            Name = "FormTesteLayout";
            Text = "FormTesteLayout";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ResumeLayout(false);
            //AutoScaleDimensions = new SizeF(7F, 15F);
            //AutoScaleMode = AutoScaleMode.Font;
            //ClientSize = new Size(800, 450);
            //Controls.Add(tableLayoutPanel1);
            //Name = "FormTesteLayout";
            //Text = "FormTesteLayout";
            //tableLayoutPanel1.ResumeLayout(false);
            //tableLayoutPanel1.PerformLayout();
            //tableLayoutPanel2.ResumeLayout(false);
            //tableLayoutPanel2.PerformLayout();
            //flowLayoutPanel1.ResumeLayout(false);
            //flowLayoutPanel1.PerformLayout();
            //flowLayoutPanel3.ResumeLayout(false);
            //flowLayoutPanel3.PerformLayout();
            //ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private ComboBox comboBox2;
        private Button button3;
        private Button button4;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
        private Label label5;
        private TextBox textBox4;
    }
}