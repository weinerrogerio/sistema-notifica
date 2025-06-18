using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SistemaNotifica.src.Models
{
    public class EmailTemplate
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nomeArquivo")]
        public string NomeArquivo { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("conteudoHtml")]
        public string ConteudoHtml { get; set; }

        [JsonProperty("tamanhoArquivo")]
        public long TamanhoArquivo { get; set; }

        [JsonProperty("tipoMime")]
        public string TipoMime { get; set; }

        [JsonProperty("hashConteudo")]
        public string HashConteudo { get; set; }

        [JsonProperty("ehPadrao")]
        public bool EhPadrao { get; set; } = false;

        [JsonProperty("ativo")]
        public bool Ativo { get; set; } = true;

        [JsonProperty("criadoEm")]
        public DateTime CriadoEm { get; set; }

        [JsonProperty("atualizadoEm")]
        public DateTime AtualizadoEm { get; set; }
    }

    public class UploadTemplateRequest
    {
        public string NomeArquivo { get; set; }
        public string Descricao { get; set; }
        public string ConteudoHtml { get; set; }
    }

    public class PreviewRequest
    {
        public string ConteudoHtml { get; set; }
        public Dictionary<string, object> DadosTeste { get; set; }
    }

    public class PreviewResponse
    {
        [JsonProperty("htmlProcessado")]
        public string HtmlProcessado { get; set; }
    }
}