using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.DL.Interfaces;
using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Repositories.AuthorRepository
{

    public class AuthorInMemoryRepository : IAuthorRepository
    {
        private static List<Author> _users = new List<Author>()
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


        public AuthorInMemoryRepository()
        {
        }

        public IEnumerable<Author> GetAllUsers()
        {
            return _users;
        }

        public Author GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public Author AddUsers(Author user)
        {
            try
            {
                _users.Add(user);

            }
            catch (Exception e)
            {
                return null;
            }

            return user;
        }

        public Author? UpdateUser(Author user)
        {
            var existingUser = _users.FirstOrDefault(x => x.Id == user.Id);
            if (existingUser == null) return null;
            _users.Remove(existingUser);
            _users.Add(user);

            return user;
        }

        public Author? DeletUser(int userId)
        {
            if (userId <= 0) return null;
            var user = _users.FirstOrDefault(x => x.Id == userId);
            _users.Remove(user);
            return user;
        }

        IEnumerable<Author> IAuthorRepository.GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }

}
