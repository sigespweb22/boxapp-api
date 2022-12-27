using System;
using System.Threading.Tasks;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;
using Sigesp.Domain.InterfacesRepositories;

namespace BoxBack.Domain.Services
{
    public class ChaveApiTerceiroService : IChaveApiTerceiroService
    {
        private readonly IChaveApiTerceiroRepository _chaveApiTerceiroRepository;
        
        public ChaveApiTerceiroService(IChaveApiTerceiroRepository chaveApiTerceiroRepository)
        {
            _chaveApiTerceiroRepository = chaveApiTerceiroRepository;
        }

        public async Task<string> GetValidKeyByApiTerceiroNome(ApiTerceiroEnum ate)
        {
            var chaveApiTerceiro = new ChaveApiTerceiro();
            try
            {
                chaveApiTerceiro = await _chaveApiTerceiroRepository.GetByApiTerceiroNome(ate);
            }
            catch { throw new ArgumentNullException(nameof(ate)); }

            #region Generals validations
            if (IsChaveApiTerceiroNull(chaveApiTerceiro)) throw new ArgumentNullException(nameof(chaveApiTerceiro));
            if (IsKeyNullOrEmpty(chaveApiTerceiro.Key)) throw new ArgumentNullException(nameof(chaveApiTerceiro.Key));
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
            return string.IsNullOrEmpty(key.ToString());
        }
        private bool IsKeyVencida(DateTimeOffset dt)
        {
            return dt >= DateTimeOffset.Now;
        }
    }
}