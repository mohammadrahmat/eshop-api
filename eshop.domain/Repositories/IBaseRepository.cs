namespace eshop.domain.Repositories
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        Task<TKey> InsertAsync(TEntity entity);
        Task<TEntity> GetAsync(TKey key);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task UpdateAsync(TKey key, TEntity entity);
        Task DeleteAsync(TKey key);
    }
}