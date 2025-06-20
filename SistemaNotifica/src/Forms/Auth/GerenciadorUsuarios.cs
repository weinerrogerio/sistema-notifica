using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaNotifica
{
    public static class GerenciadorUsuarios
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        static GerenciadorUsuarios()
        {
            usuarios.Add(new Usuario("user", "123"));
        }

        public static bool AutenticarUsuario(string nome, string senha)
        {
            return usuarios.Any(u => u.Nome == nome && u.Senha == senha);
        }

        public static void AdicionarUsuario(string nome, string senha)
        {
            if (!usuarios.Any(u => u.Nome == nome))
                usuarios.Add(new Usuario(nome, senha));
        }

        public static bool UsuarioExiste(string nome)
        {
            return usuarios.Any(u => u.Nome == nome);
        }

        public static void AtualizarUsuario(string nomeAntigo, string nomeNovo)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Nome == nomeAntigo);
            if (usuario != null)
            {
                usuario.Nome = nomeNovo;
            }
        }

        public static string ObterSenha(string nome)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Nome == nome);
            return usuario?.Senha ?? "";
        }

        public static bool RemoverUsuario(string nome)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Nome == nome);
            if (usuario != null)
            {
                usuarios.Remove(usuario);
                return true;
            }

            return false;
        }

        public static List<Usuario> ObterTodosUsuarios()
        {
            return new List<Usuario>(usuarios);
        }
    }
}
