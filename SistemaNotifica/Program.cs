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
        public static ImportService ImportService { get; private set; }
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
            ImportService = new ImportService(ApiService); 
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.            
            //ApplicationConfiguration.Initialize();
            //Application.Run(new FormLogin());
            using (FormLogin loginForm = new FormLogin()) 
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Login bem-sucedido, agora inicie o formul�rio principal da aplica��o
                    Application.Run(new FormOrigin()); // Assumindo que FormOrigin � o seu formul�rio principal
                }
                else
                {
                    Debug.WriteLine("ERRO EM PROGRAM.CS --> LOGIN");
                }
            }
        }
    }
}