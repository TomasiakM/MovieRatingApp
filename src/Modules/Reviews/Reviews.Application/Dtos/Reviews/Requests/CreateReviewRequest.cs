namespace Reviews.Application.Dtos.Reviews.Requests;
public record CreateReviewRequest(
    string Text,
    int Rating);
