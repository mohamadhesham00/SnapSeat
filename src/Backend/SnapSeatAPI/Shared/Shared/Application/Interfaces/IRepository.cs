namespace Shared.Application.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetAllAsync();
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
