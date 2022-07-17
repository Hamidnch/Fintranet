using _1_Fintranet.Common.Constants;
using _2_Fintranet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4_.Fintranet.Persistence.MappingConfigs
{
    public class DoctorConfig : BaseEntityTypeConfiguration<Doctor>
    {
        public override void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable(name: DefaultConstants.DoctorTableName);

            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();

            //builder.HasIndex(x => x.Email).HasDatabaseName("IX_Doctor_Email").IsUnique();
            //builder.HasIndex(x => x.MedicalSystemNumber).HasDatabaseName("IX_Doctor_MedicalSystemNumber").IsUnique();

            builder.HasIndex(x => new { x.Email, x.MedicalSystemNumber })
                .HasDatabaseName("IX_Doctor_Email_MedicalSystemNumber").IsUnique();

            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(200).IsRequired();
            builder.Property(p => p.FullName).HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
            builder.Property(x => x.MedicalSystemNumber).HasMaxLength(100).IsRequired();
            builder.Property(x => x.BusinessMobileNumber).HasMaxLength(11).IsRequired(false);
            builder.Property(x => x.PersonalMobileNumber).HasMaxLength(11).IsRequired(false);
            builder.Property(x => x.PhoneNumber).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.GenderType).HasMaxLength(1).IsRequired();
            builder.Property(x => x.TurningMethod).IsRequired(false);
            builder.Property(x => x.Website).HasMaxLength(400).IsRequired(false);

            builder.HasQueryFilter(x => !x.Deleted);

            base.Configure(builder);
        }
    }
}