using MediatR;
using Reviews.Application.Interfaces;
using Reviews.Domain.Aggregates.Reviews;
using Reviews.Domain.Aggregates.Reviews.ValueObjects;

namespace Reviews.Application.Features.Reviews.Commands.Create;
internal class CreateReviewCommmandHandler : IRequestHandler<CreateReviewCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateReviewCommmandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var userId = Guid.NewGuid();

        var review = new Review(
            userId,
            request.ResourceId,
            new ReviewContent(request.Text),
            new Rating(request.Rating));

        _unitOfWork.Reviews.Add(review);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
