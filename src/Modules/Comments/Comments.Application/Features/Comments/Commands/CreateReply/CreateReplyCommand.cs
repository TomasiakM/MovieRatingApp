using MediatR;

namespace Comments.Application.Features.Comments.Commands.CreateReply;
public record CreateReplyCommand(
    Guid CommentId,
    string Content) : IRequest;
