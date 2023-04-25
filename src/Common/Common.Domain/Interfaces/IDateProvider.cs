namespace Common.Domain.Interfaces;
public interface IDateProvider
{
    public DateTimeOffset UtcNow { get; }
}
