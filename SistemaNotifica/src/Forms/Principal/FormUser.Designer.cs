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
<<<<<<< HEAD
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
=======
            campoNome = new TextBox();
            campoContato = new TextBox();
            campoEndereco = new TextBox();
            campoConfSenha = new TextBox();
            campoSenha = new TextBox();
            campoEmail = new TextBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            lblNome = new Label();
            lblSenha = new Label();
            lblEndereco = new Label();
            lblEmail = new Label();
            lblContato = new Label();
            lblConfSenha = new Label();
            dataGridView1 = new DataGridView();
            Nome = new DataGridViewTextBoxColumn();
            Contato = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Endereco = new DataGridViewTextBoxColumn();
            btnEditarUser = new Button();
            btnSalvarEdicao = new Button();
            btnCancelarEdicao = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
<<<<<<< HEAD
            label2.BackColor = Color.White;
            label2.Location = new Point(549, 9);
            label2.Name = "label2";
            label2.Size = new Size(147, 15);
=======
            label2.BackColor = SystemColors.Control;
            label2.Location = new Point(382, 27);
            label2.Name = "label2";
            label2.Size = new Size(188, 20);
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
            label2.TabIndex = 2;
            label2.Text = "USUÁRIOS CADASTRADOS";
            // 
            // btnCadUser
            // 
<<<<<<< HEAD
            btnCadUser.Location = new Point(357, 365);
            btnCadUser.Margin = new Padding(3, 2, 3, 2);
            btnCadUser.Name = "btnCadUser";
            btnCadUser.Size = new Size(255, 22);
=======
            btnCadUser.Location = new Point(745, 135);
            btnCadUser.Name = "btnCadUser";
            btnCadUser.Size = new Size(236, 29);
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
            btnCadUser.TabIndex = 4;
            btnCadUser.Text = "CADASTRAR NOVO USUÁRIO";
            btnCadUser.UseVisualStyleBackColor = true;
            btnCadUser.Click += btnCadUser_Click;
            // 
<<<<<<< HEAD
            // btnSalvar
            // 
            btnSalvar.Location = new Point(357, 391);
            btnSalvar.Margin = new Padding(3, 2, 3, 2);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(255, 22);
            btnSalvar.TabIndex = 11;
            btnSalvar.Text = "SALVAR";
=======
            // campoNome
            // 
            campoNome.Location = new Point(382, 135);
            campoNome.Name = "campoNome";
            campoNome.Size = new Size(171, 27);
            campoNome.TabIndex = 5;
            // 
            // campoContato
            // 
            campoContato.Location = new Point(382, 183);
            campoContato.Name = "campoContato";
            campoContato.Size = new Size(171, 27);
            campoContato.TabIndex = 6;
            // 
            // campoEndereco
            // 
            campoEndereco.Location = new Point(382, 281);
            campoEndereco.Name = "campoEndereco";
            campoEndereco.Size = new Size(171, 27);
            campoEndereco.TabIndex = 7;
            // 
            // campoConfSenha
            // 
            campoConfSenha.Location = new Point(382, 381);
            campoConfSenha.Name = "campoConfSenha";
            campoConfSenha.Size = new Size(171, 27);
            campoConfSenha.TabIndex = 8;
            // 
            // campoSenha
            // 
            campoSenha.Location = new Point(382, 330);
            campoSenha.Name = "campoSenha";
            campoSenha.Size = new Size(171, 27);
            campoSenha.TabIndex = 9;
            // 
            // campoEmail
            // 
            campoEmail.Location = new Point(382, 232);
            campoEmail.Name = "campoEmail";
            campoEmail.Size = new Size(171, 27);
            campoEmail.TabIndex = 10;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(419, 428);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 29);
            btnSalvar.TabIndex = 11;
            btnSalvar.Text = "Salvar";
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
<<<<<<< HEAD
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
=======
            btnCancelar.Location = new Point(419, 463);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(388, 116);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(50, 20);
            lblNome.TabIndex = 13;
            lblNome.Text = "Nome";
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(388, 311);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(49, 20);
            lblSenha.TabIndex = 14;
            lblSenha.Text = "Senha";
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.Location = new Point(388, 262);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(71, 20);
            lblEndereco.TabIndex = 15;
            lblEndereco.Text = "Endereco";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(388, 213);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(52, 20);
            lblEmail.TabIndex = 16;
            lblEmail.Text = "E-mail";
            // 
            // lblContato
            // 
            lblContato.AutoSize = true;
            lblContato.Location = new Point(388, 165);
            lblContato.Name = "lblContato";
            lblContato.Size = new Size(62, 20);
            lblContato.TabIndex = 17;
            lblContato.Text = "Contato";
            // 
            // lblConfSenha
            // 
            lblConfSenha.AutoSize = true;
            lblConfSenha.Location = new Point(388, 360);
            lblConfSenha.Name = "lblConfSenha";
            lblConfSenha.Size = new Size(124, 20);
            lblConfSenha.TabIndex = 19;
            lblConfSenha.Text = "Confirme a senha";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Nome, Contato, Email, Endereco });
            dataGridView1.Location = new Point(184, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(555, 354);
            dataGridView1.TabIndex = 20;
            // 
            // Nome
            // 
            Nome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nome.HeaderText = "Nome:";
            Nome.MinimumWidth = 6;
            Nome.Name = "Nome";
            // 
            // Contato
            // 
            Contato.HeaderText = "Contato:";
            Contato.MinimumWidth = 6;
            Contato.Name = "Contato";
            Contato.Width = 125;
            // 
            // Email
            // 
            Email.HeaderText = "E-mail:";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.Width = 125;
            // 
            // Endereco
            // 
            Endereco.HeaderText = "Endereço:";
            Endereco.MinimumWidth = 6;
            Endereco.Name = "Endereco";
            Endereco.Width = 125;
            // 
            // btnEditarUser
            // 
            btnEditarUser.Location = new Point(745, 181);
            btnEditarUser.Name = "btnEditarUser";
            btnEditarUser.Size = new Size(236, 29);
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
            btnEditarUser.TabIndex = 21;
            btnEditarUser.Text = "EDITAR USUARIO";
            btnEditarUser.UseVisualStyleBackColor = true;
            btnEditarUser.Click += btnEditarUser_Click;
            // 
<<<<<<< HEAD
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
=======
            // btnSalvarEdicao
            // 
            btnSalvarEdicao.Location = new Point(745, 216);
            btnSalvarEdicao.Name = "btnSalvarEdicao";
            btnSalvarEdicao.Size = new Size(236, 29);
            btnSalvarEdicao.TabIndex = 22;
            btnSalvarEdicao.Text = "SALVAR EDICAO";
            btnSalvarEdicao.UseVisualStyleBackColor = true;
            btnSalvarEdicao.Click += btnSalvarEdicao_Click;
            // 
            // btnCancelarEdicao
            // 
            btnCancelarEdicao.Location = new Point(745, 251);
            btnCancelarEdicao.Name = "btnCancelarEdicao";
            btnCancelarEdicao.Size = new Size(234, 29);
            btnCancelarEdicao.TabIndex = 23;
            btnCancelarEdicao.Text = "CANCELAR";
            btnCancelarEdicao.UseVisualStyleBackColor = true;
            btnCancelarEdicao.Click += btnCancelarEdicao_Click;
            // 
            // FormUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1330, 855);
            Controls.Add(btnCancelarEdicao);
            Controls.Add(btnSalvarEdicao);
            Controls.Add(btnEditarUser);
            Controls.Add(dataGridView1);
            Controls.Add(lblConfSenha);
            Controls.Add(lblContato);
            Controls.Add(lblEmail);
            Controls.Add(lblEndereco);
            Controls.Add(lblSenha);
            Controls.Add(lblNome);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(campoEmail);
            Controls.Add(campoSenha);
            Controls.Add(campoConfSenha);
            Controls.Add(campoEndereco);
            Controls.Add(campoContato);
            Controls.Add(campoNome);
            Controls.Add(btnCadUser);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormUser";
            Text = "FormUser";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Button btnCadUser;
<<<<<<< HEAD
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
=======
        private TextBox campoNome;
        private TextBox campoContato;
        private TextBox campoEndereco;
        private TextBox campoConfSenha;
        private TextBox campoSenha;
        private TextBox campoEmail;
        private Button btnSalvar;
        private Button btnCancelar;
        private Label lblNome;
        private Label lblSenha;
        private Label lblEndereco;
        private Label lblEmail;
        private Label lblContato;
        private Label lblConfSenha;
        private DataGridView dataGridView1;
        private Button btnEditarUser;
        private Button btnSalvarEdicao;
        private Button btnCancelarEdicao;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Contato;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Endereco;
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
    }
}