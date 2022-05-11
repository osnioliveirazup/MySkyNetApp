using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySkyNetApp.Domain.Interfaces.Services;
using MySkyNetApp.Domain.Models;
using MySkyNetApp.Infrastructure.Persistence;

namespace MySkyNetApp.Infrastructure.Services
{
    public class AutorService : IAutorService
    {
        private readonly ApplicationDbContext _context;

        public AutorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Autor> Create(string nome, string email, string descricao)
        {
            var autor = new Autor
            {
                Nome = nome,
                Email = email,
                Descricao = descricao
            };
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            return autor;
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            var exists = await _context.Autores
                .AnyAsync(autor => autor.Email == email);
            return !exists;
        }
    }
}
