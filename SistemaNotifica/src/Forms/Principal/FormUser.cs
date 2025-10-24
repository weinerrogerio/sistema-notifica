using Newtonsoft.Json.Linq;
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SistemaNotifica.src.Models.User;

// PANEL DAS TELAS:
// panelUserData --> Dados do Usuário (meus dados)
// panelAllUsersData --> Dados de todos os Usuários (gerenciar usuários) - SOMENTE ADMIN
// panelNewUser --> campos para novo user

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormUser : Form
    {

        private JArray dados = [];

        private readonly bool _isAdmin;
        private readonly bool _isViewingOwnProfile;

        private bool _isEditMode = false;
        private int? _userIdBeingEdited = null;
        private int _lastSelectedRowIndex = -1;

        private readonly UserService _userService;

        public FormUser()
        {
            InitializeComponent();
            // Verifica autenticação ANTES de qualquer configuração
            if ( !Session.IsAutenticated() )
            {
                MessageBox.Show(
                    "Você precisa estar autenticado para acessar esta área.",
                    "Acesso Negado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                this.Close();
                Application.Run(new FormLogin());
                return;
            }
            _userService = Program.UserService;
            _isAdmin = Session.IsAdmin();

            checkBoxAllUsers.Checked = false;

            ConfigDataGridView();
            ConfigurarAcessoPorRole();
            CarregarDadosUsuario();
            CentralizeAllElements();
            //CentralizarTodosLabelsErro();
            LimparErros();
            SendPanelsToBack();

            _ = LoadDataToGridAsync();
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("========== FORMUSER CARREGADO ==========");
            Debug.WriteLine(Session.GetInfoSession());
            Debug.WriteLine($"É Admin: {_isAdmin}");
            Debug.WriteLine("========================================");
        }

        private void SendPanelsToBack()
        {
            panelNewUser.SendToBack();
            panelAllUsersData.SendToBack();
            panelUserData.BringToFront();
        }

        private void FormUser_Resize(object sender, EventArgs e)
        {
            CentralizeAllElements();
        }

        /// Configura a visibilidade e habilitação dos controles baseado no role do usuário
        private void ConfigurarAcessoPorRole()
        {
            if ( _isAdmin )
            {
                // Administrador vê TUDO
                panelBtn2.Visible = true;
                panelBtn2.Enabled = true;
                btnUsers.Visible = true;
                btnUsers.Enabled = true;

                // Admin pode ver o grid de todos os usuários
                panelAllUsersData.Visible = true;

                Debug.WriteLine("Acesso configurado: ADMINISTRADOR (acesso total)");
            }
            else
            {
                // Usuário comum NÃO TEM ACESSO ao grid de usuários
                panelBtn2.Visible = false;
                panelBtn2.Enabled = false;
                btnUsers.Visible = false;
                btnUsers.Enabled = false;

                // Remove o painel do layout se ele estiver lá
                if ( tableLayoutPanelTop.Controls.Contains(panelBtn2) )
                {
                    tableLayoutPanelTop.Controls.Remove(panelBtn2);
                }

                // Esconde o grid de todos os usuários
                panelAllUsersData.Visible = false;

                // Garante que usuário comum só vê seus próprios dados
                panelUserData.Visible = true;

                Debug.WriteLine("Acesso configurado: USUÁRIO COMUM (somente próprios dados)");
            }
        }

        // --------------------------- Carrega os dados do usuário logado nos campos do formulário ------------------
        private void CarregarDadosUsuario()
        {
            try
            {
                // ✅ Preenche os campos com os dados da sessão
                if ( textBoxName != null )
                    textBoxName.Text = Session.UsuarioLogado ?? "";

                if ( textBoxEmail != null )
                    textBoxEmail.Text = Session.Email ?? "";

                if ( textBoxAdmin != null )
                    textBoxAdmin.Text = _isAdmin ? "Sim" : "Não";

                if ( textBoxActive != null )
                    textBoxActive.Text = "Ativo";

                // Campos que usuário comum NÃO deve editar
                if ( !_isAdmin )
                {
                    if ( textBoxAdmin != null )
                        textBoxAdmin.Enabled = false;

                    if ( textBoxActive != null )
                        textBoxActive.Enabled = false;
                }

                Debug.WriteLine($"Dados carregados para o usuário: {Session.UsuarioLogado}");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao carregar dados do usuário: {ex.Message}");
                MessageBox.Show(
                    "Erro ao carregar dados do usuário.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void ConfigDataGridView()
        {
            dataGridViewUsersData.Rows.Clear();
            dataGridViewUsersData.RowHeadersVisible = false;
            dataGridViewUsersData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsersData.AllowUserToAddRows = false;
            dataGridViewUsersData.MultiSelect = false;
            dataGridViewUsersData.ReadOnly = false;
            dataGridViewUsersData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewUsersData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsersData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewUsersData.AllowUserToOrderColumns = false;
            dataGridViewUsersData.AllowUserToResizeRows = false;
        }

        private void UnselectAllRows()
        {
            foreach ( DataGridViewRow row in dataGridViewUsersData.Rows )
            {
                row.Selected = false;
                row.Cells["ColumnSelect"].Value = false;
            }
        }

        private void CentralizeAllElements()
        {
            CentralizeElement(panelDataUsersTop, labelUsers);
            CentralizeElement(panelDataUsersBotton, flowLayoutPanelButtonsUsers);
            CentralizeElement(panelUserData, panelUserDataTextBoxes);
            CentralizeElement(panelAllUsersData, panelNewUserTextBoxes);
            CentralizeElement(panelDataUsersTop, flowLayoutPanelTopInfoUsers);
            CentralizeElement(panelFilters, flowLayoutPanelFilters);
            CentralizarTodosLabelsErro();
        }

        private void CentralizeElement(Control parentPanel, Control controlToCenter)
        {
            if ( parentPanel == null || controlToCenter == null ) return;

            int x = ( parentPanel.Width - controlToCenter.Width ) / 2;
            int y = ( parentPanel.Height - controlToCenter.Height ) / 2;
            controlToCenter.Location = new Point(x, y);
        }

        private void CentralizeTwoElementsHorizontally(Control parentPanel, Control leftControl, Control rightControl, int spacing)
        {
            if ( parentPanel == null || leftControl == null || rightControl == null ) return;

            int totalWidth = leftControl.Width + spacing + rightControl.Width;
            int startX = ( parentPanel.Width - totalWidth ) / 2;
            int centerY = ( parentPanel.Height - Math.Max(leftControl.Height, rightControl.Height) ) / 2;

            leftControl.Location = new Point(startX, centerY);
            rightControl.Location = new Point(startX + leftControl.Width + spacing, centerY);
        }
        // ------------------------------- FUNÇOES PARA EDIÇÃO DE DADOS ------------------------------------

        private void CarregarMeusDadosParaEdicao()
        {
            try
            {
                LimparFormulario();

                _isEditMode = true;
                _userIdBeingEdited = Session.UserId; // Define ID do usuário logado

                // Carrega dados da Session
                textBoxEditName.Text = Session.UsuarioLogado ?? "";
                textBoxEditEmail.Text = Session.Email ?? "";
                textBoxEditFone.Text = ""; // Não disponível na Session - ARRUMAR DEPOIS

                textBoxPassword.Text = "";
                textBoxConfirmPassword.Text = "";

                bool isAdmin = Session.IsAdmin();
                checkBoxIsAdmin.Checked = isAdmin;
                textBoxIsAdmin.Text = isAdmin ? "SIM" : "NÃO";


                //labelInfoNewUser.Text = "Edite seus dados:";
                //labelInfoNewUser.Font = new Font(labelInfoNewUser.Font, FontStyle.Bold);
                //CentralizeElement(panelNewUserTextBoxes, labelInfoNewUser);
                PersonalizeLabelUser("Edite seus dados:");

                Debug.WriteLine($"Carregados dados do usuário logado para edição: {Session.UsuarioLogado}");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao carregar dados para edição: {ex.Message}");
                MessageBox.Show(
                    "Erro ao carregar dados para edição.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void CarregarUsuarioDoGridParaEdicao(DataGridViewRow row)
        {
            try
            {
                if ( row == null ) return;

                LimparFormulario();

                _isEditMode = true;
                _userIdBeingEdited = Convert.ToInt32(row.Cells["ColumnId"].Value); // ✅ ID do grid

                // Carrega dados do grid
                textBoxEditName.Text = row.Cells["ColumnUserName"].Value?.ToString() ?? "";
                textBoxEditEmail.Text = row.Cells["ColumnEmail"].Value?.ToString() ?? "";
                textBoxEditFone.Text = row.Cells["ColumnFone"].Value?.ToString() ?? "";

                // Senha fica vazia
                textBoxPassword.Text = "";
                textBoxConfirmPassword.Text = "";

                // Define se é admin
                string role = row.Cells["ColumnAdmin"].Value?.ToString() ?? "user";
                bool isAdmin = role.Equals("admin", StringComparison.OrdinalIgnoreCase);
                checkBoxIsAdmin.Checked = isAdmin;
                textBoxIsAdmin.Text = isAdmin ? "SIM" : "NÃO";



                //labelInfoNewUser.Text = "Edite os dados do usuário:";
                PersonalizeLabelUser("Edite os dados do usuário:");

                Debug.WriteLine($"Carregados dados do usuário ID {_userIdBeingEdited} do grid para edição");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao carregar dados do grid: {ex.Message}");
                MessageBox.Show(
                    "Erro ao carregar dados do usuário.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void PersonalizeLabelUser(string text)
        {
            labelInfoNewUser.Text = text;
            labelInfoNewUser.Font = new Font(labelInfoNewUser.Font, FontStyle.Bold);
            CentralizeElement(panel1, labelInfoNewUser);
        }


        // -------------------------------------------------------------------------------------------------

        private void btnMyData_Click(object sender, EventArgs e)
        {
            SendPanelsToBack();
        }

        // -------------------------------- AÇOES DE USUARIO COMUM E ADMIN --------------------------------
        private void buttonEditMyData_Click(object sender, EventArgs e)
        {
            CarregarMeusDadosParaEdicao();
            panelUserData.SendToBack();
            panelAllUsersData.SendToBack();
            panelNewUser.BringToFront();
            buttonSave.Text = "Atualizar Cadastro";
            buttonSave.Font = new Font(buttonSave.Font.FontFamily, 8F);
            //CentralizeElement(panelNewUserTextBoxes, labelInfoNewUser);
        }

        // -------------------------------- AÇOES DE ADMINISTRADOR --------------------------------
        private void btnUsers_Click(object sender, EventArgs e)
        {
            panelNewUser.SendToBack();
            panelUserData.SendToBack();
            panelAllUsersData.BringToFront();
            textBoxIsAdmin.Text = "NÃO";
            UnselectAllRows();
        }

        private void checkBoxAllUsers_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private async Task GetUserDataAsync()
        {
            if ( _isAdmin )
            {
                try
                {
                    dados = await _userService.GetUsersAsync();
                    Debug.WriteLine($"Carregando dados de todos os usuários: {dados}");
                }
                catch ( Exception ex )
                {
                    MessageBox.Show(
                        $"Erro ao carregar usuários: {ex.Message}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    dados = new JArray();
                }
            }
        }

        private async Task LoadDataToGridAsync()
        {
            if ( _isAdmin )
            {
                // Mostra loading (opcional)
                //dataGridViewUsersData.Enabled = false;
                Cursor = Cursors.WaitCursor;

                await GetUserDataAsync();
                ApplyFilters();

                // Remove loading
                dataGridViewUsersData.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        // --------------------------------- FILTROS --------------------------------
        private JArray FilterData(JArray data)
        {
            if ( data == null || data.Count == 0 )
                return new JArray();

            JArray resultado = new JArray();

            // ✅ Obter valores dos filtros
            string userFilter = textBoxUserFilter.Text.Trim();
            string emailFilter = textBoxEmailFilter.Text.Trim();

            bool hasUserFilter = !string.IsNullOrWhiteSpace(userFilter);
            bool hasEmailFilter = !string.IsNullOrWhiteSpace(emailFilter);

            foreach ( JObject item in data )
            {
                bool isActive = item["is_active"]?.Value<bool>() ?? false;

                // ✅ FILTRO 1: Status Ativo/Inativo (checkbox)
                bool passaFiltroStatus = false;

                if ( !checkBoxAllUsers.Checked )
                {
                    // Checkbox DESMARCADO: mostra apenas usuários ATIVOS
                    passaFiltroStatus = isActive;
                }
                else
                {
                    // Checkbox MARCADO: mostra TODOS os usuários
                    passaFiltroStatus = true;
                }

                // Se não passa no filtro de status, pula para o próximo
                if ( !passaFiltroStatus )
                    continue;

                // ✅ FILTRO 2: Nome de Usuário
                bool passaFiltroNome = true;
                if ( hasUserFilter )
                {
                    string nome = item["nome"]?.ToString() ?? "";
                    passaFiltroNome = nome.IndexOf(userFilter, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                // Se não passa no filtro de nome, pula para o próximo
                if ( !passaFiltroNome )
                    continue;

                // ✅ FILTRO 3: Email
                bool passaFiltroEmail = true;
                if ( hasEmailFilter )
                {
                    string email = item["email"]?.ToString() ?? "";
                    passaFiltroEmail = email.IndexOf(emailFilter, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                // Se não passa no filtro de email, pula para o próximo
                if ( !passaFiltroEmail )
                    continue;
                resultado.Add(item);
            }
            return resultado;
        }

        private void ApplyFilters()
        {
            dataGridViewUsersData.Rows.Clear();

            JArray dadosFiltrados = FilterData(dados);

            if ( dadosFiltrados.Count == 0 )
            {
                Debug.WriteLine("Nenhum dado para exibir após filtragem");
                return;
            }

            foreach ( JObject item in dadosFiltrados )
            {
                AddItemToGrid(item);
            }

            if ( dataGridViewUsersData.Rows.Count > 0 )
            {
                dataGridViewUsersData.Rows[0].Selected = false;
                dataGridViewUsersData.ClearSelection();
            }
            ConfigurarColunas();
            Debug.WriteLine($"Total de linhas adicionadas: {dataGridViewUsersData.Rows.Count}");
        }

        private void textBoxEmailFilter_TextChanged(object sender, EventArgs e)
        {
            // Para o timer se estiver rodando
            _filterTimer.Stop();

            // Reinicia o timer
            _filterTimer.Start();

            TextBox textBox = sender as TextBox;
            Debug.WriteLine($"Texto digitado: {textBox.Text}");
        }

        private void textBoxUserFilter_TextChanged(object sender, EventArgs e)
        {
            // Para o timer se estiver rodando
            _filterTimer.Stop();

            // Reinicia o timer
            _filterTimer.Start();

            TextBox textBox = sender as TextBox;
            Debug.WriteLine($"Texto digitado: {textBox.Text}");
        }

        private void _filterTimer_Tick(object sender, EventArgs e)
        {
            _filterTimer.Stop();
            Debug.WriteLine($"[FILTRO] Aplicando filtros - Nome: '{textBoxUserFilter.Text}' | Email: '{textBoxEmailFilter.Text}'");
            ApplyFilters();
        }

        private void buttonClearTextBoxes_Click(object sender, EventArgs e)
        {
            textBoxUserFilter.Clear();
            textBoxEmailFilter.Clear();
            checkBoxAllUsers.Checked = false;
        }

        private void ConfigurarPlaceholdersForFilters()
        {
            // Se você estiver usando TextBoxes normais, pode fazer assim:

            textBoxUserFilter.ForeColor = Color.Gray;
            textBoxUserFilter.Text = "Buscar por nome...";
            textBoxUserFilter.Enter += (s, e) =>
            {
                if ( textBoxUserFilter.Text == "Buscar por nome..." )
                {
                    textBoxUserFilter.Text = "";
                    textBoxUserFilter.ForeColor = Color.Black;
                }
            };
            textBoxUserFilter.Leave += (s, e) =>
            {
                if ( string.IsNullOrWhiteSpace(textBoxUserFilter.Text) )
                {
                    textBoxUserFilter.Text = "Buscar por nome...";
                    textBoxUserFilter.ForeColor = Color.Gray;
                }
            };

            textBoxEmailFilter.ForeColor = Color.Gray;
            textBoxEmailFilter.Text = "Buscar por email...";
            textBoxEmailFilter.Enter += (s, e) =>
            {
                if ( textBoxEmailFilter.Text == "Buscar por email..." )
                {
                    textBoxEmailFilter.Text = "";
                    textBoxEmailFilter.ForeColor = Color.Black;
                }
            };
            textBoxEmailFilter.Leave += (s, e) =>
            {
                if ( string.IsNullOrWhiteSpace(textBoxEmailFilter.Text) )
                {
                    textBoxEmailFilter.Text = "Buscar por email...";
                    textBoxEmailFilter.ForeColor = Color.Gray;
                }
            };
        }

        // -------------------------------------------------------------------------------------------------

        private void ConfigurarColunas()
        {
            // Tornar todas as colunas ReadOnly exceto a de checkbox
            foreach ( DataGridViewColumn column in dataGridViewUsersData.Columns )
            {
                if ( column.Name == "ColumnSelect" )
                {
                    column.ReadOnly = false; // Permitir edição do checkbox
                }
                else
                {
                    column.ReadOnly = true; // Bloquear edição das outras colunas
                }
            }
        }

        private void AddItemToGrid(JObject item)
        {
            try
            {
                int rowIndex = dataGridViewUsersData.Rows.Add();
                DataGridViewRow row = dataGridViewUsersData.Rows[rowIndex];


                row.Cells["ColumnSelect"].Value = false;

                // Preenche as células
                row.Cells["ColumnId"].Value = item["id"]?.Value<int>();
                row.Cells["ColumnUserName"].Value = item["nome"]?.Value<string>();
                row.Cells["ColumnEmail"].Value = item["email"]?.Value<string>();
                row.Cells["ColumnFone"].Value = item["contato"]?.Value<string>();
                row.Cells["ColumnAdmin"].Value = item["role"]?.Value<string>();

                bool isActive = item["is_active"]?.Value<bool>() ?? false;
                row.Cells["ColumnIsActive"].Value = isActive;

                // Formata datas
                DateTime? createdAt = item["createdAt"]?.Value<DateTime>();
                row.Cells["ColumnCreatedAt"].Value = createdAt?.ToString("dd/MM/yyyy");

                // ✅ Opcional: Destacar usuários inativos visualmente
                if ( !isActive )
                {
                    row.DefaultCellStyle.ForeColor = Color.IndianRed;
                    row.DefaultCellStyle.Font = new Font(dataGridViewUsersData.Font, FontStyle.Italic);
                }
                // Armazena o objeto completo na Tag
                row.Tag = item;
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao adicionar item ao grid: {ex.Message}");
                MessageBox.Show(
                    $"Erro ao adicionar usuário: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ---------------------------  BOTÃO DE NOVO USER -----------------------------------
        private void buttonNewUser_Click(object sender, EventArgs e)
        {
            PersonalizeLabelUser("Insira abaixo os dados do novo usuário:");
            buttonSave.Text = "Salvar";
            buttonSave.Font = new Font(buttonSave.Font.FontFamily, 9.75F);
            panelUserData.SendToBack();
            panelAllUsersData.SendToBack();
            panelNewUser.BringToFront();
        }

        // ---------------------------  BOTÃO DE EDIÇÃO USER DO GRID ---------------------------   
        private void buttonEditSelectedUser_Click(object sender, EventArgs e)
        {
            // Verifica se há linha selecionada no grid
            if ( dataGridViewUsersData.SelectedRows.Count == 0 )
            {
                MessageBox.Show(
                    "Selecione um usuário na tabela para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if ( dataGridViewUsersData.SelectedRows.Count > 1 )
            {
                MessageBox.Show(
                    "Selecione apenas um usuário para editar.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Obtém a linha selecionada
            DataGridViewRow selectedRow = dataGridViewUsersData.SelectedRows[0];

            // Carrega dados do grid
            CarregarUsuarioDoGridParaEdicao(selectedRow);

            // Muda para tela de edição
            panelUserData.SendToBack();
            panelAllUsersData.SendToBack();
            panelNewUser.BringToFront();


            //labelInfoNewUser.Text = "Edite abaixo os dados do usuário:";
            PersonalizeLabelUser("Edite abaixo os dados do usuário:");
            buttonSave.Text = "Atualizar Cadastro";
            buttonSave.Font = new Font(buttonSave.Font.FontFamily, 8F);
            panelUserData.SendToBack();
            panelAllUsersData.SendToBack();
            panelNewUser.BringToFront();

        }

        // ---------------------------  BOTÃO DE SALVAR NOVO USER  --------------------------------
        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if ( !ValidaCamposNovoUsuario() ) return;

            if ( buttonSave.Text == "Atualizar Cadastro" )
            {
                Debug.WriteLine($"ID do usuário sendo editado: {_userIdBeingEdited}");
                if ( _userIdBeingEdited == null )
                {
                    MessageBox.Show(
                        "Erro: ID do usuário não encontrado.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                try
                {
                    // ✅ Criar objeto com apenas campos preenchidos
                    var updateUserDto = new UpdateUserDto();

                    // ✅ Só adiciona se campo não estiver vazio
                    if ( !string.IsNullOrWhiteSpace(textBoxEditName.Text) )
                    {
                        updateUserDto.nome = textBoxEditName.Text.Trim();
                    }

                    if ( !string.IsNullOrWhiteSpace(textBoxEditEmail.Text) )
                    {
                        updateUserDto.email = textBoxEditEmail.Text.Trim();
                    }

                    if ( !string.IsNullOrWhiteSpace(textBoxEditFone.Text) )
                    {
                        updateUserDto.contato = textBoxEditFone.Text.Trim();
                    }

                    // ✅ Senha: só envia se foi preenchida
                    if ( !string.IsNullOrWhiteSpace(textBoxPassword.Text) )
                    {
                        updateUserDto.password = textBoxPassword.Text.Trim();
                    }

                    // ✅ Role: só envia se for admin editando
                    if ( _isAdmin )
                    {
                        updateUserDto.role = checkBoxIsAdmin.Checked ? "admin" : "user";
                    }
                    // Desabilitar botão
                    buttonSave.Enabled = false;
                    buttonCancel.Enabled = false;

                    // Enviar requisição
                    var response = await _userService.PatchUserAsync(_userIdBeingEdited.Value, updateUserDto);

                    MessageBox.Show(
                        "Usuário atualizado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // ✅ Se atualizou o próprio usuário, atualiza a Session
                    if ( _userIdBeingEdited == Session.UserId )
                    {
                        Session.UsuarioLogado = updateUserDto.nome;
                        Debug.WriteLine($"Session atualizada com novo nome: {Session.UsuarioLogado}");
                    }

                    // Limpar formulário
                    LimparFormulario();
                    _isEditMode = false;
                    _userIdBeingEdited = null;

                    // Recarregar grid
                    await LoadDataToGridAsync();

                    // Voltar para tela apropriada
                    if ( _isAdmin )
                    {
                        btnUsers_Click(sender, e);
                    }
                    else
                    {
                        btnMyData_Click(sender, e);
                        // Recarrega os dados na tela "Meus Dados"
                        CarregarDadosUsuario();
                    }
                }
                catch ( Exception ex )
                {
                    MessageBox.Show(
                        $"Erro ao atualizar usuário: {ex.Message}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                finally
                {
                    buttonSave.Enabled = true;
                    buttonCancel.Enabled = true;
                    buttonSave.Text = "Atualizar Cadastro";
                    buttonSave.Font = new Font(buttonSave.Font.FontFamily, 8F);

                }
            }
            else if ( buttonSave.Text == "Salvar" )
            {
                try
                {

                    var createUserDto = new CreateUserDto
                    {
                        nome = textBoxEditName.Text.Trim(),
                        email = textBoxEditEmail.Text.Trim(),
                        contato = textBoxEditFone.Text.Trim(),
                        password = textBoxPassword.Text,
                        role = checkBoxIsAdmin.Checked ? "admin" : "user"
                    };

                    // Desabilitar botão para evitar cliques múltiplos
                    buttonSave.Enabled = false;
                    buttonCancel.Enabled = false;
                    buttonSave.Text = "Salvando...";
                    buttonSave.Font = new Font(buttonSave.Font.FontFamily, 9F);

                    // Enviar requisição
                    var response = await _userService.PostUserAsync(createUserDto);

                    MessageBox.Show(
                        "Usuário criado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Limpar formulário
                    LimparFormulario();

                    // Recarregar dados na grid
                    await LoadDataToGridAsync();
                }
                catch ( Exception ex )
                {
                    MessageBox.Show(
                        $"Erro ao criar usuário: {ex.Message}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                finally
                {
                    // Reabilitar botão
                    buttonSave.Enabled = true;
                    buttonCancel.Enabled = true;
                    buttonSave.Text = "Salvar";
                    buttonSave.Font = new Font(buttonSave.Font.FontFamily, 9.75F);
                }
            }
        }

        // ---------------------------  BOTÃO DELETAR USER - DESATIVA NÃO DELETA ---------------------------
        private async void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"ID do usuário sendo EXCLUIDO: {_userIdBeingEdited}");
            if ( _userIdBeingEdited == null )
            {
                MessageBox.Show(
                    "Erro: ID do usuário não encontrado.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            var result = MessageBox.Show(
                "Tem certeza que deseja **excluir** o usuário selecionado?\n\n" +
                "• Esta operação pode ser revertida posteriormente através da opção 'Reativar Cadastro'",
                "Confirmar Exclusão?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if ( result == DialogResult.Yes )
            {
                try
                {
                    // Desabilitar botão durante operação
                    buttonDeleteUser.Enabled = false;

                    await _userService.DeleteUserAsync(_userIdBeingEdited.Value);

                    MessageBox.Show(
                        "Usuário desativado com sucesso!\n\n" +
                        "O usuário pode ser reativado no menu de Gerenciamento de Usuários.",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Recarregar dados
                    await LoadDataToGridAsync();
                    LimparFormulario();
                    btnUsers_Click(sender, e);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show(
                        $"Erro ao desativar usuário: {ex.Message}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                finally
                {
                    buttonDeleteUser.Enabled = true;
                }
            }
        }

        // ---------------------------------------  BOTÃO REATIVAR USER -------------------------------
        private async void buttonReactivateUser_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"ID do usuário sendo REATIVADO: {_userIdBeingEdited}");

            if ( _userIdBeingEdited == null )
            {
                MessageBox.Show(
                    "Erro: ID do usuário não encontrado.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            var result = MessageBox.Show(
                "Tem certeza que deseja reativar o usuário selecionado?\n\n" +
                "• O usuário poderá fazer login novamente após a reativação",
                "Confirmar Reativação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if ( result == DialogResult.Yes )
            {
                try
                {
                    // Desabilitar botão durante operação
                    buttonReactivateUser.Enabled = false;

                    await _userService.ReactivateUserAsync(_userIdBeingEdited.Value);

                    MessageBox.Show(
                        "Usuário reativado com sucesso!\n\n" +
                        "O usuário já pode fazer login no sistema.",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Recarregar dados
                    await LoadDataToGridAsync();
                    LimparFormulario();
                    btnUsers_Click(sender, e);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show(
                        $"Erro ao reativar usuário: {ex.Message}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                finally
                {
                    buttonReactivateUser.Enabled = true;
                }
            }
        }
        // --------------------------------------------------------------------------------------------------

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            // TODO --> reafazer a busca e atualizar os dados no grid - APENAS ADMIN
        }


        // Método auxiliar para limpar o formulário
        private void LimparFormulario()
        {
            textBoxEditName.Clear();
            textBoxEditEmail.Clear();
            textBoxEditFone.Clear();
            textBoxPassword.Clear();
            textBoxConfirmPassword.Clear();
            checkBoxIsAdmin.Checked = false;

            // Reabilitar campos
            textBoxEditEmail.ReadOnly = false;
            textBoxEditFone.ReadOnly = false;
            checkBoxIsAdmin.Enabled = true;

            // Resetar estado de edição
            _isEditMode = false;
            _userIdBeingEdited = null;

            LimparErros();
        }

        private void LimparErros()
        {
            labelErrorName.Visible = false;
            labelErrorEmail.Visible = false;
            labelErrorFone.Visible = false;
            labelErrorPassword.Visible = false;
            labelErrorConfirmPassword.Visible = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // 1. Limpa o formulário de Novo/Edição
            LimparFormulario();

            // 2. Define o painel de destino com base no papel do usuário
            // O painel ativo (panelNewUser) será enviado para trás pelo método de destino.
            if ( _isAdmin )
            {
                // Se for Admin, retorna para a tela de Gerenciar Usuários
                // Isso simula o clique no btnUsers, que traz o panelAllUsersData para frente.
                btnUsers_Click(sender, e);
                UnselectAllRows();
            }
            else
            {
                // Se for Usuário Comum, retorna para a tela de Meus Dados               
                btnMyData_Click(sender, e);
                UnselectAllRows();
            }
        }



        // ---------------------------------------------- CONFIGURAÇÕES DE LABELS ERRORS ----------------------------------------
        private void CentralizarLabelErro(TextBox textBox, Label errorLabel, int verticalSpacing = 2)
        {
            if ( textBox == null || errorLabel == null ) return;

            // Calcula a posição X para centralizar o label em relação ao TextBox
            int centeredX = textBox.Left + ( textBox.Width - errorLabel.Width ) / 2;

            // Posiciona o label abaixo do TextBox
            int posY = textBox.Bottom + verticalSpacing;

            errorLabel.Location = new Point(centeredX, posY);
        }

        private void AtualizarLabelErro(TextBox textBox, Label errorLabel, string mensagem, int verticalSpacing = 2)
        {
            if ( errorLabel == null ) return;

            errorLabel.Text = mensagem;

            // Força o recálculo do tamanho do label baseado no novo texto
            errorLabel.AutoSize = true;

            // Aguarda o layout ser processado
            errorLabel.Refresh();

            // Centraliza o label
            CentralizarLabelErro(textBox, errorLabel, verticalSpacing);
        }

        private void CentralizarTodosLabelsErro()
        {
            // Labels de erro do formulário de novo usuário
            CentralizarLabelErro(textBoxEditName, labelErrorName);
            CentralizarLabelErro(textBoxEditEmail, labelErrorEmail);
            CentralizarLabelErro(textBoxEditFone, labelErrorFone);
            CentralizarLabelErro(textBoxPassword, labelErrorPassword);
            CentralizarLabelErro(textBoxConfirmPassword, labelErrorConfirmPassword);
        }

        private bool ValidarCampoNome()
        {
            if ( string.IsNullOrWhiteSpace(textBoxEditName.Text) )
            {
                AtualizarLabelErro(textBoxEditName, labelErrorName, "O nome é obrigatório");
                labelErrorName.Visible = true;
                return false;
            }

            labelErrorName.Visible = false;
            return true;
        }

        private bool ValidarCampoEmail()
        {
            if ( string.IsNullOrWhiteSpace(textBoxEditEmail.Text) )
            {
                AtualizarLabelErro(textBoxEditEmail, labelErrorEmail, "O email é obrigatório");
                labelErrorEmail.Visible = true;
                return false;
            }

            // Validação básica de formato
            if ( !textBoxEditEmail.Text.Contains("@") )
            {
                AtualizarLabelErro(textBoxEditEmail, labelErrorEmail, "Email inválido");
                labelErrorEmail.Visible = true;
                return false;
            }

            labelErrorEmail.Visible = false;
            return true;
        }

        private bool ValidarCampoSenha()
        {
            if ( string.IsNullOrWhiteSpace(textBoxPassword.Text) )
            {
                AtualizarLabelErro(textBoxPassword, labelErrorPassword, "A senha é obrigatória");
                labelErrorPassword.Visible = true;
                return false;
            }

            if ( textBoxPassword.Text.Length < 4 || textBoxPassword.Text.Length > 20 )
            {
                AtualizarLabelErro(textBoxPassword, labelErrorPassword, "Senha deve ter entre 4 e 20 caracteres");
                labelErrorPassword.Visible = true;
                return false;
            }

            labelErrorPassword.Visible = false;
            return true;
        }

        private bool ValidarConfirmacaoSenha()
        {
            if ( textBoxPassword.Text != textBoxConfirmPassword.Text )
            {
                AtualizarLabelErro(textBoxConfirmPassword, labelErrorConfirmPassword, "As senhas não coincidem");
                labelErrorConfirmPassword.Visible = true;
                return false;
            }

            labelErrorConfirmPassword.Visible = false;
            return true;
        }

        private bool ValidaCamposNovoUsuario()
        {
            LimparErros();
            bool nomeValido = ValidarCampoNome();
            // Em modo edição, email e telefone não são necessários
            bool emailValido = _isEditMode ? true : ValidarCampoEmail();
            // Senha é obrigatória apenas na criação, opcional na edição
            bool senhaValida = true;
            bool confirmacaoValida = true;
            if ( !_isEditMode )
            {
                // Modo criação: senha obrigatória
                senhaValida = ValidarCampoSenha();
                confirmacaoValida = ValidarConfirmacaoSenha();
            }
            else
            {
                // Modo edição: senha opcional, mas se preenchida deve ser válida
                if ( !string.IsNullOrWhiteSpace(textBoxPassword.Text) )
                {
                    senhaValida = ValidarCampoSenha();
                    confirmacaoValida = ValidarConfirmacaoSenha();
                }
            }
            return nomeValido && emailValido && senhaValida && confirmacaoValida;
        }

        private void checkBoxIsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if ( checkBoxIsAdmin.Checked )
            {
                textBoxIsAdmin.Text = "SIM";
            }
            else
            {
                textBoxIsAdmin.Text = "NÂO";
            }
        }

        private void dataGridViewUsersData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine($"Clique na linha {e.RowIndex} e coluna {e.ColumnIndex}");

            if ( e.RowIndex < 0 )
            {
                return;
            }

            DataGridViewRow clickedRow = dataGridViewUsersData.Rows[e.RowIndex];

            if ( clickedRow.Cells["ColumnId"].Value != null )
            {
                _userIdBeingEdited = Convert.ToInt32(clickedRow.Cells["ColumnId"].Value);
            }
            else
            {
                _userIdBeingEdited = null;
            }

            // Verificar se a linha clicada já está selecionada
            bool isCurrentlyChecked = clickedRow.Cells["ColumnSelect"].Value != null
                && ( bool ) clickedRow.Cells["ColumnSelect"].Value;

            if ( isCurrentlyChecked && _lastSelectedRowIndex == e.RowIndex )
            {
                // Desmarcar se clicar na mesma linha novamente
                clickedRow.Cells["ColumnSelect"].Value = false;
                clickedRow.Selected = false;
                _lastSelectedRowIndex = -1;
            }
            else
            {
                // Desmarcar a linha anterior
                if ( _lastSelectedRowIndex != -1 && _lastSelectedRowIndex != e.RowIndex )
                {
                    DataGridViewRow lastRow = dataGridViewUsersData.Rows[_lastSelectedRowIndex];
                    lastRow.Cells["ColumnSelect"].Value = false;
                    lastRow.Selected = false;
                }

                // Marcar a nova linha
                clickedRow.Cells["ColumnSelect"].Value = true;
                clickedRow.Selected = true;
                _lastSelectedRowIndex = e.RowIndex;
            }
        }

       




        // ----------------------------------------------------------------------------------------------------------------------
    }
}