using Common.Application.Interfaces;
using Common.Domain.Exceptions;
using MediatR;
using Users.Application.Dtos.User.Responses;
using Users.Application.Interfaces;

namespace Users.Application.Features.Users.Queries.RefreshToken;
internal class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQuery, AuthenticationResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IIdentityService _identityService;

    public RefreshTokenQueryHandler(IUnitOfWork unitOfWork, IAuthenticationService authenticationService, IIdentityService identityService)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _identityService = identityService;
    }

    public async Task<AuthenticationResponse> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetAsync(_authenticationService.GetUserId());

        if(user is null)
        {
            throw new UnauthorizedException();
        }

        return _identityService.GenerateAuthenticationResponse(user);
    }
}
