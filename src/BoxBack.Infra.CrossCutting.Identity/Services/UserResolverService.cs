using System.Linq;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace BoxBack.Infra.CrossCutting.Identity.Services
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserResolverService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            var hasHttpContextUser = _httpContextAccessor.HttpContext.User.Claims.Count();

            if (hasHttpContextUser == 0)
                return Guid.Parse("00000000-0000-0000-0000-000000000000");
            return Guid.Parse((_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            
            // return _httpContextAccessor.HttpContext.User?.Identity?.Name;
        }
    }
}
