using eshop.domain.Entities;

namespace eshop.domain.Repositories
{
    public class CountryRepository : BaseRepository<Country, int>, ICountryRepository
    {
        public CountryRepository(EShopDbContext context) : base(context) { }
    }
}