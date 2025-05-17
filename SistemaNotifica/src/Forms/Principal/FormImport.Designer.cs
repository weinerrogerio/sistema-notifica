namespace SistemaNotifica.src.Forms.Principal
{
    partial class FormImport
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
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            btnSelecArquivo = new Button();
            txtFilePath = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(400, 30);
            label1.Name = "label1";
            label1.Size = new Size(155, 20);
            label1.TabIndex = 0;
            label1.Text = "IMPORTAR ARQUIVOS";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSelecArquivo
            // 
            btnSelecArquivo.Location = new Point(564, 133);
            btnSelecArquivo.Name = "btnSelecArquivo";
            btnSelecArquivo.Size = new Size(144, 29);
            btnSelecArquivo.TabIndex = 1;
            btnSelecArquivo.Text = "Selecionar arquivo";
            btnSelecArquivo.UseVisualStyleBackColor = true;
            btnSelecArquivo.Click += btnSelecionarArquivo_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(714, 133);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(144, 29);
            txtFilePath.TabIndex = 2;
            txtFilePath.Text = "Importar";
            txtFilePath.UseVisualStyleBackColor = true;
            txtFilePath.Click += btnImportar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Location = new Point(74, 136);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 3;
            label2.Text = "Arquivo:";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(144, 133);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(414, 27);
            textBox1.TabIndex = 4;
            textBox1.Click += btnSelecionarArquivo_Click;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(74, 183);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(784, 364);
            listBox1.TabIndex = 5;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // FormImport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1330, 855);
            Controls.Add(listBox1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(txtFilePath);
            Controls.Add(btnSelecArquivo);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormImport";
            Text = "FormImport";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private OpenFileDialog openFileDialog1;
        private Button btnSelecArquivo;
        private Button txtFilePath;
        private Label label2;
        private TextBox textBox1;
        private ListBox listBox1;
    }
}