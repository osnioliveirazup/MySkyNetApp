using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySkyNetApp.Application.Interfaces.Metrics;
using MySkyNetApp.Domain.Interfaces.Services;
using MySkyNetApp.Infrastructure.Metrics;
using MySkyNetApp.Infrastructure.Persistence;
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
            services.AddScoped<ICounterAutoresCreated, CounterAutoresCreated>();
            services.AddDbContext<ApplicationDbContext>();
            return services;
        }
    }
}
