using FluentValidation;
using Forge.WebApi.Application.Operations.Auth.Commands;

namespace Forge.WebApi.Application.Operations.Auth.Validators
{
    public class AuthUserValidator : AbstractValidator<LoginUserCommand>
    {
        public AuthUserValidator()
        {
            RuleFor(user => user.Email)
            .EmailAddress()
            .WithMessage("O email não é um email válido.");

            RuleFor(user => user.Password.Length)
           .GreaterThanOrEqualTo(3)
           .WithMessage("A senha precisa ter mais de 3 caracteres.");
        }
    }
}
