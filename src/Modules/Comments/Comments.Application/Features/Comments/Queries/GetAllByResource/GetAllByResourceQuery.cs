using Comments.Domain.Aggregates.Comments;
using MediatR;

namespace Comments.Application.Features.Comments.Queries.GetAllByResource;
public record GetAllByResourceQuery(
    Guid ResourceId) : IRequest<ICollection<Comment>>;
