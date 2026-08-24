using FluentValidation;
using Forge.WebApi.Application.Operations.Auth.Commands;

namespace Forge.WebApi.Application.Operations.Auth.Validators;

public sealed class AuthUserValidator : AbstractValidator<LoginUserCommand>
{
    public AuthUserValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("O email é obrigatório.")
            .EmailAddress()
            .WithMessage("O email não é válido.");

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("A senha é obrigatória.")
            .MinimumLength(3)
            .WithMessage("A senha precisa ter ao menos 3 caracteres.");
    }
}
