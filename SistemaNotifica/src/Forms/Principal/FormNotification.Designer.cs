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
            btnSendSelected = new Button();
            btnSend = new Button();
            panelFilters = new Panel();
            maskedTextBoxFinalDate = new MaskedTextBox();
            maskedTextBoxInitialDate = new MaskedTextBox();
            labelFinalDate = new Label();
            labelInitialDate = new Label();
            dateTimePickerFinalDate = new DateTimePicker();
            dateTimePickerInitialDate = new DateTimePicker();
            chkBoxNotNaoEnviadas = new CheckBox();
            chkBoxNotSended = new CheckBox();
            dataGridViewDataNotification = new DataGridView();
            ColumnSelect = new DataGridViewCheckBoxColumn();
            ColumnId = new DataGridViewTextBoxColumn();
            ColumnDate = new DataGridViewTextBoxColumn();
            ColumnDist = new DataGridViewTextBoxColumn();
            ColumnNumTitulo = new DataGridViewTextBoxColumn();
            ColumnTotal = new DataGridViewTextBoxColumn();
            ColumnDev = new DataGridViewTextBoxColumn();
            ColumnDocDev = new DataGridViewTextBoxColumn();
            ColumnDevEmail = new DataGridViewTextBoxColumn();
            ColumnCred = new DataGridViewTextBoxColumn();
            ColumnSended = new DataGridViewTextBoxColumn();
            ColumnDateSend = new DataGridViewTextBoxColumn();
            ColumnLido = new DataGridViewTextBoxColumn();
            ColumnTabelionato = new DataGridViewTextBoxColumn();
            ColumnPortador = new DataGridViewTextBoxColumn();
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
            tableLayoutPanelData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelData.Controls.Add(panelTop, 0, 0);
            tableLayoutPanelData.Controls.Add(panelFilters, 0, 1);
            tableLayoutPanelData.Controls.Add(dataGridViewDataNotification, 0, 2);
            tableLayoutPanelData.Dock = DockStyle.Fill;
            tableLayoutPanelData.Location = new Point(0, 0);
            tableLayoutPanelData.Name = "tableLayoutPanelData";
            tableLayoutPanelData.RowCount = 3;
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Percent, 13.0340548F));
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8617086F));
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Percent, 76.10424F));
            tableLayoutPanelData.Size = new Size(887, 471);
            tableLayoutPanelData.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnSendSelected);
            panelTop.Controls.Add(btnSend);
            panelTop.Dock = DockStyle.Fill;
            panelTop.Location = new Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(881, 55);
            panelTop.TabIndex = 0;
            // 
            // btnSendSelected
            // 
            btnSendSelected.Location = new Point(214, 9);
            btnSendSelected.Name = "btnSendSelected";
            btnSendSelected.Size = new Size(184, 45);
            btnSendSelected.TabIndex = 1;
            btnSendSelected.Text = "Enviar Notificações marcadas";
            btnSendSelected.UseVisualStyleBackColor = true;
            btnSendSelected.Click += btnSendSelected_Click;
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
            panelFilters.Controls.Add(maskedTextBoxFinalDate);
            panelFilters.Controls.Add(maskedTextBoxInitialDate);
            panelFilters.Controls.Add(labelFinalDate);
            panelFilters.Controls.Add(labelInitialDate);
            panelFilters.Controls.Add(dateTimePickerFinalDate);
            panelFilters.Controls.Add(dateTimePickerInitialDate);
            panelFilters.Controls.Add(chkBoxNotNaoEnviadas);
            panelFilters.Controls.Add(chkBoxNotSended);
            panelFilters.Dock = DockStyle.Fill;
            panelFilters.Location = new Point(3, 64);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(881, 45);
            panelFilters.TabIndex = 1;
            // 
            // maskedTextBoxFinalDate
            // 
            maskedTextBoxFinalDate.Location = new Point(642, 12);
            maskedTextBoxFinalDate.Mask = "00/00/0000";
            maskedTextBoxFinalDate.Name = "maskedTextBoxFinalDate";
            maskedTextBoxFinalDate.Size = new Size(75, 23);
            maskedTextBoxFinalDate.TabIndex = 7;
            maskedTextBoxFinalDate.ValidatingType = typeof(DateTime);
            // 
            // maskedTextBoxInitialDate
            // 
            maskedTextBoxInitialDate.Location = new Point(455, 12);
            maskedTextBoxInitialDate.Mask = "00/00/0000";
            maskedTextBoxInitialDate.Name = "maskedTextBoxInitialDate";
            maskedTextBoxInitialDate.Size = new Size(75, 23);
            maskedTextBoxInitialDate.TabIndex = 6;
            maskedTextBoxInitialDate.ValidatingType = typeof(DateTime);
            // 
            // labelFinalDate
            // 
            labelFinalDate.AutoSize = true;
            labelFinalDate.Location = new Point(577, 16);
            labelFinalDate.Name = "labelFinalDate";
            labelFinalDate.Size = new Size(62, 15);
            labelFinalDate.TabIndex = 5;
            labelFinalDate.Text = "Data Final:";
            // 
            // labelInitialDate
            // 
            labelInitialDate.AutoSize = true;
            labelInitialDate.Location = new Point(382, 16);
            labelInitialDate.Name = "labelInitialDate";
            labelInitialDate.Size = new Size(68, 15);
            labelInitialDate.TabIndex = 4;
            labelInitialDate.Text = "Data Inicial:";
            // 
            // dateTimePickerFinalDate
            // 
            dateTimePickerFinalDate.Format = DateTimePickerFormat.Short;
            dateTimePickerFinalDate.ImeMode = ImeMode.NoControl;
            dateTimePickerFinalDate.Location = new Point(717, 12);
            dateTimePickerFinalDate.Name = "dateTimePickerFinalDate";
            dateTimePickerFinalDate.Size = new Size(14, 23);
            dateTimePickerFinalDate.TabIndex = 3;
            // 
            // dateTimePickerInitialDate
            // 
            dateTimePickerInitialDate.Format = DateTimePickerFormat.Short;
            dateTimePickerInitialDate.Location = new Point(530, 12);
            dateTimePickerInitialDate.Name = "dateTimePickerInitialDate";
            dateTimePickerInitialDate.Size = new Size(14, 23);
            dateTimePickerInitialDate.TabIndex = 2;
            // 
            // chkBoxNotNaoEnviadas
            // 
            chkBoxNotNaoEnviadas.AutoSize = true;
            chkBoxNotNaoEnviadas.Location = new Point(9, 15);
            chkBoxNotNaoEnviadas.Name = "chkBoxNotNaoEnviadas";
            chkBoxNotNaoEnviadas.Size = new Size(164, 19);
            chkBoxNotNaoEnviadas.TabIndex = 1;
            chkBoxNotNaoEnviadas.Text = "Notificações não enviadas";
            chkBoxNotNaoEnviadas.UseVisualStyleBackColor = true;
            chkBoxNotNaoEnviadas.CheckedChanged += chkBoxNotNaoEnviadas_CheckedChanged;
            // 
            // chkBoxNotSended
            // 
            chkBoxNotSended.AutoSize = true;
            chkBoxNotSended.Location = new Point(202, 15);
            chkBoxNotSended.Name = "chkBoxNotSended";
            chkBoxNotSended.Size = new Size(147, 19);
            chkBoxNotSended.TabIndex = 0;
            chkBoxNotSended.Text = "Notificaçãoes Enviadas";
            chkBoxNotSended.UseVisualStyleBackColor = true;
            chkBoxNotSended.CheckedChanged += chkBoxNotSended_CheckedChanged;
            // 
            // dataGridViewDataNotification
            // 
            dataGridViewDataNotification.AllowUserToAddRows = false;
            dataGridViewDataNotification.AllowUserToDeleteRows = false;
            dataGridViewDataNotification.AllowUserToOrderColumns = true;
            dataGridViewDataNotification.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDataNotification.Columns.AddRange(new DataGridViewColumn[] { ColumnSelect, ColumnId, ColumnDate, ColumnDist, ColumnNumTitulo, ColumnTotal, ColumnDev, ColumnDocDev, ColumnDevEmail, ColumnCred, ColumnSended, ColumnDateSend, ColumnLido, ColumnTabelionato, ColumnPortador });
            dataGridViewDataNotification.Dock = DockStyle.Fill;
            dataGridViewDataNotification.Location = new Point(3, 115);
            dataGridViewDataNotification.Name = "dataGridViewDataNotification";
            dataGridViewDataNotification.ReadOnly = true;
            dataGridViewDataNotification.Size = new Size(881, 353);
            dataGridViewDataNotification.TabIndex = 2;
            // 
            // ColumnSelect
            // 
            ColumnSelect.FillWeight = 45F;
            ColumnSelect.HeaderText = "Sel.";
            ColumnSelect.Name = "ColumnSelect";
            ColumnSelect.ReadOnly = true;
            ColumnSelect.Width = 45;
            // 
            // ColumnId
            // 
            ColumnId.HeaderText = "Id";
            ColumnId.Name = "ColumnId";
            ColumnId.ReadOnly = true;
            ColumnId.Visible = false;
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
            // ColumnNumTitulo
            // 
            ColumnNumTitulo.HeaderText = "Num. Titulo";
            ColumnNumTitulo.Name = "ColumnNumTitulo";
            ColumnNumTitulo.ReadOnly = true;
            // 
            // ColumnTotal
            // 
            ColumnTotal.HeaderText = "Total";
            ColumnTotal.Name = "ColumnTotal";
            ColumnTotal.ReadOnly = true;
            ColumnTotal.Visible = false;
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
            // ColumnDevEmail
            // 
            ColumnDevEmail.HeaderText = "Email";
            ColumnDevEmail.Name = "ColumnDevEmail";
            ColumnDevEmail.ReadOnly = true;
            // 
            // ColumnCred
            // 
            ColumnCred.HeaderText = "Credor";
            ColumnCred.Name = "ColumnCred";
            ColumnCred.ReadOnly = true;
            // 
            // ColumnSended
            // 
            ColumnSended.HeaderText = "Enviado";
            ColumnSended.Name = "ColumnSended";
            ColumnSended.ReadOnly = true;
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
            // ColumnTabelionato
            // 
            ColumnTabelionato.HeaderText = "Tabelionato";
            ColumnTabelionato.Name = "ColumnTabelionato";
            ColumnTabelionato.ReadOnly = true;
            ColumnTabelionato.Visible = false;
            // 
            // ColumnPortador
            // 
            ColumnPortador.HeaderText = "Portador";
            ColumnPortador.Name = "ColumnPortador";
            ColumnPortador.ReadOnly = true;
            ColumnPortador.Visible = false;
            // 
            // FormNotification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 471);
            Controls.Add(pnlMain);
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
        private DateTimePicker dateTimePickerInitialDate;
        private CheckBox chkBoxNotNaoEnviadas;
        private DateTimePicker dateTimePickerFinalDate;
        private Label labelFinalDate;
        private Label labelInitialDate;
        private Button btnSend;
        private Button btnSendSelected;
        private MaskedTextBox maskedTextBoxInitialDate;
        private MaskedTextBox maskedTextBoxFinalDate;
        private DataGridViewCheckBoxColumn ColumnSelect;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnDate;
        private DataGridViewTextBoxColumn ColumnDist;
        private DataGridViewTextBoxColumn ColumnNumTitulo;
        private DataGridViewTextBoxColumn ColumnTotal;
        private DataGridViewTextBoxColumn ColumnDev;
        private DataGridViewTextBoxColumn ColumnDocDev;
        private DataGridViewTextBoxColumn ColumnDevEmail;
        private DataGridViewTextBoxColumn ColumnCred;
        private DataGridViewTextBoxColumn ColumnSended;
        private DataGridViewTextBoxColumn ColumnDateSend;
        private DataGridViewTextBoxColumn ColumnLido;
        private DataGridViewTextBoxColumn ColumnTabelionato;
        private DataGridViewTextBoxColumn ColumnPortador;
    }
}