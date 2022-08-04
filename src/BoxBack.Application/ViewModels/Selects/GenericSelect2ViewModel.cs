using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Models;
using BoxBack.Application.ViewModels;

namespace BoxBack.Application.ViewModels.Selects
{
    public class GenericSelect2ViewModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
    }
}