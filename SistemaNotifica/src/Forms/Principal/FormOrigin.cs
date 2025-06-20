using System.Drawing.Printing;
using SistemaNotifica.src.Forms;
using SistemaNotifica.src.Forms.Principal;

namespace SistemaNotifica
{
    public partial class FormOrigin : Form
    {
        // Thread nt;
        public Form objForm;
        private string TelaAtual = string.Empty;

        public FormOrigin(string token)
        {
            InitializeComponent();
            objForm = new Form();

            // Inicia o formul�rio em tela cheia, mantendo a barra de tarefas vis�vel.
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void ResetSidebarButtons()
        {
            // Coloque aqui os bot�es da sidebar que devem ser "resetados"
            btnHome.BackColor = Color.FromArgb(0, 0, 0);
            btnImportarDoc.BackColor = Color.FromArgb(0, 0, 0);
            btnDados.BackColor = Color.FromArgb(0, 0, 0);
            btnUser.BackColor = Color.FromArgb(0, 0, 0);
            btnConfig.BackColor = Color.FromArgb(0, 0, 0);
            btnSobre.BackColor = Color.FromArgb(0, 0, 0);

            // Tamb�m pode mudar �cones ou fontes aqui se quiser
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
        }

        Boolean sidebarExpand = false;

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebarMenu.Width -= 10;
                if (sidebarMenu.Width <= 60)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                    adjustWidth(sidebarMenu.Width);
                }
            }
            else
            {
                sidebarMenu.Width += 10;
                if (sidebarMenu.Width >= 190)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                    adjustWidth(sidebarMenu.Width);
                }
            }
        }

        private void adjustWidth(int barWidth)
        {
            panelHome.Width = barWidth;
            panelImportar.Width = barWidth;
            panelData.Width = barWidth;
            panelUser.Width = barWidth;
            panelSettings.Width = barWidth;
            panelLogOut.Width = barWidth;
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (TelaAtual == "FormHome") return;

            ResetSidebarButtons();
            btnHome.BackColor = Color.FromArgb(100, 100, 100);

            objForm?.Close();
            objForm = new FormHome
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            TelaAtual = "FormHome";
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void btnImportarDoc_Click(object sender, EventArgs e)
        {
            if (TelaAtual == "formImport") return;

            ResetSidebarButtons();
            btnImportarDoc.BackColor = Color.FromArgb(100, 100, 100);

            objForm?.Close();
            objForm = new FormImport
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            TelaAtual = "FormImport";
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void btnDados_Click(object sender, EventArgs e)
        {
            if (TelaAtual == "FormData") return;

            ResetSidebarButtons();
            btnDados.BackColor = Color.FromArgb(100, 100, 100);

            objForm?.Close();
            objForm = new FormData
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            TelaAtual = "FormData";
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            if (TelaAtual == "FormUser") return;

            ResetSidebarButtons();
            btnUser.BackColor = Color.FromArgb(100, 100, 100);

            objForm?.Close();
            objForm = new FormUser
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            TelaAtual = "FormUser";
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (TelaAtual == "FormSettings") return;

            ResetSidebarButtons();
            btnConfig.BackColor = Color.FromArgb(100, 100, 100);

            objForm?.Close();
            objForm = new FormSettings
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            TelaAtual = "FormSettings";
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void btnSobre_Click(object sender, EventArgs e)
        {
            if (TelaAtual == "FormSobre") return;

            ResetSidebarButtons();
            btnSobre.BackColor = Color.FromArgb(100, 100, 100);

            objForm?.Close();
            objForm = new FormSobre
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            TelaAtual = "FormSobre";
            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();

            ResetSidebarButtons();
            btnLogOut.BackColor = Color.FromArgb(100, 100, 100);

            Thread nt = new Thread(() =>
            {
                Application.Run(new FormLogin());
            });
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sidebarMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
