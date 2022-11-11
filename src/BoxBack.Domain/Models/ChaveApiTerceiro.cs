using System;
using BoxBack.Domain.Enums;

namespace BoxBack.Domain.Models
{
    public class ChaveApiTerceiro : EntityAudit
    {
        public ChaveApiTerceiro(ApiTerceiroEnum apiTerceiro,
                                string descricao, string key,
                                DateTimeOffset dataValidade)
        {
            ApiTerceiro = apiTerceiro;
            Descricao = descricao;
            Key = key;
            DataValidade = dataValidade;
        }

        // Contructor empty to EFCore
        public ChaveApiTerceiro() {}

        public ApiTerceiroEnum ApiTerceiro { get; set; }
        public string Key { get; set; }
        public string Descricao { get; set; }
        public DateTimeOffset DataValidade { get; set; }
    }
}