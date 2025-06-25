namespace SistemaNotifica
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            topPanel = new Panel();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            imgLogo = new PictureBox();
            panelLogin = new Panel();
            btnLogin = new Button();
            textBoxPassword = new TextBox();
            textBoxName = new TextBox();
            lblTituloLogin = new Label();
            lblInstrucaoLogin = new Label();
            poisonContextMenuStrip1 = new ReaLTaiizor.Controls.PoisonContextMenuStrip(components);
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgLogo).BeginInit();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(64, 64, 64);
            topPanel.Controls.Add(nightControlBox1);
            topPanel.Controls.Add(imgLogo);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1164, 40);
            topPanel.TabIndex = 1;
            // 
            // nightControlBox1
            // 
            nightControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nightControlBox1.BackColor = Color.Transparent;
            nightControlBox1.CloseHoverColor = Color.FromArgb(232, 17, 35);
            nightControlBox1.CloseHoverForeColor = Color.White;
            nightControlBox1.DefaultLocation = true;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.EnableCloseColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMaximizeButton = true;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.Location = new Point(1025, 0);
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
            imgLogo.Location = new Point(10, 5);
            imgLogo.Name = "imgLogo";
            imgLogo.Size = new Size(90, 30);
            imgLogo.SizeMode = PictureBoxSizeMode.Zoom;
            imgLogo.TabIndex = 2;
            imgLogo.TabStop = false;
            // 
            // panelLogin
            // 
            panelLogin.Anchor = AnchorStyles.None;
            panelLogin.BackColor = Color.FromArgb(240, 240, 240);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(textBoxPassword);
            panelLogin.Controls.Add(textBoxName);
            panelLogin.Controls.Add(lblTituloLogin);
            panelLogin.Controls.Add(lblInstrucaoLogin);
            panelLogin.Location = new Point(350, 150);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(460, 380);
            panelLogin.TabIndex = 6;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 122, 204);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(130, 290);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(200, 40);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Entrar";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 10F);
            textBoxPassword.Location = new Point(80, 220);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.PlaceholderText = "Senha";
            textBoxPassword.Size = new Size(300, 25);
            textBoxPassword.TabIndex = 4;
            textBoxPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Segoe UI", 10F);
            textBoxName.Location = new Point(80, 160);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Nome de Usuário";
            textBoxName.Size = new Size(300, 25);
            textBoxName.TabIndex = 2;
            textBoxName.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTituloLogin
            // 
            lblTituloLogin.AutoSize = true;
            lblTituloLogin.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            lblTituloLogin.ForeColor = Color.FromArgb(64, 64, 64);
            lblTituloLogin.Location = new Point(50, 40);
            lblTituloLogin.Name = "lblTituloLogin";
            lblTituloLogin.Size = new Size(351, 32);
            lblTituloLogin.TabIndex = 6;
            lblTituloLogin.Text = "Bem-vindo ao Sistema Notifica";
            lblTituloLogin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInstrucaoLogin
            // 
            lblInstrucaoLogin.AutoSize = true;
            lblInstrucaoLogin.Font = new Font("Segoe UI", 9.5F);
            lblInstrucaoLogin.ForeColor = Color.FromArgb(100, 100, 100);
            lblInstrucaoLogin.Location = new Point(80, 90);
            lblInstrucaoLogin.Name = "lblInstrucaoLogin";
            lblInstrucaoLogin.Size = new Size(270, 17);
            lblInstrucaoLogin.TabIndex = 7;
            lblInstrucaoLogin.Text = "Insira suas credenciais abaixo para continuar";
            lblInstrucaoLogin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // poisonContextMenuStrip1
            // 
            poisonContextMenuStrip1.Name = "poisonContextMenuStrip1";
            poisonContextMenuStrip1.Size = new Size(61, 4);
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 230, 230);
            ClientSize = new Size(1164, 641);
            Controls.Add(panelLogin);
            Controls.Add(topPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogin";
            Load += FormLogin_Load;
            topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imgLogo).EndInit();
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTituloLogin;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Panel topPanel;
        private PictureBox imgLogo;
        private TextBox textBoxName;
        private ReaLTaiizor.Controls.PoisonContextMenuStrip poisonContextMenuStrip1;
        private TextBox textBoxPassword;
        private Button btnLogin;
        private Panel panelLogin;
        private Label lblInstrucaoLogin;
    }
}