using System.Net;
using AutoMapper;
using MediatR;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.Model.Models.MediatR.Commands;
using TestWebAPI.Model.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.CommandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateBookCommandHandler> _logger;
        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, ILogger<UpdateBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newBook = new TestWebAPIModels.Models.Book();

                if (request == null)
                    return null;

                var mapBook = _mapper.Map<TestWebAPIModels.Models.Book>(newBook);
                await _bookRepository.UpdateBook(request.bookId);                
            }
            catch (Exception)
            {
                _logger.LogError("The book can't be updated");
            }
            return await _bookRepository.UpdateBook(request.bookId);
        }
    }
}
