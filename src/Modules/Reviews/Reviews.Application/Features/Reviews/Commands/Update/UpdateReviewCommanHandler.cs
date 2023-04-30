using Common.Application.Interfaces;
using Common.Domain.Exceptions;
using MediatR;
using Reviews.Application.Interfaces;
using Reviews.Domain.Aggregates.Reviews.ValueObjects;

namespace Reviews.Application.Features.Reviews.Commands.Update;
internal class UpdateReviewCommanHandler : IRequestHandler<UpdateReviewCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;

    public UpdateReviewCommanHandler(IUnitOfWork unitOfWork, IAuthenticationService authorizationService)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authorizationService;
    }

    public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var reviewId = new ReviewId(request.ReviewId);
        var review = await _unitOfWork.Reviews.GetAsync(reviewId);

        if(review is null)
        {
            throw new NotFoundException();
        }

        var userId = _authenticationService.GetUserId();
        review.Update(
            userId,
            new ReviewContent(request.Text),
            new Rating(request.Rating));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
