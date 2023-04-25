using Comments.Application.Interfaces;
using Comments.Domain.Aggregates.Comments;
using Comments.Domain.Aggregates.Comments.ValueObjects;
using Comments.Domain.Aggregates.Creators.ValueObjects;
using Comments.Domain.Aggregates.Resources.ValueObjects;
using Common.Domain.Interfaces;
using MediatR;

namespace Comments.Application.Features.Comments.Commands.Create;
internal class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateProvider _dateProvider;

    public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IDateProvider dateProvider)
    {
        _unitOfWork = unitOfWork;
        _dateProvider = dateProvider;
    }

    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var creatorId = new CreatorId(Guid.NewGuid());

        var comment = new Comment(
            creatorId,
            new ResourceId(request.ResourseId),
            new CommentContent(request.Content),
            _dateProvider);

        _unitOfWork.Comments.Add(comment);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
