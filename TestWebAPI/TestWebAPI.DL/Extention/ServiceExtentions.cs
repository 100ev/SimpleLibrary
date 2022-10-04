using Microsoft.Extensions.DependencyInjection;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.DL.Repositories.AuthorRepository;
using TestWebAPI.DL.Repositories.BookRepository;
using TestWebAPI.DL.Repositories.MemoryRepository;
using TestWebAPI.DL.Repositories.MsSql;

namespace BookStore.BL.Extention
{
    public static class ServiceExtentions
    {
        public static IServiceCollection RegistratesRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IAuthorRepository, AuthorRepository>();
            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorRepository, AuthorRepository>();
            return services;
        }

        public static IServiceCollection RegistrateRepositoriesForBook(this IServiceCollection services)
        {
            services.AddSingleton<IBookRepository, BookRepository>();
            return services;
        }
    }
}
