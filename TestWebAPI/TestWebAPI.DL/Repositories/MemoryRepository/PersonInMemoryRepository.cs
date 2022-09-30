using TestWebAPI.DL.Interfaces;
using TestWebAPIModels;
using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Repositories.MemoryRepository
{
    public class PersonInMemoryRepository : IUserRepository
    {
        private static List<Person> _users = new List<Person>()
        {
            new Person()
            {
                Id = 1,
                Name = "Pesho",
                Age = 20,
            },
            new Person()
            {
                Id = 1,
                Name = "Kerano",
                Age = 20,
            }

        };

        
        public PersonInMemoryRepository()
        {
        }

        public IEnumerable<Person> GetAllUsers()
        {
            return _users;
        }

        public Person GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public Person AddUsers(Person user)
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

        public Person? UpdateUser(Person user)
        {
            var existingUser = _users.FirstOrDefault(x => x.Id == user.Id);
            if (existingUser == null) return null;
            _users.Remove(existingUser);
            _users.Add(user);

            return user;            
        }

        public Person? DeletUser(int userId)
        {
            if (userId <= 0) return null;
            var user = _users.FirstOrDefault(x => x.Id == userId);
            _users.Remove(user);
            return user;
        }

        Book? IUserRepository.DeletUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
