using _1_Fintranet.Common.Constants;
using _2_Fintranet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4_.Fintranet.Persistence.MappingConfigs
{
    public class PatientConfig : PersonEntityTypeConfiguration<Patient>
    {
        public override void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable(name: DefaultConstants.PatientTableName);

            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
            builder.HasIndex(x => new { x.Email, x.DocumentNumber })
                .HasDatabaseName("IX_Patient_Email_DocumentNumber").IsUnique();

            builder.Property(x => x.DocumentNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.MobileNumber).HasMaxLength(100).IsRequired(false);

            builder.HasQueryFilter(x => !x.Deleted);

            base.Configure(builder);
        }
    }
}