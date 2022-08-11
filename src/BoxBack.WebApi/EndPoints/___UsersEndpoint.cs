// using System.Net.Http.Headers;
// using System.Net.NetworkInformation;
// using System.Xml.Linq;
// using System.Net.Sockets;
// using System.ComponentModel.DataAnnotations;
// using System.Net.Mime;
// using System.Reflection.Metadata;
// using System;
// using System.Linq;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using BoxBack.Infra.Data.Context;
// using BoxBack.WebApi.Extensions;
// using BoxBack.Application.ViewModels;
// using BoxBack.Domain.Models;
// using AutoMapper;
// using AutoMapper.QueryableExtensions;
// using BoxBack.Domain.Interfaces;
// using BoxBack.Domain.Enums;
// using BoxBack.Application.Interfaces;
// using BoxBack.Application.ViewModels.Selects;
// using BoxBack.Infra.Data.Extensions;
// using BoxBack.WebApi.Controllers;

// namespace BoxBack.WebApi.EndPoints
// {
//     [ApiController]
//     [Route("api/users")]
//     public class UsersEndpoint : ApiController
//     {
//         private readonly BoxAppDbContext _context;
//         private readonly UserManager<ApplicationUser> _manager;
//         private readonly IContaUsuarioAppService _contaUsuarioAppService;
//         private readonly IContaUsuarioRepository _contaUsuarioRepository;
//         private readonly RoleManager<ApplicationRole> _roleManager;
//         private readonly IMapper _mapper;
//         private readonly ValidationResult _validationResult;

//         public UsersEndpoint(BoxAppDbContext context,
//                              UserManager<ApplicationUser> manager, RoleManager<ApplicationRole> roleManager, IMapper mapper, IContaUsuarioAppService contaUsuarioAppService, IContaUsuarioRepository contaUsuarioRepository, ValidationResult validationResult)
//         {
//             _context = context;
//             _manager = manager;
//             _roleManager = roleManager;
//             _mapper = mapper;
//             _contaUsuarioAppService = contaUsuarioAppService;
//             _contaUsuarioRepository = contaUsuarioRepository;
//             _validationResult = validationResult;
//         }

//         [HttpGet]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         public async Task<ActionResult<IEnumerable<ApplicationUserViewModel>>> Get()
//         {
//             var users = await _manager.Users
//                                 .AsNoTracking()
//                                 .Include(x => x.ApplicationUserRoles)
//                                 .ThenInclude(x => x.ApplicationRole)
//                                 .ToListAsync();

//             var usersRet = new List<ApplicationUserViewModel>();
            
//             foreach (var user in users)
//             {
//                 var userMapped = MapperExtensions.MapWithChildren<ApplicationUserViewModel>(user);

//                 usersRet.Add(userMapped);
//             }
            
//             return Ok(new { data = usersRet, recordsTotal = users.Count, recordsFiltered = users.Count });
//         }

//         [HttpGet("{id}")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         public async Task<ActionResult<ApplicationUser>> Get([FromRoute]string id) => Ok(await _manager.FindByIdAsync(id));

//         [HttpPost]
//         [ProducesResponseType(StatusCodes.Status201Created)]
//         public async Task<IActionResult> Create([FromBody]ApplicationUserViewModel viewModel)
//         {
//             //Create DTO for db
//             ApplicationUser applicationUser = new ApplicationUser {
//                 Id = Guid.NewGuid().ToString(),
//                 UserName = viewModel.UserName,
//                 NormalizedUserName = viewModel.UserName.ToUpper(),
//                 Email = viewModel.Email,
//                 NormalizedEmail = viewModel.Email.ToUpper(),
//                 TwoFactorEnabled = viewModel.TwoFactorEnabled,
//                 EmailConfirmed = true,
//                 ApplicationUserRoles = new List<ApplicationUserRole>()
//             };

//             if (!viewModel.ApplicationUserRoles.IsNullOrEmpty()) 
//             {
//                 foreach (var viewModelApplicationUserRole in viewModel.ApplicationUserRoles)
//                 {
//                     //obtenho o id da role
//                     var roleIdDB = await _roleManager.FindByNameAsync(viewModelApplicationUserRole);

//                     //adiciono ao applicationUser no filho da iteração applicationUserRole a role que será inserida na tabela intermediária
//                     var applicatioUserRole = new ApplicationUserRole {
//                         UserId = applicationUser.Id,
//                         RoleId = roleIdDB.Id
//                     };

//                     applicationUser.ApplicationUserRoles.Add(applicatioUserRole);              
//                 }
//             }

//             var result = await _manager.CreateAsync(applicationUser);

//             if (result.Succeeded)
//             {
//                 // HACK: This password is just for demonstration purposes!
//                 // Please do NOT keep it as-is for your own project!
//                 result = await _manager.AddPasswordAsync(applicationUser, "Password123*");

//                 if (result.Succeeded)
//                 {
//                     //Adiciono uma conta para o usuário recém criado
//                     var contaUsuario = new ContaUsuarioViewModel();
//                     contaUsuario.UserId = applicationUser.Id;
//                     contaUsuario.Nome = applicationUser.Email;
//                     contaUsuario.Setor = SetorEnum.NAO_INFORMADO.ToString();
//                     contaUsuario.Funcao = FuncaoEnum.NAO_INFORMADO.ToString();
//                     contaUsuario.PerfilFoto = "data:image/png;base64,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";

//                     _contaUsuarioAppService.Add(contaUsuario);

//                     return CreatedAtAction("Get", new { id = applicationUser.Id }, 
                    
//                     MapperExtensions.MapWithChildren<ApplicationUserViewModel>(applicationUser));
//                 }
//             }

//             return BadRequest(result);
//         }

//         [HttpPut]
//         [ProducesResponseType(StatusCodes.Status204NoContent)]
//         public async Task<IActionResult> Update([FromBody]ApplicationUserViewModel viewModel) 
//         {
//             //Recupero o applicationUser do banco para atualizá-lo
//             ApplicationUser applicationUserDB = await _manager.Users
//                                                     .Include(x => x.ApplicationUserRoles)
//                                                     .ThenInclude(xt => xt.ApplicationRole)
//                                                     .Where(x => x.Id == viewModel.UserId)
//                                                     .FirstOrDefaultAsync();

//             applicationUserDB.UserName = viewModel.UserName;
//             applicationUserDB.Email = viewModel.Email;
//             applicationUserDB.TwoFactorEnabled = viewModel.TwoFactorEnabled;

//             //Removo todos os applicationUserRoles obtidos no pai applicationUserDb
//             applicationUserDB.ApplicationUserRoles.Clear();

//             //Adiciono as applicationUserRoles no objeto que será atualizado
//             foreach (var viewModelApplicationUserRole in viewModel.ApplicationUserRoles)
//             {
//                 //obtenho o id da role
//                 var roleIdDB = await _roleManager.FindByNameAsync(viewModelApplicationUserRole);

//                 //adiciono ao applicationUser no filho da iteração applicationUserRole a role que será inserida na tabela intermediária
//                 var applicatioUserRole = new ApplicationUserRole {
//                     UserId = applicationUserDB.Id,
//                     RoleId = roleIdDB.Id
//                 };

//                 applicationUserDB.ApplicationUserRoles.Add(applicatioUserRole);
//             }

//             var result = await _context.UpdateAsync(applicationUserDB, applicationUserDB.Id);

//             if (result.Succeeded)
//             {
//                 var contaUsuario = _contaUsuarioRepository.GetByUserId(applicationUserDB.Id.ToString());
                
//                 if (contaUsuario == null)
//                 {
//                     //Adiciono uma conta para o usuário recém criado
//                     var contaUsuarioViewModel = new ContaUsuarioViewModel();
//                     contaUsuarioViewModel.UserId = applicationUserDB.Id;
//                     contaUsuarioViewModel.Nome = applicationUserDB.Email;
//                     contaUsuarioViewModel.Setor = SetorEnum.NAO_INFORMADO.ToString();
//                     contaUsuarioViewModel.Funcao = FuncaoEnum.NAO_INFORMADO.ToString();
//                     contaUsuarioViewModel.PerfilFoto = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADIAAAAyCAYAAAAeP4ixAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADvMAAA7zARxTmToAAATJSURBVGhD7ZnfT1xFFMe/F9hdFtpSKJQWCy20C4VCFxobLND2RSFC02iijVp/xEcfmxh9U/6Bxrca45vRVI2+mJRqmlb7AyQVU0rWCoXyw26blXZhl2V32Z/XOXcHjWkNvefObqrxs2HvzCx3Zr4z55yZO1d76vjHOv4D5Mnrv57/hayNJq+5IQtCNNht+SgtsUEXn1yh2Nk1rCvU0NZUgSOHGoWYIkx7AwiGYoglElgKx+C7F8bUb4vw+SPi/9U1rURInpjXns5a9Ha50LizEk6HHXkaVZuZcF3XoWkZU6M0fW77FnH20iS+Pj+O5UiKfjF+56JAiI733+pCT0eD6Kw5S9X1NOYXw+g/dR6j4/dlKQ/LPlK/vRTdHbtNiyDonsqy9fjg3V607i6XpTwsC9nfXCXMyFqEKrTZcfyIW9QjCxiwhRQV5uHF7nq80uuWJdbodG/HR+/1CVG8LrHuIuc++U4PTrx2EGUlxbLUGmRme3ZVovfQLlliDpaQxrpNcLu2/hmJVEH1de2rEeHDfL0sIVWbS5SLyKBhR1Wp+DYfSFlCVmIJmVKPzV4gU+ZgCVkIRIyFLRsEgmHW0sgS4g9GZUo9/gCvbpaQQCiKVBYmhGY5M0g58pF4LI3ISlzm1EHxwx9cYcQsppC0aMq/GJI5lYh6A2FxNd8t03fQaNHEL2TBT2hX7F/KoY+0NZRja8V6mVOIGKHu9lrYC3LgI9TEgdYaIWRjpkAhmZW9Fps3rZMljw5LCD3xZQvangRDK0Y7ZmCZ1uTthYyiLOC7v4RQJGk6crGc/depeSRS9HiqGh2jE3dZY8SakeVoCmM374qU2mmhXc/wda/p2SBYQogLw7MypY5ILI6hUa/MmYMt5NsrUxi8NmMcIKggFI7iw9M/GrPNgS0kGk+j/9RFJNNqhAyNzuKrC1MssyLYQggavRu3fDLHhzaLVz0+GEdhTCwJIb7/ac5wUivEkylcuTYnczwsCzk3NI1YMilzPC7/PI2lZWt1WBayEIzh3OC4YR4c0sLHvvjuF5njY1kI8ck3Y0gI8zCPjuGxGXgmrR2XEkqE3JmPIBpjmIaYxMm5oEhwY9VfKBFC4cbhYJx+iP4XOqgLj4mQggINBXT8aBoNTjEAKl4IKRCiw56fjzzmCbSz0CbkWO+GpRqo666aUpx4vZ1tHO0tNXj+6Z3YUGyTJTzyt+092i/TprELk/ry5DE01VWyj1Addhs63DUoLrJhUGwYuQNiaUaSybT4I/vmNp+BTuKjKylLtVgSsmPbRhQ5rZnEKi2uCvHNd3q+EDF8bz7Xavlt1SrNri3Yv2eLkMKrj+Uj7vpyvP1GOw4/WWeYhQrIxzr3VaPIoWHmTkAssOZ2Co/8Vpeia0dbNV7ta8be+iq2c6+NLkQkcObSBD4/6xG7hszp/FqtrSmEFrueA3V4ua8FdU+UKZuBtaBFkoLJD1en8NmABxOzi6KU5Dy8u/8gREOxU8PRww049myz8Qo5VwIeREdK7JBHPF58emYMIzd+f6iWvwnRheDyDQ688EyTWKQaxSLlzKIJmUQ8JtBnfPqeIejiyBwo8q8+VRpCKF1dWYyXxOj3HWwwFqnHRsADCDlpHd75IE4PXMfAZfFgl0jjD8RGmR47ddkVAAAAAElFTkSuQmCCdaKOvFACnpTaXFFABk0lLjNGPegAHWj1pKKAFHUUUdaXH0oAB0NH5UhPJooAdRmkwKCM0ALmk3UYHpQelAC0Uyn0ABptOooAM0ZpMCjFACGil/hFLmgBtFOzRQA09aKdRmgBtONGaM0ANopSMUlABRTgMUUANop1FADKWl4paAG0U6igBvekp9JigBKKd2pAeKAEoPSnVt6B4PvtedWjQxW/eaQcfh3NTKSgrspK5ggcjAre0jwbqeshXjgMUR/5ayfKP/r16RofgfTtHVGMYuZ1582QZwfYV0QQKABgAdulcU8S9omypX+I4XS/hfawbHvJnuG6lF+Vfz611Wn6DYaWoW2tI4vUhefzNaXSjOa5JTlLdmyio7CKoHTigjFOAoFZ2KGjrTiOKKD0pgRscA14f4n1C5vtaujcSGTy5XjQdgoOBgflXuRGRXM+JfBNnrqvIgFvd9pVHX/eFb0JqnLUymnJaHjvrSY5rT1nQLvQrnyrmMgHlXHKt9DWdXqxkpK6OW1tGJ7UU6imIZS5zTqKAGnoKBTqQ9RQAm3ApKf0ozQAylpxoxigBlHan9aTFADaUcmlHpRjFACEcUlPNFADKKeaQdaAEpKfSZzQA2jkU+igBuTRjvTs0UAMop+aKAGUU/NIelACdaOmaUDFLQAzmlxTqTHtQAdRS0UHvQAZpB1ptLz60AOoozSdqAFzR+NMpaAHUUZFGaAD1plPzxTaAEp3ag8Cm0APptOoNADaKKKAHGmUtOzxQAZozTKWgBx6Uyn02gAp1FBNABmimU80AFFNp2eKAA55pUieRlVQWYnAAGSaRQWOByScADvXqHgbwYmnRpfXa7rlhlEYf6sf41lVqKmrlxi5OxR8KfDxdqXWppluqQH/ANm/wr0GOJYIwiKEQDAAGAKkCgUvWvKnOU3dnUoqIylyTTqMD0qCxtLupc0YFAB0pN1OpKADNB6iiloAQ9KYeKkpKAKWo6bb6rbNBcxLJG3YjkH1FeU+KvBU+gyNNCDPZk8N3X617GQMGopoEkjaNlDKwwQRkGtadV03oZyipHz2DS5rsfGngj+yS15ZAtak5eMDlP8A61cbivVhNTV0csk4uwtIO9LRVkiDrS9qKKAEJ4pBTqKAEzSU7rSdKAG0uTTs0UANHWlPSl6Uh6UAFGcU2lFACk8Ugp1IcEE0AJ1oHWkpR1FADqQ9DQelN96AF70pNIOtOoAaOopc5zS0UANHUUp6UtIOtACDrTj0opD0oATcaN3vQKd+FABR+NBpmKAHbaMClpvegBcCjtTaMUAPNBppOaD1oASnYFJRQA7PFNpBSigBWoxSdaOtADqM02igBTQOlJ0ooAd2ptFGT60AJS0lLQA7ik60lOPSgAPSmUuTSUAPoyKTtTaAHnFNJzSfrU1pA91cRQoMs7BR+JoegHZ/Drwyt7cHULhd0UZ/dhu7eteoAY9PpVHSNPj0rToLVBhY1A+prQzxXj1Jc8rnZCPKhvanUynDvWRoLQehptGTQAU7NBNNoAcaN1LSUAN707PvQ3SmUAPzRTR1px6UABPFJkmk6UEkigBk0SyxurAMrDBB6EV5F418KnQrvzoQfscp+XP8J9K9gqjq2mx6tYTW0qgq69+x7GtaU3CRE48yPBs4NBqa+s30+7mt5RhomKnNQZr1001dHHa2jFApc03saKYh2aQ0lAoAVaD0pKKAAdqdmm5zSmgAPIpCtApSaAEHUU6m0ZNADj0pvejNKTxQAHoaQdRSUtADqKbnNFADj0poozQOooAd0opD0pKAHZpv8VJRQA+kPSkyTQKAFbpTcUvvRn2oAdRTcmncYoAKM0jdKbQA/iimU+gAoo70mRQAtB6UUUANopxptABS/wANJnjFOJ4oAbTj3plOzmgBKKXim0AFLQO9JQAuKKKKACnZ4pvSkoAd1FJRRQAlPNNpDQA7OBXQ+BLf7R4mteMhNz9PQYrnRXV/DP8A5GZf+uL/AMxWdTSDZUPiR66lPplOJrxjuEz81Lmm0vegBaMim80lADsilzTaKAHZ96D0plLQA4mjNMpR1oAdQelB6U33oAce1FNHWnHpQAZoJ4NMpW4pMDyb4mWQttcSVVCiaMFh7jj/AArkB1rufitzqNl/1zb+Yrha9ii7wRxTXvDz0ptANGTWxAUZ6UlFAD80HpTKXNAAOtOzTSc0lADjSUlFAC0DrSUoJoAU9KTvQe9FABSUtJQAZpR1pKKAHE8Ug6ijvRmgBx6UylycUUAJSjrSUtADs0UylzQApNHFJRuPrQAcelL2FLmigBp606kalzQAUn40ueab3oAVulNp5pB0oAWg0ZpDz3oASkpaKAEop56Uh6CgBtLinU2gAoooyaAEpaOtGTQAdKKOlFABRRRQAu6g9KT60UAFFB60dDQADrXWfDUf8VKv/XB/5iuTaux+F/8AyMMg/wCmDfzFZ1f4bLh8SPVqWjrRXjHaOJFNpKfmgBtFB607AoAWkPSignigBop2cYpop2aAA9KbSnkUmcigBwpaYOtKSCKAFzQeaaOtOzigBMc9aRqP4qD1pMDzb4rAfaLA452t/SuBPSu++LH+vsfo/wDSuAr16H8NHJP4hKUUUVuZCnp1pKKKACkpR1pT0oAbRS0UAJSjiikoAcTkUlFFAAOtKelIKD3oAO9FFFAB15o7GjsaB1oAB0NFOzQTxQA2gdaD0FJQA/NB6U3vSnpQAlFA60p5xQAgpeKCeKSgBKfRRQAjdKaKfRtHpQAyin0ZoAZTiaWkNACUdaU8UECgBtLSU+gBvWjJpxplAC049KKM0ANop2aKAG0ZNOzQaAGdqWlFLQA2g9aXORS5oAbRTu1MoAWlPSlzQTQA0c12Xwt/5GKX/ri38xXHdjXa/CpVOrXLY5EWAfx/+tWNb+Gy6fxI9UoJptFeQdolFPPSm0AOPSkU8Cl7U2gBxptOoPSgAJ4ptA606gBtJT8Cg9KAGUo60DrT6AEpDyRSnpTR1oAX1oPQUHqKQ9aAPNvix/r7H6N/SuArv/ix/r7H6N/SuAFetQ/ho5J/EAoHelPSkHWtzIM0YpSeKQdaACinZpD0NACUUp6UlABRQOtOPSgBtGc0lO9KAEoNOpMCgBKCOM07NB6UAMpaBSnpQAmPekxSjrSnpQAnSjJpKUdaAAmjoaU9KSgAzRQKXGM0AIKXPtSCl/z0oATpTqM0UAFJnNLQelADetLxTafigAo60nNLQAU09aXn0FL2oATvSZJopKAFope1HUUANpaKUgGgBKdnimZpaACkp/am0AJTz0pvSlB4oASinE8U0cUAOzRmm0lAC0nank8Uw0wDtXc/Cr/kLXX/AFzH864btXdfCn/kK3f/AFzFYVv4bLp/Ej1GjNGeKZXkHaSUmaKaetADqKWigBOgoozS0AJQDQehpo60AOopaQ9KADNFNFO3UAFFFFAAOppp6mnU0nk0mB5v8V/+Piw+j/0rgD0rvviv/r7H6P8A0rgPwr16H8NHJP4gFKSMUhpK3MhR2pT0NIegooAQdafTfwpxPFACE8U2lFKTxQAgPtSk8U0U78KABuRSDg0HpQegoAdSHpTaUdaAAdadRmg0AITxSUdKSgBx6UlHelJ+lACCnZFNooAdxQTxTDS0AKtKelNFOzQA2lz7UHpSUAFKvSlNNPWgBxopKU9KADNGaZS7aAF/GlplO7UALnmg9KbQetABRSUooAcaTtSUUAFFJS0AFL1FNooAWiiigA6UUd6PSgAoop1AAabTu1NoAO5ozR1pSBg0AAArtvhUf+Jrdf8AXIfzrn/CmlR6zrcNrLnyzlmx3xXrWkeGLDRJmltYjG7LtOTnIrkr1FFOD6m0Itu5rr3p2BTKcvWvNOoWlpoPzU6gBKCeKCeKbQAlPzTKWgBxPFNHWgdacelABmg00dacelACE8UDvSCnN0oAMCimjrTj0oAM0080YyaGGKTA82+LH+vsPo39K4CvZPFPhNPEckDSXDQiIEDAzXlOuaU2i6pPaF9+wjB9RXqYeSceXqctRNO5Roo60YrqMQooooAKMUUUAL6Uh60lLQAZxTieKb2NFACUtFGKACgdaOlJ2oAUd6B1oooAcTxTaKTFAC0Y460UUAFFJS0AFFGKMUAFFFFABRiikoAfRSbqXg0AI3SlPSjNFACHpS0UUAFJjilpM0AKelNp1IaAEopx6U2gBfxpcD0pu406gAoo4ozQAHpTKfmjtQA2lHQUlHSgB1FFGaADFFHFFACZwKWm4pe5oAWg0UdqBm54FnMHiezxzuJQ/l/9avahwK8N8KzeT4isXx/y1Ax9eK9yX7tebiviTOmlsxSeKXNNorkNhcilzTKWgBcClzTKBQA+jApP4jSnpQAZoNN9KB0NADsCjikPU0g60AOwBRQelNoAdxSDqaQdacelABmjtTR1pxPFADHArxTxpP5/iW9IH3WC/kK9rc/KK8L8TOJvEF+w6eaf8K7ML8TMauxmDrTsim4xRXonKOoxTR1FOoAKKD0ptADutJgU2loAd2pCMA0g607NADR2pcYpc0h6UALQehpopT0oAQdacelN707NADR1FO7UHGKbQAoFIO9FFACge9Lmm0UAKehpB1oHWnHpQAZoptFAC4FL/nrTaM+1AClqbRS9DQAlLk07tTaAF9aB0pc0d6ADNFGKKAA02nUh5FADaKXHFOoAZS0uBQOlADaX6UU4mgBopKWigBKWinGgApMClzQelADKeabSjrQA2lp2aM0AHSg96M0UAT6dN9n1C2lx9yRW/I175E2Y0PqK+fASDkdQa9z8O6gupaNZzg53RjP1rgxS2Z0UnujSopeh60VwnQOzRmm7aSgB56U2n0lAC0lGfejNABRRRQAUHpSHqKWgBo60o6mloPSgAz70U2nZxQAdaCBSdvxpCeOtAEc7bIXb0BNeBX0wuL2eQHO92b9a9v8AEN+unaPdTn+GM49ya8Kbqccf/qrvwi3Zz1XsNxSjrQKUniu45xT0pDSd6U0AB6U2looAKOlA6ilPIoAbRS9Kd1oAZSjrTj0pooAVulJSnoaQdaACilHelzQA2jvTj0ptABRRQOooAKB1p1IO9AC0ZoPSm0AOzQehpo6049KAGjrQetKtLj2oAZSrS/rS0AJ0pT0oooAZT6KO9ABR1oooAKTuaXvRQA2jrRu4pKAFoxS9qQk0AJR3paKADJop1JxQAlKTxSUlAC04mg02gApe5pc0negBTTaD1pxxQA2ncU2koAXOK734beIktmOmzvtV23RE9M9xXBVJDI0MyOp2spBBFZ1IqcbMuMuV3PoPNOz8xqnplyl5YwTocrIgbP4VbHWvGatodid1ccelMp56U2gY49Kbk07NBoAbRS/gKbQA7sKATmkFOwKAEJoJ6UtIcUAAJzS0mRmlPIoAaO9FLj3oIwKADJpDz7UDrVXVLpbGynnc8Ihb9KEr6AcL8TddVoo9OifLE7pcdh2H5153njNS3FzJczvLKxd2OSx71GvWvYpQ5I2OKTuxKSnHkGkHWtSAoHWlJ4pO9ADs0HpQOB60HpQA3nHWgdaKSgBxORSDrQODTieKAEJwKAabRQA5jxSUDrTqAG5NA7Uo60E8UALmgnim0UAGTRQOtOPSgBtFA6inE8UANo7iigdaAHHpTadQelADR1p3FNpfyoAXNFMp9ABR60UUAJ2paKOtABRRjiigAoowKTvQAlFONB6UANxQetFFAB0op3ak7UAJRk0U40ANo6HrRiigBxptO7U2gBcCkpewpaADsabTqO1ADacelNp1ADaXqaWjpQB678Oro3PhqFScmJin5V1NeffCvUQbe7syQCrCRfof/wBVeg55rx6q5Zs7Y6pDj0pq96dmlrIsZTj0ooPSgBtOKjFMqSgBlA60+koAQnIpKdmgnFADR1pfWgnIpe1ADR1px70mTmgd6AErlviLfiy8PSR4y07CMfz/AJA11BOK8y+KOpGa+t7NWGIh5jAep6fpWtKPNNETdkcPmg4xSHvSV7BxBRj3oooAKKB1pT0oAQdacaZSjrQArdKbTieKSgBKWgU7igBtHXvR60DrQADrSnqKWkboaAFPSm0UoJzQAmTQOtK1JQA480mMUg6049KAEP1ptLRQAUDrQOtAoAcKKb0oHWgBx6U2g9TTgeKAGU+m9DTqAAmmU/A9KKADNBpMCloAM0UmBS0AFFFB6UAIaWm0daAHdaTApO9JQA/8aZS0dzQAuBSk8UyloAU9KO1NpaAHfjRxim0lADwMUZpuTSUAKetKcAUlJQAtFGeKOtABTu1JxSUAbXg/Vf7H1yCVm2xOfLcexr2tGDgEHIPIr56zx6e9er/D/wASjU7IWk7YuoBgZP3l7GuHEQv7yOilLodjTs03cTSVwHQPbpS0zJp9ABRRSbqACig9KaOtADsCjNB6UygB9B6UA8UHGKAGjrTs02kPSgCO6nS2hklkYKiKWJPavCda1E6rqtzdNx5j5GPTt+gFeg/EfxELW1OnQvmWX/Wey+n415l657134aFk5M5qkr+6Lmj8aZS13GA6g03JNFAC5xSnpTDRQAvY0d6SigBwApabRk0AKehpB1oySKKAHHmjApnWloAdQelMpaAAdadwabR0oAUikFGc0etADs0U2jJNADutJwKSigBeDSUUd6AAdadxSHkUlADj0ptGaXj0oATvTs+9N6mnYFABRRRQAUZoyKKACiikNAC0UUUAB6UnalNNoAKdkU2igBxptOptABSZpaKACnE0yloAKXbSU6gBNtLgUHpTaAHUnc0p6UijNABnilPSm07pQA2infjRmgAxU2n302nXaXED7JEOQc9faoc5BpgFAbao9x8Ma3/wkGlR3OzY2drA9Miteub+H9v5Hhi1OMeZl/zNdLXiTSUmkd0W2tQ/A0+mbjS5NSUOpv8AFSk03GaAHE8U2igdRQAoGTQRSnpTc5oAUD3pcCmjrS+tACk1T1K5+x2E8/8AzzQt+Qq1Wd4i/wCQDf8A/XB/5U1uJ6I8Qvb2XUbuS5mYvJIckn9KhPSjoeaCeK9tJJJI4etxD0pB1ooHWmIdQelGaM0ANoHWj1ooAU9KSgUp6UAB7UHpTaKAFoxQBk07pQAm2jbS0ZoATAoIxmgnikHWgAHWlJ4pT0NNHUUAA60vrSk8U2gAHWnZpopTg0ALmmjvQOooPU0AFA60UUAOPSm0pPFJQAUYozzS8epoAWij1pP50ALQaKKAG0496Kb3oAU9KXNJ1FNoAf1oNFIaAG0+jNGaAG0U7ijPFADacabTieKAG0UlLQAlPozQTxQAUZpD0oOKAF4pvc0U7NACdqdSUZoAKO1IelKT1oAZS0UdKAClzg+1Lmm9SKGNHuXhVPL8OWCj/niv8q1/4ap6VD5GnW0f92NR+lXa8OTu2ztWwmBS9qNo9KM0ihtOoJoHSgApB1NLQTigAPSmindaQ9KAFPSm0p7UvWgBorM8TSLH4fv2PTyH/lWoTisfxcP+KZ1H/rg38qqO6E9jw4+1FK3U0g617fQ4AHWg9aUgUg60AJilHWnZpD0NAAcYNJQOtKO9ACZzSU7il4NADaTpT8UdRQA3PNOpAvNLQAHpTMU/NHWgBlKBzTs4xRQA31pMU4dTS5oAbRTj0ptABRRTj2oAbSU89KaOtABRTuDRgUANopxPFNHWgA707NHWk/KgA7cUYFLRQAUUh6UdKAFpO9LRQAUUUdKAA02lbpQ3SgBKKD1ooAKQUtFAAetFFJQAtFHWigA6UCkpaAHGm04ikWgBKKUd6Tv0oAcabTqO1ADaXPJoPSlPSgBtAopx6UAMxzVqwt3ub23jALBpFBwM8ZrY8E6GmvasBKN1vCN7j19BXrsGn21soEcCIBx8qgYrlq11D3VubRi3qTQjESDsAKmNN6YFL/hXl7u50oTJpKKWmMKcelFB6UANHUU7NJ/CKQdRQA49DTR1FOPSk9KAFPSkXvSnpTaAHE1jeLQT4b1AAEkwNgD6VrjrSOquuGGR6U07O4Hz26MjYZSpx0IxTGNexeMPDMOr6XMY4VW5QbkZRycdq8dZSpIIwe/1r16VRVFfscUouL1AUpIApKK1IEoope9ACUuSc048U31oATtTlptKOtACnpTcc089KZigB2QKU9Kb3oHHFAAcelA606g9KAG96cTxTPpSjqKACgHmlbtSUAKTkUlGKKAAdacelNIooAKKKB1oAB1pxPFNPU0UAA5NOPSminHpQA2l2n1pKKAFJxS0ynDpQAtHaijNABiijNFABSZpTSfw0AKOlHak7mhulADaXpRRQAUZNFOPSgAPSm0p7fSm0ALk07NMpaADJopKWgAyaU8CkpcmgBKdTadkUAFGRQelMoAfwRQabTiaAGjrS5JPpSU5FLvtAyWOAPU0bAek/Cu2C6fdz4wzSbc+wA/rXejisbwlo40TRoLcgeYRuc+pNbJHNeNUkpTbR3RVlYdRwRQabWZQ7NFNp1AC0hPFJuptACjrTqbRnIoAcTxTaQUpJoAce1B6U0dacOpoAaOtOPIoPSmUANlXMbD1FeB6lEYNRuozxslYY/Gvfj0ryf4j6KbDVRdoP3VzycdA2Of8a6sNLllZ9TCqro5I9KbRnFAr0zmAdad3pD0pB1FADqRucUp6U2gA6GncU3JNFADs0U33pQTmgBW6GmjrQO9FADs0E8U2gdaAAdafTSR1oJoAdSE8UHpTaADsaB0NFFABQOtA604nigAzRupo604nigAOMUg60lFADieKCabRQA4n8aTcPQUnSjNABtpQeKXI5ptACt0ptPJ96ZQAtOzTW60lADjQelNpcUALwaUnim0UAFFGaD1oAXuaSiigB2Rim0U7NABQelFFADadgUmaXOaAA8U2nUZoAbRTqTPJoAXijAptOPIoAD0ptOHOAOSewra0nwXqmr7WSAwxn/lrJ8o/LqalyUdxpMw8HGa6PwJo/wDaevQs6ZihHmHPQntXYaT8M7K1CyXjNdSD+E/c/KuttLKGxjEcESRKOyjFcdTEKzijeNPqycLjipKZup1cB0AelM707NJQA6lpKWgBKWm7qdQAUUhOKTcKAFopN1LuoAWkoooAKO1FB6UAIRxxXO+ONJGp6DOAu6WIeYmB3FdEDxTXGT604vldyWr6HzyUIOCCCOo9KQrjn9a9s1XwhpurhjPbqshGPMj+Vv0rjdX+F9zAXksJhOuOI5eG/OvShiIS0locrpyWxwxGMUg5Oat3+k3WmyFLqB4SOMkcH8aqDrXSmpbGfkOoI4oozimAgWlxSZzS0AGKKKKAEXqaU8ig9DSelABtNG3mlooAMUEDFFB6UAJj3pPagdadQA2ilPUUuaAE20uKM80tADCCKB1p9JQAHpTR1pxpN1AC9aMUZ4oyKAA0m2lpNwoAbS0UUAFLikPWnUAMop9BoAM0UynmgAzxSdqSnZ60ANpe9JR3oAKKKMe9ACUtJS4oAD1ozzSUuaAClXrSU6gAo4IpM+/Sk5NADieKZ3rQ0vRL3V5AtpbvKP7w4UfjXbaL8L1BWTUZdxxnyo+PzbvWUqsIdS1FvY4C2tJryURQRPK57Kua63SPhpe3jB7xltYwc7cAsRXo9hpFppkXl21ukSj+6vJ+tXQMHiuKeJb+FG6ppbmFo/g7TtHAMUCySj/lpJy38q3QoUYxgfSnAU6uSTb3ZoklsN20u0elLRQUFFFFABSZoPSmUAPzRTad2oAM0U3rTh0oAWkHU0UUALSZFB6U2gB2aWmDrTqACg80UUAGBSY5zSnpTR1oAcRkU0rxTqDQBXubSG7iMc0SyqeoYZzXI6v8NLG9LvasbSUnIA5X8q7bPFNAzVRnKOzJcU9zxbWPBWqaSWYw+fED/rIeePpWEVIOCMEdQe1fQrIpHrWHq/hDTNXy0tuEk/56R/K36da64Yl7SMZUv5TxbOKOPWuz1f4ZXlpueykFyvXaRtYfj3rkLq0nsZDHcQvC/cSDBrsjOMtmZOLW5Hn3ozTce1A61oQOooyDQelABmg9KaKfQAwdadRQTxQAZoPSmjqKcelADR1FOzTaKAHZopCB2oAyc0ALS0maM0AB6U2nHmkxigBQeKODSHpSUAKemKTb7incGjAoAbSgZo7mkoAXvSnpTaccYoAbS5ptFAC07NMooAfnrTaKKACilx70d6AE6UU7NGaAGUUp60UAJQaKKAF6UvGOora0XwjqOtlTDCY4T/y1k4X/ABNegaH8PLDS9sk6/bLgfxP90fQf41zzrRh1NI02zzzR/C2o60w8iAiP/npJwv4etd5ovw1srPbJeN9rlHO08KD9O9djFEsSBUUIo6ADGKftrhnXlLRaHRGCRDb2sVrGEhRY07Kq4FTgc0E8Uuaweu5aVtgPSm07dRQMWiiigBG6UtJmjNABkUtJkUtABSUUZ96AFpKWigApO1B6UDpQAdhRS0UAFJS0UAJRSDp+NKelABmikAyaWgAPSmjrTs0tACUUGjOOKACg9KOlG7NABTT1p1FADcZBqnf6Va6lGY7mBJlP94c/nV49OabQnbYTVzz3WfhdG4aTTptjdopeR+dcRqehX2jyFbu3eMZxuIyp/HpXvGKiuLWK5jZJY1kU/wALAEV0wxEo6PUh001ofP3060meeTXqes/DSzvSXsz9kkJyQfmQ/h2rhNa8L6hokh8+3Yx4/wBbH8yn8e1dsa0JbM5pQcehknpSAnNIOuKcTxW5A31opT0FJQADrSk5FA5NKelADaKB1FOoAaODTieKCabQAYooHWn0AMop9JQAZwKOtGBRQA09aX8KXNGRQAdqbTjTce9ABk0U78aT8aADrS9qM0ZoAMCg/WijNADaKdmkJoASnGm0UAFFKetNPFAC5NJyelSRI00gRFLuxwFUcmu+8M/DhmCXGp4x1EA6/wDAj/hWc5qC1KUXLY5HRfDt9rsmLaElB1kYYUfjXo2gfDyx0vbLcj7XOOct90H2H+NdPbW8drEscUaxovAVRwBVk/drzp15T0Wx0xglqMSNYwAo2gdABgU/cKTrSd65vU1H5oPSm049KYDaduFNp9ABScEUHpTaAHUZobpTaAA9aKfSfxGgBaKKQ0ABplPPIpuKAHGjcKWkz70AFLRRQAhozRwaMCgAoPSg9KbQADrTs02igB2RQehpo6inHpQA0dRTs02gdqAFJzQe1LSN2oAU9KaOtJTm60ALmjNNoHWgBQcmlzRRgUAJmjcKU9KYOtADieKjkjWRSGXKnsRkVNSHpQBx2vfDuw1MGS2H2SbrhPuk/SvPda8LX+hOftEOYu0yHK/ia9wpksKzIVdQ6nqrDINbwryhpuZSppnz7nFAYGvRvFXw7jeN7rTB5co5aHPDfT0+lecyIyMUcFWB5B7V6VOpGoro55Rcdw6UbqbS/jWhAp6UZ4pCOc0D60AJ3zTs0Gk/GgB1Jmk/GkoAfRTfxp1ACHikJyKU9KT8aAAdDRxSUUAJRTyeKaO9ACUUtLg0ANozS7aTFABRS0dzQAUUUUAFOzTaKAHEjHWljjaeRI0BZ24CjqTTB1r0T4beGwUOpzpnnEQb9WrKpNU1cqEeZ2NXwZ4Oj0aJbm6USXjgHBGQnt9a64KAKAuKeeleTKTk7s7FFRVkJgClzTelFSUPpM0dqbQA+kpab3NAC5oplPNABuFLTCc0+gBD0ptOPSmUAP3UZoNMoAfmlplOoAWiikzQAtJgUUE8UALSGgdKO5oAaOtPpCaMigApaKSgAooPAppNADqM0DpQcYoAM0U0dRTj0oAMijNIe1K3SgAopo607NABRRRQAUZoPSmDigB9FGelFABRRQelABmg800dadQAxgOlcL498Hi8ja/s0xOvMiKPvj1+td2etI4DZyMj0NVCTg7omS5lY+eehxz9D2pa6jx74fGkaoZ4lxbT/MuOgbuK5bPNezGanG6OJqzsOopKWqEJmim+tA6igB1LSUUAGaM0tIelAAT70n40g6049KADNG6m0UAHpSHgUUUDHfwikyc0UUCFHekyaKKADJoyaKKAFyaTJoooAXJpM0UUAA6j617zocKQaRZKg2r5S8D6UUVw4rodFLdmgPu0fwiiiuA6BT92kXp+FFFADacB81FFAC0EZoooAG6UtFFACYFFFFABS0UUAN/iNLgUUUAB6U0cUUUAOpCAKKKAFP3aNooooAQfepT0oooAQ9BSDrRRQA+kPSiigBCelA60UUADUhoooAB1pxPSiigBaKKKAGetKBRRQAp4FN6kUUUAK3akzRRQADrTj0oooAQdqXNFFAAelIvSiigBB/WnGiigDl/iDbRz+HZ3cZaMhlPocivHiMA0UV6WG+A5agZ4NJuPFFFdZiG4kGgdaKKAFPWkJNFFABuNLk0UUAGTQCaKKAAUZNFFAH//2Q==";

//                     _contaUsuarioAppService.Add(contaUsuarioViewModel);
//                 }

//                 return NoContent();
//             }

//             return BadRequest(result);
//         }

//         [HttpDelete]
//         [ProducesResponseType(StatusCodes.Status204NoContent)]
//         public async Task<IActionResult> Delete([FromForm]ApplicationUserViewModel model)
//         {
//             // HACK: The code below is just for demonstration purposes!
//             // Please use a different method of preventing the currently logged in user from being removed
            

//             var result = await _context.DeleteAsync<ApplicationUser>(model.UserId);

//             if (result.Succeeded)
//             {
//                 return NoContent();
//             }

//             return BadRequest(result);
//         }

//         [Route("get-all")]
//         [HttpGet]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         public async Task<IActionResult> GetAll()
//         {
//             var users = new List<ApplicationUser>();
//             try
//             {
//                 users = await _manager.Users
//                                     .AsNoTracking()
//                                     .Include(x => x.ContaUsuario)
//                                     .ToListAsync();
                
//             }
//             catch { throw new Exception("Problemas ao obter uma UNIDADE PRISIONAL para o usuário logado. <br><br>Faça login novamente, caso o problema persista, informe a equipe técnica do sistema."); }

//             var usersForSelect2 = new List<Generic2Select2ViewModel>();
//             try
//             {
//                 if (users != null && users.Count() > 0)
//                 {
//                     foreach (var user in users)
//                     {
//                         var temp = new Generic2Select2ViewModel
//                         {
//                             Id = user.Id,
//                             Nome = user.ContaUsuario.Nome
//                         };
//                         usersForSelect2.Add(temp);
//                     }
//                 }
//             }
//             catch { throw; }
//             return CustomResponse(usersForSelect2);
//         }
//     }
// }