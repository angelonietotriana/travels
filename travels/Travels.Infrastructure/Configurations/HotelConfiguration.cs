
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travels.Domain.Hotels;

namespace CleanArchitecture.Infrastructure.Configurations
{

    internal sealed class HotelConfiguration : IEntityTypeConfiguration<HotelEntity>
    {
        public void Configure(EntityTypeBuilder<HotelEntity> builder)
        {
            builder.ToTable("hotels");

            builder.HasKey(hotel => hotel.Id);

            builder.OwnsOne(hotel => hotel.Business);
            builder.OwnsOne(hotel => hotel.Address);
            builder.OwnsOne(hotel => hotel.Capacity);


            builder.Property(hotel => hotel.Starts)
            .HasConversion(starts => starts!.Value, value => new Stars(value));


            builder.Property(hotel => hotel.Starts)
            .HasConversion(starts => starts!.Value, value => new Stars(value));


        }
    }
}