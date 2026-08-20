using Bogus;
using Forge.WebApi.Application.Operations.Auth.Commands;

namespace Forge.WebApi.Tests.Requests
{
    public static class RequestAuthBuilder
    {
        public static LoginUserCommand Build()
        {
            return new Faker<LoginUserCommand>()
                .RuleFor(x => x.Email, (f) => f.Internet.Email())
                .RuleFor(x => x.Password, (f) => f.Internet.Password());

        }
    }
}
