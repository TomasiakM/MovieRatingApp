using MediatR;

namespace Reviews.Application.Features.Reviews.Commands.Delete;
public record DeleteReviewCommand(
    Guid ReviewId) : IRequest;
