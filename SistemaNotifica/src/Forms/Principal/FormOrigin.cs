using SistemaNotifica.src.Forms;
using SistemaNotifica.src.Forms.Principal;
using SistemaNotifica.src.Forms.Template;
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Utils;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace SistemaNotifica
{
    public partial class FormOrigin : Form
    {


        //Thread nt;
        public Form objForm;
        private string TelaAtual = string.Empty;

        private const int SIDEBAR_MIN_WIDTH = 50;
        private const int SIDEBAR_MAX_WIDTH = 190;

        private const int SUBMENU_MIN_HEIGHT = 42;
        private const int SUBMENU_MAX_HEIGHT = 140;

        public FormOrigin()
        {
            InitializeComponent();
            this.Text = $"Sistema de Notificações - Versão 1.0       Usuário: {Session.UsuarioLogado}";
            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src/icons", "Logo_transp_pb.ico");
            if ( File.Exists(iconPath) ) this.Icon = new Icon(iconPath);
            //this.EnableDragByControl(this.topPanel);
            objForm = new Form();
            ApplyPerformanceOptimizations();
            sidebarMenu.Width = SIDEBAR_MIN_WIDTH;
            tableLayoutNotificacao.Height = SUBMENU_MIN_HEIGHT;
            openHomeDefaultForm();

            // ADICIONAR EVENTOS DE CLICK PARA RECOLHER SIDEBAR
            SetupClickOutsideHandlers();
        }

        private void SetupClickOutsideHandlers()
        {
            // Adiciona evento de click para o form principal
            this.Click += FormOrigin_Click;

            // Adiciona evento de click para o painel principal
            pnlMain.Click += PnlMain_Click;

            // Se você tiver um topPanel, adicione também
            // topPanel.Click += TopPanel_Click;

            // Adiciona recursivamente para todos os controles filhos do pnlMain
            AddClickHandlerToControls(pnlMain);
        }

        private void AddClickHandlerToControls(Control parent)
        {
            foreach ( Control control in parent.Controls )
            {
                // Não adiciona evento para controles da sidebar
                if ( IsControlInSidebar(control) )
                    continue;

                control.Click += Control_Click;

                // Recursivamente adiciona para controles filhos
                if ( control.HasChildren )
                {
                    AddClickHandlerToControls(control);
                }
            }
        }

        private bool IsControlInSidebar(Control control)
        {
            Control current = control;
            while ( current != null )
            {
                if ( current == sidebarMenu )
                    return true;
                current = current.Parent;
            }
            return false;
        }

        private void FormOrigin_Click(object sender, EventArgs e)
        {
            CollapseSidebar();
        }

        private void PnlMain_Click(object sender, EventArgs e)
        {
            CollapseSidebar();
        }

        private void Control_Click(object sender, EventArgs e)
        {
            CollapseSidebar();
        }

        private void CollapseSidebar()
        {
            // Só recolhe se a sidebar estiver expandida
            if ( sidebarMenu.Width > SIDEBAR_MIN_WIDTH )
            {
                StartSidebarCollapseAnimation();
            }
        }

        private void StartSidebarCollapseAnimation()
        {
            startWidth = sidebarMenu.Width;
            targetWidth = SIDEBAR_MIN_WIDTH;

            // Se o submenu estiver expandido, recolhe também
            if ( menuTargetHeight == SUBMENU_MAX_HEIGHT || tableLayoutNotificacao.Height > SUBMENU_MIN_HEIGHT )
            {
                StartSubmenuCollapseAnimation();
            }

            animationProgress = 0f;
            sidebarTransition.Start();
        }

        private void StartSubmenuCollapseAnimation()
        {
            menuStartHeight = tableLayoutNotificacao.Height;
            menuTargetHeight = SUBMENU_MIN_HEIGHT;
            menuAnimationProgress = 0f;
            menuTransition.Start();
        }

        private void FormOrigin_Load(object sender, EventArgs e)
        {

            objForm?.Close();

            FormHome formHome = new FormHome
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            // INSCREVA-SE NO EVENTO AQUI TAMBÉM
            formHome.OnNavigateToImport += HandleNavigateToImport;

            objForm = formHome;
            pnlMain.Controls.Add(objForm);
            objForm.Show();

            // Reconfigurar handlers após adicionar novo form
            AddClickHandlerToControls(pnlMain);
        }

        private void ApplyPerformanceOptimizations()
        {
            // CONFIGURAÇÕES CRÍTICAS DE PERFORMANCE DO FORM
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.DoubleBuffer |
                         ControlStyles.ResizeRedraw |
                         ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            // APLICAR DOUBLEBUFFERED A TODOS OS PAINÉIS USANDO REFLECTION
            Panel[] panels = { panel5, panelHome, panelImportar, panelData, panelSettings,
                              panelNotificação, panelSubMenu1, panelSubMenu2, panelUser,
                              panelSobre, panelLogOut, pnlMain };

            foreach ( Panel panel in panels )
            {
                // CONFIGURAÇÃO CRÍTICA: Evita flickering durante animações
                typeof(Panel).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, panel, new object[] { true });
            }

            // PERFORMANCE: PictureBox com DoubleBuffered para btnHam
            typeof(PictureBox).InvokeMember("DoubleBuffered",
               BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
               null, btnHam, new object[] { true });



            // CONFIGURAÇÃO ULTRA CRÍTICA - GARANTE ANIMAÇÕES A 60 FPS
            typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, sidebarMenu, new object[] { true });

            // CONFIGURAÇÃO CRÍTICA PARA SUBMENU ANIMADO
            typeof(TableLayoutPanel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, tableLayoutNotificacao, new object[] { true });

            // sidebarTransition - CONFIGURAÇÃO CRÍTICA PARA 60 FPS
            sidebarTransition.Interval = 24; // ~60 FPS

            // menuTransition - CONFIGURAÇÃO PARA 60 FPS
            menuTransition.Interval = 24; // ~60 FPS
        }


        //---------------------------------------- ANIMAÇÃO SIDEBAR --------------------------
        //Boolean sidebarExpanded = false;
        private float animationProgress = 0f;
        private int startWidth, targetWidth;


        private void StartSidebarAnimation()
        {
            startWidth = sidebarMenu.Width;
            if ( startWidth == SIDEBAR_MIN_WIDTH )
            {
                targetWidth = SIDEBAR_MAX_WIDTH;
            }
            else
            {
                targetWidth = SIDEBAR_MIN_WIDTH;
                if ( menuTargetHeight == SUBMENU_MAX_HEIGHT )
                {
                    StartSubmenuAnimation();
                }


            }
            animationProgress = 0f;
            sidebarTransition.Start();
        }



        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            animationProgress += 0.05f;

            if ( animationProgress >= 1f )
            {
                animationProgress = 1f;
                sidebarTransition.Stop();
            }

            float easedProgress = 1f - ( float ) Math.Pow(1 - animationProgress, 3);
            int newWidth = ( int ) ( startWidth + ( targetWidth - startWidth ) * easedProgress );

            newWidth = Math.Max(50, Math.Min(190, newWidth));

            sidebarMenu.Width = newWidth;
            adjustWidth(newWidth);
        }


        // ------------------------------ ANIMAÇÃO MENU - SUBMENUS ----------------------
        private float menuAnimationProgress = 0f;
        private int menuStartHeight, menuTargetHeight;
        private void StartSubmenuAnimation()
        {
            menuStartHeight = tableLayoutNotificacao.Height; // Altura atual do submenu

            // Determina a altura alvo com base na altura atual
            if ( menuStartHeight == SUBMENU_MIN_HEIGHT )
            {
                menuTargetHeight = SUBMENU_MAX_HEIGHT;
                if ( sidebarMenu.Width == SIDEBAR_MIN_WIDTH )
                {
                    StartSidebarAnimation();
                }
            }
            else // Se menuStartHeight é SUBMENU_MAX_HEIGHT (ou outro valor)
            {
                menuTargetHeight = SUBMENU_MIN_HEIGHT;
            }

            menuAnimationProgress = 0f; // Reinicia o progresso
            menuTransition.Start(); // Inicia o Timer do submenu
        }

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            menuAnimationProgress += 0.05f; // Velocidade da animação (ajuste conforme necessário)

            if ( menuAnimationProgress >= 1f )
            {
                menuAnimationProgress = 1f; // Garante que o progresso não passe de 1
                menuTransition.Stop(); // Para a animação
            }

            float easedProgress = 1f - ( float ) Math.Pow(1 - menuAnimationProgress, 3);
            int newHeight = ( int ) ( menuStartHeight + ( menuTargetHeight - menuStartHeight ) * easedProgress );

            newHeight = Math.Max(SUBMENU_MIN_HEIGHT, Math.Min(SUBMENU_MAX_HEIGHT, newHeight));

            tableLayoutNotificacao.Height = newHeight;
        }


        private void adjustWidth(int barWidth)
        {
            // Suspende layout para evitar múltiplos redesenhos
            sidebarMenu.SuspendLayout();
            panelHome.Width = barWidth;
            panelImportar.Width = barWidth;
            panelData.Width = barWidth;
            panelUser.Width = barWidth;
            panelSettings.Width = barWidth;
            panelLogOut.Width = barWidth;
            tableLayoutNotificacao.Width = barWidth;
            sidebarMenu.ResumeLayout(false);
        }

        private void ResetSidebarButtons()
        {
            btnHome.BackColor = Color.FromArgb(0, 0, 0);
            btnImportarDoc.BackColor = Color.FromArgb(0, 0, 0);
            btnDados.BackColor = Color.FromArgb(0, 0, 0);
            btnUser.BackColor = Color.FromArgb(0, 0, 0);
            btnSettings.BackColor = Color.FromArgb(0, 0, 0);
            btnSobre.BackColor = Color.FromArgb(0, 0, 0);
            btnConfigNotificacao.BackColor = Color.FromArgb(0, 0, 0);
            btnNotificacao.BackColor = Color.FromArgb(0, 0, 0);
            btnLogOut.BackColor = Color.FromArgb(0, 0, 0);

        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            StartSidebarAnimation();
        }

        private void btnNotificacao_Click(object sender, EventArgs e)
        {
            StartSubmenuAnimation();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

            if ( !( TelaAtual == "FormHome" ) )
            {
                openHomeDefaultForm();
                ResetSidebarButtons();
                btnHome.BackColor = Color.FromArgb(60, 60, 60);
            }
            return;
        }

        private void openHomeDefaultForm()
        {
            objForm?.Close();
            ResetSidebarButtons();

            FormHome formHome = new FormHome() // Mude para variável local
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            // INSCREVA-SE NO EVENTO AQUI
            formHome.OnNavigateToImport += HandleNavigateToImport;
            formHome.OnNavigateToNotification += HandleNavigateToNotification;

            objForm = formHome; // Atribua à variável global
            TelaAtual = "FormHome";
            pnlMain.Controls.Add(objForm);
            objForm.Show();

            // Reconfigurar handlers após adicionar novo form
            AddClickHandlerToControls(pnlMain);
        }
        private void HandleNavigateToImport()
        {
            // Chama sua função existente de navegação para FormImport
            btnImportarDoc_Click(null, null);
        }


        private void btnImportarDoc_Click(object sender, EventArgs e)
        {

            if ( !( TelaAtual == "FormImport" ) )
            {
                ResetSidebarButtons();
                btnImportarDoc.BackColor = Color.FromArgb(60, 60, 60);
                objForm?.Close();
                objForm = new FormImport
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                TelaAtual = "FormImport";
                pnlMain.Controls.Add(objForm);
                objForm.Show();

                // Reconfigurar handlers após adicionar novo form
                AddClickHandlerToControls(pnlMain);
            }
            return;
        }

        private void HandleNavigateToNotification()
        {
            btnEnviarNotificacao_Click(null, null);
        }

        private void btnEnviarNotificacao_Click(object sender, EventArgs e)
        {
            if ( !( TelaAtual == "FormNotification" ) )
            {
                ResetSidebarButtons();
                btnEnviarNotificacao.BackColor = Color.FromArgb(60, 60, 60);
                objForm?.Close();
                objForm = new FormNotification
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                TelaAtual = "FormNotification"; // Corrigido
                pnlMain.Controls.Add(objForm);
                objForm.Show();

                // Reconfigurar handlers após adicionar novo form
                AddClickHandlerToControls(pnlMain);
            }
            return;
        }

        private void btnConfigNotificacao_Click(object sender, EventArgs e)
        {
            if ( !( TelaAtual == "TemplateManagerForm" ) )
            {
                ResetSidebarButtons();
                btnConfigNotificacao.BackColor = Color.FromArgb(60, 60, 60);
                objForm?.Close();
                objForm = new TemplateManagerForm
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                TelaAtual = "TemplateManagerForm"; // Corrigido
                pnlMain.Controls.Add(objForm);
                objForm.Show();

                // Reconfigurar handlers após adicionar novo form
                AddClickHandlerToControls(pnlMain);
            }
            return;
        }

        private void btnDados_Click(object sender, EventArgs e)
        {
            //FormData
            if ( !( TelaAtual == "FormData" ) )
            {
                ResetSidebarButtons();
                btnConfigNotificacao.BackColor = Color.FromArgb(60, 60, 60);
                objForm?.Close();
                objForm = new FormData
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                TelaAtual = "FormData";
                pnlMain.Controls.Add(objForm);
                objForm.Show();

                // Reconfigurar handlers após adicionar novo form
                AddClickHandlerToControls(pnlMain);
            }
            return;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            //FormUser
            if ( !( TelaAtual == "FormUser" ) )
            {
                ResetSidebarButtons();
                btnConfigNotificacao.BackColor = Color.FromArgb(60, 60, 60);
                objForm?.Close();
                objForm = new FormUser
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                TelaAtual = "FormUser";
                pnlMain.Controls.Add(objForm);
                objForm.Show();

                // Reconfigurar handlers após adicionar novo form
                AddClickHandlerToControls(pnlMain);
            }
            return;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            //FormConfig
            if ( !( TelaAtual == "FormConfig" ) )
            {
                ResetSidebarButtons();
                btnConfigNotificacao.BackColor = Color.FromArgb(60, 60, 60);
                objForm?.Close();
                objForm = new FormConfig
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                TelaAtual = "FormConfig";
                pnlMain.Controls.Add(objForm);
                objForm.Show();

                // Reconfigurar handlers após adicionar novo form
                AddClickHandlerToControls(pnlMain);
            }
            return;
        }
    }
}