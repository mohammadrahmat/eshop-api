namespace eshop.domain.Entities
{
    public class City : BaseEntity<int>
    {
        public string CityName { get; set; }
        public int CountryId { get; set; }
    }
}