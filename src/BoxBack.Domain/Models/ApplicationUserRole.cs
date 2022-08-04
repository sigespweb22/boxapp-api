using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Domain.Models
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}