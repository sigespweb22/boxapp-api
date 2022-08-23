using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using BoxBack.Domain.Models.Services;

namespace BoxBack.Domain.ModelsServices
{
    public class CNPJaUserModelServices
    {
        public int Username  { get; set; }
        public string Password { get; set; }
    }
}