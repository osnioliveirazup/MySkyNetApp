using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MySkyNetApp.Application.CreateAutor
{
    public class CreateAutorHandler : IRequestHandler<CreateAutorCommand, CreateAutorResult>
    {
        public async Task<CreateAutorResult> Handle(CreateAutorCommand command, CancellationToken cancellationToken)
        {
            await Task.Delay(2000);
            var result = new CreateAutorResult
            {
                Id = 1,
                Nome = command.Nome,
                Email = command.Email,
                Descricao = command.Descricao
            };
            return result;
        }
    }
}
