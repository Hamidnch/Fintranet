using Microsoft.EntityFrameworkCore;

namespace _3_Fintranet.Application.Interfaces.Commons;

public interface IFintranetContext
{
    DbSet<T> Set<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    Task<int> ExecuteSqlRawAsync(string query, CancellationToken cancellationToken);
    Task<int> ExecuteSqlRawAsync(string query);
}