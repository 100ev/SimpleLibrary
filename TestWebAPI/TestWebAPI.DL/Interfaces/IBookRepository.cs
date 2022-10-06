using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Interfaces
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAlBooks();
        public Task<Book> GetById(int id);

        void AddBook(Book book);
        void RemoveBook(int id);
        void UpdateBook (int id);

    }
}
