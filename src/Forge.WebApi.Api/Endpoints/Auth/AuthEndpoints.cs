using AutoMapper;
using Forge.WebApi.Application.Operations.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Forge.WebApi.Api.Endpoints.Auth
{
    public static class AuthEndpoints
    {
        public static void AuthEndpoint(this WebApplication app)
        {
            app.MapPost("login", async ([FromBody] LoginUserCommand command,[FromServices] IMediator mediator, [FromServices] IMapper mapper, HttpContext httpContext) =>
            {
                var result = await mediator.Send(command);

                if (result.IsSuccess)
                {
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.None,
                        Expires = DateTime.UtcNow.AddHours(1),
                        Path = "/"
                    };

                    httpContext.Response.Cookies.Append(
                       "AuthToken",
                       result.Value.TokenJwt!,
                       cookieOptions
                   );

                    result.Value.TokenJwt = string.Empty;

                    return Results.Ok(result.Value);

                }

               return Results.BadRequest(command);
            })
             .WithName("Login")
             .WithTags("Auth")
             .WithSummary("Realiza login do usuário")
             .WithDescription("Endpoint responsável por autenticar o usuário e retornar o token de acesso")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status400BadRequest); ;
        }
    }
}
