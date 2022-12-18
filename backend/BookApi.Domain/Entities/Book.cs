using BookApi.Domain.Entities.Base;

namespace BookApi.Domain.Entities {
    public class Book: BaseEntity<long> {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Language { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}