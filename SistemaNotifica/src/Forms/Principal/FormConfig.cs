using SistemaNotifica.src.Forms.Principal.ConfigMenu;
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
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }


        private void MostrarTela(UserControl tela)
        {
            // Limpa o que estiver lá dentro no momento
            panelConteudo.Controls.Clear();
            // Faz a nova tela preencher todo o espaço do painel
            tela.Dock = DockStyle.Fill;
            // Adiciona ao painel e traz para a frente
            panelConteudo.Controls.Add(tela);
            tela.BringToFront();
        }

        private void btnConBkend_Click(object sender, EventArgs e)
        {
            UC_ConexaoBackend uc = new UC_ConexaoBackend();
            MostrarTela(uc);
        }

        private void btnConApiDb_Click(object sender, EventArgs e)
        {
            UC_ConexaoApiDb uc = new UC_ConexaoApiDb();
            MostrarTela(uc);
        }

        private void btnExternalSenderService_Click(object sender, EventArgs e)
        {
            UC_TrackingEmailService uc = new UC_TrackingEmailService();
            MostrarTela(uc);
        }

        private void btnSmtpEmail_Click(object sender, EventArgs e)
        {

            UC_SMTPEmailLocal uc = new UC_SMTPEmailLocal();
            MostrarTela(uc);
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            UC_ConexaoBackend uc = new UC_ConexaoBackend();
            MostrarTela(uc);
        }
    }
}
