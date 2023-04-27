namespace Reviews.Application.Dtos.Reviews.Requests;
public record UpdateReviewRequest(
    string Text,
    int Rating);
