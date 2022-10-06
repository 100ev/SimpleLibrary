using System.Net;
using AutoMapper;
using MediatR;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.DL.Service_Interfaces;
using TestWebAPI.Model.Models.MediatR.Commands;
using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;

namespace TestWebAPI.CommandHandlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, AddBookResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteBookCommandHandler> _logger;
        public DeleteBookCommandHandler(IBookRepository bookRepository,IMapper mapper, ILogger<DeleteBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<AddBookResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request != null)
                    return new AddBookResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };

                var mapBook = _mapper.Map<TestWebAPIModels.Models.Book>(request);

               await  _bookRepository.RemoveBook(request.bookId);

                return new AddBookResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                _logger.LogError("");
            }
            return null;
        }
    }
}
