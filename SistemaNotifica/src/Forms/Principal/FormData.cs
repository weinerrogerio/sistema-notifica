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
    public partial class FormData : Form
    {
        public FormData()
        {
            InitializeComponent();
            ShowDados();
        }

        private void ShowDados()
        {
            panelDados.Visible = true;
            viewDist.Visible = true;
            viewDataDist.Visible = true;
            viewDocDev.Visible = true;
            viewDocCred.Visible = true;
            viewDataImport.Visible = true;
            lblDist.Visible = true;
            lblDataDist.Visible = true;
            lblDocDev.Visible = true;
            lblDocCred.Visible = true;
            lblDataImport.Visible = true;
            btnAcaoRelatorio.Visible = false;
            btnGrafico.Visible = false;
<<<<<<< HEAD
            panelRelatorios.Visible = false;
=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9

        }

        private void ShowRelatorios()
        {
            panelDados.Visible = false;
            viewDist.Visible = false;
            viewDataDist.Visible = false;
            viewDocDev.Visible = false;
            viewDocCred.Visible = false;
            viewDataImport.Visible = false;
            lblDist.Visible = false;
            lblDataDist.Visible = false;
            lblDocDev.Visible = false;
            lblDocCred.Visible = false;
            lblDataImport.Visible = false;
            btnAcaoRelatorio.Visible = true;
            btnGrafico.Visible = true;
<<<<<<< HEAD
            panelRelatorios.Visible = true;
        }

        private void AtivarBotao(Button botaoAtivo)
        {
            btnDados2.BackColor = SystemColors.Control;
            btnAbaRelatorios.BackColor = SystemColors.Control;

            botaoAtivo.BackColor = Color.LightGray;
        }

        private void btnDados2_Click(object sender, EventArgs e)
        {
            ShowDados();
            AtivarBotao(btnDados2);
        }

        private void btnAbaRelatorios_Click(object sender, EventArgs e)
        {
            ShowRelatorios();
            AtivarBotao(btnAbaRelatorios);
=======
        }

        private void btnDados2_Click(object sender, EventArgs e) //botão da aba Dados
        {
            ShowDados();
        }

        private void btnAbaRelatorios_Click(object sender, EventArgs e) //botão da aba Relatorios
        {
            ShowRelatorios();
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
        }

        private void panelDados_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
<<<<<<< HEAD

        private void panelRelatorios_Paint(object sender, PaintEventArgs e)
        {

        }
=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
    }
}
