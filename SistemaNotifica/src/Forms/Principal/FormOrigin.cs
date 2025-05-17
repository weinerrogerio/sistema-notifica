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

        public FormOrigin()
        {
            InitializeComponent();
            objForm = new Form();

            // Inicia o formulário em tela cheia, mantendo a barra de tarefas visível.
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
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

            Thread nt = new Thread(() =>
            {
                Application.Run(new FormLogin());
            });
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            // OnLoad.add
        }
    }
}
