using System.Linq.Expressions;
using Domain.Core.Entities;
using Domain.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Core.Repository;

public class BaseRepository : IBaseRepository
{
    private readonly DbContext Context;

    public BaseRepository(DbContext context)
    {
        Context = context;
    }

    public async Task BeginTransactionAsync()
    {
        if (Context.Database.CurrentTransaction != null)
            return;
        await Context.Database.BeginTransactionAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await Context.Database.CommitTransactionAsync();
    }

    public async Task RollBackTransactionAsync()
    {
        await Context.Database.RollbackTransactionAsync();
    }

    public async Task AddAsync<T>(Entity<T> entity)
    {
        entity.SetDateInc(DateTimeOffset.UtcNow);
        entity.SetDateAlter(DateTimeOffset.UtcNow);

        await Context.AddAsync(entity);
    }

    public void Update<T>(Entity<T> entity)
    {
        entity.SetDateAlter(DateTimeOffset.UtcNow);
        Context.Update(entity);
    }

    public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate, bool? track = true, 
        params Expression<Func<T, object>>[]? include) where T : Entity<T>
    {
        IQueryable<T> query = Context.Set<T>();

        if (!track.HasValue || track.Value)
        {
            query = query.AsTracking();
        }
        else
        {
            query = query.AsNoTracking();
        }

        if (include != null)
        {
            query = include.Aggregate(query, (current, expression) => current.Include(expression));
        }

        return await query.Where(predicate).ToListAsync();
    }
}