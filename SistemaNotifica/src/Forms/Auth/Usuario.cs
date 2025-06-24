using System;
using System.Collections.Generic;

namespace SistemaNotifica
{
    public static class Usuarios
    {
        public static List<Usuario> ListaUsuarios = new List<Usuario>();
    }

    public class Usuario
    {
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Senha { get; set; }

        // ✅ NOVO: Adicionado campo para distinguir Admin de Usuario comum
        public string Role { get; set; } // "Admin" ou "Usuario"

        // ✅ Construtor completo (útil para inicialização via código)
        public Usuario(string nome, string contato, string email, string endereco, string senha, string role)
        {
            Nome = nome;
            Contato = contato;
            Email = email;
            Endereco = endereco;
            Senha = senha;
            Role = role;
        }

        // ✅ Construtor básico usado para login/local
        public Usuario(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

        // ✅ Construtor vazio necessário para desserialização JSON (API)
        public Usuario() { }
    }
}
