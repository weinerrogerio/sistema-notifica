using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SistemaNotifica.src.Models;
using SistemaNotifica.src.Services;

public class ImportService
{
    private readonly ApiService _apiService;

    // Construtor:
    public ImportService(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<ImportResponse> UploadFileAsync(byte[] fileBytes, string fileName) // Defina ImportResponse ou o tipo de retorno correto
    {
        Debug.WriteLine("Iniciando upload.......");
        try
        {

            // O endpoint é "import/upload"
            var response = await _apiService.PostFileAsync<ImportResponse>("import/upload", fileBytes, fileName);
            return response;
        }
        catch (HttpRequestException ex)
        {
            // Trate erros HTTP específicos (ex: 400 Bad Request, 401 Unauthorized)
            Console.WriteLine($"Erro HTTP ao fazer upload: {ex.Message}");
            throw; // Re-lança a exceção para ser tratada em FormImport
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado ao fazer upload: {ex.Message}");
            throw; // Re-lança a exceção
        }
    }


    public async Task<List<DataImportsUser>> SearchImportsAsync()
    {
        try
        {
            Debug.WriteLine("Buscando Importações com usuário...........................");
            var response = await _apiService.GetAsync<List<DataImportsUser>>("log-arquivo-import/all-and-user/");
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


    public async Task<string> SearhLogImportsAsync(int id)
    {
        try
        {
            Debug.WriteLine("Buscando SearhLogImportsAsync...........................");
            var response = await _apiService.GetJsonAsync($"log-arquivo-import/status/{id}");
            return response;
        }
        catch ( HttpRequestException ex )
        {
            Debug.WriteLine($"Erro HTTP: {ex.Message}");
            throw new Exception($"Erro durante o processo de busca de Importações com usuário::::Erro de conexão com o servidor. Verifique sua rede ou a URL da API. Detalhes: {ex.Message}");
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


