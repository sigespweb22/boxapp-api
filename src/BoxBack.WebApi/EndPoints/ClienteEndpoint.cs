using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoxBack.Infra.Data.Context;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Models;
using AutoMapper;
using BoxBack.Domain.InterfacesRepositories;
using BoxBack.WebApi.Controllers;
using BoxBack.Domain.ServicesThirdParty;
using BoxBack.Domain.ModelsServices;
using BoxBack.Application.ViewModels.Selects;
using BoxBack.Domain.Enums;
using BoxBack.WebApi.Helpers;
using BoxBack.Application.Interfaces;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/clientes")]
    public class ClienteEndpoint : ApiController
    {
        private readonly ICNPJAServices _cnpjaServices;
        private readonly IBCServices _bcServices;
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IClienteAppService _clienteAppService;

        public ClienteEndpoint(BoxAppDbContext context,
                               IUnitOfWork unitOfWork,
                               UserManager<ApplicationUser> manager, 
                               RoleManager<ApplicationRole> roleManager,
                               IMapper mapper,
                               ICNPJAServices cnpjaServices,
                               IBCServices bcServices,
                               IClienteAppService clienteAppService)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _manager = manager;
            _roleManager = roleManager;
            _mapper = mapper;
            _cnpjaServices = cnpjaServices;
            _bcServices = bcServices;
            _clienteAppService = clienteAppService;
        }

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Um json com os clientes</returns>
        /// <response code="200">Lista de clientes</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        [Authorize(Roles = "Master, CanClienteList, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q)
        {
            #region Get data
            var clientes = new List<Cliente>();
            Guid id;
            try
            {
                if (Guid.TryParse(q, out id))
                {
                    clientes = await _context.Clientes
                                                .AsNoTracking()
                                                .Where(x => x.Id == id)
                                                .OrderByDescending(x => x.UpdatedAt)
                                                .ToListAsync();
                } 
                else
                {
                    clientes = await _context.Clientes
                                            .AsNoTracking()
                                            .Include(x => x.ClienteContratos)
                                            .OrderByDescending(x => x.UpdatedAt)
                                            .ToListAsync();
                }
                
                if (clientes == null)
                {
                    AddError("Não encontrado.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Filter search
            if(!string.IsNullOrEmpty(q))
                clientes = clientes.Where(x => x.RazaoSocial.Contains(q)).ToList();
            #endregion

            #region Map
            IEnumerable<ClienteViewModel> clienteMapped = new List<ClienteViewModel>();
            try
            {
                clienteMapped = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = clienteMapped.ToList(),
                Clientes = clienteMapped.ToList(),
                Params = q,
                Total = clienteMapped.Count()
            });
        }

        /// <summary>
        /// Lista todos os clientes para uma select2
        /// </summary>
        /// <param name="q"></param>
        /// <param name="isDeleted"></param>
        /// <returns>Um json com os clientes</returns>
        /// <response code="200">Lista de clientes</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteList, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("list-to-select")] 
        [HttpGet]
        public async Task<IActionResult> ListToSelectAsync(string q, bool isDeleted = false)
        {
            #region Get data
            var clientesDB = new List<Cliente>();
            try
            {
                clientesDB = await _context
                                        .Clientes
                                        .Where(x => !x.IsDeleted || x.IsDeleted == isDeleted)
                                        .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (clientesDB == null)
            {
                AddError("Não encontrado");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            IEnumerable<ClienteSelect2ViewModel> clientesMap = new List<ClienteSelect2ViewModel>();
            try
            {
                clientesMap = _mapper.Map<IEnumerable<ClienteSelect2ViewModel>>(clientesDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(clientesMap);
        }

        /// <summary>
        /// Cria um cliente
        /// </summary>
        /// <param name="clienteViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Authorize(Roles = "Master, CanClienteCreate, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ClienteViewModel clienteViewModel)
        {
            #region Validations required
            if (clienteViewModel.TipoPessoa == TipoPessoaEnum.JURIDICA.ToString())
            {
                if (string.IsNullOrEmpty(clienteViewModel.CNPJ))
                {
                    AddError("Cnpj é requerido para tipo pessoa JURIDICA.");
                    return CustomResponse(400);
                }

                if (string.IsNullOrEmpty(clienteViewModel.RazaoSocial))
                {
                    AddError("Razão social é requerida para tipo pessoa JURIDICA.");
                    return CustomResponse(400);
                }
            } else if (clienteViewModel.TipoPessoa == TipoPessoaEnum.FISICA.ToString()) {
                if (string.IsNullOrEmpty(clienteViewModel.Cpf))
                {
                    AddError("Cpf é requerido para tipo pessoa FISICA.");
                    return CustomResponse(400);
                }
            }
            #endregion

            #region Clean CNPJ/CPF/Telefone to Map
            if (clienteViewModel.TipoPessoa == TipoPessoaEnum.JURIDICA.ToString()) 
            {
                clienteViewModel.CNPJ = StringHelpers.CnpjClean(clienteViewModel.CNPJ);
            } else if (clienteViewModel.TipoPessoa == TipoPessoaEnum.FISICA.ToString()) {
                clienteViewModel.Cpf = StringHelpers.CpfClean(clienteViewModel.Cpf);
            }
            
            if (!string.IsNullOrEmpty(clienteViewModel.TelefonePrincipal)) {
                clienteViewModel.TelefonePrincipal = StringHelpers.TelefoneClean(clienteViewModel.TelefonePrincipal);
            }
            #endregion

            #region Map
            var clienteMapped = new Cliente();
            try
            {
                clienteMapped = _mapper.Map<Cliente>(clienteViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Validations
            bool alreadySameCNPJ;
            bool alreadySameCPF;

            switch (clienteViewModel.TipoPessoa)
            {
                case "FISICA":
                    try
                    {
                        alreadySameCPF = await _context
                                                    .Clientes
                                                    .AnyAsync(x => x.Cpf == clienteViewModel.Cpf);
                    }
                    catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

                    if (alreadySameCPF)
                    {
                        AddError("Já existe um cliente cadastrado com o mesmo CPF informado.");
                        return CustomResponse(400);
                    }
                    break;
                case "JURIDICA":
                    try
                    {
                        alreadySameCNPJ = await _context
                                                    .Clientes
                                                    .AnyAsync(x => x.CNPJ == clienteViewModel.CNPJ);
                    }
                    catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
                    if (alreadySameCNPJ)
                    {
                        AddError("Já existe um cliente cadastrado com o mesmo CNPJ informado.");
                        return CustomResponse(400);
                    }
                    break;
                default:
                    AddError("Tipo pessoa obrigatório.");
                    return CustomResponse(400);
            }
            #endregion

            #region Persistance and commit
            try
            {
                await _context.Clientes.AddAsync(clienteMapped);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(201);
        }

        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <param name="clienteViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Authorize(Roles = "Master, CanClienteUpdate, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]ClienteViewModel clienteViewModel)
        {
            #region Required validations
            if (clienteViewModel.Id == null ||
                clienteViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }

            if (clienteViewModel.TipoPessoa == TipoPessoaEnum.JURIDICA.ToString())
            {
                if (string.IsNullOrEmpty(clienteViewModel.CNPJ))
                {
                    AddError("Cnpj é requerido para tipo pessoa JURIDICA.");
                    return CustomResponse(400);
                }
                
                if (string.IsNullOrEmpty(clienteViewModel.RazaoSocial))
                {
                    AddError("Razão social é requerida para tipo pessoa JURIDICA.");
                    return CustomResponse(400);
                }
            } else if (clienteViewModel.TipoPessoa == TipoPessoaEnum.FISICA.ToString()) {
                if (string.IsNullOrEmpty(clienteViewModel.Cpf))
                {
                    AddError("Cpf é requerido para tipo pessoa FISICA.");
                    return CustomResponse(400);
                }
            }
            #endregion

            #region Clean CNPJ/CPF/Telefone to Map
            if (clienteViewModel.TipoPessoa == TipoPessoaEnum.JURIDICA.ToString()) 
            {
                clienteViewModel.CNPJ = StringHelpers.CnpjClean(clienteViewModel.CNPJ);
            } else if (clienteViewModel.TipoPessoa == TipoPessoaEnum.FISICA.ToString()) {
                clienteViewModel.Cpf = StringHelpers.CpfClean(clienteViewModel.Cpf);
            }

            if (!string.IsNullOrEmpty(clienteViewModel.TelefonePrincipal)) {
                clienteViewModel.TelefonePrincipal = StringHelpers.TelefoneClean(clienteViewModel.TelefonePrincipal);
            }
            #endregion

            #region Get data for update
            var clienteDB = new Cliente();
            try
            {
                clienteDB = await _context
                                    .Clientes
                                    .FindAsync(clienteViewModel.Id);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (clienteDB == null)
            {
                AddError("Cliente não encontrada para atualizar.");
                return CustomResponse(404);
            }
            #endregion

            #region Validations
            bool alreadySameCNPJ;
            bool alreadySameCPF;

            switch (clienteViewModel.TipoPessoa)
            {
                case "FISICA":
                    try
                    {
                        alreadySameCPF = await _context
                                                    .Clientes
                                                    .Where(x => x.Id != clienteViewModel.Id)
                                                    .AnyAsync(x => x.Cpf == clienteViewModel.Cpf);
                    }
                    catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

                    if (alreadySameCPF)
                    {
                        AddError("Já existe um cliente cadastrado com o mesmo CPF informado.");
                        return CustomResponse(400);
                    }
                    break;
                case "JURIDICA":
                    try
                    {
                        alreadySameCNPJ = await _context
                                                    .Clientes
                                                    .Where(x => x.Id != clienteViewModel.Id)
                                                    .AnyAsync(x => x.CNPJ == clienteViewModel.CNPJ);
                    }
                    catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
                    if (alreadySameCNPJ)
                    {
                        AddError("Já existe um cliente cadastrado com o mesmo CNPJ informado.");
                        return CustomResponse(400);
                    }
                    break;
                default:
                    AddError("Tipo pessoa obrigatório.");
                    return CustomResponse(400);
            }
            #endregion

            #region Map
            var clienteMap = new Cliente();
            try
            {
                clienteMap = _mapper.Map<ClienteViewModel, Cliente>(clienteViewModel, clienteDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update cliente
            try
            {
                _context.Clientes.Update(clienteMap);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Check to result
            try
            {
                await _unitOfWork.CommitAsync(); 
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Deleta um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se deletado com sucesso</returns>
        /// <response code="204">Deletado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Master, CanClienteDelete, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            #region Validations required
            if (id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion
    
            #region Generals validations
            // implementar
            #endregion

            #region Get data
            var cliente = new Cliente();
            try
            {
                cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    AddError("Cliente não encontrado para deletar.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Delete
            try
            {
                _context.Clientes.Remove(cliente);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Altera o status de um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se a operação foi realizada com sucesso</returns>
        /// <response code="200">Status alterado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /alter-status
        ///     {
        ///        "id": "f9c7d5a6-1181-4591-948b-5f97088e20a4"
        ///     }
        ///
        /// </remarks>
        
        [Authorize(Roles = "Master, CanClienteUpdate, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("alter-status/{id}")]
        [HttpPut]
        public async Task<IActionResult> AlterStatusAsync(Guid id)
        {
            #region Validations required
            if (id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion
    
            #region Get data
            var cliente = new Cliente();
            try
            {
                cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    AddError("Cliente não encontrado para alterar seu status.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Map
            switch(cliente.IsDeleted)
            {
                case true:
                    cliente.IsDeleted = false;
                    break;
                case false:
                    cliente.IsDeleted = true;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                _context.Clientes.Update(cliente);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(200, new { message = "Status cliente alterado com sucesso." } );
        }

        /// <summary>
        /// Retorna um cliente pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto com o cliente solicitado</returns>
        /// <response code="200">Lista um cliente</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Cliente não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [Authorize(Roles = "Master, CanClienteRead, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("list-one/{id}")]
        [HttpGet]
        public async Task<IActionResult> ListOneAsync([FromRoute]string id)
        {
            #region Required validations
            if (string.IsNullOrEmpty(id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var cliente = new Cliente();
            try
            {
                cliente = await _context.Clientes
                                            .FindAsync(Guid.Parse(id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (cliente == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var clienteMapped = new ClienteViewModel();
            try
            {
                clienteMapped = _mapper.Map<ClienteViewModel>(cliente);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                Data = clienteMapped,
                Cliente = clienteMapped,
                Params = id
            });
        }

        #region Third Party
        /// <summary>
        /// Lista os dados do CNPJ de uma empresa a partir de uma api de terceiro
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns>Um json com os dados da empresa</returns>
        /// <response code="200">Dados da empresa</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">CNPJ não encontrado</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /tp
        ///     {
        ///        "cnpj": "23831562000182"
        ///     }
        ///
        /// </remarks>
        [Authorize(Roles = "Master, CanClienteCreate, CanClienteAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("tp/{cnpj}")]
        [HttpGet]
        public async Task<IActionResult> GetByApiThirdPartyByCnpj(string cnpj)
        {
            #region Required validations
            if (string.IsNullOrEmpty(cnpj))
            {
                AddError("CNPJ requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var empresa = new CNPJaEmpresaModelService();
            try
            {
                empresa = await _cnpjaServices.ConsultaEstabelecimento(cnpj);
                if (empresa == null)
                {
                    AddError("Empresa não encontrada com o CNPJ informado.");
                    return CustomResponse(404, empresa);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(400); }
            #endregion
            
            return CustomResponse(200, empresa);
        }

        [Route("tp/bc/alter/{id}")]
        [HttpGet]
        public async Task<IActionResult> TPBCAlterAsync(string id)
        {
            #region Required validations
            if (string.IsNullOrEmpty(id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Chave api resolve
            var chaveApiTerceiro = new ChaveApiTerceiro();
            try
            {
                chaveApiTerceiro = await _context
                                                .ChavesApiTerceiro
                                                .Where(x => x.DataValidade >= DateTimeOffset.Now &&
                                                       x.IsDeleted == false && !string.IsNullOrEmpty(x.Key))
                                                .FirstOrDefaultAsync(x => x.ApiTerceiro.Equals(ApiTerceiroEnum.BOM_CONTROLE));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (chaveApiTerceiro == null)
            { 
                AddError("Nenhuma chave de api de terceiro encontrada, verifique os possíveis erros: \n\nNenhuma chave de api cadastrada para esta integração. \n\nA chave de api cadastrada não possui uma Key. \n\nA chave de api cadastrada não está ativa. \n\nA chave de api cadastrada está com Data de Validade vencida.");
                return CustomResponse(404);
            }
            #endregion

            #region Token resolve
            String token = string.Empty;
            try
            {
                token = $"ApiKey {chaveApiTerceiro.Key}";
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Get data
            var cliente = new BCClienteModelService();
            try
            {
                cliente = await _bcServices.ClienteObter(id, token);
                if (cliente == null)
                {
                    AddError("Cliente não encontrado com o Id informado.");
                    return CustomResponse(404, cliente);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(400); }
            #endregion
            
            return CustomResponse(200, cliente);
        }
        #endregion
    }
}