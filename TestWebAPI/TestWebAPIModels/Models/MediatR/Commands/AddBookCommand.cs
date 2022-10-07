using MediatR;
using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;

namespace TestWebAPI.Model.Models.MediatR.Commands
{
    public record AddBookCommand(AddBookRequest Book) : IRequest<AddBookResponse>
    {
        public readonly AddBookRequest _book = Book;
    }
}
