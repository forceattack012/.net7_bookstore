namespace BookApi.Application.DTOs
{
    public class BookRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Language { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}
