using System.Threading.Tasks;
using MySkyNetApp.Domain.Models;

namespace MySkyNetApp.Domain.Interfaces.Services
{
    public interface IHelloWorldService
    {
        Task<HelloWorldResponse> Create(string userName, int userLevel);
    }
}