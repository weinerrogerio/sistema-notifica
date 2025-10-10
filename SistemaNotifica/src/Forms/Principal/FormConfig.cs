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
            CentralizeAllElements();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {

        }

        private void CentralizeElement(Control parentPanel, Control controlToCenter)
        {
            int x = ( parentPanel.Width - controlToCenter.Width ) / 2;
            int y = ( parentPanel.Height - controlToCenter.Height ) / 2;
            controlToCenter.Location = new Point(x, y);
        }

        private void CentralizeAllElements()
        {
            CentralizeElement(panelUserDataBox, panelLogin);


        }

        private void FormConfig_Resize(object sender, EventArgs e)
        {
            CentralizeAllElements();
        }
    }
}
