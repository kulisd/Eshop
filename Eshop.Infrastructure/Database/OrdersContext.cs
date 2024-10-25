using Ardalis.GuardClauses;
using Eshop.Domain.Customers;
using Eshop.Domain.Orders;
using MongoDB.Driver;

namespace Eshop.Infrastructure.Database;

public sealed class OrdersContext(IMongoDatabase database)
{
    public IMongoDatabase Database { get; } = Guard.Against.Null(database, nameof(database));
    public IMongoCollection<Order> Orders => Database.GetCollection<Order>("Orders");
    public IMongoCollection<Customer> Customers => Database.GetCollection<Customer>("Customers");
}