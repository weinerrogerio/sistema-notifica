namespace SistemaNotifica.src.Forms.Principal
{
    partial class FormConfig
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
            panelUserData = new Panel();
            panelUserDataBox = new Panel();
            panelLogin = new Panel();
            lblErrorMessage = new Label();
            btnLogin = new Button();
            textBoxPassword = new TextBox();
            textBoxName = new TextBox();
            lblTituloLogin = new Label();
            lblInstrucaoLogin = new Label();
            panelUserData.SuspendLayout();
            panelUserDataBox.SuspendLayout();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelUserData
            // 
            panelUserData.Controls.Add(panelUserDataBox);
            panelUserData.Dock = DockStyle.Fill;
            panelUserData.Location = new Point(0, 0);
            panelUserData.Name = "panelUserData";
            panelUserData.Size = new Size(843, 434);
            panelUserData.TabIndex = 9;
            // 
            // panelUserDataBox
            // 
            panelUserDataBox.Controls.Add(panelLogin);
            panelUserDataBox.Dock = DockStyle.Fill;
            panelUserDataBox.Location = new Point(0, 0);
            panelUserDataBox.Name = "panelUserDataBox";
            panelUserDataBox.Size = new Size(843, 434);
            panelUserDataBox.TabIndex = 0;
            // 
            // panelLogin
            // 
            panelLogin.BackColor = SystemColors.Window;
            panelLogin.Controls.Add(lblErrorMessage);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(textBoxPassword);
            panelLogin.Controls.Add(textBoxName);
            panelLogin.Controls.Add(lblTituloLogin);
            panelLogin.Controls.Add(lblInstrucaoLogin);
            panelLogin.Location = new Point(12, 12);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(457, 366);
            panelLogin.TabIndex = 7;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Location = new Point(0, 142);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(200, 15);
            lblErrorMessage.TabIndex = 8;
            lblErrorMessage.Text = "labelError";
            lblErrorMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblErrorMessage.Visible = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(      0,       122,       204);
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
            lblTituloLogin.ForeColor = Color.FromArgb(      64,       64,       64);
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
            lblInstrucaoLogin.ForeColor = Color.FromArgb(      100,       100,       100);
            lblInstrucaoLogin.Location = new Point(80, 90);
            lblInstrucaoLogin.Name = "lblInstrucaoLogin";
            lblInstrucaoLogin.Size = new Size(270, 17);
            lblInstrucaoLogin.TabIndex = 7;
            lblInstrucaoLogin.Text = "Insira suas credenciais abaixo para continuar";
            lblInstrucaoLogin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 434);
            Controls.Add(panelUserData);
            Name = "FormConfig";
            Text = "FormConfig";
            Load +=  FormConfig_Load ;
            Resize +=  FormConfig_Resize ;
            panelUserData.ResumeLayout(false);
            panelUserDataBox.ResumeLayout(false);
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelUserData;
        private Panel panelUserDataBox;
        private Panel panelLogin;
        private Label lblErrorMessage;
        private Button btnLogin;
        private TextBox textBoxPassword;
        private TextBox textBoxName;
        private Label lblTituloLogin;
        private Label lblInstrucaoLogin;
    }
}