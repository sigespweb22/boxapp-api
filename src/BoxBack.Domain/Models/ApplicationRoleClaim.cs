using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Domain.Models
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        // Constructor empty to EFCore
        public ApplicationRoleClaim() {}

        public ApplicationRole ApplicationRole { get; set; }
    }
}