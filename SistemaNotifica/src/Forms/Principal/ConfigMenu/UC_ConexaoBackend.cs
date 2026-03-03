using SistemaNotifica.src.Forms.Principal.Config;
using SistemaNotifica.src.Forms.Principal.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotifica.src.Forms.Principal.ConfigMenu
{
    public partial class UC_ConexaoBackend : UserControl
    {
        public UC_ConexaoBackend()
        {
            InitializeComponent();
            CarregarUrlAtual();
        }

        private void CarregarUrlAtual()
        {
            textBox1.Text = AppSettingsManager.GetBaseApiUrl();
        }        

        private async void btnTest_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text.Trim();

            if ( string.IsNullOrWhiteSpace(url) )
            {
                MessageBox.Show("Informe uma URL para testar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnTest.Enabled = false;
            btnTest.Text = "Testando...";

            bool conectou = await TestarConexaoAsync(url);

            btnTest.Enabled = true;
            btnTest.Text = "Testar";

            if ( conectou )
            {
                MessageBox.Show("Conexão bem-sucedida! A API está acessível.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não foi possível conectar à API. Verifique a URL e sua conexão.", "Falha na conexão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static async Task<bool> TestarConexaoAsync(string url)
        {
            try
            {
                using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
                var response = await client.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string novaUrl = textBox1.Text.Trim();

            if ( string.IsNullOrWhiteSpace(novaUrl) )
            {
                MessageBox.Show("Informe uma URL válida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                AppSettingsManager.SaveBaseApiUrl(novaUrl);

                // Atualiza a URL nos serviços globais
                Program.InitializeServices(novaUrl);

                MessageBox.Show("URL salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Fecha o formulário pai (o popup) automaticamente após salvar
                this.ParentForm?.Close();
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"Erro ao salvar a URL:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
