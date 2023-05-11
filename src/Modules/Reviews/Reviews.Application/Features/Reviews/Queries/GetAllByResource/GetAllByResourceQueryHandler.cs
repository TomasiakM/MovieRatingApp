using MapsterMapper;
using MediatR;
using Reviews.Application.Dtos.Reviews.Responses;
using Reviews.Application.Interfaces;

namespace Reviews.Application.Features.Reviews.Queries.GetAllByResource;
internal class GetAllByResourceQueryHandler : IRequestHandler<GetAllByResourceQuery, ICollection<ReviewResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllByResourceQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ICollection<ReviewResponse>> Handle(GetAllByResourceQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _unitOfWork.Reviews
            .FindAllAsync(e => e.ResourceId == request.ResourceId);

        var reviewsDto = _mapper.Map<ICollection<ReviewResponse>>(reviews);

        return reviewsDto;
    }
}
