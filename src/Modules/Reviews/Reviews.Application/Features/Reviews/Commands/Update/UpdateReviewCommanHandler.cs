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
        var review = await _unitOfWork.Reviews.GetAsync(request.ReviewId);

        if(review is null)
        {
            throw new NotFoundException();
        }

        review.Update(
            _authenticationService.GetUserId(),
            new ReviewContent(request.Text),
            new Rating(request.Rating));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
