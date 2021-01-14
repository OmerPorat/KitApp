using DataAccessLayer.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace InvoiceOrchestrator.Configurations
{
    public class KitContext
    {
        private readonly IMongoDatabase _database = null;
        public IMongoCollection<Kit> Kits => _database.GetCollection<Kit>("Kits");
        
        public KitContext(IOptions<MongoConfigurations> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

    }
}