using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.Model.Responses
{
    public class AddBookResponse : BaseResponse
    {
        public Book Title { get; set; }
    }
}
