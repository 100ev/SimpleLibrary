using MediatR;
using TestWebAPI.Model.Responses;

namespace TestWebAPI.Model.Models.MediatR.Commands
{
    public record DeleteBookCommand(int bookId) : IRequest<AddBookResponse>
    {
    }
}
