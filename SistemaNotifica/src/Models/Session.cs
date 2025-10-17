using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Models
{
    internal class Session
    {
        // Tokens de autenticação
        public static string AccessToken { get; set; }
        public static string RefreshToken { get; set; }
        public static int? SessionId { get; set; }
        // Dados do usuário
        public static int? UserId { get; set; }
        public static string UsuarioLogado { get; set; }
        public static string Email { get; set; }
        public static string TipoUsuario { get; set; } // "admin" ou "user"

        
        /// Verifica se existe uma sessão ativa válida        
        public static bool IsAutenticated()
        {
            return !string.IsNullOrEmpty(AccessToken) && UserId.HasValue;
        }

        /// Verifica se o usuário logado é administrador
        public static bool IsAdmin()
        {
            return IsAutenticated() &&
                   TipoUsuario?.Equals("admin", StringComparison.OrdinalIgnoreCase) == true;
        }

        
        /// Limpa todos os dados da sessão (útil no logout)        
        public static void ClearSession()
        {
            AccessToken = null;
            RefreshToken = null;
            SessionId = null;
            UserId = null;
            UsuarioLogado = null;
            Email = null;
            TipoUsuario = null;
        }

        
        /// Obtém informações resumidas da sessão para debug        
        public static string GetInfoSession()
        {
            if ( !IsAutenticated() )
                return "Sessão não autenticada";

            return $"Usuário: {UsuarioLogado} (ID: {UserId}) | Role: {TipoUsuario} | SessionId: {SessionId}";
        }
    }
}
