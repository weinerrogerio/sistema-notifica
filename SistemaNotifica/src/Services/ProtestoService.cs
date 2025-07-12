using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaNotifica.src.Models;
using System.Text.Json;

namespace SistemaNotifica.src.Services
{
    internal class ProtestoService
    {
        private readonly ApiService _apiService;

        //construtor:
        public ProtestoService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<Protesto>> SearchDistAsync()
        {
            try
            {
                var response = await _apiService.GetAsync<List< Protesto >>("doc-protesto/distribuicoes/buscar/");
                return response;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"Erro HTTP: {ex.Message}");
                throw new Exception($"Erro durante o processo de busca de distribuições::::Erro de conexão com o servidor. Verifique sua rede ou a URL da API. Detalhes: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"Erro JSON: {ex.Message}");
                throw new Exception($"Erro ao processar resposta da API: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro geral: {ex.Message}");
                throw;
            }
        }

        public async Task<List<DataImportsUser>> SearchImportsAsync()
        {
            try
            {
                var response = await _apiService.GetAsync<List<DataImportsUser>>("doc-protesto/log-arquivo-import/all-and-user/");
                return response;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"Erro HTTP: {ex.Message}");
                throw new Exception($"Erro durante o processo de busca de Importações com usuário::::Erro de conexão com o servidor. Verifique sua rede ou a URL da API. Detalhes: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"Erro JSON: {ex.Message}");
                throw new Exception($"Erro ao processar resposta da API: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro geral: {ex.Message}");
                throw;
            }
        }


        public async Task<List<DocProtesto>> FindByDateRange(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var queryParams = new Dictionary<string, string>();

                if (startDate.HasValue)
                {
                    queryParams["startDate"] = startDate.Value.ToString("yyyy-MM-dd");
                }

                if (endDate.HasValue)
                {
                    queryParams["endDate"] = endDate.Value.ToString("yyyy-MM-dd");
                }
                var response = await _apiService.GetAsync<List<DocProtesto>>("doc-protesto/date-range", queryParams);
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro: {ex.Message}");
                throw;
            }
        }

    }
}
