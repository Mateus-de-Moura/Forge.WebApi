using FastEndpoints;
using Forge.WebApi.Application.Dto.Auth;
using Forge.WebApi.Application.Operations.Auth.Commands;
using MediatR;

namespace Forge.WebApi.Api.Endpoints.Auth;

public sealed class LoginEndpoint(IMediator mediator)
    : Endpoint<LoginUserCommand, UserAuthResponseDto>
{
    public override void Configure()
    {
        Post("/login");
        AllowAnonymous();
        Tags("Auth");
        Summary(summary =>
        {
            summary.Summary = "Realiza login do usuário";
            summary.Description = "Autentica o usuário e grava o token de acesso em um cookie seguro.";
            summary.Response<UserAuthResponseDto>(StatusCodes.Status200OK);
            summary.Response(StatusCodes.Status400BadRequest, "Credenciais ou dados inválidos.");
        });
    }

    public override async Task HandleAsync(
        LoginUserCommand command,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        if (!result.IsSuccess)
        {
            foreach (var error in result.Errors)
                AddError(error);

            await Send.ErrorsAsync(StatusCodes.Status400BadRequest, cancellationToken);
            return;
        }

        HttpContext.Response.Cookies.Append(
            "AuthToken",
            result.Value.TokenJwt!,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddHours(1),
                Path = "/"
            });

        result.Value.TokenJwt = string.Empty;
        await Send.OkAsync(result.Value, cancellationToken);
    }
}
