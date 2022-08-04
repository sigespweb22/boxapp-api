using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Domain.Models
{
    public class ApplicationRole : IdentityRole
    {        
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}