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
using ReaLTaiizor.Controls;
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormImport : Form
    {
        private readonly ImportService _importService;

        public FormImport()
        {
            InitializeComponent();
            _importService = Program.ImportService;
            ConfigDataGridView();
            LoadDataImport();

        }

        //dataGridViewDataImport
        private void ConfigDataGridView()
        {
            dataGridViewDataImport.Rows.Clear();
            dataGridViewDataImport.RowHeadersVisible = false;
            dataGridViewDataImport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDataImport.AllowUserToAddRows = false;
            dataGridViewDataImport.MultiSelect = false;
            dataGridViewDataImport.ReadOnly = true;
            dataGridViewDataImport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewDataImport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDataImport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewDataImport.AllowUserToOrderColumns = false;
            dataGridViewDataImport.AllowUserToResizeRows = false;
            dataGridViewDataImport.AllowUserToResizeColumns = false;
        }
        private async void LoadDataImport()
        {
            try
            {
                if (_importService == null)
                {
                    Debug.WriteLine("ImportService não foi inicializado!");
                    MessageBox.Show("Erro: Serviço não disponivel, verifique sua conexão.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Debug.WriteLine("Iniciando LoadDataImport...");
                List<DataImportsUser> dados = await _importService.SearchImportsAsync();

                if (dados == null || dados.Count == 0)
                {
                    Debug.WriteLine("LoadDataImport: dados retornados são NULL ou vazios");
                    return;
                }

                Debug.WriteLine($"LoadgDataImport - Sucesso: {dados.Count} registros encontrados");

                // Limpar dados existentes no grid
                dataGridViewDataImport.Rows.Clear();

                // CORREÇÃO: Loop simples, sem aninhamento desnecessário
                foreach (var file in dados)
                {
                    if (file != null)
                    {
                        AdicionarLinhaApiTabelaFile(file);
                    }
                }

                // Aplicar cores baseadas no status
                AplicarCoresImportStatus();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro em ConfigDataImport: {ex.Message}");
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");

                MessageBox.Show($"Erro ao carregar dados da API de importações: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarLinhaApiTabelaFile(DataImportsUser data)
        {
            try
            {
                string status = data.status;

                // CORREÇÃO: Adicionar linha no grid correto (dataGridViewDataImport)
                int rowIndex = dataGridViewDataImport.Rows.Add();
                DataGridViewRow row = dataGridViewDataImport.Rows[rowIndex];

                // Preencher dados usando os nomes das colunas
                row.Cells["ColumnFile"].Value = data.nome_arquivo;
                row.Cells["ColumnDate"].Value = data.data_importacao;
                row.Cells["ColumnStatus"].Value = data.status;
                row.Cells["ColumnUser"].Value = data.usuario?.Nome ?? "N/A"; // Proteção contra null
                row.Cells["ColumnRecordsCount"].Value = data.total_registros; //totalRegistros
                row.Cells["ColumnErrorCount"].Value = data.registros_com_erro; // total com erros
                row.Cells["ColumnDuplicatesCount"].Value = data.registros_duplicados; // total duplicadoss
                row.Cells["ColumnFileSize"].Value = data.tamanho_arquivo;

                //Colunas invisiveis -> exibir apenas em "detalhes" por conta da quantidade de detalhes
                row.Cells["ColumnDetalhesErros"].Value = data.detalhes_erro;
                row.Cells["ColumnDetalhesDuplicidades"].Value = data.detalhes_duplicidade;

                // Armazenar o status na Tag da linha para usar na coloração
                row.Tag = status;

                Debug.WriteLine($"Linha de importação adicionada: {data.nome_arquivo} - Status: {status}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao adicionar linha da API de importações: {ex.Message}");

                // Método alternativo usando índices
                try
                {
                    //AdicionarLinhaImportComIndices(data);
                }
                catch (Exception err)
                {
                    Debug.WriteLine($"Todos os métodos para adicionar linha de importação falharam: {err.Message}");
                }
            }
        }

        private void AplicarCoresImportStatus()
        {
            foreach (DataGridViewRow row in dataGridViewDataImport.Rows)
            {
                if (row.Tag != null)
                {
                    string status = row.Tag.ToString();

                    switch (status)
                    {
                        case "sucesso":
                            row.DefaultCellStyle.BackColor = Color.Green;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case "parcial":
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case "falha":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 142, 136);
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                    }
                }
            }
        }

        private void dialogImport()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configurações do OpenFileDialog
                //openFileDialog.InitialDirectory = "c:\\"; // Define o diretório inicial
                // RETIRAR ESSE DIRETÓRIO -- TESTES
                openFileDialog.InitialDirectory = "C:\\Users\\Dist02\\js\\Nest.js\\sistema-notifica-nestjs";
                openFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Arquivos CSV (*.csv)|*.csv|Todos os Arquivos (*.*)|*.*"; // Filtra os tipos de arquivo
                openFileDialog.FilterIndex = 3; // Define o filtro padrão (Todos os Arquivos (*.*))
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Pega o caminho do arquivo selecionado
                    string filePath = openFileDialog.FileName;

                    // Exibe o caminho do arquivo no smallTextBox1
                    smallTextBoxSelectFile.Text = filePath;

                    if (string.IsNullOrWhiteSpace(filePath) || !System.IO.File.Exists(filePath))
                    {
                        MessageBox.Show("Por favor, selecione um arquivo válido para importar.", "Arquivo Não Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        // Exemplo de como mostrar o progresso
                        toolStripProgressBarImport.Visible = true;
                        toolStripProgressBarImport.Style = ProgressBarStyle.Marquee;
                        byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                        string fileName = System.IO.Path.GetFileName(filePath);
                        // Exemplo de como atualizar o progresso
                        //toolStripProgressBarImport.Value = 50; // Atualiza o progresso para 50%
                        // Exemplo de como ocultar o progresso
                        //toolStripProgressBarImport.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao Selecionar o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            dialogImport();
        }


        private void smallTextBoxSelectFile_Click(object sender, EventArgs e)
        {
            dialogImport();
        }

        private void smallTextBoxSelectFile_MouseClick(object sender, MouseEventArgs e)
        {
            dialogImport();
        }


        private async void buttonImport_Click(object sender, EventArgs e)
        {
            string filePath = smallTextBoxSelectFile.Text; // Use smallTextBox1 como você tinha no InitializeComponent

            // Validação básica se um arquivo foi selecionado
            if (string.IsNullOrWhiteSpace(filePath) || !System.IO.File.Exists(filePath))
            {
                MessageBox.Show("Por favor, selecione um arquivo válido para importar.", "Arquivo Não Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Exemplo de como mostrar o progresso visualmente
                toolStripProgressBarImport.Visible = true;
                toolStripProgressBarImport.Style = ProgressBarStyle.Marquee; // Mostra um progresso indeterminado
                buttonImport.Enabled = false; // Desabilita o botão para evitar múltiplos cliques
                buttonSelect.Enabled = false;

                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                string fileName = System.IO.Path.GetFileName(filePath);

                // Chamar o serviço de importação para enviar o arquivo
                ImportResponse response = await _importService.UploadFileAsync(fileBytes, fileName);
                //processedCount
                MessageBox.Show($"Arquivo importado com sucesso!\e Registros: {response.processedCount}\n Erros encontrados: {response.errorCount}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aqui você pode atualizar seu DataGridView com base na resposta ou buscar os dados novamente
                // Limpe o smallTextBox1 após o sucesso
                smallTextBoxSelectFile.Text = "Selecione um arquivo...";
            }
            catch (HttpRequestException httpEx)
            {
                // Erros específicos de requisição HTTP (ex: 4xx, 5xx)
                MessageBox.Show($"Erro na requisição à API: {httpEx.Message}\nVerifique o console para mais detalhes.", "Erro de Comunicação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Outros erros
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                toolStripProgressBarImport.Visible = false;
                toolStripProgressBarImport.Style = ProgressBarStyle.Blocks; // Volta ao estilo normal
                buttonImport.Enabled = true; // Reabilita o botão
                buttonSelect.Enabled = true;
            }
        }

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {

        }

        private void btnDatails_Click(object sender, EventArgs e)
        {
            if (dataGridViewDataImport.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione uma linha para ver os detalhes.", "Nenhuma linha selecionada",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Obter a linha selecionada
            DataGridViewRow linhaSelecionada = dataGridViewDataImport.SelectedRows[0];

            // Extrair os dados das colunas de detalhes
            string detalhesErros = linhaSelecionada.Cells["ColumnDetalhesErros"]?.Value?.ToString() ?? "";
            string detalhesDuplicidades = linhaSelecionada.Cells["ColumnDetalhesDuplicidades"]?.Value?.ToString() ?? "";
            string nomeArquivo = linhaSelecionada.Cells["ColumnFile"]?.Value?.ToString() ?? "Arquivo";

            // Verificar se há detalhes para mostrar
            bool temErros = !string.IsNullOrEmpty(detalhesErros) && detalhesErros != "[null]";
            bool temDuplicidades = !string.IsNullOrEmpty(detalhesDuplicidades) && detalhesDuplicidades != "[null]";

            if (!temErros && !temDuplicidades)
            {
                MessageBox.Show("Esse Arquivo não possui detalhes de erros ou duplicidades.", "Sem detalhes",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Criar e exibir o modal
            using (FormDetalhesErros formDetalhes = new FormDetalhesErros())
            {
                formDetalhes.Text = $"Detalhes dos Erros - {nomeArquivo}";
                formDetalhes.ExibirDetalhes(detalhesErros, detalhesDuplicidades);
                formDetalhes.ShowDialog(this);
            }
        }

        
    }
}
