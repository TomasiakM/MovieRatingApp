using Comments.Application.Interfaces;
using Comments.Domain.Aggregates.Comments;
using Comments.Infrastructure.Persistence.Repositories;

namespace Comments.Infrastructure.Persistence;
internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly CommentDbContext _dbContext;

    public ICommentRepository Comments { get; }

    public UnitOfWork(CommentDbContext dbContext)
    {
        _dbContext = dbContext;

        Comments = new CommentRepository(_dbContext);
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
