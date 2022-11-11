using System.Linq;
using AutoMapper;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Models;
using BoxBack.Domain.Enums;
using BoxBack.Application.ViewModels.Selects;

namespace BoxBack.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ApplicationUserGroup, ApplicationUserGroupViewModel>()
                .ForMember(dst => dst.Name, src => src.MapFrom(x => x.ApplicationGroup.Name));
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dst => dst.Email, src => src.MapFrom(x => x.Email))
                .ForMember(dst => dst.FullName, src => src.MapFrom(x => x.FullName))
                .ForMember(dst => dst.UserName, src => src.MapFrom(x => x.UserName))
                .ForMember(dst => dst.Avatar, src => src.MapFrom(x => x.Avatar))
                .ForMember(dst => dst.ApplicationUserGroups, src => src.MapFrom(x => x.ApplicationUserGroups));
            CreateMap<ApplicationRole, ApplicationRoleViewModel>();
            CreateMap<ApplicationGroup, ApplicationGroupViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"))
                .ForMember(dst => dst.ApplicationRoleGroupsNames, src => src.MapFrom(x => x.ApplicationRoleGroups.Select(x => x.ApplicationRole.Name)));
            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"));
            CreateMap<ClienteServico, ClienteServicoViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"))
                .ForMember(dst => dst.ServicoId, src => src.MapFrom(x => x.Servico.Id))
                .ForMember(dst => dst.Nome, src => src.MapFrom(x => x.Servico.Nome));
            CreateMap<Servico, ServicoViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"));
            CreateMap<PipelineAssinante, PipelineAssinanteViewModel>()
                .ForMember(dst => dst.Name, src => src.MapFrom(x => x.FullName))
                .ForMember(dst => dst.UserId, src => src.MapFrom(x => x.UserId));
            CreateMap<Pipeline, PipelineViewModel>()
                .ForMember(dst => dst.TotalTarefas, src => src.MapFrom(x => x.PipelineEtapas.Select(x => x.PipelineTarefas).Count()))
                .ForMember(dst => dst.TotalAssinantes, src => src.MapFrom(x => x.PipelineAssinantes.Count()))
                .ForMember(dst => dst.TotalTarefasConcluidas, src => src.MapFrom(x => x.PipelineEtapas.Select(x => x.PipelineTarefas.Where(x => x.Status == TarefaStatusEnum.CONCLUIDA)).Count()))
                .ForMember(dst => dst.Avatars, src => src.MapFrom(x => x.PipelineAssinantes.Select(x => x.ApplicationUser.Avatar)));
            CreateMap<ApplicationGroup, ApplicationGroupSelect2ViewModel>()
                .ForMember(dst => dst.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dst => dst.GroupId, src => src.MapFrom(x => x.Id));
            CreateMap<ApplicationRoleGroup, ApplicationRoleGroupViewModel>()
                .ForMember(dst => dst.Name, src => src.MapFrom(x => x.ApplicationRole.Name));;
            CreateMap<ApplicationRole, ApplicationRoleSelect2ViewModel>()
                .ForMember(dst => dst.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dst => dst.RoleId, src => src.MapFrom(x => x.Id));
            CreateMap<Fornecedor, FornecedorViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"));
            CreateMap<FornecedorServico, FornecedorServicoViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"));
            CreateMap<FornecedorServico, FornecedorServicoSelect2ViewModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Nome, src => src.MapFrom(x => x.Nome));
            CreateMap<Servico, ServicoSelect2ViewModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Nome, src => src.MapFrom(x => x.Nome));
            CreateMap<ApplicationUser, UsuarioContaViewModel>()
                .ForMember(dst => dst.ApplicationUserGroups, src => src.MapFrom(x => x.ApplicationUserGroups));
            CreateMap<ApplicationUser, UsuarioInfoViewModel>();
            CreateMap<ChaveApiTerceiro, ChaveApiTerceiroViewModel>();
            CreateMap<ChaveApiTerceiro, ChaveApiTerceiroSelect2ViewModel>();
        }
    }
}