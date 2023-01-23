using System;

namespace BoxBack.Application.ViewModels
{
    public class ClienteContratoFaturaViewModel
    {
        public Guid? Id { get; set; }
        public string DataVencimento { get; set; }
        public string DataCompetencia { get; set; }
        public string DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public Int32 NumeroParcela { get; set; }
        public bool Quitado { get; set; }

        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string Status  { get; set; }

        public Guid? ClienteContratoId { get; set; }
        public ClienteContratoViewModel ClienteContrato { get; set; }

        public Int64? BomControleContratoId { get; set; }
    }
}