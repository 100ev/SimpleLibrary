using MediatR;
using Book = TestWebAPIModels.Models.Book;

namespace TestWebAPI.Model.Models.MediatR.Commands
{
    public record GetAllBooksCommand : IRequest<IEnumerable<Book>>
    {

    }
}
