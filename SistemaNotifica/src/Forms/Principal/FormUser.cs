using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormUser : Form
    {
        // PANEL DAS TELAS:
        // panelUserData --> Dados do Usuário (meus dados)
        // panelAllUsersData --> Dados de todos os Usuários (gerenciar usuários) - SOMENTE ADMIN
        // panelNewUser --> campos para novo user

        private readonly bool _isAdmin;
        private readonly bool _isViewingOwnProfile;

        private readonly UserService _userService;

        public FormUser()
        {
            InitializeComponent();

            // ✅ Verifica autenticação ANTES de qualquer configuração
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

            _isAdmin = Session.IsAdmin();
            //_isViewingOwnProfile = true; // Por padrão, abre visualizando próprio perfil

            ConfigDataGridView();
            ConfigurarAcessoPorRole();
            CarregarDadosUsuario();
            CentralizeAllElements();
            SendPanelsToBack();

            LoadUserDataToGrid();
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

        /// <summary>
        /// Configura a visibilidade e habilitação dos controles baseado no role do usuário
        /// </summary>
        private void ConfigurarAcessoPorRole()
        {
            if ( _isAdmin )
            {
                // ✅ Administrador vê TUDO
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
                // ❌ Usuário comum NÃO vê grid de usuários
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

        /// <summary>
        /// Carrega os dados do usuário logado nos campos do formulário
        /// </summary>
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
                    textBoxActive.Text = "Ativo"; // Assumindo que usuário logado está ativo

                // ✅ Campos que usuário comum NÃO deve editar
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

        private async Task LoadUserDataToGrid()
        {
            // TODO: Implementar chamada à API para buscar dados de todos os usuários
            //var dataUsers = await _userService.GetUsersAsync();
            //Debug.WriteLine($"Carregando dados de todos os usuários:>>>>>>>>>>>>>> {dataUsers}");
        }

        /// <summary>
        /// Carrega os dados de um usuário específico (usado por admin ao editar outro usuário)
        /// </summary>
        /// <param name="userId">ID do usuário a ser carregado</param>
        public async void CarregarDadosUsuarioEspecifico(int userId)
        {
            if ( !_isAdmin )
            {
                MessageBox.Show(
                    "Você não tem permissão para visualizar dados de outros usuários.",
                    "Acesso Negado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                // TODO: Implementar chamada à API para buscar dados do usuário específico
                // var userService = new UserService(apiService);
                // var userData = await userService.GetUserByIdAsync(userId);

                // Preencher os campos com os dados retornados
                Debug.WriteLine($"Carregando dados do usuário ID: {userId}");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao carregar dados do usuário {userId}: {ex.Message}");
                MessageBox.Show(
                    $"Erro ao carregar dados do usuário: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ConfigDataGridView()
        {
            dataGridViewDataGrid.Rows.Clear();
            dataGridViewDataGrid.RowHeadersVisible = false;
            dataGridViewDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDataGrid.AllowUserToAddRows = false;
            dataGridViewDataGrid.MultiSelect = false;
            dataGridViewDataGrid.ReadOnly = true;
            dataGridViewDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewDataGrid.AllowUserToOrderColumns = false;
            dataGridViewDataGrid.AllowUserToResizeRows = false;
            dataGridViewDataGrid.AllowUserToResizeColumns = true;
        }

        private void CentralizeAllElements()
        {
            CentralizeElement(panelDataUsersTop, labelUsers);
            CentralizeElement(panelDataUsersBotton, panelDataUsersBotton);
            CentralizeElement(panelUserData, panelUserDataTextBoxes);
            CentralizeElement(panelAllUsersData, panelNewUserTextBoxes);
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

        private void btnMyData_Click(object sender, EventArgs e)
        {

            SendPanelsToBack();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            panelNewUser.SendToBack();
            panelUserData.SendToBack();
            panelAllUsersData.BringToFront();
        }

        private void buttonEditMyData_Click(object sender, EventArgs e)
        {
            panelUserData.SendToBack();
            panelAllUsersData.SendToBack();
            panelNewUser.BringToFront();
        }

        private void buttonNewUser_Click(object sender, EventArgs e)
        {
            panelUserData.SendToBack();
            panelAllUsersData.SendToBack();
            panelNewUser.BringToFront();
        }

        private void buttonEditSelectedUser_Click(object sender, EventArgs e)
        {
            panelUserData.SendToBack();
            panelAllUsersData.SendToBack();
            panelNewUser.BringToFront();

        }
    }
}