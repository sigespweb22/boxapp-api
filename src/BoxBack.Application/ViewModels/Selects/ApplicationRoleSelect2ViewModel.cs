using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Models;
using BoxBack.Application.ViewModels;

namespace BoxBack.Application.ViewModels.Selects
{
    public class ApplicationRoleSelect2ViewModel
    {
        public string GroupId { get; set; }
        public string RoleId { get; set; }
        public string Name { get; set; }
    }
}