using MediatR;
using Reviews.Application.Dtos.Reviews.Responses;

namespace Reviews.Application.Features.Reviews.Queries.GetAllByResource;
public record GetAllByResourceQuery(
    Guid ResourceId) : IRequest<ICollection<ReviewResponse>>;
