using System;

namespace BoxBack.Application.ViewModels
{
    public class ClienteContratoViewModel
    {
        public Guid? Id { get; set; }
        public decimal ValorContrato { get; set; }
        public string Periodicidade { get; set; }

        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public string Status  { get; set; }

        public Guid? ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }

        public Int64? BomControleContratoId { get; set; }
    }
}