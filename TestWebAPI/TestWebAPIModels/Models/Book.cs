namespace TestWebAPIModels.Models
{
    public record Book
    {
        public int Id { get; init; }
        public string Title { get; init; }

        public int AuthorId { get; init; }
        public int Quantity { get; set; }
        public DateTime LastUpdate { get; init; }

        public decimal Price { get; set; }
    }
}
