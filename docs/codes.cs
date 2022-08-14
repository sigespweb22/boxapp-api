#region Code to implementation in the hash UniqueKey of ApplicationGroup
using System;
using System.Security.Cryptography;
using System.Text;
					
public class Program
{
	static void Main(string[] args)
    {
        // example:
        // replace-with-desired-secret => 5KZ3D/MuEtYxRNTZ2oY6oHdLdxMZ6x4YxQI2n1v2g7c=

        // replace this with desired secret; could be a randomly generated one of sufficient length like a guid
        var secret = "Master"; // Guid.NewGuid().ToString();
        var hash = Sha256(secret);
        Console.WriteLine($"secret: {secret}");
        Console.WriteLine($"hash: {hash}");
    }

    // source: https://github.com/IdentityServer/IdentityServer4/blob/main/src/IdentityServer4/src/Extensions/HashExtensions.cs
    // IdentityServer4.Models.HashExtensions.Sha256
    static string Sha256(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(input);
        var hash = sha.ComputeHash(bytes);

        return Convert.ToBase64String(hash);
    }
}
#endregion 