using System.Net;
using AutoMapper;
using MediatR;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.Model.Models.MediatR.Commands;
using TestWebAPIModel.Responses;

namespace TestWebAPI.CommandHandlers
{
    public class GetAllAuthorsCommandHandler : IRequestHandler<GetAllAuthorsCommand, IEnumerable<AddAuthorResponse>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllAuthorsCommandHandler> _logger;
        public GetAllAuthorsCommandHandler(IAuthorRepository authorRepository, IMapper mapper, ILogger<GetAllAuthorsCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
        }
        

        public async Task<IEnumerable<AddAuthorResponse>> Handle(GetAllAuthorsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (_authorRepository == null)
                {
                    return null;
                }
                var result = await _authorRepository.GetAllAuthors();
                var books = _mapper.Map<TestWebAPIModels.Models.Book>(result);
            }
            catch (Exception)
            {
                _logger.LogError("Author collection does not exit");
            }
            return null;
        }
    }
}
