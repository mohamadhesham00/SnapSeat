namespace Shared.Application.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        IQueryable<TEntity> GetAllAsync();
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
