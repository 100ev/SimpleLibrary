using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPIModel.Request;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AddAuthorResponse> GetAllAuthors();

        AddAuthorResponse GetAuthroById(int id);

        AddAuthorResponse AddAutor(AddAuthorRequest user);


        AddAuthorResponse? UpdateAutor(AddAuthorRequest user);


        AddAuthorResponse? DeletAutor(int userId);

        AddAuthorResponse? GetAuthorByName(string name);
    }

}
