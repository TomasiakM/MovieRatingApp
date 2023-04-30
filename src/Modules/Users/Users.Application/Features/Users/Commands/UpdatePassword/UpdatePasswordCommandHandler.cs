using Common.Application.Interfaces;
using Common.Domain.Exceptions;
using MediatR;
using Users.Application.Interfaces;
using Users.Domain.Aggregates.Users.ValueObjects;
using Users.Domain.Interfaces;

namespace Users.Application.Features.Users.Commands.UpdatePassword;
internal class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHashService _hashService;
    private readonly IAuthenticationService _authenticationService;

    public UpdatePasswordCommandHandler(IUnitOfWork unitOfWork, IHashService hashService, IAuthenticationService authorizationService)
    {
        _unitOfWork = unitOfWork;
        _hashService = hashService;
        _authenticationService = authorizationService;
    }

    public async Task Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        var userId = new UserId(_authenticationService.GetUserId());
        var user = await _unitOfWork.Users.GetAsync(userId);

        if (user is null || !_hashService.VerifyPassword(request.Password, user.Password))
        {
            throw new UnauthorizedException();
        }

        var hashedPassword = _hashService.HashPassword(request.NewPassword);
        user.UpdatePassword(hashedPassword);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
