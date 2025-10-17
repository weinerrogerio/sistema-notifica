
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SistemaNotifica.src.Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
using static SistemaNotifica.src.Models.User;

    namespace SistemaNotifica.src.Services
    {
        internal class UserService
        {
            private readonly ApiService _apiService;

            //construtor:
            public UserService(ApiService apiService)
            {
                _apiService = apiService;
            }

            public async Task<JArray> GetUsersAsync()
            {
                try
                {
                    var response = await _apiService.GetAsJArrayAsync("user/");
                    return response;
                }
                catch ( HttpRequestException ex )
                {
                    Debug.WriteLine($"Erro HTTP: {ex.Message}");
                    throw new Exception($"Erro durante o processo de busca de distribuições::::Erro de conexão com o servidor. Verifique sua rede ou a URL da API. Detalhes: {ex.Message}");
                }
                catch ( JsonException ex )
                {
                    Debug.WriteLine($"Erro JSON em UserService: {ex.Message}");
                    throw new Exception($"Erro ao processar resposta da API: {ex.Message}");
                }
                catch ( Exception ex )
                {
                    Debug.WriteLine($"Erro geral: {ex.Message}");
                    throw;
                }
            }

            public async Task<JObject> GetAllUsersAsync()
            {
                try
                {
                    var response = await _apiService.GetAsJObjectAsync("user/all/");
                    return response;
                }
                catch ( HttpRequestException ex )
                {
                    Debug.WriteLine($"Erro HTTP: {ex.Message}");
                    throw new Exception($"Erro durante o processo de busca de distribuições::::Erro de conexão com o servidor. Verifique sua rede ou a URL da API. Detalhes: {ex.Message}");
                }
                catch ( JsonException ex )
                {
                    Debug.WriteLine($"Erro JSON: {ex.Message}");
                    throw new Exception($"Erro ao processar resposta da API: {ex.Message}");
                }
                catch ( Exception ex )
                {
                    Debug.WriteLine($"Erro geral: {ex.Message}");
                    throw;
                }
            }

        // Adicione este método no UserService.cs
        public async Task<JObject> PostUserAsync(CreateUserDto createUserDto)
        {
            try
            {                
                Debug.WriteLine($"Enviando dados: {JsonConvert.SerializeObject(createUserDto)}");
                var response = await _apiService.PostAsync<CreateUserDto, JObject>("user", createUserDto);
                return response;
            }
            catch ( UnauthorizedAccessException ex )
            {
                Debug.WriteLine($"Erro de autorização: {ex.Message}");
                throw new Exception($"Você não tem permissão para criar usuários. Detalhes: {ex.Message}");
            }
            catch ( ArgumentException ex )
            {
                Debug.WriteLine($"Erro de validação: {ex.Message}");
                throw new Exception($"Dados inválidos: {ex.Message}");
            }
            catch ( HttpRequestException ex )
            {
                Debug.WriteLine($"Erro HTTP: {ex.Message}");
                throw new Exception($"Erro de conexão com o servidor: {ex.Message}");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro geral ao criar usuário: {ex.Message}");
                throw;
            }
        }

    }

}
