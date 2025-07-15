using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormDetalhesErros : Form
    {
        private TabControl tabControl;
        public FormDetalhesErros()
        {
            InitializeComponent();
            InitializeComponentForm();
        }

        private void InitializeComponentForm()
        {
            this.SuspendLayout();

            // Configurações do Form
            this.Text = "Detalhes dos Erros";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.BackColor = Color.White;

            // Label título
            Label lblTitulo = new Label();
            lblTitulo.Text = "Detalhes dos Erros";
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Size = new Size(200, 30);
            this.Controls.Add(lblTitulo);

            // TabControl para separar tipos de erro
            tabControl = new TabControl();
            tabControl.Location = new Point(20, 60);
            tabControl.Size = new Size(740, 480);
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(tabControl);

            // Tab para erros críticos
            TabPage tabErrosCriticos = new TabPage("Erros Críticos");
            ListBox listBoxErrosCriticos = new ListBox();
            listBoxErrosCriticos.Dock = DockStyle.Fill;
            listBoxErrosCriticos.Font = new Font("Microsoft Sans Serif", 9);
            listBoxErrosCriticos.BackColor = Color.FromArgb(255, 240, 240);
            listBoxErrosCriticos.SelectionMode = SelectionMode.None;
            tabErrosCriticos.Controls.Add(listBoxErrosCriticos);
            tabControl.TabPages.Add(tabErrosCriticos);

            // Tab para duplicidades
            TabPage tabDuplicidades = new TabPage("Duplicidades");
            DataGridView dgvDuplicidades = new DataGridView();
            dgvDuplicidades.Dock = DockStyle.Fill;
            dgvDuplicidades.BackgroundColor = Color.FromArgb(240, 240, 255);
            dgvDuplicidades.AllowUserToAddRows = false;
            dgvDuplicidades.AllowUserToDeleteRows = false;
            dgvDuplicidades.ReadOnly = true;
            dgvDuplicidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDuplicidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabDuplicidades.Controls.Add(dgvDuplicidades);
            tabControl.TabPages.Add(tabDuplicidades);

            // Botão Fechar
            Button btnFechar = new Button();
            btnFechar.Text = "Fechar";
            btnFechar.Size = new Size(100, 30);
            btnFechar.Location = new Point(660, 550);
            btnFechar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFechar.Click += (sender, e) => this.Close();
            this.Controls.Add(btnFechar);

            this.ResumeLayout(false);
        }

        public void ExibirDetalhes(string detalhesErros, string detalhesDuplicidades)
        {
            // Usar a referência direta ao TabControl
            if (tabControl == null) return;

            // Processar erros críticos
            ProcessarErrosCriticos(detalhesErros, tabControl.TabPages[0]);

            // Processar duplicidades
            ProcessarDuplicidades(detalhesDuplicidades, tabControl.TabPages[1]);

            // Mostrar/ocultar tabs baseado no conteúdo
            bool temErrosCriticos = !string.IsNullOrEmpty(detalhesErros) && detalhesErros != "[null]";
            bool temDuplicidades = !string.IsNullOrEmpty(detalhesDuplicidades) && detalhesDuplicidades != "[null]";

            tabControl.TabPages[0].Text = $"Erros Críticos ({(temErrosCriticos ? "Há erros" : "Nenhum erro")})";
            tabControl.TabPages[1].Text = $"Duplicidades ({(temDuplicidades ? "Há duplicidades" : "Nenhuma duplicidade")})";

            if (temErrosCriticos && !temDuplicidades)
                tabControl.SelectedTab = tabControl.TabPages[0];
            else if (!temErrosCriticos && temDuplicidades)
                tabControl.SelectedTab = tabControl.TabPages[1];
        }

        private void ProcessarErrosCriticos(string detalhesErros, TabPage tabPage)
        {
            ListBox listBox = (ListBox)tabPage.Controls[0];
            listBox.Items.Clear();

            if (string.IsNullOrEmpty(detalhesErros) || detalhesErros == "[null]")
            {
                listBox.Items.Add("Nenhum erro crítico encontrado.");
                return;
            }

            try
            {
                // Remove colchetes externos se existirem
                string jsonLimpo = detalhesErros.Trim();
                if (jsonLimpo.StartsWith("[") && jsonLimpo.EndsWith("]"))
                {
                    jsonLimpo = jsonLimpo.Substring(1, jsonLimpo.Length - 2);
                }

                // Divide por vírgulas, considerando que pode haver vírgulas dentro das strings
                List<string> erros = ParseErrosCriticos(jsonLimpo);

                if (erros.Count == 0)
                {
                    listBox.Items.Add("Nenhum erro crítico encontrado.");
                    return;
                }

                foreach (string erro in erros)
                {
                    string erroLimpo = erro.Trim().Trim('"');
                    listBox.Items.Add($"• {erroLimpo}");
                }
            }
            catch (Exception ex)
            {
                listBox.Items.Add($"Erro ao processar detalhes: {ex.Message}");
                listBox.Items.Add($"Dados recebidos: {detalhesErros}");
            }
        }

        private List<string> ParseErrosCriticos(string jsonLimpo)
        {
            List<string> erros = new List<string>();
            bool dentroString = false;
            string erroAtual = "";

            for (int i = 0; i < jsonLimpo.Length; i++)
            {
                char c = jsonLimpo[i];

                if (c == '"' && (i == 0 || jsonLimpo[i - 1] != '\\'))
                {
                    dentroString = !dentroString;
                    erroAtual += c;
                }
                else if (c == ',' && !dentroString)
                {
                    if (!string.IsNullOrEmpty(erroAtual.Trim()))
                    {
                        erros.Add(erroAtual.Trim());
                    }
                    erroAtual = "";
                }
                else
                {
                    erroAtual += c;
                }
            }

            // Adiciona o último erro
            if (!string.IsNullOrEmpty(erroAtual.Trim()))
            {
                erros.Add(erroAtual.Trim());
            }

            return erros;
        }

        private void ProcessarDuplicidades(string detalhesDuplicidades, TabPage tabPage)
        {
            DataGridView dgv = (DataGridView)tabPage.Controls[0];
            dgv.DataSource = null;
            dgv.Columns.Clear();

            if (string.IsNullOrEmpty(detalhesDuplicidades) || detalhesDuplicidades == "[null]")
            {
                // Criar uma tabela vazia com mensagem
                dgv.Columns.Add("Mensagem", "Mensagem");
                dgv.Rows.Add("Nenhuma duplicidade encontrada.");
                dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                return;
            }

            try
            {
                var duplicidades = JsonConvert.DeserializeObject<List<DuplicidadeModel>>(detalhesDuplicidades);

                if (duplicidades == null || duplicidades.Count == 0)
                {
                    dgv.Columns.Add("Mensagem", "Mensagem");
                    dgv.Rows.Add("Nenhuma duplicidade encontrada.");
                    dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    return;
                }

                // Configurar colunas
                dgv.Columns.Add("Linha", "Linha");
                dgv.Columns.Add("NumDistribuicao", "Nº Distribuição");
                dgv.Columns.Add("CartProtesto", "Cartório de Protesto");
                dgv.Columns.Add("NumTitulo", "Nº Título");
                dgv.Columns.Add("Apresentante", "Apresentante");
                dgv.Columns.Add("Vencimento", "Vencimento");
                dgv.Columns.Add("Motivo", "Motivo");

                // Configurar larguras das colunas
                dgv.Columns["Linha"].Width = 60;
                dgv.Columns["NumDistribuicao"].Width = 100;
                dgv.Columns["CartProtesto"].Width = 180;
                dgv.Columns["NumTitulo"].Width = 80;
                dgv.Columns["Apresentante"].Width = 150;
                dgv.Columns["Vencimento"].Width = 80;
                dgv.Columns["Motivo"].Width = 200;

                // Adicionar dados
                foreach (var duplicidade in duplicidades)
                {
                    dgv.Rows.Add(
                        duplicidade.linha,
                        duplicidade.num_distribuicao,
                        duplicidade.cart_protesto,
                        duplicidade.num_titulo,
                        duplicidade.apresentante,
                        duplicidade.vencimento,
                        duplicidade.motivo
                    );
                }

                // Alternar cores das linhas
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index % 2 == 0)
                        row.DefaultCellStyle.BackColor = Color.FromArgb(248, 248, 255);
                    else
                        row.DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                dgv.Columns.Add("Erro", "Erro");
                dgv.Rows.Add($"Erro ao processar duplicidades: {ex.Message}");
                dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }

    // Modelo para deserialização das duplicidades
    public class DuplicidadeModel
    {
        public int linha { get; set; }
        public string num_distribuicao { get; set; }
        public string cart_protesto { get; set; }
        public string num_titulo { get; set; }
        public string apresentante { get; set; }
        public string vencimento { get; set; }
        public string motivo { get; set; }
    }
}