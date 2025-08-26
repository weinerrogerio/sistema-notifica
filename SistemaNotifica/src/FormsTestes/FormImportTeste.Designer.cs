namespace SistemaNotifica.src.Forms.Principal
{
    partial class FormImportTeste
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tableLayoutPanelFormImportMain = new TableLayoutPanel();
            panelTop = new Panel();
            groupBoxFileSelection = new GroupBox();
            btnDelete = new Button();
            buttonRefresh = new Button();
            buttonExportLog = new Button();
            labelDescription = new Label();
            labelFilePath = new Label();
            smallTextBoxSelectFile = new ReaLTaiizor.Controls.SmallTextBox();
            buttonImport = new Button();
            buttonSelect = new Button();
            panelBottonMain = new Panel();
            tableLayoutPanelBottom = new TableLayoutPanel();
            panelFilters = new Panel();
            btnDatails = new Button();
            buttonClearFilter = new Button();
            buttonApplyFilter = new Button();
            textBoxUserFilter = new TextBox();
            labelUserFilter = new Label();
            dateTimePickerTo = new DateTimePicker();
            labelDateTo = new Label();
            dateTimePickerFrom = new DateTimePicker();
            labelDateFrom = new Label();
            comboBoxStatusFilter = new ComboBox();
            labelFilterBy = new Label();
            groupBoxImportHistory = new GroupBox();
            overlayPanel = new Panel();
            labelPercent = new Label();
            labelProgress = new Label();
            progressBar = new ProgressBar();
            dataGridViewDataImport = new DataGridView();
            ColumnFile = new DataGridViewTextBoxColumn();
            ColumnDate = new DataGridViewTextBoxColumn();
            ColumnStatus = new DataGridViewTextBoxColumn();
            ColumnUser = new DataGridViewTextBoxColumn();
            ColumnRecordsCount = new DataGridViewTextBoxColumn();
            ColumnErrorCount = new DataGridViewTextBoxColumn();
            ColumnDuplicatesCount = new DataGridViewTextBoxColumn();
            ColumnFileSize = new DataGridViewTextBoxColumn();
            ColumnDetalhesErros = new DataGridViewTextBoxColumn();
            ColumnDetalhesDuplicidades = new DataGridViewTextBoxColumn();
            contextMenuStripGrid = new ContextMenuStrip(components);
            toolStripMenuItemReprocess = new ToolStripMenuItem();
            toolStripMenuItemViewError = new ToolStripMenuItem();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            toolStripMenuItemCopyPath = new ToolStripMenuItem();
            statusStripMain = new StatusStrip();
            toolStripStatusLabelRecords = new ToolStripStatusLabel();
            toolStripStatusLabelLastUpdate = new ToolStripStatusLabel();
            toolStripProgressBarImport = new ToolStripProgressBar();
            errorProviderMain = new ErrorProvider(components);
            toolTipMain = new ToolTip(components);
            timerAutoRefresh = new System.Windows.Forms.Timer(components);
            pnlProgressOverlay = new Panel();
            pnlProgressUpload = new Panel();
            labelStatusUpload = new Label();
            progressBarUpload = new ProgressBar();
            tableLayoutPanelFormImportMain.SuspendLayout();
            panelTop.SuspendLayout();
            groupBoxFileSelection.SuspendLayout();
            panelBottonMain.SuspendLayout();
            tableLayoutPanelBottom.SuspendLayout();
            panelFilters.SuspendLayout();
            groupBoxImportHistory.SuspendLayout();
            overlayPanel.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewDataImport ).BeginInit();
            contextMenuStripGrid.SuspendLayout();
            statusStripMain.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) errorProviderMain ).BeginInit();
            pnlProgressOverlay.SuspendLayout();
            pnlProgressUpload.SuspendLayout();
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
            tableLayoutPanelFormImportMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanelFormImportMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelFormImportMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanelFormImportMain.Size = new Size(860, 544);
            tableLayoutPanelFormImportMain.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(groupBoxFileSelection);
            panelTop.Dock = DockStyle.Fill;
            panelTop.Location = new Point(10, 10);
            panelTop.Margin = new Padding(10, 10, 10, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(840, 110);
            panelTop.TabIndex = 1;
            // 
            // groupBoxFileSelection
            // 
            groupBoxFileSelection.Controls.Add(btnDelete);
            groupBoxFileSelection.Controls.Add(buttonRefresh);
            groupBoxFileSelection.Controls.Add(buttonExportLog);
            groupBoxFileSelection.Controls.Add(labelDescription);
            groupBoxFileSelection.Controls.Add(labelFilePath);
            groupBoxFileSelection.Controls.Add(smallTextBoxSelectFile);
            groupBoxFileSelection.Controls.Add(buttonImport);
            groupBoxFileSelection.Controls.Add(buttonSelect);
            groupBoxFileSelection.Dock = DockStyle.Fill;
            groupBoxFileSelection.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxFileSelection.Location = new Point(0, 0);
            groupBoxFileSelection.Name = "groupBoxFileSelection";
            groupBoxFileSelection.Size = new Size(840, 110);
            groupBoxFileSelection.TabIndex = 0;
            groupBoxFileSelection.TabStop = false;
            groupBoxFileSelection.Text = "Seleção de Arquivo";
            // 
            // btnDelete
            // 
            btnDelete.Anchor =     AnchorStyles.Top  |  AnchorStyles.Right ;
            btnDelete.BackColor = Color.Brown;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(695, 41);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(119, 28);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "🗑 Excluir arquivo";
            toolTipMain.SetToolTip(btnDelete, "Iniciar importação do arquivo selecionado");
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor =     AnchorStyles.Top  |  AnchorStyles.Right ;
            buttonRefresh.Location = new Point(577, 76);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(90, 28);
            buttonRefresh.TabIndex = 6;
            buttonRefresh.Text = "🔄 Atualizar";
            toolTipMain.SetToolTip(buttonRefresh, "Atualizar lista de importações");
            buttonRefresh.UseVisualStyleBackColor = true;
            // 
            // buttonExportLog
            // 
            buttonExportLog.Anchor =     AnchorStyles.Top  |  AnchorStyles.Right ;
            buttonExportLog.Location = new Point(711, 76);
            buttonExportLog.Name = "buttonExportLog";
            buttonExportLog.Size = new Size(85, 28);
            buttonExportLog.TabIndex = 7;
            buttonExportLog.Text = "📊 Exportar Log";
            toolTipMain.SetToolTip(buttonExportLog, "Exportar log de importações para Excel");
            buttonExportLog.UseVisualStyleBackColor = true;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 8.25F);
            labelDescription.Location = new Point(6, 18);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(667, 13);
            labelDescription.TabIndex = 0;
            labelDescription.Text = "Para Importar um arquivo, informe o arquivo nos campos abaixo. Atenção: não é permitida a importação de arquivos duplicados!";
            // 
            // labelFilePath
            // 
            labelFilePath.AutoSize = true;
            labelFilePath.Font = new Font("Segoe UI", 9F);
            labelFilePath.Location = new Point(6, 45);
            labelFilePath.Name = "labelFilePath";
            labelFilePath.Size = new Size(52, 15);
            labelFilePath.TabIndex = 1;
            labelFilePath.Text = "Arquivo:";
            // 
            // smallTextBoxSelectFile
            // 
            smallTextBoxSelectFile.Anchor =     AnchorStyles.Left  |  AnchorStyles.Right ;
            smallTextBoxSelectFile.BackColor = Color.Transparent;
            smallTextBoxSelectFile.BorderColor = Color.FromArgb(      180,       180,       180);
            smallTextBoxSelectFile.CustomBGColor = Color.White;
            smallTextBoxSelectFile.Font = new Font("Tahoma", 11F);
            smallTextBoxSelectFile.ForeColor = Color.DimGray;
            smallTextBoxSelectFile.Location = new Point(64, 40);
            smallTextBoxSelectFile.MaxLength = 32767;
            smallTextBoxSelectFile.Multiline = false;
            smallTextBoxSelectFile.Name = "smallTextBoxSelectFile";
            smallTextBoxSelectFile.ReadOnly = true;
            smallTextBoxSelectFile.Size = new Size(336, 28);
            smallTextBoxSelectFile.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            smallTextBoxSelectFile.TabIndex = 2;
            smallTextBoxSelectFile.Text = "Selecione um arquivo...";
            smallTextBoxSelectFile.TextAlignment = HorizontalAlignment.Left;
            smallTextBoxSelectFile.UseSystemPasswordChar = false;
            // 
            // buttonImport
            // 
            buttonImport.Anchor =     AnchorStyles.Top  |  AnchorStyles.Right ;
            buttonImport.BackColor = Color.FromArgb(      0,       122,       255);
            buttonImport.FlatStyle = FlatStyle.Flat;
            buttonImport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonImport.ForeColor = Color.White;
            buttonImport.Location = new Point(577, 41);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(90, 28);
            buttonImport.TabIndex = 4;
            buttonImport.Text = "▶ Importar";
            toolTipMain.SetToolTip(buttonImport, "Iniciar importação do arquivo selecionado");
            buttonImport.UseVisualStyleBackColor = false;
            buttonImport.Click +=  buttonImport_Click ;
            // 
            // buttonSelect
            // 
            buttonSelect.Anchor =     AnchorStyles.Top  |  AnchorStyles.Right ;
            buttonSelect.Font = new Font("Segoe UI", 9F);
            buttonSelect.Location = new Point(416, 41);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(136, 28);
            buttonSelect.TabIndex = 3;
            buttonSelect.Text = "📁 Selecionar Arquivo";
            toolTipMain.SetToolTip(buttonSelect, "Clique para selecionar um arquivo para importação");
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click +=  buttonSelect_Click ;
            // 
            // panelBottonMain
            // 
            panelBottonMain.Controls.Add(tableLayoutPanelBottom);
            panelBottonMain.Dock = DockStyle.Fill;
            panelBottonMain.Location = new Point(10, 130);
            panelBottonMain.Margin = new Padding(10, 10, 10, 0);
            panelBottonMain.Name = "panelBottonMain";
            panelBottonMain.Size = new Size(840, 389);
            panelBottonMain.TabIndex = 0;
            // 
            // tableLayoutPanelBottom
            // 
            tableLayoutPanelBottom.ColumnCount = 1;
            tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelBottom.Controls.Add(panelFilters, 0, 0);
            tableLayoutPanelBottom.Controls.Add(groupBoxImportHistory, 0, 1);
            tableLayoutPanelBottom.Dock = DockStyle.Fill;
            tableLayoutPanelBottom.Location = new Point(0, 0);
            tableLayoutPanelBottom.Margin = new Padding(0);
            tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            tableLayoutPanelBottom.RowCount = 2;
            tableLayoutPanelBottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanelBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelBottom.Size = new Size(840, 389);
            tableLayoutPanelBottom.TabIndex = 0;
            // 
            // panelFilters
            // 
            panelFilters.BackColor = Color.FromArgb(      248,       249,       250);
            panelFilters.BorderStyle = BorderStyle.FixedSingle;
            panelFilters.Controls.Add(btnDatails);
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
            panelFilters.Size = new Size(834, 54);
            panelFilters.TabIndex = 3;
            // 
            // btnDatails
            // 
            btnDatails.Anchor =     AnchorStyles.Top  |  AnchorStyles.Right ;
            btnDatails.BackColor = Color.Green;
            btnDatails.FlatStyle = FlatStyle.Flat;
            btnDatails.ForeColor = Color.White;
            btnDatails.Location = new Point(745, 21);
            btnDatails.Name = "btnDatails";
            btnDatails.Size = new Size(80, 23);
            btnDatails.TabIndex = 10;
            btnDatails.Text = "Detalhes";
            btnDatails.UseVisualStyleBackColor = false;
            btnDatails.Click +=  btnDatails_Click ;
            // 
            // buttonClearFilter
            // 
            buttonClearFilter.Anchor =     AnchorStyles.Top  |  AnchorStyles.Right ;
            buttonClearFilter.Location = new Point(663, 21);
            buttonClearFilter.Name = "buttonClearFilter";
            buttonClearFilter.Size = new Size(77, 23);
            buttonClearFilter.TabIndex = 9;
            buttonClearFilter.Text = "✖ Limpar";
            buttonClearFilter.UseVisualStyleBackColor = true;
            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.Anchor =     AnchorStyles.Top  |  AnchorStyles.Right ;
            buttonApplyFilter.BackColor = Color.FromArgb(      40,       167,       69);
            buttonApplyFilter.FlatStyle = FlatStyle.Flat;
            buttonApplyFilter.ForeColor = Color.White;
            buttonApplyFilter.Location = new Point(577, 21);
            buttonApplyFilter.Name = "buttonApplyFilter";
            buttonApplyFilter.Size = new Size(80, 23);
            buttonApplyFilter.TabIndex = 8;
            buttonApplyFilter.Text = "🔍 Filtrar";
            buttonApplyFilter.UseVisualStyleBackColor = false;
            buttonApplyFilter.Click +=  buttonApplyFilter_Click ;
            // 
            // textBoxUserFilter
            // 
            textBoxUserFilter.Location = new Point(411, 21);
            textBoxUserFilter.Name = "textBoxUserFilter";
            textBoxUserFilter.PlaceholderText = "Nome do usuário...";
            textBoxUserFilter.Size = new Size(150, 23);
            textBoxUserFilter.TabIndex = 7;
            // 
            // labelUserFilter
            // 
            labelUserFilter.AutoSize = true;
            labelUserFilter.Location = new Point(411, 8);
            labelUserFilter.Name = "labelUserFilter";
            labelUserFilter.Size = new Size(50, 15);
            labelUserFilter.TabIndex = 6;
            labelUserFilter.Text = "Usuário:";
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Format = DateTimePickerFormat.Short;
            dateTimePickerTo.Location = new Point(301, 21);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(100, 23);
            dateTimePickerTo.TabIndex = 5;
            // 
            // labelDateTo
            // 
            labelDateTo.AutoSize = true;
            labelDateTo.Location = new Point(301, 8);
            labelDateTo.Name = "labelDateTo";
            labelDateTo.Size = new Size(28, 15);
            labelDateTo.TabIndex = 4;
            labelDateTo.Text = "Até:";
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Format = DateTimePickerFormat.Short;
            dateTimePickerFrom.Location = new Point(191, 21);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(100, 23);
            dateTimePickerFrom.TabIndex = 3;
            // 
            // labelDateFrom
            // 
            labelDateFrom.AutoSize = true;
            labelDateFrom.Location = new Point(191, 8);
            labelDateFrom.Name = "labelDateFrom";
            labelDateFrom.Size = new Size(24, 15);
            labelDateFrom.TabIndex = 2;
            labelDateFrom.Text = "De:";
            // 
            // comboBoxStatusFilter
            // 
            comboBoxStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatusFilter.Items.AddRange(new object[] { "Todos", "Sucesso", "Erro", "Processando" });
            comboBoxStatusFilter.Location = new Point(81, 21);
            comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            comboBoxStatusFilter.Size = new Size(100, 23);
            comboBoxStatusFilter.TabIndex = 1;
            // 
            // labelFilterBy
            // 
            labelFilterBy.AutoSize = true;
            labelFilterBy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFilterBy.Location = new Point(13, 5);
            labelFilterBy.Name = "labelFilterBy";
            labelFilterBy.Size = new Size(65, 15);
            labelFilterBy.TabIndex = 0;
            labelFilterBy.Text = "Filtrar por:";
            // 
            // groupBoxImportHistory
            // 
            groupBoxImportHistory.Controls.Add(overlayPanel);
            groupBoxImportHistory.Controls.Add(dataGridViewDataImport);
            groupBoxImportHistory.Dock = DockStyle.Fill;
            groupBoxImportHistory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxImportHistory.Location = new Point(3, 63);
            groupBoxImportHistory.Name = "groupBoxImportHistory";
            groupBoxImportHistory.Padding = new Padding(0);
            groupBoxImportHistory.Size = new Size(834, 323);
            groupBoxImportHistory.TabIndex = 4;
            groupBoxImportHistory.TabStop = false;
            groupBoxImportHistory.Text = "Histórico de Importações";
            // 
            // overlayPanel
            // 
            overlayPanel.BackColor = SystemColors.ActiveCaption;
            overlayPanel.BorderStyle = BorderStyle.FixedSingle;
            overlayPanel.Controls.Add(labelPercent);
            overlayPanel.Controls.Add(labelProgress);
            overlayPanel.Controls.Add(progressBar);
            overlayPanel.Location = new Point(14, 44);
            overlayPanel.Name = "overlayPanel";
            overlayPanel.Size = new Size(477, 235);
            overlayPanel.TabIndex = 1;
            // 
            // labelPercent
            // 
            labelPercent.AutoSize = true;
            labelPercent.Location = new Point(314, 27);
            labelPercent.Name = "labelPercent";
            labelPercent.Size = new Size(38, 15);
            labelPercent.TabIndex = 2;
            labelPercent.Text = "100%";
            // 
            // labelProgress
            // 
            labelProgress.AutoSize = true;
            labelProgress.Location = new Point(21, 27);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(40, 15);
            labelProgress.TabIndex = 1;
            labelProgress.Text = "label1";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(21, 54);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(331, 23);
            progressBar.TabIndex = 0;
            // 
            // dataGridViewDataImport
            // 
            dataGridViewDataImport.AllowUserToAddRows = false;
            dataGridViewDataImport.AllowUserToDeleteRows = false;
            dataGridViewDataImport.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(      248,       249,       250);
            dataGridViewDataImport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewDataImport.BackgroundColor = SystemColors.Control;
            dataGridViewDataImport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDataImport.Columns.AddRange(new DataGridViewColumn[] { ColumnFile, ColumnDate, ColumnStatus, ColumnUser, ColumnRecordsCount, ColumnErrorCount, ColumnDuplicatesCount, ColumnFileSize, ColumnDetalhesErros, ColumnDetalhesDuplicidades });
            dataGridViewDataImport.ContextMenuStrip = contextMenuStripGrid;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(      0,       123,       255);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewDataImport.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewDataImport.Dock = DockStyle.Fill;
            dataGridViewDataImport.Font = new Font("Segoe UI", 8.25F);
            dataGridViewDataImport.GridColor = Color.WhiteSmoke;
            dataGridViewDataImport.Location = new Point(0, 16);
            dataGridViewDataImport.Name = "dataGridViewDataImport";
            dataGridViewDataImport.ReadOnly = true;
            dataGridViewDataImport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDataImport.Size = new Size(834, 307);
            dataGridViewDataImport.TabIndex = 0;
            dataGridViewDataImport.Visible = false;
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
            // 
            // ColumnRecordsCount
            // 
            ColumnRecordsCount.HeaderText = "Registros";
            ColumnRecordsCount.Name = "ColumnRecordsCount";
            ColumnRecordsCount.ReadOnly = true;
            ColumnRecordsCount.Width = 70;
            // 
            // ColumnErrorCount
            // 
            ColumnErrorCount.HeaderText = "Erros";
            ColumnErrorCount.Name = "ColumnErrorCount";
            ColumnErrorCount.ReadOnly = true;
            ColumnErrorCount.Width = 150;
            // 
            // ColumnDuplicatesCount
            // 
            ColumnDuplicatesCount.HeaderText = "Duplicidades";
            ColumnDuplicatesCount.Name = "ColumnDuplicatesCount";
            ColumnDuplicatesCount.ReadOnly = true;
            // 
            // ColumnFileSize
            // 
            ColumnFileSize.HeaderText = "Tamanho";
            ColumnFileSize.Name = "ColumnFileSize";
            ColumnFileSize.ReadOnly = true;
            ColumnFileSize.Width = 80;
            // 
            // ColumnDetalhesErros
            // 
            ColumnDetalhesErros.HeaderText = "DetalhesErros";
            ColumnDetalhesErros.Name = "ColumnDetalhesErros";
            ColumnDetalhesErros.ReadOnly = true;
            ColumnDetalhesErros.Visible = false;
            // 
            // ColumnDetalhesDuplicidades
            // 
            ColumnDetalhesDuplicidades.HeaderText = "DetalhesDuplicidades";
            ColumnDetalhesDuplicidades.Name = "ColumnDetalhesDuplicidades";
            ColumnDetalhesDuplicidades.ReadOnly = true;
            ColumnDetalhesDuplicidades.Visible = false;
            // 
            // contextMenuStripGrid
            // 
            contextMenuStripGrid.Items.AddRange(new ToolStripItem[] { toolStripMenuItemReprocess, toolStripMenuItemViewError, toolStripMenuItemDelete, toolStripMenuItemCopyPath });
            contextMenuStripGrid.Name = "contextMenuStripGrid";
            contextMenuStripGrid.Size = new Size(198, 92);
            // 
            // toolStripMenuItemReprocess
            // 
            toolStripMenuItemReprocess.Name = "toolStripMenuItemReprocess";
            toolStripMenuItemReprocess.Size = new Size(197, 22);
            toolStripMenuItemReprocess.Text = "🔄 Reprocessar Arquivo";
            // 
            // toolStripMenuItemViewError
            // 
            toolStripMenuItemViewError.Name = "toolStripMenuItemViewError";
            toolStripMenuItemViewError.Size = new Size(197, 22);
            toolStripMenuItemViewError.Text = "⚠ Ver Detalhes do Erro";
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            toolStripMenuItemDelete.Size = new Size(197, 22);
            toolStripMenuItemDelete.Text = "🗑 Excluir Registro";
            // 
            // toolStripMenuItemCopyPath
            // 
            toolStripMenuItemCopyPath.Name = "toolStripMenuItemCopyPath";
            toolStripMenuItemCopyPath.Size = new Size(197, 22);
            toolStripMenuItemCopyPath.Text = "📋 Copiar Caminho";
            // 
            // statusStripMain
            // 
            statusStripMain.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelRecords, toolStripStatusLabelLastUpdate, toolStripProgressBarImport });
            statusStripMain.Location = new Point(0, 522);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Size = new Size(860, 22);
            statusStripMain.TabIndex = 2;
            statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelRecords
            // 
            toolStripStatusLabelRecords.Name = "toolStripStatusLabelRecords";
            toolStripStatusLabelRecords.Size = new Size(109, 17);
            toolStripStatusLabelRecords.Text = "Total de registros: 0";
            // 
            // toolStripStatusLabelLastUpdate
            // 
            toolStripStatusLabelLastUpdate.Name = "toolStripStatusLabelLastUpdate";
            toolStripStatusLabelLastUpdate.Size = new Size(736, 17);
            toolStripStatusLabelLastUpdate.Spring = true;
            toolStripStatusLabelLastUpdate.Text = "Última atualização: --";
            toolStripStatusLabelLastUpdate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // toolStripProgressBarImport
            // 
            toolStripProgressBarImport.Name = "toolStripProgressBarImport";
            toolStripProgressBarImport.Size = new Size(100, 19);
            toolStripProgressBarImport.Visible = false;
            // 
            // errorProviderMain
            // 
            errorProviderMain.ContainerControl = this;
            // 
            // timerAutoRefresh
            // 
            timerAutoRefresh.Interval = 30000;
            // 
            // pnlProgressOverlay
            // 
            pnlProgressOverlay.BackColor = Color.Transparent;
            pnlProgressOverlay.Controls.Add(pnlProgressUpload);
            pnlProgressOverlay.Dock = DockStyle.Fill;
            pnlProgressOverlay.Location = new Point(0, 0);
            pnlProgressOverlay.Name = "pnlProgressOverlay";
            pnlProgressOverlay.Size = new Size(860, 544);
            pnlProgressOverlay.TabIndex = 999;
            pnlProgressOverlay.Visible = false;
            // 
            // pnlProgressUpload
            // 
            pnlProgressUpload.Anchor = AnchorStyles.None;
            pnlProgressUpload.BackColor = Color.White;
            pnlProgressUpload.BorderStyle = BorderStyle.FixedSingle;
            pnlProgressUpload.Controls.Add(labelStatusUpload);
            pnlProgressUpload.Controls.Add(progressBarUpload);
            pnlProgressUpload.Location = new Point(530, 372);
            pnlProgressUpload.Name = "pnlProgressUpload";
            pnlProgressUpload.Size = new Size(400, 120);
            pnlProgressUpload.TabIndex = 0;
            // 
            // labelStatusUpload
            // 
            labelStatusUpload.AutoSize = true;
            labelStatusUpload.Font = new Font("Segoe UI", 10F);
            labelStatusUpload.Location = new Point(15, 20);
            labelStatusUpload.Name = "labelStatusUpload";
            labelStatusUpload.Size = new Size(145, 19);
            labelStatusUpload.TabIndex = 0;
            labelStatusUpload.Text = "Processando arquivo...";
            // 
            // progressBarUpload
            // 
            progressBarUpload.Location = new Point(15, 55);
            progressBarUpload.Name = "progressBarUpload";
            progressBarUpload.Size = new Size(370, 25);
            progressBarUpload.TabIndex = 1;
            // 
            // FormImportTeste
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 544);
            Controls.Add(tableLayoutPanelFormImportMain);
            Controls.Add(pnlProgressOverlay);
            Font = new Font("Segoe UI", 9F);
            Name = "FormImportTeste";
            Text = "Sistema de Importação de Arquivos";
            tableLayoutPanelFormImportMain.ResumeLayout(false);
            tableLayoutPanelFormImportMain.PerformLayout();
            panelTop.ResumeLayout(false);
            groupBoxFileSelection.ResumeLayout(false);
            groupBoxFileSelection.PerformLayout();
            panelBottonMain.ResumeLayout(false);
            tableLayoutPanelBottom.ResumeLayout(false);
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            groupBoxImportHistory.ResumeLayout(false);
            overlayPanel.ResumeLayout(false);
            overlayPanel.PerformLayout();
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewDataImport ).EndInit();
            contextMenuStripGrid.ResumeLayout(false);
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            ( ( System.ComponentModel.ISupportInitialize ) errorProviderMain ).EndInit();
            pnlProgressOverlay.ResumeLayout(false);
            pnlProgressUpload.ResumeLayout(false);
            pnlProgressUpload.PerformLayout();
            ResumeLayout(false);

        }

        #endregion


        // Main layout controls
        private TableLayoutPanel tableLayoutPanelFormImportMain;

        // Top panel controls
        private Panel panelTop;
        // private TableLayoutPanel tableLayoutPanelTop; // Removed
        private GroupBox groupBoxFileSelection;
        private Label labelDescription;
        private Label labelFilePath;
        private ReaLTaiizor.Controls.SmallTextBox smallTextBoxSelectFile;
        private Button buttonSelect;
        private Button buttonImport;
        private Button buttonRefresh;
        private Button buttonExportLog;

        // Bottom panel controls
        private Panel panelBottonMain;
        private TableLayoutPanel tableLayoutPanelBottom;
        private ContextMenuStrip contextMenuStripGrid;
        private ToolStripMenuItem toolStripMenuItemReprocess;
        private ToolStripMenuItem toolStripMenuItemViewError;
        private ToolStripMenuItem toolStripMenuItemDelete;
        private ToolStripMenuItem toolStripMenuItemCopyPath;

        // Helper components
        private ErrorProvider errorProviderMain;
        private ToolTip toolTipMain;
        private System.Windows.Forms.Timer timerAutoRefresh;
        private Panel panelFilters;
        private Button buttonClearFilter;
        private Button buttonApplyFilter;
        private TextBox textBoxUserFilter;
        private Label labelUserFilter;
        private DateTimePicker dateTimePickerTo;
        private Label labelDateTo;
        private DateTimePicker dateTimePickerFrom;
        private Label labelDateFrom;
        private ComboBox comboBoxStatusFilter;
        private Label labelFilterBy;
        private GroupBox groupBoxImportHistory;
        private DataGridView dataGridViewDataImport;
        private DataGridViewTextBoxColumn ColumnFile;
        private DataGridViewTextBoxColumn ColumnDate;
        private DataGridViewTextBoxColumn ColumnStatus;
        private DataGridViewTextBoxColumn ColumnUser;
        private DataGridViewTextBoxColumn ColumnRecordsCount;
        private DataGridViewTextBoxColumn ColumnErrorCount;
        private DataGridViewTextBoxColumn ColumnDuplicatesCount;
        private DataGridViewTextBoxColumn ColumnFileSize;
        private DataGridViewTextBoxColumn ColumnDetalhesErros;
        private DataGridViewTextBoxColumn ColumnDetalhesDuplicidades;
        private Button btnDatails;
        private Button btnDelete;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel toolStripStatusLabelRecords;
        private ToolStripStatusLabel toolStripStatusLabelLastUpdate;
        private ToolStripProgressBar toolStripProgressBarImport;

        private Panel pnlProgressOverlay;
        private Panel pnlProgressUpload;
        private Label labelStatusUpload;
        private ProgressBar progressBarUpload;
        private Panel overlayPanel;
        private Label labelPercent;
        private Label labelProgress;
        private ProgressBar progressBar;
    }
}