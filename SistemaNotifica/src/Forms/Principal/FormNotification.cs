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
    public partial class FormNotification : Form
    {
        public FormNotification()
        {
            InitializeComponent();
            ConfigDataGridView();
        }

        private void ConfigDataGridView()
        {
            dataGridViewDataNotification.Rows.Clear();
            dataGridViewDataNotification.RowHeadersVisible = false;
            dataGridViewDataNotification.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDataNotification.AllowUserToAddRows = false;
            dataGridViewDataNotification.MultiSelect = false;
            dataGridViewDataNotification.ReadOnly = true;
            dataGridViewDataNotification.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewDataNotification.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDataNotification.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewDataNotification.AllowUserToResizeRows = false;
            dataGridViewDataNotification.AllowUserToResizeColumns = false;
        }
        }
}
