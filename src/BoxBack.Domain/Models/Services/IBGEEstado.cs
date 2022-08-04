using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BoxBack.Domain.Models
{
    public class IBGEEstado
    {        
        public string Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        
        public virtual IBGERegiao Regiao { get; set; }
    }
}