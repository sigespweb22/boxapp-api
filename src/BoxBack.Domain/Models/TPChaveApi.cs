using System;
namespace BoxBack.Domain.Models
{
    public class ChaveApi : EntityAudit
    {
        public ChaveApi(string descricao, string token,
                        DateTimeOffset validoAte)
        {
            Descricao = descricao;
            Token = token;
            ValidoAte = validoAte;
        }

        public string Token { get; set; }
        public string Descricao { get; set; }
        public DateTimeOffset ValidoAte { get; set; }
    }
}