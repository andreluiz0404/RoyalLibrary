using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Infra.Abstractions;
using RoyalLibrary.Models;
using RoyalLibrary.Repositories.Abstractions;

namespace RoyalLibrary.Repositories.Concretes
{
    public class BookRepository(IRoyalLibraryDbContext dbContext) : BaseRepository<Book>(dbContext), IBookRepository
    {
        public Task<Book?> GetById(int id)
            => DbContext.Set<Book>().AsNoTracking().SingleOrDefaultAsync(b => b.book_id == id);

        public Task<List<Book>> List()
            => DbContext.Set<Book>().AsNoTracking().OrderBy(b => b.book_id).ToListAsync();
    }
}
