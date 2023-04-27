using MediatR;

namespace Reviews.Application.Features.Reviews.Commands.Create;
public record CreateReviewCommand(
    Guid ResourceId,
    string Text,
    int Rating) : IRequest;
