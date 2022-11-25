using System;


namespace BoxBack.Application.ViewModels
{
    public class ClienteProdutoViewModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public decimal? ValorVenda { get; set; }
        public string Caracteristicas { get; set; }
        public string Status { get; set; }
        public Guid? ClienteId { get; set; }

        public Guid? ProdutoId { get; set; }
        public ProdutoViewModel Produto { get; set; }
    }
}