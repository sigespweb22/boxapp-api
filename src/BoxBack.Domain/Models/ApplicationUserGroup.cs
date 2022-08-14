using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Domain.Models
{
    public class ApplicationUserGroup
    {        
        // Constructor empty for EF
        public ApplicationUserGroup() {}

        // Relationships
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        [ForeignKey("GroupId")]
        public Guid GroupId { get; set; }
        public ApplicationGroup ApplicationGroup { get; set; }
    }
}