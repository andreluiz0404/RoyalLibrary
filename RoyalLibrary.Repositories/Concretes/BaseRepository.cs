using RoyalLibrary.Infra.Abstractions;
using RoyalLibrary.Repositories.Abstractions;

namespace RoyalLibrary.Repositories.Concretes
{
    public class BaseRepository<TMDL>(IRoyalLibraryDbContext dbContext):IBaseRepository<TMDL> where TMDL : class
    {
        protected readonly IRoyalLibraryDbContext DbContext = dbContext;
    }
}
