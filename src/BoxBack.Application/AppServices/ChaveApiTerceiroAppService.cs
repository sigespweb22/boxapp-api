using System.Text;
using System;
using System.Threading.Tasks;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels;
using BoxBack.Domain.Enums;
using BoxBack.Domain.Interfaces;
using BoxBack.Domain.Models;

namespace BoxBack.Application.AppServices
{
    public class ChaveApiTerceiroAppService : IChaveApiTerceiroAppService
    {
        private readonly IChaveApiTerceiroService _chaveApiTerceiroService;

        public ChaveApiTerceiroAppService(IChaveApiTerceiroService chaveApiTerceiroService)
        {
            _chaveApiTerceiroService = chaveApiTerceiroService;
        }

        public async Task<string> GetValidKeyByApiTerceiroNome(ApiTerceiroEnum ate)
        {
            try
            {
                return await _chaveApiTerceiroService.GetValidKeyByApiTerceiroNome(ate);
            }
            catch { throw; }
        }
    }
} 