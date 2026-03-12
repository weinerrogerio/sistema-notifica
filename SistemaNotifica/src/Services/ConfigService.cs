using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Services
{
    public class ConfigService
    {
        private readonly ApiService _apiService;

        public ConfigService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<JObject> GetConfigData()
        {
            try
            {
                return await _apiService.GetAsJObjectAsync("config/1");
            }
            catch ( Exception ex )
            {
                throw new Exception($"Erro ao buscar dados de configuração: {ex.Message}");
            }
        }

        public async Task<JObject> UpdateConfigData(JObject data)
        {
            try
            {
                return await _apiService.PatchAsync<JObject, JObject>("config", data);
            }
            catch ( Exception ex )
            {
                throw new Exception($"Erro ao atualizar dados de configuração: {ex.Message}");
            }
        }
    }
}
