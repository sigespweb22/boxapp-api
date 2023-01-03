using System;

namespace BoxBack.Domain.ModelsServices
{
    public class BCFaturaModelService
    {
        public Int32 Id { get; set; }
        public Guid IdParcela { get; set; }
        public Guid IdMovimentacaoFinanceira { get; set; }
        public Int32 TipoFatura { get; set; }
        public string NomeTipoFatura { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataCompetencia { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal ValorPagamento { get; set; }
        public Int32 NumeroParcela { get; set; }
        public bool Quitado { get; set; }
        public bool Conciliado { get; set; }
        public Int32 FormaPagamento { get; set; }
        public string NomeFormaPagamento { get; set; }
        public bool EmiteBoleto{ get; set; }
        public string ObservacaoBoleto { get; set; }
        public Int32 IdBoleto { get; set; }
        public string LinkBoleto { get; set; }
        public bool EmiteNotaFiscal { get; set; }
        public string ObservacaoNotaFiscal { get; set; }
        public string LinkNotaFiscal { get; set; }
        public string LinkXmlNotaFiscal { get; set; }
        public DateTime? DataPromessaPagamento { get; set; }
        public bool ClienteNaoVaiPagar { get; set; }
        public string Anexos { get; set; }
    }
}