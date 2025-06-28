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
                Debug.WriteLine("Fazendo requisição para API...");

                var response = await _apiService.GetAsync<List< Protesto >>("doc-protesto/distribuicoes/buscar/");
                Debug.WriteLine("Resposta recebida da API com sucesso");
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
    }


}
