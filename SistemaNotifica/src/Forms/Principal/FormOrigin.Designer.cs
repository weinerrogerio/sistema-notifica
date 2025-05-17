
namespace SistemaNotifica
{
    partial class FormOrigin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrigin));
            panel1 = new Panel();
            btnHam = new PictureBox();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            imgLogo = new PictureBox();
            sidebarMenu = new FlowLayoutPanel();
            panel5 = new Panel();
            panelHome = new Panel();
            btnHome = new Button();
            panelImportar = new Panel();
            btnImportarDoc = new Button();
            panelData = new Panel();
            btnDados = new Button();
            panelUser = new Panel();
            btnUser = new Button();
            panelSettings = new Panel();
            btnConfig = new Button();
            panelSobre = new Panel();
            btnSobre = new Button();
            panelLogOut = new Panel();
            btnLogOut = new Button();
            sidebarTransition = new System.Windows.Forms.Timer(components);
            pnlMain = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnHam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgLogo).BeginInit();
            sidebarMenu.SuspendLayout();
            panelHome.SuspendLayout();
            panelImportar.SuspendLayout();
            panelData.SuspendLayout();
            panelUser.SuspendLayout();
            panelSettings.SuspendLayout();
            panelSobre.SuspendLayout();
            panelLogOut.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(btnHam);
            panel1.Controls.Add(nightControlBox1);
            panel1.Controls.Add(imgLogo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1059, 46);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnHam
            // 
            btnHam.Image = (Image)resources.GetObject("btnHam.Image");
            btnHam.Location = new Point(8, 0);
            btnHam.Margin = new Padding(3, 4, 3, 4);
            btnHam.Name = "btnHam";
            btnHam.Size = new Size(43, 43);
            btnHam.SizeMode = PictureBoxSizeMode.CenterImage;
            btnHam.TabIndex = 3;
            btnHam.TabStop = false;
            btnHam.Click += btnHam_Click;
            // 
            // nightControlBox1
            // 
            nightControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nightControlBox1.BackColor = Color.Transparent;
            nightControlBox1.CloseHoverColor = Color.FromArgb(199, 80, 80);
            nightControlBox1.CloseHoverForeColor = Color.White;
            nightControlBox1.DefaultLocation = true;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.EnableCloseColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMaximizeButton = true;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.Location = new Point(920, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 2;
            // 
            // imgLogo
            // 
            imgLogo.BackgroundImageLayout = ImageLayout.None;
            imgLogo.Image = (Image)resources.GetObject("imgLogo.Image");
            imgLogo.Location = new Point(57, 0);
            imgLogo.Margin = new Padding(3, 4, 3, 4);
            imgLogo.Name = "imgLogo";
            imgLogo.Size = new Size(113, 44);
            imgLogo.SizeMode = PictureBoxSizeMode.Zoom;
            imgLogo.TabIndex = 2;
            imgLogo.TabStop = false;
            // 
            // sidebarMenu
            // 
            sidebarMenu.BackColor = Color.Black;
            sidebarMenu.Controls.Add(panel5);
            sidebarMenu.Controls.Add(panelHome);
            sidebarMenu.Controls.Add(panelImportar);
            sidebarMenu.Controls.Add(panelData);
            sidebarMenu.Controls.Add(panelUser);
            sidebarMenu.Controls.Add(panelSettings);
            sidebarMenu.Controls.Add(panelSobre);
            sidebarMenu.Controls.Add(panelLogOut);
            sidebarMenu.Dock = DockStyle.Left;
            sidebarMenu.FlowDirection = FlowDirection.TopDown;
            sidebarMenu.Location = new Point(0, 46);
            sidebarMenu.Margin = new Padding(3, 4, 3, 4);
            sidebarMenu.Name = "sidebarMenu";
            sidebarMenu.Size = new Size(60, 585);
            sidebarMenu.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Location = new Point(3, 4);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(229, 31);
            panel5.TabIndex = 4;
            // 
            // panelHome
            // 
            panelHome.Controls.Add(btnHome);
            panelHome.Location = new Point(3, 43);
            panelHome.Margin = new Padding(3, 4, 3, 4);
            panelHome.Name = "panelHome";
            panelHome.Size = new Size(214, 59);
            panelHome.TabIndex = 5;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.Black;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.White;
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(-14, -7);
            btnHome.Margin = new Padding(3, 4, 3, 4);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(17, 0, 0, 0);
            btnHome.Size = new Size(245, 75);
            btnHome.TabIndex = 2;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // panelImportar
            // 
            panelImportar.Controls.Add(btnImportarDoc);
            panelImportar.Location = new Point(3, 110);
            panelImportar.Margin = new Padding(3, 4, 3, 4);
            panelImportar.Name = "panelImportar";
            panelImportar.Size = new Size(214, 59);
            panelImportar.TabIndex = 3;
            // 
            // btnImportarDoc
            // 
            btnImportarDoc.BackColor = Color.Black;
            btnImportarDoc.FlatStyle = FlatStyle.Flat;
            btnImportarDoc.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImportarDoc.ForeColor = Color.White;
            btnImportarDoc.Image = (Image)resources.GetObject("btnImportarDoc.Image");
            btnImportarDoc.ImageAlign = ContentAlignment.MiddleLeft;
            btnImportarDoc.Location = new Point(-13, -15);
            btnImportarDoc.Margin = new Padding(3, 4, 3, 4);
            btnImportarDoc.Name = "btnImportarDoc";
            btnImportarDoc.Padding = new Padding(17, 0, 0, 0);
            btnImportarDoc.Size = new Size(239, 81);
            btnImportarDoc.TabIndex = 2;
            btnImportarDoc.Text = "     Importar";
            btnImportarDoc.UseVisualStyleBackColor = false;
            btnImportarDoc.Click += btnImportarDoc_Click;
            // 
            // panelData
            // 
            panelData.Controls.Add(btnDados);
            panelData.Location = new Point(3, 177);
            panelData.Margin = new Padding(3, 4, 3, 4);
            panelData.Name = "panelData";
            panelData.Size = new Size(214, 59);
            panelData.TabIndex = 4;
            // 
            // btnDados
            // 
            btnDados.BackColor = Color.Black;
            btnDados.FlatStyle = FlatStyle.Flat;
            btnDados.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDados.ForeColor = Color.White;
            btnDados.Image = (Image)resources.GetObject("btnDados.Image");
            btnDados.ImageAlign = ContentAlignment.MiddleLeft;
            btnDados.Location = new Point(-13, -7);
            btnDados.Margin = new Padding(3, 4, 3, 4);
            btnDados.Name = "btnDados";
            btnDados.Padding = new Padding(17, 0, 0, 0);
            btnDados.Size = new Size(245, 75);
            btnDados.TabIndex = 2;
            btnDados.Text = " Dados";
            btnDados.UseVisualStyleBackColor = false;
            btnDados.Click += btnDados_Click;
            // 
            // panelUser
            // 
            panelUser.Controls.Add(btnUser);
            panelUser.Location = new Point(3, 244);
            panelUser.Margin = new Padding(3, 4, 3, 4);
            panelUser.Name = "panelUser";
            panelUser.Size = new Size(214, 59);
            panelUser.TabIndex = 5;
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.Black;
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUser.ForeColor = Color.White;
            btnUser.Image = (Image)resources.GetObject("btnUser.Image");
            btnUser.ImageAlign = ContentAlignment.MiddleLeft;
            btnUser.Location = new Point(-14, -7);
            btnUser.Margin = new Padding(3, 4, 3, 4);
            btnUser.Name = "btnUser";
            btnUser.Padding = new Padding(17, 0, 0, 0);
            btnUser.Size = new Size(245, 75);
            btnUser.TabIndex = 2;
            btnUser.Text = "Ususário";
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUsuario_Click;
            // 
            // panelSettings
            // 
            panelSettings.Controls.Add(btnConfig);
            panelSettings.Location = new Point(3, 311);
            panelSettings.Margin = new Padding(3, 4, 3, 4);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(214, 59);
            panelSettings.TabIndex = 6;
            // 
            // btnConfig
            // 
            btnConfig.BackColor = Color.Black;
            btnConfig.FlatStyle = FlatStyle.Flat;
            btnConfig.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfig.ForeColor = Color.White;
            btnConfig.Image = (Image)resources.GetObject("btnConfig.Image");
            btnConfig.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfig.Location = new Point(-13, -7);
            btnConfig.Margin = new Padding(3, 4, 3, 4);
            btnConfig.Name = "btnConfig";
            btnConfig.Padding = new Padding(17, 0, 0, 0);
            btnConfig.Size = new Size(245, 75);
            btnConfig.TabIndex = 2;
            btnConfig.Text = "Configurações";
            btnConfig.UseVisualStyleBackColor = false;
            btnConfig.Click += btnConfig_Click;
            // 
            // panelSobre
            // 
            panelSobre.Controls.Add(btnSobre);
            panelSobre.Location = new Point(3, 378);
            panelSobre.Margin = new Padding(3, 4, 3, 4);
            panelSobre.Name = "panelSobre";
            panelSobre.Size = new Size(214, 59);
            panelSobre.TabIndex = 8;
            // 
            // btnSobre
            // 
            btnSobre.BackColor = Color.Black;
            btnSobre.FlatStyle = FlatStyle.Flat;
            btnSobre.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSobre.ForeColor = Color.White;
            btnSobre.Image = (Image)resources.GetObject("btnSobre.Image");
            btnSobre.ImageAlign = ContentAlignment.MiddleLeft;
            btnSobre.Location = new Point(-10, -7);
            btnSobre.Margin = new Padding(3, 4, 3, 4);
            btnSobre.Name = "btnSobre";
            btnSobre.Padding = new Padding(17, 0, 0, 0);
            btnSobre.Size = new Size(245, 75);
            btnSobre.TabIndex = 2;
            btnSobre.Text = "Sobre";
            btnSobre.UseVisualStyleBackColor = false;
            btnSobre.Click += btnSobre_Click;
            // 
            // panelLogOut
            // 
            panelLogOut.Controls.Add(btnLogOut);
            panelLogOut.Location = new Point(3, 445);
            panelLogOut.Margin = new Padding(3, 4, 3, 4);
            panelLogOut.Name = "panelLogOut";
            panelLogOut.Size = new Size(214, 59);
            panelLogOut.TabIndex = 7;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.Black;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogOut.ForeColor = Color.White;
            btnLogOut.Image = (Image)resources.GetObject("btnLogOut.Image");
            btnLogOut.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogOut.Location = new Point(-10, -7);
            btnLogOut.Margin = new Padding(3, 4, 3, 4);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Padding = new Padding(17, 0, 0, 0);
            btnLogOut.Size = new Size(245, 75);
            btnLogOut.TabIndex = 2;
            btnLogOut.Text = "Sair";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // sidebarTransition
            // 
            sidebarTransition.Interval = 5;
            sidebarTransition.Tick += sidebarTransition_Tick;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.WhiteSmoke;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(60, 46);
            pnlMain.Margin = new Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(999, 585);
            pnlMain.TabIndex = 3;
            pnlMain.Paint += pnlMain_Paint;
            // 
            // FormOrigin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 631);
            Controls.Add(pnlMain);
            Controls.Add(sidebarMenu);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormOrigin";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnHam).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgLogo).EndInit();
            sidebarMenu.ResumeLayout(false);
            panelHome.ResumeLayout(false);
            panelImportar.ResumeLayout(false);
            panelData.ResumeLayout(false);
            panelUser.ResumeLayout(false);
            panelSettings.ResumeLayout(false);
            panelSobre.ResumeLayout(false);
            panelLogOut.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel sidebarMenu;
        private PictureBox imgLogo;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Button btnImportarDoc;
        private Panel panelImportar;
        private PictureBox btnHam;
        private Panel panelData;
        private Button btnDados;
        private System.Windows.Forms.Timer sidebarTransition;
        private Panel panel5;
        private Panel panelHome;
        private Button btnHome;
        private Panel panelUser;
        private Button btnUser;
        private Panel panelSettings;
        private Button btnConfig;
        private Panel panelLogOut;
        private Button btnLogOut;
        private Panel pnlMain;
        private Panel panelSobre;
        private Button btnSobre;
    }
}
