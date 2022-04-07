using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using StackSpot.ErrorHandler;
using MySkyNetApp.Application;
using MySkyNetApp.Application.Common.StackSpot;
using MySkyNetApp.Infrastructure;

namespace MySkyNetApp.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public IWebHostEnvironment _env { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(_configuration);
            services.AddStackSpot(_configuration, _env);

            services.AddHttpContextAccessor();

            services.AddHealthChecks();
            services.AddControllers()
                    .AddFluentValidation(x => x.AutomaticValidationEnabled = false)
                    .AddJsonOptions(x =>
                    {
                        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MySkyNetApp.Api", Version = "v1" });

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MySkyNetApp.Api v1"));

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();

            app.UseErrorHandler();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStackSpot(_configuration, env);
        }
    }
}