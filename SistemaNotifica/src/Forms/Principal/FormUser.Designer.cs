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
            panelNewUser = new Panel();
            panelNewUserTextBoxes = new Panel();
            textBoxConfirmPassword = new TextBox();
            textBoxPassword = new TextBox();
            labelPasswordConfirm = new Label();
            labelPassword = new Label();
            labelInfoNewUser = new Label();
            buttonSave = new Button();
            checkBoxIsAdmin = new CheckBox();
            buttonCancel = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBoxEditFone = new TextBox();
            label4 = new Label();
            textBoxEditEmail = new TextBox();
            label5 = new Label();
            textBoxEditName = new TextBox();
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
            panelAllUsersData = new Panel();
            tableLayoutPanelUsers = new TableLayoutPanel();
            panelDataUsersBotton = new Panel();
            flowLayoutPanelButtonsUsers = new FlowLayoutPanel();
            buttonNewUser = new Button();
            buttonEditSelectedUser = new Button();
            panelDataUsersTop = new Panel();
            checkBoxAllUsers = new CheckBox();
            labelUsers = new Label();
            panelDataUsersMiddle = new Panel();
            dataGridViewUsersData = new DataGridView();
            ColumnId = new DataGridViewCheckBoxColumn();
            ColumnUserName = new DataGridViewTextBoxColumn();
            ColumnEmail = new DataGridViewTextBoxColumn();
            ColumnFone = new DataGridViewTextBoxColumn();
            ColumnAdmin = new DataGridViewTextBoxColumn();
            ColumnCreatedAt = new DataGridViewTextBoxColumn();
            ColumnIsActive = new DataGridViewTextBoxColumn();
            tableLayoutPanelTop = new TableLayoutPanel();
            panelBtn2 = new Panel();
            btnUsers = new Button();
            panelBtn1 = new Panel();
            btnMyData = new Button();
            panelMain.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panelMainData.SuspendLayout();
            panelNewUser.SuspendLayout();
            panelNewUserTextBoxes.SuspendLayout();
            panelUserData.SuspendLayout();
            panelUserDataTextBoxes.SuspendLayout();
            panelAllUsersData.SuspendLayout();
            tableLayoutPanelUsers.SuspendLayout();
            panelDataUsersBotton.SuspendLayout();
            flowLayoutPanelButtonsUsers.SuspendLayout();
            panelDataUsersTop.SuspendLayout();
            panelDataUsersMiddle.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewUsersData ).BeginInit();
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
            panelNewUserTextBoxes.Controls.Add(textBoxConfirmPassword);
            panelNewUserTextBoxes.Controls.Add(textBoxPassword);
            panelNewUserTextBoxes.Controls.Add(labelPasswordConfirm);
            panelNewUserTextBoxes.Controls.Add(labelPassword);
            panelNewUserTextBoxes.Controls.Add(labelInfoNewUser);
            panelNewUserTextBoxes.Controls.Add(buttonSave);
            panelNewUserTextBoxes.Controls.Add(checkBoxIsAdmin);
            panelNewUserTextBoxes.Controls.Add(buttonCancel);
            panelNewUserTextBoxes.Controls.Add(label2);
            panelNewUserTextBoxes.Controls.Add(textBox2);
            panelNewUserTextBoxes.Controls.Add(label3);
            panelNewUserTextBoxes.Controls.Add(textBoxEditFone);
            panelNewUserTextBoxes.Controls.Add(label4);
            panelNewUserTextBoxes.Controls.Add(textBoxEditEmail);
            panelNewUserTextBoxes.Controls.Add(label5);
            panelNewUserTextBoxes.Controls.Add(textBoxEditName);
            panelNewUserTextBoxes.Location = new Point(203, 1);
            panelNewUserTextBoxes.Margin = new Padding(0);
            panelNewUserTextBoxes.Name = "panelNewUserTextBoxes";
            panelNewUserTextBoxes.Size = new Size(398, 395);
            panelNewUserTextBoxes.TabIndex = 2;
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.Location = new Point(141, 257);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new Size(175, 23);
            textBoxConfirmPassword.TabIndex = 25;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(141, 209);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(175, 23);
            textBoxPassword.TabIndex = 24;
            // 
            // labelPasswordConfirm
            // 
            labelPasswordConfirm.Anchor =     AnchorStyles.Top  |  AnchorStyles.Bottom ;
            labelPasswordConfirm.AutoSize = true;
            labelPasswordConfirm.Location = new Point(23, 261);
            labelPasswordConfirm.Name = "labelPasswordConfirm";
            labelPasswordConfirm.Size = new Size(118, 15);
            labelPasswordConfirm.TabIndex = 18;
            labelPasswordConfirm.Text = "Confirme sua senha: ";
            // 
            // labelPassword
            // 
            labelPassword.Anchor =     AnchorStyles.Top  |  AnchorStyles.Bottom ;
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(85, 215);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(45, 15);
            labelPassword.TabIndex = 16;
            labelPassword.Text = "Senha: ";
            // 
            // labelInfoNewUser
            // 
            labelInfoNewUser.AutoSize = true;
            labelInfoNewUser.Location = new Point(80, 24);
            labelInfoNewUser.Name = "labelInfoNewUser";
            labelInfoNewUser.Size = new Size(247, 15);
            labelInfoNewUser.TabIndex = 14;
            labelInfoNewUser.Text = "Digite abaixo as informações do novo usuário";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(      0,       122,       204);
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = SystemColors.Control;
            buttonSave.Location = new Point(210, 350);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(92, 36);
            buttonSave.TabIndex = 13;
            buttonSave.Text = "Salvar";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click +=  buttonSave_Click ;
            // 
            // checkBoxIsAdmin
            // 
            checkBoxIsAdmin.AutoSize = true;
            checkBoxIsAdmin.Location = new Point(204, 305);
            checkBoxIsAdmin.Name = "checkBoxIsAdmin";
            checkBoxIsAdmin.Size = new Size(15, 14);
            checkBoxIsAdmin.TabIndex = 11;
            checkBoxIsAdmin.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.FromArgb(      255,       67,       67);
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.ForeColor = SystemColors.Control;
            buttonCancel.Location = new Point(112, 351);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(92, 36);
            buttonCancel.TabIndex = 10;
            buttonCancel.Text = "Cancelar";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click +=  buttonCancel_Click ;
            // 
            // label2
            // 
            label2.Anchor =     AnchorStyles.Top  |  AnchorStyles.Bottom ;
            label2.AutoSize = true;
            label2.Location = new Point(109, 303);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 7;
            label2.Text = "Administrador? ";
            // 
            // textBox2
            // 
            textBox2.Anchor =     AnchorStyles.Top  |  AnchorStyles.Bottom ;
            textBox2.Location = new Point(227, 299);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(45, 23);
            textBox2.TabIndex = 6;
            // 
            // label3
            // 
            label3.Anchor =     AnchorStyles.Top  |  AnchorStyles.Bottom ;
            label3.AutoSize = true;
            label3.Location = new Point(85, 165);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 5;
            label3.Text = "Contato: ";
            // 
            // textBoxEditFone
            // 
            textBoxEditFone.Anchor =     AnchorStyles.Top  |  AnchorStyles.Bottom ;
            textBoxEditFone.Location = new Point(141, 159);
            textBoxEditFone.Name = "textBoxEditFone";
            textBoxEditFone.Size = new Size(175, 23);
            textBoxEditFone.TabIndex = 4;
            // 
            // label4
            // 
            label4.Anchor =     AnchorStyles.Top  |  AnchorStyles.Bottom ;
            label4.AutoSize = true;
            label4.Location = new Point(40, 119);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 3;
            label4.Text = "Email: ";
            // 
            // textBoxEditEmail
            // 
            textBoxEditEmail.Anchor =     AnchorStyles.Top  |  AnchorStyles.Bottom ;
            textBoxEditEmail.Location = new Point(100, 113);
            textBoxEditEmail.Name = "textBoxEditEmail";
            textBoxEditEmail.Size = new Size(251, 23);
            textBoxEditEmail.TabIndex = 2;
            // 
            // label5
            // 
            label5.Anchor =     AnchorStyles.Top  |  AnchorStyles.Bottom ;
            label5.AutoSize = true;
            label5.Location = new Point(41, 72);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 1;
            label5.Text = "Nome: ";
            // 
            // textBoxEditName
            // 
            textBoxEditName.Anchor =     AnchorStyles.Top  |  AnchorStyles.Bottom ;
            textBoxEditName.Location = new Point(101, 66);
            textBoxEditName.Name = "textBoxEditName";
            textBoxEditName.Size = new Size(250, 23);
            textBoxEditName.TabIndex = 0;
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
            flowLayoutPanelButtonsUsers.Location = new Point(290, -3);
            flowLayoutPanelButtonsUsers.Name = "flowLayoutPanelButtonsUsers";
            flowLayoutPanelButtonsUsers.Size = new Size(245, 44);
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
            buttonEditSelectedUser.Text = "Atualizar Usuário selecionado";
            buttonEditSelectedUser.UseVisualStyleBackColor = true;
            buttonEditSelectedUser.Click +=  buttonEditSelectedUser_Click ;
            // 
            // panelDataUsersTop
            // 
            panelDataUsersTop.Controls.Add(checkBoxAllUsers);
            panelDataUsersTop.Controls.Add(labelUsers);
            panelDataUsersTop.Dock = DockStyle.Fill;
            panelDataUsersTop.Location = new Point(0, 0);
            panelDataUsersTop.Margin = new Padding(0);
            panelDataUsersTop.Name = "panelDataUsersTop";
            panelDataUsersTop.Size = new Size(794, 22);
            panelDataUsersTop.TabIndex = 0;
            // 
            // checkBoxAllUsers
            // 
            checkBoxAllUsers.AutoSize = true;
            checkBoxAllUsers.Location = new Point(361, 3);
            checkBoxAllUsers.Name = "checkBoxAllUsers";
            checkBoxAllUsers.Size = new Size(251, 19);
            checkBoxAllUsers.TabIndex = 1;
            checkBoxAllUsers.Text = "Mostrar usuários Deletados ou desativados";
            checkBoxAllUsers.UseVisualStyleBackColor = true;
            checkBoxAllUsers.CheckedChanged +=  checkBoxAllUsers_CheckedChanged ;
            // 
            // labelUsers
            // 
            labelUsers.AutoSize = true;
            labelUsers.Location = new Point(196, 4);
            labelUsers.Name = "labelUsers";
            labelUsers.Size = new Size(151, 15);
            labelUsers.TabIndex = 0;
            labelUsers.Text = "USUÁRIOS CADASTRADOS:";
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
            dataGridViewUsersData.Columns.AddRange(new DataGridViewColumn[] { ColumnId, ColumnUserName, ColumnEmail, ColumnFone, ColumnAdmin, ColumnCreatedAt, ColumnIsActive });
            dataGridViewUsersData.Dock = DockStyle.Fill;
            dataGridViewUsersData.Location = new Point(80, 0);
            dataGridViewUsersData.Name = "dataGridViewUsersData";
            dataGridViewUsersData.Size = new Size(628, 320);
            dataGridViewUsersData.TabIndex = 3;
            // 
            // ColumnId
            // 
            ColumnId.FillWeight = 40F;
            ColumnId.HeaderText = " ID";
            ColumnId.Name = "ColumnId";
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
            panelNewUser.ResumeLayout(false);
            panelNewUserTextBoxes.ResumeLayout(false);
            panelNewUserTextBoxes.PerformLayout();
            panelUserData.ResumeLayout(false);
            panelUserDataTextBoxes.ResumeLayout(false);
            panelUserDataTextBoxes.PerformLayout();
            panelAllUsersData.ResumeLayout(false);
            tableLayoutPanelUsers.ResumeLayout(false);
            panelDataUsersBotton.ResumeLayout(false);
            flowLayoutPanelButtonsUsers.ResumeLayout(false);
            panelDataUsersTop.ResumeLayout(false);
            panelDataUsersTop.PerformLayout();
            panelDataUsersMiddle.ResumeLayout(false);
            ( ( System.ComponentModel.ISupportInitialize ) dataGridViewUsersData ).EndInit();
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
        private TextBox textBox2;
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
        private DataGridViewCheckBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnUserName;
        private DataGridViewTextBoxColumn ColumnEmail;
        private DataGridViewTextBoxColumn ColumnFone;
        private DataGridViewTextBoxColumn ColumnAdmin;
        private DataGridViewTextBoxColumn ColumnCreatedAt;
        private DataGridViewTextBoxColumn ColumnIsActive;
        private TextBox textBoxConfirmPassword;
        private TextBox textBoxPassword;
    }
}