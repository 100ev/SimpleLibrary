using TestWebAPI.Model.Request;
using TestWebAPIModel.Request;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AddAuthorResponse> GetAllAuthors();

        AddAuthorResponse GetAuthorByName(AddAuthorRequest name);

        AddAuthorResponse GetAuthroById(int id);

        AddAuthorResponse AddAutor(AddMultipleAuthosrRequest user);


        AddAuthorResponse? UpdateAutor(AddMultipleAuthosrRequest user);

        public bool AddMultipleAuthors(IEnumerable<Author> authorsCollection);
    }

}
