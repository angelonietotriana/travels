namespace Travels.Domain.Bookings
{
    public sealed record DateRange
    {
        private DateRange()
        {

        }

        public DateOnly Start { get; init; }
        public DateOnly End { get; init; }

        public int CantidadDias => End.DayNumber - Start.DayNumber;

        public static DateRange Create(DateOnly start, DateOnly end)
        {
            if (start > end)
            {
                throw new
                ApplicationException("La fecha final es anterior a la fecha de start");
            }

            return new DateRange
            {
                Start = start,
                End = end
            };

        }

    }

}