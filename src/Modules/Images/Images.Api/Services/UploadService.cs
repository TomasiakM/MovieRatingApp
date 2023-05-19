using Images.Api.Models;

namespace Images.Api.Services;

public class UploadService : IUploadService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    public UploadService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> UploadImage(IFormFile file)
    {
        var uploadUrl = _configuration.GetSection("Urls")["ImageUpload"]!;

        var ms = new MemoryStream();
        file.CopyTo(ms);

        var fileBytes = ms.ToArray();
        var b64 = Convert.ToBase64String(fileBytes);

        var content = new MultipartFormDataContent
        {
            { new StringContent(b64), "image" }
        };

        var client = _httpClientFactory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Post, uploadUrl) { Content = content };
        var response = await client.SendAsync(request);

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception();
        }

        var res = await response.Content.ReadFromJsonAsync<ImgBBResponse>();

        var url = res!.Data.Url;
        return url;
    }
}
