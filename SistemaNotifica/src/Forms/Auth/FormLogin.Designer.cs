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
<<<<<<< HEAD
            btnCancelar = new Button();
            label4 = new Label();
            label3 = new Label();
=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
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
<<<<<<< HEAD
            label1.Size = new Size(239, 15);
=======
            label1.Size = new Size(241, 15);
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
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
<<<<<<< HEAD
            textBoxName.TextChanged += textBoxName_TextChanged;
=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
            // 
            // poisonContextMenuStrip1
            // 
            poisonContextMenuStrip1.Name = "poisonContextMenuStrip1";
            poisonContextMenuStrip1.Size = new Size(61, 4);
            // 
            // textBoxPassword
            // 
<<<<<<< HEAD
            textBoxPassword.Location = new Point(117, 189);
=======
            textBoxPassword.Location = new Point(112, 207);
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(224, 23);
            textBoxPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
<<<<<<< HEAD
            btnLogin.BackColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.Black;
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.Location = new Point(140, 227);
=======
            btnLogin.Location = new Point(184, 283);
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Entrar";
<<<<<<< HEAD
            btnLogin.UseVisualStyleBackColor = false;
=======
            btnLogin.UseVisualStyleBackColor = true;
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
            btnLogin.Click += btnLogin_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
<<<<<<< HEAD
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(btnCancelar);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
=======
            panel2.BackColor = Color.FromArgb(224, 224, 224);
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
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
<<<<<<< HEAD
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(240, 227);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(117, 174);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 8;
            label4.Text = "Senha:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(76, 120);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 7;
            label3.Text = "Nome de Usuário:";
            // 
=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 73);
            label2.Name = "label2";
<<<<<<< HEAD
            label2.Size = new Size(295, 15);
=======
            label2.Size = new Size(296, 15);
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
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
<<<<<<< HEAD
            KeyPreview = true;
=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
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
<<<<<<< HEAD
        private Label label4;
        private Label label3;
        private Button btnCancelar;
=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
    }
}