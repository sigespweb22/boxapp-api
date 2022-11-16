using System;
using System.ComponentModel.DataAnnotations;
using BoxBack.Domain.Models;

namespace BoxBack.Application.ViewModels
{
    public class ClienteContratoViewModel
    {
        public Guid? Id { get; set; }

        public decimal ValorContrato { get; set; }
        public string Periodicidade { get; set; }

        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}