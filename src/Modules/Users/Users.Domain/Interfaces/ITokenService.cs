using Users.Domain.Aggregates.Users;

namespace Users.Domain.Interfaces;
public interface ITokenService
{
    string GenerateAccessToken(User user);
}
