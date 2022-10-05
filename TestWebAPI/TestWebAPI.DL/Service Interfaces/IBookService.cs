using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;

namespace TestWebAPI.DL.Service_Interfaces
{
    public interface IBookService
    {
        IEnumerable<AddBookResponse> GetAllBooks(IEnumerable<AddBookRequest> bookRequests);

        AddBookResponse AddBook(AddBookRequest bookRequest);

        AddBookResponse? UpdateBook(AddBookRequest bookRequests, int id);

        AddBookResponse? DeletBook(AddBookRequest BookRequest, int id);
        AddBookResponse GetById(int id);
    }
}
