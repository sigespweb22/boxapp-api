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
using BoxBack.Domain.Enums;
using BoxBack.Application.ViewModels.Selects;
using BoxBack.WebApi.Controllers;
using BoxBack.Domain.ServicesThirdParty;
using System.Text.RegularExpressions;

namespace BoxBack.WebApi.EndPoints
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    public class UserEndpoint : ApiController
    {
        private readonly ICNPJAServices _cnpjaServices;
        private readonly BoxAppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public UserEndpoint(BoxAppDbContext context,
                             IUnitOfWork unitOfWork,
                             UserManager<ApplicationUser> manager, 
                             RoleManager<ApplicationRole> roleManager, 
                             IMapper mapper,
                             ICNPJAServices cnpjaServices)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _manager = manager;
            _roleManager = roleManager;
            _mapper = mapper;
            _cnpjaServices = cnpjaServices;
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Um json com os usuários</returns>
        /// <response code="200">Lista de usuários</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        [Authorize(Roles = "Master, CanUserList, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> ListAsync(string q)
        {
            #region Get data
            var users = new List<ApplicationUser>();
            try
            {
                users = await _manager.Users
                                        .AsNoTracking()
                                        .Include(x => x.ApplicationUserRoles)
                                        .ThenInclude(x => x.ApplicationRole)
                                        .Include(x => x.ApplicationUserGroups)
                                        .ThenInclude(x => x.ApplicationGroup)
                                        .OrderBy(x => x.UserName)
                                        .ToListAsync();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (users == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Filter search
            if(!string.IsNullOrEmpty(q))
                users = users.Where(x => x.FullName.Contains(q)).ToList();
            #endregion

            #region Map
            IEnumerable<ApplicationUserViewModel> userMap = new List<ApplicationUserViewModel>();
            try
            {
                userMap = _mapper.Map<IEnumerable<ApplicationUserViewModel>>(users);
                foreach(var tmp in userMap)
                {
                    tmp.UserName = tmp.UserName.Substring(0, tmp.UserName.IndexOf("@"));
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(new {
                AllData = userMap.ToList(),
                Usuarios = userMap.ToList(),
                Params = q,
                Total = userMap.Count()
            });
        }

        /// <summary>
        /// Lista um usuário pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto tipado com o usuário</returns>
        /// <response code="200">O usuário</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Registro não encontrado</response>
        [Authorize(Roles = "Master, CanUserRead, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("list-one/{id}")]
        [HttpGet]
        public async Task<IActionResult> ListOneAsync([FromRoute]string id)
        {
            #region Required validations
            if(string.IsNullOrEmpty(id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var user = new ApplicationUser();
            try
            {
                user = await _context
                                .Users
                                .AsNoTracking()
                                .Include(x => x.ApplicationUserGroups)
                                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (user == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var userMap = new ApplicationUserViewModel();
            try
            {
                userMap = _mapper.Map<ApplicationUserViewModel>(user);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(user);
        }

        /// <summary>
        /// Lista todos os usuários ativos
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Um json com os usuários ativos</returns>
        /// <response code="200">Lista de usuários ativos</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Lista vazia</response>
        [Authorize(Roles = "Master, CanUserList, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("list-to-select")] 
        [HttpGet]
        public async Task<IActionResult> ListToSelectAsync(string q)
        {
            #region Get data
            var users = new List<ApplicationUserSelect2ViewModel>();
            var usersDB = new List<ApplicationUser>();
            try
            {
                usersDB = await _manager.Users.ToListAsync();
                if (usersDB == null)
                {
                    AddError("Não encontrado");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            #region Map
            try
            {
                foreach(var user in usersDB)
                {
                    var tmp = new ApplicationUserSelect2ViewModel()
                    {
                        UserId = user.Id.ToString(),
                        FullName = user.FullName
                    };
                    users.Add(tmp);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(users);
        }

        /// <summary>
        /// Cria um usuário
        /// </summary>
        /// <param name="applicationUserViewModel"></param>
        /// <returns>True se adicionardo com sucesso</returns>
        /// <response code="201">Criado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Authorize(Roles = "Master, CanUserCreate, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ApplicationUserViewModel applicationUserViewModel)
        {
            #region Validations required
            if (string.IsNullOrEmpty(applicationUserViewModel.Password))
            {
                AddError("Senha é requerida.");
                return CustomResponse(400);
            }
            #endregion

            #region Check to password pattern
            try
            {
                Regex passwordRE = new Regex(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!$*&@#])[0-9a-zA-Z!$*&@#]{6,}");
                if (!passwordRE.IsMatch(applicationUserViewModel.Password))
                {
                    AddError("Padrão de senha não corresponde ao esperado. \nVerifique os requisitos de senha.");
                    return CustomResponse(400);
                }    
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Map
            var userMap = new ApplicationUser();
            applicationUserViewModel.Id = Guid.NewGuid().ToString();
            applicationUserViewModel.UserId = applicationUserViewModel.Id;
            try
            {
                userMap = _mapper.Map<ApplicationUser>(applicationUserViewModel);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Map set fixeds values
            userMap.LockoutEnabled = true;
            userMap.TwoFactorEnabled = false;
            userMap.EmailConfirmed = true;
            userMap.Avatar = "5.png";
            userMap.Status = ApplicationUserStatusEnum.PENDING;
            #endregion

            #region Persitance user data and password
            var signIn = new IdentityResult();
            try
            {

                signIn = await _manager.CreateAsync(userMap);
                
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (signIn.Succeeded)
            {
                try
                {
                    await _manager.AddPasswordAsync(userMap, applicationUserViewModel.Password);    
                }
                catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            } else if (signIn.Errors.Count() > 0)
            {
                foreach (var error in signIn.Errors)
                {
                    switch(error.Code)
                    {
                        case "DuplicateUserName":
                            AddError("Usuário já existe.");
                            return CustomResponse(400);
                        default:
                            AddError(error.Code);
                            return CustomResponse(400);
                    }    
                }
            }
            #endregion

            #region Commit
             _unitOfWork.Commit();
            #endregion

            return CustomResponse(201);
        }

        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="applicationUserViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        [Authorize(Roles = "Master, CanUserUpdate, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]ApplicationUserUpdateViewModel applicationUserViewModel)
        {
            #region Required validations
            if (string.IsNullOrEmpty(applicationUserViewModel.Id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var userDB = new ApplicationUser();
            try
            {
                userDB = await _context
                                    .Users
                                    .Include(x => x.ApplicationUserGroups)
                                    .FirstOrDefaultAsync(x => x.Id.Equals(applicationUserViewModel.Id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (userDB == null)
            {
                AddError("Usuário não encontrada para atualizar.");
                return CustomResponse(404);
            }
            #endregion 

            #region Grupos remove | Mudar isso pelo amooooor
            _context.ApplicationUserGroups.RemoveRange(userDB.ApplicationUserGroups);
            #endregion

            #region Map User | Mudar isso pelo amoooor
            // Map User
            var userMap = new ApplicationUser();
            try 
            {
                applicationUserViewModel.EmailConfirmed = userDB.EmailConfirmed;
                applicationUserViewModel.LockoutEnd = userDB.LockoutEnd;
                applicationUserViewModel.LockoutEnabled = userDB.LockoutEnabled;
                applicationUserViewModel.Avatar = userDB.Avatar;
                applicationUserViewModel.Funcao = userDB.Funcao.ToString();
                applicationUserViewModel.Setor = userDB.Setor.ToString();
                applicationUserViewModel.Status = userDB.Status.ToString();
                userMap = _mapper.Map<ApplicationUserUpdateViewModel, ApplicationUser>(applicationUserViewModel, userDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update user
            try
            {
                _context.Users.Update(userMap);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se deletado com sucesso</returns>
        /// <response code="204">Deletado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Not found</response>
        [Route("delete/{id}")]
        [Authorize(Roles = "Master, CanUserDelete, CanUserAll")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            #region Validations required
            if (string.IsNullOrEmpty(id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion
    
            #region Generals validations
            // implementar
            #endregion

            #region Get data
            var user = new ApplicationUser();
            try
            {
                user = await _manager.FindByIdAsync(id);
                if (user == null)
                {
                    AddError("Usuário não encontrado para deletar.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Delete
            try
            {
                await _manager.DeleteAsync(user);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(204);
        }

        /// <summary>
        /// Altera o status de um usuário
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
        [Route("alter-status/{id}")]
        [Authorize(Roles = "Master, CanUserUpdate, CanUserAll")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> AlterStatusAsync(string id)
        {
            #region Validations required
            if (string.IsNullOrEmpty(id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion
    
            #region Get data
            var user = new ApplicationUser();
            try
            {
                user = await _manager.FindByIdAsync(id);
                if (user == null)
                {
                    AddError("Usuário não encontrado para alterar seu status.");
                    return CustomResponse(404);
                }
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Map
            switch(user.Status)
            {
                case ApplicationUserStatusEnum.ACTIVE:
                    user.Status = ApplicationUserStatusEnum.INACTIVE;
                    break;
                case ApplicationUserStatusEnum.INACTIVE:
                    user.Status = ApplicationUserStatusEnum.ACTIVE;
                    break;
                case ApplicationUserStatusEnum.PENDING:
                    user.Status = ApplicationUserStatusEnum.ACTIVE;
                    break;
                default:
                    user.Status = ApplicationUserStatusEnum.INACTIVE;
                    break;
            }
            #endregion

            #region Alter status
            try
            {
                await _manager.UpdateAsync(user);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            #endregion

            return CustomResponse(200, new { message = "Status usuário alterado com sucesso." } );
        }


        #region Methods Usuário Conta
        
        /// <summary>
        /// Lista a conta de um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto da conta do usuário</returns>
        /// <response code="200">A conta do usuários</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Registro não encontrado</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanUserRead, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("conta/list-one/{id}")]
        [HttpGet]
        public async Task<IActionResult> ContaListOneAsync([FromRoute]string id)
        {
            #region Required validations
            if(string.IsNullOrEmpty(id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var user = new ApplicationUser();
            try
            {
                user = await _context
                                .Users
                                .AsNoTracking()
                                .Include(x => x.ApplicationUserGroups)
                                .ThenInclude(x => x.ApplicationGroup)
                                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (user == null)
            {
                AddError("Não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var usuarioContaMap = new UsuarioContaViewModel();
            try
            {
                usuarioContaMap = _mapper.Map<UsuarioContaViewModel>(user);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(usuarioContaMap);
        }

        /// <summary>
        /// Atualiza uma conta de usuário
        /// </summary>
        /// <param name="usuarioContaViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanUserUpdate, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("conta/update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]UsuarioContaViewModel usuarioContaViewModel)
        {
            #region Required validations
            if (string.IsNullOrEmpty(usuarioContaViewModel.Id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var userDB = new ApplicationUser();
            try
            {
                userDB = await _context
                                    .Users
                                    .FirstOrDefaultAsync(x => x.Id.Equals(usuarioContaViewModel.Id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (userDB == null)
            {
                AddError("Usuário não encontrada para atualizar a conta.");
                return CustomResponse(404);
            }
            #endregion 

            #region Map User | Mudar isso pelo amoooor
            // Map User
            var usuarioContaMap = new ApplicationUser();
            try 
            {
                usuarioContaViewModel.NormalizedUserName = usuarioContaViewModel.UserName.ToUpper();
                usuarioContaViewModel.NormalizedEmail = usuarioContaViewModel.Email.ToUpper();
                usuarioContaMap = _mapper.Map<UsuarioContaViewModel, ApplicationUser>(usuarioContaViewModel, userDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update user
            try
            {
                _context.Users.Update(usuarioContaMap);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(204);
        }

        #endregion

        #region Methods Usuário Segurança
        /// <summary>
        /// Atualiza dados de segurança do usuário
        /// </summary>
        /// <param name="usuarioSegurancaViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanUserUpdate, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("seguranca/update")]
        [HttpPut]
        public async Task<IActionResult> SegurancaUpdateAsync([FromBody]UsuarioSegurancaViewModel usuarioSegurancaViewModel)
        {
            #region Required validations
            if (string.IsNullOrEmpty(usuarioSegurancaViewModel.Id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }

            if (string.IsNullOrEmpty(usuarioSegurancaViewModel.CurrentPassword))
            {
                AddError("Senha Atual é requerida.");
                return CustomResponse(400);
            }

            if (string.IsNullOrEmpty(usuarioSegurancaViewModel.NewPassword))
            {
                AddError("Nova Senha é requerida.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var userDB = new ApplicationUser();
            try
            {
                userDB = await _context
                                    .Users
                                    .FirstOrDefaultAsync(x => x.Id.Equals(usuarioSegurancaViewModel.Id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (userDB == null)
            {
                AddError("Usuário não encontrada para atualizar seus dados de segurança.");
                return CustomResponse(404);
            }
            #endregion 

            #region Check senha atual - Check tentando fazer login com a senha e as credenciais do usuários
            bool checkCurrentPassword;
            try
            {
                checkCurrentPassword = await _manager.CheckPasswordAsync(userDB, usuarioSegurancaViewModel.CurrentPassword);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (!checkCurrentPassword)
            {
                AddError("Senha Atual inválida!");
                return CustomResponse(400);
            }
            #endregion

            #region Check to password pattern
            try
            {
                Regex passwordRE = new Regex(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!$*&@#])[0-9a-zA-Z!$*&@#]{6,}");
                if (!passwordRE.IsMatch(usuarioSegurancaViewModel.NewPassword))
                {
                    AddError("Padrão de senha não corresponde ao esperado. \nVerifique os requisitos de senha.");
                    return CustomResponse(400);
                }    
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Get code (Token to reset)
            String code;
            try
            {
                code = await _manager.GeneratePasswordResetTokenAsync(userDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            
            if (code == null)
            {
                AddError("Problemas ao obter o token de reset de senha. Tente novamente, persistindo o problema informe a equipe técnica do sistema.");
                return CustomResponse(400);
            }
            #endregion

            #region Reset password
            var result = new IdentityResult();
            try
            {
                result = await _manager.ResetPasswordAsync(userDB, code, usuarioSegurancaViewModel.NewPassword);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    AddError(error.Description);
                }
                return CustomResponse(400);
            }
            #endregion

            return CustomResponse(204);
        }
        #endregion

        #region Methods Usuário Informações pessoais

        /// <summary>
        /// Lista as informações pessoais do usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto com as informações pessoais do usuário</returns>
        /// <response code="200">As informações pessoais do usuários</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Registro não encontrado</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanUserRead, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("info/list-one/{id}")]
        [HttpGet]
        public async Task<IActionResult> InfosListOneAsync([FromRoute]string id)
        {
            #region Required validations
            if(string.IsNullOrEmpty(id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data
            var user = new ApplicationUser();
            try
            {
                user = await _context
                                .Users
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            if (user == null)
            {
                AddError("Usuário não encontrado.");
                return CustomResponse(404);
            }
            #endregion
            
            #region Map
            var usuarioInfosMap = new UsuarioInfoViewModel();
            try
            {
                usuarioInfosMap = _mapper.Map<UsuarioInfoViewModel>(user);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion
            
            return Ok(usuarioInfosMap);
        }
        
        /// <summary>
        /// Atualiza informações pessoais do usuário
        /// </summary>
        /// <param name="usuarioInfoViewModel"></param>
        /// <returns>True se atualizada com sucesso</returns>
        /// <response code="204">Atualizada com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Authorize(Roles = "Master, CanUserUpdate, CanUserAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("info/update")]
        [HttpPut]
        public async Task<IActionResult> InfoUpdateAsync([FromBody]UsuarioInfoViewModel usuarioInfoViewModel)
        {
            #region Required validations
            if (string.IsNullOrEmpty(usuarioInfoViewModel.Id))
            {
                AddError("Id requerido.");
                return CustomResponse(400);
            }
            #endregion

            #region Get data for update
            var userDB = new ApplicationUser();
            try
            {
                userDB = await _context
                                    .Users
                                    .FirstOrDefaultAsync(x => x.Id.Equals(usuarioInfoViewModel.Id));
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            if (userDB == null)
            {
                AddError("Usuário não encontrada para atualizar seus dados pessoais.");
                return CustomResponse(404);
            }
            #endregion 

            #region Map
            var userMap = new ApplicationUser();
            try
            {
                userMap = _mapper.Map<UsuarioInfoViewModel, ApplicationUser>(usuarioInfoViewModel, userDB);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Update user
            try
            {
                _context.Users.Update(userMap);
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            #endregion

            return CustomResponse(204);
        }
        #endregion
    }
}