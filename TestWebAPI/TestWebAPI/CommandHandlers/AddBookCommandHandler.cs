using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.DL.Service_Interfaces;
using TestWebAPI.Model.Models.MediatR.Commands;
using TestWebAPI.Model.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.DL.CommandHandlers
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, AddBookResponse>
    {
        private readonly IBookRepository _bookRepository;        
        private readonly IMapper  _mapper;
        private readonly ILogger<AddBookCommandHandler> _logger;

        public AddBookCommandHandler(IBookRepository bookRepository, IMediator mediator, IMapper mapper, ILogger<AddBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }
        
        public async Task<AddBookResponse> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var book = _bookRepository.GetById(request._book.Id);
                if (book != null)
                {
                    return new AddBookResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };
                }

                var bookMapper = _mapper.Map<Book>(request);
                await  _bookRepository.AddBook(bookMapper);

                return new AddBookResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Title = bookMapper
                };
            }
            catch (Exception)
            {
                _logger.LogError("Book can't be added");
            }

            return null;
        }
    }
}
