namespace SistemaNotifica.src.Forms.Principal
{
    partial class FormUser
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
            panelMain = new Panel();
            tableLayoutPanel = new TableLayoutPanel();
            panelMainData = new Panel();
            panelAllUsersData = new Panel();
            tableLayoutPanelUsers = new TableLayoutPanel();
            panelDataUsersBotton = new Panel();
            flowLayoutPanelButtonsUsers = new FlowLayoutPanel();
            buttonNewUser = new Button();
            buttonEditSelectedUser = new Button();
            buttonDeleteUser = new Button();
            buttonReactivateUser = new Button();
            panelDataUsersTop = new Panel();
            flowLayoutPanelTopInfoUsers = new FlowLayoutPanel();
            labelUsers = new Label();
            checkBoxAllUsers = new CheckBox();
            panelDataUsersMiddle = new Panel();
            dataGridViewUsersData = new DataGridView();
            ColumnSelect = new DataGridViewCheckBoxColumn();
            ColumnId = new DataGridViewTextBoxColumn();
            ColumnUserName = new DataGridViewTextBoxColumn();
            ColumnEmail = new DataGridViewTextBoxColumn();
            ColumnFone = new DataGridViewTextBoxColumn();
            ColumnAdmin = new DataGridViewTextBoxColumn();
            ColumnCreatedAt = new DataGridViewTextBoxColumn();
            ColumnIsActive = new DataGridViewTextBoxColumn();
            panelNewUser = new Panel();
            panelNewUserTextBoxes = new Panel();
            labelErrorConfirmPassword = new Label();
            labelErrorPassword = new Label();
            labelErrorFone = new Label();
            labelErrorEmail = new Label();
            labelErrorName = new Label();
            textBoxConfirmPassword = new TextBox();
            textBoxPassword = new TextBox();
            labelPasswordConfirm = new Label();
            labelPassword = new Label();
            checkBoxIsAdmin = new CheckBox();
            buttonCancel = new Button();
            label2 = new Label();
            textBoxIsAdmin = new TextBox();
            label3 = new Label();
            textBoxEditFone = new TextBox();
            label4 = new Label();
            textBoxEditEmail = new TextBox();
            label5 = new Label();
            textBoxEditName = new TextBox();
            buttonSave = new Button();
            panel1 = new Panel();
            labelInfoNewUser = new Label();
            panelUserData = new Panel();
            panelUserDataTextBoxes = new Panel();
            buttonEditMyData = new Button();
            labelActive = new Label();
            textBoxActive = new TextBox();
            labelIsAdmin = new Label();
            textBoxAdmin = new TextBox();
            labelFone = new Label();
            textBoxFone = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelName = new Label();
            textBoxName = new TextBox();
            tableLayoutPanelTop = new TableLayoutPanel();
            panelBtn2 = new Panel();
            btnUsers = new Button();
            panelBtn1 = new Panel();
            btnMyData = new Button();
            panelMain.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panelMainData.SuspendLayout();
            panelAllUsersData.SuspendLayout();
            tableLayoutPanelUsers.SuspendLayout();
            panelDataUsersBotton.SuspendLayout();
            flowLayoutPanelButtonsUsers.SuspendLayout();
            panelDataUsersTop.SuspendLayout();
            flowLayoutPanelTopInfoUsers.SuspendLayout();
            panelDataUsersMiddle.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewUsersData ).BeginInit();
            panelNewUser.SuspendLayout();
            panelNewUserTextBoxes.SuspendLayout();
            panel1.SuspendLayout();
            panelUserData.SuspendLayout();
            panelUserDataTextBoxes.SuspendLayout();
            tableLayoutPanelTop.SuspendLayout();
            panelBtn2.SuspendLayout();
            panelBtn1.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(tableLayoutPanel);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(800, 450);
            panelMain.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(panelMainData, 0, 1);
            tableLayoutPanel.Controls.Add(tableLayoutPanelTop, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.7953043F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 89.2047F));
            tableLayoutPanel.Size = new Size(800, 450);
            tableLayoutPanel.TabIndex = 0;
            // 
            // panelMainData
            // 
            panelMainData.Controls.Add(panelAllUsersData);
            panelMainData.Controls.Add(panelNewUser);
            panelMainData.Controls.Add(panelUserData);
            panelMainData.Dock = DockStyle.Fill;
            panelMainData.Location = new Point(3, 51);
            panelMainData.Name = "panelMainData";
            panelMainData.Size = new Size(794, 396);
            panelMainData.TabIndex = 1;
            // 
            // panelAllUsersData
            // 
            panelAllUsersData.Controls.Add(tableLayoutPanelUsers);
            panelAllUsersData.Dock = DockStyle.Fill;
            panelAllUsersData.Location = new Point(0, 0);
            panelAllUsersData.Name = "panelAllUsersData";
            panelAllUsersData.Size = new Size(794, 396);
            panelAllUsersData.TabIndex = 10;
            // 
            // tableLayoutPanelUsers
            // 
            tableLayoutPanelUsers.ColumnCount = 1;
            tableLayoutPanelUsers.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelUsers.Controls.Add(panelDataUsersBotton, 0, 2);
            tableLayoutPanelUsers.Controls.Add(panelDataUsersTop, 0, 0);
            tableLayoutPanelUsers.Controls.Add(panelDataUsersMiddle, 0, 1);
            tableLayoutPanelUsers.Dock = DockStyle.Fill;
            tableLayoutPanelUsers.Location = new Point(0, 0);
            tableLayoutPanelUsers.Margin = new Padding(0);
            tableLayoutPanelUsers.Name = "tableLayoutPanelUsers";
            tableLayoutPanelUsers.RowCount = 3;
            tableLayoutPanelUsers.RowStyles.Add(new RowStyle(SizeType.Percent, 6.4F));
            tableLayoutPanelUsers.RowStyles.Add(new RowStyle(SizeType.Percent, 93.6F));
            tableLayoutPanelUsers.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            tableLayoutPanelUsers.Size = new Size(794, 396);
            tableLayoutPanelUsers.TabIndex = 9;
            // 
            // panelDataUsersBotton
            // 
            panelDataUsersBotton.Controls.Add(flowLayoutPanelButtonsUsers);
            panelDataUsersBotton.Dock = DockStyle.Fill;
            panelDataUsersBotton.Location = new Point(3, 351);
            panelDataUsersBotton.Name = "panelDataUsersBotton";
            panelDataUsersBotton.Size = new Size(788, 42);
            panelDataUsersBotton.TabIndex = 3;
            // 
            // flowLayoutPanelButtonsUsers
            // 
            flowLayoutPanelButtonsUsers.Anchor = AnchorStyles.None;
            flowLayoutPanelButtonsUsers.Controls.Add(buttonNewUser);
            flowLayoutPanelButtonsUsers.Controls.Add(buttonEditSelectedUser);
            flowLayoutPanelButtonsUsers.Controls.Add(buttonDeleteUser);
            flowLayoutPanelButtonsUsers.Controls.Add(buttonReactivateUser);
            flowLayoutPanelButtonsUsers.Location = new Point(151, -3);
            flowLayoutPanelButtonsUsers.Name = "flowLayoutPanelButtonsUsers";
            flowLayoutPanelButtonsUsers.Size = new Size(486, 44);
            flowLayoutPanelButtonsUsers.TabIndex = 0;
            // 
            // buttonNewUser
            // 
            buttonNewUser.Location = new Point(3, 3);
            buttonNewUser.Name = "buttonNewUser";
            buttonNewUser.Size = new Size(115, 39);
            buttonNewUser.TabIndex = 5;
            buttonNewUser.Text = "Novo Usuário ";
            buttonNewUser.UseVisualStyleBackColor = true;
            buttonNewUser.Click +=  buttonNewUser_Click ;
            // 
            // buttonEditSelectedUser
            // 
            buttonEditSelectedUser.Location = new Point(124, 3);
            buttonEditSelectedUser.Name = "buttonEditSelectedUser";
            buttonEditSelectedUser.Size = new Size(115, 39);
            buttonEditSelectedUser.TabIndex = 4;
            buttonEditSelectedUser.Text = "Editar Usuário selecionado";
            buttonEditSelectedUser.UseVisualStyleBackColor = true;
            buttonEditSelectedUser.Click +=  buttonEditSelectedUser_Click ;
            // 
            // buttonDeleteUser
            // 
            buttonDeleteUser.Location = new Point(245, 3);
            buttonDeleteUser.Name = "buttonDeleteUser";
            buttonDeleteUser.Size = new Size(115, 39);
            buttonDeleteUser.TabIndex = 6;
            buttonDeleteUser.Text = "Deletar Usuário";
            buttonDeleteUser.UseVisualStyleBackColor = true;
            buttonDeleteUser.Click +=  buttonDeleteUser_Click ;
            // 
            // buttonReactivateUser
            // 
            buttonReactivateUser.Location = new Point(366, 3);
            buttonReactivateUser.Name = "buttonReactivateUser";
            buttonReactivateUser.Size = new Size(115, 39);
            buttonReactivateUser.TabIndex = 7;
            buttonReactivateUser.Text = "Reativar Cadastro";
            buttonReactivateUser.UseVisualStyleBackColor = true;
            buttonReactivateUser.Click +=  buttonReactivateUser_Click ;
            // 
            // panelDataUsersTop
            // 
            panelDataUsersTop.Controls.Add(flowLayoutPanelTopInfoUsers);
            panelDataUsersTop.Dock = DockStyle.Fill;
            panelDataUsersTop.Location = new Point(0, 0);
            panelDataUsersTop.Margin = new Padding(0);
            panelDataUsersTop.Name = "panelDataUsersTop";
            panelDataUsersTop.Size = new Size(794, 22);
            panelDataUsersTop.TabIndex = 0;
            // 
            // flowLayoutPanelTopInfoUsers
            // 
            flowLayoutPanelTopInfoUsers.Controls.Add(labelUsers);
            flowLayoutPanelTopInfoUsers.Controls.Add(checkBoxAllUsers);
            flowLayoutPanelTopInfoUsers.Location = new Point(190, 3);
            flowLayoutPanelTopInfoUsers.Margin = new Padding(0);
            flowLayoutPanelTopInfoUsers.Name = "flowLayoutPanelTopInfoUsers";
            flowLayoutPanelTopInfoUsers.Size = new Size(425, 22);
            flowLayoutPanelTopInfoUsers.TabIndex = 2;
            // 
            // labelUsers
            // 
            labelUsers.AutoSize = true;
            labelUsers.Location = new Point(3, 0);
            labelUsers.Name = "labelUsers";
            labelUsers.Padding = new Padding(0, 4, 0, 0);
            labelUsers.Size = new Size(151, 19);
            labelUsers.TabIndex = 0;
            labelUsers.Text = "USUÁRIOS CADASTRADOS:";
            // 
            // checkBoxAllUsers
            // 
            checkBoxAllUsers.Anchor =     AnchorStyles.Top  |  AnchorStyles.Right ;
            checkBoxAllUsers.AutoSize = true;
            checkBoxAllUsers.Location = new Point(162, 3);
            checkBoxAllUsers.Margin = new Padding(5, 3, 0, 0);
            checkBoxAllUsers.Name = "checkBoxAllUsers";
            checkBoxAllUsers.Size = new Size(251, 19);
            checkBoxAllUsers.TabIndex = 1;
            checkBoxAllUsers.Text = "Mostrar usuários Deletados ou desativados";
            checkBoxAllUsers.UseVisualStyleBackColor = true;
            checkBoxAllUsers.CheckedChanged +=  checkBoxAllUsers_CheckedChanged ;
            // 
            // panelDataUsersMiddle
            // 
            panelDataUsersMiddle.Controls.Add(dataGridViewUsersData);
            panelDataUsersMiddle.Dock = DockStyle.Fill;
            panelDataUsersMiddle.Location = new Point(3, 25);
            panelDataUsersMiddle.Name = "panelDataUsersMiddle";
            panelDataUsersMiddle.Padding = new Padding(80, 0, 80, 0);
            panelDataUsersMiddle.Size = new Size(788, 320);
            panelDataUsersMiddle.TabIndex = 2;
            // 
            // dataGridViewUsersData
            // 
            dataGridViewUsersData.AllowUserToAddRows = false;
            dataGridViewUsersData.AllowUserToOrderColumns = true;
            dataGridViewUsersData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsersData.Columns.AddRange(new DataGridViewColumn[] { ColumnSelect, ColumnId, ColumnUserName, ColumnEmail, ColumnFone, ColumnAdmin, ColumnCreatedAt, ColumnIsActive });
            dataGridViewUsersData.Dock = DockStyle.Fill;
            dataGridViewUsersData.Location = new Point(80, 0);
            dataGridViewUsersData.Name = "dataGridViewUsersData";
            dataGridViewUsersData.Size = new Size(628, 320);
            dataGridViewUsersData.TabIndex = 3;
            dataGridViewUsersData.CellClick +=  dataGridViewUsersData_CellClick ;
            // 
            // ColumnSelect
            // 
            ColumnSelect.HeaderText = "ColumnSelect";
            ColumnSelect.Name = "ColumnSelect";
            ColumnSelect.Resizable = DataGridViewTriState.True;
            ColumnSelect.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnId
            // 
            ColumnId.FillWeight = 40F;
            ColumnId.HeaderText = " ID";
            ColumnId.Name = "ColumnId";
            ColumnId.Resizable = DataGridViewTriState.True;
            ColumnId.Visible = false;
            ColumnId.Width = 40;
            // 
            // ColumnUserName
            // 
            ColumnUserName.FillWeight = 120F;
            ColumnUserName.HeaderText = "Nome";
            ColumnUserName.Name = "ColumnUserName";
            ColumnUserName.Width = 120;
            // 
            // ColumnEmail
            // 
            ColumnEmail.FillWeight = 190F;
            ColumnEmail.HeaderText = "Email";
            ColumnEmail.Name = "ColumnEmail";
            ColumnEmail.Width = 190;
            // 
            // ColumnFone
            // 
            ColumnFone.FillWeight = 120F;
            ColumnFone.HeaderText = "Contato";
            ColumnFone.Name = "ColumnFone";
            ColumnFone.Width = 120;
            // 
            // ColumnAdmin
            // 
            ColumnAdmin.HeaderText = "Administrador";
            ColumnAdmin.Name = "ColumnAdmin";
            ColumnAdmin.Resizable = DataGridViewTriState.True;
            ColumnAdmin.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnCreatedAt
            // 
            ColumnCreatedAt.HeaderText = "Data Criação";
            ColumnCreatedAt.Name = "ColumnCreatedAt";
            // 
            // ColumnIsActive
            // 
            ColumnIsActive.HeaderText = "IsActive";
            ColumnIsActive.Name = "ColumnIsActive";
            ColumnIsActive.Visible = false;
            // 
            // panelNewUser
            // 
            panelNewUser.Controls.Add(panelNewUserTextBoxes);
            panelNewUser.Dock = DockStyle.Fill;
            panelNewUser.Location = new Point(0, 0);
            panelNewUser.Name = "panelNewUser";
            panelNewUser.Size = new Size(794, 396);
            panelNewUser.TabIndex = 11;
            // 
            // panelNewUserTextBoxes
            // 
            panelNewUserTextBoxes.Controls.Add(labelErrorConfirmPassword);
            panelNewUserTextBoxes.Controls.Add(labelErrorPassword);
            panelNewUserTextBoxes.Controls.Add(labelErrorFone);
            panelNewUserTextBoxes.Controls.Add(labelErrorEmail);
            panelNewUserTextBoxes.Controls.Add(labelErrorName);
            panelNewUserTextBoxes.Controls.Add(textBoxConfirmPassword);
            panelNewUserTextBoxes.Controls.Add(textBoxPassword);
            panelNewUserTextBoxes.Controls.Add(labelPasswordConfirm);
            panelNewUserTextBoxes.Controls.Add(labelPassword);
            panelNewUserTextBoxes.Controls.Add(checkBoxIsAdmin);
            panelNewUserTextBoxes.Controls.Add(buttonCancel);
            panelNewUserTextBoxes.Controls.Add(label2);
            panelNewUserTextBoxes.Controls.Add(textBoxIsAdmin);
            panelNewUserTextBoxes.Controls.Add(label3);
            panelNewUserTextBoxes.Controls.Add(textBoxEditFone);
            panelNewUserTextBoxes.Controls.Add(label4);
            panelNewUserTextBoxes.Controls.Add(textBoxEditEmail);
            panelNewUserTextBoxes.Controls.Add(label5);
            panelNewUserTextBoxes.Controls.Add(textBoxEditName);
            panelNewUserTextBoxes.Controls.Add(buttonSave);
            panelNewUserTextBoxes.Controls.Add(panel1);
            panelNewUserTextBoxes.Location = new Point(203, 1);
            panelNewUserTextBoxes.Margin = new Padding(0);
            panelNewUserTextBoxes.Name = "panelNewUserTextBoxes";
            panelNewUserTextBoxes.Size = new Size(398, 395);
            panelNewUserTextBoxes.TabIndex = 2;
            // 
            // labelErrorConfirmPassword
            // 
            labelErrorConfirmPassword.AutoSize = true;
            labelErrorConfirmPassword.ForeColor = Color.Red;
            labelErrorConfirmPassword.Location = new Point(156, 285);
            labelErrorConfirmPassword.Name = "labelErrorConfirmPassword";
            labelErrorConfirmPassword.Size = new Size(126, 15);
            labelErrorConfirmPassword.TabIndex = 30;
            labelErrorConfirmPassword.Text = "ErrorConfirmPassword";
            // 
            // labelErrorPassword
            // 
            labelErrorPassword.AutoSize = true;
            labelErrorPassword.ForeColor = Color.Red;
            labelErrorPassword.Location = new Point(179, 234);
            labelErrorPassword.Name = "labelErrorPassword";
            labelErrorPassword.Size = new Size(82, 15);
            labelErrorPassword.TabIndex = 29;
            labelErrorPassword.Text = "ErrorPassword";
            // 
            // labelErrorFone
            // 
            labelErrorFone.AutoSize = true;
            labelErrorFone.ForeColor = Color.Red;
            labelErrorFone.Location = new Point(185, 183);
            labelErrorFone.Name = "labelErrorFone";
            labelErrorFone.Size = new Size(58, 15);
            labelErrorFone.TabIndex = 28;
            labelErrorFone.Text = "ErrorFone";
            // 
            // labelErrorEmail
            // 
            labelErrorEmail.AutoSize = true;
            labelErrorEmail.ForeColor = Color.Red;
            labelErrorEmail.Location = new Point(183, 133);
            labelErrorEmail.Name = "labelErrorEmail";
            labelErrorEmail.Size = new Size(61, 15);
            labelErrorEmail.TabIndex = 27;
            labelErrorEmail.Text = "ErrorEmail";
            // 
            // labelErrorName
            // 
            labelErrorName.AutoSize = true;
            labelErrorName.Font = new Font("Segoe UI", 8F);
            labelErrorName.ForeColor = Color.Red;
            labelErrorName.Location = new Point(179, 84);
            labelErrorName.Name = "labelErrorName";
            labelErrorName.Size = new Size(61, 13);
            labelErrorName.TabIndex = 26;
            labelErrorName.Text = "ErrorName";
            labelErrorName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            textBoxConfirmPassword.Location = new Point(134, 259);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new Size(175, 23);
            textBoxConfirmPassword.TabIndex = 25;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            textBoxPassword.Location = new Point(134, 208);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(175, 23);
            textBoxPassword.TabIndex = 24;
            // 
            // labelPasswordConfirm
            // 
            labelPasswordConfirm.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            labelPasswordConfirm.AutoSize = true;
            labelPasswordConfirm.Location = new Point(17, 263);
            labelPasswordConfirm.Name = "labelPasswordConfirm";
            labelPasswordConfirm.Size = new Size(118, 15);
            labelPasswordConfirm.TabIndex = 18;
            labelPasswordConfirm.Text = "Confirme sua senha: ";
            // 
            // labelPassword
            // 
            labelPassword.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(80, 213);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(45, 15);
            labelPassword.TabIndex = 16;
            labelPassword.Text = "Senha: ";
            // 
            // checkBoxIsAdmin
            // 
            checkBoxIsAdmin.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            checkBoxIsAdmin.AutoSize = true;
            checkBoxIsAdmin.Location = new Point(204, 318);
            checkBoxIsAdmin.Name = "checkBoxIsAdmin";
            checkBoxIsAdmin.Size = new Size(15, 14);
            checkBoxIsAdmin.TabIndex = 11;
            checkBoxIsAdmin.UseVisualStyleBackColor = true;
            checkBoxIsAdmin.CheckedChanged +=  checkBoxIsAdmin_CheckedChanged ;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            buttonCancel.BackColor = Color.FromArgb(      255,       67,       67);
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9.75F);
            buttonCancel.ForeColor = SystemColors.Control;
            buttonCancel.Location = new Point(112, 347);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(92, 38);
            buttonCancel.TabIndex = 10;
            buttonCancel.Text = "Cancelar";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click +=  buttonCancel_Click ;
            // 
            // label2
            // 
            label2.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            label2.AutoSize = true;
            label2.Location = new Point(109, 316);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 7;
            label2.Text = "Administrador? ";
            // 
            // textBoxIsAdmin
            // 
            textBoxIsAdmin.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            textBoxIsAdmin.Location = new Point(227, 312);
            textBoxIsAdmin.Name = "textBoxIsAdmin";
            textBoxIsAdmin.ReadOnly = true;
            textBoxIsAdmin.Size = new Size(45, 23);
            textBoxIsAdmin.TabIndex = 6;
            // 
            // label3
            // 
            label3.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            label3.AutoSize = true;
            label3.Location = new Point(78, 163);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 5;
            label3.Text = "Contato: ";
            // 
            // textBoxEditFone
            // 
            textBoxEditFone.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            textBoxEditFone.Location = new Point(134, 157);
            textBoxEditFone.Name = "textBoxEditFone";
            textBoxEditFone.Size = new Size(175, 23);
            textBoxEditFone.TabIndex = 4;
            // 
            // label4
            // 
            label4.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            label4.AutoSize = true;
            label4.Location = new Point(55, 110);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 3;
            label4.Text = "Email: ";
            // 
            // textBoxEditEmail
            // 
            textBoxEditEmail.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            textBoxEditEmail.Location = new Point(100, 107);
            textBoxEditEmail.Name = "textBoxEditEmail";
            textBoxEditEmail.Size = new Size(227, 23);
            textBoxEditEmail.TabIndex = 2;
            // 
            // label5
            // 
            label5.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            label5.AutoSize = true;
            label5.Location = new Point(55, 61);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 1;
            label5.Text = "Nome: ";
            // 
            // textBoxEditName
            // 
            textBoxEditName.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            textBoxEditName.Location = new Point(101, 58);
            textBoxEditName.Name = "textBoxEditName";
            textBoxEditName.Size = new Size(226, 23);
            textBoxEditName.TabIndex = 0;
            // 
            // buttonSave
            // 
            buttonSave.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            buttonSave.BackColor = Color.FromArgb(      0,       122,       204);
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 9.75F);
            buttonSave.ForeColor = SystemColors.Control;
            buttonSave.Location = new Point(210, 347);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(92, 38);
            buttonSave.TabIndex = 13;
            buttonSave.Text = "Salvar";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click +=  buttonSave_Click ;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.Controls.Add(labelInfoNewUser);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(397, 47);
            panel1.TabIndex = 31;
            // 
            // labelInfoNewUser
            // 
            labelInfoNewUser.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left ;
            labelInfoNewUser.AutoSize = true;
            labelInfoNewUser.Location = new Point(65, 17);
            labelInfoNewUser.Name = "labelInfoNewUser";
            labelInfoNewUser.Size = new Size(247, 15);
            labelInfoNewUser.TabIndex = 14;
            labelInfoNewUser.Text = "Digite abaixo as informações do novo usuário";
            // 
            // panelUserData
            // 
            panelUserData.Controls.Add(panelUserDataTextBoxes);
            panelUserData.Dock = DockStyle.Fill;
            panelUserData.Location = new Point(0, 0);
            panelUserData.Name = "panelUserData";
            panelUserData.Size = new Size(794, 396);
            panelUserData.TabIndex = 8;
            // 
            // panelUserDataTextBoxes
            // 
            panelUserDataTextBoxes.Controls.Add(buttonEditMyData);
            panelUserDataTextBoxes.Controls.Add(labelActive);
            panelUserDataTextBoxes.Controls.Add(textBoxActive);
            panelUserDataTextBoxes.Controls.Add(labelIsAdmin);
            panelUserDataTextBoxes.Controls.Add(textBoxAdmin);
            panelUserDataTextBoxes.Controls.Add(labelFone);
            panelUserDataTextBoxes.Controls.Add(textBoxFone);
            panelUserDataTextBoxes.Controls.Add(labelEmail);
            panelUserDataTextBoxes.Controls.Add(textBoxEmail);
            panelUserDataTextBoxes.Controls.Add(labelName);
            panelUserDataTextBoxes.Controls.Add(textBoxName);
            panelUserDataTextBoxes.Location = new Point(203, 1);
            panelUserDataTextBoxes.Margin = new Padding(0);
            panelUserDataTextBoxes.Name = "panelUserDataTextBoxes";
            panelUserDataTextBoxes.Size = new Size(388, 395);
            panelUserDataTextBoxes.TabIndex = 2;
            // 
            // buttonEditMyData
            // 
            buttonEditMyData.Anchor =       AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            buttonEditMyData.Location = new Point(159, 347);
            buttonEditMyData.Name = "buttonEditMyData";
            buttonEditMyData.Size = new Size(92, 36);
            buttonEditMyData.TabIndex = 10;
            buttonEditMyData.Text = "Editar";
            buttonEditMyData.UseVisualStyleBackColor = true;
            buttonEditMyData.Click +=  buttonEditMyData_Click ;
            // 
            // labelActive
            // 
            labelActive.Anchor =       AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            labelActive.AutoSize = true;
            labelActive.Location = new Point(124, 292);
            labelActive.Name = "labelActive";
            labelActive.Size = new Size(87, 15);
            labelActive.TabIndex = 9;
            labelActive.Text = "Usuário ativo?  ";
            // 
            // textBoxActive
            // 
            textBoxActive.Anchor =       AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            textBoxActive.Enabled = false;
            textBoxActive.Location = new Point(214, 286);
            textBoxActive.Name = "textBoxActive";
            textBoxActive.ReadOnly = true;
            textBoxActive.Size = new Size(45, 23);
            textBoxActive.TabIndex = 8;
            // 
            // labelIsAdmin
            // 
            labelIsAdmin.Anchor =       AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            labelIsAdmin.AutoSize = true;
            labelIsAdmin.Location = new Point(121, 230);
            labelIsAdmin.Name = "labelIsAdmin";
            labelIsAdmin.Size = new Size(91, 15);
            labelIsAdmin.TabIndex = 7;
            labelIsAdmin.Text = "Administrador? ";
            // 
            // textBoxAdmin
            // 
            textBoxAdmin.Anchor =       AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            textBoxAdmin.Enabled = false;
            textBoxAdmin.Location = new Point(214, 227);
            textBoxAdmin.Name = "textBoxAdmin";
            textBoxAdmin.ReadOnly = true;
            textBoxAdmin.Size = new Size(45, 23);
            textBoxAdmin.TabIndex = 6;
            // 
            // labelFone
            // 
            labelFone.Anchor =       AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            labelFone.AutoSize = true;
            labelFone.Location = new Point(80, 163);
            labelFone.Name = "labelFone";
            labelFone.Size = new Size(56, 15);
            labelFone.TabIndex = 5;
            labelFone.Text = "Contato: ";
            // 
            // textBoxFone
            // 
            textBoxFone.Anchor =       AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            textBoxFone.Location = new Point(136, 157);
            textBoxFone.Name = "textBoxFone";
            textBoxFone.ReadOnly = true;
            textBoxFone.Size = new Size(175, 23);
            textBoxFone.TabIndex = 4;
            // 
            // labelEmail
            // 
            labelEmail.Anchor =       AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(35, 99);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(42, 15);
            labelEmail.TabIndex = 3;
            labelEmail.Text = "Email: ";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor =       AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            textBoxEmail.Location = new Point(95, 93);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.ReadOnly = true;
            textBoxEmail.Size = new Size(251, 23);
            textBoxEmail.TabIndex = 2;
            // 
            // labelName
            // 
            labelName.Anchor =       AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            labelName.AutoSize = true;
            labelName.Location = new Point(36, 33);
            labelName.Name = "labelName";
            labelName.Size = new Size(46, 15);
            labelName.TabIndex = 1;
            labelName.Text = "Nome: ";
            // 
            // textBoxName
            // 
            textBoxName.Anchor =       AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            textBoxName.Location = new Point(96, 27);
            textBoxName.Name = "textBoxName";
            textBoxName.ReadOnly = true;
            textBoxName.Size = new Size(250, 23);
            textBoxName.TabIndex = 0;
            // 
            // tableLayoutPanelTop
            // 
            tableLayoutPanelTop.ColumnCount = 2;
            tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelTop.Controls.Add(panelBtn2, 1, 0);
            tableLayoutPanelTop.Controls.Add(panelBtn1, 0, 0);
            tableLayoutPanelTop.Dock = DockStyle.Fill;
            tableLayoutPanelTop.Location = new Point(3, 3);
            tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            tableLayoutPanelTop.RowCount = 1;
            tableLayoutPanelTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelTop.Size = new Size(794, 42);
            tableLayoutPanelTop.TabIndex = 2;
            // 
            // panelBtn2
            // 
            panelBtn2.Controls.Add(btnUsers);
            panelBtn2.Dock = DockStyle.Fill;
            panelBtn2.Location = new Point(397, 0);
            panelBtn2.Margin = new Padding(0);
            panelBtn2.Name = "panelBtn2";
            panelBtn2.Size = new Size(397, 42);
            panelBtn2.TabIndex = 6;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = SystemColors.ControlLightLight;
            btnUsers.Dock = DockStyle.Fill;
            btnUsers.Location = new Point(0, 0);
            btnUsers.Margin = new Padding(0);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(397, 42);
            btnUsers.TabIndex = 2;
            btnUsers.Text = "GERENCIAR USUÁRIOS";
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click +=  btnUsers_Click ;
            // 
            // panelBtn1
            // 
            panelBtn1.BackColor = SystemColors.Control;
            panelBtn1.Controls.Add(btnMyData);
            panelBtn1.Dock = DockStyle.Fill;
            panelBtn1.Location = new Point(0, 0);
            panelBtn1.Margin = new Padding(0);
            panelBtn1.Name = "panelBtn1";
            panelBtn1.Size = new Size(397, 42);
            panelBtn1.TabIndex = 4;
            // 
            // btnMyData
            // 
            btnMyData.BackColor = SystemColors.ControlLightLight;
            btnMyData.Dock = DockStyle.Fill;
            btnMyData.Location = new Point(0, 0);
            btnMyData.Name = "btnMyData";
            btnMyData.Size = new Size(397, 42);
            btnMyData.TabIndex = 1;
            btnMyData.Text = "MEUS DADOS";
            btnMyData.UseVisualStyleBackColor = false;
            btnMyData.Click +=  btnMyData_Click ;
            // 
            // FormUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelMain);
            Name = "FormUser";
            Text = "FormUser";
            Resize +=  FormUser_Resize ;
            panelMain.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            panelMainData.ResumeLayout(false);
            panelAllUsersData.ResumeLayout(false);
            tableLayoutPanelUsers.ResumeLayout(false);
            panelDataUsersBotton.ResumeLayout(false);
            flowLayoutPanelButtonsUsers.ResumeLayout(false);
            panelDataUsersTop.ResumeLayout(false);
            flowLayoutPanelTopInfoUsers.ResumeLayout(false);
            flowLayoutPanelTopInfoUsers.PerformLayout();
            panelDataUsersMiddle.ResumeLayout(false);
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewUsersData ).EndInit();
            panelNewUser.ResumeLayout(false);
            panelNewUserTextBoxes.ResumeLayout(false);
            panelNewUserTextBoxes.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelUserData.ResumeLayout(false);
            panelUserDataTextBoxes.ResumeLayout(false);
            panelUserDataTextBoxes.PerformLayout();
            tableLayoutPanelTop.ResumeLayout(false);
            panelBtn2.ResumeLayout(false);
            panelBtn1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private TableLayoutPanel tableLayoutPanel;
        private Panel panelMainData;
        private TableLayoutPanel tableLayoutPanelTop;
        private Panel panelBtn2;
        private Button btnUsers;
        private Panel panelBtn1;
        private Button btnMyData;
        private Panel panelUserData;
        private TableLayoutPanel tableLayoutPanelUsers;
        private Panel panelDataUsersTop;
        private Label labelUsers;
        private Panel panelDataUsersMiddle;
        private DataGridView dataGridViewUsersData;
        private Panel panelDataUsersBotton;
        private FlowLayoutPanel flowLayoutPanelButtonsUsers;
        private Button buttonNewUser;
        private Button buttonEditSelectedUser;
        private Panel panelAllUsersData;
        private Panel panelUserDataTextBoxes;
        private Button buttonEditMyData;
        private Label labelActive;
        private TextBox textBoxActive;
        private Label labelIsAdmin;
        private TextBox textBoxAdmin;
        private Label labelFone;
        private TextBox textBoxFone;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelName;
        private TextBox textBoxName;
        private Panel panelNewUser;
        private Panel panelNewUserTextBoxes;
        private CheckBox checkBoxIsAdmin;
        private Button buttonCancel;
        private Label label2;
        private TextBox textBoxIsAdmin;
        private Label label3;
        private TextBox textBoxEditFone;
        private Label label4;
        private TextBox textBoxEditEmail;
        private Label label5;
        private TextBox textBoxEditName;
        private Button buttonSave;
        private Label labelInfoNewUser;
        private Label labelPasswordConfirm;
        private Label labelPassword;
        private CheckBox checkBoxAllUsers;
        private TextBox textBoxConfirmPassword;
        private TextBox textBoxPassword;
        private Label labelErrorFone;
        private Label labelErrorEmail;
        private Label labelErrorName;
        private Label labelErrorConfirmPassword;
        private Label labelErrorPassword;
        private Button buttonDeleteUser;
        private FlowLayoutPanel flowLayoutPanelTopInfoUsers;
        private DataGridViewCheckBoxColumn ColumnSelect;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnUserName;
        private DataGridViewTextBoxColumn ColumnEmail;
        private DataGridViewTextBoxColumn ColumnFone;
        private DataGridViewTextBoxColumn ColumnAdmin;
        private DataGridViewTextBoxColumn ColumnCreatedAt;
        private DataGridViewTextBoxColumn ColumnIsActive;
        private Panel panel1;
        private Button buttonReactivateUser;
    }
}