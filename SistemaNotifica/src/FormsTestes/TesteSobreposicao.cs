using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotifica.src.FormsTestes
{
    public partial class TesteSobreposicao : Form
    {
        public TesteSobreposicao()
        {
            InitializeComponent();
        }


        private void showOverlayButton_Click(object sender, EventArgs e)
        {
            // Centralizar o overlay no mainPanel
            CenterOverlayPanel();

            // Mostrar overlay e trazer para frente
            overlayPanel.Visible = true;
            overlayPanel.BringToFront();

            // Exemplo: desativar botões críticos quando overlay estiver ativo
        }

        private void hideOverlayButton_Click(object sender, EventArgs e)
        {
            overlayPanel.Visible = false;

            // Reativar botões quando overlay for fechado
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ação do overlay executada!\nO fundo permaneceu visível o tempo todo.");
        }

        private void CenterOverlayPanel()
        {
            // Centralizar no mainPanel
            int x = ( mainPanel.Width - overlayPanel.Width ) / 2;
            int y = ( mainPanel.Height - overlayPanel.Height ) / 2;
            overlayPanel.Location = new Point(x, y);
        }

        //private void DisableCriticalButtons(bool enable)
        //{
        //    // Exemplo de como desativar botões específicos quando overlay está ativo
        //    // Você pode expandir isso para desativar apenas os botões que considera "críticos"

        //    foreach ( Control control in tableLayoutPanel1.Controls )
        //    {
        //        if ( control is Button btn && btn != showOverlayButton )
        //        {
        //            btn.Enabled = enable;

        //            // Opcional: alterar aparência visual dos botões desabilitados
        //            if ( !enable )
        //            {
        //                btn.ForeColor = Color.Gray;
        //                btn.Text = btn.Text.Replace("(Visível atrás)", "(DESABILITADO)");
        //            }
        //            else
        //            {
        //                btn.ForeColor = btn.BackColor == Color.Yellow || btn.BackColor == Color.Orange ? Color.Black : Color.White;
        //                btn.Text = btn.Text.Replace("(DESABILITADO)", "(Visível atrás)");
        //            }
        //        }
        //    }
        //}

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if ( overlayPanel != null && overlayPanel.Visible )
            {
                CenterOverlayPanel();
            }
        }
    }
}
