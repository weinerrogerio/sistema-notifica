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
    public partial class FormTesteLayout : Form
    {

        public FormTesteLayout()
        {
            InitializeComponent();
            ReorganizarLayout();
        }

        private void ReorganizarLayout()
        {
            this.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();

            // Limpar o TableLayoutPanel1
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 3; // 3 linhas agora

            // Adicionar FlowLayoutPanel1 diretamente (linha 0)
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Padding = new Padding(5);

            // Adicionar FlowLayoutPanel3 diretamente (linha 1)
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 1);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.WrapContents = true;
            flowLayoutPanel3.Margin = new Padding(0);
            flowLayoutPanel3.Padding = new Padding(5);

            // Adicionar Panel1 (linha 2) - área azul
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            panel1.Dock = DockStyle.Fill;
            panel1.Margin = new Padding(0);

            // Configurar estilos das linhas
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // FlowLayoutPanel1
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // FlowLayoutPanel3
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Panel1 (área azul)

            // Configurar coluna
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            tableLayoutPanel1.ResumeLayout(true);
            this.ResumeLayout(true);

            AjustarMargensControles();
        }

        private void AjustarMargensControles()
        {
            foreach ( Control ctrl in flowLayoutPanel1.Controls )
            {
                ctrl.Margin = new Padding(3);
            }

            foreach ( Control ctrl in flowLayoutPanel3.Controls )
            {
                ctrl.Margin = new Padding(3);
            }

            label2.Margin = new Padding(3, 6, 3, 3);
            label3.Margin = new Padding(3, 6, 3, 3);
            label4.Margin = new Padding(3, 6, 3, 3);
            label5.Margin = new Padding(3, 6, 3, 3);
        }
    }
}

