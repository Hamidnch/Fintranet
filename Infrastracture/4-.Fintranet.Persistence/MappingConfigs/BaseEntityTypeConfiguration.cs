using _2_Fintranet.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4_.Fintranet.Persistence.MappingConfigs
{
    public class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.CreatedDateTime).HasDefaultValueSql("getdate()");
            builder.Property(x => x.UpdatedDateTime).HasDefaultValueSql("getdate()");
        }
    }
}