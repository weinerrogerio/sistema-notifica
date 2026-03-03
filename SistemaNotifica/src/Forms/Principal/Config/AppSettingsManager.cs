using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Forms.Principal.Config
{

    public static class AppSettingsManager
    {
        private static readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

        /// <summary>
        /// Lê a URL base da API salva no appsettings.json.
        /// Lança exceção se o arquivo não existir ou a URL estiver vazia/ausente.
        /// </summary>
        public static string GetBaseApiUrl()
        {
            if ( !File.Exists(_filePath) )
            {
                // Em vez de travar, podemos apenas retornar vazio ou criar o arquivo básico
                return string.Empty;          }

            try
            {
                string json = File.ReadAllText(_filePath);
                JsonNode? root = JsonNode.Parse(json);

                // Tentamos pegar o valor. Se não existir, 'url' será null.
                string? url = root?["ApiSettings"]?["BaseUrl"]?.GetValue<string>();

                // Retornamos a url encontrada ou uma string vazia caso seja null
                return url ?? string.Empty;
            }
            catch
            {
                // Se o JSON estiver corrompido, retorna vazio para não travar o início
                return string.Empty;
            }
        }

        /// <summary>
        /// Salva a URL base da API no appsettings.json.
        /// </summary>
        public static void SaveBaseApiUrl(string url)
        {
            if ( string.IsNullOrWhiteSpace(url) )
                throw new ArgumentException("A URL não pode ser vazia.", nameof(url));

            JsonNode root;

            if ( File.Exists(_filePath) )
            {
                string existingJson = File.ReadAllText(_filePath);
                root = JsonNode.Parse(existingJson) ?? new JsonObject();
            }
            else
            {
                root = new JsonObject();
            }

            if ( root["ApiSettings"] == null )
                root["ApiSettings"] = new JsonObject();

            root["ApiSettings"]!["BaseUrl"] = url.Trim();

            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(_filePath, root.ToJsonString(options));
        }
    }

}
