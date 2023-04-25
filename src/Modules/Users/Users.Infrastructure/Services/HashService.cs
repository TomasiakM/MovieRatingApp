using Users.Domain.Interfaces;

namespace Users.Infrastructure.Services;
public sealed class HashService : IHashService
{
    private const int Salt = 12;

    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, Salt);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
