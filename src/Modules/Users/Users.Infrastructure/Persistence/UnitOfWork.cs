using Users.Application.Interfaces;
using Users.Domain.Aggregates.Users;
using Users.Infrastructure.Persistence.Repositories;

namespace Users.Infrastructure.Persistence;
internal class UnitOfWork : IUnitOfWork
{
    private readonly UserDbContext _dbContext;

    public IUserRepository Users { get; }

    public UnitOfWork(UserDbContext dbContext)
    {
        _dbContext = dbContext;

        Users = new UserRepository(_dbContext);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
