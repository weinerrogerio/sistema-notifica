using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaNotifica.src.Models;

namespace SistemaNotifica.src.Services
{
    internal class ProtestoService : ApiService
    {
        //construtor:
        public ProtestoService(string baseUrl) : base(baseUrl){ }

        public async Task<Protesto> SearchDistAsync()
        {
            try
            {
                Protesto response = await GetAsync<Protesto>("doc-protesto/distribuicoes/buscar/");
                return response;               
            }
            // Captura exceções de comunicação HTTP (rede, servidor indisponível)
            catch (HttpRequestException ex)
            {
                throw new Exception($"Erro durante o processo de busca de distribuições::::Erro de conexão com o servidor. Verifique sua rede ou a URL da API. Detalhes: {ex.Message}");
            }            
        }
    }


}
