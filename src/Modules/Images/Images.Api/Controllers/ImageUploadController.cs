using Images.Api.Models;
using Images.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Images.Api.Controllers;
[ApiController]
[Route("/api/image")]
public class ImageUploadController : ControllerBase
{
    private readonly IUploadService _uploadService;

    public ImageUploadController(IUploadService uploadService)
    {
        _uploadService = uploadService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UploadImage(IFormFile image)
    {
        var res = await _uploadService.UploadImage(image);

        var responseDto = new UploadImageResponse(res);
        return Ok(responseDto);
    }
}
