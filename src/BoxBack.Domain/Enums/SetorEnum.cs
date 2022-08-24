using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum SetorEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,
        
        [Display(Name = "Jurídico")]
        JURIDICO = 1,

        [Display(Name = "Gerência")]
        GERENCIA = 2,

        [Display(Name = "Recursos Humanos")]
        RECURSOS_HUMANOS = 3,

        [Display(Name = "Tecnologia da Informação")]
        TECNOLOGIA_INFORMACAO = 4,

        [Display(Name = "Diretoria")]
        DIRETORIA = 5
    }
}