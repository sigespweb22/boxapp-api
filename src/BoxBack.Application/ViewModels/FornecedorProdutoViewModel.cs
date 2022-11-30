using System;
using System.ComponentModel.DataAnnotations;

namespace BoxBack.Application.ViewModels
{
    public class FornecedorProdutoViewModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string CodigoProduto { get; set; }
        public string Caracteristicas { get; set; }
        public string Status { get; set; }

        public Guid? FornecedorId { get; set; }
        public FornecedorViewModel Fornecedor { get; set; }
    }
}