using RoyalLibrary.Infra.Abstractions;
using RoyalLibrary.Repositories.Abstractions;
using RoyalLibrary.Services.Abstractions;

namespace RoyalLibrary.Services.Concretes
{
    public class BaseService<TMDL>(IBaseRepository<TMDL> repository, IUnitOfWork unitOfWork) : IBaseService<TMDL> where TMDL : class
    {
        protected readonly IBaseRepository<TMDL> Repository = repository;
        protected readonly IUnitOfWork UnitOfWork = unitOfWork;
    }
}
