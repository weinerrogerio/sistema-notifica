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

            // Passar a mesma inst�ncia para todos os servi�os
            AuthService = new AuthService(ApiService);
            ProtestoService = new ProtestoService(ApiService);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.            
            //ApplicationConfiguration.Initialize();
            //Application.Run(new FormLogin());
            using (FormLogin loginForm = new FormLogin()) // Use 'using' para garantir o dispose
            {
                // Mostra o formul�rio de login como um di�logo modal.
                // O c�digo ABAIXO S� SER� EXECUTADO DEPOIS QUE loginForm.Close() for chamado
                // E SE o DialogResult for OK.
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Login bem-sucedido, agora inicie o formul�rio principal da aplica��o
                    Application.Run(new FormOrigin()); // Assumindo que FormOrigin � o seu formul�rio principal
                }
                else
                {
                    // Login n�o foi bem-sucedido (usu�rio fechou o form, ou login falhou
                    // e o form foi fechado sem DialogResult.OK).
                    // A aplica��o simplesmente terminar� aqui.
                    // N�o chame Application.Exit() aqui, ShowDialog() j� gerencia isso.
                    Debug.WriteLine("ERRO EM PROGRAM.CS --> LOGIN");
                }
            }
        }
    }
}