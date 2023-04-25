using Users.Application.Dtos.User.Responses;

namespace Users.Application.Interfaces;
public interface IIdentityService
{
    Task<AuthenticationResponse> Login(string userName, string password, CancellationToken cancellationToken = default);
    Task Register(string userName, string password, string email, CancellationToken cancellationToken = default);
}
