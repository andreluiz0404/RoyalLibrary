using RoyalLibrary.Models;

namespace RoyalLibrary.Services.Abstractions
{
    public interface IBookService : IBaseService<Book>
    {
        Task<Book?> GetById(int id);

        Task<List<Book>> List();
    }
}
