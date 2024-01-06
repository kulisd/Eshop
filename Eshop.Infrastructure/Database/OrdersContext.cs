using Eshop.Domain.Orders;
using MongoDB.Driver;

namespace Eshop.Infrastructure.Database
{
    internal class OrdersContext
    {
        private readonly IMongoDatabase _database;        

        public OrdersContext(MongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<Order> Orders => _database.GetCollection<Order>(nameof(Orders));
    }
}
