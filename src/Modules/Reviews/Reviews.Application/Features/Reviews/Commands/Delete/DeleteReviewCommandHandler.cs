using Common.Application.Interfaces;
using Common.Domain.Exceptions;
using MediatR;
using Reviews.Application.Interfaces;
using Reviews.Domain.Aggregates.Reviews.ValueObjects;

namespace Reviews.Application.Features.Reviews.Commands.Delete;
internal class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;

    public DeleteReviewCommandHandler(IUnitOfWork unitOfWork, IAuthenticationService authorizationService)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authorizationService;
    }

    public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _unitOfWork.Reviews.GetAsync(request.ReviewId);

        if (review is null)
        {
            throw new NotFoundException();
        }

        var userId = _authenticationService.GetUserId();
        if (review.CreatorId != userId)
        {
            throw new ForbiddenException();
        }

        _unitOfWork.Reviews.Delete(review);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
