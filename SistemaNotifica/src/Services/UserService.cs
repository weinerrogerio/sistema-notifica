
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SistemaNotifica.src.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }


}
