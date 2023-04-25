using Comments.Domain.Aggregates.Creators.ValueObjects;
using Common.Domain.DDD;

namespace Comments.Domain.Aggregates.Creators;
public sealed class Creator : AggregateRoot<CreatorId>
{
    public string UserName { get; private set; }
    public string Image { get; private set; }

    public Creator(CreatorId creatorId, string userName, string image) 
        : base(creatorId)
    {
        UserName = userName;
        Image = image;
    }

    public Creator() : base(new CreatorId(Guid.Empty)) { }
}
