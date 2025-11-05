using Newtonsoft.Json;
using SistemaNotifica.src.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Services
{
    internal class TemplateService
    {
        private readonly ApiService _apiService;

        public TemplateService(ApiService apiService)
        {
            _apiService = apiService;
        }

        /// <summary>
        /// Obtém todos os templates disponíveis
        /// </summary>
        public async Task<List<EmailTemplate>> GetTemplatesAsync()
        {
            try
            {
                Debug.WriteLine("Chamando GET /template");
                return await _apiService.GetAsync<List<EmailTemplate>>("template")
                       ?? new List<EmailTemplate>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro em GetTemplatesAsync: {ex}");
                throw new Exception($"Erro ao buscar templates: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtém um template específico por ID
        /// </summary>
        public async Task<EmailTemplate> GetTemplateAsync(int id)
        {
            try
            {
                Debug.WriteLine($"Chamando GET /template/{id}");
                return await _apiService.GetAsync<EmailTemplate>($"template/{id}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro em GetTemplateAsync({id}): {ex}");
                throw new Exception($"Erro ao buscar template: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtém o conteúdo HTML de um template
        /// </summary>
        public async Task<string> GetTemplateContentAsync(int id)
        {
            try
            {
                Debug.WriteLine($"Chamando GET /template/{id}/conteudo");
                return await _apiService.GetJsonAsync($"template/{id}/conteudo");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro em GetTemplateContentAsync({id}): {ex}");
                throw new Exception($"Erro ao buscar conteúdo do template: {ex.Message}");
            }
        }

        
        // Obtém o template marcado como padrão, se não tiver pdrão configurado, retornar null
        public async Task<EmailTemplate?> GetDefaultTemplateAsync()
        {
            try
            {
                Debug.WriteLine("Chamando GET /template/padrao");
                return await _apiService.GetAsync<EmailTemplate>("template/padrao");
            }
            catch (HttpRequestException ex) when (ex.Message.Contains("404") || ex.Message.Contains("NotFound"))
            {
                Debug.WriteLine("Nenhum template padrão configurado");
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro em GetDefaultTemplateAsync: {ex}");
                throw new Exception($"Erro ao buscar template padrão: {ex.Message}");
            }
        }
                
        /// Faz upload de um novo template HTML
        public async Task<EmailTemplate> UploadTemplateAsync(byte[] fileBytes, string nomeArquivo, string descricao = null)
        {
            try
            {
                Debug.WriteLine($"Fazendo upload: {nomeArquivo}");

                using (var form = new MultipartFormDataContent())
                {
                    var fileContent = new ByteArrayContent(fileBytes);
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/html");

                    form.Add(fileContent, "file", nomeArquivo);

                    if (!string.IsNullOrEmpty(descricao))
                    {
                        form.Add(new StringContent(descricao), "descricao");
                    }

                    var httpClient = _apiService.GetHttpClient();
                    var response = await httpClient.PostAsync(
                        _apiService.BuildUrlWithQueryParams("template/upload"),
                        form
                    );

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

        /// <summary>
        /// Define um template como padrão
        /// </summary>
        public async Task SetTemplatePadraoAsync(int id)
        {
            try
            {
                Debug.WriteLine($"Definindo template {id} como padrão");

                var httpClient = _apiService.GetHttpClient();
                var response = await httpClient.PostAsync(
                    _apiService.BuildUrlWithQueryParams($"template/{id}/set-padrao"),
                    null
                );

                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao definir padrão: {ex}");
                throw new Exception($"Erro ao definir template padrão: {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui um template
        /// </summary>
        public async Task DeleteTemplateAsync(int id)
        {
            try
            {
                Debug.WriteLine($"Excluindo template {id}");
                await _apiService.DeleteAsync($"template/{id}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao excluir: {ex}");
                throw new Exception($"Erro ao excluir template: {ex.Message}");
            }
        }

        /// <summary>
        /// Processa um template HTML substituindo placeholders pelos dados fornecidos
        /// </summary>
        /// <param name="conteudoHtml">Conteúdo HTML do template</param>
        /// <param name="dados">Dicionário com os dados para substituição</param>
        /// <returns>HTML processado com os dados substituídos</returns>
        public string ProcessarTemplate(string conteudoHtml, Dictionary<string, object> dados)
        {
            try
            {
                var htmlProcessado = conteudoHtml;

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
                return conteudoHtml;
            }
        }
    }
}