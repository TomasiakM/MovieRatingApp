using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Common.Infrastructure.Converters;
public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter()
    : base(dateOnly =>
            dateOnly.ToDateTime(TimeOnly.MinValue),
        dateTime => DateOnly.FromDateTime(dateTime))
    { }

}
