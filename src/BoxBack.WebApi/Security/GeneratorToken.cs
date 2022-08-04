using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BoxBack.Infra;
using BoxBack.Application.ViewModels;
using BoxBack.Infra.Data.Context;
using BoxBack.Domain.Models;

namespace BoxBack.WebApi.Security
{
    public class GeneratorToken
    {
        public ApplicationUserViewModel GetToken(ApplicationUser appUser)
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
                    foreach (var item in appUser.ApplicationUserRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item.ApplicationRole.NormalizedName));
                        
                        // Create Claim by app
                        // claims.Add(new Claim("BoxAppApi", item.ApplicationRole.NormalizedName));
                    }
                    return claims.ToArray();
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = getClaimsIdentity(),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            // var tokenDescriptor = new SecurityTokenDescriptor
            // {
            //     Subject = new ClaimsIdentity(new Claim[]
            //     {
            //         new Claim(ClaimTypes.Name, appUser.UserName),
            //         new Claim("BoxAppApi", appUser.ApplicationUserRoles.Select(x => x.ApplicationRole.NormalizedName).FirstOrDefault())
            //     }),
            //     Expires = DateTime.UtcNow.AddDays(7),
            //     SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            // };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userViewModel = new ApplicationUserViewModel();
            
            userViewModel.UserName = appUser.UserName;
            userViewModel.Funcao = appUser.ContaUsuario.Funcao.ToString();
            userViewModel.Setor = appUser.ContaUsuario.Setor.ToString();
            userViewModel.Nome = appUser.ContaUsuario.Nome;
            userViewModel.AccessToken = tokenHandler.WriteToken(token);
            userViewModel.Password = null;

            return userViewModel;
        }
    }
}
