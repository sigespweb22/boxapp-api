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