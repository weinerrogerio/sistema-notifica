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
    public partial class FormTesteCadastro2 : Form
    {
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
        private Button btnSalvar;

        private Label lblErrorNome;
        private Label lblErrorEmail;
        private Label lblErrorFone;
        private Label lblErrorSenha;
        private Label lblErrorConfirmaSenha;

        public FormTesteCadastro2()
        {
            InitializeComponents();
            
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




        private void LimparErros()
        {
            lblErrorNome.Visible = false;
            lblErrorEmail.Visible = false;
            lblErrorFone.Visible = false;
            lblErrorSenha.Visible = false;
            lblErrorConfirmaSenha.Visible = false;
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
    }
}
