using Comments.Domain.Aggregates.Creators;
using Comments.Domain.Aggregates.Creators.ValueObjects;
using Common.Infrastructure.Persistance;

namespace Comments.Infrastructure.Persistence.Repositories;
internal sealed class CreatorRepository : Repository<Creator, CreatorId>, ICreatorRepository
{
    public CreatorRepository(AppDbContext dbContext) 
        : base(dbContext)
    {
    }
}
