using Comments.Application.Interfaces;
using Comments.Domain.Aggregates.Comments;
using Comments.Domain.Aggregates.Resources.ValueObjects;
using MediatR;

namespace Comments.Application.Features.Comments.Queries.GetAllByResource;
internal class GetAllByResourceQueryHandler : IRequestHandler<GetAllByResourceQuery, ICollection<Comment>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllByResourceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ICollection<Comment>> Handle(GetAllByResourceQuery request, CancellationToken cancellationToken)
    {
        var resourceId = new ResourceId(request.ResourceId);

        return await _unitOfWork.Comments.FindAllAsync(e => e.ResourceId == resourceId);
    }
}
