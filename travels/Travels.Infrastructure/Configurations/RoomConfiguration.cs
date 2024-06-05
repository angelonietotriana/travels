using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travels.Domain.Hotels;
using Travels.Domain.Rooms;
using Travels.Domain.Shared;
using Travels.Domain.Users;

namespace CleanArchitecture.Infrastructure.Configurations;

internal sealed class RoomConfiguration : IEntityTypeConfiguration<RoomEntity>
{
    public void Configure(EntityTypeBuilder<RoomEntity> builder)
    {

        builder.ToTable("rooms");
        builder.HasKey(room => room.Id);


        builder.Property(room => room.PricePerPeriod).HasConversion(price => price!.Amount, value => new Currency(value));

        builder.Property(room => room.Maintenance).HasConversion(price => price!.Amount, value => new Currency(value));

        builder.Property(room => room.FeaturesPrice).HasConversion(price => price!.Amount, value => new Currency(value));

        builder.Property(room => room.TotalPrice).HasConversion(price => price!.Amount, value => new Currency(value));

        builder.Property(room => room.Price).HasConversion(price => price!.Amount, value => new Currency(value));

        builder.OwnsOne(room => room.Localization);

        builder.Property(room => room.Capacity)
        .HasConversion(capacity => capacity!.value, value => new Capacity(value));

        builder.Property(room => room.NumberOfBeds)
        .HasConversion(beds => beds!.value, value => new NumberOfBeds(value));

    }
}