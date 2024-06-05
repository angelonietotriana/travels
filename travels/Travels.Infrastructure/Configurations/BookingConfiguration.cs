using Travels.Domain.Bookings;
using Travels.Domain.Shared;
using Travels.Domain.Users;
using Travels.Domain.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travels.Domain.Hotels;

namespace CleanArchitecture.Infrastructure.Configurations;

internal sealed class BookingConfiguration : IEntityTypeConfiguration<BookingEntity>
{
    public void Configure(EntityTypeBuilder<BookingEntity> builder)
    {
        builder.ToTable("bookings");
        builder.HasKey(bookingEntity => bookingEntity.Id);

        builder.HasOne<RoomEntity>()
            .WithMany()
            .HasForeignKey(bookingEntity => bookingEntity.RoomId);

        builder.HasOne<HotelEntity>()
            .WithMany()
            .HasForeignKey(bookingEntity => bookingEntity.HotelId);

        builder.HasOne<UserEntity>()
            .WithMany()
            .HasForeignKey(bookingEntity => bookingEntity.UserIdBooking);

        builder.OwnsOne(bookingEntity => bookingEntity.Duration);

    }
}