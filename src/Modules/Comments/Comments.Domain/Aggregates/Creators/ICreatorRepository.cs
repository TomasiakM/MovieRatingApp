using Comments.Domain.Aggregates.Creators.ValueObjects;
using Common.Domain.Interfaces;

namespace Comments.Domain.Aggregates.Creators;
public interface ICreatorRepository : IRepository<Creator, CreatorId>
{
}
