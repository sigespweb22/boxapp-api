using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Domain.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string description)
        {
            Description = description;
        }

        // Constructor empty to EFCore
        public ApplicationRole() {}

        public string Description { get;  set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public virtual ICollection<ApplicationRoleGroup> ApplicationRoleGroups { get; set; }
    }
}