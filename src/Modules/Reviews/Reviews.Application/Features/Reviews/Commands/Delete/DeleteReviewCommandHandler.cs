using Common.Domain.Exceptions;
using MediatR;
using Reviews.Application.Interfaces;
using Reviews.Domain.Aggregates.Reviews.ValueObjects;

namespace Reviews.Application.Features.Reviews.Commands.Delete;
internal class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReviewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var reviewId = new ReviewId(request.ReviewId);
        var review = await _unitOfWork.Reviews.GetAsync(reviewId);

        if (review is null)
        {
            throw new NotFoundException();
        }

        var userId = Guid.NewGuid();
        if (review.CreatorId != userId)
        {
            throw new ForbiddenException();
        }

        _unitOfWork.Reviews.Delete(review);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
