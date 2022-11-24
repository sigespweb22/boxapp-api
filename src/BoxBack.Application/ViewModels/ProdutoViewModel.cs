using System;
using System.ComponentModel.DataAnnotations;

namespace BoxBack.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "\nNome é requerido.")]
        public string Nome { get; set; }
        public string CodigoUnico { get; set; }
        public decimal? ValorCusto { get; set; }
        public string Caracteristicas { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }

        public FornecedorProdutoViewModel FornecedorProduto { get; set; }
    }
}