using SistemaNotifica.src.Forms;
using SistemaNotifica.src.Forms.Template;
using SistemaNotifica.src.Services;

namespace SistemaNotifica
{
    internal static class Program
    {

        private static string _baseApiUrl = "http://localhost:3000"; // URL base

        public static AuthService AuthService { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AuthService = new AuthService(_baseApiUrl);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.            
            ApplicationConfiguration.Initialize();
            Application.Run(new FormLogin());
        }
    }
}