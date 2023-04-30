namespace Common.Application.Interfaces;
public interface IAuthenticationService
{
    bool IsAuthorized { get; }
    Guid GetUserId();
}
