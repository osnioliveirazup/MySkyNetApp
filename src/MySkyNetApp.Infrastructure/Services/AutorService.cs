using System.Threading.Tasks;
using MySkyNetApp.Domain.Interfaces.Services;
using MySkyNetApp.Domain.Models;

namespace MySkyNetApp.Infrastructure.Services
{
    public class AutorService : IAutorService
    {
        public async Task<Autor> Create(string nome, string email, string descricao)
        {
            await Task.Delay(2000);
            var autor = new Autor
            {
                Id = 1,
                Nome = nome,
                Email = email,
                Descricao = descricao
            };
            return autor;
        }
    }
}
