using _2_Fintranet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4_.Fintranet.Persistence.MappingConfigs
{
    public class PersonEntityTypeConfiguration<T> : BaseEntityTypeConfiguration<T> where T: Person
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(200).IsRequired();
            builder.Property(p => p.FullName).HasComputedColumnSql("[LastName] + ', ' + [FirstName]").HasMaxLength(300);
            builder.Property(p => p.NationalCode).HasMaxLength(11);
            builder.Property(p => p.LastIpAddress).HasMaxLength(20);
            builder.Property(x => x.GenderType).HasMaxLength(1).IsRequired();
        }
    }
}