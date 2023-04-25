using Comments.Domain.Aggregates.Resources.ValueObjects;
using Common.Domain.DDD;

namespace Comments.Domain.Aggregates.Resources;
public sealed class Resource : AggregateRoot<ResourceId>
{
    public Resource(ResourceId resourceId)
        : base(resourceId)
    {
    }

    public Resource() : base(new ResourceId(Guid.Empty)) { }
}
