using _1_Fintranet.Common.Constants;
using _2_Fintranet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4_.Fintranet.Persistence.MappingConfigs
{
    public class DoctorDoctorOfficeMappingConfig : BaseEntityTypeConfiguration<DoctorDoctorOfficeMapping>
    {
        public override void Configure(EntityTypeBuilder<DoctorDoctorOfficeMapping> builder)
        {
            builder.ToTable(name: DefaultConstants.DoctorDoctorOfficeMappingTableName);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.DoctorId).HasColumnName("Doctor_Id");
            builder.Property(x => x.DoctorOfficeId).HasColumnName("DoctorOffice_Id");

            builder.HasOne(x => x.Doctor)
                .WithMany(doctor => doctor.DoctorDoctorOfficeMappings)
                .HasForeignKey(x => x.DoctorId)
                .IsRequired();

            builder.HasOne(x => x.DoctorOffice)
                .WithMany()
                .HasForeignKey(x => x.DoctorOfficeId)
                .IsRequired();

            base.Configure(builder);
        }
    }
}