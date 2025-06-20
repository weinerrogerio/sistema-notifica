using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaNotifica.src.Forms;


namespace SistemaNotifica
{
    public partial class FormLogin : Form
    {
        private readonly ApiService _apiService;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text=="user"&& textBoxPassword.Text == "123")
            {
                this.Close();
                nt = new Thread(() =>
                {
                    Application.Run(new FormOrigin());
                });
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();
                MessageBox.Show("Logado");
            }
        }
    }
}
