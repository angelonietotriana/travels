using Travels.Domain.Hotels;

namespace Travels.Application.Hotel.GetHotel
{

    public sealed class HotelResponse
    {
        Guid Id { get; set; }   
        string BusinessName {  get; set; }
        string Nit {  get; set; }
        string City {  get; set; }
        string Neighborhood {  get; set; }
        string Zone {  get; set; }
        string Numeration {  get; set; }    
        public int Capacity { get; set; }
        public int Starts { get; set; }
        public int State { get; set; }
        public DateOnly DateCreated { get; set; }

    }
}