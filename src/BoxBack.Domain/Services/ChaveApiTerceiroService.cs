using System.IO.MemoryMappedFiles;
using System;
using System.Threading.Tasks;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;
using Sigesp.Domain.InterfacesRepositories;
using BoxBack.Domain.InterfacesRepositories;

namespace BoxBack.Domain.Services
{
    public class ChaveApiTerceiroService : IChaveApiTerceiroService
    {
        private readonly IChaveApiTerceiroRepository _chaveApiTerceiroRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public ChaveApiTerceiroService(IChaveApiTerceiroRepository chaveApiTerceiroRepository,
                                       IUnitOfWork unitOfWork)
        {
            _chaveApiTerceiroRepository = chaveApiTerceiroRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> GetValidKeyByApiTerceiroNome(ApiTerceiroEnum ate)
        {
            var chaveApiTerceiro = new ChaveApiTerceiro();
            try
            {
                chaveApiTerceiro = await _chaveApiTerceiroRepository.GetByApiTerceiroNome(ate);
            }
            catch (InvalidOperationException ex){ throw new InvalidOperationException(ex.Message, ex.InnerException); }

            #region Generals validations
            if (IsChaveApiTerceiroNull(chaveApiTerceiro)) throw new InvalidOperationException("Chave nula. Principal motivo é chave não encontrada.");
            if (IsKeyNullOrEmpty(chaveApiTerceiro.Key)) throw new InvalidOperationException("Chave vazia.");
            if (IsKeyVencida(chaveApiTerceiro.DataValidade)) throw new InvalidOperationException("Chave vencida.");
            #endregion

            return chaveApiTerceiro.Key;
        }

        private bool IsChaveApiTerceiroNull(ChaveApiTerceiro cat)
        {
            return cat == null;
        }
        private bool IsKeyNullOrEmpty(string key)
        {
            return string.IsNullOrEmpty(key);
        }
        private bool IsKeyVencida(DateTimeOffset dt)
        {
            return DateTimeOffset.Now.Date > dt.Date;
        }

        public void Dispose()
        {
            _chaveApiTerceiroRepository.Dispose();
        }
    }
}