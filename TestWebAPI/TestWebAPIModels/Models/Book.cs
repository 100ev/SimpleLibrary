namespace TestWebAPIModels.Models
{
    public record Book
    {
        public int Id { get; init; }
        public string Title { get; init; }

        public int AuthorId { get; init; }
        public DateTime dateOfBirth { get; init; }
    }
}
