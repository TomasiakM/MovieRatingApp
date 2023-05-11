using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reviews.Application.Dtos.Reviews.Requests;
using Reviews.Application.Features.Reviews.Commands.Create;
using Reviews.Application.Features.Reviews.Commands.Delete;
using Reviews.Application.Features.Reviews.Commands.Update;
using Reviews.Application.Features.Reviews.Queries.GetAllByResource;
using Reviews.Application.Features.Reviews.Queries.GetCretedByUserInResource;

namespace Reviews.Api.Controllers;

[ApiController]
[Route("/api/review")]
public class ReviewController : ControllerBase
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;

    public ReviewController(ISender mediatr, IMapper mapper)
    {
        _mediatr = mediatr;
        _mapper = mapper;
    }

    [HttpGet("{resourceId}")]
    public async Task<IActionResult> GetByResource(Guid resourceId)
    {
        var query = new GetAllByResourceQuery(resourceId);
        var reviews = await _mediatr.Send(query);

        return Ok(reviews);
    }

    [HttpGet("user/{resourceId}")]
    public async Task<IActionResult> GetUserReview(Guid resourceId)
    {
        var query = new GetCretedByUserInResourceQuery(resourceId);
        var review = await _mediatr.Send(query);

        return Ok(review);
    }

    [HttpPost("{resourceId}")]
    public async Task<IActionResult> Create(Guid resourceId, CreateReviewRequest request)
    {
        var command = _mapper.Map<CreateReviewCommand>((resourceId, request));
        await _mediatr.Send(command);

        return NoContent();
    }

    [HttpPut("{reviewId}")]
    public async Task<IActionResult> Update(Guid reviewId, UpdateReviewRequest request)
    {
        var command = _mapper.Map<UpdateReviewCommand>((reviewId, request));
        await _mediatr.Send(command);

        return NoContent();
    }

    [HttpDelete("{reviewId}")]
    public async Task<IActionResult> Delete(Guid reviewId)
    {
        var command = new DeleteReviewCommand(reviewId);
        await _mediatr.Send(command);

        return NoContent();
    }
}
