using System.Drawing.Printing;
using SistemaNotifica.src.Forms;

namespace SistemaNotifica
{
    public partial class FormOrigin : Form
    {
        //Thread nt;
        public Form objForm;

        public FormOrigin()
        {
            InitializeComponent();
            objForm = new Form();
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
                if (sidebarMenu.Width <= 50)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                    // ajusta o tamanho dos containers dos botões dentro do width do menu
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

                    // ajusta o tamanho dos containers dos botões dentro do width do menu
                    adjustWidth(sidebarMenu.Width);

                }
            }
        }
        //CONFERIR FUNCIONAMENTO DESSA FUNÇÃO
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
            objForm?.Close();
            objForm = new FormHome
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlMain.Controls.Add(objForm);
            objForm.Show();
        }

        private void btnImportarDoc_Click(object sender, EventArgs e)
        {

        }

        // A PRIMEIRA TELA A SER APRESENTADA PRECISA SER A HOME
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            //OnLoad.add
        }
    }
}
