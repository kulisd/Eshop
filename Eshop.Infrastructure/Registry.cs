using Eshop.Application.Orders;
using Eshop.Domain.Orders;
using Eshop.Domain.SeedWork;
using Eshop.Infrastructure.Database;
using Eshop.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Eshop.Infrastructure;

public static class Registry
{
    public static void RegistryInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductPriceDataApi, ProductPriceDataApi>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();
        services.AddScoped<IEntityTracker, EntityTracker>();

        var mongoDbSettings = configuration.GetSection("MongoDB").Get<MongoDbSettings>() ?? throw new InvalidOperationException("MongoDB settings are not configured properly.");
            
        if (string.IsNullOrEmpty(mongoDbSettings.ConnectionString))
            throw new InvalidOperationException("MongoDB connection string is not configured.");
            
        services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoDbSettings.ConnectionString));

        services.AddSingleton(provider =>
        {
            var client = provider.GetRequiredService<IMongoClient>();
            if (string.IsNullOrEmpty(mongoDbSettings.DatabaseName))
                throw new InvalidOperationException("MongoDB database name is not configured.");
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);
            return new OrdersContext(database);
        });
    }
}