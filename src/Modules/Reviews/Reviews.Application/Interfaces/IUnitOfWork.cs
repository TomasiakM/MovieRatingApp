using Common.Application.Interfaces;
using Reviews.Domain.Aggregates.Reviews;

namespace Reviews.Application.Interfaces;
public interface IUnitOfWork : IBaseUnitOfWork
{
    IReviewRepository Reviews { get; }
}
