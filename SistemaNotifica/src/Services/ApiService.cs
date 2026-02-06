using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SistemaNotifica.src.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Services
{
    // HttpClient deve viver durante toda a aplicação
    public class ApiService
    {
        // HttpClient principal para requisições REST normais
        private static readonly HttpClient _sharedHttpClient = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(5)
        };

        // HttpClient separado para SSE (long-lived connections)
        //private static readonly HttpClient _sseHttpClient = new HttpClient
        //{
        //    Timeout = Timeout.InfiniteTimeSpan // SSE precisa de timeout infinito
        //};

        private static readonly HttpClient _sseHttpClient = new HttpClient(new SocketsHttpHandler
        {
            PooledConnectionLifetime = Timeout.InfiniteTimeSpan, // Mantém conexão viva
            PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
            ResponseDrainTimeout = TimeSpan.FromSeconds(30),
            KeepAlivePingDelay = TimeSpan.FromSeconds(30), // Ping a cada 30s
            KeepAlivePingTimeout = TimeSpan.FromSeconds(30)
        })
        {
            Timeout = Timeout.InfiniteTimeSpan // SSE precisa de timeout infinito
        };


        private readonly string _baseUrl;

        public ApiService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        // Método para definir o token de autorização em AMBOS os clientes       

        public void SetAuthorizationHeader(string token)
        {
            if ( !string.IsNullOrEmpty(token) )
            {
                _sharedHttpClient.DefaultRequestHeaders.Remove("Authorization");
                _sharedHttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                _sseHttpClient.DefaultRequestHeaders.Remove("Authorization");
                _sseHttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                Debug.WriteLine($"[API Service] ✅ SetAuthorizationHeader chamado com token: {token.Substring(0, Math.Min(50, token.Length))}...");
            }
            else
            {
                Debug.WriteLine($"[API Service] ❌ SetAuthorizationHeader chamado com token vazio/nulo");
            }
        }

        // Método para remover o token de autorização de AMBOS os clientes
        public void ClearAuthorizationHeader()
        {
            _sharedHttpClient.DefaultRequestHeaders.Authorization = null;
            _sseHttpClient.DefaultRequestHeaders.Authorization = null;
        }

        public string BuildUrlWithQueryParams(string endpoint, Dictionary<string, string> parameters = null)
        {
            var url = $"{_baseUrl}/{endpoint}";

            if ( parameters != null && parameters.Count > 0 )
            {
                var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value)}"));
                url += $"?{queryString}";
            }

            return url;
        }

        // ✅ Retorna o HttpClient compartilhado para requisições normais
        public HttpClient GetHttpClient()
        {
            return _sharedHttpClient;
        }

        // ✅ Retorna o HttpClient específico para SSE
        public HttpClient GetSSEHttpClient()
        {
            return _sseHttpClient;
        }

        // ------------- MÉTODOS PARA FAZER REQUISIÇÕES HTTP ------------- //

        public async Task<T> GetAsync<T>(string endpoint, Dictionary<string, string> queryParams = null)
        {
            var url = BuildUrlWithQueryParams(endpoint, queryParams);
            var response = await _sharedHttpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"URL chamada: {url}");
            Debug.WriteLine($"JSON retornado: {json}");
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<string> GetJsonAsync(string endpoint, Dictionary<string, string> queryParams = null)
        {
            //Debug.WriteLine($"Chamando GET /{endpoint}");
            var url = BuildUrlWithQueryParams(endpoint, queryParams);
            Debug.WriteLine($"Chamando GET /{url}");
            var response = await _sharedHttpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Debug.WriteLine($"JSON retornado: {response}");
            return await response.Content.ReadAsStringAsync();
        }


        // Usar com: JToken {}
        public async Task<JToken> GetAsJTokenAsync(string endpoint, Dictionary<string, string> queryParams = null)
        {
            var json = await GetJsonAsync(endpoint, queryParams);
            return JToken.Parse(json); // ✅ Genérico para objeto/array
        }


        // Usar com: objeto {}
        public async Task<JObject> GetAsJObjectAsync(string endpoint, Dictionary<string, string> queryParams = null)
        {
            var json = await GetJsonAsync(endpoint, queryParams);
            return JObject.Parse(json);
        }        

        // Usar com: array []
        public async Task<JArray> GetAsJArrayAsync(string endpoint, Dictionary<string, string> queryParams = null)
        {
            var json = await GetJsonAsync(endpoint, queryParams);
            return JArray.Parse(json); 
        }

        // ------------------------------- FUNÇÃO DELETE COM PARAMETROS --------------------------------------//

        public async Task DeleteAsync(string endpoint, Dictionary<string, string> queryParams = null)
        {
            try
            {
                var url = BuildUrlWithQueryParams(endpoint, queryParams);
                Debug.WriteLine($"Excluindo no endpoint: {url}");
                var response = await _sharedHttpClient.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao excluir: {ex}");
                throw new Exception($"Erro ao excluir: {ex.Message}");
            }
        }

        // --------------------------------------------------------------------------------------------------//
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string fullUrl = $"{_baseUrl}/{endpoint}";

                // ✅ DEBUG: Verificar se o token existe
                Debug.WriteLine($"[API Service] Session.AccessToken existe? {!string.IsNullOrEmpty(Session.AccessToken)}");
                Debug.WriteLine($"[API Service] Session.AccessToken: {Session.AccessToken?.Substring(0, Math.Min(50, Session.AccessToken?.Length ?? 0))}...");

                // Adiciona token se disponível
                if ( !string.IsNullOrEmpty(Session.AccessToken) )
                {
                    _sharedHttpClient.DefaultRequestHeaders.Remove("Authorization");
                    _sharedHttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Session.AccessToken}");
                    Debug.WriteLine($"[API Service] ✅ Authorization Header adicionado");
                }
                else
                {
                    Debug.WriteLine($"[API Service] ❌ SEM TOKEN - Authorization Header NÃO adicionado");
                }

                // ✅ DEBUG: Verificar se o header foi adicionado
                var hasAuthHeader = _sharedHttpClient.DefaultRequestHeaders.Contains("Authorization");
                Debug.WriteLine($"[API Service] Header Authorization presente? {hasAuthHeader}");

                if ( hasAuthHeader )
                {
                    var authValue = _sharedHttpClient.DefaultRequestHeaders.GetValues("Authorization").FirstOrDefault();
                    Debug.WriteLine($"[API Service] Valor do Authorization: {authValue?.Substring(0, Math.Min(60, authValue?.Length ?? 0))}...");
                }

                Debug.WriteLine($"[API Service] Enviando POST para: {fullUrl}");
                Debug.WriteLine($"[API Service] Corpo da requisição: {json}");

                var response = await _sharedHttpClient.PostAsync(fullUrl, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"[API Service] Status: {response.StatusCode}");
                Debug.WriteLine($"[API Service] Resposta: {responseContent}");

                if ( response.IsSuccessStatusCode )
                {
                    return JsonConvert.DeserializeObject<TResponse>(responseContent);
                }
                else
                {
                    switch ( response.StatusCode )
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
                            throw new HttpRequestException($"HTTP {( int ) response.StatusCode}: {generalErrorMessage}");
                    }
                }
            }
            catch ( UnauthorizedAccessException )
            {
                throw;
            }
            catch ( ArgumentException )
            {
                throw;
            }
            catch ( FileNotFoundException )
            {
                throw;
            }
            catch ( HttpRequestException )
            {
                throw;
            }
            catch ( TaskCanceledException ex ) when ( ex.InnerException is TimeoutException )
            {
                throw new TimeoutException("A requisição expirou. Verifique sua conexão.");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"[API Service] Erro inesperado: {ex.Message}");
                throw new HttpRequestException($"Erro na comunicação com o servidor: {ex.Message}");
            }
        }


        // --------------------------------------------------------------------------------------------------//

        // Método genérico para requisições PATCH
        public async Task<TResponse> PatchAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string fullUrl = $"{_baseUrl}/{endpoint}";

                // ✅ DEBUG: Verificar se o token existe
                Debug.WriteLine($"[API Service] Session.AccessToken existe? {!string.IsNullOrEmpty(Session.AccessToken)}");

                // Adiciona token se disponível
                if ( !string.IsNullOrEmpty(Session.AccessToken) )
                {
                    _sharedHttpClient.DefaultRequestHeaders.Remove("Authorization");
                    _sharedHttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Session.AccessToken}");
                    Debug.WriteLine($"[API Service] ✅ Authorization Header adicionado");
                }
                else
                {
                    Debug.WriteLine($"[API Service] ❌ SEM TOKEN - Authorization Header NÃO adicionado");
                }

                Debug.WriteLine($"[API Service] Enviando PATCH para: {fullUrl}");
                Debug.WriteLine($"[API Service] Corpo da requisição: {json}");

                var response = await _sharedHttpClient.PatchAsync(fullUrl, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"[API Service] Status: {response.StatusCode}");
                Debug.WriteLine($"[API Service] Resposta: {responseContent}");

                if ( response.IsSuccessStatusCode )
                {
                    return JsonConvert.DeserializeObject<TResponse>(responseContent);
                }
                else
                {
                    switch ( response.StatusCode )
                    {
                        case HttpStatusCode.Unauthorized:
                            string authErrorMessage = ExtractApiErrorMessage(responseContent) ?? "Credenciais inválidas.";
                            throw new UnauthorizedAccessException(authErrorMessage);

                        case HttpStatusCode.Forbidden:
                            string forbiddenMessage = ExtractApiErrorMessage(responseContent) ?? "Acesso negado.";
                            throw new UnauthorizedAccessException(forbiddenMessage);

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
                            throw new HttpRequestException($"HTTP {( int ) response.StatusCode}: {generalErrorMessage}");
                    }
                }
            }
            catch ( UnauthorizedAccessException )
            {
                throw;
            }
            catch ( ArgumentException )
            {
                throw;
            }
            catch ( FileNotFoundException )
            {
                throw;
            }
            catch ( HttpRequestException )
            {
                throw;
            }
            catch ( TaskCanceledException ex ) when ( ex.InnerException is TimeoutException )
            {
                throw new TimeoutException("A requisição expirou. Verifique sua conexão.");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"[API Service] Erro inesperado: {ex.Message}");
                throw new HttpRequestException($"Erro na comunicação com o servidor: {ex.Message}");
            }
        }

        // -----------------------------------------  FUNÇÃO DELETE  - PatchAsync-----------------------------------------//
       
        public async Task<TResponse> DeleteAsync<TResponse>(string endpoint)
        {
            try
            {
                string fullUrl = $"{_baseUrl}/{endpoint}";

                // ✅ DEBUG: Verificar se o token existe
                Debug.WriteLine($"[API Service] Session.AccessToken existe? {!string.IsNullOrEmpty(Session.AccessToken)}");

                // Adiciona token se disponível
                if ( !string.IsNullOrEmpty(Session.AccessToken) )
                {
                    _sharedHttpClient.DefaultRequestHeaders.Remove("Authorization");
                    _sharedHttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Session.AccessToken}");
                    Debug.WriteLine($"[API Service] ✅ Authorization Header adicionado");
                }
                else
                {
                    Debug.WriteLine($"[API Service] ❌ SEM TOKEN - Authorization Header NÃO adicionado");
                }

                Debug.WriteLine($"[API Service] Enviando DELETE para: {fullUrl}");

                var response = await _sharedHttpClient.DeleteAsync(fullUrl);
                var responseContent = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"[API Service] Status: {response.StatusCode}");
                Debug.WriteLine($"[API Service] Resposta: {responseContent}");

                if ( response.IsSuccessStatusCode )
                {
                    return JsonConvert.DeserializeObject<TResponse>(responseContent);
                }
                else
                {
                    switch ( response.StatusCode )
                    {
                        case HttpStatusCode.Unauthorized:
                            string authErrorMessage = ExtractApiErrorMessage(responseContent) ?? "Credenciais inválidas.";
                            throw new UnauthorizedAccessException(authErrorMessage);

                        case HttpStatusCode.Forbidden:
                            string forbiddenMessage = ExtractApiErrorMessage(responseContent) ?? "Acesso negado.";
                            throw new UnauthorizedAccessException(forbiddenMessage);

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
                            throw new HttpRequestException($"HTTP {( int ) response.StatusCode}: {generalErrorMessage}");
                    }
                }
            }
            catch ( UnauthorizedAccessException )
            {
                throw;
            }
            catch ( ArgumentException )
            {
                throw;
            }
            catch ( FileNotFoundException )
            {
                throw;
            }
            catch ( HttpRequestException )
            {
                throw;
            }
            catch ( TaskCanceledException ex ) when ( ex.InnerException is TimeoutException )
            {
                throw new TimeoutException("A requisição expirou. Verifique sua conexão.");
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"[API Service] Erro inesperado: {ex.Message}");
                throw new HttpRequestException($"Erro na comunicação com o servidor: {ex.Message}");
            }
        }

        // --------------------------------------------------------------------------------------------------//


        private string ExtractApiErrorMessage(string responseContent)
        {
            try
            {
                if ( string.IsNullOrEmpty(responseContent) )
                    return null;

                Debug.WriteLine($"[API Service] Tentando extrair erro de: {responseContent}");

                var errorObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);

                if ( errorObject.ContainsKey("message") )
                {
                    string message = errorObject["message"].ToString();
                    Debug.WriteLine($"[API Service] Mensagem extraída: {message}");
                    return message;
                }

                if ( errorObject.ContainsKey("error") )
                {
                    return errorObject["error"].ToString();
                }

                if ( errorObject.ContainsKey("detail") )
                {
                    return errorObject["detail"].ToString();
                }

                return null;
            }
            catch ( JsonException ex )
            {
                Debug.WriteLine($"[API Service] Erro ao deserializar JSON de erro: {ex.Message}");

                if ( !string.IsNullOrEmpty(responseContent) && responseContent.Length < 500 )
                {
                    string cleanMessage = responseContent.Replace("<", "").Replace(">", "").Trim();
                    if ( !string.IsNullOrEmpty(cleanMessage) )
                    {
                        return cleanMessage;
                    }
                }

                return null;
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"[API Service] Erro inesperado ao extrair mensagem: {ex.Message}");
                return null;
            }
        }



        //RETIRAR DEPOIS ESSAS FUNÇÕES DESSA CLASSE E METER EM OUTRA CLASSE COM RESPOSABILIDADE ESPECÍFICA
        public async Task<TResponse> PostFileAsync<TResponse>(string endpoint, byte[] fileBytes, string fileName, Dictionary<string, string> additionalFormFields = null)
        {
            using ( var multipartContent = new MultipartFormDataContent() )
            {
                var fileContent = new ByteArrayContent(fileBytes);
                string fileExtension = Path.GetExtension(fileName).ToLowerInvariant();
                string contentType = "application/octet-stream";

                Debug.WriteLine("fileContent" + fileContent);
                Debug.WriteLine("fileExtension" + fileExtension);
                Debug.WriteLine("contentType" + contentType);

                switch ( fileExtension )
                {
                    case ".txt":
                        contentType = "text/plain";
                        break;
                    case ".csv":
                        contentType = "text/csv";
                        break;
                    case ".xml":
                        contentType = "application/xml";
                        break;
                }

                fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                multipartContent.Add(fileContent, "file", fileName);

                if ( additionalFormFields != null )
                {
                    foreach ( var field in additionalFormFields )
                    {
                        multipartContent.Add(new StringContent(field.Value), field.Key);
                    }
                }

                var url = $"{_baseUrl}/{endpoint}";
                Debug.WriteLine($"[API Service] Enviando POST (File) para: {url}");
                Debug.WriteLine($"[API Service] Nome do arquivo: {fileName}");

                var response = await _sharedHttpClient.PostAsync(url, multipartContent);
                response.EnsureSuccessStatusCode();
                var responseJson = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"[API Service] Resposta (File) em ApiService: {responseJson}");
                return JsonConvert.DeserializeObject<TResponse>(responseJson);
            }
        }
       
    }
}