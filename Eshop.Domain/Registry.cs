using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Domain;

public static class Registry
{
    public static void RegistryDomain(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Registry).Assembly));
    }
}