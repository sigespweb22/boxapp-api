using System.Text.RegularExpressions;

namespace BoxBack.WebApi.Helpers
{
    public static class DateHelpers
    {
        public static bool IsDateStringValid(string date)
        {
            try
            {
                var dateMapped = "";

                if (date.Trim().Length >= 10)
                    dateMapped = date.Trim().Substring(0, 10);

                Regex dateStringRE = new Regex(@"^(\d{1,2}\/\d{1,2}\/\d{4})$");
                return dateStringRE.IsMatch(dateMapped);    
            }
            catch { throw; }
        }
    }
}