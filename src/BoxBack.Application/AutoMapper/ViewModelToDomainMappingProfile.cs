using System.Reflection.Metadata.Ecma335;
using System.Linq;
using AutoMapper;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Models;
using BoxBack.Application.Extensions;

namespace BoxBack.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ApplicationUserViewModel, ApplicationUser>();
            CreateMap<ApplicationRoleViewModel, ApplicationRole>();

        }
    }
}
