using System.Linq.Expressions;

namespace Common.Domain.Interfaces;
public interface IRepository<TEntity>
    where TEntity : IAggregateRoot
{
    Task<TEntity?> GetAsync(object id);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression);

    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression);

    void Add(TEntity entity);
    void Add(IEnumerable<TEntity> entities);

    void Update(TEntity entity);
    void Update(IEnumerable<TEntity> entities);

    void Delete(TEntity entity);
    void Delete(IEnumerable<TEntity> entities);
}
