namespace Eshop.Infrastructure.Database
{
    internal class MongoDbSettings
    {
        public required string ConnectionString { get; set; }
        public required string DatabaseName { get; set; }
    }
}
