using _2_Fintranet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using _3_Fintranet.Application.Interfaces;

namespace _4_.Fintranet.Persistence.Contexts
{
    public class FintranetContext : DbContext, IFintranetContext
    {
        public FintranetContext(DbContextOptions<FintranetContext> options) : base(options)
        {

        }

        #region DbSets

        public DbSet<Doctor>? Doctors { get; set; }
        public DbSet<Patient>? Patients { get; set; }
        public DbSet<DoctorDoctorOfficeMapping>? DoctorDoctorOfficeMappings { get; set; }

        #endregion DbSets

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("nch");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> ExecuteSqlRawAsync(string query, CancellationToken cancellationToken)
        {
            var result = await base.Database.ExecuteSqlRawAsync(query, cancellationToken);
            return result;
        }

        public async Task<int> ExecuteSqlRawAsync(string query) => await ExecuteSqlRawAsync(query, CancellationToken.None);
    }
}
