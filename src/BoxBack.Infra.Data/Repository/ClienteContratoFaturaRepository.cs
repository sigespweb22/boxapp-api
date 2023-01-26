using BoxBack.Infra.Data.Repository;
using BoxBack.Domain.Models;
using BoxBack.Infra.Data.Context;
using Sigesp.Domain.InterfacesRepositories;
using System.Threading.Tasks;
using BoxBack.Domain.ModelsServices;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Sigesp.Infra.Data.Repository
{
    public class ClienteContratoFaturaRepository : Repository<ClienteContratoFatura>, IClienteContratoFaturaRepository
    {
        public ClienteContratoFaturaRepository(BoxAppDbContext context)
            : base(context)
        {
        }

        public bool AlreadyByParams(AlreadyModelParam args)
        {
            return DbSet.Any(x => x.ClienteContratoId.Equals(args.ClienteContratoId) &&
                                                             x.DataCompetencia.Equals(args.DataCompetencia) &&
                                                             x.Valor.Equals(args.Valor) &&
                                                             x.NumeroParcela.Equals(args.NumeroParcela));
        }

        public async Task<ClienteContratoFatura[]> GetAllQuitadasByCompetenciaAsync(DateTime dataInicio, DateTime dataFim)
        {
            return await DbSet
                        .Include(x => x.ClienteContrato)
                        .ThenInclude(x => x.VendedoresContratos)
                        .Where(x => x.DataCompetencia.Date >= dataInicio &&
                                    x.DataCompetencia.Date <= dataFim &&
                                    x.Quitado == true &&
                                    x.ClienteContrato.VendedoresContratos.Any())
                                    .ToArrayAsync();
        }
    }
}