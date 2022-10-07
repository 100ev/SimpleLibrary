using System.Net;
using AutoMapper;
using MediatR;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.Model.Models.MediatR.Commands;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.CommandHandlers
{
    public class GetAuthorByNameCommandHandler : IRequestHandler<GetAuthorByNameCommand, AddAuthorResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAuthorByNameCommandHandler> _logger;
        public GetAuthorByNameCommandHandler(IAuthorRepository authorRepository, IMapper mapper, ILogger<GetAuthorByNameCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AddAuthorResponse> Handle(GetAuthorByNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var autName = await _authorRepository.GetAuthorByName(request.name);
                if (request == null)
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                    };
                else
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.OK,
                        Author = autName
                    };
            }
            catch (Exception)
            {
                _logger.LogError("There is no such author");
            }

            return null;
        }
    }
}
