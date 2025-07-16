namespace SistemaNotifica.src.Forms.Principal
{
    partial class FormNotification
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
            pnlMain = new Panel();
            tableLayoutPanelData = new TableLayoutPanel();
            panelTop = new Panel();
            btnSend = new Button();
            panelFilters = new Panel();
            labelFinalDate = new Label();
            labelInitialDate = new Label();
            dateTimePickerFinal = new DateTimePicker();
            dateTimePickerInitial = new DateTimePicker();
            chkBoxEmail = new CheckBox();
            chkBoxNotSended = new CheckBox();
            dataGridViewDataNotification = new DataGridView();
            ColumnDate = new DataGridViewTextBoxColumn();
            ColumnDist = new DataGridViewTextBoxColumn();
            ColumnDev = new DataGridViewTextBoxColumn();
            ColumnDocDev = new DataGridViewTextBoxColumn();
            ColumnCred = new DataGridViewTextBoxColumn();
            ColumnEmailSended = new DataGridViewTextBoxColumn();
            ColumnDateSend = new DataGridViewTextBoxColumn();
            ColumnLido = new DataGridViewTextBoxColumn();
            button1 = new Button();
            pnlMain.SuspendLayout();
            tableLayoutPanelData.SuspendLayout();
            panelTop.SuspendLayout();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataNotification).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(tableLayoutPanelData);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(887, 471);
            pnlMain.TabIndex = 0;
            // 
            // tableLayoutPanelData
            // 
            tableLayoutPanelData.ColumnCount = 1;
            tableLayoutPanelData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelData.Controls.Add(panelTop, 0, 0);
            tableLayoutPanelData.Controls.Add(panelFilters, 0, 1);
            tableLayoutPanelData.Controls.Add(dataGridViewDataNotification, 0, 2);
            tableLayoutPanelData.Dock = DockStyle.Fill;
            tableLayoutPanelData.Location = new Point(0, 0);
            tableLayoutPanelData.Name = "tableLayoutPanelData";
            tableLayoutPanelData.RowCount = 3;
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Percent, 55.2631569F));
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Percent, 44.7368431F));
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Absolute, 356F));
            tableLayoutPanelData.Size = new Size(887, 471);
            tableLayoutPanelData.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(button1);
            panelTop.Controls.Add(btnSend);
            panelTop.Dock = DockStyle.Fill;
            panelTop.Location = new Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(881, 57);
            panelTop.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(9, 9);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(184, 45);
            btnSend.TabIndex = 0;
            btnSend.Text = "Enviar Todas Notificações Pendentes";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // panelFilters
            // 
            panelFilters.Controls.Add(labelFinalDate);
            panelFilters.Controls.Add(labelInitialDate);
            panelFilters.Controls.Add(dateTimePickerFinal);
            panelFilters.Controls.Add(dateTimePickerInitial);
            panelFilters.Controls.Add(chkBoxEmail);
            panelFilters.Controls.Add(chkBoxNotSended);
            panelFilters.Dock = DockStyle.Fill;
            panelFilters.Location = new Point(3, 66);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(881, 45);
            panelFilters.TabIndex = 1;
            // 
            // labelFinalDate
            // 
            labelFinalDate.AutoSize = true;
            labelFinalDate.Location = new Point(502, 15);
            labelFinalDate.Name = "labelFinalDate";
            labelFinalDate.Size = new Size(59, 15);
            labelFinalDate.TabIndex = 5;
            labelFinalDate.Text = "Data Final";
            // 
            // labelInitialDate
            // 
            labelInitialDate.AutoSize = true;
            labelInitialDate.Location = new Point(333, 15);
            labelInitialDate.Name = "labelInitialDate";
            labelInitialDate.Size = new Size(65, 15);
            labelInitialDate.TabIndex = 4;
            labelInitialDate.Text = "Data Inicial";
            // 
            // dateTimePickerFinal
            // 
            dateTimePickerFinal.Format = DateTimePickerFormat.Short;
            dateTimePickerFinal.Location = new Point(421, 11);
            dateTimePickerFinal.Name = "dateTimePickerFinal";
            dateTimePickerFinal.Size = new Size(79, 23);
            dateTimePickerFinal.TabIndex = 3;
            // 
            // dateTimePickerInitial
            // 
            dateTimePickerInitial.Format = DateTimePickerFormat.Short;
            dateTimePickerInitial.Location = new Point(252, 11);
            dateTimePickerInitial.Name = "dateTimePickerInitial";
            dateTimePickerInitial.Size = new Size(79, 23);
            dateTimePickerInitial.TabIndex = 2;
            // 
            // chkBoxEmail
            // 
            chkBoxEmail.AutoSize = true;
            chkBoxEmail.Location = new Point(162, 15);
            chkBoxEmail.Name = "chkBoxEmail";
            chkBoxEmail.Size = new Size(84, 19);
            chkBoxEmail.TabIndex = 1;
            chkBoxEmail.Text = "Com Email";
            chkBoxEmail.UseVisualStyleBackColor = true;
            // 
            // chkBoxNotSended
            // 
            chkBoxNotSended.AutoSize = true;
            chkBoxNotSended.Location = new Point(9, 15);
            chkBoxNotSended.Name = "chkBoxNotSended";
            chkBoxNotSended.Size = new Size(147, 19);
            chkBoxNotSended.TabIndex = 0;
            chkBoxNotSended.Text = "Notificaçãoes Enviadas";
            chkBoxNotSended.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDataNotification
            // 
            dataGridViewDataNotification.AllowUserToAddRows = false;
            dataGridViewDataNotification.AllowUserToDeleteRows = false;
            dataGridViewDataNotification.AllowUserToOrderColumns = true;
            dataGridViewDataNotification.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDataNotification.Columns.AddRange(new DataGridViewColumn[] { ColumnDate, ColumnDist, ColumnDev, ColumnDocDev, ColumnCred, ColumnEmailSended, ColumnDateSend, ColumnLido });
            dataGridViewDataNotification.Dock = DockStyle.Fill;
            dataGridViewDataNotification.Location = new Point(3, 117);
            dataGridViewDataNotification.Name = "dataGridViewDataNotification";
            dataGridViewDataNotification.ReadOnly = true;
            dataGridViewDataNotification.Size = new Size(881, 351);
            dataGridViewDataNotification.TabIndex = 2;
            // 
            // ColumnDate
            // 
            ColumnDate.HeaderText = "Data";
            ColumnDate.Name = "ColumnDate";
            ColumnDate.ReadOnly = true;
            // 
            // ColumnDist
            // 
            ColumnDist.HeaderText = "Distribuição";
            ColumnDist.Name = "ColumnDist";
            ColumnDist.ReadOnly = true;
            // 
            // ColumnDev
            // 
            ColumnDev.HeaderText = "Devedor";
            ColumnDev.Name = "ColumnDev";
            ColumnDev.ReadOnly = true;
            // 
            // ColumnDocDev
            // 
            ColumnDocDev.HeaderText = "Doc. Devedor";
            ColumnDocDev.Name = "ColumnDocDev";
            ColumnDocDev.ReadOnly = true;
            // 
            // ColumnCred
            // 
            ColumnCred.HeaderText = "Credor";
            ColumnCred.Name = "ColumnCred";
            ColumnCred.ReadOnly = true;
            // 
            // ColumnEmailSended
            // 
            ColumnEmailSended.HeaderText = "Enviado";
            ColumnEmailSended.Name = "ColumnEmailSended";
            ColumnEmailSended.ReadOnly = true;
            // 
            // ColumnDateSend
            // 
            ColumnDateSend.HeaderText = "Data do envio";
            ColumnDateSend.Name = "ColumnDateSend";
            ColumnDateSend.ReadOnly = true;
            // 
            // ColumnLido
            // 
            ColumnLido.HeaderText = "Lido";
            ColumnLido.Name = "ColumnLido";
            ColumnLido.ReadOnly = true;
            // 
            // button1
            // 
            button1.Location = new Point(214, 9);
            button1.Name = "button1";
            button1.Size = new Size(184, 45);
            button1.TabIndex = 1;
            button1.Text = "Enviar Notificações marcadas";
            button1.UseVisualStyleBackColor = true;
            // 
            // FormNotification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 471);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormNotification";
            Text = "FormNotification";
            pnlMain.ResumeLayout(false);
            tableLayoutPanelData.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataNotification).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private TableLayoutPanel tableLayoutPanelData;
        private Panel panelTop;
        private Panel panelFilters;
        private CheckBox chkBoxNotSended;
        private DataGridView dataGridViewDataNotification;
        private DateTimePicker dateTimePickerInitial;
        private CheckBox chkBoxEmail;
        private DateTimePicker dateTimePickerFinal;
        private Label labelFinalDate;
        private Label labelInitialDate;
        private DataGridViewTextBoxColumn ColumnDate;
        private DataGridViewTextBoxColumn ColumnDist;
        private DataGridViewTextBoxColumn ColumnDev;
        private DataGridViewTextBoxColumn ColumnDocDev;
        private DataGridViewTextBoxColumn ColumnCred;
        private DataGridViewTextBoxColumn ColumnEmailSended;
        private DataGridViewTextBoxColumn ColumnDateSend;
        private DataGridViewTextBoxColumn ColumnLido;
        private Button btnSend;
        private Button button1;
    }
}