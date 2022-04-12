using System.Threading.Tasks;
using MySkyNetApp.Domain.Models;

namespace MySkyNetApp.Domain.Interfaces.Services
{
    public interface IAutorService
    {
        Task<Autor> Create(string nome, string email, string descricao);
    }
}
