using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TestWebAPI.DL.Interfaces;
using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Repositories.MsSql
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ILogger<Person> _personLogger;
        private readonly IConfiguration _configuration;

        public PersonRepository(ILogger<Person> personLogger, IConfiguration configuration)
        {
            _personLogger = personLogger;
            _configuration = configuration;
        }

        public async Task<Person> AddUsers(Person user)
        {
            List<Person> users = new List<Person>();
             users.Add(user);
            return null;
        }

        public async Task<Person> DeletePerson(int id)
        {
            try
            {
                await using(var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    return await conn.QueryFirstOrDefaultAsync<Person>("SELECT * FROM Person WHERE Id = @Id", new { Id = id });

                }
            }
            catch (Exception e)
            {
                _personLogger.LogError($"Cannot delete person by the given Id: {id}");
            }

            return null;
        }

        public async Task<IEnumerable<Person>> GetAllUsers()
        {
            var results = new List<Person>();
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    await conn.OpenAsync();
                    return await conn.QueryAsync<Person>("SELECT * FROM Person WITH(NOLOCK)");

                }
            }
            catch (Exception e)
            {
                _personLogger.LogError($"Error in {nameof(GetAllUsers)}-{e.Message}", e);
            }

            return null;
        }

        public async Task<Person> GetById(int id)
        {
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    return await conn.QueryFirstOrDefaultAsync<Person>("SELECT * FROM Person WHERE Id = @Id", new { Id = id });

                }
            }
            catch (Exception e)
            {
                _personLogger.LogError($"Invalid Id {id}");
            }

            return null;
        }

        public async Task<Person>? UpdateUser(int id)
        {
            var results = new List<Person>();
            try
            {
                await using(var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    return await conn.QueryFirstOrDefaultAsync<Person>("SELECT * FROM Authors Person Id = @Id", new { Id = id });
                }
            }
            catch (Exception e)
            {
                _personLogger.LogError($"Error in {nameof(UpdateUser)}-{e.Message}", e);
            }

            return null;
        }
    }
}
