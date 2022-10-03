using TestWebAPI.DL.Interfaces;
using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Repositories.BookRepository
{
    public class BookInMemoryRepository : IBookRepository
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Title = "The old man and the sea",
                AuthorId = 20,
            },
            new Book()
            {
                Id = 2,
                Title = "The lord of the rings",
                AuthorId = 27,
            }

        };

        public BookInMemoryRepository()
        {
        }
        public IEnumerable<Book> GetAlBooks()
        {
            return _books;
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public Book? FindAuthorById(int id)
        {
            if (id <= 0) return null;
            
            var authorId = _books.Single(at => at.AuthorId == id);
            return authorId;
        }

        public Book GetById(int id)
        {
            if (id <= 0) return null;

            var bookId = _books.Single(at => at.AuthorId == id);
            return bookId;
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }
    }
}
