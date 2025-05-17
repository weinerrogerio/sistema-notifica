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
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Location = new Point(382, 27);
            label2.Name = "label2";
            label2.Size = new Size(188, 20);
            label2.TabIndex = 2;
            label2.Text = "USUÁRIOS CADASTRADOS";
            // 
            // btnCadUser
            // 
            btnCadUser.Location = new Point(745, 135);
            btnCadUser.Name = "btnCadUser";
            btnCadUser.Size = new Size(236, 29);
            btnCadUser.TabIndex = 4;
            btnCadUser.Text = "CADASTRAR NOVO USUÁRIO";
            btnCadUser.UseVisualStyleBackColor = true;
            btnCadUser.Click += btnCadUser_Click;
            // 
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
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
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
            btnEditarUser.TabIndex = 21;
            btnEditarUser.Text = "EDITAR USUARIO";
            btnEditarUser.UseVisualStyleBackColor = true;
            btnEditarUser.Click += btnEditarUser_Click;
            // 
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Button btnCadUser;
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
    }
}