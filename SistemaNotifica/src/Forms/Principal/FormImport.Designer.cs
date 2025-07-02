namespace SistemaNotifica.src.Forms.Principal
{
    partial class FormImport
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
            components = new System.ComponentModel.Container();

            // Main layout
            tableLayoutPanelFormImportMain = new TableLayoutPanel();

            // Top panel and controls
            panelTop = new Panel();
            tableLayoutPanelTop = new TableLayoutPanel();
            groupBoxFileSelection = new GroupBox();
            labelDescription = new Label();
            labelFilePath = new Label();
            smallTextBox1 = new ReaLTaiizor.Controls.SmallTextBox();
            buttonSelect = new Button();
            panelActions = new Panel();
            buttonImport = new Button();
            buttonClearList = new Button();
            buttonRefresh = new Button();
            buttonExportLog = new Button();

            // Bottom panel and controls
            panelBottonMain = new Panel();
            tableLayoutPanelBottom = new TableLayoutPanel();

            // Filters panel
            panelFilters = new Panel();
            labelFilterBy = new Label();
            comboBoxStatusFilter = new ComboBox();
            labelDateFrom = new Label();
            dateTimePickerFrom = new DateTimePicker();
            labelDateTo = new Label();
            dateTimePickerTo = new DateTimePicker();
            labelUserFilter = new Label();
            textBoxUserFilter = new TextBox();
            buttonApplyFilter = new Button();
            buttonClearFilter = new Button();

            // Statistics panel
            panelStats = new Panel();
            labelTotalFiles = new Label();
            labelSuccessCount = new Label();
            labelErrorCount = new Label();
            labelProcessingCount = new Label();

            // DataGrid section
            groupBoxImportHistory = new GroupBox();
            dataGridViewDataImport = new DataGridView();

            // DataGrid Columns
            ColumnFile = new DataGridViewTextBoxColumn();
            ColumnDate = new DataGridViewTextBoxColumn();
            ColumnStatus = new DataGridViewTextBoxColumn();
            ColumnUser = new DataGridViewTextBoxColumn();
            ColumnFileSize = new DataGridViewTextBoxColumn();
            ColumnRecordsCount = new DataGridViewTextBoxColumn();
            ColumnErrorMessage = new DataGridViewTextBoxColumn();
            ColumnDuration = new DataGridViewTextBoxColumn();
            ColumnActions = new DataGridViewButtonColumn();

            // Status strip
            statusStripMain = new StatusStrip();
            toolStripStatusLabelRecords = new ToolStripStatusLabel();
            toolStripStatusLabelLastUpdate = new ToolStripStatusLabel();
            toolStripProgressBarImport = new ToolStripProgressBar();

            // Context menu
            contextMenuStripGrid = new ContextMenuStrip(components);
            toolStripMenuItemReprocess = new ToolStripMenuItem();
            toolStripMenuItemViewError = new ToolStripMenuItem();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            toolStripMenuItemCopyPath = new ToolStripMenuItem();

            // Other components
            errorProviderMain = new ErrorProvider(components);
            toolTipMain = new ToolTip(components);
            timerAutoRefresh = new System.Windows.Forms.Timer(components);

            // Suspend layouts
            tableLayoutPanelFormImportMain.SuspendLayout();
            panelTop.SuspendLayout();
            tableLayoutPanelTop.SuspendLayout();
            groupBoxFileSelection.SuspendLayout();
            panelActions.SuspendLayout();
            panelBottonMain.SuspendLayout();
            tableLayoutPanelBottom.SuspendLayout();
            panelFilters.SuspendLayout();
            panelStats.SuspendLayout();
            groupBoxImportHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataImport).BeginInit();
            statusStripMain.SuspendLayout();
            contextMenuStripGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProviderMain).BeginInit();
            SuspendLayout();

            // 
            // tableLayoutPanelFormImportMain
            // 
            tableLayoutPanelFormImportMain.ColumnCount = 1;
            tableLayoutPanelFormImportMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelFormImportMain.Controls.Add(panelTop, 0, 0);
            tableLayoutPanelFormImportMain.Controls.Add(panelBottonMain, 0, 1);
            tableLayoutPanelFormImportMain.Controls.Add(statusStripMain, 0, 2);
            tableLayoutPanelFormImportMain.Dock = DockStyle.Fill;
            tableLayoutPanelFormImportMain.Location = new Point(0, 0);
            tableLayoutPanelFormImportMain.Name = "tableLayoutPanelFormImportMain";
            tableLayoutPanelFormImportMain.RowCount = 3;
            tableLayoutPanelFormImportMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanelFormImportMain.RowStyles.Add(new RowStyle(SizeType.Percent, 72F));
            tableLayoutPanelFormImportMain.RowStyles.Add(new RowStyle(SizeType.Percent, 3F));
            tableLayoutPanelFormImportMain.Size = new Size(860, 528);
            tableLayoutPanelFormImportMain.TabIndex = 0;

            // 
            // panelTop
            // 
            panelTop.Controls.Add(tableLayoutPanelTop);
            panelTop.Dock = DockStyle.Fill;
            panelTop.Location = new Point(10, 10);
            panelTop.Margin = new Padding(10);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(840, 112);
            panelTop.TabIndex = 1;

            // 
            // tableLayoutPanelTop
            // 
            tableLayoutPanelTop.ColumnCount = 1;
            tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelTop.Controls.Add(groupBoxFileSelection, 0, 0);
            tableLayoutPanelTop.Controls.Add(panelActions, 0, 1);
            tableLayoutPanelTop.Dock = DockStyle.Fill;
            tableLayoutPanelTop.Location = new Point(0, 0);
            tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            tableLayoutPanelTop.RowCount = 2;
            tableLayoutPanelTop.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanelTop.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanelTop.Size = new Size(840, 112);
            tableLayoutPanelTop.TabIndex = 0;

            // 
            // groupBoxFileSelection
            // 
            groupBoxFileSelection.Controls.Add(labelDescription);
            groupBoxFileSelection.Controls.Add(labelFilePath);
            groupBoxFileSelection.Controls.Add(smallTextBox1);
            groupBoxFileSelection.Controls.Add(buttonSelect);
            groupBoxFileSelection.Dock = DockStyle.Fill;
            groupBoxFileSelection.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxFileSelection.Location = new Point(3, 3);
            groupBoxFileSelection.Name = "groupBoxFileSelection";
            groupBoxFileSelection.Size = new Size(834, 72);
            groupBoxFileSelection.TabIndex = 0;
            groupBoxFileSelection.TabStop = false;
            groupBoxFileSelection.Text = "Seleção de Arquivo";

            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular);
            labelDescription.Location = new Point(6, 18);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(688, 13);
            labelDescription.TabIndex = 0;
            labelDescription.Text = "Para Importar um arquivo, informe o arquivo nos campos abaixo. Atenção: não é permitida a importação de arquivos duplicados!";

            // 
            // labelFilePath
            // 
            labelFilePath.AutoSize = true;
            labelFilePath.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            labelFilePath.Location = new Point(6, 45);
            labelFilePath.Name = "labelFilePath";
            labelFilePath.Size = new Size(52, 15);
            labelFilePath.TabIndex = 1;
            labelFilePath.Text = "Arquivo:";

            // 
            // smallTextBox1
            // 
            smallTextBox1.BackColor = Color.Transparent;
            smallTextBox1.BorderColor = Color.FromArgb(180, 180, 180);
            smallTextBox1.CustomBGColor = Color.White;
            smallTextBox1.Font = new Font("Tahoma", 11F);
            smallTextBox1.ForeColor = Color.DimGray;
            smallTextBox1.Location = new Point(64, 40);
            smallTextBox1.MaxLength = 32767;
            smallTextBox1.Multiline = false;
            smallTextBox1.Name = "smallTextBox1";
            smallTextBox1.ReadOnly = true;
            smallTextBox1.Size = new Size(450, 28);
            smallTextBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            smallTextBox1.TabIndex = 2;
            smallTextBox1.Text = "Selecione um arquivo...";
            smallTextBox1.TextAlignment = HorizontalAlignment.Left;
            smallTextBox1.UseSystemPasswordChar = false;

            // 
            // buttonSelect
            // 
            buttonSelect.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            buttonSelect.Location = new Point(520, 40);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(136, 28);
            buttonSelect.TabIndex = 3;
            buttonSelect.Text = "📁 Selecionar Arquivo";
            buttonSelect.UseVisualStyleBackColor = true;
            toolTipMain.SetToolTip(buttonSelect, "Clique para selecionar um arquivo para importação");

            // 
            // panelActions
            // 
            panelActions.Controls.Add(buttonExportLog);
            panelActions.Controls.Add(buttonRefresh);
            panelActions.Controls.Add(buttonClearList);
            panelActions.Controls.Add(buttonImport);
            panelActions.Dock = DockStyle.Fill;
            panelActions.Location = new Point(3, 81);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(834, 28);
            panelActions.TabIndex = 1;

            // 
            // buttonImport
            // 
            buttonImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonImport.BackColor = Color.FromArgb(0, 122, 255);
            buttonImport.FlatStyle = FlatStyle.Flat;
            buttonImport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonImport.ForeColor = Color.White;
            buttonImport.Location = new Point(750, 0);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(84, 28);
            buttonImport.TabIndex = 4;
            buttonImport.Text = "▶ Importar";
            buttonImport.UseVisualStyleBackColor = false;
            toolTipMain.SetToolTip(buttonImport, "Iniciar importação do arquivo selecionado");

            // 
            // buttonClearList
            // 
            buttonClearList.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            buttonClearList.Location = new Point(0, 0);
            buttonClearList.Name = "buttonClearList";
            buttonClearList.Size = new Size(90, 28);
            buttonClearList.TabIndex = 5;
            buttonClearList.Text = "🗑 Limpar Lista";
            buttonClearList.UseVisualStyleBackColor = true;
            toolTipMain.SetToolTip(buttonClearList, "Limpar todos os registros da lista");

            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            buttonRefresh.Location = new Point(96, 0);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(80, 28);
            buttonRefresh.TabIndex = 6;
            buttonRefresh.Text = "🔄 Atualizar";
            buttonRefresh.UseVisualStyleBackColor = true;
            toolTipMain.SetToolTip(buttonRefresh, "Atualizar lista de importações");

            // 
            // buttonExportLog
            // 
            buttonExportLog.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            buttonExportLog.Location = new Point(182, 0);
            buttonExportLog.Name = "buttonExportLog";
            buttonExportLog.Size = new Size(90, 28);
            buttonExportLog.TabIndex = 7;
            buttonExportLog.Text = "📊 Exportar Log";
            buttonExportLog.UseVisualStyleBackColor = true;
            toolTipMain.SetToolTip(buttonExportLog, "Exportar log de importações para Excel");

            // 
            // panelBottonMain
            // 
            panelBottonMain.Controls.Add(tableLayoutPanelBottom);
            panelBottonMain.Dock = DockStyle.Fill;
            panelBottonMain.Location = new Point(10, 142);
            panelBottonMain.Margin = new Padding(10, 10, 10, 0);
            panelBottonMain.Name = "panelBottonMain";
            panelBottonMain.Size = new Size(840, 370);
            panelBottonMain.TabIndex = 0;

            // 
            // tableLayoutPanelBottom
            // 
            tableLayoutPanelBottom.ColumnCount = 1;
            tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelBottom.Controls.Add(panelFilters, 0, 0);
            tableLayoutPanelBottom.Controls.Add(panelStats, 0, 1);
            tableLayoutPanelBottom.Controls.Add(groupBoxImportHistory, 0, 2);
            tableLayoutPanelBottom.Dock = DockStyle.Fill;
            tableLayoutPanelBottom.Location = new Point(0, 0);
            tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            tableLayoutPanelBottom.RowCount = 3;
            tableLayoutPanelBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanelBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tableLayoutPanelBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 77F));
            tableLayoutPanelBottom.Size = new Size(840, 370);
            tableLayoutPanelBottom.TabIndex = 0;

            // 
            // panelFilters
            // 
            panelFilters.BackColor = Color.FromArgb(248, 249, 250);
            panelFilters.BorderStyle = BorderStyle.FixedSingle;
            panelFilters.Controls.Add(buttonClearFilter);
            panelFilters.Controls.Add(buttonApplyFilter);
            panelFilters.Controls.Add(textBoxUserFilter);
            panelFilters.Controls.Add(labelUserFilter);
            panelFilters.Controls.Add(dateTimePickerTo);
            panelFilters.Controls.Add(labelDateTo);
            panelFilters.Controls.Add(dateTimePickerFrom);
            panelFilters.Controls.Add(labelDateFrom);
            panelFilters.Controls.Add(comboBoxStatusFilter);
            panelFilters.Controls.Add(labelFilterBy);
            panelFilters.Dock = DockStyle.Fill;
            panelFilters.Location = new Point(3, 3);
            panelFilters.Name = "panelFilters";
            panelFilters.Padding = new Padding(5);
            panelFilters.Size = new Size(834, 49);
            panelFilters.TabIndex = 0;

            // 
            // labelFilterBy
            // 
            labelFilterBy.AutoSize = true;
            labelFilterBy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFilterBy.Location = new Point(8, 8);
            labelFilterBy.Name = "labelFilterBy";
            labelFilterBy.Size = new Size(67, 15);
            labelFilterBy.TabIndex = 0;
            labelFilterBy.Text = "Filtrar por:";

            // 
            // comboBoxStatusFilter
            // 
            comboBoxStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatusFilter.Items.AddRange(new object[] { "Todos", "Sucesso", "Erro", "Processando" });
            comboBoxStatusFilter.Location = new Point(8, 26);
            comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            comboBoxStatusFilter.Size = new Size(100, 23);
            comboBoxStatusFilter.TabIndex = 1;
            comboBoxStatusFilter.SelectedIndex = 0;

            // 
            // labelDateFrom
            // 
            labelDateFrom.AutoSize = true;
            labelDateFrom.Location = new Point(118, 8);
            labelDateFrom.Name = "labelDateFrom";
            labelDateFrom.Size = new Size(24, 15);
            labelDateFrom.TabIndex = 2;
            labelDateFrom.Text = "De:";

            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Format = DateTimePickerFormat.Short;
            dateTimePickerFrom.Location = new Point(118, 26);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(100, 23);
            dateTimePickerFrom.TabIndex = 3;

            // 
            // labelDateTo
            // 
            labelDateTo.AutoSize = true;
            labelDateTo.Location = new Point(228, 8);
            labelDateTo.Name = "labelDateTo";
            labelDateTo.Size = new Size(28, 15);
            labelDateTo.TabIndex = 4;
            labelDateTo.Text = "Até:";

            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Format = DateTimePickerFormat.Short;
            dateTimePickerTo.Location = new Point(228, 26);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(100, 23);
            dateTimePickerTo.TabIndex = 5;

            // 
            // labelUserFilter
            // 
            labelUserFilter.AutoSize = true;
            labelUserFilter.Location = new Point(338, 8);
            labelUserFilter.Name = "labelUserFilter";
            labelUserFilter.Size = new Size(50, 15);
            labelUserFilter.TabIndex = 6;
            labelUserFilter.Text = "Usuário:";

            // 
            // textBoxUserFilter
            // 
            textBoxUserFilter.Location = new Point(338, 26);
            textBoxUserFilter.Name = "textBoxUserFilter";
            textBoxUserFilter.PlaceholderText = "Nome do usuário...";
            textBoxUserFilter.Size = new Size(150, 23);
            textBoxUserFilter.TabIndex = 7;

            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.BackColor = Color.FromArgb(40, 167, 69);
            buttonApplyFilter.FlatStyle = FlatStyle.Flat;
            buttonApplyFilter.ForeColor = Color.White;
            buttonApplyFilter.Location = new Point(498, 26);
            buttonApplyFilter.Name = "buttonApplyFilter";
            buttonApplyFilter.Size = new Size(80, 23);
            buttonApplyFilter.TabIndex = 8;
            buttonApplyFilter.Text = "🔍 Filtrar";
            buttonApplyFilter.UseVisualStyleBackColor = false;

            // 
            // buttonClearFilter
            // 
            buttonClearFilter.Location = new Point(584, 26);
            buttonClearFilter.Name = "buttonClearFilter";
            buttonClearFilter.Size = new Size(60, 23);
            buttonClearFilter.TabIndex = 9;
            buttonClearFilter.Text = "✖ Limpar";
            buttonClearFilter.UseVisualStyleBackColor = true;

            // 
            // panelStats
            // 
            panelStats.BackColor = Color.FromArgb(220, 248, 198);
            panelStats.BorderStyle = BorderStyle.FixedSingle;
            panelStats.Controls.Add(labelProcessingCount);
            panelStats.Controls.Add(labelErrorCount);
            panelStats.Controls.Add(labelSuccessCount);
            panelStats.Controls.Add(labelTotalFiles);
            panelStats.Dock = DockStyle.Fill;
            panelStats.Location = new Point(3, 58);
            panelStats.Name = "panelStats";
            panelStats.Padding = new Padding(5);
            panelStats.Size = new Size(834, 23);
            panelStats.TabIndex = 1;

            // 
            // labelTotalFiles
            // 
            labelTotalFiles.AutoSize = true;
            labelTotalFiles.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTotalFiles.Location = new Point(8, 4);
            labelTotalFiles.Name = "labelTotalFiles";
            labelTotalFiles.Size = new Size(113, 15);
            labelTotalFiles.TabIndex = 0;
            labelTotalFiles.Text = "Total de arquivos: 0";

            // 
            // labelSuccessCount
            // 
            labelSuccessCount.AutoSize = true;
            labelSuccessCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSuccessCount.ForeColor = Color.FromArgb(40, 167, 69);
            labelSuccessCount.Location = new Point(150, 4);
            labelSuccessCount.Name = "labelSuccessCount";
            labelSuccessCount.Size = new Size(68, 15);
            labelSuccessCount.TabIndex = 1;
            labelSuccessCount.Text = "Sucessos: 0";

            // 
            // labelErrorCount
            // 
            labelErrorCount.AutoSize = true;
            labelErrorCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelErrorCount.ForeColor = Color.FromArgb(220, 53, 69);
            labelErrorCount.Location = new Point(250, 4);
            labelErrorCount.Name = "labelErrorCount";
            labelErrorCount.Size = new Size(50, 15);
            labelErrorCount.TabIndex = 2;
            labelErrorCount.Text = "Erros: 0";

            // 
            // labelProcessingCount
            // 
            labelProcessingCount.AutoSize = true;
            labelProcessingCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelProcessingCount.ForeColor = Color.FromArgb(0, 123, 255);
            labelProcessingCount.Location = new Point(330, 4);
            labelProcessingCount.Name = "labelProcessingCount";
            labelProcessingCount.Size = new Size(90, 15);
            labelProcessingCount.TabIndex = 3;
            labelProcessingCount.Text = "Processando: 0";

            // 
            // groupBoxImportHistory
            // 
            groupBoxImportHistory.Controls.Add(dataGridViewDataImport);
            groupBoxImportHistory.Dock = DockStyle.Fill;
            groupBoxImportHistory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxImportHistory.Location = new Point(3, 87);
            groupBoxImportHistory.Name = "groupBoxImportHistory";
            groupBoxImportHistory.Padding = new Padding(10);
            groupBoxImportHistory.Size = new Size(834, 280);
            groupBoxImportHistory.TabIndex = 2;
            groupBoxImportHistory.TabStop = false;
            groupBoxImportHistory.Text = "Histórico de Importações";

            // 
            // dataGridViewDataImport
            // 
            dataGridViewDataImport.AllowUserToAddRows = false;
            dataGridViewDataImport.AllowUserToOrderColumns = true;
            dataGridViewDataImport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewDataImport.BackgroundColor = SystemColors.Control;
            dataGridViewDataImport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDataImport.Columns.AddRange(new DataGridViewColumn[] {
                ColumnFile, ColumnDate, ColumnStatus, ColumnUser, ColumnFileSize,
                ColumnRecordsCount, ColumnErrorMessage, ColumnDuration, ColumnActions });
            dataGridViewDataImport.ContextMenuStrip = contextMenuStripGrid;
            dataGridViewDataImport.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dataGridViewDataImport.Dock = DockStyle.Fill;
            dataGridViewDataImport.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular);
            dataGridViewDataImport.GridColor = Color.WhiteSmoke;
            dataGridViewDataImport.Location = new Point(10, 26);
            dataGridViewDataImport.MultiSelect = true;
            dataGridViewDataImport.Name = "dataGridViewDataImport";
            dataGridViewDataImport.ReadOnly = true;
            dataGridViewDataImport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDataImport.Size = new Size(814, 244);
            dataGridViewDataImport.TabIndex = 0;

            // DataGrid Columns Configuration
            // 
            // ColumnFile
            // 
            ColumnFile.HeaderText = "Arquivo";
            ColumnFile.Name = "ColumnFile";
            ColumnFile.ReadOnly = true;
            ColumnFile.Width = 200;

            // 
            // ColumnDate
            // 
            ColumnDate.HeaderText = "Data/Hora";
            ColumnDate.Name = "ColumnDate";
            ColumnDate.ReadOnly = true;
            ColumnDate.Width = 120;

            // 
            // ColumnStatus
            // 
            ColumnStatus.HeaderText = "Status";
            ColumnStatus.Name = "ColumnStatus";
            ColumnStatus.ReadOnly = true;
            ColumnStatus.Width = 80;

            // 
            // ColumnUser
            // 
            ColumnUser.HeaderText = "Usuário";
            ColumnUser.Name = "ColumnUser";
            ColumnUser.ReadOnly = true;
            ColumnUser.Width = 100;

            // 
            // ColumnFileSize
            // 
            ColumnFileSize.HeaderText = "Tamanho";
            ColumnFileSize.Name = "ColumnFileSize";
            ColumnFileSize.ReadOnly = true;
            ColumnFileSize.Width = 80;

            // 
            // ColumnRecordsCount
            // 
            ColumnRecordsCount.HeaderText = "Registros";
            ColumnRecordsCount.Name = "ColumnRecordsCount";
            ColumnRecordsCount.ReadOnly = true;
            ColumnRecordsCount.Width = 70;

            // 
            // ColumnErrorMessage
            // 
            ColumnErrorMessage.HeaderText = "Erro";
            ColumnErrorMessage.Name = "ColumnErrorMessage";
            ColumnErrorMessage.ReadOnly = true;
            ColumnErrorMessage.Width = 150;

            // 
            // ColumnDuration
            // 
            ColumnDuration.HeaderText = "Duração";
            ColumnDuration.Name = "ColumnDuration";
            ColumnDuration.ReadOnly = true;
            ColumnDuration.Width = 80;

            // 
            // ColumnActions
            // 
            ColumnActions.HeaderText = "Ações";
            ColumnActions.Name = "ColumnActions";
            ColumnActions.ReadOnly = true;
            ColumnActions.Text = "Detalhes";
            ColumnActions.UseColumnTextForButtonValue = true;
            ColumnActions.Width = 80;

            // 
            // statusStripMain
            // 
            statusStripMain.Items.AddRange(new ToolStripItem[] {
                toolStripStatusLabelRecords, toolStripStatusLabelLastUpdate, toolStripProgressBarImport });
            statusStripMain.Location = new Point(0, 522);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Size = new Size(860, 22);
            statusStripMain.TabIndex = 2;
            statusStripMain.Text = "statusStrip1";

            // 
            // toolStripStatusLabelRecords
            // 
            toolStripStatusLabelRecords.Name = "toolStripStatusLabelRecords";
            toolStripStatusLabelRecords.Size = new Size(118, 17);
            toolStripStatusLabelRecords.Text = "Total de registros: 0";

            // 
            // toolStripStatusLabelLastUpdate
            // 
            toolStripStatusLabelLastUpdate.Name = "toolStripStatusLabelLastUpdate";
            toolStripStatusLabelLastUpdate.Size = new Size(118, 17);
            toolStripStatusLabelLastUpdate.Spring = true;
            toolStripStatusLabelLastUpdate.Text = "Última atualização: --";
            toolStripStatusLabelLastUpdate.TextAlign = ContentAlignment.MiddleRight;

            // 
            // toolStripProgressBarImport
            // 
            toolStripProgressBarImport.Name = "toolStripProgressBarImport";
            toolStripProgressBarImport.Size = new Size(100, 16);
            toolStripProgressBarImport.Visible = false;

            // 
            // contextMenuStripGrid
            // 
            contextMenuStripGrid.Items.AddRange(new ToolStripItem[] {
                toolStripMenuItemReprocess, toolStripMenuItemViewError,
                toolStripMenuItemDelete, toolStripMenuItemCopyPath });
            contextMenuStripGrid.Name = "contextMenuStripGrid";
            contextMenuStripGrid.Size = new Size(181, 92);

            // 
            // toolStripMenuItemReprocess
            // 
            toolStripMenuItemReprocess.Name = "toolStripMenuItemReprocess";
            toolStripMenuItemReprocess.Size = new Size(180, 22);
            toolStripMenuItemReprocess.Text = "🔄 Reprocessar Arquivo";

            // 
            // toolStripMenuItemViewError
            // 
            toolStripMenuItemViewError.Name = "toolStripMenuItemViewError";
            toolStripMenuItemViewError.Size = new Size(180, 22);
            toolStripMenuItemViewError.Text = "⚠ Ver Detalhes do Erro";

            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            toolStripMenuItemDelete.Size = new Size(180, 22);
            toolStripMenuItemDelete.Text = "🗑 Excluir Registro";

            // 
            // toolStripMenuItemCopyPath
            // 
            toolStripMenuItemCopyPath.Name = "toolStripMenuItemCopyPath";
            toolStripMenuItemCopyPath.Size = new Size(180, 22);
            toolStripMenuItemCopyPath.Text = "📋 Copiar Caminho";

            // 
            // errorProviderMain
            // 
            errorProviderMain.ContainerControl = this;

            // 
            // timerAutoRefresh
            // 
            timerAutoRefresh.Interval = 30000;

            // 
            // FormImport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 544);
            Controls.Add(tableLayoutPanelFormImportMain);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormImport";
            Text = "Sistema de Importação de Arquivos";

            // Resume layouts
            tableLayoutPanelFormImportMain.ResumeLayout(false);
            tableLayoutPanelFormImportMain.PerformLayout();
            panelTop.ResumeLayout(false);
            tableLayoutPanelTop.ResumeLayout(false);
            groupBoxFileSelection.ResumeLayout(false);
            groupBoxFileSelection.PerformLayout();
            panelActions.ResumeLayout(false);
            panelBottonMain.ResumeLayout(false);
            tableLayoutPanelBottom.ResumeLayout(false);
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            groupBoxImportHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDataImport).EndInit();
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            contextMenuStripGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProviderMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Main layout controls
        private TableLayoutPanel tableLayoutPanelFormImportMain;

        // Top panel controls
        private Panel panelTop;
        private TableLayoutPanel tableLayoutPanelTop;
        private GroupBox groupBoxFileSelection;
        private Label labelDescription;
        private Label labelFilePath;
        private ReaLTaiizor.Controls.SmallTextBox smallTextBox1;
        private Button buttonSelect;
        private Panel panelActions;
        private Button buttonImport;
        private Button buttonClearList;
        private Button buttonRefresh;
        private Button buttonExportLog;

        // Bottom panel controls
        private Panel panelBottonMain;
        private TableLayoutPanel tableLayoutPanelBottom;

        // Filter controls
        private Panel panelFilters;
        private Label labelFilterBy;
        private ComboBox comboBoxStatusFilter;
        private Label labelDateFrom;
        private DateTimePicker dateTimePickerFrom;
        private Label labelDateTo;
        private DateTimePicker dateTimePickerTo;
        private Label labelUserFilter;
        private TextBox textBoxUserFilter;
        private Button buttonApplyFilter;
        private Button buttonClearFilter;

        // Statistics controls
        private Panel panelStats;
        private Label labelTotalFiles;
        private Label labelSuccessCount;
        private Label labelErrorCount;
        private Label labelProcessingCount;

        // DataGrid controls
        private GroupBox groupBoxImportHistory;
        private DataGridView dataGridViewDataImport;
        private DataGridViewTextBoxColumn ColumnFile;
        private DataGridViewTextBoxColumn ColumnDate;
        private DataGridViewTextBoxColumn ColumnStatus;
        private DataGridViewTextBoxColumn ColumnUser;
        private DataGridViewTextBoxColumn ColumnFileSize;
        private DataGridViewTextBoxColumn ColumnRecordsCount;
        private DataGridViewTextBoxColumn ColumnErrorMessage;
        private DataGridViewTextBoxColumn ColumnDuration;
        private DataGridViewButtonColumn ColumnActions;

        // Status and context menu
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel toolStripStatusLabelRecords;
        private ToolStripStatusLabel toolStripStatusLabelLastUpdate;
        private ToolStripProgressBar toolStripProgressBarImport;
        private ContextMenuStrip contextMenuStripGrid;
        private ToolStripMenuItem toolStripMenuItemReprocess;
        private ToolStripMenuItem toolStripMenuItemViewError;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripMenuItem toolStripMenuItemCopyPath;

        // Helper components
        private ErrorProvider errorProviderMain;
        private ToolTip toolTipMain;
        private System.Windows.Forms.Timer timerAutoRefresh;
    }
}