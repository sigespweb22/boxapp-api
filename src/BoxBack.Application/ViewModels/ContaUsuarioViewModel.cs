using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Models;
using BoxBack.Application.ViewModels;
using BoxBack.Application.ViewModels.Selects;

namespace BoxBack.Application.ViewModels
{
    public class ContaUsuarioViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        public string PerfilFoto { get; set; }
        public string Setor { get; set; }
        public int SetorId { get; set; }
        public string Funcao { get; set; }
        public int FuncaoId { get; set; }

        public string UserId { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
    }
}