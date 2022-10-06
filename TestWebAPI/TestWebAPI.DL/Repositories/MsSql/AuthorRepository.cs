using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TestWebAPI.DL.Interfaces;
using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Repositories.MsSql
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ILogger<AuthorRepository > _logger;
        private readonly IConfiguration _configuration;
        public AuthorRepository(ILogger<AuthorRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }             

        public async Task<Author> AddAutor(Author author)
        {
            var results = new List<Author>();
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    return await conn.QueryFirstOrDefaultAsync<Author>("SELECT * FROM Authors");
                    results.Add(new Author());
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(GetAllAuthors)}-{e.Message}", e);
            }

            return null;
        }

        public Task<Author> AddMultipleAuthors(Author author)
        {
            throw new NotImplementedException();
        }

        public async Task<Author>? DeletAutor(int userId)
        {
            var authors = new List<Author>();
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    var author =  await conn.QueryFirstOrDefaultAsync<Author>("SELECT * FROM Authors WHERE Id = @Id", new { Id = userId });
                    if (authors.Contains(author)) authors.Remove(author);
                    return author;                    
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(GetAllAuthors)}-{e.Message}", e);
            }

            return null;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            try
            {
               await  using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    
                    await conn.OpenAsync();
                   var result =  await conn.QueryAsync<Author>("SELECT * FROM Authors WITH(NOLOCK)");
                    return result;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(GetAllAuthors)}-{e.Message}", e);
            }

            return Enumerable.Empty<Author>();
        }

        public async Task<Author>? GetAuthorByName(string name)
        {
            try
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    var result = await conn.QueryFirstOrDefaultAsync<Author>("SELECT * FROM Authors WHERE Name = @Name", new { Name = name });
                    return result;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(GetAllAuthors)}-{e.Message}", e);
            }
            return null;
        
        }

        public async Task<Author> GetById(int id)
        {
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    await conn.OpenAsync();
                    var result =  await conn.QueryFirstOrDefaultAsync<Author>("SELECT * FROM Authors WHERE Id = @Id", new { Id = id });
                    return result;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(GetAllAuthors)}-{e.Message}", e);
            }

            return new Author();

        }

        public async Task<Author>? UpdateUser(int authroId)
        {
            var results = new List<Author>();
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    var result = await conn.QueryFirstOrDefaultAsync<Author>("SELECT * FROM Authors WHERE Id = @Id", new { Id = authroId });
                    return result;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(GetAllAuthors)}-{e.Message}", e);
            }

            return null;
        }
    }
}
