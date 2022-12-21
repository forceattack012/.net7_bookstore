using BookApi.Domain.Entities.Base;

namespace BookApi.Domain.Entities {
    public class Book: BaseEntity<long> {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Language { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedAt { get; set; }
        public List<Order> Orders { get; set; }
    }
}