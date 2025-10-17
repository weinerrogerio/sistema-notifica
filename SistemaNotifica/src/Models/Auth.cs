using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static SistemaNotifica.src.Models.User;


namespace SistemaNotifica.src.Models
{
    internal class Auth
    {
        // Classe para enviar os dados de login
        public class LoginRequest
        {
            [JsonProperty("nome")]
            public string Nome { get; set; } // Use "Nome" para corresponder ao seu 'username' no JSON de envio
            [JsonProperty("password")]
            public string Password { get; set; }
        }

        // Classe para receber a resposta do login da API
        public class LoginResponse
        {
            public string Message { get; set; } // Mensagem de sucesso ou erro, se a API retornar
            public bool Success { get; set; } // Indica se o login foi bem-sucedido
            [JsonProperty("accessToken")]
            public string AccessToken { get; set; }

            [JsonProperty("refreshToken")]
            public string RefreshToken { get; set; }

            [JsonProperty("sessionId")]
            public int SessionId { get; set; } // id da sessão --> LogUser

            [JsonProperty("user")]
            public UserLoginData UserData { get; set; }
        }
        




    }
}
