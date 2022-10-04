using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;

namespace TestWebAPI.DL.Service_Interfaces
{
    public interface IBookService
    {
        IEnumerable<AddBookResponse> GetAllBooks(IEnumerable<AddBookRequest> bookRequests);

        AddBookResponse AddBook(AddBookRequest bookRequest);

        AddBookResponse? UpdateBook(AddBookRequest bookRequests);

        AddBookResponse? DeletBook(AddBookRequest BookRequest);
        AddBookResponse GetById(int id);
    }
}
