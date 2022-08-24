using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum ClienteAtivoTipoEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,
        
        [Display(Name = "Serviço")]
        SERVICO = 1,
        
        [Display(Name = "Produto")]
        PRODUTO = 2
    }
}