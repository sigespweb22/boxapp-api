using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using BoxBack.Domain.Models.Services;

namespace BoxBack.Domain.ModelsServices
{
    public class CNPJaTokenModelServices
    {
        public int IdToken { get; set; }
        public string Ttl { get; set; }
    }
}