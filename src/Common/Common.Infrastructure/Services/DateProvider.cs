using Common.Domain.Interfaces;

namespace Common.Infrastructure.Services;
public sealed class DateProvider : IDateProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
