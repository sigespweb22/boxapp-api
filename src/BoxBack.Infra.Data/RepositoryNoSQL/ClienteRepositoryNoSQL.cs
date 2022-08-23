using System.Threading;
using System;
using System.Net.Mime;
using System.Xml;
using System.Security.AccessControl;
using Microsoft.VisualBasic.CompilerServices;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoxBack.Domain.InterfacesNoSQL;
using BoxBack.Domain.Models;
using BoxBack.Domain.ModelsNoSQL;
using BoxBack.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;

namespace BoxBack.Infra.Data.RepositoryNoSQL
{
    public class ClienteRepositoryNoSQL : IClienteRepositoryNoSQL
    {
        private readonly MongoDbContext _contextNoSQL = null;

         public ClienteRepositoryNoSQL(IOptions<MongoDbSettings> settings)
        {
            _contextNoSQL = new MongoDbContext(settings);
        }

        public async Task<IEnumerable<ClienteNoSQL>> GetAll()
        {
            IEnumerable<ClienteNoSQL> result = new List<ClienteNoSQL>();
            try
            {
                result = await _contextNoSQL.Clientes
                                                .Find(_ => true).ToListAsync();
            }
            catch { throw; }
            return result;
        }
        public async Task AddAsync(ClienteNoSQL item)
        {
            try
            {
                await _contextNoSQL.Clientes.InsertOneAsync(item);
            }
            catch { throw; }
        }
        public async Task<bool> RemoveAsync(string id)
        {
            try
            {
                DeleteResult actionResult 
                = await _contextNoSQL.Clientes.DeleteOneAsync(
                    Builders<ClienteNoSQL>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged 
                                && actionResult.DeletedCount > 0;
            }
            catch { throw; }
        }
    }
}