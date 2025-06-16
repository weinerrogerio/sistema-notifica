using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using SistemaNotifica.src.Models;
using System.Diagnostics;

namespace SistemaNotifica.src.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiService(string baseUrl = "http://localhost:3000")
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMinutes(5);
        }

        public async Task<List<EmailTemplate>> GetTemplatesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/template");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EmailTemplate>>(json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar templates: {ex.Message}");
            }
        }

        public async Task<EmailTemplate> GetTemplateAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/template/{id}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EmailTemplate>(json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar template: {ex.Message}");
            }
        }

        public async Task<EmailTemplate> UploadTemplateAsync(byte[] fileBytes, string nomeArquivo)
        {
            try
            {
                // Validar se é arquivo HTML
                if (!nomeArquivo.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Apenas arquivos HTML são permitidos.", nameof(nomeArquivo));
                }

                // A validação de arquivo vazio e tamanho já foi feita no frontend,
                // mas podemos adicionar uma redundância aqui se necessário.
                if (fileBytes == null || fileBytes.Length == 0)
                {
                    throw new ArgumentException("Os dados do arquivo estão vazios ou inválidos.", nameof(fileBytes));
                }

                Debug.WriteLine($"ApiService: Recebido arquivo '{nomeArquivo}' com {fileBytes.Length} bytes para upload.");

                using (var form = new MultipartFormDataContent())
                {
                    var fileContent = new ByteArrayContent(fileBytes);

                    // Definir o Content-Type correto para HTML
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/html");

                    // Adicionar o arquivo ao form com o nome esperado pelo backend ("templateFile")
                    form.Add(fileContent, "templateFile", nomeArquivo);

                    Debug.WriteLine($"ApiService: Enviando requisição POST para {_baseUrl}/template/upload com Content-Disposition: name=\"templateFile\"; filename=\"{nomeArquivo}\"");

                    var response = await _httpClient.PostAsync($"{_baseUrl}/template/upload", form);

                    if (!response.IsSuccessStatusCode)
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine($"ApiService: Erro HTTP: {response.StatusCode} - {errorContent}");
                        throw new HttpRequestException($"Falha no upload do template. Status: {response.StatusCode}. Resposta do servidor: {errorContent}");
                    }

                    var responseJson = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"ApiService: Resposta de sucesso do backend: {responseJson}");
                    return JsonConvert.DeserializeObject<EmailTemplate>(responseJson);
                }
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"ApiService: Erro de requisição HTTP: {httpEx.Message}");
                throw new Exception($"Erro de comunicação com o servidor: {httpEx.Message}", httpEx);
            }
            catch (JsonException jsonEx)
            {
                Debug.WriteLine($"ApiService: Erro ao desserializar a resposta JSON: {jsonEx.Message}");
                throw new Exception($"Erro ao processar a resposta do servidor: {jsonEx.Message}", jsonEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ApiService: Erro geral ao fazer upload do template: {ex}"); // Log completo para depuração
                throw new Exception($"Não foi possível completar o upload do template: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteTemplateAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/template/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar template: {ex.Message}");
            }
        }

        public async Task<EmailTemplate> SetTemplatePadraoAsync(int id)
        {
            try
            {
                var response = await _httpClient.PostAsync($"{_baseUrl}/template/{id}/set-padrao", null);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EmailTemplate>(json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao definir template padrão: {ex.Message}");
            }
        }

        public async Task<string> GetPreviewAsync(string conteudoHtml, Dictionary<string, object> dadosTeste)
        {
            try
            {
                var request = new PreviewRequest
                {
                    ConteudoHtml = conteudoHtml,
                    DadosTeste = dadosTeste
                };

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/template/preview", content);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao gerar preview: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
