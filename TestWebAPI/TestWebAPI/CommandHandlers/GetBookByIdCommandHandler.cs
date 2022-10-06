using MediatR;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.DL.Service_Interfaces;
using TestWebAPI.Model.Models.MediatR.Commands;
using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.CommandHandlers
{
    public class GetBookByIdCommandHandler : IRequestHandler<GetBookByIdCommand, Book>
    {

        private readonly IBookRepository _bookRepository;
        public GetBookByIdCommandHandler(IBookRepository bookService)
        {
            _bookRepository = bookService;
        }

        public async Task<Book> Handle(GetBookByIdCommand request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetById(request.bookId);
        }
    }
}
