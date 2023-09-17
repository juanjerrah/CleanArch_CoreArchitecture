using System.Linq.Expressions;
using Domain.Core.Entities;

namespace Domain.Core.Interfaces;

public interface IBaseRepository
{
    Task BeginTransactionAsync();
    Task<int> SaveChangesAsync();
    Task CommitTransactionAsync();
    Task RollBackTransactionAsync();
    Task AddAsync<T>(Entity<T> entity);
    void Update<T>(Entity<T> entity);
    Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate, bool? track = true,
        params Expression<Func<T, object>>[]? include) where T : Entity<T>;
}