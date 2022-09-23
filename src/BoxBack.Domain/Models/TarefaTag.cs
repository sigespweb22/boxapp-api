using System.Numerics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoxBack.Domain.Enums;
namespace BoxBack.Domain.Models
{
    public class TarefaTag : EntityAudit
    {        
        public TarefaTag(string nome)
        {
            Nome = nome;
        }

        // Constructor empty for EF
        public TarefaTag() {}

        public string Nome { get; set; }

        // Relationships
        public ICollection<PipelineEtapaTarefa> Tarefas { get; set; }
    }
} 