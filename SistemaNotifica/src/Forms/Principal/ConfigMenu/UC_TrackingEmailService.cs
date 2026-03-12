using Newtonsoft.Json.Linq;
using SistemaNotifica.src.Forms.Principal.Config;
using SistemaNotifica.src.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotifica.src.Forms.Principal.ConfigMenu
{
    public partial class UC_TrackingEmailService : UserControl
    {
        private readonly ConfigService _configService;

        public UC_TrackingEmailService(ConfigService configService)
        {
            InitializeComponent();
            _configService = configService;
            Load += async (s, e) => await LoadConfigDataAsync();
        }        

        private async Task LoadConfigDataAsync()
        {
            try
            {
                var data = await _configService.GetConfigData();

                textBoxApiKey.Text = data["EXTERNAL_SERVICE_API_KEY"]?.ToString() ?? string.Empty;
                textBoxEmail.Text = data["EXTERNAL_SERVICE_SENDER_EMAIL"]?.ToString() ?? string.Empty;
            }
            catch ( Exception ex )
            {
                MessageBox.Show(
                    $"Erro ao carregar configurações:\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string apiKey = textBoxApiKey.Text.Trim();
            string remetente = textBoxEmail.Text.Trim().ToLower();

            // Validação: campos vazios
            if ( string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(remetente) )
            {
                MessageBox.Show(
                    "Preencha todos os campos.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Validação: formato de e-mail
            if ( !IsValidEmail(remetente) )
            {
                MessageBox.Show(
                    "Informe um e-mail válido no campo 'Email remetente'.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Validação: API key muito curta (mínimo razoável)
            if ( apiKey.Length < 8 )
            {
                MessageBox.Show(
                    "A chave do serviço parece inválida (mínimo 8 caracteres).",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                btnSave.Enabled = false;

                var payload = new JObject
                {
                    ["EXTERNAL_SERVICE_API_KEY"] = apiKey,
                    ["EXTERNAL_SERVICE_SENDER_EMAIL"] = remetente
                };

                await _configService.UpdateConfigData(payload);

                MessageBox.Show(
                    "Configurações salvas com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch ( Exception ex )
            {
                MessageBox.Show(
                    $"Erro ao salvar configurações:\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}

