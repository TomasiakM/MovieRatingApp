using Comments.Domain.Aggregates.Resources;
using Comments.Domain.Aggregates.Resources.ValueObjects;
using Common.Infrastructure.Persistance;

namespace Comments.Infrastructure.Persistence.Repositories;
internal sealed class ResourceRepository : Repository<Resource, ResourceId>, IResourceRepository
{
    public ResourceRepository(AppDbContext dbContext) 
        : base(dbContext)
    {
    }
}
