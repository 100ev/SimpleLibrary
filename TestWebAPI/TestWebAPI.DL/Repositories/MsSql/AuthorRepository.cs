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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ILogger<AuthorRepository > _logger;
        private readonly IConfiguration _configuration;
        public AuthorRepository(ILogger<AuthorRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<Author> AddAutor(int authorId)
        {
            var results = new List<Author>();
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    return await conn.QueryFirstOrDefaultAsync<Author>("SELECT * FROM Authors WHERE Id = @Id", new { Id = authorId });
                    results.Remove(new Author()
                    {
                        Id = authorId,
                    });
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(GetAllAuthors)}-{e.Message}", e);
            }

            return null;
        }

        public Task<bool> AddMultipleAuthors(IEnumerable<Author> authorCollection)
        {
            throw new NotImplementedException();
        }

        public async Task<Author>? DeletAutor(int userId)
        {
            var results = new List<Author>();
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    return await conn.QueryFirstOrDefaultAsync<Author>("SELECT * FROM Authors WHERE Id = @Id", new { Id = userId });
                    results.Remove(new Author()
                    {
                        Id = userId,
                    });
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
            var results = new List<Author>();
            try
            {
               await  using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    
                    await conn.OpenAsync();
                   return  await conn.QueryAsync<Author>("SELECT * FROM Authors WITH(NOLOCK)");                   
                    
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
                    return await conn.QueryFirstOrDefaultAsync<Author>("SELECT * FROM Authors WHERE Id = @Id", new { Id = id });

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
                    return await conn.QueryFirstOrDefaultAsync<Author>("SELECT * FROM Authors WHERE Id = @Id", new { Id = authroId });                    
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
