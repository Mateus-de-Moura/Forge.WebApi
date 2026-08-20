using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Forge.WebApi.Infrastructure
{
    /// <summary>
    /// Classe utilizada apenas para Migrations
    /// </summary>
    public class ForgeWebApiDbContextFactory : IDesignTimeDbContextFactory<ForgeWebApiDbContex>
    {
        public ForgeWebApiDbContex CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) 
            .AddJsonFile("appsettings.json") 
            .Build();
            
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            var optionsBuilder = new DbContextOptionsBuilder<ForgeWebApiDbContex>();
            optionsBuilder.UseSqlServer(connectionString);
           
            return new ForgeWebApiDbContex(optionsBuilder.Options);
        }
    }
}
