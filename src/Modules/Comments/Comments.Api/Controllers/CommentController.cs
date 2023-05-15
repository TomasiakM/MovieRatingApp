using Comments.Application.Dtos.Comment.Requests;
using Comments.Application.Features.Comments.Commands.Create;
using Comments.Application.Features.Comments.Commands.CreateReply;
using Comments.Application.Features.Comments.Queries.GetAllByResource;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Comments.Api.Controllers;
[Route("api/comment")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public CommentController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{resourceId}")]
    public async Task<IActionResult> GetComments(Guid resourceId)
    {
        var query = new GetAllByResourceQuery(resourceId);
        var comments = await _mediator.Send(query);

        return Ok(comments);
    }

    [HttpPost("{resourceId}")]
    [Authorize]
    public async Task<IActionResult> CreateComment(Guid resourceId, CreateCommentRequest request)
    {
        var command = _mapper.Map<CreateCommentCommand>((resourceId, request));
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPost("{commentId}/reply")]
    [Authorize]
    public async Task<IActionResult> CreateReply(Guid commentId, CreateReplyRequest request)
    {
        var command = _mapper.Map<CreateReplyCommand>((commentId, request));
        await _mediator.Send(command);

        return NoContent();
    }
}
