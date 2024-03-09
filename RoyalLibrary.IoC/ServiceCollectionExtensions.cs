using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RoyalLibrary.Infra.Abstractions;
using RoyalLibrary.Infra.Concretes;
using RoyalLibrary.Repositories.Abstractions;
using RoyalLibrary.Repositories.Concretes;
using RoyalLibrary.Services.Abstractions;
using RoyalLibrary.Services.Concretes;

namespace RoyalLibrary.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRoyalLibraryDbContext(this IServiceCollection services, string connectionString)
            => services.AddDbContext<IRoyalLibraryDbContext, RoyalLibraryDbContext>(options => options.UseSqlServer(connectionString));

        public static void RegisterInfra(this IServiceCollection services)
            => services.AddScoped<IUnitOfWork, UnitOfWork>();

        public static void RegisterRepositories(this IServiceCollection services)
            => services.AddScoped<IBookRepository, BookRepository>();

        public static void RegisterServices(this IServiceCollection services)
            => services.AddScoped<IBookService, BookService>();
    }
}