using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Models;

namespace BoxBack.WebApi.Extensions
{
    public static class MapperExtensions
    {
        public static ApplicationUserViewModel MapWithChildren<TDestination>(ApplicationUser applicationUser)
        {
            var applicationUserRet = new ApplicationUserViewModel() {
                UserId = applicationUser.Id,
                UserName = applicationUser.UserName,
                Email = applicationUser.Email,
                TwoFactorEnabled = applicationUser.TwoFactorEnabled,
                ApplicationUserRoles = applicationUser.ApplicationUserRoles.Select(x => x.ApplicationRole.NormalizedName).ToList()
            };

            return applicationUserRet;
            
        }

        public static List<string> MapFromTwoDepths(IEnumerable<IEnumerable<string>> inputs)
        {
            var list = new List<string>();
            try
            {
                foreach (var tmpDeepOne in inputs.ToList())
                {
                    foreach (var tmpDeepTwo in tmpDeepOne)
                    {
                        list.Add(tmpDeepTwo);
                    }
                }    
            } catch { throw; }
            return list;
        }
    }
}