namespace RoyalLibrary.Infra.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}