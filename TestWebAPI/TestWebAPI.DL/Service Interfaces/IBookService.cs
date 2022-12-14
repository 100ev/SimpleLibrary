using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;

namespace TestWebAPI.DL.Service_Interfaces
{
    public interface IBookService
    {
        public Task<AddBookResponse> GetAllBooks();

        public Task<AddBookResponse> AddBook(AddBookRequest bookRequest);

       public Task<AddBookResponse>? UpdateBook(AddBookRequest bookRequests, int id);

        public Task<AddBookResponse>? DeletBook(AddBookRequest BookRequest, int id);
        public Task<AddBookResponse> GetById(int id);
    }
}
