using System.Threading.Tasks;
using BoxBack.Domain.Interfaces;
using Sigesp.Domain.InterfacesRepositories;

namespace BoxBack.Application.AppServices
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        
        public ClienteService(IClienteRepository clienteRepository)
        {
            clienteRepository = _clienteRepository;
        }
    
        public async Task SincronizarFromTPAsync()
        {
            // #region Chave api resolve
            // var chaveApiTerceiro = new ChaveApiTerceiro();
            // try
            // {
            //     chaveApiTerceiro = await _context
            //                                     .ChavesApiTerceiro
            //                                     .Where(x => x.DataValidade >= DateTimeOffset.Now &&
            //                                            x.IsDeleted == false && !string.IsNullOrEmpty(x.Key))
            //                                     .FirstOrDefaultAsync(x => x.ApiTerceiro.Equals(ApiTerceiroEnum.BOM_CONTROLE));
            // }
            // catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            // if (chaveApiTerceiro == null)
            // { 
            //     AddError("Nenhuma chave de api de terceiro encontrada, verifique os possíveis erros: \n\nNenhuma chave de api cadastrada para esta integração. \n\nA chave de api cadastrada não possui uma Key. \n\nA chave de api cadastrada não está ativa. \n\nA chave de api cadastrada está com Data de Validade vencida.");
            //     return CustomResponse(404);
            // }
            // #endregion

            // #region Token resolve
            // String token = string.Empty;
            // try
            // {
            //     token = $"ApiKey {chaveApiTerceiro.Key}";
            // }
            // catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            // #endregion

            // #region Get data Bom Controle (TP)
            // IEnumerable<BCClienteModelService> clientesThirdParty = new List<BCClienteModelService>();
            // try
            // {
            //     clientesThirdParty = await _bcServices.ClientePesquisar(token);
            // }
            // catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }

            // if (clientesThirdParty == null || clientesThirdParty.Count() <= 0)
            // {
            //     AddError("Nenhum registro encontrado na api de terceiro");
            //     return CustomResponse(404);
            // }
            // #endregion

            // #region Get data BoxApp
            // IEnumerable<Cliente> clientesBoxApp = new List<Cliente>();
            // try
            // {
            //     clientesBoxApp = await _context
            //                                 .Clientes
            //                                 .ToListAsync();
            // }
            // catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            // #endregion

            // #region Sincronization
            // Int64 totalSincronizado = 0;
            // Int64 totalIsNotDocumento = 0;
            // foreach (var clienteTP in clientesThirdParty)
            // {
            //     bool clienteThirdPartyAlreadyInBoxApp = false;
            //     if (clienteTP.PessoaFisica == null)
            //     {
            //         if (clienteTP.PessoaJuridica.Documento == null) totalIsNotDocumento++;

            //         clienteThirdPartyAlreadyInBoxApp = clientesBoxApp.Any(x => x.CNPJ == clienteTP.PessoaJuridica.Documento);
            //     } else {
            //         if (clienteTP.PessoaFisica.Documento == null) totalIsNotDocumento++;

            //         clienteThirdPartyAlreadyInBoxApp = clientesBoxApp.Any(x => x.Cpf == clienteTP.PessoaFisica.Documento);
            //     }

            //     // Cliente não existe no BoxApp e está ativo no bom controle, portanto, deve ser cadastrado no BoxApp
            //     if (!clienteThirdPartyAlreadyInBoxApp && clienteTP.Bloqueado == false)
            //     {
                    

            //         var cliente = new Cliente();
            //         try
            //         {
            //             if (clienteTP.TipoPessoa == "Juridica")
            //             {
            //                 if (!string.IsNullOrEmpty(clienteTP.PessoaJuridica.Documento))
            //                 {
            //                     cliente = _mapper.Map<Cliente>(clienteTP);    
            //                 }
            //             } else {
            //                 if (!string.IsNullOrEmpty(clienteTP.PessoaFisica.Documento))
            //                 {
            //                     cliente = _mapper.Map<Cliente>(clienteTP);    
            //                 }
            //             }
            //         }
            //         catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
                    
            //         try
            //         {
            //             if (cliente.Id != Guid.Empty)
            //             {
            //                 await _context.Clientes.AddAsync(cliente);
            //                 totalSincronizado++;
            //             }
            //         }
            //         catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            //     }
            // }
            // #endregion

            // #region Commit
            // try
            // {
            //     _unitOfWork.Commit();
            // }
            // catch (Exception ex) { AddErrorToTryCatch(ex); return CustomResponse(500); }
            // #endregion
            await Task.Run(() => "1");
        }
    }
}