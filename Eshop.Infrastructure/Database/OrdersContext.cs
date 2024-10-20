using Ardalis.GuardClauses;
using Eshop.Domain.Orders;
using MongoDB.Driver;

namespace Eshop.Infrastructure.Database;

public sealed class OrdersContext(IMongoDatabase database)
{
    private readonly IMongoDatabase _database = Guard.Against.Null(database, nameof(database));

    public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
}