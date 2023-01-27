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

        public string GetUserId()
        {
            var hasHttpContextUser = _httpContextAccessor?.HttpContext?.User?.Claims.Count();

            if (hasHttpContextUser == 0)
                return string.Empty;
            return _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
