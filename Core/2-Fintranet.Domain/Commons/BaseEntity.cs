using System.ComponentModel.DataAnnotations;
using _1_Fintranet.Common.Interfaces;

namespace _2_Fintranet.Domain.Commons
{
    public interface IBaseEntity
    {
    }

    public interface IBaseEntity<out TKey> : IBaseEntity
    {
        public TKey Id { get; }
    }

    public abstract class BaseEntity<TKey> : IBaseEntity<TKey?>
    {
        public virtual TKey Id { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
        public DateTimeOffset CreatedDateTime => DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedDateTime { get; set; }

        private int? _requestedHashCode;

        public bool IsTransient()
        {
            return Id != null && Id.Equals(default(TKey));
        }

        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity<TKey> item)
                return false;

            if (ReferenceEquals(this, item))
                return true;

            if (GetType() != item.GetType())
                return false;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item == this;
        }
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (Id != null) 
                    _requestedHashCode ??= Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(BaseEntity<TKey> left, BaseEntity<TKey>? right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(BaseEntity<TKey> left, BaseEntity<TKey> right)
        {
            return !(left == right);
        }
    }

    public abstract class BaseEntity : BaseEntity<Guid>, ISoftDeletedEntity
    {
        public bool Deleted { get; set; }
    }
}