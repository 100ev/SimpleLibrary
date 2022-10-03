using TestWebAPI.Model.Request;
using TestWebAPIModel.Request;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AddAuthorResponse> GetAllAuthors();

        AddAuthorResponse GetAuthroById(int id);

        AddAuthorResponse AddAutor(AddMultipleAuthosrRequest user);


        AddAuthorResponse? UpdateAutor(AddMultipleAuthosrRequest user);


        AddAuthorResponse? DeletAutor(AddMultipleAuthosrRequest author);

        AddAuthorResponse? GetAuthorByName(string name);
        public bool AddMultipleAuthors(IEnumerable<Author> authorsCollection);
    }

}
