using Common.Domain.Interfaces;
using Reviews.Domain.Aggregates.Reviews.ValueObjects;

namespace Reviews.Domain.Aggregates.Reviews;
public interface IReviewRepository : IRepository<Review, ReviewId>
{
}
