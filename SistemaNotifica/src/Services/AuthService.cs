using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SistemaNotifica.src.Models;// Para LoginRequest e LoginResponse
using System.Net.Http;
using System.Diagnostics; // Para HttpRequestException

namespace SistemaNotifica.src.Services
{
    internal class AuthService : ApiService
    {
        public AuthService(string baseApiUrl) : base(baseApiUrl) { }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            try
            {
                var loginData = new LoginRequest // Cria uma instância da classe LoginRequest
                {
                    Nome = username, // Sua API espera 'nome', então mapeie 'username' para 'Nome'
                    Password = password
                };
                
                LoginResponse response = await PostAsync<LoginRequest, LoginResponse>("auth/login", loginData);

                if (response != null && !string.IsNullOrEmpty(response.AccessToken))
                {
                    // Armazena o token na sua classe estática Sessao
                    Sessao.AccessToken = response.AccessToken;
                    Sessao.RefreshToken = response.RefreshToken;
                    Sessao.UsuarioLogado = response.UserData?.Nome ?? username; // Tenta pegar do UserData ou usa o nome de usuário
                    Sessao.TipoUsuario = response.UserData?.Role ?? "Unknown"; // Tenta pegar do UserData
                   
                    SetAuthorizationHeader(response.AccessToken);
                    Debug.WriteLine($"Login::::::::    . {response}");
                    return response;
                }
                else
                {
                    // Se a API não retornar um token válido ou indicar falha, lance uma exceção ou retorne uma resposta de erro.
                    // Você pode melhorar esta lógica para retornar mensagens de erro mais específicas da API.
                    throw new Exception(response?.Message ?? "Credenciais inválidas ou erro desconhecido.");
                }
            }
            // Captura exceções de comunicação HTTP (rede, servidor indisponível)
            catch (HttpRequestException ex)
            {
                throw new Exception($"Erro de conexão com o servidor. Verifique sua rede ou a URL da API. Detalhes: {ex.Message}");
            }
            // Captura outras exceções gerais
            catch (Exception ex)
            {
                // Inclui a mensagem da exceção interna para depuração
                throw new Exception($"Erro durante o processo de login: {ex.Message}");
            }
        }

        // Você pode adicionar um método para refreshToken aqui, se necessário:
        //public async Task<LoginResponse> RefreshTokenAsync(string refreshToken)
        //{
        //    try
        //    {
        //        var refreshData = new { refreshToken = refreshToken };
        //        LoginResponse response = await PostAsync<object, LoginResponse>("auth/refresh-token", refreshData);

        //        if (response != null && !string.IsNullOrEmpty(response.Token))
        //        {
        //            Sessao.Token = response.Token;
        //            Sessao.RefreshToken = response.RefreshToken; // Atualiza o refresh token também
        //            SetAuthorizationHeader(response.Token);
        //            return response;
        //        }
        //        else
        //        {
        //            throw new Exception(response?.Message ?? "Falha ao renovar o token.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro ao renovar token: {ex.Message}");
        //    }
        //}

        // Método para fazer logout (limpar tokens)
        public void Logout()
        {
            Sessao.AccessToken = null;
            Sessao.RefreshToken = null;
            Sessao.UsuarioLogado = null;
            Sessao.TipoUsuario = null;  
            // Sessao.RefreshToken = null; // Limpa também o refresh token
            ClearAuthorizationHeader(); // Limpa o cabeçalho de autorização do HttpClient
        }

        // Outros métodos relacionados a autenticação/usuário
        public async Task<User> GetUserProfileAsync()
        {
            // Este método usará o token que foi setado no HttpClient via SetAuthorizationHeader
            return await GetAsync<User>("user/profile");
        }
    }
}