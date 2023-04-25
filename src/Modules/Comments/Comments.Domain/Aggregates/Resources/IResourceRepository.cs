using Comments.Domain.Aggregates.Resources.ValueObjects;
using Common.Domain.Interfaces;

namespace Comments.Domain.Aggregates.Resources;
public interface IResourceRepository : IRepository<Resource, ResourceId>
{
}
