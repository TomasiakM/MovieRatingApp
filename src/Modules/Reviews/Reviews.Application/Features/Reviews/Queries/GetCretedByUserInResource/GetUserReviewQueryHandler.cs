using Common.Application.Interfaces;
using Common.Domain.Exceptions;
using MediatR;
using Reviews.Application.Interfaces;
using Reviews.Domain.Aggregates.Reviews;

namespace Reviews.Application.Features.Reviews.Queries.GetCretedByUserInResource;
internal class GetCretedByUserInResourceQueryHandler : IRequestHandler<GetCretedByUserInResourceQuery, Review>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;

    public GetCretedByUserInResourceQueryHandler(IUnitOfWork unitOfWork, IAuthenticationService authorizationService)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authorizationService;
    }

    public async Task<Review> Handle(GetCretedByUserInResourceQuery request, CancellationToken cancellationToken)
    {
        var userId = _authenticationService.GetUserId();

        var review = await _unitOfWork.Reviews
            .FindAsync(e => e.CreatorId == userId && e.ResourceId == request.ResourceId);

        if(review is null) 
        {
            throw new NotFoundException();
        }

        return review;
    }
}
