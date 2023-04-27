using MediatR;
using Reviews.Domain.Aggregates.Reviews;

namespace Reviews.Application.Features.Reviews.Queries.GetAllByResource;
public record GetAllByResourceQuery(
    Guid ResourceId) : IRequest<ICollection<Review>>;
