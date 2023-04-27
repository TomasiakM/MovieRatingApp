using Common.Infrastructure.Persistance;
using Reviews.Domain.Aggregates.Reviews;
using Reviews.Domain.Aggregates.Reviews.ValueObjects;

namespace Reviews.Infrastructure.Persistence.Repositories;
internal class ReviewRepository : Repository<Review, ReviewId>, IReviewRepository
{
    public ReviewRepository(ReviewDbContext dbContext) 
        : base(dbContext)
    {
    }
}
