namespace Reviews.Application.Dtos.Reviews.Responses;
public record ReviewResponse(
    string Id,
    string CreatorId,
    string Text,
    int Rating);
