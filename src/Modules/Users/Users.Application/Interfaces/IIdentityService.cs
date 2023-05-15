using Users.Application.Dtos.User.Responses;
using Users.Domain.Aggregates.Users;

namespace Users.Application.Interfaces;
public interface IIdentityService
{
    Task<AuthenticationResponse> Login(string userName, string password, CancellationToken cancellationToken = default);
    Task Register(string userName, string password, string email, CancellationToken cancellationToken = default);
    AuthenticationResponse GenerateAuthenticationResponse(User user);
    Task Logout();
}
