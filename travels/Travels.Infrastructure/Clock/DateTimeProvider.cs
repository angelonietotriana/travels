using Travels.Application.Abstractions.Clock;

namespace Travels.Infrastructure.Clock
{

    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime currentTime => DateTime.UtcNow;
    }
}