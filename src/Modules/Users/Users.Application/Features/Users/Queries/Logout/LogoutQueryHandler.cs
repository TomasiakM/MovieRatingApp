using MediatR;
using Users.Application.Interfaces;

namespace Users.Application.Features.Users.Queries.Logout;
internal class LogoutQueryHandler : IRequestHandler<LogoutQuery>
{
    private readonly IIdentityService _identityService;

    public LogoutQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task Handle(LogoutQuery request, CancellationToken cancellationToken)
    {
        await _identityService.Logout();
    }
}
