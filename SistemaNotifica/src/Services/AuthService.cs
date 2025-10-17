using Newtonsoft.Json;
using SistemaNotifica.src.Models;// Para LoginRequest e LoginResponse
using System;
using System.Collections.Generic;
using System.Diagnostics; // Para HttpRequestException
using System.Linq;
using System.Net.Http;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using static SistemaNotifica.src.Models.Auth;

namespace SistemaNotifica.src.Services
{
    internal class AuthService
    {
        private readonly ApiService _apiService;

        public AuthService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            try
            {
                var loginData = new LoginRequest
                {
                    Nome = username,
                    Password = password
                };

                LoginResponse response = await _apiService.PostAsync<LoginRequest, LoginResponse>("auth/login", loginData);

                if ( response != null && !string.IsNullOrEmpty(response.AccessToken) )
                {
                    Session.AccessToken = response.AccessToken;
                    Session.RefreshToken = response.RefreshToken;
                    Session.SessionId = response.SessionId;
                    Session.UserId = response.UserData?.Id;
                    Session.UsuarioLogado = response.UserData?.Nome ?? username;
                    Session.Email = response.UserData?.Email;
                    Session.TipoUsuario = response.UserData?.Role ?? "user";

                    // ✅ IMPORTANTE: Configurar o header IMEDIATAMENTE após o login
                    _apiService.SetAuthorizationHeader(response.AccessToken);

                    // ✅ DEBUG: Verificar se salvou
                    Debug.WriteLine($"[AuthService] Token salvo: {Session.AccessToken?.Substring(0, 50)}...");
                    Debug.WriteLine($"[AuthService] UserId: {Session.UserId}");
                    Debug.WriteLine($"[AuthService] Role: {Session.TipoUsuario}");

                    return response;
                }
                else
                {
                    throw new Exception(response?.Message ?? "Credenciais inválidas ou erro desconhecido.");
                }
            }
            catch ( HttpRequestException ex )
            {
                Debug.WriteLine($"Erro HttpRequestException em LoginAsync: {ex.Message}");
                throw new Exception($"Erro de conexão com o servidor. Verifique sua rede ou a URL da API. Detalhes: {ex.Message}");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao fazer login: {ex.Message}");
                throw;
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
            Session.AccessToken = null;
            Session.RefreshToken = null;
            Session.UsuarioLogado = null;
            Session.TipoUsuario = null;
            // Sessao.RefreshToken = null; // Limpa também o refresh token
            _apiService.ClearAuthorizationHeader(); // Limpa o cabeçalho de autorização do HttpClient
        }

        // Outros métodos relacionados a autenticação/usuário
        public async Task<User> GetUserProfileAsync()
        {
            // Este método usará o token que foi setado no HttpClient via SetAuthorizationHeader
            return await _apiService.GetAsync<User>("user/profile");
        }
    }
}