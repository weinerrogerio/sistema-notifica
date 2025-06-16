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
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            label1 = new Label();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            topPanel = new Panel();
            imgLogo = new PictureBox();
            textBoxName = new TextBox();
            poisonContextMenuStrip1 = new ReaLTaiizor.Controls.PoisonContextMenuStrip(components);
            textBoxPassword = new TextBox();
            btnLogin = new Button();
            panel2 = new Panel();
            label2 = new Label();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgLogo).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 38);
            label1.Name = "label1";
            label1.Size = new Size(241, 15);
            label1.TabIndex = 0;
            label1.Text = "BEM VINDO AO SISTEMA DE NOTIFICAÇÕES";
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
            nightControlBox1.Location = new Point(1025, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 2;
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.Silver;
            topPanel.Controls.Add(nightControlBox1);
            topPanel.Controls.Add(imgLogo);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1164, 33);
            topPanel.TabIndex = 1;
            // 
            // imgLogo
            // 
            imgLogo.BackgroundImageLayout = ImageLayout.None;
            imgLogo.Image = (Image)resources.GetObject("imgLogo.Image");
            imgLogo.Location = new Point(0, 0);
            imgLogo.Name = "imgLogo";
            imgLogo.Size = new Size(99, 33);
            imgLogo.SizeMode = PictureBoxSizeMode.Zoom;
            imgLogo.TabIndex = 2;
            imgLogo.TabStop = false;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(76, 135);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(306, 23);
            textBoxName.TabIndex = 2;
            // 
            // poisonContextMenuStrip1
            // 
            poisonContextMenuStrip1.Name = "poisonContextMenuStrip1";
            poisonContextMenuStrip1.Size = new Size(61, 4);
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(112, 207);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(224, 23);
            textBoxPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(184, 283);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Entrar";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(textBoxName);
            panel2.Controls.Add(btnLogin);
            panel2.Controls.Add(textBoxPassword);
            panel2.Location = new Point(375, 133);
            panel2.Name = "panel2";
            panel2.Size = new Size(455, 358);
            panel2.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 73);
            label2.Name = "label2";
            label2.Size = new Size(296, 15);
            label2.TabIndex = 6;
            label2.Text = "INSIRA OS DADOS DE USUÁRIO ABAIXO PARA ENTRAR";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1164, 641);
            Controls.Add(panel2);
            Controls.Add(topPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogin";
            topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imgLogo).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Panel topPanel;
        private PictureBox imgLogo;
        private TextBox textBoxName;
        private ReaLTaiizor.Controls.PoisonContextMenuStrip poisonContextMenuStrip1;
        private TextBox textBoxPassword;
        private Button btnLogin;
        private Panel panel2;
        private Label label2;
    }
}