using CjDinner.Application.Common.Interfaces.Services;

namespace CjDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}