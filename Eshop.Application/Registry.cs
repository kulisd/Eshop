using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Application
{
    public static class Registry
    {
        public static void RegistryApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Registry));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Registry).Assembly));
        }
    }
}
