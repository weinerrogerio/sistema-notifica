using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaNotifica.src.Utils
{
    internal class Format
    {
        // Método puramente funcional: Recebe string -> Devolve data formatada
        public static string ParaData(string dataString)
        {
            if ( string.IsNullOrEmpty(dataString) )
                return string.Empty;

            try
            {
                if ( DateTime.TryParse(dataString, out DateTime data) )
                {
                    return data.ToString("dd/MM/yyyy HH:mm");
                }
                return dataString;
            }
            catch
            {
                return dataString;
            }
        }

        public static string ParaValor(string valorString)
        {
            if ( string.IsNullOrEmpty(valorString) )
                return "R$ 0,00";

            try
            {
                if ( decimal.TryParse(valorString, out decimal valor) )
                {
                    decimal valorEmReais = valor / 100;
                    return valorEmReais.ToString("C2");
                }
                return valorString;
            }
            catch
            {
                return valorString;
            }
        }

        public static string ParaDocumento(string documento)
        {
            if ( string.IsNullOrEmpty(documento) )
                return string.Empty;

            // Remove tudo que não é dígito
            documento = Regex.Replace(documento, @"[^\d]", "");

            try
            {
                if ( documento.Length == 11 )
                {
                    return Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00");
                }
                else if ( documento.Length == 14 )
                {
                    return Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
                }
            }
            catch
            {
                // Se falhar a conversão (ex: número muito grande), retorna original
                return documento;
            }

            return documento;
        }
    }
}