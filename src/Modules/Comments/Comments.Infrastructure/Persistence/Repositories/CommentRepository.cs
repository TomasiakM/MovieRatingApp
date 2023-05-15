using Comments.Domain.Aggregates.Comments;
using Comments.Domain.Aggregates.Comments.ValueObjects;
using Common.Infrastructure.Persistance;

namespace Comments.Infrastructure.Persistence.Repositories;
internal sealed class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(AppDbContext dbContext) 
        : base(dbContext)
    {
    }
}
