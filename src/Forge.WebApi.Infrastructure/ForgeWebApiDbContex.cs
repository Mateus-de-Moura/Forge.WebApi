using Forge.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forge.WebApi.Infrastructure
{
    public class ForgeWebApiDbContex(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
