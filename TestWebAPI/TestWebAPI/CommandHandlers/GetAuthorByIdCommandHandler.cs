using MediatR;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.Model.Models.MediatR.Commands;
using TestWebAPIModels.Models;

namespace TestWebAPI.CommandHandlers
{
    public class GetAuthorByIdCommandHandler : IRequestHandler<GetAuthorByIdCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;
        public GetAuthorByIdCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<Author> Handle(GetAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetById(request.id);
        }
    }
}
