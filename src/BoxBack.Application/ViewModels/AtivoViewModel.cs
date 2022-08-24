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
    public class AtivoViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Nome é requerido.")]
        public string Nome { get; set; }
        public string Referencia { get; set; }
        public string CodigoUnico { get; set; }
        public string Tipo { get; set; }
        public decimal? ValorCusto { get; set; }
        public decimal? ValorVenda { get; set; }
        public string UnidadeMedida { get; set; }
        public string ClienteAtivoTipoServicoTipo { get; set; }
        public string Caracteristica { get; set; }
        public string Observacao { get; set; }
        public string Status { get; set; }
    }
}