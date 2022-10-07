using System.Net;
using AutoMapper;
using MediatR;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.Model.Models.MediatR.Commands;
using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;
using TestWebAPIModels.Models;
using Book = TestWebAPIModels.Models.Book;

namespace TestWebAPI.CommandHandlers
{
    public class GetAllBooksCommandHandler : IRequestHandler<GetAllBooksCommand, IEnumerable<Book>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllBooksCommandHandler> _logger;

        public GetAllBooksCommandHandler(IBookRepository bookRepository, ILogger<GetAllBooksCommandHandler> logger, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Book>> Handle(GetAllBooksCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (_bookRepository == null)
                    return null;
                var result = await _bookRepository.GetAlBooks();
                var books = _mapper.Map<TestWebAPIModels.Models.Book>(result);
               
            }
            catch (Exception)
            {
                _logger.LogError("book collection does not exit");
            }
            return await _bookRepository.GetAlBooks();
        }
    }
}
