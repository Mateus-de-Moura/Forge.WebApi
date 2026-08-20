
using Ardalis.Result;
using Forge.WebApi.Application.Dto.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Forge.WebApi.Application.Operations.Auth.Commands
{
    public class LoginUserCommand : IRequest<Result<UserAuthResponseDto>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
