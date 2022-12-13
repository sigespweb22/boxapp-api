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
    public class ApplicationRoleGroupViewModel
    {
        public string RoleId { get;set; }
        public string GroupId { get;set; }
        public string Name { get; set; }

        public ApplicationRoleViewModel ApplicationRole { get; set; }
        public ApplicationGroupViewModel ApplicationGroup { get; set; }
    }
}