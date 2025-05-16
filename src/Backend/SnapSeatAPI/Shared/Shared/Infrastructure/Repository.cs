using Microsoft.EntityFrameworkCore;
using Shared.Application.Interfaces;

namespace Shared.Infrastructure
{
    public class Repository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        protected readonly TDbContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(TDbContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }

        public virtual IQueryable<TEntity> GetAllAsync()
        {
            return _dbSet;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _db.SaveChangesAsync(cancellationToken) > 0;
        }

    }
}
