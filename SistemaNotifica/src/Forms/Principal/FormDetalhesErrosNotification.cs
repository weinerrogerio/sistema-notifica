using SistemaNotifica.src.Models;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormDetalhesErrosNotification : Form
    {

        private List<ErroDetalhado> _erros;
        private string _caminhoLog;
        private ListView _listViewErros; // Adicionar campo para armazenar referência

        public FormDetalhesErrosNotification(List<ErroDetalhado> erros, string caminhoLog)
        {
            InitializeComponent();
            InitializeComponents();
            _erros = erros;
            _caminhoLog = caminhoLog;
            ConfigurarForm();
            CarregarErros();
        }
       


        private void ConfigurarForm()
        {
            this.Text = $"Detalhes dos Erros ({_erros.Count} falhas)";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimumSize = new Size(600, 400);
        }

        private void InitializeComponents()
        {
            // ListView para mostrar os erros
            var listViewErros = new ListView
            {
                Name = "listViewErros",
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                MultiSelect = false
            };

            // Colunas do ListView
            listViewErros.Columns.Add("Nome", 150);
            listViewErros.Columns.Add("Documento", 120);
            listViewErros.Columns.Add("Email", 300);
            listViewErros.Columns.Add("Tipo Erro", 100);
            listViewErros.Columns.Add("Mensagem", 200);

            // Panel para botões
            var panelBotoes = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50
            };

            var btnAbrirLog = new Button
            {
                Text = "Abrir Log Completo",
                Size = new Size(130, 30),
                Location = new Point(10, 10)
            };

            var btnExportarCSV = new Button
            {
                Text = "Exportar CSV",
                Size = new Size(100, 30),
                Location = new Point(150, 10)
            };

            var btnFechar = new Button
            {
                Text = "Fechar",
                Size = new Size(80, 30),
                Location = new Point(260, 10)
            };

            // Eventos
            btnAbrirLog.Click += (s, e) => AbrirArquivoLog();
            btnExportarCSV.Click += (s, e) => ExportarParaCSV();
            btnFechar.Click += (s, e) => this.Close();

            // Adicionar controles
            panelBotoes.Controls.AddRange(new Control[] { btnAbrirLog, btnExportarCSV, btnFechar });
            this.Controls.AddRange(new Control[] { listViewErros, panelBotoes });

            // Referenciar o ListView para uso posterior
            _listViewErros = listViewErros;
        }

        private void CarregarErros()
        {
            _listViewErros.Items.Clear();

            foreach (var erro in _erros)
            {
                var item = new ListViewItem(erro.NomeDevedor);
                item.SubItems.Add(erro.Documento);
                item.SubItems.Add(erro.Email);
                item.SubItems.Add(erro.TipoErro);
                item.SubItems.Add(erro.MensagemErro);
                item.Tag = erro; // Para referência posterior

                _listViewErros.Items.Add(item);
            }

            // Auto-ajustar colunas
            foreach (ColumnHeader column in _listViewErros.Columns)
            {
                column.Width = -2; // Auto-size
            }
        }

        private void AbrirArquivoLog()
        {
            try
            {
                if (File.Exists(_caminhoLog))
                {
                    Process.Start("notepad.exe", _caminhoLog);
                }
                else
                {
                    MessageBox.Show("Arquivo de log não encontrado.", "Erro",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir log: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarParaCSV()
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV files (*.csv)|*.csv";
                    saveDialog.FileName = $"erros_notificacao_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        var csv = new StringBuilder();
                        csv.AppendLine("Nome,Documento,Email,TipoErro,MensagemErro,DataHora");

                        foreach (var erro in _erros)
                        {
                            csv.AppendLine($"\"{erro.NomeDevedor}\",\"{erro.Documento}\",\"{erro.Email}\"," +
                                          $"\"{erro.TipoErro}\",\"{erro.MensagemErro}\",\"{erro.DataHora:dd/MM/yyyy HH:mm:ss}\"");
                        }

                        File.WriteAllText(saveDialog.FileName, csv.ToString(), Encoding.UTF8);
                        MessageBox.Show("Arquivo CSV exportado com sucesso!", "Sucesso",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar CSV: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
