using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MySkyNetApp.Domain.Interfaces.Services;

namespace MySkyNetApp.Application.CreateAutor
{
    public class CreateAutorHandler : IRequestHandler<CreateAutorCommand, CreateAutorResult>
    {
        private readonly IAutorService _autorService;

        private readonly IMapper _mapper;

        public CreateAutorHandler(IAutorService autorService, IMapper mapper)
        {
            _autorService = autorService;
            _mapper = mapper;
        }

        public async Task<CreateAutorResult> Handle(CreateAutorCommand command, CancellationToken cancellationToken)
        {
            var autor = await _autorService.Create(command.Nome, command.Email, command.Descricao);
            return _mapper.Map<CreateAutorResult>(autor);
        }
    }
}
