using System.Data.SqlClient;
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

        public async Task<Book> RemoveBook(int id)
        {
            
            var book = new Book();
            var results = new List<Book>();
            
            results.Add(book);
            var bookToRemove = book.Id == id;
            try
            {
                await using(var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    await conn.QueryFirstOrDefaultAsync<Book>("SELECT * FROM Books Id = @Id", new { Id = id });
                    if (book.Id == id)
                    {
                        results.Remove(book);
                    }
                    
                }
            }
            catch (Exception e)
            {
                _book.LogError($"cannot Delete Book By given Id");
            }

            return null;
        }
        

        public async Task<Book> AddBook(Book book)
        {
            return book;
        }

        public async Task<Book> UpdateBook(int id)
        {
            //var results = new List<Book>();
            try
            {
                await using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await conn.OpenAsync();
                    await conn.QueryFirstOrDefaultAsync<Book>("SELECT * FROM Books WHERE Id = @Id", new { Id = id });
                    return new Book()
                    {
                        Id = id
                    };
                }
            }
            catch (Exception e)
            {
                _book.LogError($"Invalid id {id}");
            }
            return null;

        }
    }
}
