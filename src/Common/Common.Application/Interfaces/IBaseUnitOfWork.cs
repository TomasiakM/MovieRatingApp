namespace Common.Application.Interfaces;
public interface IBaseUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
