namespace SistemaNotifica.src.FormsTestes
{
    partial class ProgressOverlayForm
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
            pnlProgressUpload = new Panel();
            labelStatusUpload = new Label();
            progressBarUpload = new ProgressBar();
            lblPercent = new Label();
            pnlProgressUpload.SuspendLayout();
            SuspendLayout();
            // 
            // pnlProgressUpload
            // 
            pnlProgressUpload.BackColor = Color.White;
            pnlProgressUpload.BorderStyle = BorderStyle.FixedSingle;
            pnlProgressUpload.Controls.Add(labelStatusUpload);
            pnlProgressUpload.Controls.Add(progressBarUpload);
            pnlProgressUpload.Controls.Add(lblPercent);
            pnlProgressUpload.Location = new Point(100, 100);
            pnlProgressUpload.Name = "pnlProgressUpload";
            pnlProgressUpload.Padding = new Padding(20);
            pnlProgressUpload.Size = new Size(450, 140);
            pnlProgressUpload.TabIndex = 0;
            // 
            // labelStatusUpload
            // 
            labelStatusUpload.AutoSize = true;
            labelStatusUpload.Font = new Font("Segoe UI", 11F);
            labelStatusUpload.ForeColor = Color.FromArgb(      64,       64,       64);
            labelStatusUpload.Location = new Point(40, 45);
            labelStatusUpload.Name = "labelStatusUpload";
            labelStatusUpload.Size = new Size(155, 20);
            labelStatusUpload.TabIndex = 0;
            labelStatusUpload.Text = "Processando arquivo...";
            // 
            // progressBarUpload
            // 
            progressBarUpload.Location = new Point(20, 65);
            progressBarUpload.Name = "progressBarUpload";
            progressBarUpload.Size = new Size(410, 30);
            progressBarUpload.Style = ProgressBarStyle.Continuous;
            progressBarUpload.TabIndex = 1;
            // 
            // lblPercent
            // 
            lblPercent.AutoSize = true;
            lblPercent.Font = new Font("Segoe UI", 9F);
            lblPercent.ForeColor = Color.Gray;
            lblPercent.Location = new Point(20, 105);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(23, 15);
            lblPercent.TabIndex = 2;
            lblPercent.Text = "0%";
            // 
            // ProgressOverlayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(664, 351);
            Controls.Add(pnlProgressUpload);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "ProgressOverlayForm";
            Opacity = 0.1D;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "ProgressOverlayForm";
            TopMost = true;
            TransparencyKey = Color.Transparent;
            pnlProgressUpload.ResumeLayout(false);
            pnlProgressUpload.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblPercent;
    }
}