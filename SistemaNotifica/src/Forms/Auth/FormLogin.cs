using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotifica
{
    public partial class FormLogin : Form
    {
        private readonly ApiService _apiService;

        public FormLogin()
        {
            InitializeComponent();
            _apiService = new ApiService();
            this.KeyPreview = true; // Permite capturar teclas no form
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string nome = textBoxName.Text.Trim();
            string senha = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Entrando...";
                Cursor.Current = Cursors.WaitCursor;

                // Chama a API para autenticação
                var loginResponse = await _apiService.LoginAsync(nome, senha);

                if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.Token) && loginResponse.User != null)
                {
                    // Salva na sessão
                    Sessao.Token = loginResponse.Token;
                    Sessao.UsuarioLogado = loginResponse.User.Nome;
                    Sessao.TipoUsuario = loginResponse.User.Role; // Ex: "admin" ou "user"

                    MessageBox.Show($"Bem-vindo, {Sessao.UsuarioLogado}!", "Login Realizado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    using (var formOrigin = new FormOrigin(Sessao.Token))
                    {
                        formOrigin.ShowDialog();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPassword.Clear();
                    textBoxName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao fazer login: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Clear();
                textBoxName.Focus();
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Entrar";
                Cursor.Current = Cursors.Default;
            }
        }

        // Permite apertar Enter para logar
        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Libera recursos ao fechar
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            _apiService?.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            // Você pode deixar vazio, ou implementar algo aqui se precisar
        }
    }

    // Sessão compartilhada em todo o sistema
    public static class Sessao
    {
        public static string Token { get; set; }
        public static string UsuarioLogado { get; set; }
        public static string TipoUsuario { get; set; }
    }

    public class User
    {
        public string Nome { get; set; }
        public string Role { get; set; }
    }
}
