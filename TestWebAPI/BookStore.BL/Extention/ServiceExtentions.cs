using BookStore.BL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using TestWebAPI.DL.Interfaces;
using TestWebAPI.DL.Repositories.AuthorRepository;
using TestWebAPI.DL.Repositories.BookRepository;
using TestWebAPI.DL.Repositories.MemoryRepository;

namespace BookStore.BL.Extention
{
    internal static class ServiceExtentions
    {
        public static IServiceCollection RegistratesRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, PersonInMemoryRepository>();
            services.AddSingleton<IAuthorRepository, AuthorInMemoryRepository>();
            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorRepository, AuthorInMemoryRepository>();
            return services;
        }

        public static IServiceCollection RegistrateRepositoriesForBook(this IServiceCollection services)
        {
            services.AddSingleton<IBookRepository, BookInMemoryRepository>();
            return services;
        }
    }
}
