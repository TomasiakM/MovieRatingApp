namespace Users.Infrastructure.Settings;
public class JwtSettings
{
    public string Issuer { get; set; } = null!;
    public string Secret { get; set; } = null!;
    public int ExpiryMinutes { get; set; }
}
