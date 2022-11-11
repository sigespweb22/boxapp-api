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
            DataValidate = dataValidade;
        }

        // Contructor empty to EFCore
        public ChaveApiTerceiro() {}

        public ApiTerceiroEnum ApiTerceiro { get; set; }
        public string Key { get; set; }
        public string Descricao { get; set; }
        public DateTimeOffset DataValidate { get; set; }
    }
}