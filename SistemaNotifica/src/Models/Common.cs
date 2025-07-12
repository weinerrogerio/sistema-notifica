using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SistemaNotifica.src.Models
{
    internal class Common
    {
    }

    public static class Sessao
    {
        public static string AccessToken { get; set; } = ""; // token
        public static string RefreshToken { get; set; } = ""; // token --> principal
        public static int SessionId { get; set; } = 0;// sessão
        public static int UserId { get; set; } = 0; // id do usuário
        public static string UsuarioLogado { get; set; } = ""; // nome do usuário
        public static string TipoUsuario { get; set; } = ""; // tipo (admin, user, etc)
    }

    public class Usuario
    {
        public string Nome { get; set; }
        public string Role { get; set; }
        public string Tipo { get; set; }

    }

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
        public User UserData { get; set; }
    }

    // Exemplo de classe User (se a API retornar dados do usuário no login)
    public class User
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



    /// Clases Modelos para buscas de distribuição -- dada,dis,dev,docDev, email,status
    public class StatusNotificacao
    {
        public bool emailEnviado { get; set; }
        public DateTime? dataEnvio { get; set; } // Nullable DateTime
        public bool lido { get; set; }
        public DateTime? dataLeitura { get; set; }
        public string trackingToken { get; set; }
    }

    public class Credor
    {
        public int id { get; set; }
        public string sacador { get; set; }
        public string cedente { get; set; }
    }

    public class Apresentante
    {
        public int id { get; set; }
        public string nome { get; set; }
    }

    public class Devedor
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string docDevedor { get; set; }
        public string email { get; set; }
        public bool devedorPj { get; set; }
    }

    public class Protesto
    {
        public int id { get; set; }
        public required string numDistribuicao { get; set; }
        public DateTime dataDistribuicao { get; set; }
        public DateTime dataApresentacao { get; set; }
        public required string cartProtesto { get; set; }
        public required string numTitulo { get; set; }
        public int valor { get; set; } // O valor parece ser um int aqui, representando centavos
        public int saldo { get; set; }
        public string? vencimento { get; set; }
        public required List<Devedor> devedor { get; set; }
        public required Apresentante apresentante { get; set; }
        public List<Credor>? credores { get; set; }
        public StatusNotificacao? statusNotificacao { get; set; }
    }


    /* ----------------------------------  Classes modelos para receber doc-protesto (Get)  -----------------------------------------*/
    public class DocProtesto{        
        public int id { get; set; }
        public DateTime dataApresentacao { get;  set; }
        public int numDistribuicao { get;  set; }
        public DateTime dataDistribuicao { get;  set; }        
        public required string cartProtesto { get;  set; }
        public required string numTitulo { get;  set; }
        public int valor { get;  set; }
        public int saldo { get;  set; }
        public string? vencimento { get;  set; }
        public int fkApresentante { get;  set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    /* -------------------------------------------   Classes para receber dados de log-import (Get) ---------------------------------------------*/

    //classe simples de immportações e user
    public class DataImportsUser
    {
        public int id { get; set; }
        public required string nome_arquivo { get; set; }
        public int tamanho_arquivo { get; set; }
        public required string status { get; set; }
        public int total_registros { get; set; }
        public int registros_com_erro { get; set; }
        public int registrosDuplicados { get; set; }
        public DateTime data_importacao { get; set; }
        public required User usuario { get; set; }
    }

    //classe extendida de importações e user
    public class DataImportUserDetails { }



    /*-------------------------------------     CLASSE MODELO  PARA RESPOSTA DO UPLOAD  ---------------------------------------                   -*/
    // Exemplo de classe de resposta da API de upload, se ela retornar algo simples
    public class ImportResponse
    {
        //return { processedCount, errorCount, skippedCount, errors };
        public string? processedCount { get; }
        public object? errorCount { get; }
        public object? skippedCount { get; }
        public object? errors { get; }
    }

}
