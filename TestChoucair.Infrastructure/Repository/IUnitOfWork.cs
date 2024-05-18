using TestChoucair.Infrastructure.Repository;
using TestChoucair.Domain.Model;

namespace TestChoucair.Infrastructure.Repository {

    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : class
    {
        IBaseRepository<TEntity> Repository { get; }
        Task<int> SaveChangesAsync();
    }
}
