using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoxBack.Application.ViewModels.Requests
{
    public class GenericViewModel
    {
        [Required(ErrorMessage = "Id requerido.")]
        public string Id { get; set; }
    }
}