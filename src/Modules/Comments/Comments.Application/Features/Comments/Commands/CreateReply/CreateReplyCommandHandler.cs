using Comments.Application.Interfaces;
using Comments.Domain.Aggregates.Comments.ValueObjects;
using Common.Application.Interfaces;
using Common.Domain.Exceptions;
using Common.Domain.Interfaces;
using MediatR;

namespace Comments.Application.Features.Comments.Commands.CreateReply;
internal class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateProvider _dateProvider;
    private readonly IAuthenticationService _authenticationService;

    public CreateReplyCommandHandler(IUnitOfWork unitOfWork, IDateProvider dateProvider, IAuthenticationService authorizationService)
    {
        _unitOfWork = unitOfWork;
        _dateProvider = dateProvider;
        _authenticationService = authorizationService;
    }

    public async Task Handle(CreateReplyCommand request, CancellationToken cancellationToken)
    {
        var comment = await _unitOfWork.Comments.GetAsync(request.CommentId);

        if (comment is null)
        {
            throw new NotFoundException();
        }

        comment.AddReply(
            _authenticationService.GetUserId(),
            new CommentContent(request.Content),
            _dateProvider);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
