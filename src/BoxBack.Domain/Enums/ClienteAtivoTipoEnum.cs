using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum ClienteAtivoTipoEnum
    {
        [Display(Name = "Serviço")]
        SERVICO = 1,
        
        [Display(Name = "Produto")]
        PRODUTO = 2
    }
}