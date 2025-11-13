using SistemaNotifica.src.Forms;
using SistemaNotifica.src.Forms.Principal;
using SistemaNotifica.src.Forms.Template;
using SistemaNotifica.src.FormsTestes;
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;
using SistemaNotifica.src.Services.Cache;
using System.Diagnostics;

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
        public static DevedorService DevedorService { get; private set; }
        public static UserService UserService { get; private set; }
        public static TemplateService TemplateService { get; private set; }

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
            DevedorService = new DevedorService(ApiService); 
            UserService = new UserService(ApiService);
            TemplateService = new TemplateService(ApiService);


            ConfigureCacheHandlers();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.            
            //ApplicationConfiguration.Initialize();
            //List<ErroDetalhado> erros = new List<ErroDetalhado>();

            //Application.Run(new src.Forms.Template.TemplateManagerForm());
            //Application.Run(new FormData());

            using ( FormLogin loginForm = new FormLogin() )
            {
                if ( loginForm.ShowDialog() == DialogResult.OK )
                {
                    // Login bem-sucedido, agora inicie o formulário principal da aplicação
                    Application.Run(new FormOrigin()); // Assumindo que FormOrigin é o seu formulário principal
                }
                else
                {
                    Debug.WriteLine("ERRO EM PROGRAM.CS --> LOGIN");
                }
            }
        }


        private static void ConfigureCacheHandlers()
        {
            // Configura handlers globais para logging do cache
            ProtestoDataCache.OnDataUpdated += (newData) =>
            {
                System.Diagnostics.Debug.WriteLine($"Program: Cache atualizado com {newData.Count} novos registros");
            };

            ProtestoDataCache.OnLoadingStateChanged += (isLoading) =>
            {
                System.Diagnostics.Debug.WriteLine($"Program: Estado do cache mudou - Carregando: {isLoading}");
            };

            // Handler para erros não tratados relacionados ao cache
            Application.ThreadException += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine($"Program: Erro na thread da aplicação: {e.Exception.Message}");
                if ( e.Exception.Message.Contains("Cache") )
                {
                    // Log específico para erros de cache
                    System.Diagnostics.Debug.WriteLine($"Program: Erro relacionado ao cache detectado, limpando cache");
                    ProtestoDataCache.Clear();
                }
            };
        }

    }
}