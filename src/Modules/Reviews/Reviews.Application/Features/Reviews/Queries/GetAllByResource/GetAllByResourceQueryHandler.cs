using MediatR;
using Reviews.Application.Interfaces;
using Reviews.Domain.Aggregates.Reviews;

namespace Reviews.Application.Features.Reviews.Queries.GetAllByResource;
internal class GetAllByResourceQueryHandler : IRequestHandler<GetAllByResourceQuery, ICollection<Review>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllByResourceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ICollection<Review>> Handle(GetAllByResourceQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Reviews
            .FindAllAsync(e => e.ResourceId == request.ResourceId);
    }
}
