namespace SistemaNotifica.src.Forms.Principal
{
    partial class FormUser
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
            label2 = new Label();
            btnCadUser = new Button();
            btnSalvar = new Button();
            btnCancelar = new Button();
            btnEditarUser = new Button();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnDelet = new Button();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(549, 9);
            label2.Name = "label2";
            label2.Size = new Size(147, 15);
            label2.TabIndex = 2;
            label2.Text = "USUÁRIOS CADASTRADOS";
            // 
            // btnCadUser
            // 
            btnCadUser.Location = new Point(357, 365);
            btnCadUser.Margin = new Padding(3, 2, 3, 2);
            btnCadUser.Name = "btnCadUser";
            btnCadUser.Size = new Size(255, 22);
            btnCadUser.TabIndex = 4;
            btnCadUser.Text = "CADASTRAR NOVO USUÁRIO";
            btnCadUser.UseVisualStyleBackColor = true;
            btnCadUser.Click += btnCadUser_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(357, 391);
            btnSalvar.Margin = new Padding(3, 2, 3, 2);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(255, 22);
            btnSalvar.TabIndex = 11;
            btnSalvar.Text = "SALVAR";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(624, 391);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(255, 22);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEditarUser
            // 
            btnEditarUser.Location = new Point(624, 365);
            btnEditarUser.Margin = new Padding(3, 2, 3, 2);
            btnEditarUser.Name = "btnEditarUser";
            btnEditarUser.Size = new Size(255, 22);
            btnEditarUser.TabIndex = 21;
            btnEditarUser.Text = "EDITAR USUARIO";
            btnEditarUser.UseVisualStyleBackColor = true;
            btnEditarUser.Click += btnEditarUser_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(357, 169);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(522, 23);
            comboBox1.TabIndex = 24;
            comboBox1.Text = "Selecione um usuário";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(357, 225);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(255, 23);
            textBox1.TabIndex = 25;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(624, 225);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(255, 23);
            textBox2.TabIndex = 26;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(357, 278);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(255, 23);
            textBox3.TabIndex = 27;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(624, 277);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(255, 23);
            textBox4.TabIndex = 28;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(357, 328);
            textBox5.Margin = new Padding(3, 2, 3, 2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(255, 23);
            textBox5.TabIndex = 29;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(624, 328);
            textBox6.Margin = new Padding(3, 2, 3, 2);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(255, 23);
            textBox6.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(357, 208);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 31;
            label1.Text = "Nome completo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(624, 208);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 32;
            label3.Text = "Contato:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(357, 261);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 33;
            label4.Text = "E-mail:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(624, 261);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 34;
            label5.Text = "Endereço:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(357, 312);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 35;
            label6.Text = "Senha";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(357, 312);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 35;
            label7.Text = "Senha";
            // 
            // btnDelet
            // 
            btnDelet.Location = new Point(549, 418);
            btnDelet.Name = "btnDelet";
            btnDelet.Size = new Size(134, 23);
            btnDelet.TabIndex = 37;
            btnDelet.Text = "DELETAR USUARIO";
            btnDelet.UseVisualStyleBackColor = true;
            btnDelet.Click += btnDelet_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(760, 144);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(119, 19);
            checkBox1.TabIndex = 38;
            checkBox1.Text = "Todos os usuários";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // FormUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1164, 591);
            Controls.Add(checkBox1);
            Controls.Add(btnDelet);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(btnEditarUser);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(btnCadUser);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormUser";
            Text = "ga";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Button btnCadUser;
        private Button btnSalvar;
        private Button btnCancelar;
        private Button btnEditarUser;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnDelet;
        private CheckBox checkBox1;
    }
}