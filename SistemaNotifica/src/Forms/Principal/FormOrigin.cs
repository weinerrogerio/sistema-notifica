using System.Diagnostics;
using System.Drawing.Printing;
using System.Reflection;
using SistemaNotifica.src.Forms;


namespace SistemaNotifica
{
    public partial class FormOrigin : Form
    {
        //Thread nt;
        public Form objForm;

        private const int SIDEBAR_MIN_WIDTH = 50;
        private const int SIDEBAR_MAX_WIDTH = 190;

        private const int SUBMENU_MIN_HEIGHT = 45;
        private const int SUBMENU_MAX_HEIGHT = 125;
        public FormOrigin()
        {
            InitializeComponent();
            objForm = new Form();
            ApplyPerformanceOptimizations();
            //StartSidebarAnimation();
            sidebarMenu.Width = SIDEBAR_MIN_WIDTH;
            tableLayoutNotificacao.Height = SUBMENU_MIN_HEIGHT;
        }

        private void ApplyPerformanceOptimizations()
        {
            // CONFIGURA��ES CR�TICAS DE PERFORMANCE DO FORM
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.DoubleBuffer |
                         ControlStyles.ResizeRedraw |
                         ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            // APLICAR DOUBLEBUFFERED A TODOS OS PAIN�IS USANDO REFLECTION
            Panel[] panels = { panel1, panel5, panelHome, panelImportar, panelData, panelSettings,
                              panelNotifica��o, panelSubMenu1, panelSubMenu2, panelUser,
                              panelSobre, panelLogOut, pnlMain };

            foreach (Panel panel in panels)
            {
                // CONFIGURA��O CR�TICA: Evita flickering durante anima��es
                typeof(Panel).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, panel, new object[] { true });
            }

            // PERFORMANCE: PictureBox com DoubleBuffered para btnHam
            typeof(PictureBox).InvokeMember("DoubleBuffered",
               BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
               null, btnHam, new object[] { true });

            // PERFORMANCE: Logo com DoubleBuffered para imgLogo
            typeof(PictureBox).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, imgLogo, new object[] { true });

            // CONFIGURA��O ULTRA CR�TICA - GARANTE ANIMA��ES A 60 FPS
            typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, sidebarMenu, new object[] { true });

            // CONFIGURA��O CR�TICA PARA SUBMENU ANIMADO
            typeof(TableLayoutPanel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, tableLayoutNotificacao, new object[] { true });

            // sidebarTransition - CONFIGURA��O CR�TICA PARA 60 FPS
            sidebarTransition.Interval = 24; // ~60 FPS

            // menuTransition - CONFIGURA��O PARA 60 FPS
            menuTransition.Interval = 24; // ~60 FPS
        }


        //---------------------------------------- ANIMA��O SIDEBAR --------------------------
        //Boolean sidebarExpanded = false;
        private float animationProgress = 0f;
        private int startWidth, targetWidth;

        
        private void StartSidebarAnimation()
        {
            startWidth = sidebarMenu.Width;
            if (startWidth == SIDEBAR_MIN_WIDTH)
            {
                targetWidth = SIDEBAR_MAX_WIDTH; 
            }
            else 
            {
                targetWidth = SIDEBAR_MIN_WIDTH;
                if(menuTargetHeight == SUBMENU_MAX_HEIGHT)
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

            if (animationProgress >= 1f)
            {
                animationProgress = 1f; 
                sidebarTransition.Stop(); 
            }

            float easedProgress = 1f - (float)Math.Pow(1 - animationProgress, 3);
            int newWidth = (int)(startWidth + (targetWidth - startWidth) * easedProgress);

            newWidth = Math.Max(50, Math.Min(190, newWidth));

            sidebarMenu.Width = newWidth;
            adjustWidth(newWidth); 
        }


        // ------------------------------ ANIMA��O MENU - SUBMENUS ----------------------
        private float menuAnimationProgress = 0f;
        private int menuStartHeight, menuTargetHeight;
        private void StartSubmenuAnimation()
        {
            menuStartHeight = tableLayoutNotificacao.Height; // Altura atual do submenu

            // Determina a altura alvo com base na altura atual
            if (menuStartHeight == SUBMENU_MIN_HEIGHT)
            {
                menuTargetHeight = SUBMENU_MAX_HEIGHT;
                if(sidebarMenu.Width == SIDEBAR_MIN_WIDTH)
                {
                    StartSidebarAnimation();
                }
            }
            else // Se menuStartHeight � SUBMENU_MAX_HEIGHT (ou outro valor)
            {
                menuTargetHeight = SUBMENU_MIN_HEIGHT; 
            }

            menuAnimationProgress = 0f; // Reinicia o progresso
            menuTransition.Start(); // Inicia o Timer do submenu
        }

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            menuAnimationProgress += 0.05f; // Velocidade da anima��o (ajuste conforme necess�rio)

            if (menuAnimationProgress >= 1f)
            {
                menuAnimationProgress = 1f; // Garante que o progresso n�o passe de 1
                menuTransition.Stop(); // Para a anima��o
            }

            float easedProgress = 1f - (float)Math.Pow(1 - menuAnimationProgress, 3);
            int newHeight = (int)(menuStartHeight + (menuTargetHeight - menuStartHeight) * easedProgress);

            newHeight = Math.Max(SUBMENU_MIN_HEIGHT, Math.Min(SUBMENU_MAX_HEIGHT, newHeight));

            tableLayoutNotificacao.Height = newHeight;            
        }
        private void adjustWidth(int barWidth)
        {
            // Suspende layout para evitar m�ltiplos redesenhos
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
            objForm?.Close();
            objForm = new FormHome
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void btnImportarDoc_Click(object sender, EventArgs e)
        {

        }

        // A PRIMEIRA TELA A SER APRESENTADA PRECISA SER A HOME --> fazer depois 
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            //OnLoad.add
        }

        


    }
}
