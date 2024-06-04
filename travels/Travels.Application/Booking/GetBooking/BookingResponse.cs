namespace Travels.Application.Booking.GetBooking
{

    public sealed class BookingResponse
    {
        public Guid Id { get; init; }
        public Guid UserIdBooking { get; init; }
        public Guid UserIdVendor { get; init; }

        public Guid RoomId { get; init; }

        public int Status { get; init; }

        public decimal BookingPrice { get; init; }

        public string? CurrencyType { get; init; }

        public decimal MaintenancePrice { get; init; }
        public string? MaintenanceCurrentyType { get; init; }

        public decimal FeaturesPrice { get; init; }
        public string? FeaturesCurrencyType { get; init; }
        
        public decimal TotalPrice { get; init; }
        public string? TotalPriceCurrencyType { get; init; }

        public DateOnly StartDuration { get; init; }
        public DateOnly EndDuration { get; init; }

        public DateTime CreationDate { get; init; }

    }
}