using _1_Fintranet.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace _4_.Fintranet.Persistence.Contexts
{
    public class FintranetContextFactory: IDesignTimeDbContextFactory<FintranetContext>
    {
        public FintranetContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(basePath: basePath)
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString =
                configBuilder.GetConnectionString(DefaultConstants.DefaultConnectionString);
            var builder = new DbContextOptionsBuilder<FintranetContext>();
            builder.UseSqlServer(connectionString);
            return new FintranetContext(builder.Options);
        }
    }
}