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
            btnSearchEmails = new Button();
            btnSendSelected = new Button();
            btnSendAll = new Button();
            panelGrid = new Panel();
            panelLogSearch = new Panel();
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
            ColumnCreatedAt = new DataGridViewTextBoxColumn();
            panelFilters = new Panel();
            maskedTextBoxFinalDate = new MaskedTextBox();
            maskedTextBoxInitialDate = new MaskedTextBox();
            labelFinalDate = new Label();
            labelInitialDate = new Label();
            dateTimePickerFinalDate = new DateTimePicker();
            dateTimePickerInitialDate = new DateTimePicker();
            chkBoxNotSended = new CheckBox();
            chkBoxSended = new CheckBox();
            pnlMain.SuspendLayout();
            tableLayoutPanelData.SuspendLayout();
            panelTop.SuspendLayout();
            panelGrid.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewDataNotification ).BeginInit();
            panelFilters.SuspendLayout();
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
            tableLayoutPanelData.Controls.Add(panelGrid, 0, 2);
            tableLayoutPanelData.Controls.Add(panelFilters, 0, 1);
            tableLayoutPanelData.Dock = DockStyle.Fill;
            tableLayoutPanelData.Location = new Point(0, 0);
            tableLayoutPanelData.Name = "tableLayoutPanelData";
            tableLayoutPanelData.RowCount = 3;
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Percent, 14.1786737F));
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Percent, 8.932827F));
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Percent, 76.888504F));
            tableLayoutPanelData.Size = new Size(887, 471);
            tableLayoutPanelData.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnSearchEmails);
            panelTop.Controls.Add(btnSendSelected);
            panelTop.Controls.Add(btnSendAll);
            panelTop.Dock = DockStyle.Fill;
            panelTop.Location = new Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(881, 60);
            panelTop.TabIndex = 0;
            // 
            // btnSearchEmails
            // 
            btnSearchEmails.Location = new Point(403, 9);
            btnSearchEmails.Name = "btnSearchEmails";
            btnSearchEmails.Size = new Size(184, 45);
            btnSearchEmails.TabIndex = 2;
            btnSearchEmails.Text = "Pesquisar emails - PJ";
            btnSearchEmails.UseVisualStyleBackColor = true;
            btnSearchEmails.Click +=  btnSearchEmails_Click ;
            // 
            // btnSendSelected
            // 
            btnSendSelected.Location = new Point(9, 9);
            btnSendSelected.Name = "btnSendSelected";
            btnSendSelected.Size = new Size(184, 45);
            btnSendSelected.TabIndex = 1;
            btnSendSelected.Text = "Enviar Notificações marcadas";
            btnSendSelected.UseVisualStyleBackColor = true;
            btnSendSelected.Click +=  btnSendSelected_Click ;
            // 
            // btnSendAll
            // 
            btnSendAll.Location = new Point(205, 9);
            btnSendAll.Name = "btnSendAll";
            btnSendAll.Size = new Size(184, 45);
            btnSendAll.TabIndex = 0;
            btnSendAll.Text = "Enviar Todas Notificações Pendentes";
            btnSendAll.UseVisualStyleBackColor = true;
            btnSendAll.Click +=  btnSend_Click ;
            // 
            // panelGrid
            // 
            panelGrid.Controls.Add(panelLogSearch);
            panelGrid.Controls.Add(dataGridViewDataNotification);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(3, 111);
            panelGrid.Name = "panelGrid";
            panelGrid.Size = new Size(881, 357);
            panelGrid.TabIndex = 2;
            // 
            // panelLogSearch
            // 
            panelLogSearch.BackColor = SystemColors.Control;
            panelLogSearch.BorderStyle = BorderStyle.FixedSingle;
            panelLogSearch.Location = new Point(282, 40);
            panelLogSearch.Name = "panelLogSearch";
            panelLogSearch.Size = new Size(353, 308);
            panelLogSearch.TabIndex = 4;
            panelLogSearch.Visible = false;
            // 
            // dataGridViewDataNotification
            // 
            dataGridViewDataNotification.AllowUserToAddRows = false;
            dataGridViewDataNotification.AllowUserToDeleteRows = false;
            dataGridViewDataNotification.AllowUserToOrderColumns = true;
            dataGridViewDataNotification.BackgroundColor = SystemColors.Control;
            dataGridViewDataNotification.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDataNotification.Columns.AddRange(new DataGridViewColumn[] { ColumnSelect, ColumnId, ColumnDate, ColumnDist, ColumnNumTitulo, ColumnTotal, ColumnDev, ColumnDocDev, ColumnDevEmail, ColumnCred, ColumnSended, ColumnDateSend, ColumnLido, ColumnTabelionato, ColumnPortador, ColumnCreatedAt });
            dataGridViewDataNotification.Dock = DockStyle.Fill;
            dataGridViewDataNotification.Location = new Point(0, 0);
            dataGridViewDataNotification.Name = "dataGridViewDataNotification";
            dataGridViewDataNotification.ReadOnly = true;
            dataGridViewDataNotification.Size = new Size(881, 357);
            dataGridViewDataNotification.TabIndex = 3;
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
            // ColumnCreatedAt
            // 
            ColumnCreatedAt.HeaderText = "Criado Em";
            ColumnCreatedAt.Name = "ColumnCreatedAt";
            ColumnCreatedAt.ReadOnly = true;
            // 
            // panelFilters
            // 
            panelFilters.Controls.Add(maskedTextBoxFinalDate);
            panelFilters.Controls.Add(maskedTextBoxInitialDate);
            panelFilters.Controls.Add(labelFinalDate);
            panelFilters.Controls.Add(labelInitialDate);
            panelFilters.Controls.Add(dateTimePickerFinalDate);
            panelFilters.Controls.Add(dateTimePickerInitialDate);
            panelFilters.Controls.Add(chkBoxNotSended);
            panelFilters.Controls.Add(chkBoxSended);
            panelFilters.Dock = DockStyle.Fill;
            panelFilters.Location = new Point(3, 69);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(881, 36);
            panelFilters.TabIndex = 1;
            // 
            // maskedTextBoxFinalDate
            // 
            maskedTextBoxFinalDate.Location = new Point(574, 12);
            maskedTextBoxFinalDate.Mask = "00/00/0000";
            maskedTextBoxFinalDate.Name = "maskedTextBoxFinalDate";
            maskedTextBoxFinalDate.Size = new Size(75, 23);
            maskedTextBoxFinalDate.TabIndex = 7;
            maskedTextBoxFinalDate.ValidatingType = typeof(DateTime);
            // 
            // maskedTextBoxInitialDate
            // 
            maskedTextBoxInitialDate.Location = new Point(403, 12);
            maskedTextBoxInitialDate.Mask = "00/00/0000";
            maskedTextBoxInitialDate.Name = "maskedTextBoxInitialDate";
            maskedTextBoxInitialDate.Size = new Size(75, 23);
            maskedTextBoxInitialDate.TabIndex = 6;
            maskedTextBoxInitialDate.ValidatingType = typeof(DateTime);
            // 
            // labelFinalDate
            // 
            labelFinalDate.AutoSize = true;
            labelFinalDate.Location = new Point(509, 16);
            labelFinalDate.Name = "labelFinalDate";
            labelFinalDate.Size = new Size(62, 15);
            labelFinalDate.TabIndex = 5;
            labelFinalDate.Text = "Data Final:";
            // 
            // labelInitialDate
            // 
            labelInitialDate.AutoSize = true;
            labelInitialDate.Location = new Point(330, 16);
            labelInitialDate.Name = "labelInitialDate";
            labelInitialDate.Size = new Size(68, 15);
            labelInitialDate.TabIndex = 4;
            labelInitialDate.Text = "Data Inicial:";
            // 
            // dateTimePickerFinalDate
            // 
            dateTimePickerFinalDate.Format = DateTimePickerFormat.Short;
            dateTimePickerFinalDate.ImeMode = ImeMode.NoControl;
            dateTimePickerFinalDate.Location = new Point(649, 12);
            dateTimePickerFinalDate.Name = "dateTimePickerFinalDate";
            dateTimePickerFinalDate.Size = new Size(14, 23);
            dateTimePickerFinalDate.TabIndex = 3;
            // 
            // dateTimePickerInitialDate
            // 
            dateTimePickerInitialDate.CalendarForeColor = SystemColors.Control;
            dateTimePickerInitialDate.CalendarTitleForeColor = SystemColors.Control;
            dateTimePickerInitialDate.CalendarTrailingForeColor = SystemColors.Control;
            dateTimePickerInitialDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerInitialDate.Location = new Point(478, 12);
            dateTimePickerInitialDate.Name = "dateTimePickerInitialDate";
            dateTimePickerInitialDate.RightToLeft = RightToLeft.No;
            dateTimePickerInitialDate.Size = new Size(14, 23);
            dateTimePickerInitialDate.TabIndex = 2;
            // 
            // chkBoxNotSended
            // 
            chkBoxNotSended.AutoSize = true;
            chkBoxNotSended.Location = new Point(9, 15);
            chkBoxNotSended.Name = "chkBoxNotSended";
            chkBoxNotSended.Size = new Size(164, 19);
            chkBoxNotSended.TabIndex = 1;
            chkBoxNotSended.Text = "Notificações não enviadas";
            chkBoxNotSended.UseVisualStyleBackColor = true;
            chkBoxNotSended.CheckedChanged +=  chkBoxNotSended_CheckedChanged ;
            // 
            // chkBoxSended
            // 
            chkBoxSended.AutoSize = true;
            chkBoxSended.Location = new Point(179, 15);
            chkBoxSended.Name = "chkBoxSended";
            chkBoxSended.Size = new Size(147, 19);
            chkBoxSended.TabIndex = 0;
            chkBoxSended.Text = "Notificaçãoes Enviadas";
            chkBoxSended.UseVisualStyleBackColor = true;
            chkBoxSended.CheckedChanged +=  chkBoxSended_CheckedChanged ;
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
            panelGrid.ResumeLayout(false);
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewDataNotification ).EndInit();
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private TableLayoutPanel tableLayoutPanelData;
        private Panel panelTop;
        private Panel panelFilters;
        private CheckBox chkBoxSended;
        private DateTimePicker dateTimePickerInitialDate;
        private CheckBox chkBoxNotSended;
        private DateTimePicker dateTimePickerFinalDate;
        private Label labelFinalDate;
        private Label labelInitialDate;
        private Button btnSendAll;
        private Button btnSendSelected;
        private MaskedTextBox maskedTextBoxInitialDate;
        private MaskedTextBox maskedTextBoxFinalDate;
        private Panel panelGrid;
        private Panel panelLogSearch;
        private DataGridView dataGridViewDataNotification;
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
        private DataGridViewTextBoxColumn ColumnCreatedAt;
        private Button btnSearchEmails;
    }
}