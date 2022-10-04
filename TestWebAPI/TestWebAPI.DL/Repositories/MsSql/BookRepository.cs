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
    public class BookRepository : IBookRepository
    {
        private readonly ILogger<Book> _book;
        private readonly IConfiguration _configuration;

        public BookRepository(ILogger<Book> book, IConfiguration configuration)
        {
            _book = book;
            _configuration = configuration;
        }
        public void AddBook(Book book)
        {
            
        }
        public async Task<IEnumerable<Book>> GetAlBooks()
        {
            var results = new List<Book>();
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    await conn.OpenAsync();
                    return await conn.QueryAsync<Book>("SELECT * FROM Books WITH(NOLOCK)");

                }
            }
            catch (Exception e)
            {
                _book.LogError($"Error in {nameof(GetAlBooks)}-{e.Message}", e);
            }

            return Enumerable.Empty<Book>();
        }

        public async Task<Book> GetById(int id)
        {
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    return await conn.QueryFirstOrDefaultAsync<Book>("SELECT * FROM Books WHERE Id = @Id", new { Id = id });

                }
            }
            catch (Exception e)
            {
                _book.LogError($"Error in {nameof(GetAlBooks)}-{e.Message}", e);
            }

            return null;
        }

        public void RemoveBook(Book book)
        {
            
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
