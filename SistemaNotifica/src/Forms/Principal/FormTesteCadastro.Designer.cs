namespace SistemaNotifica.src.Forms.Principal
{
    partial class FormTesteCadastro
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
            buttonSave = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            buttonSave.BackColor = Color.FromArgb(      0,       122,       204);
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 9.75F);
            buttonSave.ForeColor = SystemColors.Control;
            buttonSave.Location = new Point(376, 76);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(92, 38);
            buttonSave.TabIndex = 14;
            buttonSave.Text = "teste";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click +=  buttonSave_Click ;
            // 
            // button1
            // 
            button1.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            button1.BackColor = Color.FromArgb(      0,       122,       204);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9.75F);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(375, 179);
            button1.Name = "button1";
            button1.Size = new Size(92, 38);
            button1.TabIndex = 15;
            button1.Text = "teste2";
            button1.UseVisualStyleBackColor = false;
            button1.Click +=  button1_Click ;
            // 
            // button2
            // 
            button2.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            button2.BackColor = Color.FromArgb(      0,       122,       204);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9.75F);
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(375, 279);
            button2.Name = "button2";
            button2.Size = new Size(92, 38);
            button2.TabIndex = 16;
            button2.Text = "Salvar";
            button2.UseVisualStyleBackColor = false;
            // 
            // FormTesteCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 434);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(buttonSave);
            Name = "FormTesteCadastro";
            Text = "FormConfig";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSave;
        private Button button1;
        private Button button2;
    }
}