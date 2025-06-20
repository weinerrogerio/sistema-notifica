using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormImport : Form
    {
        private string filePath = string.Empty;

        public FormImport()
        {
            InitializeComponent();
        }

        private readonly string historicoPath = "historico_importacoes.txt";

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSelecionarArquivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Selecione um arquivo";
            openFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos os Arquivos (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                textBox1.Text = filePath;
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                // Verificar se já foi importado
                if (System.IO.File.Exists(historicoPath))
                {
                    var linhasHistorico = System.IO.File.ReadAllLines(historicoPath);

                    // Verifica se o caminho do arquivo já está no histórico
                    bool jaImportado = linhasHistorico.Any(linha => linha.Contains(filePath));

                    if (jaImportado)
                    {
                        MessageBox.Show("Arquivo já foi importado anteriormente.");
                        return;
                    }
                }

                string dataAtual = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                string item = $"Arquivo: {filePath} | Data: {dataAtual}";

                listBox1.Items.Add(item);

                System.IO.File.AppendAllLines(historicoPath, new[] { item });

                MessageBox.Show("Arquivo importado: " + filePath);
            }
            else
            {
                MessageBox.Show("Selecione um arquivo primeiro.");
            }
        }

        private void FormImport_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(historicoPath))
            {
                var linhas = System.IO.File.ReadAllLines(historicoPath);
                listBox1.Items.AddRange(linhas);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnRemoverSelecionado_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var itemSelecionado = listBox1.SelectedItem.ToString();

                DialogResult resultado = MessageBox.Show(
                    "Tem certeza que deseja remover o item selecionado?",
                    "Confirmar Remoção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    listBox1.Items.Remove(itemSelecionado);

                    var restantes = listBox1.Items.Cast<string>().ToArray();
                    System.IO.File.WriteAllLines(historicoPath, restantes);
                }
            }
            else
            {
                MessageBox.Show("Selecione um arquivo");
            }
        }

    }
}
