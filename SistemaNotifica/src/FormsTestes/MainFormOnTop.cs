using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotifica.src.FormsTestes
{
    public partial class MainFormOnTop : Form
    {
        private Panel mainPanel;
        private Panel overlayPanel;
        private Button showOverlayButton;
        private Button hideOverlayButton;
        private TableLayoutPanel tableLayout;

        public MainFormOnTop()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Size = new Size(800, 600);
            this.Text = "Teste Sobreposição - Overlay por Cima";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Panel principal
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray
            };
            this.Controls.Add(mainPanel);

            // TableLayoutPanel com conteúdo
            CreateMainContent();

            // IMPORTANTE: Overlay deve ser adicionado DEPOIS e DIRETAMENTE ao FORM
            // não ao mainPanel, para garantir que fique por cima de tudo
            CreateOverlayPanel();
        }

        private void CreateMainContent()
        {
            // TableLayoutPanel
            tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 2,
                BackColor = Color.Blue,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            // Configurar linhas e colunas
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            mainPanel.Controls.Add(tableLayout);

            // Botão para mostrar overlay
            showOverlayButton = new Button
            {
                Text = "Mostrar Overlay",
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                BackColor = Color.LightGreen,
                Font = new Font("Arial", 11, FontStyle.Bold)
            };
            showOverlayButton.Click += ShowOverlay_Click;
            tableLayout.Controls.Add(showOverlayButton, 0, 0);

            // Outros botões para demonstrar o overlay por cima
            Button redButton = new Button
            {
                Text = "Botão Vermelho\nVisível quando\noverlay fechado",
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            tableLayout.Controls.Add(redButton, 1, 0);

            Button blueButton = new Button
            {
                Text = "Botão Azul\nCoberto pelo\noverlay",
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                BackColor = Color.DarkBlue,
                ForeColor = Color.White,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            tableLayout.Controls.Add(blueButton, 0, 1);

            Button orangeButton = new Button
            {
                Text = "Botão Laranja\nTambém coberto\npelo overlay",
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                BackColor = Color.Orange,
                ForeColor = Color.Black,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            tableLayout.Controls.Add(orangeButton, 1, 1);

            Button purpleButton = new Button
            {
                Text = "Botão Roxo\nFica atrás do\noverlay",
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            tableLayout.Controls.Add(purpleButton, 0, 2);

            Button yellowButton = new Button
            {
                Text = "Botão Amarelo\nNão clicável\nquando overlay ativo",
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                BackColor = Color.Yellow,
                ForeColor = Color.Black,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            tableLayout.Controls.Add(yellowButton, 1, 2);
        }

        private void CreateOverlayPanel()
        {
            // Panel de overlay - ADICIONADO DIRETAMENTE AO FORM
            overlayPanel = new Panel
            {
                Size = new Size(400, 200),
                BackColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
                // NÃO definir Location aqui, será calculado no show
            };

            // Título do overlay
            Label overlayTitle = new Label
            {
                Text = "OVERLAY SOBREPOSTO",
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(100, 30),
                AutoSize = true
            };
            overlayPanel.Controls.Add(overlayTitle);

            // Descrição
            Label overlayContent = new Label
            {
                Text = "Este painel está VERDADEIRAMENTE\nsobreposto aos outros controles!",
                ForeColor = Color.LightGray,
                Font = new Font("Arial", 10),
                Location = new Point(80, 70),
                Size = new Size(300, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };
            overlayPanel.Controls.Add(overlayContent);

            // Botão para fechar
            hideOverlayButton = new Button
            {
                Text = "Fechar",
                Size = new Size(100, 35),
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(150, 130)
            };
            hideOverlayButton.Click += HideOverlay_Click;
            overlayPanel.Controls.Add(hideOverlayButton);

            // CRUCIAL: Adicionar o overlay DIRETAMENTE ao Form, não ao mainPanel
            this.Controls.Add(overlayPanel);
        }

        private void ShowOverlay_Click(object sender, EventArgs e)
        {
            // Calcular posição para centralizar no form inteiro
            CenterOverlayPanel();

            // Mostrar overlay
            overlayPanel.Visible = true;

            // CRUCIAL: Trazer para frente para ficar por cima de TUDO
            overlayPanel.BringToFront();
        }

        private void HideOverlay_Click(object sender, EventArgs e)
        {
            overlayPanel.Visible = false;
        }

        private void CenterOverlayPanel()
        {
            // Centralizar no Form inteiro (não apenas no mainPanel)
            int x = ( this.ClientSize.Width - overlayPanel.Width ) / 2;
            int y = ( this.ClientSize.Height - overlayPanel.Height ) / 2;
            overlayPanel.Location = new Point(x, y);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if ( overlayPanel != null && overlayPanel.Visible )
            {
                CenterOverlayPanel();
            }
        }

        // Opcional: Método para simular loading como nas imagens
        public void ShowLoadingOverlay(string message = "Carregando...")
        {
            // Atualizar texto do overlay
            if ( overlayPanel.Controls.Count > 1 && overlayPanel.Controls[1] is Label contentLabel )
            {
                contentLabel.Text = message;
            }

            ShowOverlay_Click(null, null);

            // Forçar atualização da interface
            this.Refresh();
            Application.DoEvents();
        }

        public void HideLoadingOverlay()
        {
            HideOverlay_Click(null, null);
        }
    }
}