using Newtonsoft.Json.Linq;
using SistemaNotifica.src.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Services
{
    public class ProtestoService
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
                var response = await _apiService.GetAsync<List<Protesto>>("doc-protesto/distribuicoes/buscar/");
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


        public async Task<JObject> GetAsJObjectAsync(string currentPage, string pageSize)
        {
            Debug.WriteLine("chamando GetAsJObjectAsync de ProtestoService...........................");
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "page", currentPage },     
                    { "limit", pageSize }
                };

                Debug.WriteLine($"Enviando parâmetros: page={currentPage}, limit={pageSize}");

                var response = await _apiService.GetAsJObjectAsync("doc-protesto/find-all-pagination", parameters);
                Debug.WriteLine("Resposta Service em GetAsJObjectAsync:" + response.ToString());
                return response;
            }
            catch ( HttpRequestException ex )
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

    }
}
