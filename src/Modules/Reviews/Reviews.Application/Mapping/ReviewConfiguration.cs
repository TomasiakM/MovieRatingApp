using Mapster;
using Reviews.Application.Dtos.Reviews.Requests;
using Reviews.Application.Dtos.Reviews.Responses;
using Reviews.Application.Features.Reviews.Commands.Create;
using Reviews.Application.Features.Reviews.Commands.Update;
using Reviews.Domain.Aggregates.Reviews;

namespace Reviews.Application.Mapping;
internal class ReviewConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(Guid resourceId, CreateReviewRequest request), CreateReviewCommand>()
            .Map(dest => dest.ResourceId, src => src.resourceId)
            .Map(dest => dest, src => src.request);

        config.NewConfig<(Guid reviewId, UpdateReviewRequest request), UpdateReviewCommand>()
            .Map(dest => dest.ReviewId, src => src.reviewId)
            .Map(dest => dest, src => src.request);

        config.NewConfig<Review, ReviewResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Text, src => src.ReviewContent.Value)
            .Map(dest => dest.Rating, src => src.Rating.Value);
    }
}
