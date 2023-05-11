using Common.Application.Interfaces;
using Common.Domain.Exceptions;
using MapsterMapper;
using MediatR;
using Reviews.Application.Dtos.Reviews.Responses;
using Reviews.Application.Interfaces;

namespace Reviews.Application.Features.Reviews.Queries.GetCretedByUserInResource;
internal class GetCretedByUserInResourceQueryHandler : IRequestHandler<GetCretedByUserInResourceQuery, ReviewResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public GetCretedByUserInResourceQueryHandler(IUnitOfWork unitOfWork, IAuthenticationService authorizationService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authorizationService;
        _mapper = mapper;
    }

    public async Task<ReviewResponse> Handle(GetCretedByUserInResourceQuery request, CancellationToken cancellationToken)
    {
        var userId = _authenticationService.GetUserId();

        var review = await _unitOfWork.Reviews
            .FindAsync(e => e.CreatorId == userId && e.ResourceId == request.ResourceId);

        if(review is null) 
        {
            throw new NotFoundException();
        }

        var reviewDto = _mapper.Map<ReviewResponse>(review);

        return reviewDto;
    }
}
