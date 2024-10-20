namespace Eshop.Infrastructure.Database;

internal class MongoDbSettings
{
    public required string ConnectionString { get; init; }
    public required string DatabaseName { get; init; }
}