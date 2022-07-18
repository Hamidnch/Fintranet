using System.Linq.Expressions;
using _2_Fintranet.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace _3_Fintranet.Application.Interfaces
{
    public interface IFintranetRepository<T> where T : BaseEntity
    {
        DbSet<T> Get { get; }
        IQueryable<T> Table { get; }
        IReadOnlyList<T> GetAll(bool trackChanges = true);
        Task<IReadOnlyList<T>> GetAllAsync(bool trackChanges);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<T?> GetByIdAsync(int? id);
        Task<IReadOnlyList<T>> GetPagedAsync(int pageNumber, int pageSize);
        Task InsertAsync(T entity);
        Task InsertRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}