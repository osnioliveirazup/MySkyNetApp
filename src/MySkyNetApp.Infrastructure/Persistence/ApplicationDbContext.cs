using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySkyNetApp.Domain.Models;
using MySkyNetApp.Infrastructure.Persistence.Configurations;
using StackSpot.Secrets.Common;

namespace MySkyNetApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ISecretsManagerCache _secretsManagerCache;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ISecretsManagerCache secretsManagerCache)
            : base(options)
        {
            _secretsManagerCache = secretsManagerCache;
        }

        public DbSet<Autor> Autores => Set<Autor>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Task.Run(async () =>
                await _secretsManagerCache.GetSecretString("connectionString")
            ).Result;
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Autor>(new AutorConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
