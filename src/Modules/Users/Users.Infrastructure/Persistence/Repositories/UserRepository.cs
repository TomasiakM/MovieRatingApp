using Common.Infrastructure.Persistance;
using Users.Domain.Aggregates.Users;

namespace Users.Infrastructure.Persistence.Repositories;
internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(UserDbContext dbContext)
        : base(dbContext)
    {
    }
}
