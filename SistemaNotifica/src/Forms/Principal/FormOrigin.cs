<<<<<<< HEAD
ï»¿using System.Drawing.Printing;
=======
using System.Drawing.Printing;
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
using SistemaNotifica.src.Forms;
using SistemaNotifica.src.Forms.Principal;

namespace SistemaNotifica
{
    public partial class FormOrigin : Form
    {
        // Thread nt;
        public Form objForm;
        private string TelaAtual = string.Empty;

<<<<<<< HEAD
        public FormOrigin(string token)
=======
        public FormOrigin()
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
        {
            InitializeComponent();
            objForm = new Form();

<<<<<<< HEAD
            // Inicia o formulï¿½rio em tela cheia, mantendo a barra de tarefas visï¿½vel.
=======
            // Inicia o formulário em tela cheia, mantendo a barra de tarefas visível.
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

<<<<<<< HEAD
        private void ResetSidebarButtons()
        {
            // Coloque aqui os botï¿½es da sidebar que devem ser "resetados"
            btnHome.BackColor = Color.FromArgb(0, 0, 0);
            btnImportarDoc.BackColor = Color.FromArgb(0, 0, 0);
            btnDados.BackColor = Color.FromArgb(0, 0, 0);
            btnUser.BackColor = Color.FromArgb(0, 0, 0);
            btnConfig.BackColor = Color.FromArgb(0, 0, 0);
            btnSobre.BackColor = Color.FromArgb(0, 0, 0);

            // Tambï¿½m pode mudar ï¿½cones ou fontes aqui se quiser
        }

=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (TelaAtual == "FormHome") return;
<<<<<<< HEAD

            ResetSidebarButtons();
            btnHome.BackColor = Color.FromArgb(100, 100, 100);

=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
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
<<<<<<< HEAD

            ResetSidebarButtons();
            btnImportarDoc.BackColor = Color.FromArgb(100, 100, 100);

=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
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
<<<<<<< HEAD

            ResetSidebarButtons();
            btnDados.BackColor = Color.FromArgb(100, 100, 100);

=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
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
<<<<<<< HEAD

            ResetSidebarButtons();
            btnUser.BackColor = Color.FromArgb(100, 100, 100);

=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
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
<<<<<<< HEAD

            ResetSidebarButtons();
            btnConfig.BackColor = Color.FromArgb(100, 100, 100);

=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
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
<<<<<<< HEAD

            ResetSidebarButtons();
            btnSobre.BackColor = Color.FromArgb(100, 100, 100);

=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
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

<<<<<<< HEAD
            ResetSidebarButtons();
            btnLogOut.BackColor = Color.FromArgb(100, 100, 100);

=======
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
            Thread nt = new Thread(() =>
            {
                Application.Run(new FormLogin());
            });
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
<<<<<<< HEAD

        }

        private void sidebarMenu_Paint(object sender, PaintEventArgs e)
        {

=======
            // OnLoad.add
>>>>>>> d7ad8ad943a45b8b3f1f09e8b48c35a06ef22de9
        }
    }
}
