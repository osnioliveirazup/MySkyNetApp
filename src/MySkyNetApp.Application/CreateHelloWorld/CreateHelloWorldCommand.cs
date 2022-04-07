using MediatR;
using MySkyNetApp.Domain.Enums;

namespace MySkyNetApp.Application.CreateHelloWorld
{
    public class CreateHelloWorldCommand : IRequest<CreateHelloWorldResult>
    {
        public string UserName { get; set; }
        public UserLevel Level { get; set; }
    }
}