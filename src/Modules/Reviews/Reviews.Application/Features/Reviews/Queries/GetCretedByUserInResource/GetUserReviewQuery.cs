using MediatR;
using Reviews.Domain.Aggregates.Reviews;

namespace Reviews.Application.Features.Reviews.Queries.GetCretedByUserInResource;
public record GetCretedByUserInResourceQuery(
    Guid ResourceId): IRequest<Review>;
