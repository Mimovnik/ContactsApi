using Contacts.Application.Interfaces.Services;

namespace Contacts.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}