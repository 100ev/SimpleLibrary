using System.Net;
using AutoMapper;
using MediatR;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.Model.Models.MediatR.Commands;
using TestWebAPI.Model.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.CommandHandlers
{
    public class GetBookByIdCommandHandler : IRequestHandler<GetBookByIdCommand, Book>
    {

        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetBookByIdCommandHandler> _logger;
        public GetBookByIdCommandHandler(IBookRepository bookService, IMapper mapper, ILogger<GetBookByIdCommandHandler> logger)
        {
            _bookRepository = bookService;            
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Book> Handle(GetBookByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.bookId <= 0)
                    return null;

                var mapBook = _mapper.Map<TestWebAPIModels.Models.Book>(request.bookId);

                await _bookRepository.GetById(request.bookId);

            }
            catch (Exception)
            {
                _logger.LogError("There is no book with the represented Id");
            }

            return await _bookRepository.GetById(request.bookId);
        }
    }
}
