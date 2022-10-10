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
        [DisplayName("Id")]
        public Guid? Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "\nNome é requerido.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "\nNome deve possuir entre 3 e 255 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Posição")]
        [Required(ErrorMessage = "\nPosição é requerida.")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "\nPosição deve possuir no mínimo um caracter.")]
        public string Posicao { get; set; }

        [DisplayName("Total tarefas")]
        public int TotalTarefas { get; set; }

        [DisplayName("Total tarefas concluídas")]
        public int TotalTarefasConcluidas { get; set; }

        [DisplayName("Total assinantes")]
        public int TotalAssinantes { get; set; }

        [DisplayName("Total avatares")]
        public List<string> Avatars { get; set; }

        [DisplayName("Assinantes")]
        [MinLength(1, ErrorMessage = "\nAo menos um assinante é requerido.")]
        public List<PipelineAssinanteViewModel> PipelineAssinantes { get; set; }
    }
}