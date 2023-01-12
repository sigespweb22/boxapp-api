using System;
using System.Collections.Generic;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.ModelsServices
{
    public class BCContratoModelService
    {
        public Int64 Id { get; set; }
        public Int64 IdVenda { get; set; }
        public string Inicio { get; set; }
        public string Termino { get; set; }
        public ContratoTipoEnum TipoPagamento { get; set; }
        public string NomeTipoPagamento { get; set; }
        public bool Encerrado { get; set; }
        public string DataEncerramento { get; set; }
        public decimal Valor { get; set; }
        public PeriodicidadeEnum Periodicidade { get; set; }
        public string ProximoReajuste { get; set; }
        public IndiceReajusteEnum IndiceReajuste { get; set; }
        public string NomeIndiceReajuste { get; set; }
        public PeriodoReajusteEnum PeriodoReajuste { get; set; }
        public string NomePeriodoReajuste { get; set; }
        public ICollection<BCFaturaModelService> Faturas { get; set; }
    }
}