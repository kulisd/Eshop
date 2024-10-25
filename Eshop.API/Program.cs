using Eshop.API.Examples;
using Eshop.API.Middlewares;
using Eshop.Application;
using Eshop.Infrastructure;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Eshop.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.RegistryInfrastructure(builder.Configuration);
        builder.Services.RegistryApplication();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        builder.Services.AddSwaggerExamplesFromAssemblyOf<CustomerOrderRequestExample>();
        builder.Services.AddSwaggerExamplesFromAssemblyOf<ErrorDtoExample>();
        
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            c.ExampleFilters();
        });

        var app = builder.Build();

        if (builder.Environment.IsDevelopment())
        {
            // app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eshop API v1"));
        }

        app.MapControllers();
            
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.Run();
    }
}