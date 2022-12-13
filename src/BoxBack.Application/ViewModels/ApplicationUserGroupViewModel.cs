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
    public class ApplicationUserGroupViewModel
    {
        public string UserId { get;set; }
        public string GroupId { get;set; }
        public string Name { get; set; }

        public ApplicationGroupViewModel ApplicationGroup { get; set; }
    }
}