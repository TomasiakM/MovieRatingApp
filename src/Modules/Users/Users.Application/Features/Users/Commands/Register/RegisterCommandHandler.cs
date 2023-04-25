using MediatR;
using Users.Application.Interfaces;
using Users.Domain.Aggregates.Users;

namespace Users.Application.Features.Users.Commands.Register;
internal class RegisterCommandHandler : IRequestHandler<RegisterCommand>
{
    private readonly IIdentityService _identityService;

    public RegisterCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _identityService
            .Register(request.UserName, request.Password, request.Email, cancellationToken);
    }
}
