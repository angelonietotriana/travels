
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travels.Domain.Hotels;
using Travels.Domain.HotelsRooms;
using Travels.Domain.Rooms;

namespace CleanArchitecture.Infrastructure.Configurations
{

    internal sealed class HotelsRoomsConfiguration : IEntityTypeConfiguration<HotelsRoomsEntity>
    {
        public void Configure(EntityTypeBuilder<HotelsRoomsEntity> builder)
        {
            builder.ToTable("hotels_rooms");

            builder.HasKey(hotelRooms => hotelRooms.Id);

            builder.HasOne<RoomEntity>()
                .WithMany()
                .HasForeignKey(room => room.RoomId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne<HotelEntity>()
                .WithMany()
                .HasForeignKey(hotel => hotel.HotelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.OwnsOne(hotelsRooms => hotelsRooms.IsActive);


        }
    }
}