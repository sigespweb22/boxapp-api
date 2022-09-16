using System.Security.Cryptography;
using System.Threading;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using AutoMapper;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Models;
using BoxBack.Domain.ModelsNoSQL;
using BoxBack.Application.Extensions;
using BoxBack.Domain.Enums;
using System.Collections.Generic;
using BoxBack.Domain.Models.DataTable;

namespace BoxBack.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Email, src => src.MapFrom(x => x.Email))
                .ForMember(dst => dst.FullName, src => src.MapFrom(x => x.FullName))
                .ForMember(dst => dst.UserName, src => src.MapFrom(x => x.UserName))
                .ForMember(dst => dst.Avatar, src => src.MapFrom(x => x.Avatar))
                .ForMember(dst => dst.ApplicationUserGroupsNames, src => src.MapFrom(x => x.ApplicationUserGroups.Select(x => x.ApplicationGroup.Name)));
            CreateMap<ApplicationRole, ApplicationRoleViewModel>();
            CreateMap<ApplicationGroup, ApplicationGroupViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"))
                .ForMember(dst => dst.ApplicationRoleGroupsNames, src => src.MapFrom(x => x.ApplicationRoleGroups.Select(x => x.ApplicationRole.Name)));
            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"));
            CreateMap<Ativo, AtivoViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"));
            CreateMap<Pipeline, PipelineViewModel>();
        }
    }
}