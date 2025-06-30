using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Utils
{
    internal class MouseEvent
    {


        private Point mouseLocation; // armazenar a posição do mouse
        private bool isDragging = false;
        private Form parentForm;

        public MouseEvent(Form form)
        {
            parentForm = form;
        }


        // Evento quando o botão do mouse é pressionado no topPanel
        public void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Apenas se o botão esquerdo do mouse for pressionado
            {
                isDragging = true;
                mouseLocation = e.Location; // Armazena a posição atual do mouse
            }
        }

        // Evento quando o mouse se move no topPanel
        public void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && parentForm != null)
            {
                // Calcula a nova posição do formulário
                parentForm.Location = new Point(
                    (parentForm.Location.X - mouseLocation.X) + e.X,
                    (parentForm.Location.Y - mouseLocation.Y) + e.Y
                );
                parentForm.Update();
            }
        }

        // Evento quando o botão do mouse é liberado no topPanel
        public void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false; // Para de arrastar
        }
    }
}
