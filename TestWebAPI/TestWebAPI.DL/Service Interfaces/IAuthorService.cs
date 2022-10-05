using TestWebAPI.Model.Request;
using TestWebAPIModel.Request;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AddAuthorResponse> GetAllAuthors();

        public Task<AddAuthorResponse> GetAuthorByName(AddAuthorRequest name);

        public Task<AddAuthorResponse> GetAuthroById(int id);

        public Task<AddAuthorResponse> AddAutor(AddMultipleAuthosrRequest user);

        public Task<AddAuthorResponse>? UpdateAutor(AddMultipleAuthosrRequest authorRequest, int id);

        public bool AddMultipleAuthors(IEnumerable<Author> authorsCollection);
    }

}
