using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Domain.Models
{
    public class ClienteAtivo
    {        
        // Constructor empty for EF
        public ClienteAtivo() {}

        // Relationships
        [ForeignKey("ClienteId")]
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("AtivoId")]
        public Guid AtivoId { get; set; }
        public Ativo Ativo { get; set; }

        
    }
}