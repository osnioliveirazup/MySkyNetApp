using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Logging;
using MySkyNetApp.Domain.Interfaces.Services;

namespace MySkyNetApp.Application.CreateAutor
{
    public class CreateAutorValidator : AbstractValidator<CreateAutorCommand>
    {
        private readonly IAutorService _autorService;

        private readonly ILogger<CreateAutorValidator> _logger;

        public CreateAutorValidator(IAutorService autorService, ILogger<CreateAutorValidator> logger)
        {
            _autorService = autorService;
            _logger = logger;

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
            var isEmailUnique = await _autorService.IsEmailUnique(email);
            _logger.LogInformation(
                isEmailUnique ? "Email ainda não cadastrado" : "Email já cadastrado",
                new { Email = email },
                $"Método: {nameof(EmailUnique)}",
                "Usuário: nome_usuario",
                "Motivo: Porque eu quis"
            );
            return isEmailUnique;
        }
    }
}
