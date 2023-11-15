using Microsoft.EntityFrameworkCore;
using WalletBackend.Data.Interfaces;
using WalletBackend.Repositories.Interfaces;

namespace WalletBackend.Repositories.Implementations
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly TContext _context;
        public Repository(TContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await _context.Set<TEntity>().FirstAsync(e=>e.Id==id);
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(Guid id)
        => await _context.Set<TEntity>().AsNoTracking().AnyAsync(e=>e.Id==id);

        public IQueryable<TEntity> GetAll()
        => _context.Set<TEntity>().AsNoTracking();

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
