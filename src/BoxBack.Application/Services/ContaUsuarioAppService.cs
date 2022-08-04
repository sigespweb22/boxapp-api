using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels;

namespace BoxBack.Application.Services
{
    public class ContaUsuarioAppService : IContaUsuarioAppService
    {
        private readonly IContaUsuarioRepository _contaUsuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ValidationResult _validationResult;

        public ContaUsuarioAppService(IContaUsuarioRepository contaUsuarioRepository,
                                     IUnitOfWork unitOfWork, 
                                     IMapper mapper,
                                     ValidationResult validationResult)
        {
            _contaUsuarioRepository = contaUsuarioRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationResult = validationResult;
        }
        public async Task<ContaUsuarioViewModel> GetByIdAsync(Guid id)
        {
            var contaUsuario = _mapper.Map<ContaUsuarioViewModel>(
                                    await _contaUsuarioRepository.GetByIdAsync(id));

            return contaUsuario;
        }
        public ContaUsuarioViewModel GetById(Guid id)
        {
            var contaUsuario = _mapper.Map<ContaUsuarioViewModel>(
                                    _contaUsuarioRepository.GetById(id));

            return contaUsuario;
        }
        public ContaUsuarioViewModel GetByUserId(string userId)
        {
            var contaUsuario = _mapper.Map<ContaUsuarioViewModel>(
                                    _contaUsuarioRepository.GetByUserId(userId));

            return contaUsuario;
        }
        public async Task<IEnumerable<ContaUsuarioViewModel>> GetAll()
        {
            var contaUsuarios = _mapper.Map<IEnumerable<ContaUsuarioViewModel>>(
                                     await _contaUsuarioRepository.GetAll());
            return contaUsuarios;
        }
        public void Add(ContaUsuarioViewModel contaUsuarioViewModel)
        {
            var contaUsuario = _mapper.Map<ContaUsuario>(contaUsuarioViewModel);
            
            _contaUsuarioRepository.Add(contaUsuario);
            _unitOfWork.Commit();
        }
        public ValidationResult Update(ContaUsuarioViewModel contaUsuarioViewModel)
        {
            var contaUsuarioDB = _contaUsuarioRepository
                                    .GetByIdWithInclude((Guid) contaUsuarioViewModel.Id);

            var colaboradorMapped = _mapper.Map<ContaUsuarioViewModel, 
                                    ContaUsuario>(contaUsuarioViewModel, contaUsuarioDB);
            
            // //Validação troca Situação
            // if (colaboradoDB.Situacao == ColaboradorSituacaoEnum.ADMITIDO &&
            //         colaboradorViewModel.Situacao == ColaboradorSituacaoEnum.EM_PROCESSO_ADMISSAO.ToString())
            // {
            //     _validationResult.AddErrorMessage("Colaborador situação 'ADMITIDO' só permite mudança de situação para 'DEMITIDO'.");
            //     return _validationResult;
            // }
            
            _contaUsuarioRepository.Update(colaboradorMapped);
            _unitOfWork.Commit();

            return _validationResult;
        }
        public void Remove(Guid id)
        {
            var contaUsuario = new ContaUsuario();

            _contaUsuarioRepository.Remove(id);
            _unitOfWork.Commit();
        }
        public void Dispose()
        {
            _contaUsuarioRepository.Dispose();
        }
    }
}