namespace Forge.WebApi.Application.Services
{
    public interface IAuthService
    {
        public string GenerateJWT(string email, string username, Guid UserId);
        public string GenerateRefreshToken();
    }
}
