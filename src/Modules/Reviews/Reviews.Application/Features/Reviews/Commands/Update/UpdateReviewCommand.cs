using MediatR;

namespace Reviews.Application.Features.Reviews.Commands.Update;
public record UpdateReviewCommand(
    Guid ReviewId,
    string Text,
    int Rating) : IRequest;
