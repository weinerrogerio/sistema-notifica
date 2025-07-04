using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        }

        private void dialogImport()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configurações do OpenFileDialog
                //openFileDialog.InitialDirectory = "c:\\"; // Define o diretório inicial
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

        
    }
}
