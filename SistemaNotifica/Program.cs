using System.Diagnostics;
using SistemaNotifica.src.Forms;
using SistemaNotifica.src.Forms.Template;
using SistemaNotifica.src.Services;

namespace SistemaNotifica
{
    internal static class Program
    {

        private static string _baseApiUrl = "http://localhost:3000"; // URL base

        public static ApiService ApiService { get; private set; }
        public static AuthService AuthService { get; private set; }
        public static ProtestoService ProtestoService { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApiService = new ApiService(_baseApiUrl);

            // Passar a mesma instância para todos os serviços
            AuthService = new AuthService(ApiService);
            ProtestoService = new ProtestoService(ApiService);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.            
            //ApplicationConfiguration.Initialize();
            //Application.Run(new FormLogin());
            using (FormLogin loginForm = new FormLogin()) // Use 'using' para garantir o dispose
            {
                // Mostra o formulário de login como um diálogo modal.
                // O código ABAIXO SÓ SERÁ EXECUTADO DEPOIS QUE loginForm.Close() for chamado
                // E SE o DialogResult for OK.
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Login bem-sucedido, agora inicie o formulário principal da aplicação
                    Application.Run(new FormOrigin()); // Assumindo que FormOrigin é o seu formulário principal
                }
                else
                {
                    // Login não foi bem-sucedido (usuário fechou o form, ou login falhou
                    // e o form foi fechado sem DialogResult.OK).
                    // A aplicação simplesmente terminará aqui.
                    // Não chame Application.Exit() aqui, ShowDialog() já gerencia isso.
                    Debug.WriteLine("ERRO EM PROGRAM.CS --> LOGIN");
                }
            }
        }
    }
}