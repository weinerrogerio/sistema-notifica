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
            if ( disposing && ( components != null ) )
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            panel1 = new Panel();
            panelConteudo = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnConBkend = new Button();
            btnExternalSenderService = new Button();
            btnSmtpEmail = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 92F));
            tableLayoutPanel1.Size = new Size(885, 367);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point,    0);
            label3.Location = new Point(0, 4);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(226, 20);
            label3.TabIndex = 2;
            label3.Text = "CONFIGURAÇÕES DO SISTEMA";
            // 
            // panel1
            // 
            panel1.Controls.Add(panelConteudo);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 29);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(885, 338);
            panel1.TabIndex = 3;
            // 
            // panelConteudo
            // 
            panelConteudo.BorderStyle = BorderStyle.FixedSingle;
            panelConteudo.Dock = DockStyle.Fill;
            panelConteudo.Location = new Point(181, 0);
            panelConteudo.Margin = new Padding(0);
            panelConteudo.Name = "panelConteudo";
            panelConteudo.Size = new Size(704, 338);
            panelConteudo.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(btnConBkend);
            flowLayoutPanel1.Controls.Add(btnExternalSenderService);
            flowLayoutPanel1.Controls.Add(btnSmtpEmail);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(181, 338);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // btnConBkend
            // 
            btnConBkend.Location = new Point(3, 10);
            btnConBkend.Margin = new Padding(3, 10, 3, 0);
            btnConBkend.Name = "btnConBkend";
            btnConBkend.Size = new Size(178, 26);
            btnConBkend.TabIndex = 0;
            btnConBkend.Text = "Conexão com backend";
            btnConBkend.UseVisualStyleBackColor = true;
            btnConBkend.Click +=  btnConBkend_Click ;
            // 
            // btnExternalSenderService
            // 
            btnExternalSenderService.Location = new Point(3, 39);
            btnExternalSenderService.Margin = new Padding(3, 3, 3, 0);
            btnExternalSenderService.Name = "btnExternalSenderService";
            btnExternalSenderService.Size = new Size(178, 26);
            btnExternalSenderService.TabIndex = 2;
            btnExternalSenderService.Text = "Email - Serviço de envio";
            btnExternalSenderService.UseVisualStyleBackColor = true;
            btnExternalSenderService.Click +=  btnExternalSenderService_Click ;
            // 
            // btnSmtpEmail
            // 
            btnSmtpEmail.Location = new Point(3, 68);
            btnSmtpEmail.Margin = new Padding(3, 3, 3, 0);
            btnSmtpEmail.Name = "btnSmtpEmail";
            btnSmtpEmail.Size = new Size(178, 26);
            btnSmtpEmail.TabIndex = 3;
            btnSmtpEmail.Text = "Email - Remetente Local";
            btnSmtpEmail.UseVisualStyleBackColor = true;
            btnSmtpEmail.Click +=  btnSmtpEmail_Click ;
            // 
            // FormConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 367);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(700, 355);
            Name = "FormConfig";
            Text = "FormConfig";
            Load +=  FormConfig_Load ;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnConBkend;
        private Button btnExternalSenderService;
        private Button btnSmtpEmail;
        private Panel panelConteudo;
    }
}