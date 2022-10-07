using System.Net;
using AutoMapper;
using MediatR;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.Model.Models.MediatR.Commands;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.CommandHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, AddAuthorResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAuthorCommandHandler> _logger;
        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, ILogger<UpdateAuthorCommandHandler> logger, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _logger = logger;
            _mapper = mapper;
        }
       
        public async Task<AddAuthorResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var auth = _authorRepository.GetById(request.id);

                if (auth != null)
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };

                var author = _mapper.Map<Author>(request);

                await _authorRepository.AddAutor(author);

                return new AddAuthorResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Author = author
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Cannot update author");
            }
            return null;
        }
    }
}
