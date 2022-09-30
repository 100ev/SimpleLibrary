using BookStore.BL.Interfaces;

namespace BookStore.BL.Services
{
    public class PersonService : IUserRepository
    {
        private readonly IUserRepository _personRepository;
        public Person AddUsers(Person user)
        {
           return _personRepository.AddUsers(user);
        }

        public Person? DeletUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Person GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Person? UpdateUser(Person user)
        {
            throw new NotImplementedException();
        }
    }
}