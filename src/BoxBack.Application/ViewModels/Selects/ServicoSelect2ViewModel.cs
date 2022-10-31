using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Models;
using BoxBack.Application.ViewModels;

namespace BoxBack.Application.ViewModels.Selects
{
    public class ServicoSelect2ViewModel
    {
        public string ServicoId { get; set; }
        public string Nome { get; set; }
    }
}