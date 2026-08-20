using FluentAssertions;
using Forge.WebApi.Application.Operations.Auth.Validators;
using Forge.WebApi.Tests.Requests;

namespace Forge.WebApi.Tests.Auth
{
    public class AuthValidatorTest
    {

        [Fact]
        public void Authenticating_The_User_Should_Return_Success()
        {
            var request = RequestAuthBuilder.Build();

            var result = new AuthUserValidator().Validate(request);

            result.IsValid.Should().BeTrue();
        }
    }
}
