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
    public class ClienteServicoViewModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public decimal? ValorVenda { get; set; }
        public string Caracteristicas { get; set; }
        public string CobrancaTipo { get; set; }

        public string ServicoNome { get; set; }
        public string Status { get; set; }

        public Servico Servico { get; set; }

        public Guid? ClienteId { get; set; }
        public Guid? ServicoId { get; set; }
    }
}