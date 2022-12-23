using MongoDB.Driver;
using BoxBack.Domain.Models;
using BoxBack.Domain.ModelsNoSQL;
using Microsoft.Extensions.Options;

namespace BoxBack.Infra.Data.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<ClienteNoSQL> Clientes
        {
            get
            {
                return _database.GetCollection<ClienteNoSQL>("clientes");
            }
        }
    }
}