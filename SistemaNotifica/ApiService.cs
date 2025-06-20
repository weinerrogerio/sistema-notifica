using System.Text;
using Newtonsoft.Json;

namespace SistemaNotifica
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiService(string baseUrl = "http://localhost:3000")
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        // Método para login
        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            try
            {
                var loginData = new
                {
                    nome = username,
                    password = password
                };

                var json = JsonConvert.SerializeObject(loginData);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/auth/login", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<LoginResponse>(responseContent);
                }
                else
                {
                    throw new Exception($"Erro no login: {responseContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao conectar com o servidor: {ex.Message}");
            }
        }

        // Método para buscar todos os usuários
        public async Task<List<Usuario>> GetUsuariosAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetAsync($"{_baseUrl}/auth/login");
                Console.WriteLine(" response!", response);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<Usuario>>(responseContent);
                }
                else
                {
                    throw new Exception($"Erro ao buscar usuários: {responseContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar usuários: {ex.Message}");
            }
        }

        // Método para criar usuário
        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var json = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/users", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Usuario>(responseContent);
                }
                else
                {
                    throw new Exception($"Erro ao criar usuário: {responseContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar usuário: {ex.Message}");
            }
        }

        // Método para atualizar usuário
        public async Task<Usuario> UpdateUsuarioAsync(string id, Usuario usuario, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var json = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PatchAsync($"{_baseUrl}/users/{id}", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Usuario>(responseContent);
                }
                else
                {
                    throw new Exception($"Erro ao atualizar usuário: {responseContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar usuário: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }

    // Classes para deserialização
    public class LoginResponse
    {
        public string Token { get; set; }
        public Usuario User { get; set; }
    }




}