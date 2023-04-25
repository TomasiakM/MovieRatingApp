using MediatR;

namespace Comments.Application.Features.Comments.Commands.Create;
public record CreateCommentCommand(
    Guid ResourseId,
    string Content) : IRequest;
