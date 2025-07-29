namespace SistemaNotifica.src.Forms.Principal
{
    partial class FormRegistrosJaEnviados
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
            flowLayoutPanelMain = new FlowLayoutPanel();
            panelTop = new Panel();
            dataGridViewData = new DataGridView();
            panelBotton = new Panel();
            flowLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            flowLayoutPanelMain.Controls.Add(panelTop);
            flowLayoutPanelMain.Controls.Add(dataGridViewData);
            flowLayoutPanelMain.Controls.Add(panelBotton);
            flowLayoutPanelMain.Dock = DockStyle.Fill;
            flowLayoutPanelMain.Location = new Point(150, 0);
            flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            flowLayoutPanelMain.Size = new Size(500, 450);
            flowLayoutPanelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.Location = new Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(497, 53);
            panelTop.TabIndex = 0;
            // 
            // dataGridViewData
            // 
            dataGridViewData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewData.Location = new Point(3, 62);
            dataGridViewData.Name = "dataGridViewData";
            dataGridViewData.Size = new Size(494, 307);
            dataGridViewData.TabIndex = 1;
            // 
            // panelBotton
            // 
            panelBotton.Location = new Point(3, 375);
            panelBotton.Name = "panelBotton";
            panelBotton.Size = new Size(494, 72);
            panelBotton.TabIndex = 2;
            // 
            // FormRegistrosJaEnviados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanelMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRegistrosJaEnviados";
            Padding = new Padding(150, 0, 150, 0);
            Text = "FormRegistrosJaEnviados";
            flowLayoutPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelMain;
        private Panel panelTop;
        private DataGridView dataGridViewData;
        private Panel panelBotton;
    }
}