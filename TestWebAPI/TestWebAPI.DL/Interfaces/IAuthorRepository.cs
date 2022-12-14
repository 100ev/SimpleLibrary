using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors();

        public Task<Author> GetById(int id);

         Task<Author> AddAutor(Author author);


         public Task<Author>? UpdateUser(int userId);


        public Task<Author>? DeletAutor(int userId);

        public Task<Author?> GetAuthorByName(string name);

        public Task<Author> AddMultipleAuthors (Author author);

    }
}
