using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySkyNetApp.Domain.Interfaces.Services;
using MySkyNetApp.Infrastructure.Services;

namespace MySkyNetApp.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHelloWorldService, HelloWorldService>();
            services.AddScoped<IAutorService, AutorService>();
            return services;
        }
    }
}