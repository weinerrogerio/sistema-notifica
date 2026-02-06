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
            mainPanelLogSearch = new Panel();
            tableLayoutPanelSearch = new TableLayoutPanel();
            richTextBoxLogs = new RichTextBox();
            pnlSearchBotton = new Panel();
            btnFecharOverlay = new Button();
            btnCancelSearch = new Button();
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            textBoxDevedor = new TextBox();
            label2 = new Label();
            textBoxDoc = new TextBox();
            label3 = new Label();
            textBoxEmail = new TextBox();
            pnlMain.SuspendLayout();
            tableLayoutPanelData.SuspendLayout();
            panelTop.SuspendLayout();
            panelGrid.SuspendLayout();
            mainPanelLogSearch.SuspendLayout();
            tableLayoutPanelSearch.SuspendLayout();
            pnlSearchBotton.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewDataNotification ).BeginInit();
            panelFilters.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            tableLayoutPanelData.Controls.Add(panelGrid, 0, 3);
            tableLayoutPanelData.Controls.Add(panelFilters, 0, 2);
            tableLayoutPanelData.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanelData.Dock = DockStyle.Fill;
            tableLayoutPanelData.Location = new Point(0, 0);
            tableLayoutPanelData.Name = "tableLayoutPanelData";
            tableLayoutPanelData.RowCount = 4;
            tableLayoutPanelData.RowStyles.Add(new RowStyle());
            tableLayoutPanelData.RowStyles.Add(new RowStyle());
            tableLayoutPanelData.RowStyles.Add(new RowStyle());
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelData.Size = new Size(887, 471);
            tableLayoutPanelData.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnSearchEmails);
            panelTop.Controls.Add(btnSendSelected);
            panelTop.Controls.Add(btnSendAll);
            panelTop.Dock = DockStyle.Fill;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(887, 60);
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
            panelGrid.Controls.Add(mainPanelLogSearch);
            panelGrid.Controls.Add(dataGridViewDataNotification);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(3, 128);
            panelGrid.Name = "panelGrid";
            panelGrid.Size = new Size(881, 340);
            panelGrid.TabIndex = 2;
            // 
            // mainPanelLogSearch
            // 
            mainPanelLogSearch.BackColor = SystemColors.Control;
            mainPanelLogSearch.BorderStyle = BorderStyle.FixedSingle;
            mainPanelLogSearch.Controls.Add(tableLayoutPanelSearch);
            mainPanelLogSearch.Location = new Point(176, -99);
            mainPanelLogSearch.Name = "mainPanelLogSearch";
            mainPanelLogSearch.Size = new Size(547, 447);
            mainPanelLogSearch.TabIndex = 4;
            mainPanelLogSearch.Visible = false;
            // 
            // tableLayoutPanelSearch
            // 
            tableLayoutPanelSearch.ColumnCount = 1;
            tableLayoutPanelSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelSearch.Controls.Add(richTextBoxLogs, 0, 0);
            tableLayoutPanelSearch.Controls.Add(pnlSearchBotton, 0, 1);
            tableLayoutPanelSearch.Dock = DockStyle.Fill;
            tableLayoutPanelSearch.Location = new Point(0, 0);
            tableLayoutPanelSearch.Name = "tableLayoutPanelSearch";
            tableLayoutPanelSearch.RowCount = 2;
            tableLayoutPanelSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 91.46067F));
            tableLayoutPanelSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 8.539326F));
            tableLayoutPanelSearch.Size = new Size(545, 445);
            tableLayoutPanelSearch.TabIndex = 2;
            // 
            // richTextBoxLogs
            // 
            richTextBoxLogs.Dock = DockStyle.Fill;
            richTextBoxLogs.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point,    0);
            richTextBoxLogs.Location = new Point(3, 3);
            richTextBoxLogs.Name = "richTextBoxLogs";
            richTextBoxLogs.ReadOnly = true;
            richTextBoxLogs.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBoxLogs.Size = new Size(539, 401);
            richTextBoxLogs.TabIndex = 1;
            richTextBoxLogs.Text = "";
            // 
            // pnlSearchBotton
            // 
            pnlSearchBotton.Controls.Add(btnFecharOverlay);
            pnlSearchBotton.Controls.Add(btnCancelSearch);
            pnlSearchBotton.Dock = DockStyle.Fill;
            pnlSearchBotton.Location = new Point(3, 410);
            pnlSearchBotton.Name = "pnlSearchBotton";
            pnlSearchBotton.Size = new Size(539, 32);
            pnlSearchBotton.TabIndex = 2;
            // 
            // btnFecharOverlay
            // 
            btnFecharOverlay.Anchor =      AnchorStyles.Top  |  AnchorStyles.Left   |  AnchorStyles.Right ;
            btnFecharOverlay.Location = new Point(127, 3);
            btnFecharOverlay.Name = "btnFecharOverlay";
            btnFecharOverlay.Size = new Size(278, 26);
            btnFecharOverlay.TabIndex = 1;
            btnFecharOverlay.Text = "FECHAR";
            btnFecharOverlay.UseVisualStyleBackColor = true;
            btnFecharOverlay.Click +=  btnFecharOverlay_Click ;
            // 
            // btnCancelSearch
            // 
            btnCancelSearch.Anchor =      AnchorStyles.Top  |  AnchorStyles.Left   |  AnchorStyles.Right ;
            btnCancelSearch.Location = new Point(127, 3);
            btnCancelSearch.Name = "btnCancelSearch";
            btnCancelSearch.Size = new Size(278, 26);
            btnCancelSearch.TabIndex = 0;
            btnCancelSearch.Text = "CANCELAR";
            btnCancelSearch.UseVisualStyleBackColor = true;
            btnCancelSearch.Click +=  btnCancel_Click ;
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
            dataGridViewDataNotification.Size = new Size(881, 340);
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
            ColumnDate.FillWeight = 95F;
            ColumnDate.HeaderText = "Data";
            ColumnDate.Name = "ColumnDate";
            ColumnDate.ReadOnly = true;
            ColumnDate.Width = 95;
            // 
            // ColumnDist
            // 
            ColumnDist.FillWeight = 70F;
            ColumnDist.HeaderText = "Distribuição";
            ColumnDist.Name = "ColumnDist";
            ColumnDist.ReadOnly = true;
            ColumnDist.Width = 70;
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
            ColumnDev.FillWeight = 150F;
            ColumnDev.HeaderText = "Devedor";
            ColumnDev.Name = "ColumnDev";
            ColumnDev.ReadOnly = true;
            ColumnDev.Width = 150;
            // 
            // ColumnDocDev
            // 
            ColumnDocDev.HeaderText = "Doc. Devedor";
            ColumnDocDev.Name = "ColumnDocDev";
            ColumnDocDev.ReadOnly = true;
            // 
            // ColumnDevEmail
            // 
            ColumnDevEmail.FillWeight = 120F;
            ColumnDevEmail.HeaderText = "Email";
            ColumnDevEmail.Name = "ColumnDevEmail";
            ColumnDevEmail.ReadOnly = true;
            ColumnDevEmail.Width = 120;
            // 
            // ColumnCred
            // 
            ColumnCred.FillWeight = 120F;
            ColumnCred.HeaderText = "Credor";
            ColumnCred.Name = "ColumnCred";
            ColumnCred.ReadOnly = true;
            ColumnCred.Width = 120;
            // 
            // ColumnSended
            // 
            ColumnSended.FillWeight = 35F;
            ColumnSended.HeaderText = "Enviado";
            ColumnSended.Name = "ColumnSended";
            ColumnSended.ReadOnly = true;
            ColumnSended.Width = 35;
            // 
            // ColumnDateSend
            // 
            ColumnDateSend.FillWeight = 95F;
            ColumnDateSend.HeaderText = "Data do envio";
            ColumnDateSend.Name = "ColumnDateSend";
            ColumnDateSend.ReadOnly = true;
            ColumnDateSend.Width = 95;
            // 
            // ColumnLido
            // 
            ColumnLido.FillWeight = 35F;
            ColumnLido.HeaderText = "Lido";
            ColumnLido.Name = "ColumnLido";
            ColumnLido.ReadOnly = true;
            ColumnLido.Width = 35;
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
            panelFilters.Location = new Point(0, 89);
            panelFilters.Margin = new Padding(0);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(887, 36);
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBoxDevedor);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(textBoxDoc);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(textBoxEmail);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 60);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(887, 29);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 7);
            label1.Margin = new Padding(2, 7, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Devedor:";
            // 
            // textBoxDevedor
            // 
            textBoxDevedor.Location = new Point(56, 3);
            textBoxDevedor.Margin = new Padding(0, 3, 0, 3);
            textBoxDevedor.Name = "textBoxDevedor";
            textBoxDevedor.Size = new Size(244, 23);
            textBoxDevedor.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(302, 7);
            label2.Margin = new Padding(2, 7, 0, 0);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 3;
            label2.Text = "Documento: ";
            // 
            // textBoxDoc
            // 
            textBoxDoc.Location = new Point(378, 3);
            textBoxDoc.Margin = new Padding(0, 3, 0, 3);
            textBoxDoc.Name = "textBoxDoc";
            textBoxDoc.Size = new Size(176, 23);
            textBoxDoc.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(556, 7);
            label3.Margin = new Padding(2, 7, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Email:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(595, 3);
            textBoxEmail.Margin = new Padding(0, 3, 0, 3);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(216, 23);
            textBoxEmail.TabIndex = 5;
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
            tableLayoutPanelData.PerformLayout();
            panelTop.ResumeLayout(false);
            panelGrid.ResumeLayout(false);
            mainPanelLogSearch.ResumeLayout(false);
            tableLayoutPanelSearch.ResumeLayout(false);
            pnlSearchBotton.ResumeLayout(false);
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewDataNotification ).EndInit();
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
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
        private Panel mainPanelLogSearch;
        private DataGridView dataGridViewDataNotification;
        private Button btnSearchEmails;
        private Button btnCancelSearch;
        private RichTextBox richTextBoxLogs;
        private TableLayoutPanel tableLayoutPanelSearch;
        private Panel pnlSearchBotton;
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
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private TextBox textBoxDevedor;
        private Label label2;
        private TextBox textBoxDoc;
        private Label label3;
        private TextBox textBoxEmail;
        private Button btnFecharOverlay;
    }
}