using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Services
{
    internal class DevedorService
    {
        private readonly ApiService _apiService;

        // HttpClient separado para SSE
        private readonly HttpClient _sseClient;

        // Variáveis de estado da conexão SSE
        private CancellationTokenSource _sseCancel;

        // Evento para o Form se inscrever
        public event LogHandler OnLogReceived;

        //Delegate para logs (para comunicação limpa com o Form)
        public delegate void LogHandler(string logLevel, string message, DateTime timestamp, string cnpj = null, string email = null);

        public DevedorService(ApiService apiService)
        {
            _apiService = apiService;
            // ✅ Usa o HttpClient específico para SSE (separado do HttpClient principal)
            _sseClient = _apiService.GetSSEHttpClient();
        }

        // ROTA: devedor/email-search/start - Cria a sessão
        public async Task<JObject> CreateEmailSearchSession()
        {
            try
            {
                return await _apiService.GetAsJObjectAsync("devedor/email-search/start");
            }
            catch ( Exception ex )
            {
                throw new Exception($"Erro ao criar sessão de busca de emails: {ex.Message}");
            }
        }

        // ROTA: devedor/email-search/start/{sessionId} - Inicia a busca
        public async Task<JObject> StartEmailSearch(string sessionId)
        {
            try
            {
                return await _apiService.PostAsync<object, JObject>($"devedor/email-search/start/{sessionId}", new { });
            }
            catch ( Exception ex )
            {
                throw new Exception($"Erro ao iniciar busca de emails: {ex.Message}");
            }
        }

        // ROTA: devedor/email-search/logs/{sessionId} - Conecta ao SSE
        public async Task<(HttpResponseMessage Response, CancellationTokenSource CancelSource)> ConnectToSSE(string currentSessionId)
        {
            if ( string.IsNullOrEmpty(currentSessionId) )
            {
                MessageBox.Show("Primeiro, crie uma sessão!");
                return (null, null);
            }

            _sseCancel = new CancellationTokenSource();

            try
            {
                var fullUrl = _apiService.BuildUrlWithQueryParams($"devedor/email-search/logs/{currentSessionId}");

                var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);

                // ✅ Headers SSE
                request.Headers.Add("Accept", "text/event-stream");
                request.Headers.Add("Cache-Control", "no-cache");
                request.Headers.Add("Connection", "keep-alive");

                Debug.WriteLine($"[DevedorService] Conectando SSE: {fullUrl}");

                // ✅ IMPORTANTE: ResponseHeadersRead para não bufferizar toda resposta
                var response = await _sseClient.SendAsync(
                    request,
                    HttpCompletionOption.ResponseHeadersRead,
                    _sseCancel.Token
                );

                if ( response.IsSuccessStatusCode )
                {
                    Debug.WriteLine($"[DevedorService] ✅ Conexão SSE estabelecida para sessão {currentSessionId}");
                    return (response, _sseCancel);
                }
                else
                {
                    Debug.WriteLine($"[DevedorService] ❌ Falha na conexão SSE. Status: {response.StatusCode}");
                    throw new HttpRequestException($"Falha na conexão SSE. Status: {response.StatusCode}");
                }
            }
            catch ( OperationCanceledException )
            {
                Debug.WriteLine("[DevedorService] Conexão SSE cancelada pelo usuário");
                OnLogReceived?.Invoke("warn", "Conexão cancelada", DateTime.Now);
                return (null, null);
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"[DevedorService] Erro na conexão SSE: {ex}");
                OnLogReceived?.Invoke("error", $"FATAL: Erro na conexão: {ex.Message}", DateTime.Now);
                return (null, null);
            }
        }

        // ✅ Cancela apenas a conexão SSE (não afeta o HttpClient principal)
        public void CancelSSEConnection()
        {
            try
            {
                Debug.WriteLine("[DevedorService] Cancelando conexão SSE...");
                _sseCancel?.Cancel();
                _sseCancel?.Dispose();
                _sseCancel = null;
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"[DevedorService] Erro ao cancelar SSE: {ex.Message}");
            }
        }

        // Cancela a busca no backend
        public async Task<JObject> CancelEmailSearch(string sessionId)
        {
            try
            {
                Debug.WriteLine($"[DevedorService] Cancelando busca para sessão {sessionId}");
                return await _apiService.PostAsync<object, JObject>($"devedor/email-search/cancel/{sessionId}", new { });
            }
            catch ( Exception ex )
            {
                throw new Exception($"Erro ao cancelar busca de emails: {ex.Message}");
            }
        }

        // ✅ Método completo para cancelar tanto a conexão quanto o processamento
        public async Task CancelSSE(string sessionId)
        {
            try
            {
                // 1. Cancela o token da conexão SSE (para de receber eventos)
                CancelSSEConnection();

                // 2. Notifica o backend para parar o processamento
                if ( !string.IsNullOrEmpty(sessionId) )
                {
                    await CancelEmailSearch(sessionId);
                }

                OnLogReceived?.Invoke("info", "Busca cancelada com sucesso.", DateTime.Now);
            }
            catch ( Exception ex )
            {
                OnLogReceived?.Invoke("error", $"Erro ao cancelar busca: {ex.Message}", DateTime.Now);
            }
        }

        // Método que processa a stream do SSE
        public async Task ProcessSSEStream(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            using var stream = await response.Content.ReadAsStreamAsync();
            using var reader = new System.IO.StreamReader(stream);

            string line;
            string eventType = null;
            StringBuilder data = new StringBuilder();

            try
            {
                Debug.WriteLine("[DevedorService] Iniciando leitura do stream SSE...");

                while ( !cancellationToken.IsCancellationRequested && ( line = await reader.ReadLineAsync() ) != null )
                {
                    if ( line.StartsWith("event:") )
                    {
                        eventType = line.Substring(6).Trim();
                    }
                    else if ( line.StartsWith("data:") )
                    {
                        data.AppendLine(line.Substring(5).Trim());
                    }
                    else if ( string.IsNullOrEmpty(line) )
                    {
                        if ( !string.IsNullOrEmpty(eventType) && data.Length > 0 )
                        {
                            ProcessSSEEvent(eventType, data.ToString().Trim());
                        }
                        eventType = null;
                        data.Clear();
                    }
                }

                Debug.WriteLine("[DevedorService] Stream SSE encerrado");

                // ✅ NÃO dispara session_ended aqui - backend já disparou
                // O evento session_ended vem do SSE, não precisa disparar manualmente
            }
            catch ( OperationCanceledException )
            {
                Debug.WriteLine("[DevedorService] Stream SSE cancelado");

                // ✅ Só dispara se callback existe
                if ( OnLogReceived != null )
                {
                    try
                    {
                        OnLogReceived.Invoke("warn", "Busca cancelada", DateTime.Now);
                    }
                    catch
                    {
                        // Form pode ter sido fechado, ignora
                    }
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"[DevedorService] Erro no stream: {ex}");

                // ✅ Só dispara se callback existe
                if ( OnLogReceived != null )
                {
                    try
                    {
                        OnLogReceived.Invoke("error", $"FATAL: {ex.Message}", DateTime.Now);
                    }
                    catch
                    {
                        // Form pode ter sido fechado, ignora
                    }   
                }
            }
            finally
            {
                reader?.Dispose();
                stream?.Dispose();
            }
        }



        // Método que desserializa e dispara o evento de Log
        private void ProcessSSEEvent(string eventType, string jsonData)
        {
            try
            {
                // ✅ VERIFICAR se ainda tem listener antes de disparar evento
                if ( OnLogReceived == null )
                {
                    Debug.WriteLine($"[DevedorService] Nenhum listener registrado, ignorando evento: {eventType}");
                    return;
                }

                var eventData = JObject.Parse(jsonData);

                switch ( eventType )
                {
                    case "connection":
                        OnLogReceived.Invoke(
                            "connection",
                            eventData["message"]?.ToString() ?? "Conectado",
                            DateTime.Parse(eventData["timestamp"]?.ToString() ?? DateTime.Now.ToString())
                        );
                        break;

                    case "ready":
                        OnLogReceived.Invoke(
                            "ready",
                            eventData["message"]?.ToString() ?? "Pronto",
                            DateTime.Parse(eventData["timestamp"]?.ToString() ?? DateTime.Now.ToString())
                        );
                        break;

                    case "session_ended":
                        OnLogReceived.Invoke(
                            "session_ended",
                            eventData["message"]?.ToString() ?? "Sessão encerrada",
                            DateTime.Parse(eventData["timestamp"]?.ToString() ?? DateTime.Now.ToString())
                        );
                        break;

                    case "error":
                        OnLogReceived.Invoke(
                            "error",
                            eventData["message"]?.ToString() ?? "Erro",
                            DateTime.Parse(eventData["timestamp"]?.ToString() ?? DateTime.Now.ToString())
                        );
                        break;

                    case "log":
                        var logData = ( JObject ) eventData["log"];
                        OnLogReceived.Invoke(
                            logData["level"]?.ToString() ?? "log",
                            logData["message"]?.ToString() ?? "",
                            DateTime.Parse(logData["timestamp"]?.ToString() ?? DateTime.Now.ToString()),
                            logData["cnpj"]?.ToString(),
                            logData["email"]?.ToString()
                        );
                        break;

                    case "heartbeat":
                        // Heartbeat - não precisa logar
                        Debug.WriteLine("[DevedorService] ❤️ Heartbeat");
                        break;

                    default:
                        Debug.WriteLine($"[DevedorService] Evento desconhecido: {eventType}");
                        break;
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"[DevedorService] Erro ao processar evento: {ex.Message}");

                // ✅ Só tenta disparar evento se callback existe
                if ( OnLogReceived != null )
                {
                    try
                    {
                        OnLogReceived.Invoke("error", $"Erro ao processar evento: {ex.Message}", DateTime.Now);
                    }
                    catch ( Exception invokeEx )
                    {
                        Debug.WriteLine($"[DevedorService] Erro ao invocar callback: {invokeEx.Message}");
                    }
                }
            }
        }
    }
}