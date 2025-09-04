using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SistemaNotifica.src.Models;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;


namespace SistemaNotifica.src.Services
{
    public class ApiService : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiService(string baseUrl)
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMinutes(5);
        }

        // Método para definir o token de autorização
        public void SetAuthorizationHeader(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        // Método para remover o token de autorização
        public void ClearAuthorizationHeader()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public string BuildUrlWithQueryParams(string endpoint, Dictionary<string, string> parameters = null)
        {
            var url = $"{_baseUrl}/{endpoint}";

            if (parameters != null && parameters.Count > 0)
            {
                var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value)}"));
                url += $"?{queryString}";
            }

            return url;
        }


        // ------------- MÉTODOS PARA FAZER REQUISIÇÕES HTTP ------------- //
        // GET /:endpoint
        // Método GET com parâmetros
        public async Task<T> GetAsync<T>(string endpoint, Dictionary<string, string> queryParams = null)
        {
            var url = BuildUrlWithQueryParams(endpoint, queryParams);
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"URL chamada: {url}");
            Debug.WriteLine($"JSON retornado: {json}");
            return JsonConvert.DeserializeObject<T>(json);
        }

        // Método que retorna JSON cru
        public async Task<string> GetJsonAsync(string endpoint, Dictionary<string, string> queryParams = null)
        {   
            Debug.WriteLine($"Chamando GET /{endpoint}");
            var url = BuildUrlWithQueryParams(endpoint, queryParams);
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Debug.WriteLine($"JSON retornado: {response}");
            return await response.Content.ReadAsStringAsync();
        }

        // Método que retorna JObject para manipulação dinâmica
        public async Task<JObject> GetAsJObjectAsync(string endpoint, Dictionary<string, string> queryParams = null)
        {
            var json = await GetJsonAsync(endpoint, queryParams);
            return JObject.Parse(json);
        }

        // DELETE /:id - Exclui Arq
        public async Task DeleteAsync(string endpoint)
        {
            try
            {
                Debug.WriteLine($"Excluindo arquivo no endpoint: {endpoint}");                
                var url = BuildUrlWithQueryParams(endpoint);
                var response = await _httpClient.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao excluir: {ex}");
                throw new Exception($"Erro ao excluir: {ex.Message}");
            }
        }


        // POST /:endpoint
        //public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        //{
        //    var json = JsonConvert.SerializeObject(data);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var response = await _httpClient.PostAsync($"{_baseUrl}/{endpoint}", content);

        //    string fullUrl = $"{_baseUrl}/{endpoint}"; // A URL completa 
        //    Debug.WriteLine($"[API Service] Enviando POST para: {fullUrl}");
        //    Debug.WriteLine($"[API Service] Corpo da requisição: {json}");

        //    response.EnsureSuccessStatusCode();
        //    var responseJson = await response.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<TResponse>(responseJson);
        //}
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string fullUrl = $"{_baseUrl}/{endpoint}";

                Debug.WriteLine($"[API Service] Enviando POST para: {fullUrl}");
                Debug.WriteLine($"[API Service] Corpo da requisição: {json}");

                var response = await _httpClient.PostAsync(fullUrl, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"[API Service] Status: {response.StatusCode}");
                Debug.WriteLine($"[API Service] Resposta: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TResponse>(responseContent);
                }
                else
                {
                    // Tratamento específico para diferentes status codes
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.Unauthorized:
                            string authErrorMessage = ExtractApiErrorMessage(responseContent) ?? "Credenciais inválidas.";
                            throw new UnauthorizedAccessException(authErrorMessage);

                        case HttpStatusCode.BadRequest:
                            string badRequestMessage = ExtractApiErrorMessage(responseContent) ?? "Dados inválidos.";
                            throw new ArgumentException(badRequestMessage);

                        case HttpStatusCode.NotFound:
                            string notFoundMessage = ExtractApiErrorMessage(responseContent) ?? "Recurso não encontrado.";
                            throw new FileNotFoundException(notFoundMessage);

                        case HttpStatusCode.InternalServerError:
                            string serverErrorMessage = ExtractApiErrorMessage(responseContent) ?? "Erro interno do servidor.";
                            throw new Exception($"Erro do servidor: {serverErrorMessage}");

                        default:
                            string generalErrorMessage = ExtractApiErrorMessage(responseContent) ?? response.ReasonPhrase;
                            throw new HttpRequestException($"HTTP {(int)response.StatusCode}: {generalErrorMessage}");
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw; // Re-lança para manter tratamento específico
            }
            catch (ArgumentException)
            {
                throw; // Re-lança para manter tratamento específico
            }
            catch (FileNotFoundException)
            {
                throw; // Re-lança para manter tratamento específico
            }
            catch (HttpRequestException)
            {
                throw; // Re-lança para manter tratamento específico
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                throw new TimeoutException("A requisição expirou. Verifique sua conexão.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[API Service] Erro inesperado: {ex.Message}");
                throw new HttpRequestException($"Erro na comunicação com o servidor: {ex.Message}");
            }
        }


        private string ExtractApiErrorMessage(string responseContent)
        {
            try
            {
                if (string.IsNullOrEmpty(responseContent))
                    return null;

                Debug.WriteLine($"[API Service] Tentando extrair erro de: {responseContent}");

                // Tenta deserializar como um objeto genérico primeiro
                var errorObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);

                // Formato NestJS padrão: { "statusCode": 401, "message": "Credenciais Inválidas", "error": "Unauthorized" }
                if (errorObject.ContainsKey("message"))
                {
                    string message = errorObject["message"].ToString();
                    Debug.WriteLine($"[API Service] Mensagem extraída: {message}");
                    return message;
                }

                // Formato alternativo: { "error": "mensagem de erro" }
                if (errorObject.ContainsKey("error"))
                {
                    return errorObject["error"].ToString();
                }

                // Formato alternativo: { "detail": "mensagem de erro" }
                if (errorObject.ContainsKey("detail"))
                {
                    return errorObject["detail"].ToString();
                }

                return null;
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"[API Service] Erro ao deserializar JSON de erro: {ex.Message}");

                // Se não conseguir deserializar como JSON, tenta usar como texto simples
                if (!string.IsNullOrEmpty(responseContent) && responseContent.Length < 500)
                {
                    // Remove caracteres HTML básicos se houver
                    string cleanMessage = responseContent.Replace("<", "").Replace(">", "").Trim();
                    if (!string.IsNullOrEmpty(cleanMessage))
                    {
                        return cleanMessage;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[API Service] Erro inesperado ao extrair mensagem: {ex.Message}");
                return null;
            }
        }



        // POST -  MÉTODO PARA UPLOAD DE ARQUIVOS
        public async Task<TResponse> PostFileAsync<TResponse>(string endpoint, byte[] fileBytes, string fileName, Dictionary<string, string> additionalFormFields = null)
        {
            using (var multipartContent = new MultipartFormDataContent())
            {
                // Adiciona o arquivo
                var fileContent = new ByteArrayContent(fileBytes);
                string fileExtension = System.IO.Path.GetExtension(fileName).ToLowerInvariant();
                string contentType = "application/octet-stream"; // Padrão


                Debug.WriteLine("fileContent" + fileContent);
                Debug.WriteLine("fileExtension" + fileExtension);
                Debug.WriteLine("contentType" + contentType);

                switch (fileExtension)
                {
                    case ".txt":
                        contentType = "text/plain";
                        break;
                    case ".csv":
                        contentType = "text/csv";
                        break;
                    case ".xml":
                        contentType = "application/xml"; // Ou "text/xml" dependendo do servidor
                        break;
                        // Adicione outros casos conforme necessário
                }

                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

                // CORREÇÃO: Adicionar o arquivo apenas UMA VEZ
                multipartContent.Add(fileContent, "file", fileName); // "file" deve ser o nome do campo esperado pelo Multer no backend

                // Adiciona campos de formulário adicionais, se houver
                if (additionalFormFields != null)
                {
                    foreach (var field in additionalFormFields)
                    {
                        multipartContent.Add(new StringContent(field.Value), field.Key);
                    }
                }

                var url = $"{_baseUrl}/{endpoint}";
                Debug.WriteLine($"[API Service] Enviando POST (File) para: {url}");
                Debug.WriteLine($"[API Service] Nome do arquivo: {fileName}");

                var response = await _httpClient.PostAsync(url, multipartContent);
                response.EnsureSuccessStatusCode();
                var responseJson = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"[API Service] Resposta (File) em ApiService: {responseJson}");
                return JsonConvert.DeserializeObject<TResponse>(responseJson);
            }
        }



        //------------------------- REMOVER OS ENDPOINTS ABAIXO E COLOCAR EM UM SERVICE PROPRIO-------------------------//
        // GET / - Lista todos os templates
        public async Task<List<EmailTemplate>> GetTemplatesAsync()
        {
            try
            {
                Debug.WriteLine("Chamando GET /template");
                var response = await _httpClient.GetAsync($"{_baseUrl}/template");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"Response JSON: {json}");

                var templates = JsonConvert.DeserializeObject<List<EmailTemplate>>(json);
                Debug.WriteLine($"Templates deserializados: {templates?.Count ?? 0}");

                return templates ?? new List<EmailTemplate>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro em GetTemplatesAsync: {ex}");
                throw new Exception($"Erro ao buscar templates: {ex.Message}");
            }
        }

        // GET /:id - Busca template específico com todos os dados
        public async Task<EmailTemplate> GetTemplateAsync(int id)
        {
            try
            {
                Debug.WriteLine($"Chamando GET /template/{id}");
                var response = await _httpClient.GetAsync($"{_baseUrl}/template/{id}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"Template {id} JSON: {json}");

                return JsonConvert.DeserializeObject<EmailTemplate>(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro em GetTemplateAsync({id}): {ex}");
                throw new Exception($"Erro ao buscar template: {ex.Message}");
            }
        }

        // GET /:id/conteudo - Busca apenas o conteúdo HTML
        public async Task<string> GetTemplateContentAsync(int id)
        {
            try
            {
                Debug.WriteLine($"Chamando GET /template/{id}/conteudo");
                var response = await _httpClient.GetAsync($"{_baseUrl}/template/{id}/conteudo");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro em GetTemplateContentAsync({id}): {ex}");
                throw new Exception($"Erro ao buscar conteúdo do template: {ex.Message}");
            }
        }

        // GET /padrao - Busca o template padrão
        public async Task<EmailTemplate> GetTemplatePadraoAsync()
        {
            try
            {
                Debug.WriteLine("Chamando GET /template/padrao");
                var response = await _httpClient.GetAsync($"{_baseUrl}/template/padrao");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"Template padrão JSON: {json}");

                return JsonConvert.DeserializeObject<EmailTemplate>(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro em GetTemplatePadraoAsync: {ex}");
                throw new Exception($"Erro ao buscar template padrão: {ex.Message}");
            }
        }

        // POST /upload - Upload de novo template
        public async Task<EmailTemplate> UploadTemplateAsync(byte[] fileBytes, string nomeArquivo, string descricao = null)
        {
            try
            {
                Debug.WriteLine($"Fazendo upload: {nomeArquivo}");
                using (var form = new MultipartFormDataContent())
                {
                    // Adicionar o arquivo como conteúdo binário
                    var fileContent = new ByteArrayContent(fileBytes);
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/html");

                    // Nome do campo deve ser "file" para corresponder ao FileInterceptor('file')
                    form.Add(fileContent, "file", nomeArquivo);

                    // Se precisar enviar outros dados, adicione como campos separados
                    if (!string.IsNullOrEmpty(descricao))
                    {
                        form.Add(new StringContent(descricao), "descricao");
                    }

                    var response = await _httpClient.PostAsync($"{_baseUrl}/template/upload", form);
                    response.EnsureSuccessStatusCode();

                    var responseJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EmailTemplate>(responseJson);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro no upload: {ex}");
                throw new Exception($"Erro ao fazer upload do template: {ex.Message}");
            }
        }

        // POST /:id/set-padrao - Define template como padrão
        public async Task SetTemplatePadraoAsync(int id)
        {
            try
            {
                Debug.WriteLine($"Definindo template {id} como padrão");
                var response = await _httpClient.PostAsync($"{_baseUrl}/template/{id}/set-padrao", null);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao definir padrão: {ex}");
                throw new Exception($"Erro ao definir template padrão: {ex.Message}");
            }
        }

        // DELETE /:id - Exclui template
        public async Task DeleteTemplateAsync(int id)
        {
            try
            {
                Debug.WriteLine($"Excluindo template {id}");
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/template/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao excluir: {ex}");
                throw new Exception($"Erro ao excluir template: {ex.Message}");
            }
        }

        // Método para processar template com dados (substituição local)
        public string ProcessarTemplate(string conteudoHtml, Dictionary<string, object> dados)
        {
            try
            {
                var htmlProcessado = conteudoHtml;

                // Substitui placeholders simples como ${dados.propriedade}
                if (dados?.ContainsKey("dados") == true && dados["dados"] is Dictionary<string, object> dadosObj)
                {
                    foreach (var kvp in dadosObj)
                    {
                        var placeholder = $"${{dados.{kvp.Key}}}";
                        htmlProcessado = htmlProcessado.Replace(placeholder, kvp.Value?.ToString() ?? "");
                    }
                }

                return htmlProcessado;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao processar template: {ex}");
                return conteudoHtml; // Retorna original em caso de erro
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}