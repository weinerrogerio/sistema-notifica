using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaNotifica.src.Utils
{
    public static class FormExtensions
    {
        public static void EnableDragByControl(this Form form, Control control)
        {
            Point mouseLocation = Point.Empty;
            bool isDragging = false;

            control.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    mouseLocation = e.Location;
                }
            };

            control.MouseMove += (sender, e) =>
            {
                if (isDragging)
                {
                    form.Location = new Point(
                        (form.Location.X - mouseLocation.X) + e.X,
                        (form.Location.Y - mouseLocation.Y) + e.Y
                    );
                    form.Update();
                }
            };

            control.MouseUp += (sender, e) =>
            {
                isDragging = false;
            };
        }
    }
}