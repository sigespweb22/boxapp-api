using System;
using System.ComponentModel.DataAnnotations;
using BoxBack.Domain.Models;

namespace BoxBack.Application.ViewModels
{
    public class ServicoViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "\nNome é requerido.")]
        public string Nome { get; set; }

        public string CodigoUnico { get; set; }
        public decimal? ValorCusto { get; set; }
        public string Caracteristicas { get; set; }
        public string UnidadeMedida { get; set; }
        public string Status { get; set; }

        public FornecedorServico FornecedorServico { get; set; }
        
        public Guid? FornecedorServicoId { get; set; }
    }
}