using Comments.Domain.Aggregates.Comments;
using Common.Application.Interfaces;

namespace Comments.Application.Interfaces;
public interface IUnitOfWork : IBaseUnitOfWork
{
    ICommentRepository Comments { get; }
}
