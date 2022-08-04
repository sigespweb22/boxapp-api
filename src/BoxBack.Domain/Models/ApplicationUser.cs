using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Domain.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //Construtor vazio para o EF
        public ApplicationUser() { }

        public ContaUsuario ContaUsuario { get; set; }


        public virtual ICollection<ApplicationUserClaim> ApplicationUserClaims { get; set; }
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}