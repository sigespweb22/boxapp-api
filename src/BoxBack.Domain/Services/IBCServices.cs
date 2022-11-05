using System.Threading.Tasks;
using Refit;
using BoxBack.Domain.ModelsServices;

namespace BoxBack.Domain.Services
{
    public interface IBCServices
    {
        /// <summary>
        /// Cadastra um cliente
        /// </summary>
        /// <param name="clienteModel"></param>
        /// <returns>Um json com os dados do cliente consultado</returns>
        /// <response code="201">Cliente cadastrado com sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="500">Erro interno desconhecido</response>
        [Post("/Cliente/Criar")]
        [Headers("ApiKey Z0EjZPzTOb-NVurlZvdf-jqb2g6FUvIlKBmvUVCh7sE03jMPBaCQ9bIps9El6__SynsbTrCaUm1yI2geYNx3JSPNELf-pDy5HaUUcTkvYNw8nwlkDozDnA==")]
        Task<BCClienteModelService> ClienteCriar(BCClienteModelService clienteModel);
    }
}