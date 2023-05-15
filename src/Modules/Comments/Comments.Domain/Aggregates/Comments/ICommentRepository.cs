using Comments.Domain.Aggregates.Comments.ValueObjects;
using Common.Domain.Interfaces;

namespace Comments.Domain.Aggregates.Comments;
public interface ICommentRepository : IRepository<Comment>
{
}
