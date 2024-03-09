using RoyalLibrary.Models;

namespace RoyalLibrary.Repositories.Abstractions
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<Book?> GetById(int id);

        Task<List<Book>> List();
    }
}