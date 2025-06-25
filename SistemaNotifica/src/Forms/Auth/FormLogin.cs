using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // Importar para cantos arredondados
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaNotifica.src.Forms;

namespace SistemaNotifica
{
    public partial class FormLogin : Form
    {
        private Point mouseLocation; // Para armazenar a posição do mouse
        private bool isDragging = false;
        private Thread? nt;
        public FormLogin()
        {
            InitializeComponent();
            // Adicionar eventos Paint para os controles que queremos arredondar
            this.panelLogin.Paint += new PaintEventHandler(this.PanelLogin_Paint);
            this.btnLogin.Paint += new PaintEventHandler(this.Button_Paint);
            this.textBoxName.Paint += new PaintEventHandler(this.TextBox_Paint);
            this.textBoxPassword.Paint += new PaintEventHandler(this.TextBox_Paint);

            // Adicionar evento para quando o tamanho do form mudar, redesenhar o panelLogin
            this.Resize += new EventHandler(this.FormLogin_Resize);
            this.topPanel.MouseDown += new MouseEventHandler(this.TopPanel_MouseDown);
            this.topPanel.MouseMove += new MouseEventHandler(this.TopPanel_MouseMove);
            this.topPanel.MouseUp += new MouseEventHandler(this.TopPanel_MouseUp);
        }

        // Evento quando o botão do mouse é pressionado no topPanel
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Apenas se o botão esquerdo do mouse for pressionado
            {
                isDragging = true;
                mouseLocation = e.Location; // Armazena a posição atual do mouse
            }
        }

        // Evento quando o mouse se move no topPanel
        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calcula a nova posição do formulário
                this.Location = new Point(
                    (this.Location.X - mouseLocation.X) + e.X,
                    (this.Location.Y - mouseLocation.Y) + e.Y
                );
                this.Update(); // Força a atualização da tela
            }
        }

        // Evento quando o botão do mouse é liberado no topPanel
        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false; // Para de arrastar
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //trazer autenticação do banco depois
            if (textBoxName.Text == "user" && textBoxPassword.Text == "123")
            {
                this.Hide(); // Esconder o formulário de login em vez de fechar imediatamente
                nt = new Thread(() =>
                {
                    Application.Run(new FormOrigin());
                });
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();
                MessageBox.Show("Logado com sucesso!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
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