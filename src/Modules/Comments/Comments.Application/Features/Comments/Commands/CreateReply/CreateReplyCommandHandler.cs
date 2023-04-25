using Comments.Application.Interfaces;
using Comments.Domain.Aggregates.Comments.ValueObjects;
using Comments.Domain.Aggregates.Creators.ValueObjects;
using Common.Domain.Exceptions;
using Common.Domain.Interfaces;
using MediatR;

namespace Comments.Application.Features.Comments.Commands.CreateReply;
internal class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateProvider _dateProvider;

    public CreateReplyCommandHandler(IUnitOfWork unitOfWork, IDateProvider dateProvider)
    {
        _unitOfWork = unitOfWork;
        _dateProvider = dateProvider;
    }

    public async Task Handle(CreateReplyCommand request, CancellationToken cancellationToken)
    {
        var commentId = new CommentId(request.CommentId);
        var comment = await _unitOfWork.Comments.GetAsync(commentId);

        if (comment is null)
        {
            throw new NotFoundException();
        }

        var creatorId = new CreatorId(new Guid());

        comment.AddReply(
            creatorId,
            new CommentContent(request.Content),
            _dateProvider);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
