using BookApi.Domain.Entities.Base;

namespace BookApi.Domain.Entities
{
    public class Order : BaseEntity<long>
    {
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
