using _1_Fintranet.Common.Constants;
using _1_Fintranet.Common.Enums;
using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Interfaces;
using _4_.Fintranet.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fintranet.Test.Validation
{
    public class RepositoryServiceTest
    {
        private static FintranetContext CreateDbContext()
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

        [Fact]
        public async Task Create_Doctor_Success_Test()
        {
            var context = CreateDbContext();
            IFintranetRepository<Doctor> fintranetRepository = new FintranetRepository<Doctor>(context);

            var doctor = new Doctor(
                "Hamid", "Nezamivand Chegini", GenderType.Male, 1, "4323511086",
                "hamidnch2007@gmail.com", "678678",
                "09124820700", null, null,
                TurningMethod.ByPhone, 15, null);

            await fintranetRepository.InsertAsync(doctor);
        }

        [Fact]
        public async Task Create_Doctor_Success_Test2()
        {
            var context = CreateDbContext();
            IFintranetRepository<Doctor> fintranetRepository = new FintranetRepository<Doctor>(context);
            
            var doctor = new Doctor(
                "Ali", "Mostafa", GenderType.Male, 1, "43235116025",
                "AliMostafa@gmail.com", "98922",
                "09195263526", null, null,
                TurningMethod.ByInternet, 8, null);

            await fintranetRepository.InsertAsync(doctor);
        }
    }
}
