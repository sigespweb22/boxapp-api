using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string fullName,
                               string avatar,
                               SetorEnum setor,
                               FuncaoEnum funcao,
                               ApplicationUserStatusEnum status) 
        {
            FullName = fullName;
            Avatar = avatar;
            Setor = setor;
            Funcao = funcao;
            Status = status;
        }


        //Construtor vazio para o EF
        public ApplicationUser() { }

        public string FullName { get; set; }
        public string Avatar { get; set; }
        public SetorEnum Setor { get; set; }
        public FuncaoEnum Funcao { get; set; }
        public ApplicationUserStatusEnum Status { get; set; }
        

        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public virtual ICollection<ApplicationUserClaim> ApplicationUserClaims { get; set; }
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public virtual ICollection<ApplicationUserGroup> ApplicationUserGroups { get; set; }
        public virtual ICollection<PipelineAssinante> PipelineAssinantes { get; set; }
        public virtual ICollection<PipelineTarefaAssinante> PipelineTarefaAssinantes { get; set; }
    }
}