namespace Images.Api.Services;

public interface IUploadService
{
    Task<string> UploadImage(IFormFile file);
}
