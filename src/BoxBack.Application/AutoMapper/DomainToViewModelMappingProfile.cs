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
            CreateMap<ContaUsuario, ContaUsuarioViewModel>()
                .ForMember(dst => dst.SetorId, src => src.MapFrom(x => (int) x.Setor))
                .ForMember(dst => dst.Setor, src => src.MapFrom(x => x.Setor))
                .ForMember(dst => dst.FuncaoId, src => src.MapFrom(x => (int) x.Funcao))
                .ForMember(dst => dst.Funcao, src => src.MapFrom(x => x.Funcao));
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dst => dst.UserId, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.ContaUsuarioViewModel, src => src.MapFrom(x => x.ContaUsuario));
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}