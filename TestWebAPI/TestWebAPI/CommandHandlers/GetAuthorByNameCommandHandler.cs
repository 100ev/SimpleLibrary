using MediatR;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.Model.Models.MediatR.Commands;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.CommandHandlers
{
    public class GetAuthorByNameCommandHandler : IRequestHandler<GetAuthorByNameCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;
        public GetAuthorByNameCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(GetAuthorByNameCommand request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetAuthorByName(request.name);
        }
    }
}
