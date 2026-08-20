using Forge.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forge.WebApi.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            //senha "teste"

            builder.HasKey(x => x.Id);

            var seed = new User[]
            {
                new User
                {
                    Id = new Guid("c3d2251f-1e0b-42b6-8868-75d03046460c"),
                    Active = true,
                    Name = "Admin",
                    Surname = "Admin",
                    UserName = "Admin",
                    Email = "admin@admin.com",
                    PasswordSalt = "$2a$11$kgueTQbW2exSJwFqWxQ.h.",
                    PasswordHash = "$2a$11$kgueTQbW2exSJwFqWxQ.h.cFK5l5WArN8DdGWCLS1UZ849lop2C2m",
                    RefreshToken = "vMVEc5sypGQDpoqFWtmXOuVfPwjzEo9EuorBukiH/WbE2EYvAeGJxaCBGnwgRv7sSV2/6dfX220TjC4quGC/MexPfZiL/U6YPferYZRGcPz30fFg4jzO4Y1wTbXSvV2ta5j8nlAhdvGDT0dTW42RgTmrzmKun4B0nPCV3AIpupQ=",
                    RefreshTokenExpirationTime = new DateTime(DateTime.Now.Year + 2, 12, 05),                   
                }
            };

            builder.HasData(seed);
        }
    }
}
