using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;

namespace TestWebAPI.DL.Service_Interfaces
{
    public interface IBookService
    {
        IEnumerable<AddBookResponse> GetAllBooks();


        AddBookResponse AddBook(AddBookRequest book);


        AddBookResponse? UpdateBook(AddBookRequest book);


        AddBookResponse? DeletBook(AddBookRequest book);
        object GetById(int id);
    }
}
