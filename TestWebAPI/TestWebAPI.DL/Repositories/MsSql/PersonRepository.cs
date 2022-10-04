using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.DL.Interfaces;
using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Repositories.MsSql
{
    public class PersonRepository : IPersonRepository
    {
        public Task<Person> AddUsers(Person user)
        {
            throw new NotImplementedException();
        }

        public Task<Person> DeletePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person>? UpdateUser(Person user)
        {
            throw new NotImplementedException();
        }
    }
}
