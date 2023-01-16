using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxBack.Domain.Models
{
    public class ClienteContratoFatura : EntityAudit
    {
        public ClienteContratoFatura(DateTimeOffset dataVencimento, DateTimeOffset dataCompetencia,
                                     DateTimeOffset dataPagamento, decimal valor, decimal desconto,
                                     Int32 numeroParcela, bool quitado)
        {
            DataVencimento = dataVencimento;
            DataCompetencia = dataCompetencia;
            DataPagamento = dataPagamento;
            Valor = valor;
            Desconto = desconto;
            NumeroParcela = numeroParcela;
            Quitado = quitado;
        }

        // Constructor empty to EFCore
        public ClienteContratoFatura() {}

        public DateTimeOffset DataVencimento { get; set; }
        public DateTimeOffset DataCompetencia { get; set; }
        public DateTimeOffset DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public Int32 NumeroParcela { get; set; }
        public bool Quitado { get; set; }



        // Relashionship
        [ForeignKey("ClienteContratoId")]
        public Guid ClienteContratoId { get; set; }
        public ClienteContrato ClienteContrato { get; set; }


        // Id do registro da fatura no sistema de terceiro - Atualmente o Bom Controle
        public Int64 BomControleFaturaId { get; set; }
    }
}