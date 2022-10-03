using Microsoft.Extensions.Logging;
using TestWebAPI.DL.Interfaces;
using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Repositories.AuthorRepository
{

    public class AuthorInMemoryRepository : IAuthorRepository
    {
        private readonly ILogger<AuthorInMemoryRepository> _authorRepositoryLogger;

        private static List<Author> _author = new List<Author>()
        {
            new Author()
            {
                Id = 1,
                Name = "Pesho",
                Age = 20,

            },
            new Author()
            {
                Id = 1,
                Name = "Kerano",
                Age = 20,
            }

        };
       public IEnumerable<Author> GetAllAuthors()
        {
            return _author;
        }

        public AuthorInMemoryRepository(ILogger<AuthorInMemoryRepository> authorRepositoryLogger)
        {
            _authorRepositoryLogger = authorRepositoryLogger;
        }

        public IEnumerable<Author> GetAllUsers()
        {
            return _author;
        }

        public Author GetById(int id)
        {
            return _author.FirstOrDefault(x => x.Id == id);
        }

        public Author AddUsers(Author user)
        {
            try
            {
                _author.Add(user);

            }
            catch (Exception e)
            {
                return null;
            }

            return user;
        }

        public Author? UpdateUser(Author user)
        {
            try
            {
                var existingUser = _author.FirstOrDefault(x => x.Id == user.Id);
                if (existingUser == null) return null;
                _author.Remove(existingUser);
                _author.Add(user);

                return user;
            }
            catch (Exception)
            {
                 _authorRepositoryLogger.LogError("Author not found");
            }
            return null;
            
        }

        public Author? DeletUser(int userId)
        {
            if (userId <= 0) return null;
            var user = _author.FirstOrDefault(x => x.Id == userId);
            _author.Remove(user);
            return user;
        }

        public Author? GetAuthorByName(string name)
        {
            return _author.FirstOrDefault(a => a.Name == name);
        }

        public void AddAutor(Author autor)
        {
            _author.Add(autor);
        }

        public bool AddMultipleAuthors(IEnumerable<Author> authorCollection)
        {
            try
            {
                AuthorInMemoryRepository._author.AddRange(authorCollection);
                return true; 
            }
            catch (Exception)
            {
                _authorRepositoryLogger.LogWarning("Unable to add multiple authors ");

                return false;
            };
        }
    }

}
