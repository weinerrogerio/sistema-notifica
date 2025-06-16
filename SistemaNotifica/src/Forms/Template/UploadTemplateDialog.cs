using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotifica.src.Forms.Template
{
    public partial class UploadTemplateDialog : Form
     {
        private TextBox txtNome;
        private TextBox txtDescricao;
        private Label lblArquivo;
        private Button btnOk;
        private Button btnCancel;

        public string NomeTemplate => txtNome.Text;
        public string DescricaoTemplate => txtDescricao.Text;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NomeArquivo { get; set; }

        public UploadTemplateDialog()
        {
            InitDialog();
        }

        private void InitDialog()
        {
            this.Text = "Upload de Template";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblNome = new Label
            {
                Text = "Nome do Template:",
                Location = new Point(15, 20),
                Size = new Size(120, 20)
            };

            txtNome = new TextBox
            {
                Location = new Point(15, 45),
                Size = new Size(350, 25)
            };

            var lblDescricaoLabel = new Label
            {
                Text = "Descrição:",
                Location = new Point(15, 80),
                Size = new Size(120, 20)
            };

            txtDescricao = new TextBox
            {
                Location = new Point(15, 105),
                Size = new Size(350, 60),
                Multiline = true
            };

            lblArquivo = new Label
            {
                Text = "Arquivo: ",
                Location = new Point(15, 175),
                Size = new Size(350, 20),
                ForeColor = Color.Gray
            };

            btnOk = new Button
            {
                Text = "OK",
                Location = new Point(210, 200),
                Size = new Size(75, 30),
                DialogResult = DialogResult.OK
            };
            btnOk.Click += BtnOk_Click;

            btnCancel = new Button
            {
                Text = "Cancelar",
                Location = new Point(290, 200),
                Size = new Size(75, 30),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[] 
            { 
                lblNome, txtNome, lblDescricaoLabel, txtDescricao, lblArquivo, btnOk, btnCancel 
            });

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Nome do template é obrigatório!", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            lblArquivo.Text = $"Arquivo: {NomeArquivo}";
            txtNome.Focus();
        }
    }
}
