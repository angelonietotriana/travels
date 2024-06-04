using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travels.Domain.Users;

namespace CleanArchitecture.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(
        EntityTypeBuilder<UserEntity> builder
        )
    {
        builder.ToTable("users");
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Nombre)
            .HasMaxLength(200)
            .HasConversion(nombre => nombre!.Value, value=> new Nombre(value));


        builder.Property(user => user.Apellido)
        .HasMaxLength(200)
        .HasConversion(apellido => apellido!.Value , value => new Apellido(value));

        builder.Property(user => user.Email)
        .HasMaxLength(400)
        .HasConversion(email => email!.Value , value => new Travels.Domain.Users.Email(value));

        builder.HasIndex(user => user.Email).IsUnique();
    }
}