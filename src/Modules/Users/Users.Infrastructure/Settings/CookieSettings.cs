namespace Users.Infrastructure.Settings;
public class CookieSettings
{
    public string Name { get; set; } = "DefaultCookieName";
    public int ExpiryDays { get; set; } = 30;
}
