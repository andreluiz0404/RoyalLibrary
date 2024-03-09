using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Infra.Abstractions;

namespace RoyalLibrary.Infra.Concretes
{
    public class UnitOfWork(IRoyalLibraryDbContext dbContext) : IUnitOfWork
    {
        private readonly IRoyalLibraryDbContext _dbContext = dbContext;
        private bool _isDisposed;

        public void Dispose()
        {
            if (_isDisposed)
                return;
            _dbContext.Dispose();
            _isDisposed = true;
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries[0].Reload();
            }
        }
    }
}
