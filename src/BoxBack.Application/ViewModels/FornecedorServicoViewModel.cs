using System;
using System.ComponentModel.DataAnnotations;

namespace BoxBack.Application.ViewModels
{
    public class FornecedorServicoViewModel
    {
        public Guid? Id { get; set; }

        public string Nome { get; set; }
        public string CodigoServico { get; set; }
        public string UnidadeMedida { get; set; }
        public string Caracteristicas { get; set; }
        public string Status { get; set; }

        public string FornecedorId { get; set; }
    }
}