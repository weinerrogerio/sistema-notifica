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

            // ✅ Cria um novo token de cancelamento a cada conexão
            _sseCancel = new CancellationTokenSource();

            try
            {
                var fullUrl = _apiService.BuildUrlWithQueryParams($"devedor/email-search/logs/{currentSessionId}");

                var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);

                // ✅ Headers específicos para SSE
                request.Headers.Add("Accept", "text/event-stream");
                request.Headers.Add("Cache-Control", "no-cache");
                request.Headers.Add("Connection", "keep-alive");

                // ✅ Usa o HttpClient específico para SSE
                var response = await _sseClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, _sseCancel.Token);

                if ( response.IsSuccessStatusCode )
                {
                    Debug.WriteLine($"[DevedorService] Conexão SSE estabelecida para sessão {currentSessionId}");
                    return (response, _sseCancel);
                }
                else
                {
                    throw new HttpRequestException($"Falha na conexão SSE. Status: {response.StatusCode}");
                }
            }
            catch ( Exception ex )
            {
                OnLogReceived?.Invoke("error", $"Erro na conexão SSE: {ex.Message}", DateTime.Now);
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
                    else if ( string.IsNullOrEmpty(line) ) // Linha vazia indica fim do evento
                    {
                        if ( !string.IsNullOrEmpty(eventType) && data.Length > 0 )
                        {
                            ProcessSSEEvent(eventType, data.ToString().Trim());
                        }
                        eventType = null;
                        data.Clear();
                    }
                }

                Debug.WriteLine("[DevedorService] Stream SSE encerrado.");
            }
            catch ( OperationCanceledException )
            {
                Debug.WriteLine("[DevedorService] Stream SSE cancelado pelo usuário.");
                OnLogReceived?.Invoke("session_ended", "Busca de emails cancelada pelo usuário.", DateTime.Now);
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"[DevedorService] Erro fatal ao ler stream SSE: {ex}");
                OnLogReceived?.Invoke("error", $"Erro fatal ao ler stream SSE: {ex.Message}", DateTime.Now);
            }
            finally
            {
                // ✅ Limpa recursos da stream
                reader?.Dispose();
                stream?.Dispose();
            }
        }

        // Método que desserializa e dispara o evento de Log
        private void ProcessSSEEvent(string eventType, string jsonData)
        {
            try
            {
                var eventData = JObject.Parse(jsonData);

                if ( OnLogReceived == null ) return;

                switch ( eventType )
                {
                    case "connection":
                    case "ready":
                    case "session_ended":
                    case "error":
                        OnLogReceived.Invoke(
                            eventType,
                            eventData["message"].ToString(),
                            DateTime.Parse(eventData["timestamp"].ToString())
                        );
                        break;

                    case "log":
                        var logData = ( JObject ) eventData["log"];
                        OnLogReceived.Invoke(
                            logData["level"].ToString(),
                            logData["message"].ToString(),
                            DateTime.Parse(logData["timestamp"].ToString()),
                            logData.ContainsKey("cnpj") ? logData["cnpj"].ToString() : null,
                            logData.ContainsKey("email") ? logData["email"].ToString() : null
                        );
                        break;
                }
            }
            catch ( Exception ex )
            {
                OnLogReceived?.Invoke("error", $"Erro ao desserializar/processar evento SSE: {ex.Message}", DateTime.Now);
            }
        }
    }
}