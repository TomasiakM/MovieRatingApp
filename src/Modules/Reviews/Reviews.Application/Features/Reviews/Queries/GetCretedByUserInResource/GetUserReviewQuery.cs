using MediatR;
using Reviews.Application.Dtos.Reviews.Responses;

namespace Reviews.Application.Features.Reviews.Queries.GetCretedByUserInResource;
public record GetCretedByUserInResourceQuery(
    Guid ResourceId): IRequest<ReviewResponse>;
