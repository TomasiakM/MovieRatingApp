using Comments.Application.Interfaces;
using Comments.Domain.Aggregates.Comments;
using Comments.Domain.Aggregates.Comments.ValueObjects;
using Common.Application.Interfaces;
using Common.Domain.Interfaces;
using MediatR;

namespace Comments.Application.Features.Comments.Commands.Create;
internal class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateProvider _dateProvider;
    private readonly IAuthenticationService _authenticationService;

    public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IDateProvider dateProvider, IAuthenticationService authorizationService)
    {
        _unitOfWork = unitOfWork;
        _dateProvider = dateProvider;
        _authenticationService = authorizationService;
    }

    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {

        var comment = new Comment(
            _authenticationService.GetUserId(),
            request.ResourseId,
            new CommentContent(request.Content),
            _dateProvider);

        _unitOfWork.Comments.Add(comment);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
