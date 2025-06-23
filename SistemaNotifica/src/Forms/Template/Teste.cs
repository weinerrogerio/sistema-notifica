using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar;

namespace SistemaNotifica.src.Forms.Template
{
    public partial class Teste : Form
    {
        public Form pnlForm;
        private bool pnlFormExpanded = false;
        private int targetWidth = 0; // Largura alvo para a animação
        private bool isAnimating = false; // Controle de animação
        private bool isFormLoaded = false; // Controle de carregamento do formulário

        public Teste()
        {
            InitializeComponent();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            // Prevenir múltiplos cliques durante animação
            if (isAnimating)
                return;

            // Se já existe um formulário expandido, contrair primeiro
            if (pnlFormExpanded && pnlForm != null)
            {
                ContractPanel();
                return;
            }

            // Parar qualquer animação em andamento
            timerTransition.Stop();

            // 1. Limpar formulário existente
            CleanupForm();

            // 2. Criar e configurar o novo formulário
            CreateAndConfigureForm();

            // 3. Configurar animação
            SetupAnimation();

            // 4. Iniciar animação
            StartAnimation();
        }

        private void CleanupForm()
        {
            if (pnlForm != null && !pnlForm.IsDisposed)
            {
                pnlForm.Close();
                pnlForm.Dispose();
                pnlForm = null;
            }
            panelAux.Controls.Clear();
            isFormLoaded = false;
        }

        private async void CreateAndConfigureForm()
        {
            try
            {
                // Criar o formulário
                pnlForm = new TemplateEditForm
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.None,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom,
                    WindowState = FormWindowState.Normal // Garantir que não está maximizado
                };

                // Definir tamanho inicial
                pnlForm.Location = new Point(0, 0);
                pnlForm.Size = new Size(0, panelAux.Height);

                // Adicionar ao painel ANTES de mostrar
                panelAux.Controls.Add(pnlForm);

                // Aguardar um frame para garantir que o controle foi adicionado
                await Task.Delay(1);

                // Mostrar o formulário
                pnlForm.Show();
                pnlForm.BringToFront();

                // Aguardar a inicialização dos WebView2 (importante!)
                await Task.Delay(100);

                isFormLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar formulário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupAnimation()
        {
            // Definir largura inicial do painel para 0
            panelAux.Width = 0;

            // Definir largura alvo
            targetWidth = this.ClientSize.Width;

            // Estado inicial da animação
            pnlFormExpanded = false;
            isAnimating = true;
        }

        private void StartAnimation()
        {
            // Iniciar timer de animação
            timerTransition.Start();
        }

        private void timerTransition_Tick(object sender, EventArgs e)
        {
            const int step = 20;
            const int minStep = 3;

            if (!pnlFormExpanded) // Expandindo
            {
                int remainingWidth = targetWidth - panelAux.Width;
                int currentStep = Math.Max(minStep, Math.Min(step, remainingWidth / 8));

                panelAux.Width += currentStep;

                // Atualizar tamanho do formulário para acompanhar o painel
                if (pnlForm != null && !pnlForm.IsDisposed && isFormLoaded)
                {
                    try
                    {
                        pnlForm.Width = panelAux.Width;
                        pnlForm.Height = panelAux.Height;
                        pnlForm.Refresh(); // Forçar redesenho
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao redimensionar: {ex.Message}");
                    }
                }

                if (panelAux.Width >= targetWidth)
                {
                    // Animação de expansão concluída
                    panelAux.Width = targetWidth;
                    pnlFormExpanded = true;
                    isAnimating = false;
                    timerTransition.Stop();

                    // Agora sim, aplicar Dock.Fill para responsividade
                    if (pnlForm != null && !pnlForm.IsDisposed && isFormLoaded)
                    {
                        try
                        {
                            pnlForm.Dock = DockStyle.Fill;
                            pnlForm.Refresh();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao aplicar Dock.Fill: {ex.Message}");
                        }
                    }
                }
            }
            else // Contraindo
            {
                int currentStep = Math.Max(minStep, panelAux.Width / 10);
                panelAux.Width -= currentStep;

                // Atualizar tamanho do formulário durante contração
                if (pnlForm != null && !pnlForm.IsDisposed)
                {
                    try
                    {
                        pnlForm.Dock = DockStyle.None; // Remover Dock para controlar manualmente
                        pnlForm.Width = panelAux.Width;
                        pnlForm.Height = panelAux.Height;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao redimensionar na contração: {ex.Message}");
                    }
                }

                if (panelAux.Width <= 0)
                {
                    // Animação de contração concluída
                    panelAux.Width = 0;
                    pnlFormExpanded = false;
                    isAnimating = false;
                    timerTransition.Stop();

                    // Limpar formulário após contração
                    CleanupForm();
                }
            }
        }

        // Método público para contrair o painel
        public void ContractPanel()
        {
            if (panelAux.Width > 0 && !isAnimating)
            {
                isAnimating = true;
                pnlFormExpanded = true; // Definir como true para iniciar contração
                timerTransition.Start();
            }
        }

        // Override do evento Resize para manter responsividade
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Se o painel estiver totalmente expandido, ajustar largura
            if (pnlFormExpanded && !isAnimating && panelAux.Width > 0)
            {
                targetWidth = this.ClientSize.Width;
                panelAux.Width = targetWidth;

                // O Dock.Fill já cuida do redimensionamento do formulário
            }
        }

        // Método para tratar fechamento do formulário interno
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerTransition.Stop();
            CleanupForm();
            base.OnFormClosing(e);
        }

        

        
    }
}