using Common.Infrastructure.Persistance;
using Reviews.Domain.Aggregates.Reviews;

namespace Reviews.Infrastructure.Persistence.Repositories;
internal class ReviewRepository : Repository<Review>, IReviewRepository
{
    public ReviewRepository(ReviewDbContext dbContext) 
        : base(dbContext)
    {
    }
}
