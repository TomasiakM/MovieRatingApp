using Reviews.Application.Interfaces;
using Reviews.Domain.Aggregates.Reviews;
using Reviews.Infrastructure.Persistence.Repositories;

namespace Reviews.Infrastructure.Persistence;
internal class UnitOfWork : IUnitOfWork
{
    private readonly ReviewDbContext _dbContext;
    public IReviewRepository Reviews { get; }

    public UnitOfWork(ReviewDbContext dbContext)
    {
        _dbContext = dbContext;

        Reviews = new ReviewRepository(_dbContext);
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
