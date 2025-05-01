namespace SistemaNotifica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Boolean sidebarExpand = true;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebarMenu.Width -= 5;
                if (sidebarMenu.Width <= 50)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }

            }
            else
            {
                sidebarMenu.Width += 5;
                if (sidebarMenu.Width >= 190)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }
    }
}
