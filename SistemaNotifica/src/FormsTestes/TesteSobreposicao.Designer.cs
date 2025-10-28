namespace SistemaNotifica.src.FormsTestes
{
    partial class TesteSobreposicao
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
            panel2 = new Panel();
            overlayPanel = new Panel();
            hideOverlayButton = new Button();
            showOverlayButton = new Button();
            panel3 = new Panel();
            mainPanel = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.IndianRed;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(694, 416);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(overlayPanel);
            panel2.Controls.Add(hideOverlayButton);
            panel2.Controls.Add(showOverlayButton);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(688, 202);
            panel2.TabIndex = 0;
            // 
            // overlayPanel
            // 
            overlayPanel.BackColor = SystemColors.Control;
            overlayPanel.Location = new Point(181, 141);
            overlayPanel.Name = "overlayPanel";
            overlayPanel.Size = new Size(326, 118);
            overlayPanel.TabIndex = 0;
            overlayPanel.Visible = false;
            // 
            // hideOverlayButton
            // 
            hideOverlayButton.Location = new Point(285, 38);
            hideOverlayButton.Name = "hideOverlayButton";
            hideOverlayButton.Size = new Size(75, 23);
            hideOverlayButton.TabIndex = 1;
            hideOverlayButton.Text = "hide";
            hideOverlayButton.UseVisualStyleBackColor = true;
            hideOverlayButton.Click +=  hideOverlayButton_Click ;
            // 
            // showOverlayButton
            // 
            showOverlayButton.Location = new Point(285, 9);
            showOverlayButton.Name = "showOverlayButton";
            showOverlayButton.Size = new Size(75, 23);
            showOverlayButton.TabIndex = 0;
            showOverlayButton.Text = "show";
            showOverlayButton.UseVisualStyleBackColor = true;
            showOverlayButton.Click +=  showOverlayButton_Click ;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.MenuHighlight;
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 211);
            panel3.Name = "panel3";
            panel3.Size = new Size(688, 202);
            panel3.TabIndex = 1;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(tableLayoutPanel1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(694, 416);
            mainPanel.TabIndex = 1;
            // 
            // TesteSobreposicao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 416);
            Controls.Add(mainPanel);
            Name = "TesteSobreposicao";
            Text = "TesteSobreposicao";
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel3;
        private Panel mainPanel;
        private Panel overlayPanel;
        private Button hideOverlayButton;
        private Button showOverlayButton;
    }
}