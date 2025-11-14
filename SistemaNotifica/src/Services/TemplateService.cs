using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

                using ( var form = new MultipartFormDataContent() )
                {
                    var fileContent = new ByteArrayContent(fileBytes);
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/html");

                    form.Add(fileContent, "file", nomeArquivo);

                    if ( !string.IsNullOrEmpty(descricao) )
                    {
                        form.Add(new StringContent(descricao), "descricao");
                    }

                    var httpClient = _apiService.GetHttpClient();
                    var response = await httpClient.PostAsync(
                        _apiService.BuildUrlWithQueryParams("template/upload"),
                        form
                    );

                    // ✅ Se deu erro, processar a mensagem
                    if ( !response.IsSuccessStatusCode )
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();

                        // Tentar extrair mensagem formatada
                        var formattedError = FormatTemplateError(errorContent);

                        // Lançar exceção com mensagem formatada
                        throw new Exception(formattedError);
                    }

                    var responseJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EmailTemplate>(responseJson);
                }
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro no upload: {ex}");
                throw; // Repassa a exceção
            }
        }

        private string FormatTemplateError(string jsonError)
        {
            try
            {
                var error = JObject.Parse(jsonError);

                // Verifica se tem a estrutura de erro de validação
                if ( error["erros"] == null )
                {
                    // Erro genérico
                    return error["message"]?.ToString() ?? "Erro ao processar template";
                }

                var sb = new StringBuilder();

                // Cabeçalho
                sb.AppendLine("❌ ERRO DE VALIDAÇÃO DO TEMPLATE");
                sb.AppendLine();
                sb.AppendLine(error["message"]?.ToString() ?? "O template contém erros.");
                sb.AppendLine();
                sb.AppendLine("═══════════════════════════════════════════════════════════");
                sb.AppendLine();

                var erros = error["erros"];
                int errorNumber = 1;

                // Função auxiliar para processar seções de erro
                Action<JToken, string, string> ProcessarSecaoErro = (token, titulo, prefixoVariavel) =>
                {
                    if ( token == null || ( token.Type == JTokenType.Object && !token.HasValues ) )
                        return;

                    sb.AppendLine($"{errorNumber}. {titulo}:");

                    if ( token.Type == JTokenType.Object ) // Caso 1: Estrutura complexa (como o original esperava)
                    {
                        var erroObj = ( JObject ) token;
                        var mensagem = erroObj["mensagem"]?.ToString();
                        var variaveis = erroObj["variaveis"] as JArray;

                        if ( !string.IsNullOrEmpty(mensagem) )
                        {
                            sb.AppendLine($"   {mensagem}");
                            sb.AppendLine();
                        }

                        if ( variaveis != null && variaveis.Count > 0 )
                        {
                            foreach ( var v in variaveis )
                            {
                                sb.AppendLine($"      • {prefixoVariavel}{{{v}}}");
                            }
                        }
                    }
                    else if ( token.Type == JTokenType.String ) // Caso 2: Estrutura simples (string, como a API está enviando)
                    {
                        sb.AppendLine($"   {token.ToString()}");
                    }

                    sb.AppendLine();
                    errorNumber++;
                };

                // ============================================
                // 1. SINTAXE INCORRETA (${...})
                // ============================================
                ProcessarSecaoErro(erros["sintaxeInvalida"], "SINTAXE INCORRETA", "$");

                // ============================================
                // 2. HELPERS/FUNÇÕES NÃO PERMITIDAS
                // ============================================
                ProcessarSecaoErro(erros["helpersInvalidos"], "FUNÇÕES NÃO PERMITIDAS", "{{");

                // ============================================
                // 3. VARIÁVEIS INVÁLIDAS
                // ============================================
                ProcessarSecaoErro(erros["placeholdersInvalidos"], "VARIÁVEIS INVÁLIDAS", "{{");


                sb.AppendLine("═══════════════════════════════════════════════════════════");
                sb.AppendLine();

                // ============================================
                // LEGENDA DE VARIÁVEIS VÁLIDAS
                // ============================================
                var placeholdersValidos = error["placeholdersValidos"] as JArray;
                var descriptions = error["placeholderDescriptions"] as JObject;

                if ( placeholdersValidos != null && placeholdersValidos.Count > 0 )
                {
                    sb.AppendLine("✅ VARIÁVEIS VÁLIDAS:");
                    sb.AppendLine();

                  

                    foreach ( var placeholder in placeholdersValidos )
                    {
                        

                        string placeholderKey = placeholder.ToString();
                        string description = placeholderKey;

                        // Busca descrição amigável se existir
                        if ( descriptions != null && descriptions[placeholderKey] != null )
                        {
                            // Acessa o valor da propriedade de forma segura
                            description = descriptions.Value<string>(placeholderKey) ?? placeholderKey;
                        }

                        sb.AppendLine($"   • {description}: {{{{{placeholderKey}}}}}");
                        
                    }
                }

                return sb.ToString();
            }
            catch ( Exception ex )
            {
                Debug.WriteLine($"Erro ao formatar mensagem de erro principal: {ex.Message}");

                string formattedFallbackJson = jsonError; // Por padrão, o texto bruto
                try
                {
                    // Tenta formatar (pretty-print) o JSON bruto
                    var parsedJson = JToken.Parse(jsonError);
                    formattedFallbackJson = parsedJson.ToString(Formatting.Indented);
                }
                catch ( Exception formatEx )
                {
                    Debug.WriteLine($"Erro ao tentar formatar JSON de fallback: {formatEx.Message}");
                }

                // Retorna a mensagem simples + o JSON formatado
                return $"Erro ao validar template. Verifique a sintaxe e as variáveis utilizadas.{Environment.NewLine}{Environment.NewLine}{formattedFallbackJson}";
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

        
        // Exclui um template se del===true --> se del===false apenas marca como inativo        
        public async Task DeleteTemplateAsync(int id, bool del=false)
        {
            try
            {
                // 1. Define o endpoint base
                string endpoint = $"template/{id}";
                // 2. Adiciona o query parameter 'fisico=true' se 'del' for true
                if ( del )
                {
                    // A API NestJS espera a string 'true'
                    endpoint += "?delete=true";
                }
                Debug.WriteLine($"Chamando DELETE /{endpoint}");

                // 3. Chama o ApiService com a URL já montada (com ou sem o query parameter)
                await _apiService.DeleteAsync(endpoint);
            }
            catch ( Exception ex )
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