namespace SistemaNotifica.src.Forms
{
    partial class FormHome
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
            labelHome = new Label();
            panelHome = new Panel();
            panelHeader = new Panel();
            panelHome.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // labelHome
            // 
            labelHome.AutoSize = true;
            labelHome.Location = new Point(363, 6);
            labelHome.Name = "labelHome";
            labelHome.Size = new Size(77, 15);
            labelHome.TabIndex = 0;
            labelHome.Text = "TELA INICIAL";
            // 
            // panelHome
            // 
            panelHome.Controls.Add(panelHeader);
            panelHome.Dock = DockStyle.Fill;
            panelHome.Location = new Point(0, 0);
            panelHome.Name = "panelHome";
            panelHome.Size = new Size(800, 450);
            panelHome.TabIndex = 1;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(labelHome);
            panelHeader.Location = new Point(3, 3);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(794, 26);
            panelHeader.TabIndex = 1;
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelHome);
            Name = "FormHome";
            Text = "FormHome";
            panelHome.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelHome;
        private Panel panelHome;
        private Panel panelHeader;
    }
}