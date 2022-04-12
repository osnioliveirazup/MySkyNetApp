using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySkyNetApp.Domain.Interfaces.Services;
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=..\\MySkyNetApp.Infrastructure\\Persistence\\Editora.db")
            );
            return services;
        }
    }
}