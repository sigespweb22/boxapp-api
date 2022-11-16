using System.Dynamic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Models;
using BoxBack.Application.ViewModels;


namespace BoxBack.Application.ViewModels
{
    public class ClienteContratoPadraoIntegracaoViewModel
    {
        public Guid? Id { get; set; }
        public decimal ValorContrato { get; set; }
        public string Periodicidade { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}