using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoxBack.Application.Helpers
{
    public static class DateHelpers
    {
        public static bool IsDateStringValid(string date)
        {   
            try
            {
                Regex dateStringRE = new Regex(@"^(\d{4}\-\d{1,2}\-\d{1,2})$");
                var isValid = dateStringRE.IsMatch(date);
                
                return isValid;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string AnoExtractFromDateTime(DateTime date)
        {
            var ano = date.Year;
            return ano.ToString();
        }

        public static string MesExtractFromDateTime(DateTime date)
        {
            var mes = date.Month;
            return mes.ToString();
        }
    }
}