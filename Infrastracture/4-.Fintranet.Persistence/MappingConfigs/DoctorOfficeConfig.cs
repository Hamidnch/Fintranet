using _1_Fintranet.Common.Constants;
using _1_Fintranet.Common.Enums;
using _2_Fintranet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4_.Fintranet.Persistence.MappingConfigs
{
    public class DoctorOfficeConfig : BaseEntityTypeConfiguration<DoctorOffice>
    {
        public override void Configure(EntityTypeBuilder<DoctorOffice> builder)
        {
            builder.ToTable(name: DefaultConstants.DoctorOfficeTableName);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();

            builder.Property(x => x.PlaceName).HasDefaultValue(PlaceName.Office);
            builder.Property(x => x.Phone1).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Phone2).HasMaxLength(250).IsRequired();
            builder.Property(x => x.FullAddress).HasMaxLength(500).IsRequired();
            builder.Property(x => x.WhatsUp).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.FaxNumber).HasMaxLength(30).IsRequired(false);
            builder.Property(x => x.Province).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.City).HasMaxLength(50).IsRequired(false);

            base.Configure(builder);
        }
    }
}