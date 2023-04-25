namespace Users.Application.Dtos.User.Requests;

public record LoginRequest(
    string UserName,
    string Password);
