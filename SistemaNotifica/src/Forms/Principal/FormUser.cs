using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormUser : Form
    {

        // PANEL DAS TELAS :
        // panelUserData --> Dados do Usuário (meus dados)
        // panelAllUsersData --> Dados de todos os Usuários (gerenciar usuários) - tabela de usuários - SO ADMIN PODEM VER
        // panelNewUser --> campos para novo user - reutilizável na edição , apenas retirar campo ativo e/ou admin para usuários comuns 

        public FormUser()
        {
            InitializeComponent();
            ConfigDataGridView();
            CentralizeAllElements();
            IsAdmin();            
        }

        private void FormUser_Resize(object sender, EventArgs e)
        {
            // Esta função será chamada toda vez que a janela for redimensionada
            CentralizeAllElements();
        }

        private void IsAdmin()
        {
            //if (!( user.Role == 'admin' ))
            //{
            //    panelBtn2.Enabled = false;
            //    btnUsers.Enabled = false;
            //    panelBtn2.Visible = false;
            //    btnUsers.Visible = false;
            //    tableLayoutPanelTop.Controls.Remove(panelBtn2);
            //}
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

            //CentralizeTwoElementsHorizontally(panelUserDataTextBoxes, labelName, textBoxName, 2);
            //CentralizeTwoElementsHorizontally(panelTableLayoutUserDataBotton, labelEmail, textBoxEmail, 2);
            //CentralizeTwoElementsHorizontally(panelTableLayoutUserDataBotton, labelFone, textBoxFone, 2);
            //CentralizeTwoElementsHorizontally(panelTableLayoutUserDataBotton, labelIsAdmin, textBoxAdmin, 2);
            //CentralizeTwoElementsHorizontally(panelTableLayoutUserDataBotton, labelActive, textBoxActive, 2);
        }

        private void CentralizeElement(Control parentPanel, Control controlToCenter)
        {
            int x = ( parentPanel.Width - controlToCenter.Width ) / 2;
            int y = ( parentPanel.Height - controlToCenter.Height ) / 2;
            controlToCenter.Location = new Point(x, y);
        }

        private void CentralizeTwoElementsHorizontally(Control parentPanel, Control leftControl, Control rightControl, int spacing)
        {
            // Calcula a largura total dos dois controles + espaçamento
            int totalWidth = leftControl.Width + spacing + rightControl.Width;

            // Calcula a posição X inicial para centralizar horizontalmente
            int startX = ( parentPanel.Width - totalWidth ) / 2;

            // Calcula a posição Y para centralizar verticalmente
            int centerY = ( parentPanel.Height - Math.Max(leftControl.Height, rightControl.Height) ) / 2;

            // Posiciona o controle da esquerda (Label)
            leftControl.Location = new Point(startX, centerY);

            // Posiciona o controle da direita (TextBox)
            int rightX = startX + leftControl.Width + spacing;
            rightControl.Location = new Point(rightX, centerY);
        }
    }
}
