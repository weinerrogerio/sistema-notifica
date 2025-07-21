using SistemaNotifica.src.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Services
{
        
    internal class NotificationService
    {
        private readonly ApiService _apiService;

        public NotificationService(ApiService apiService)
        {
            _apiService = apiService;
        }

        // Busca de notificações de devedores com email
        public async Task<List<Notificacao>> SearchNotAsync()
        {
            try
            {
                var response = await _apiService.GetAsync<List<Notificacao>>("log-notificacao/busca-all");
                return response;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"Erro HTTP: {ex.Message}");
                throw new Exception($"Erro durante o processo de busca de Notificações::::Erro de conexão com o servidor. Verifique sua rede ou a URL da API. Detalhes: {ex.Message}");
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

        // busca comleta de notificações --> todos os dados de tabelas relacionadas
        public async Task<List<Notificacao>> SearchCompleteNotAsync()
        {
            try
            {
                var response = await _apiService.GetAsync<List<Notificacao>>("/log-notificacao/busca-completa");
                return response;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"Erro HTTP: {ex.Message}");
                throw new Exception($"Erro durante o processo de busca de Notificações::::Erro de conexão com o servidor. Verifique sua rede ou a URL da API. Detalhes: {ex.Message}");
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
