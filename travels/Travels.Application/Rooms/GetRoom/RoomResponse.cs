namespace Travels.Application.Rooms.GetRoom
{

    public sealed class RoomResponse
    {
        public Guid Id { get; set; }
        public int LocalizationFloor {  get; set; }
        public int LocalizationView {  get; set; }
        public int NumberOfBeds { get; set; }
        public int Capacity { get; set; }
        public string Features { get; set; }
        public int RoomType { get; set; }
        public decimal PricePerPeriod { get; set; }
        public decimal Maintenance { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal FeaturesPrice { get; set; }
        public decimal Price { get; set; }

    }
}