using SistemaNotifica.src.Forms;
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;
using SistemaNotifica.src.Services.Cache;
using SistemaNotifica.src.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D; // Importar para cantos arredondados
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SistemaNotifica.src.Models.Auth;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SistemaNotifica
{
    public partial class FormLogin : Form
    {
        private readonly AuthService _authService;

        private Thread? nt;

        public FormLogin()
        {
            InitializeComponent();
            // Adicionar eventos Paint para os controles que queremos arredondar
            this.panelLogin.Paint += new PaintEventHandler(this.PanelLogin_Paint);
            this.btnLogin.Paint += new PaintEventHandler(this.Button_Paint);
            this.textBoxName.Paint += new PaintEventHandler(this.TextBox_Paint);
            this.textBoxPassword.Paint += new PaintEventHandler(this.TextBox_Paint);

            this.Resize += new EventHandler(this.FormLogin_Resize);

            _authService = Program.AuthService;
            this.KeyPreview = true;

            this.Text = "Sistema de Notificações - Versão 1.0";
            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src/icons", "Logo_transp_pb.ico");
            if (File.Exists(iconPath)) this.Icon = new Icon(iconPath);
        }


        private async void btnLogin_Click(object sender, EventArgs e)
        {
            //string username = textBoxName.Text.Trim();
            //string password = textBoxPassword.Text.Trim();
            string username = "admin".Trim();
            string password = "123456".Trim();

            // MELHORAR ISSO ADICIONAR BORDAS VERMELHAS AOS CAMPOS E MENSAGENS DE ERRO
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                //MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Aqui você pode exibir a mensagem no seu label de erro ou borda do campo
                lblErrorMessage.Text = "Por favor, preencha todos os campos.";
                lblErrorMessage.Visible = true;
                return;
            }
            // Limpa mensagens de erro anteriores
            lblErrorMessage.Text = "";
            lblErrorMessage.Visible = false;
            // Restaura estilos dos campos se tiver mudado
            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Entrando...";
                Cursor.Current = Cursors.WaitCursor;
                lblErrorMessage.Text = "";
                Debug.WriteLine("Login: " + username + " - Senha: " + password);
                // Chama a API para autenticação
                // var loginResponse = await _apiService.LoginAsync(nome, senha);
                LoginResponse response = await _authService.LoginAsync(username, password);
                Debug.WriteLine(" " );
                Debug.WriteLine("Response::::::::::::::::: " + response);
                Debug.WriteLine(" " );

                if (response != null && !string.IsNullOrEmpty(response.AccessToken)) // Ou response.IsSuccess == true 
                {
                    CacheInitializer.StartBackgroundCacheInitialization();
                    await Task.Delay(100);

                    this.DialogResult = DialogResult.OK;
                    this.Close(); // Fecha o formulário de login
                }
                else
                {
                    // Login falhou por credenciais inválidas ou outro motivo retornado pela API
                    string errorMessage = response?.Message ?? "Usuário ou senha inválidos.";
                    lblErrorMessage.Text = errorMessage; // Exibe a mensagem da API na sua UI
                    lblErrorMessage.Visible = true;
                    textBoxPassword.Clear(); // Limpa a senha para nova tentativa
                    textBoxName.Focus(); // Foca no nome de usuário
                }
            }
            catch (HttpRequestException ex)
            {
                // Erro de conexão de rede ou servidor inacessível
                //lblErrorMessage.Text = $"Erro de conexão: Verifique sua internet ou contate o suporte. Detalhes: {ex.Message}";
                lblErrorMessage.Text = $"Usuário ou senha inválidos.";
                lblErrorMessage.Visible = true;

            }
            catch (Exception ex)
            {
                // Outros erros inesperados
                Debug.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
                lblErrorMessage.Text = $"{ex.Message}";
                lblErrorMessage.Visible = true;
            }
            finally
            {
                // Sempre reabilita o botão e restaura o cursor, independentemente do sucesso ou falha.
                btnLogin.Enabled = true;
                btnLogin.Text = "Entrar";
                Cursor.Current = Cursors.Default;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            CenterPanelLogin();
        }

        private void FormLogin_Resize(object sender, EventArgs e)
        {
            CenterPanelLogin();
            // Invalida os controles para forçar o redesenho dos cantos arredondados
            this.panelLogin.Invalidate();
            this.btnLogin.Invalidate();
            this.textBoxName.Invalidate();
            this.textBoxPassword.Invalidate();
        }

        private void CenterPanelLogin()
        {
            panelLogin.Location = new Point(
                (this.ClientSize.Width - panelLogin.Width) / 2,
                (this.ClientSize.Height - panelLogin.Height) / 2
            );
        }

        // ----------------------- Métodos para Cantos Arredondados -------------------

        public GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            // top left arc
            path.AddArc(arc, 180, 90);

            // top right arc
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        // Desenha o painel com cantos arredondados e sombra (opcional)
        private void PanelLogin_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int borderRadius = 20; // Raio dos cantos para o painel

            // Desenha a sombra (opcional, pode ser ajustado ou removido)
            using (GraphicsPath shadowPath = GetRoundedRect(new Rectangle(2, 2, panel.Width - 4, panel.Height - 4), borderRadius))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0))) // Sombra suave
            {
                e.Graphics.FillPath(shadowBrush, shadowPath);
            }

            // Desenha o painel com a cor de fundo e cantos arredondados
            using (GraphicsPath path = GetRoundedRect(new Rectangle(0, 0, panel.Width, panel.Height), borderRadius))
            {
                panel.Region = new Region(path); // Define a região para o recorte do painel
                using (SolidBrush brush = new SolidBrush(panel.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        // Desenha o botão com cantos arredondados
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int borderRadius = 4; // Raio dos cantos para o botão

            Rectangle bounds = new Rectangle(0, 0, btn.Width, btn.Height);
            using (GraphicsPath path = GetRoundedRect(bounds, borderRadius))
            {
                btn.Region = new Region(path); // Define a região para o recorte do botão
                using (SolidBrush brush = new SolidBrush(btn.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, bounds, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        // Desenha a caixa de texto com cantos arredondados e borda
        private void TextBox_Paint(object sender, PaintEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int borderRadius = 8; // Raio dos cantos para as textboxes

            Rectangle bounds = new Rectangle(0, 0, txtBox.Width, txtBox.Height);
            using (GraphicsPath path = GetRoundedRect(bounds, borderRadius))
            {
                txtBox.Region = new Region(path); // Define a região para o recorte da textbox

                // Desenha o background da textbox (para preencher o "arredondado" antes do texto)
                using (SolidBrush backgroundBrush = new SolidBrush(txtBox.BackColor))
                {
                    e.Graphics.FillPath(backgroundBrush, path);
                }

                // Desenha a borda arredondada
                using (Pen borderPen = new Pen(Color.FromArgb(180, 180, 180), 1)) // Borda cinza suave
                {
                    e.Graphics.DrawPath(borderPen, path);
                }
            }
        }
    }
}