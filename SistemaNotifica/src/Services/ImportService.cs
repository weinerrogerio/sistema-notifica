using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}

// Exemplo de classe de resposta da API de upload, se ela retornar algo simples
public class ImportResponse
{
    //return { processedCount, errorCount, skippedCount, errors };
    public string? processedCount { get; }
    public object? errorCount { get; }
    public object? skippedCount { get; }
    public object? errors { get; } 
}
