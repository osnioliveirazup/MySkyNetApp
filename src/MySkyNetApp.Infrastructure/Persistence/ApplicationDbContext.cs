using Microsoft.EntityFrameworkCore;
using MySkyNetApp.Domain.Models;
using MySkyNetApp.Infrastructure.Persistence.Configurations;

namespace MySkyNetApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Autor> Autores => Set<Autor>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=..\\MySkyNetApp.Infrastructure\\Persistence\\Editora.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Autor>(new AutorConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
