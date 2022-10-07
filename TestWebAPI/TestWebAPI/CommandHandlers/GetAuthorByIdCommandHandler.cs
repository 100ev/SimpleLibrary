using System.Net;
using AutoMapper;
using MediatR;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.Model.Models.MediatR.Commands;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.CommandHandlers
{
    public class GetAuthorByIdCommandHandler : IRequestHandler<GetAuthorByIdCommand, AddAuthorResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAuthorByIdCommandHandler> _logger;
        public GetAuthorByIdCommandHandler(IAuthorRepository authorRepository, IMapper mapper, ILogger<GetAuthorByIdCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
        }
        

        public async Task<AddAuthorResponse> Handle(GetAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var reslt = await _authorRepository.GetById(request.id);

                if (reslt == null)
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.NotFound
                    };
                else
                    return new AddAuthorResponse()
                    {
                        HttpStatusCode = HttpStatusCode.OK,
                        Author = reslt
                    };
            }
            catch (Exception)
            {
                _logger.LogError("There is no author with the represented Id");
            }
            return null;
        }
    }
}
