using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace BoxBack.Infra.Data.Extensions
{
    public static class StringHelpers
    {
        public static string ToUpperFirstLetter(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            // convert to char array of the string
            char[] letters = source.ToCharArray();
            
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            
            // return the array made of the new char array
            return new string(letters);
        }
        public static string RemoverAcentuacao(this string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
        public static string ExtractDetentoIpen(string text)
        {
            if (text == null)
                return "Favor informar uma string para obter o ipen do detento";
            
            var ipen = text.Substring(0, 6);

            return ipen.Trim(); 
        }
        public static string ExtractDetentoNome(string text)
        {
            if (text == null)
                return "Favor informar uma string para obter o nome do detento";
            
            var positionLastCar = text.Count();
            var nomeLeng = positionLastCar - 7;
            var nome = text.Substring(7, nomeLeng);

            return nome.Trim(); 
        }
        public static bool HasBar(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var a = input[i];

                if (input[i].Equals('/'))
                {
                    return true;
                }
            }

            return false;
        }
        public static bool HasData(string input)
        {
            if(input.Contains("Data"))
            {
                return true;
            }

            return false;
        }
        public static Guid? ExtractTenantId(string tenantId)
        {
            if (string.IsNullOrEmpty(tenantId))
                return null;

            Regex tenantIdRE = new Regex(@"[0-9 a-z A-Z]{8}-[0-9 a-z A-Z]{4}-[0-9 a-z A-Z]{4}-[0-9 a-z A-Z]{4}-[0-9 a-z A-Z]{12}");
            Guid tenantIdNew;
            string extract = "";
            
            try
            {
                tenantIdRE.IsMatch(tenantId);
                extract = tenantIdRE.Match(tenantId).ToString().Trim();
            }
            catch { throw; }

            if (!string.IsNullOrEmpty(extract))
            {
                Guid.TryParse(extract, out tenantIdNew);
                return tenantIdNew;
            }
                
            return null;
        }
    }
}