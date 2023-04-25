namespace Users.Application.Dtos.User.Responses;

public record AuthenticationResponse(
    string UserName,
    string Image,
    string Role,
    string AccessToken);
