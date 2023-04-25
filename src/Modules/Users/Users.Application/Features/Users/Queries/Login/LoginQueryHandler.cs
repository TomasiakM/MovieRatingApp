using MediatR;
using Users.Application.Dtos.User.Responses;
using Users.Application.Interfaces;

namespace Users.Application.Features.Users.Queries.Login;
internal class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResponse>
{
    private readonly IIdentityService _identityService;

    public LoginQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<AuthenticationResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        return await _identityService
            .Login(request.UserName, request.Password, cancellationToken);
    }
}
