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

        // Variáveis de estado da conexão SSE
        private CancellationTokenSource _sseCancel;
        private HttpClient _sseClient;
        // Evento para o Form se inscrever
        public event LogHandler OnLogReceived;
        //Delegate para logs (para comunicação limpa com o Form)
        public delegate void LogHandler(string logLevel, string message, DateTime timestamp, string cnpj = null, string email = null);

        public DevedorService(ApiService apiService)
        {
            _apiService = apiService;
            // O serviço de notificação agora lida com o seu próprio HttpClient para SSE
            // para evitar conflitos com o HttpClient principal do ApiService
            _sseClient = _apiService.GetHttpClient();
        }


        // ROTA: devedor/email-search/start - Cria a sessão
        public async Task<JObject> CreateEmailSearchSession()
        {
            try
            {
                // Responsabilidade: Definir o endpoint
                return await _apiService.GetAsJObjectAsync("devedor/email-search/start");
            }
            catch ( Exception ex )
            {
                // Tratamento de erros encapsulado e mais limpo
                throw new Exception($"Erro ao criar sessão de busca de emails: {ex.Message}");
            }
        }

        // ROTA: devedor/email-search/start/{sessionId} - Inicia a busca
        public async Task<JObject> StartEmailSearch(string sessionId)
        {
            try
            {
                // Responsabilidade: Definir o endpoint e o corpo da requisição
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

            // Cria um novo token de cancelamento a cada conexão
            _sseCancel = new CancellationTokenSource();

            try
            {
                // Responsabilidade: Construir a URL do SSE
                var fullUrl = _apiService.BuildUrlWithQueryParams($"devedor/email-search/logs/{currentSessionId}");

                var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);
                // Headers específicos para SSE
                request.Headers.Add("Accept", "text/event-stream");
                request.Headers.Add("Cache-Control", "no-cache");

                var response = await _sseClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, _sseCancel.Token);

                if ( response.IsSuccessStatusCode )
                {
                    // Retorna a resposta e o token de cancelamento para o Form gerenciar o loop do stream
                    return (response, _sseCancel);
                }
                else
                {
                    throw new HttpRequestException($"Falha na conexão SSE. Status: {response.StatusCode}");
                }
            }
            catch ( Exception ex )
            {
                // Dispara o evento para o Form registrar o erro
                OnLogReceived?.Invoke("error", $"Erro na conexão SSE: {ex.Message}", DateTime.Now);
                return (null, null);
            }
        }

        // Novo método para o FormNotification cancelar o SSE
        public void CancelSSE()
        {
            _sseCancel?.Cancel();
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
                            // Processa o evento e dispara o delegate para o Form
                            ProcessSSEEvent(eventType, data.ToString().Trim());
                        }
                        eventType = null;
                        data.Clear();
                    }
                }
            }
            catch ( OperationCanceledException )
            {
                // Cancelamento esperado
                OnLogReceived?.Invoke("session_ended", "Busca de emails cancelada pelo usuário.", DateTime.Now);
            }
            catch ( Exception ex )
            {
                // Erro inesperado
                OnLogReceived?.Invoke("error", $"Erro fatal ao ler stream SSE: {ex.Message}", DateTime.Now);
            }
        }

        // Método que desserializa e dispara o evento de Log
        private void ProcessSSEEvent(string eventType, string jsonData)
        {
            try
            {
                // Usando Newtonsoft.Json para compatibilidade com JObject
                var eventData = JObject.Parse(jsonData);

                // Disparar o evento para o FormNotification com os dados tratados
                if ( OnLogReceived == null ) return;

                switch ( eventType )
                {
                    case "connection":
                    case "ready":
                    case "session_ended":
                    case "error":
                        OnLogReceived.Invoke(eventType, eventData["message"].ToString(),
                            DateTime.Parse(eventData["timestamp"].ToString()));
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