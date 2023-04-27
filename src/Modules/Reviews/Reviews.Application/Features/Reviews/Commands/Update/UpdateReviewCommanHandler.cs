using Common.Domain.Exceptions;
using MediatR;
using Reviews.Application.Interfaces;
using Reviews.Domain.Aggregates.Reviews.ValueObjects;

namespace Reviews.Application.Features.Reviews.Commands.Update;
internal class UpdateReviewCommanHandler : IRequestHandler<UpdateReviewCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReviewCommanHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var reviewId = new ReviewId(request.ReviewId);
        var review = await _unitOfWork.Reviews.GetAsync(reviewId);

        if(review is null)
        {
            throw new NotFoundException();
        }

        var userId = Guid.NewGuid();
        review.Update(
            userId,
            new ReviewContent(request.Text),
            new Rating(request.Rating));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
