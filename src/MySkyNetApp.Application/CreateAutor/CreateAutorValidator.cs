using FluentValidation;

namespace MySkyNetApp.Application.CreateAutor
{
    public class CreateAutorValidator : AbstractValidator<CreateAutorCommand>
    {
        public CreateAutorValidator()
        {
            RuleFor(command => command.Nome)
                .NotNull()
                .NotEmpty();

            RuleFor(command => command.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(command => command.Descricao)
                .NotNull()
                .NotEmpty()
                .MaximumLength(400);
        }
    }
}
