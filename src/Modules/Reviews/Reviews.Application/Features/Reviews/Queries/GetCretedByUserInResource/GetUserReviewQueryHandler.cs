using Common.Domain.Exceptions;
using MediatR;
using Reviews.Application.Interfaces;
using Reviews.Domain.Aggregates.Reviews;

namespace Reviews.Application.Features.Reviews.Queries.GetCretedByUserInResource;
internal class GetCretedByUserInResourceQueryHandler : IRequestHandler<GetCretedByUserInResourceQuery, Review>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCretedByUserInResourceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Review> Handle(GetCretedByUserInResourceQuery request, CancellationToken cancellationToken)
    {
        var userId = Guid.NewGuid();

        var review = await _unitOfWork.Reviews
            .FindAsync(e => e.CreatorId == userId && e.ResourceId == request.ResourceId);

        if(review is null) 
        {
            throw new NotFoundException();
        }

        return review;
    }
}
