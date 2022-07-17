using _1_Fintranet.Common.Extensions;
using _2_Fintranet.Domain.Commons;
using _3_Fintranet.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _4_.Fintranet.Persistence.Contexts
{
    public class FintranetRepository<T> : IFintranetRepository<T> where T : BaseEntity
    {
        #region Fields

        private readonly DbSet<T> _dbSet;
        private readonly IFintranetContext _dbContext;

        public FintranetRepository(IFintranetContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        #endregion Fields

        public DbSet<T>? Get => _dbSet;
        public IQueryable<T> Table => _dbSet.AsNoTracking();

        public IReadOnlyList<T> GetAll(bool trackChanges = true)
        {
            return trackChanges ? _dbSet.ToList() : _dbSet.AsNoTracking().ToList();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(bool trackChanges)
        {
            return trackChanges ? await _dbSet.ToListAsync() : await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid? id)
        {
            if (id is null) return null;
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id.Value);
        }

        public async Task<IReadOnlyList<T>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var list = await GetAllAsync(true);
            return list.ToPaged(page: pageNumber, pageSize).ToList();
        }

        public async Task InsertAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                _dbSet.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}