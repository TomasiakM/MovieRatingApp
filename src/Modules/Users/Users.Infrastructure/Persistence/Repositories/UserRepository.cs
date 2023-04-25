using Common.Infrastructure.Persistance;
using Users.Domain.Aggregates.Users;
using Users.Domain.Aggregates.Users.ValueObjects;

namespace Users.Infrastructure.Persistence.Repositories;
internal sealed class UserRepository : Repository<User, UserId>, IUserRepository
{
    public UserRepository(UserDbContext dbContext)
        : base(dbContext)
    {
    }
}
