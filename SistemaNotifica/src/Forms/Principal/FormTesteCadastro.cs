using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormTesteCadastro : Form
    {
        private TableLayoutPanel mainPanel;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblFone;
        private TextBox txtFone;
        private Label lblSenha;
        private TextBox txtSenha;
        private Label lblConfirmaSenha;
        private TextBox txtConfirmaSenha;
        private System.Windows.Forms.Button btnSalvar;

        private Label lblErrorNome;
        private Label lblErrorEmail;
        private Label lblErrorFone;
        private Label lblErrorSenha;
        private Label lblErrorConfirmaSenha;

        public FormTesteCadastro()
        {
            //InitializeComponents();
            InitializeComponent();
            //ConfigurarFormulario();           
        }

        private void InitializeComponents()
        {
            this.SuspendLayout();

            // Configurações do Form
            this.Text = "Cadastro de Usuário";
            this.Size = new Size(600, 450);
            this.MinimumSize = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);

            this.ResumeLayout(false);
        }

        private void ConfigurarFormulario()
        {
            // Painel principal com TableLayoutPanel para centralizar
            mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 1,
                Padding = new Padding(20)
            };
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Painel interno para os campos
            TableLayoutPanel fieldsPanel = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                RowCount = 11, // Aumentado para acomodar labels de erro
                Anchor = AnchorStyles.None,
                BackColor = Color.White,
                Padding = new Padding(30, 20, 30, 20)
            };

            // Configurar colunas: Label (auto) | TextBox (fixa)
            fieldsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            fieldsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280F));

            // Configurar linhas
            for ( int i = 0; i < 11; i++ )
            {
                fieldsPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            // Criar controles
            CriarControles();

            // Adicionar controles ao painel de campos
            int row = 0;

            // Nome
            fieldsPanel.Controls.Add(lblNome, 0, row);
            fieldsPanel.Controls.Add(txtNome, 1, row++);
            fieldsPanel.Controls.Add(lblErrorNome, 1, row++);

            // Email
            fieldsPanel.Controls.Add(lblEmail, 0, row);
            fieldsPanel.Controls.Add(txtEmail, 1, row++);
            fieldsPanel.Controls.Add(lblErrorEmail, 1, row++);

            // Fone
            fieldsPanel.Controls.Add(lblFone, 0, row);
            fieldsPanel.Controls.Add(txtFone, 1, row++);
            fieldsPanel.Controls.Add(lblErrorFone, 1, row++);

            // Senha
            fieldsPanel.Controls.Add(lblSenha, 0, row);
            fieldsPanel.Controls.Add(txtSenha, 1, row++);
            fieldsPanel.Controls.Add(lblErrorSenha, 1, row++);

            // Confirmar Senha
            fieldsPanel.Controls.Add(lblConfirmaSenha, 0, row);
            fieldsPanel.Controls.Add(txtConfirmaSenha, 1, row++);
            fieldsPanel.Controls.Add(lblErrorConfirmaSenha, 1, row++);

            // Botão (ocupa 2 colunas)
            fieldsPanel.Controls.Add(btnSalvar, 1, row);

            // Adicionar sombra ao painel (efeito visual)
            fieldsPanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, fieldsPanel.ClientRectangle,
                    Color.FromArgb(200, 200, 200), ButtonBorderStyle.Solid);
            };

            mainPanel.Controls.Add(fieldsPanel, 0, 0);
            this.Controls.Add(mainPanel);
        }

        private void CriarControles()
        {
            Font labelFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            Font textBoxFont = new Font("Segoe UI", 10F);

            // Labels
            lblNome = new Label
            {
                Text = "Nome:",
                Font = labelFont,
                AutoSize = true,
                Anchor = AnchorStyles.Right,
                Margin = new Padding(0, 8, 10, 8),
                TextAlign = ContentAlignment.MiddleRight
            };

            lblEmail = new Label
            {
                Text = "Email:",
                Font = labelFont,
                AutoSize = true,
                Anchor = AnchorStyles.Right,
                Margin = new Padding(0, 8, 10, 8),
                TextAlign = ContentAlignment.MiddleRight
            };

            lblFone = new Label
            {
                Text = "Telefone:",
                Font = labelFont,
                AutoSize = true,
                Anchor = AnchorStyles.Right,
                Margin = new Padding(0, 8, 10, 8),
                TextAlign = ContentAlignment.MiddleRight
            };

            lblSenha = new Label
            {
                Text = "Senha:",
                Font = labelFont,
                AutoSize = true,
                Anchor = AnchorStyles.Right,
                Margin = new Padding(0, 8, 10, 8),
                TextAlign = ContentAlignment.MiddleRight
            };

            lblConfirmaSenha = new Label
            {
                Text = "Confirmar Senha:",
                Font = labelFont,
                AutoSize = true,
                Anchor = AnchorStyles.Right,
                Margin = new Padding(0, 8, 10, 8),
                TextAlign = ContentAlignment.MiddleRight
            };

            // TextBoxes
            txtNome = new TextBox
            {
                Font = textBoxFont,
                Width = 250,
                Margin = new Padding(0, 5, 0, 0),
                Anchor = AnchorStyles.Left
            };

            txtEmail = new TextBox
            {
                Font = textBoxFont,
                Width = 250,
                Margin = new Padding(0, 5, 0, 0),
                Anchor = AnchorStyles.Left
            };

            txtFone = new TextBox
            {
                Font = textBoxFont,
                Width = 190,
                Margin = new Padding(20, 5, 0, 0),
                Anchor = AnchorStyles.Left
            };

            txtSenha = new TextBox
            {
                Font = textBoxFont,
                Width = 125,
                PasswordChar = '●',
                Margin = new Padding(60, 5, 0, 0),
                Anchor = AnchorStyles.Left
            };

            txtConfirmaSenha = new TextBox
            {
                Font = textBoxFont,
                Width = 125,
                PasswordChar = '●',
                Margin = new Padding(60, 5, 0, 0),
                Anchor = AnchorStyles.Left
            };

            // Labels de Erro
            Font errorFont = new Font("Segoe UI", 8.5F, FontStyle.Regular);

            lblErrorNome = CriarLabelErro(errorFont);
            lblErrorEmail = CriarLabelErro(errorFont);
            lblErrorFone = CriarLabelErro(errorFont);
            lblErrorSenha = CriarLabelErro(errorFont);
            lblErrorConfirmaSenha = CriarLabelErro(errorFont);

            // Botão
            btnSalvar = new System.Windows.Forms.Button
            {
                Text = "Salvar",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Width = 120,
                Height = 35,
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 15, 0, 0),
                Anchor = AnchorStyles.None
            };
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.Click += BtnSalvar_Click;

            // Efeito hover no botão
            btnSalvar.MouseEnter += (s, e) => btnSalvar.BackColor = Color.FromArgb(0, 100, 190);
            btnSalvar.MouseLeave += (s, e) => btnSalvar.BackColor = Color.FromArgb(0, 120, 215);
        }

        private Label CriarLabelErro(Font font)
        {
            return new Label
            {
                Text = "",
                Font = font,
                ForeColor = Color.Red,
                AutoSize = true,
                Visible = false,
                Margin = new Padding(0, 2, 0, 8),
                Anchor = AnchorStyles.Left
            };
        }

        private void LimparErros()
        {
            lblErrorNome.Visible = false;
            lblErrorEmail.Visible = false;
            lblErrorFone.Visible = false;
            lblErrorSenha.Visible = false;
            lblErrorConfirmaSenha.Visible = false;
        }

        private void MostrarErro(Label lblError, string mensagem)
        {
            lblError.Text = mensagem;
            lblError.Visible = true;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            // Limpar erros anteriores
            LimparErros();

            bool temErro = false;

            // Validar Nome
            if ( string.IsNullOrWhiteSpace(txtNome.Text) )
            {
                MostrarErro(lblErrorNome, "Digite o nome de usuário");
                temErro = true;
            }

            // Validar Email
            if ( string.IsNullOrWhiteSpace(txtEmail.Text) )
            {
                MostrarErro(lblErrorEmail, "Digite o email");
                temErro = true;
            }
            else if ( !txtEmail.Text.Contains("@") )
            {
                MostrarErro(lblErrorEmail, "Digite um email válido");
                temErro = true;
            }

            // Validar Telefone (opcional, mas mostra exemplo)
            if ( !string.IsNullOrWhiteSpace(txtFone.Text) && txtFone.Text.Length < 10 )
            {
                MostrarErro(lblErrorFone, "Digite um telefone válido");
                temErro = true;
            }

            // Validar Senha
            if ( string.IsNullOrWhiteSpace(txtSenha.Text) )
            {
                MostrarErro(lblErrorSenha, "Digite a senha");
                temErro = true;
            }
            else if ( txtSenha.Text.Length < 6 )
            {
                MostrarErro(lblErrorSenha, "A senha deve ter no mínimo 6 caracteres");
                temErro = true;
            }

            // Validar Confirmação de Senha
            if ( string.IsNullOrWhiteSpace(txtConfirmaSenha.Text) )
            {
                MostrarErro(lblErrorConfirmaSenha, "Confirme a senha");
                temErro = true;
            }
            else if ( txtSenha.Text != txtConfirmaSenha.Text )
            {
                MostrarErro(lblErrorConfirmaSenha, "As senhas não coincidem");
                temErro = true;
            }

            // Se houver erros, não continua
            if ( temErro )
            {
                return;
            }

            MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpar campos após salvar
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtFone.Clear();
            txtSenha.Clear();
            txtConfirmaSenha.Clear();
            LimparErros();
            txtNome.Focus();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            button2.Text = "Atualizar Cadastro";
            button2.Font = new Font(button2.Font.FontFamily, 8F);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Text = "Salvar";
            button2.Font = new Font(button2.Font.FontFamily, 10F);
        }
    }
}
