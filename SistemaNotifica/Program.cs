using System.Diagnostics;
using SistemaNotifica.src.Forms;
using SistemaNotifica.src.Forms.Principal;
using SistemaNotifica.src.Forms.Template;
using SistemaNotifica.src.FormsTestes;
using SistemaNotifica.src.Models;
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
        public static NotificationService NotificationService { get; private set; }
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
            ImportService = new ImportService(ApiService);
            NotificationService = new NotificationService(ApiService);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.            
            //ApplicationConfiguration.Initialize();
            //List<ErroDetalhado> erros = new List<ErroDetalhado>();

            Application.Run(new FormOrigin());

            //using ( FormLogin loginForm = new FormLogin() )
            //{
            //    if ( loginForm.ShowDialog() == DialogResult.OK )
            //    {
            //        // Login bem-sucedido, agora inicie o formulário principal da aplicação
            //        Application.Run(new FormOrigin()); // Assumindo que FormOrigin é o seu formulário principal
            //    }
            //    else
            //    {
            //        Debug.WriteLine("ERRO EM PROGRAM.CS --> LOGIN");
            //    }
            //}
        }
    }
}