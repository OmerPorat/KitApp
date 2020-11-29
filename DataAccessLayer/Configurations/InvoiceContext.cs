using DataAccessLayer.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace InvoiceOrchestrator.Configurations
{
    public class InvoiceContext
    {
        private readonly IMongoDatabase _database = null;

        public InvoiceContext(IOptions<MongoConfigurations> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Invoice> Invoices => _database.GetCollection<Invoice>("Invoice");
    }
}