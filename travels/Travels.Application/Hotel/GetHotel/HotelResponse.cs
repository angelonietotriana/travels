namespace Travels.Application.Hotel.GetHotel
{

    public sealed class HotelResponse
    {
        public Guid Id { get; set; }
        public string BusinessName {  get; set; }
        public string Nit {  get; set; }
        public string City {  get; set; }
        public string Neighborhood {  get; set; }
        public string Zone {  get; set; }
        public string Numeration {  get; set; }    
        public int Capacity { get; set; }
        public int Starts { get; set; }
        public int State { get; set; }
        public DateOnly DateCreated { get; set; }

    }
}