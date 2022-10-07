using System.Security.Cryptography;
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
            CreateMap<ApplicationUserGroupViewModel, ApplicationUserGroup>();
            CreateMap<ApplicationUserViewModel, ApplicationUserGroup>()
                .ForMember(dst => dst.UserId, src => src.MapFrom(x => x.Id));
            CreateMap<ApplicationUserViewModel, ApplicationUser>()
                .ForMember(dst => dst.ApplicationUserGroups, src => src.MapFrom(x => x.ApplicationUserGroups))
                .ForMember(dst => dst.UserName, src => src.MapFrom(x => x.Email))
                .ForMember(dst => dst.NormalizedUserName, src => src.MapFrom(x => x.Email.ToUpper()))
                .ForMember(dst => dst.NormalizedEmail, src => src.MapFrom(x => x.Email.ToUpper()));
            CreateMap<ApplicationRoleViewModel, ApplicationRole>();
            CreateMap<ApplicationGroupViewModel, ApplicationGroup>();
            CreateMap<ApplicationRoleViewModel, ApplicationRole>();
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<AtivoViewModel, Ativo>();
            CreateMap<PipelineAssinanteViewModel, PipelineAssinante>()
                .ForMember(dst => dst.FullName, src => src.MapFrom(x => x.Name))
                .ForMember(dst => dst.UserId, src => src.MapFrom(x => x.UserId));
            CreateMap<PipelineViewModel, Pipeline>();
        }
    }
}