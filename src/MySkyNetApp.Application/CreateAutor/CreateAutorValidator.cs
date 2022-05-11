using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MySkyNetApp.Domain.Interfaces.Services;

namespace MySkyNetApp.Application.CreateAutor
{
    public class CreateAutorValidator : AbstractValidator<CreateAutorCommand>
    {
        private readonly IAutorService _autorService;

        public CreateAutorValidator(IAutorService autorService)
        {
            _autorService = autorService;

            RuleFor(command => command.Nome)
                .NotNull()
                .NotEmpty();

            RuleFor(command => command.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MustAsync(EmailUnique)
                    .WithMessage("Já existe autor cadastrado com {PropertyName}: {PropertyValue}.");

            RuleFor(command => command.Descricao)
                .NotNull()
                .NotEmpty()
                .MaximumLength(400);
        }

        private async Task<bool> EmailUnique(string email, CancellationToken token)
        {
            return await _autorService.IsEmailUnique(email);
        }
    }
}
