using Common.Domain.DDD;
using Common.Domain.Exceptions;
using Reviews.Domain.Aggregates.Reviews.ValueObjects;

namespace Reviews.Domain.Aggregates.Reviews;

public sealed class Review : AggregateRoot<ReviewId>
{
    public Guid CreatorId { get; private set; }
    public Guid ResourceId { get; private set; }
    public ReviewContent ReviewContent { get; private set; }
    public Rating Rating { get; private set; }

    public Review(Guid creatorId, Guid resourceId, ReviewContent reviewContent, Rating rating) 
        : base(new ReviewId()) 
    { 
        CreatorId = creatorId;
        ResourceId = resourceId;
        ReviewContent = reviewContent;
        Rating = rating;
    }

    public void Update(Guid userId, ReviewContent reviewContent, Rating rating)
    {
        if(userId != CreatorId)
        {
            throw new ForbiddenException();
        }

        ReviewContent = reviewContent;
        Rating = rating;
    }

    private Review() : base(new ReviewId()) { }
}