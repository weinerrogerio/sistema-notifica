using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // ESSENCIAL para UserControl, Panel, Label, CheckBox, SuspendLayout, ResumeLayout, Controls, etc.
using System.Drawing;     // ESSENCIAL para Color, Font, Size, Point, ContentAlignment, etc.
using System.IO;          // ESSENCIAL para Path.GetExtension, Path.GetFileNameWithoutExtension, ToolTip

using SistemaNotifica.src.Models; // Seu namespace para modelos

namespace SistemaNotifica.src.Forms.Template.Controls
{
    public partial class TemplateCard : UserControl
    {
        private EmailTemplate _template;
        private bool _isSelected;
        private Panel pnlMain;
        private Label lblNomeArquivo;
        private Label lblDataCriacao;
        private CheckBox chkEhPadrao;
        private Panel pnlStatus;
        private Label lblStatus;

        // Adicione atributos para controle de serialização do designer
        // Isso informa ao designer para ignorar a serialização dessas propriedades complexas,
        // já que elas serão definidas em tempo de execução.
        [System.ComponentModel.Browsable(false)] // Não aparece no Property Grid
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)] // O designer não tenta serializar
        public EmailTemplate Template
        {
            get => _template;
            set
            {
                _template = value;
                UpdateDisplay();
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                UpdateSelectionStyle();
            }
        }

        public event EventHandler<EmailTemplate> CardClicked;
        public event EventHandler<EmailTemplate> PadraoChanged;

        public TemplateCard()
        {
            // O InitializeComponent é onde os controles são criados e configurados,
            // e SuspendLayout/ResumeLayout são chamados.
            InitializeComponent();
            SetupLayout(); // Métodos de configuração visual adicionais, se houver
        }

        // InitializeComponent é gerado pelo designer no TemplateCard.Designer.cs
        // Mas se você está recriando-o manualmente, ele deve ser assim:
        private void InitializeComponent()
        {
            pnlMain = new Panel();
            lblNomeArquivo = new Label();
            lblDataCriacao = new Label();
            pnlStatus = new Panel();
            chkEhPadrao = new CheckBox();
            lblStatus = new Label();
            pnlMain.SuspendLayout();
            pnlStatus.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Controls.Add(lblNomeArquivo);
            pnlMain.Controls.Add(lblDataCriacao);
            pnlMain.Controls.Add(pnlStatus);
            pnlMain.Cursor = Cursors.Hand;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(5);
            pnlMain.Size = new Size(176, 68);
            pnlMain.TabIndex = 0;
            pnlMain.Click += PnlMain_Click;
            pnlMain.MouseEnter += PnlMain_MouseEnter;
            pnlMain.MouseLeave += PnlMain_MouseLeave;
            // 
            // lblNomeArquivo
            // 
            lblNomeArquivo.Cursor = Cursors.Hand;
            lblNomeArquivo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNomeArquivo.ForeColor = Color.FromArgb(33, 37, 41);
            lblNomeArquivo.Location = new Point(5, -1);
            lblNomeArquivo.Name = "lblNomeArquivo";
            lblNomeArquivo.Size = new Size(160, 20);
            lblNomeArquivo.TabIndex = 0;
            lblNomeArquivo.TextAlign = ContentAlignment.MiddleLeft;
            lblNomeArquivo.Click += PnlMain_Click;
            // 
            // lblDataCriacao
            // 
            lblDataCriacao.Cursor = Cursors.Hand;
            lblDataCriacao.Font = new Font("Segoe UI", 8.5F);
            lblDataCriacao.ForeColor = Color.FromArgb(108, 117, 125);
            lblDataCriacao.Location = new Point(5, 21);
            lblDataCriacao.Name = "lblDataCriacao";
            lblDataCriacao.Size = new Size(160, 16);
            lblDataCriacao.TabIndex = 1;
            lblDataCriacao.TextAlign = ContentAlignment.MiddleLeft;
            lblDataCriacao.Click += PnlMain_Click;
            // 
            // pnlStatus
            // 
            pnlStatus.Controls.Add(chkEhPadrao);
            pnlStatus.Controls.Add(lblStatus);
            pnlStatus.Cursor = Cursors.Hand;
            pnlStatus.Location = new Point(5, 41);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(160, 20);
            pnlStatus.TabIndex = 2;
            pnlStatus.Click += PnlMain_Click;
            // 
            // chkEhPadrao
            // 
            chkEhPadrao.Font = new Font("Segoe UI", 8F);
            chkEhPadrao.ForeColor = Color.FromArgb(40, 167, 69);
            chkEhPadrao.Location = new Point(5, -1);
            chkEhPadrao.Name = "chkEhPadrao";
            chkEhPadrao.Size = new Size(80, 20);
            chkEhPadrao.TabIndex = 0;
            chkEhPadrao.Text = "Padrão";
            chkEhPadrao.UseVisualStyleBackColor = true;
            chkEhPadrao.CheckedChanged += ChkEhPadrao_CheckedChanged;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(40, 167, 69);
            lblStatus.Location = new Point(84, 1);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(75, 16);
            lblStatus.TabIndex = 1;
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TemplateCard
            // 
            Controls.Add(pnlMain);
            Margin = new Padding(5);
            Name = "TemplateCard";
            Size = new Size(176, 68);
            pnlMain.ResumeLayout(false);
            pnlStatus.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void SetupLayout()
        {
            // Propriedades visuais do TemplateCard em si
            this.BackColor = Color.Transparent;
            // Outras configurações de layout ou estilo do próprio UserControl
        }

        private void UpdateDisplay()
        {
            if (_template == null) return;

            // Nome do arquivo (sem extensão se for muito longo)
            var nomeExibicao = _template.NomeArquivo;
            if (nomeExibicao.Length > 20)
            {
                // Certifique-se de que System.IO está no 'using'
                var extensao = Path.GetExtension(nomeExibicao);
                var nomeBase = Path.GetFileNameWithoutExtension(nomeExibicao);
                if (nomeBase.Length > 15)
                    nomeBase = nomeBase.Substring(0, 15) + "...";
                nomeExibicao = nomeBase + extensao;
            }
            lblNomeArquivo.Text = nomeExibicao;

            // Tooltip com nome completo
            // Certifique-se de que System.Windows.Forms está no 'using'
            var toolTip = new ToolTip();
            toolTip.SetToolTip(lblNomeArquivo, _template.NomeArquivo);

            // Data de criação formatada
            lblDataCriacao.Text = _template.CriadoEm.ToString("dd/MM/yyyy HH:mm");

            // Status padrão
            chkEhPadrao.Checked = _template.EhPadrao;

            if (_template.EhPadrao)
            {
                lblStatus.Text = "ATIVO";
                lblStatus.ForeColor = Color.FromArgb(40, 167, 69);
            }
            else
            {
                lblStatus.Text = "";
            }
        }

        private void UpdateSelectionStyle()
        {
            if (_isSelected)
            {
                pnlMain.BackColor = Color.FromArgb(232, 244, 253);
                pnlMain.BorderStyle = BorderStyle.FixedSingle;
                lblNomeArquivo.ForeColor = Color.FromArgb(13, 110, 253);
            }
            else
            {
                pnlMain.BackColor = Color.White;
                pnlMain.BorderStyle = BorderStyle.FixedSingle;
                lblNomeArquivo.ForeColor = Color.FromArgb(33, 37, 41);
            }
        }

        private void PnlMain_Click(object sender, EventArgs e)
        {
            CardClicked?.Invoke(this, _template);
        }

        private void PnlMain_MouseEnter(object sender, EventArgs e)
        {
            if (!_isSelected)
            {
                pnlMain.BackColor = Color.FromArgb(248, 249, 250);
            }
        }

        private void PnlMain_MouseLeave(object sender, EventArgs e)
        {
            if (!_isSelected)
            {
                pnlMain.BackColor = Color.White;
            }
        }

        private void ChkEhPadrao_CheckedChanged(object sender, EventArgs e)
        {
            // Certifique-se que você só invoca o evento se o estado realmente mudou
            // Isso evita loops infinitos se você estiver manipulando a propriedade no handler
            if (_template != null && chkEhPadrao.Checked != _template.EhPadrao)
            {
                PadraoChanged?.Invoke(this, _template);
            }
        }
    }
}