using Microsoft.EntityFrameworkCore;
using MySkyNetApp.Domain.Models;

namespace MySkyNetApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Autor> Autores => Set<Autor>();
    }
}
