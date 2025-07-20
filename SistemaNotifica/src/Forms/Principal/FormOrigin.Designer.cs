
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
            topPanel = new Panel();
            metroLabelUser = new ReaLTaiizor.Controls.MetroLabel();
            metroLabelUsuario = new ReaLTaiizor.Controls.MetroLabel();
            btnHam = new PictureBox();
            sidebarMenu = new FlowLayoutPanel();
            panel5 = new Panel();
            panelHome = new Panel();
            btnHome = new Button();
            panelImportar = new Panel();
            btnImportarDoc = new Button();
            panelData = new Panel();
            btnDados = new Button();
            panelSettings = new Panel();
            btnSettings = new Button();
            tableLayoutNotificacao = new TableLayoutPanel();
            panelNotificação = new Panel();
            btnNotificacao = new Button();
            panelSubMenu2 = new Panel();
            btnConfigNotificacao = new Button();
            panelSubMenu1 = new Panel();
            btnEnviarNotificacao = new Button();
            panelUser = new Panel();
            btnUser = new Button();
            panelSobre = new Panel();
            btnSobre = new Button();
            panelLogOut = new Panel();
            btnLogOut = new Button();
            sidebarTransition = new System.Windows.Forms.Timer(components);
            pnlMain = new Panel();
            menuTransition = new System.Windows.Forms.Timer(components);
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnHam).BeginInit();
            sidebarMenu.SuspendLayout();
            panelHome.SuspendLayout();
            panelImportar.SuspendLayout();
            panelData.SuspendLayout();
            panelSettings.SuspendLayout();
            tableLayoutNotificacao.SuspendLayout();
            panelNotificação.SuspendLayout();
            panelSubMenu2.SuspendLayout();
            panelSubMenu1.SuspendLayout();
            panelUser.SuspendLayout();
            panelSobre.SuspendLayout();
            panelLogOut.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.Gray;
            topPanel.Controls.Add(metroLabelUser);
            topPanel.Controls.Add(metroLabelUsuario);
            topPanel.Controls.Add(btnHam);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(927, 33);
            topPanel.TabIndex = 0;
            topPanel.Paint += panel1_Paint;
            // 
            // metroLabelUser
            // 
            metroLabelUser.Font = new Font("Microsoft Sans Serif", 10F);
            metroLabelUser.IsDerivedStyle = true;
            metroLabelUser.Location = new Point(107, 7);
            metroLabelUser.Name = "metroLabelUser";
            metroLabelUser.Size = new Size(45, 23);
            metroLabelUser.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroLabelUser.StyleManager = null;
            metroLabelUser.TabIndex = 4;
            metroLabelUser.Text = "Error";
            metroLabelUser.ThemeAuthor = "Taiizor";
            metroLabelUser.ThemeName = "MetroLight";
            // 
            // metroLabelUsuario
            // 
            metroLabelUsuario.Font = new Font("Microsoft Sans Serif", 10F);
            metroLabelUsuario.IsDerivedStyle = true;
            metroLabelUsuario.Location = new Point(48, 7);
            metroLabelUsuario.Name = "metroLabelUsuario";
            metroLabelUsuario.Size = new Size(65, 23);
            metroLabelUsuario.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroLabelUsuario.StyleManager = null;
            metroLabelUsuario.TabIndex = 0;
            metroLabelUsuario.Text = "Usuário:";
            metroLabelUsuario.ThemeAuthor = "Taiizor";
            metroLabelUsuario.ThemeName = "MetroLight";
            // 
            // btnHam
            // 
            btnHam.Image = (Image)resources.GetObject("btnHam.Image");
            btnHam.Location = new Point(4, 1);
            btnHam.Name = "btnHam";
            btnHam.Size = new Size(38, 32);
            btnHam.SizeMode = PictureBoxSizeMode.CenterImage;
            btnHam.TabIndex = 3;
            btnHam.TabStop = false;
            btnHam.Click += btnHam_Click;
            // 
            // sidebarMenu
            // 
            sidebarMenu.BackColor = Color.Black;
            sidebarMenu.Controls.Add(panel5);
            sidebarMenu.Controls.Add(panelHome);
            sidebarMenu.Controls.Add(panelImportar);
            sidebarMenu.Controls.Add(panelData);
            sidebarMenu.Controls.Add(panelSettings);
            sidebarMenu.Controls.Add(tableLayoutNotificacao);
            sidebarMenu.Controls.Add(panelUser);
            sidebarMenu.Controls.Add(panelSobre);
            sidebarMenu.Controls.Add(panelLogOut);
            sidebarMenu.Dock = DockStyle.Left;
            sidebarMenu.FlowDirection = FlowDirection.TopDown;
            sidebarMenu.Location = new Point(0, 33);
            sidebarMenu.Name = "sidebarMenu";
            sidebarMenu.Size = new Size(190, 440);
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
            panelHome.Location = new Point(0, 29);
            panelHome.Margin = new Padding(0);
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
            btnHome.Location = new Point(-11, -5);
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
            panelImportar.Location = new Point(0, 73);
            panelImportar.Margin = new Padding(0);
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
            panelData.Location = new Point(0, 117);
            panelData.Margin = new Padding(0);
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
            btnDados.Location = new Point(-12, -5);
            btnDados.Name = "btnDados";
            btnDados.Padding = new Padding(15, 0, 0, 0);
            btnDados.Size = new Size(214, 56);
            btnDados.TabIndex = 2;
            btnDados.Text = " Dados";
            btnDados.UseVisualStyleBackColor = false;
            // 
            // panelSettings
            // 
            panelSettings.Controls.Add(btnSettings);
            panelSettings.Location = new Point(0, 161);
            panelSettings.Margin = new Padding(0);
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
            // tableLayoutNotificacao
            // 
            tableLayoutNotificacao.ColumnCount = 1;
            tableLayoutNotificacao.ColumnStyles.Add(new ColumnStyle());
            tableLayoutNotificacao.Controls.Add(panelNotificação, 0, 0);
            tableLayoutNotificacao.Controls.Add(panelSubMenu2, 0, 2);
            tableLayoutNotificacao.Controls.Add(panelSubMenu1, 0, 1);
            tableLayoutNotificacao.Location = new Point(0, 205);
            tableLayoutNotificacao.Margin = new Padding(0);
            tableLayoutNotificacao.Name = "tableLayoutNotificacao";
            tableLayoutNotificacao.RowCount = 3;
            tableLayoutNotificacao.RowStyles.Add(new RowStyle());
            tableLayoutNotificacao.RowStyles.Add(new RowStyle());
            tableLayoutNotificacao.RowStyles.Add(new RowStyle());
            tableLayoutNotificacao.Size = new Size(187, 43);
            tableLayoutNotificacao.TabIndex = 9;
            // 
            // panelNotificação
            // 
            panelNotificação.Controls.Add(btnNotificacao);
            panelNotificação.Location = new Point(0, 0);
            panelNotificação.Margin = new Padding(0);
            panelNotificação.Name = "panelNotificação";
            panelNotificação.Size = new Size(187, 43);
            panelNotificação.TabIndex = 6;
            // 
            // btnNotificacao
            // 
            btnNotificacao.BackColor = Color.Black;
            btnNotificacao.FlatStyle = FlatStyle.Flat;
            btnNotificacao.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNotificacao.ForeColor = Color.White;
            btnNotificacao.Image = (Image)resources.GetObject("btnNotificacao.Image");
            btnNotificacao.ImageAlign = ContentAlignment.MiddleLeft;
            btnNotificacao.Location = new Point(-12, -5);
            btnNotificacao.Name = "btnNotificacao";
            btnNotificacao.Padding = new Padding(15, 0, 0, 0);
            btnNotificacao.Size = new Size(214, 56);
            btnNotificacao.TabIndex = 2;
            btnNotificacao.Text = "Notificação";
            btnNotificacao.UseVisualStyleBackColor = false;
            btnNotificacao.Click += btnNotificacao_Click;
            // 
            // panelSubMenu2
            // 
            panelSubMenu2.Controls.Add(btnConfigNotificacao);
            panelSubMenu2.Location = new Point(0, 87);
            panelSubMenu2.Margin = new Padding(0);
            panelSubMenu2.Name = "panelSubMenu2";
            panelSubMenu2.Size = new Size(187, 44);
            panelSubMenu2.TabIndex = 8;
            // 
            // btnConfigNotificacao
            // 
            btnConfigNotificacao.BackColor = Color.Black;
            btnConfigNotificacao.FlatStyle = FlatStyle.Flat;
            btnConfigNotificacao.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfigNotificacao.ForeColor = Color.White;
            btnConfigNotificacao.Image = (Image)resources.GetObject("btnConfigNotificacao.Image");
            btnConfigNotificacao.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfigNotificacao.Location = new Point(12, -6);
            btnConfigNotificacao.Name = "btnConfigNotificacao";
            btnConfigNotificacao.Padding = new Padding(5, 0, 0, 0);
            btnConfigNotificacao.Size = new Size(178, 56);
            btnConfigNotificacao.TabIndex = 2;
            btnConfigNotificacao.Text = "   Config Notificação";
            btnConfigNotificacao.TextAlign = ContentAlignment.MiddleRight;
            btnConfigNotificacao.UseVisualStyleBackColor = false;
            btnConfigNotificacao.Click += btnConfigNotificacao_Click;
            // 
            // panelSubMenu1
            // 
            panelSubMenu1.Controls.Add(btnEnviarNotificacao);
            panelSubMenu1.Location = new Point(0, 43);
            panelSubMenu1.Margin = new Padding(0);
            panelSubMenu1.Name = "panelSubMenu1";
            panelSubMenu1.Size = new Size(187, 44);
            panelSubMenu1.TabIndex = 7;
            // 
            // btnEnviarNotificacao
            // 
            btnEnviarNotificacao.BackColor = Color.Black;
            btnEnviarNotificacao.FlatStyle = FlatStyle.Flat;
            btnEnviarNotificacao.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEnviarNotificacao.ForeColor = Color.White;
            btnEnviarNotificacao.Image = (Image)resources.GetObject("btnEnviarNotificacao.Image");
            btnEnviarNotificacao.ImageAlign = ContentAlignment.MiddleLeft;
            btnEnviarNotificacao.Location = new Point(12, -5);
            btnEnviarNotificacao.Margin = new Padding(0);
            btnEnviarNotificacao.Name = "btnEnviarNotificacao";
            btnEnviarNotificacao.Padding = new Padding(5, 0, 0, 0);
            btnEnviarNotificacao.Size = new Size(178, 56);
            btnEnviarNotificacao.TabIndex = 2;
            btnEnviarNotificacao.Text = "   Enviar Notificação";
            btnEnviarNotificacao.TextAlign = ContentAlignment.MiddleRight;
            btnEnviarNotificacao.UseVisualStyleBackColor = false;
            btnEnviarNotificacao.Click += btnEnviarNotificacao_Click;
            // 
            // panelUser
            // 
            panelUser.Controls.Add(btnUser);
            panelUser.Location = new Point(0, 248);
            panelUser.Margin = new Padding(0);
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
            // panelSobre
            // 
            panelSobre.Controls.Add(btnSobre);
            panelSobre.Location = new Point(0, 292);
            panelSobre.Margin = new Padding(0);
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
            panelLogOut.Location = new Point(0, 336);
            panelLogOut.Margin = new Padding(0);
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
            btnLogOut.Location = new Point(-7, -5);
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
            pnlMain.BackColor = SystemColors.Control;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(190, 33);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(737, 440);
            pnlMain.TabIndex = 3;
            pnlMain.Paint += pnlMain_Paint;
            // 
            // menuTransition
            // 
            menuTransition.Tick += menuTransition_Tick;
            // 
            // FormOrigin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 473);
            Controls.Add(pnlMain);
            Controls.Add(sidebarMenu);
            Controls.Add(topPanel);
            IsMdiContainer = true;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "FormOrigin";
            Text = "Form1";
            topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnHam).EndInit();
            sidebarMenu.ResumeLayout(false);
            panelHome.ResumeLayout(false);
            panelImportar.ResumeLayout(false);
            panelData.ResumeLayout(false);
            panelSettings.ResumeLayout(false);
            tableLayoutNotificacao.ResumeLayout(false);
            panelNotificação.ResumeLayout(false);
            panelSubMenu2.ResumeLayout(false);
            panelSubMenu1.ResumeLayout(false);
            panelUser.ResumeLayout(false);
            panelSobre.ResumeLayout(false);
            panelLogOut.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        #endregion

        private Panel topPanel;
        private FlowLayoutPanel sidebarMenu;
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
        private Panel panelNotificação;
        private Button btnNotificacao;
        private Panel panelSubMenu1;
        private Button btnEnviarNotificacao;
        private TableLayoutPanel tableLayoutNotificacao;
        private Panel panelSubMenu2;
        private Button btnConfigNotificacao;
        private System.Windows.Forms.Timer menuTransition;
        private ReaLTaiizor.Controls.MetroLabel metroLabelUser;
        private ReaLTaiizor.Controls.MetroLabel metroLabelUsuario;
    }
}
