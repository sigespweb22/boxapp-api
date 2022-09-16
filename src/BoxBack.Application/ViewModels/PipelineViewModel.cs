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
    }
}