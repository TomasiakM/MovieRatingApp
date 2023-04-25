namespace Users.Application.Dtos.User.Requests;
public record UpdatePasswordRequest(
    string Password,
    string NewPassword);
