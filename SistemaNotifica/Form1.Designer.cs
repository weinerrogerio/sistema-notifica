namespace SistemaNotifica
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            btnHam = new PictureBox();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            imgLogo = new PictureBox();
            sidebarMenu = new FlowLayoutPanel();
            panel5 = new Panel();
            panelImportar = new Panel();
            btnImportarDoc = new Button();
            panel7 = new Panel();
            btnDados = new Button();
            sidebarTransition = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnHam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgLogo).BeginInit();
            sidebarMenu.SuspendLayout();
            panelImportar.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnHam);
            panel1.Controls.Add(nightControlBox1);
            panel1.Controls.Add(imgLogo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(927, 33);
            panel1.TabIndex = 0;
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
            sidebarMenu.Controls.Add(panelImportar);
            sidebarMenu.Controls.Add(panel7);
            sidebarMenu.Dock = DockStyle.Left;
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
            // panelImportar
            // 
            panelImportar.Controls.Add(btnImportarDoc);
            panelImportar.Location = new Point(3, 32);
            panelImportar.Name = "panelImportar";
            panelImportar.Size = new Size(193, 44);
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
            btnImportarDoc.Text = "   Importar";
            btnImportarDoc.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            panel7.Controls.Add(btnDados);
            panel7.Location = new Point(3, 82);
            panel7.Name = "panel7";
            panel7.Size = new Size(193, 44);
            panel7.TabIndex = 4;
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
            btnDados.Text = "Dados";
            btnDados.UseVisualStyleBackColor = false;
            // 
            // sidebarTransition
            // 
            sidebarTransition.Interval = 5;
            sidebarTransition.Tick += sidebarTransition_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 473);
            Controls.Add(sidebarMenu);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnHam).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgLogo).EndInit();
            sidebarMenu.ResumeLayout(false);
            panelImportar.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel sidebarMenu;
        private PictureBox imgLogo;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Button btnImportarDoc;
        private Panel panelImportar;
        private PictureBox btnHam;
        private Panel panel7;
        private Button btnDados;
        private System.Windows.Forms.Timer sidebarTransition;
        private Panel panel5;
    }
}
