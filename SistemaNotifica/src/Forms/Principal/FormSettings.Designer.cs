namespace SistemaNotifica.src.Forms.Principal
{
    partial class FormSettings
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
            lable = new Label();
            SuspendLayout();
            // 
            // lable
            // 
            lable.AutoSize = true;
            lable.Location = new Point(315, 80);
            lable.Name = "lable";
            lable.Size = new Size(98, 20);
            lable.TabIndex = 0;
            lable.Text = "TELA CONFIG";
            lable.Click += btnConfig_Click;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1330, 855);
            Controls.Add(lable);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormSettings";
            Text = "FormSettings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lable;
    }
}