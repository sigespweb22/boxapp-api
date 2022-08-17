using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BoxBack.Application.Helpers
{
    public static class KeyGenerate
    {
        public static string CreateUniqueKeyBySecret(string secret)
        {
            if (string.IsNullOrWhiteSpace(secret)) return string.Empty;
            try
            {
                using var sha = SHA256.Create();
                var bytes = Encoding.UTF8.GetBytes(secret);
                var hash = sha.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
            catch { throw; }
        }
    }
}