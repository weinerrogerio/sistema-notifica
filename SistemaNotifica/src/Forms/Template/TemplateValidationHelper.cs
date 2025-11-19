using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Forms.Template
{
    internal class TemplateValidationHelper
    {
        public static void ShowValidationError(IWin32Window parent, string title, string message)
        {
            using ( var errorForm = new Form() )
            {
                errorForm.Text = title;
                errorForm.Width = 500;
                errorForm.Height = 600;
                errorForm.StartPosition = FormStartPosition.CenterParent;
                errorForm.FormBorderStyle = FormBorderStyle.Sizable;
                errorForm.MaximizeBox = false;
                errorForm.ShowIcon = false;

                // ✅ RichTextBox para suportar texto longo com scroll
                var richTextBox = new RichTextBox
                {
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = RichTextBoxScrollBars.Vertical,
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 9.5F),
                    Text = message,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.None,
                    WordWrap = true,
                    DetectUrls = false,
                    Padding = new Padding(15)
                };

                var panel = new Panel
                {
                    Dock = DockStyle.Fill,
                    Padding = new Padding(15),
                    BackColor = Color.White
                };
                panel.Controls.Add(richTextBox);

                var btnOk = new Button
                {
                    Text = "OK",
                    Dock = DockStyle.Bottom,
                    Height = 50,
                    DialogResult = DialogResult.OK,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(0, 123, 255),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };

                btnOk.FlatAppearance.BorderSize = 0;

                errorForm.Controls.Add(panel);
                errorForm.Controls.Add(btnOk);
                errorForm.AcceptButton = btnOk;

                errorForm.ShowDialog(parent);
            }
        }
        public static void ShowTemplateValidationError(IWin32Window parent, string message)
        {
            ShowValidationError(parent, "Erro de Validação do Template", message);
        }
    }
}
