
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
            btnSettings = new Button();
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
            panel1.Name = "panel1";
            panel1.Size = new Size(927, 33);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnHam
            // 
            btnHam.Image = (Image)resources.GetObject("btnHam.Image");
            btnHam.Location = new Point(7, 0);
            btnHam.Name = "btnHam";
            btnHam.Size = new Size(38, 32);
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
            nightControlBox1.Location = new Point(788, 0);
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
            imgLogo.Location = new Point(54, 0);
            imgLogo.Name = "imgLogo";
            imgLogo.Size = new Size(99, 33);
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
            sidebarMenu.Location = new Point(0, 33);
            sidebarMenu.Name = "sidebarMenu";
            sidebarMenu.Size = new Size(50, 440);
            sidebarMenu.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(200, 23);
            panel5.TabIndex = 4;
            // 
            // panelHome
            // 
            panelHome.Controls.Add(btnHome);
            panelHome.Location = new Point(3, 32);
            panelHome.Name = "panelHome";
            panelHome.Size = new Size(187, 44);
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
            btnHome.Location = new Point(-12, -5);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(15, 0, 0, 0);
            btnHome.Size = new Size(214, 56);
            btnHome.TabIndex = 2;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // panelImportar
            // 
            panelImportar.Controls.Add(btnImportarDoc);
            panelImportar.Location = new Point(3, 82);
            panelImportar.Name = "panelImportar";
            panelImportar.Size = new Size(187, 44);
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
            btnImportarDoc.Location = new Point(-11, -11);
            btnImportarDoc.Name = "btnImportarDoc";
            btnImportarDoc.Padding = new Padding(15, 0, 0, 0);
            btnImportarDoc.Size = new Size(209, 61);
            btnImportarDoc.TabIndex = 2;
            btnImportarDoc.Text = "     Importar";
            btnImportarDoc.UseVisualStyleBackColor = false;
            btnImportarDoc.Click += btnImportarDoc_Click;
            // 
            // panelData
            // 
            panelData.Controls.Add(btnDados);
            panelData.Location = new Point(3, 132);
            panelData.Name = "panelData";
            panelData.Size = new Size(187, 44);
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
            btnDados.Location = new Point(-11, -5);
            btnDados.Name = "btnDados";
            btnDados.Padding = new Padding(15, 0, 0, 0);
            btnDados.Size = new Size(214, 56);
            btnDados.TabIndex = 2;
            btnDados.Text = " Dados";
            btnDados.UseVisualStyleBackColor = false;
            // 
            // panelUser
            // 
            panelUser.Controls.Add(btnUser);
            panelUser.Location = new Point(3, 182);
            panelUser.Name = "panelUser";
            panelUser.Size = new Size(187, 44);
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
            btnUser.Location = new Point(-12, -5);
            btnUser.Name = "btnUser";
            btnUser.Padding = new Padding(15, 0, 0, 0);
            btnUser.Size = new Size(214, 56);
            btnUser.TabIndex = 2;
            btnUser.Text = "Ususário";
            btnUser.UseVisualStyleBackColor = false;
            // 
            // panelSettings
            // 
            panelSettings.Controls.Add(btnSettings);
            panelSettings.Location = new Point(3, 232);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(187, 44);
            panelSettings.TabIndex = 6;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Black;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSettings.ForeColor = Color.White;
            btnSettings.Image = (Image)resources.GetObject("btnSettings.Image");
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(-11, -5);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(15, 0, 0, 0);
            btnSettings.Size = new Size(214, 56);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "Configurações";
            btnSettings.UseVisualStyleBackColor = false;
            // 
            // panelSobre
            // 
            panelSobre.Controls.Add(btnSobre);
            panelSobre.Location = new Point(3, 282);
            panelSobre.Name = "panelSobre";
            panelSobre.Size = new Size(187, 44);
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
            btnSobre.Location = new Point(-9, -5);
            btnSobre.Name = "btnSobre";
            btnSobre.Padding = new Padding(15, 0, 0, 0);
            btnSobre.Size = new Size(214, 56);
            btnSobre.TabIndex = 2;
            btnSobre.Text = "Sobre";
            btnSobre.UseVisualStyleBackColor = false;
            // 
            // panelLogOut
            // 
            panelLogOut.Controls.Add(btnLogOut);
            panelLogOut.Location = new Point(3, 332);
            panelLogOut.Name = "panelLogOut";
            panelLogOut.Size = new Size(187, 44);
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
            btnLogOut.Location = new Point(-9, -5);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Padding = new Padding(15, 0, 0, 0);
            btnLogOut.Size = new Size(214, 56);
            btnLogOut.TabIndex = 2;
            btnLogOut.Text = "Sair";
            btnLogOut.UseVisualStyleBackColor = false;
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
            pnlMain.Location = new Point(50, 33);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(877, 440);
            pnlMain.TabIndex = 3;
            pnlMain.Paint += pnlMain_Paint;
            // 
            // FormOrigin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 473);
            Controls.Add(pnlMain);
            Controls.Add(sidebarMenu);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
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
        private Button btnSettings;
        private Panel panelLogOut;
        private Button btnLogOut;
        private Panel pnlMain;
        private Panel panelSobre;
        private Button btnSobre;
    }
}
