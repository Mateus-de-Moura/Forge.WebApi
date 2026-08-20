using Forge.WebApi.Api.Endpoints.Auth;

namespace Forge.WebApi.Api.DependencyInjection
{
    public static class ConfigureEndpoints
    {
        public static void AddEndpoints(this WebApplication app)
        {
            AuthEndpoints.AuthEndpoint(app);
        }
    }
}
