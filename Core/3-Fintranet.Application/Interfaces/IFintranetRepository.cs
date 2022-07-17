using _2_Fintranet.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace _3_Fintranet.Application.Interfaces
{
    public interface IFintranetRepository<T> where T : BaseEntity
    {
        DbSet<T>? Get { get; }
        IQueryable<T> Table { get; }
        IReadOnlyList<T> GetAll(bool trackChanges = true);
        Task<IReadOnlyList<T>> GetAllAsync(bool trackChanges);
        Task<T?> GetByIdAsync(Guid? id);
        Task<IReadOnlyList<T>> GetPagedAsync(int pageNumber, int pageSize);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}