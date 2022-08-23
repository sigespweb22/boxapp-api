using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum ClienteAtivoTipoEnum
    {
        [Display(Name = "Serviço")]
        SERVICO = 0,
        
        [Display(Name = "Produto")]
        PRODUTO = 1
    }
}