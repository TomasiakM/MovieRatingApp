using Common.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Common.Infrastructure.Persistance;
public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IAggregateRoot
{
    protected AppDbContext _dbContext;
    protected DbSet<TEntity> _dbSet;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<TEntity?> GetAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet
            .Where(expression)
            .FirstOrDefaultAsync();
    }
    
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet
            .Where(expression)
            .ToListAsync();
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void Add(IEnumerable<TEntity> entities)
    {
        _dbSet.AddRange(entities);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Update(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public void Delete(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}
