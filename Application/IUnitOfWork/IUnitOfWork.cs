using Application.IGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Application.IUnitOfWork;

public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
{
    TContext Context { get; }

    IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

    int Commit();
    Task<int> CommitAsync();
}
