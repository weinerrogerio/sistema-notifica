using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Models
{
    public class User
    {
        // Classe UserLoginData para receber os dados do usuário no login
        public class UserLoginData
        {
            [JsonProperty("id")]
            public int Id { get; set; } // int

            [JsonProperty("nome")]
            public string Nome { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("role")]
            public string Role { get; set; }
        }


        public class CreateUserDto
        {
            public string nome { get; set; }
            public string email { get; set; }
            public string contato { get; set; }
            public string password { get; set; }
            public string role { get; set; } // "ADMIN" ou "USER"            
        }      

        //Classe para receber a resposta da criação de um novo usuário
        public class CreateUserResponseDto
        {
            public int id { get; set; }
            public string nome { get; set; }
            public string email { get; set; }
            public string contato { get; set; }
            public string role { get; set; }
            public DateTime created_at { get; set; }
        }


        public class UpdateUserDto
        {
            //public int id { get; set; }
            public string nome { get; set; }
            public string email { get; set; }
            public string contato { get; set; }
            public string password { get; set; }  
            public string role { get; set; }
        }

        // REVER UTILIDADE POIS ESSES DADOS SÃO SAVOS EM Session
        public class TokenPayloadDto
        {
            public int sub { get; set; }        // ID do usuário que está criando
            public string name { get; set; }     // Nome do usuário que está criando
            public string role { get; set; }     // Role do usuário que está criando
            public int sessionId { get; set; }   // ID da sessão
            public int iat { get; set; }         // Issued at (opcional)
            public int exp { get; set; }         // Expiration (opcional)
            public string aud { get; set; }      // Audience (opcional)
            public string iss { get; set; }      // Issuer (opcional)
        }


    }
}
