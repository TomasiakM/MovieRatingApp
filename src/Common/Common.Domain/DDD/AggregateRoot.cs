using Common.Domain.Interfaces;

namespace Common.Domain.DDD;
public abstract class AggregateRoot : Entity<Guid>, IAggregateRoot
{
    protected AggregateRoot(Guid id)
        : base(id)
    {
    }
}