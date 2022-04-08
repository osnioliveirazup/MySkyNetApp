using MediatR;

namespace MySkyNetApp.Application.CreateAutor
{
    public class CreateAutorCommand : IRequest<CreateAutorResult>
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Descricao { get; set; }
    }
}
