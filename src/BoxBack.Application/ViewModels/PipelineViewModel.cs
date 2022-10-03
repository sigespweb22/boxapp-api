using System.Reflection;
using System.Dynamic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Models;
using BoxBack.Application.ViewModels;


namespace BoxBack.Application.ViewModels
{
    public class PipelineViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "\nNome é requerido.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "\nNome deve possuir entre 3 e 255 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "\nPosição é requerida.")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "\nPosição deve possuir no mínimo um caracter.")]
        public string Posicao { get; set; }
        public int TotalTarefas { get; set; }
        public int TotalTarefasConcluidas { get; set; }
        public int TotalAssinantes { get; set; }
        public List<string> Avatars { get; set; }
        public ICollection<PipelineAssinanteViewModel> Assinantes { get; set; }
    }
}