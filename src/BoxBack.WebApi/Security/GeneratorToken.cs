using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BoxBack.Domain.Models;

namespace BoxBack.WebApi.Security
{
    public class GeneratorToken
    {
        public string GetToken(ApplicationUser appUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            
            ClaimsIdentity getClaimsIdentity()
            {
                return new ClaimsIdentity(getClaims());
                Claim[] getClaims()
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id));
                    claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
                    
                    try
                    {
                        foreach (var aUg in appUser.ApplicationUserGroups.Where(x => !x.ApplicationGroup.IsDeleted).ToList())
                        {
                            foreach (var aRg in aUg.ApplicationGroup.ApplicationRoleGroups.Select(x => x.ApplicationRole.Name))
                            {
                                claims.Add(new Claim(ClaimTypes.Role, aRg));
                            }
                            // Create Claim by app
                            // claims.Add(new Claim("BoxAppApi", item.ApplicationRole.NormalizedName));
                        }    
                    }
                    catch { throw; }
                    return claims.ToArray();
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = getClaimsIdentity(),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            String tokenResult;
            try
            {
                var token = tokenHandler.CreateToken(tokenDescriptor);
                if (token == null)
                    throw new Exception("Problemas ao obter o token. Tente novamente, persistindo o problema informe a equipe de suporte.");
                
                tokenResult = tokenHandler.WriteToken(token);
            }
            catch { throw; }
            return tokenResult;
        }
    }
}
