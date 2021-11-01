using eshop.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace eshop.domain.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly EShopDbContext _context;

        public Repository(EShopDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(TKey key)
        {
            try
            {
                var entity = await GetAsync(key);
                _ = _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"Error Deleting: {ex}");
                throw;
            }
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            try
            {
                var items = await _context.Set<TEntity>().ToListAsync();

                return items.AsQueryable();
            }
            catch (Exception ex)
            {
                Log.Error($"Error Getting All: {ex}");
                throw;
            }
        }

        public async Task<TEntity> GetAsync(TKey key)
        {
            try
            {
                return await _context.Set<TEntity>().FirstOrDefaultAsync(e => Equals(key, e.Id));
            }
            catch (Exception ex)
            {
                Log.Error($"Error Getting Item: {ex}");
                throw;
            }
        }

        public async Task<TKey> InsertAsync(TEntity entity)
        {
            try
            {
                var response = await _context.Set<TEntity>().AddAsync(entity);

                await _context.SaveChangesAsync();

                return response.Entity.Id;
            }
            catch (Exception ex)
            {
                Log.Error($"Error Inserting: {ex}");
                throw;
            }
        }

        public async Task UpdateAsync(TKey key, TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"Error Updating: {ex}");
            }
        }
    }
}
