using TestWebAPI.Model.Request;
using TestWebAPIModel.Request;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorService
    {
        public Task<AddAuthorResponse> GetAllAuthors();

        public Task<AddAuthorResponse> GetAuthorByName(AddAuthorRequest name);

        public Task<AddAuthorResponse> GetAuthroById(int id);

        public Task<AddAuthorResponse> AddAutor(AddAuthorRequest user);

        public Task<AddAuthorResponse>? UpdateAutor(AddMultipleAuthosrRequest authorRequest, int id);

        public Task<AddAuthorResponse> DeleteAuthor(AddAuthorRequest authorRequest);

        public Task<AddAuthorResponse> AddMultipleAuthors(IEnumerable<AddAuthorRequest> authorRequest);
    }

}
