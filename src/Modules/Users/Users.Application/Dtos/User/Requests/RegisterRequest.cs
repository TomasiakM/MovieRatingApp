namespace Users.Application.Dtos.User.Requests;

public record RegisterRequest(
        string UserName,
        string Password,
        string Email);
