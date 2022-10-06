using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Interfaces
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAlBooks();
        public Task<Book> GetById(int id);

        public Task<Book> AddBook(Book book);
        public Task<Book> RemoveBook(int id);
        public Task<Book> UpdateBook (int id);

    }
}
