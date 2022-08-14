using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class ApplicationGroup : EntityAudit
    {        
        public ApplicationGroup(string name,
                                string uniqueKey)
        {
            Name = name;
            UniqueKey = uniqueKey;
        }

        // Constructor empty for EF
        public ApplicationGroup() {}

        public string Name { get; set; }
        public string UniqueKey { get; set; }

        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<ApplicationRoleGroup> ApplicationRoleGroups { get; set; }
        public ICollection<ApplicationUserGroup> ApplicationUserGroups { get; set; }
    }
}