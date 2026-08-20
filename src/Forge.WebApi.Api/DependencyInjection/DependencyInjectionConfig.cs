using Forge.WebApi.Application.Operations.Auth.Commands;
using Forge.WebApi.Application.Services;
using Forge.WebApi.Domain.Interfaces.User;
using Forge.WebApi.Infrastructure;
using Forge.WebApi.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forge.WebApi.Api.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static void ConfigureDI(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(LoginUserCommand).Assembly);
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            builder.Services.AddDbContext<ForgeWebApiDbContex>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
        }
    }
}
