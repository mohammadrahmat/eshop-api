using eshop.domain.Entities;

namespace eshop.domain.Repositories
{
    public class CityRepository : BaseRepository<City, int>, ICityRepository
    {
        public CityRepository(EShopDbContext context) : base(context) { }
    }
}