using System.Reflection.Metadata.Ecma335;
using System;
using System.Linq;
using AutoMapper;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Models;
using BoxBack.Domain.ModelsServices;

namespace BoxBack.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ApplicationUserGroupViewModel, ApplicationUserGroup>();
            CreateMap<ApplicationUserGroupUpdateViewModel, ApplicationUserGroup>();
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
            CreateMap<ApplicationUserUpdateViewModel, ApplicationUserGroup>()
                .ForMember(dst => dst.UserId, src => src.MapFrom(x => x.Id));
            CreateMap<ApplicationUserUpdateViewModel, ApplicationUser>()
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
            CreateMap<ApplicationGroupUpdateViewModel, ApplicationGroup>();
            CreateMap<ApplicationRoleGroupUpdateViewModel, ApplicationRoleGroup>();
            CreateMap<ApplicationRoleGroupViewModel, ApplicationRoleGroup>();
            CreateMap<ApplicationRoleViewModel, ApplicationRole>();
            CreateMap<ClienteViewModel, Cliente>()
                .ForMember(dst => dst.ClienteContratos, src => src.MapFrom(x => x.Contratos));
            CreateMap<ClienteServicoViewModel, ClienteServico>()
                .ForMember(dst => dst.ServicoId, src => src.MapFrom(x => x.Servico.Id))
                .ForMember(dst => dst.Nome, src => src.MapFrom(x => x.Servico.Nome));
            CreateMap<ClienteProdutoViewModel, ClienteProduto>()
                .ForMember(dst => dst.ProdutoId, src => src.MapFrom(x => x.Produto.Id))
                .ForMember(dst => dst.Nome, src => src.MapFrom(x => x.Produto.Nome));
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
            CreateMap<ClienteContratoViewModel, ClienteContrato>();
            CreateMap<ClientePadraoIntegracaoViewModel, Cliente>();
            CreateMap<ClienteContratoPadraoIntegracaoViewModel, ClienteContrato>();
            CreateMap<BCClienteModelService, Cliente>()
               .ForMember(dst => dst.Id,  src => src.MapFrom(x => Guid.NewGuid()))
               .ForMember(dst => dst.TipoPessoa,  src => src.MapFrom(x => x.TipoPessoa == null ? null : x.TipoPessoa))
               .ForMember(dst => dst.NomeFantasia,  src =>
                                                    src.MapFrom(x => x.PessoaFisica == null ? x.PessoaJuridica.NomeFantasia : x.PessoaFisica.Nome))
               .ForMember(dst => dst.RazaoSocial,  src =>
                                                   src.MapFrom(x => x.PessoaFisica == null ? x.PessoaJuridica.RazaoSocial : x.PessoaFisica.Nome))
               .ForMember(dst => dst.InscricaoEstadual,  src => 
                                                         src.MapFrom(x => x.PessoaJuridica.InscricaoEstadual == null ? null : x.PessoaJuridica.InscricaoEstadual))
               .ForMember(dst => dst.CNPJ,  src => src.MapFrom(x => x.PessoaJuridica.Documento == null ? null : x.PessoaJuridica.Documento))
               .ForMember(dst => dst.TelefonePrincipal,  src => src.MapFrom(x => x.Contatos.Count() <= 0 ? null : x.Contatos.Select(x => x.Telefone).FirstOrDefault()))
               .ForMember(dst => dst.EmailPrincipal, src => src.MapFrom(x => x.Contatos.Count() <= 0 ? null : x.Contatos.Select(x => x.Email).FirstOrDefault()))
               .ForMember(dst => dst.Rua, src => src.MapFrom(x => x.Endereco == null ? null : x.Endereco.Logradouro))
               .ForMember(dst => dst.Numero, src => src.MapFrom(x => x.Endereco == null ? null : x.Endereco.Numero == null ? null : x.Endereco.Numero))
               .ForMember(dst => dst.Complemento, src => src.MapFrom(x => x.Endereco == null ? null : x.Endereco.Logradouro == null ? null : x.Endereco.Complemento))
               .ForMember(dst => dst.Cidade, src => src.MapFrom(x => x.Endereco == null ? null : x.Endereco.Cidade == null ? null : x.Endereco.Cidade))
               .ForMember(dst => dst.Estado, src => src.MapFrom(x => x.Endereco == null ? null : x.Endereco.Uf == null ? null : x.Endereco.Uf))
               .ForMember(dst => dst.Cep, src => src.MapFrom(x => x.Endereco == null ? null : x.Endereco.Cep == null ? null : x.Endereco.Cep))
               .ForMember(dst => dst.Cpf, src => src.MapFrom(x => x.PessoaJuridica == null ? x.PessoaFisica.Documento == null ? null : x.PessoaFisica.Documento : null));
            CreateMap<BCContratoModelService, ClienteContrato>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => Guid.NewGuid()))
                .ForMember(dst => dst.BomControleContratoId, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.ClienteId, src => src.MapFrom(x => Guid.Empty))
                .ForMember(dst => dst.ValorContrato, src => src.MapFrom(x => x.Valor))
                .ForMember(dst => dst.ValorContrato, src => src.MapFrom(x => x.Valor))
                .ForMember(dst => dst.Periodicidade, src => src.MapFrom(x => x.Periodicidade));
            CreateMap<BCFaturaModelService, ClienteContratoFatura>()
                .ForMember(dst => dst.Id, src => src.Ignore())
                .ForMember(dst => dst.BomControleFaturaId, src => src.MapFrom(x => x.Id));
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<FornecedorProdutoViewModel, FornecedorProduto>();
            CreateMap<VendedorViewModel, Vendedor>();
            CreateMap<VendedorContratoViewModel, VendedorContrato>()
                .ForMember(dst => dst.ComissaoPercentual, src => src.MapFrom(x => x.ComissaoPercentual))
                .ForMember(dst => dst.ComissaoReais, src => src.MapFrom(x => x.ComissaoReais));
            CreateMap<VendedorComissaoViewModel, VendedorComissao>();
            CreateMap<RotinaViewModel, Rotina>()
                .ForMember(dst => dst.DispatcherRoute, src => src.Ignore())
                .ForMember(dst => dst.PropertyId, src => src.Ignore());
            CreateMap<RotinaEventHistoryViewModel, RotinaEventHistory>();
        }
    }
}