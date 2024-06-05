namespace Travels.Domain.Hotels
{
    public interface IHotelRepository
    {
        Task<HotelEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Add(HotelEntity hotel);

        void Update(HotelEntity hotel); 
    }
}

