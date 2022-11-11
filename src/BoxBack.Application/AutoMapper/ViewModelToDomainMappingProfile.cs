using AutoMapper;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Models;

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
                .ForMember(dst => dst.NormalizedEmail, src => src.MapFrom(x => x.Email.ToUpper()))
                .ForMember(dst => dst.EmailConfirmed, src => src.MapFrom(x => x.EmailConfirmed))
                .ForMember(dst => dst.LockoutEnabled, src => src.MapFrom(x => x.LockoutEnabled))
                .ForMember(dst => dst.Avatar, src => src.MapFrom(x => x.Avatar))
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.Status));
            CreateMap<ApplicationRoleViewModel, ApplicationRole>();
            CreateMap<ApplicationGroupViewModel, ApplicationGroup>();
            CreateMap<ApplicationRoleGroupViewModel, ApplicationRoleGroup>();
            CreateMap<ApplicationRoleViewModel, ApplicationRole>();
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ClienteServicoViewModel, ClienteServico>()
                .ForMember(dst => dst.ServicoId, src => src.MapFrom(x => x.Servico.Id))
                .ForMember(dst => dst.Nome, src => src.MapFrom(x => x.Servico.Nome));
            CreateMap<ServicoViewModel, Servico>()
                .ForMember(dst => dst.FornecedorServicoId, src => src.MapFrom(x => x.FornecedorServico.Id));
            CreateMap<PipelineAssinanteViewModel, PipelineAssinante>()
                .ForMember(dst => dst.FullName, src => src.MapFrom(x => x.Name))
                .ForMember(dst => dst.UserId, src => src.MapFrom(x => x.UserId));
            CreateMap<PipelineViewModel, Pipeline>();
            CreateMap<FornecedorViewModel, Fornecedor>();
            CreateMap<FornecedorServicoViewModel, FornecedorServico>();
            CreateMap<UsuarioContaViewModel, ApplicationUser>();
            CreateMap<UsuarioInfoViewModel, ApplicationUser>();
            CreateMap<ChaveApiTerceiroViewModel, ChaveApiTerceiro>();
        }
    }
}