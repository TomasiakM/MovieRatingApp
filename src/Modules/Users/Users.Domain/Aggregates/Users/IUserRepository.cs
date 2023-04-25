using Common.Domain.Interfaces;
using Users.Domain.Aggregates.Users.ValueObjects;

namespace Users.Domain.Aggregates.Users;
public interface IUserRepository : IRepository<User, UserId>
{
}
