using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormUser : Form
    {
        private Dictionary<int, List<string>> dadosOriginais;

        public FormUser()
        {
            InitializeComponent();
            ShowCadastro();
            OcultaCadastro();
            OcultaBotoes();

            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dadosOriginais = new Dictionary<int, List<string>>();
        }

        private void ShowCadastro()
        {
            campoNome.Visible = true;
            campoContato.Visible = true;
            campoEmail.Visible = true;
            campoEndereco.Visible = true;
            campoSenha.Visible = true;
            campoConfSenha.Visible = true;
            lblNome.Visible = true;
            lblContato.Visible = true;
            lblEmail.Visible = true;
            lblEndereco.Visible = true;
            lblSenha.Visible = true;
            lblConfSenha.Visible = true;
            btnSalvar.Visible = true;
            btnCancelar.Visible = true;
            dataGridView1.Visible = false;
            btnCadUser.Visible = false;
            btnEditarUser.Visible = false;
            btnSalvarEdicao.Visible = false;
            btnCancelarEdicao.Visible = false;
        }

        private void OcultaCadastro()
        {
            campoNome.Visible = false;
            campoContato.Visible = false;
            campoEmail.Visible = false;
            campoEndereco.Visible = false;
            campoSenha.Visible = false;
            campoConfSenha.Visible = false;
            lblNome.Visible = false;
            lblContato.Visible = false;
            lblEmail.Visible = false;
            lblEndereco.Visible = false;
            lblSenha.Visible = false;
            lblConfSenha.Visible = false;
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
            dataGridView1.Visible = true;
            btnCadUser.Visible = true;
            btnEditarUser.Visible = true;
            btnSalvarEdicao.Visible = true;
            btnCancelarEdicao.Visible = true;
        }

        private void LimparCampos()
        {
            campoNome.Clear();
            campoContato.Clear();
            campoEmail.Clear();
            campoEndereco.Clear();
            campoSenha.Clear();
            campoConfSenha.Clear();
        }

        private void OcultaBotoes()
        {
            btnSalvarEdicao.Visible = false;
            btnCancelarEdicao.Visible = false;
        }

        private void MostrarBotoes()
        {
            btnSalvarEdicao.Visible = true;
            btnCancelarEdicao.Visible = true;
        }

        private void btnCadUser_Click(object sender, EventArgs e)
        {
            ShowCadastro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OcultaCadastro();
            LimparCampos();
            OcultaBotoes();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = campoNome.Text;
            string contato = campoContato.Text;
            string email = campoEmail.Text;
            string endereco = campoEndereco.Text;
            string senha = campoSenha.Text;
            string confSenha = campoConfSenha.Text;

            if (string.IsNullOrEmpty(nome) ||
                string.IsNullOrEmpty(contato) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(endereco) ||
                string.IsNullOrEmpty(senha) ||
                string.IsNullOrEmpty(confSenha))
            {
                MessageBox.Show("Preencha todos os campos");
                return;
            }

            if (senha != confSenha)
            {
                MessageBox.Show("As senhas não são iguais");
                return;
            }

            int rowIndex = dataGridView1.Rows.Add(nome, contato, email, endereco);
            ; // quando tiver usuario admin e usuario normal, adicionar para o admin poder ver e alterar a senha do usuario.
            foreach (DataGridViewCell cell in dataGridView1.Rows[rowIndex].Cells)
            {
                cell.ReadOnly = true;
            }

            LimparCampos();
            OcultaCadastro();
            OcultaBotoes();
        }

        private void btnEditarUser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um usuário para editar");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int rowIndex = selectedRow.Index;

            if (!dadosOriginais.ContainsKey(rowIndex))
            {
                List<string> valoresOriginais = selectedRow.Cells
                    .Cast<DataGridViewCell>()
                    .Select(cell => cell.Value?.ToString() ?? string.Empty)
                    .ToList();
                dadosOriginais[rowIndex] = valoresOriginais;
            }

            dataGridView1.ReadOnly = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ReadOnly = true;
                }
            }

            foreach (DataGridViewCell cell in selectedRow.Cells)
            {
                cell.ReadOnly = false;
            }

            MostrarBotoes();
        }

        private void btnSalvarEdicao_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um usuário para salvar a edição");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int rowIndex = selectedRow.Index;

            List<string> novosValores = selectedRow.Cells
                .Cast<DataGridViewCell>()
                .Select(cell => cell.Value?.ToString() ?? string.Empty)
                .ToList();

            if (dadosOriginais.ContainsKey(rowIndex))
            {
                dadosOriginais[rowIndex] = novosValores;
            }
            else
            {
                dadosOriginais.Add(rowIndex, novosValores);
            }

            dataGridView1.ReadOnly = true;

            MessageBox.Show("Usuário editado");
        }

        private void btnCancelarEdicao_Click(object sender, EventArgs e)
        {
            if (dadosOriginais.Count == 0)
            {
                MessageBox.Show("Nenhuma edição para cancelar");
                return;
            }

            foreach (var item in dadosOriginais)
            {
                int rowIndex = item.Key;
                List<string> valoresOriginais = item.Value;

                if (rowIndex < dataGridView1.Rows.Count)
                {
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        row.Cells[i].Value = valoresOriginais[i];
                        row.Cells[i].ReadOnly = true;
                    }
                }
            }

            dadosOriginais.Clear();

            dataGridView1.ReadOnly = true;

            MessageBox.Show("Edições canceladas");
        }

        
    }
}
