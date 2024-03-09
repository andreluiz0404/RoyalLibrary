using RoyalLibrary.Infra.Abstractions;
using RoyalLibrary.Models;
using RoyalLibrary.Repositories.Abstractions;
using RoyalLibrary.Services.Abstractions;

namespace RoyalLibrary.Services.Concretes
{
    public class BookService(IBookRepository repository, IUnitOfWork unitOfWork) : BaseService<Book>(repository, unitOfWork), IBookService
    {
        public async Task<Book?> GetById(int id)
            => await ((IBookRepository)Repository).GetById(id);

        public async Task<List<Book>> List()
            => await ((IBookRepository)Repository).List();
    }
}
