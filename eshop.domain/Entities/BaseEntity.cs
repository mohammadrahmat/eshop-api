namespace eshop.domain.Entities
{
    public class BaseEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
    }
}