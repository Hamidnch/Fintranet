using _1_Fintranet.Common.Constants;
using _1_Fintranet.Common.Enums;
using _2_Fintranet.Domain.Commons;
using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Interfaces;
using _4_.Fintranet.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fintranet.Test.Validation
{
    public class RepositoryDoctorServiceTest
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

        private static IFintranetRepository<T> GetFintranetRepository<T>() where T : BaseEntity
        {
            var context = CreateDbContext();
            IFintranetRepository<T> fintranetRepository = new FintranetRepository<T>(context);
            return fintranetRepository;
        }

        [Fact]
        public async Task Count_Of_Doctors_Test()
        {
            var repository = GetFintranetRepository<Doctor>();
            var allDoctors = await repository.GetAllAsync(false);
            Assert.Equal(2, allDoctors.Count);
        }

        [Fact]
        public async Task Create_Doctor_Success_Test()
        {
            var repository = GetFintranetRepository<Doctor>();

            var doctor = new Doctor(
                "Hamid", "Nezamivand Chegini", GenderType.Male, 1, "4323511086",
                "hamidnch2007@gmail.com", "678678",
                "09124820700", null, null,
                TurningMethod.ByPhone, 15, null);

            await repository.InsertAsync(doctor);
        }

        [Fact]
        public async Task Create_Doctor_Success_Test2()
        {
            var repository = GetFintranetRepository<Doctor>();

            var doctor = new Doctor("Ali", "Mostafa", GenderType.Male,
                1, "43235116025", "AliMostafa@gmail.com",
                "98922", "09195263526",
                null, null, TurningMethod.ByInternet,
                8, null);

            await repository.InsertAsync(doctor);

            var searchDoctor = repository.Find(d => d.Email == "AliMostafa@gmail.com").FirstOrDefault();
            Assert.Equal(doctor.FirstName, searchDoctor?.FirstName);
        }
    }
}
