using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAlBooks();
        Book GetById(int id);

        void AddBook(Book book);


        Book? FindAuthorById(int id);


        void RemoveBook(Book book);
    }
}
