using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Models
{
    public class EmailTemplate
    {
        public int Id { get; set; }
        public required string NomeArquivo { get; set; }
        public string? Descricao { get; set; }
        public string? ConteudoHtml { get; set; }
        public bool EhPadrao { get; set; } = false;
        public bool Ativo { get; set; } = true;
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }        
        public long TamanhoArquivo { get; set; }
    }

    public class UploadTemplateRequest
    {
        public required string NomeArquivo { get; set; }
        public string? Descricao { get; set; }
        public required string ConteudoHtml { get; set; }
    }

    public class PreviewRequest
    {
        public required string ConteudoHtml { get; set; }
        public Dictionary<string, object>? DadosTeste { get; set; }
    }
}
