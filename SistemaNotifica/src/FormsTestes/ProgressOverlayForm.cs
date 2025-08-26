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
    public partial class ProgressOverlayForm : Form
    {

        private Panel pnlProgressUpload;
        private Label labelStatusUpload;
        private ProgressBar progressBarUpload;


        public ProgressOverlayForm()
        {
            InitializeComponent();
        }
        
               

        public void CenterProgressPanel(Form parentForm)
        {
            // Posicionar o overlay exatamente sobre o form pai
            this.Location = parentForm.Location;
            this.Size = parentForm.Size;

            // Centralizar o painel de progresso dentro do overlay
            int x = ( this.Width - pnlProgressUpload.Width ) / 2;
            int y = ( this.Height - pnlProgressUpload.Height ) / 2;
            pnlProgressUpload.Location = new Point(x, y);
        }

        public void UpdateStatus(string text)
        {
            if ( labelStatusUpload != null )
                labelStatusUpload.Text = text;
        }

        public void UpdateProgress(int value)
        {
            if ( progressBarUpload != null && value >= 0 && value <= 100 )
            {
                progressBarUpload.Value = value;

                // Atualizar percentual no label (se existir)
                var lblPercent = pnlProgressUpload.Controls.Find("lblPercent", false);
                if ( lblPercent.Length > 0 )
                    ( ( Label ) lblPercent[0] ).Text = $"{value}%";
            }
        }

        public void SetMarqueeStyle(bool marquee)
        {
            if ( progressBarUpload != null )
            {
                progressBarUpload.Style = marquee ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
                if ( marquee )
                    progressBarUpload.MarqueeAnimationSpeed = 50;

                // Esconder percentual no modo marquee
                var lblPercent = pnlProgressUpload.Controls.Find("lblPercent", false);
                if ( lblPercent.Length > 0 )
                    lblPercent[0].Visible = !marquee;
            }
        }

        // Impedir que o usuário feche o overlay com Alt+F4 ou Esc
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ( keyData == Keys.Escape || keyData == ( Keys.Alt | Keys.F4 ) )
                return true; // Bloquear
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Impedir que clique no X feche o form
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }
    }
}