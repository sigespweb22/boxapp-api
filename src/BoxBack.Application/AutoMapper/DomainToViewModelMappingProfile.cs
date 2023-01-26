using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
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
            CreateMap<ApplicationGroup, ApplicationGroupUpdateViewModel>();
            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"))
                .ForMember(dst => dst.Contratos, src => src.MapFrom(x => x.ClienteContratos));
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
            CreateMap<ApplicationRoleGroup, ApplicationRoleGroupUpdateViewModel>();
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
            CreateMap<FornecedorProduto, FornecedorProdutoSelect2ViewModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Nome, src => src.MapFrom(x => x.Nome));
            CreateMap<Servico, ServicoSelect2ViewModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Nome, src => src.MapFrom(x => x.Nome));
            CreateMap<ApplicationUser, UsuarioContaViewModel>()
                .ForMember(dst => dst.ApplicationUserGroups, src => src.MapFrom(x => x.ApplicationUserGroups));
            CreateMap<ApplicationUser, UsuarioInfoViewModel>();
            CreateMap<ChaveApiTerceiro, ChaveApiTerceiroViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"))
                .ForMember(dst => dst.DataValidade, src => src.MapFrom(x => x.DataValidade.ToString("dd/MM/yyyy")));
            CreateMap<ChaveApiTerceiro, ChaveApiTerceiroSelect2ViewModel>();
            CreateMap<ClienteContrato, ClienteContratoViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"));;
            CreateMap<Cliente, ClientePadraoIntegracaoViewModel>()
                .ForMember(dst => dst.Contratos, src => src.MapFrom(x => x.ClienteContratos));
            CreateMap<ClienteContrato, ClienteContratoPadraoIntegracaoViewModel>();
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"));
            CreateMap<Produto, ProdutoSelect2ViewModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Nome, src => src.MapFrom(x => x.Nome));
            CreateMap<FornecedorProduto, FornecedorProdutoViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"));
            CreateMap<ClienteProduto, ClienteProdutoViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"));
            CreateMap<Vendedor, VendedorViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"));
            CreateMap<VendedorContrato, VendedorContratoViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"));
            CreateMap<VendedorComissao, VendedorComissaoViewModel>()
                .ForMember(dst => dst.VendedorViewModel, src => src.MapFrom(x => x.Vendedor))
                .ForMember(dst => dst.ClienteContratoViewModel, src => src.MapFrom(x => x.ClienteContrato))
                .ForMember(dst => dst.ClienteContratoFaturaViewModel, src => src.MapFrom(x => x.ClienteContratoFatura))
                .ForPath(dst => dst.ClienteContratoFaturaViewModel.DataCompetencia, src => src.MapFrom(x => x.ClienteContratoFatura.DataCompetencia.ToString("dd/MM/yyyy")))
                .ForPath(dst => dst.ClienteContratoFaturaViewModel.DataPagamento, src => src.MapFrom(x => x.ClienteContratoFatura.DataPagamento.ToString("dd/MM/yyyy")))
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"));
            CreateMap<Vendedor, VendedorSelect2ViewModel>();
            CreateMap<ClienteContratoFatura, ClienteContratoFaturaViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.Quitado ? "YES" : "NO"))
                .ForMember(dst => dst.DataCompetencia, src => src.MapFrom(x => x.DataCompetencia.ToString("dd/MM/yyyy")))
                .ForMember(dst => dst.DataPagamento, src => src.MapFrom(x => x.DataPagamento.ToString("dd/MM/yyyy")));
            CreateMap<Rotina, RotinaViewModel>()
                .ForMember(dst => dst.Status, src => src.MapFrom(x => x.IsDeleted ? "INACTIVE" : "ACTIVE"))
                .ForMember(dst => dst.DataCriacaoUltimoEvento, src => src.MapFrom(x => x.RotinasEventsHistories.OrderByDescending(x => x.CreatedAt).Select(x => x.CreatedAt).FirstOrDefault().ToString("dd/MM/yyyy hh:mm:ss")))
                .ForMember(dst => dst.StatusUltimoEvento, src => src.MapFrom(x => x.RotinasEventsHistories.OrderByDescending(x => x.CreatedAt).Select(x => x.StatusProgresso).FirstOrDefault()))
                .ForMember(dst => dst.TotalItensSucessoUltimoEvento, src => src.MapFrom(x => x.RotinasEventsHistories.OrderByDescending(x => x.CreatedAt).Select(x => x.TotalItensSucesso).FirstOrDefault()))
                .ForMember(dst => dst.TotalItensInsucessoUltimoEvento, src => src.MapFrom(x => x.RotinasEventsHistories.OrderByDescending(x => x.CreatedAt).Select(x => x.TotalItensInsucesso).FirstOrDefault()))
                .ForMember(dst => dst.ExceptionMessageUltimoEvento, src => src.MapFrom(x => x.RotinasEventsHistories.OrderByDescending(x => x.CreatedAt).Select(x => x.ExceptionMensagem).FirstOrDefault()))
                .ForMember(dst => dst.DataCompetenciaInicio, src => src.MapFrom(x => x.DataCompetenciaInicio.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DataCompetenciaFim, src => src.MapFrom(x => x.DataCompetenciaFim.ToString("yyyy-MM-dd")));
            CreateMap<RotinaEventHistory, RotinaEventHistoryViewModel>();
        }
    }
}