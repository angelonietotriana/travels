﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travels.Infrastructure;

#nullable disable

namespace Travels.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Travels.Domain.Bookings.BookingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CancelationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("cancelation_date");

                    b.Property<DateTime?>("CompleteDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("complete_date");

                    b.Property<DateTime?>("ConfirmDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("confirm_date");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("creation_date");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("hotel_id");

                    b.Property<DateTime?>("RejectDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("reject_date");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("room_id");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<Guid>("UserIdBooking")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id_booking");

                    b.Property<Guid>("UserIdSells")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id_sells");

                    b.HasKey("Id")
                        .HasName("pk_bookings");

                    b.HasIndex("HotelId")
                        .HasDatabaseName("ix_bookings_hotel_id");

                    b.HasIndex("RoomId")
                        .HasDatabaseName("ix_bookings_room_id");

                    b.HasIndex("UserIdBooking")
                        .HasDatabaseName("ix_bookings_user_id_booking");

                    b.ToTable("bookings", (string)null);
                });

            modelBuilder.Entity("Travels.Domain.Hotels.HotelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateOnly>("DateCreated")
                        .HasColumnType("date")
                        .HasColumnName("date_created");

                    b.Property<int?>("Starts")
                        .HasColumnType("int")
                        .HasColumnName("starts");

                    b.Property<int?>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.HasKey("Id")
                        .HasName("pk_hotels");

                    b.ToTable("hotels", (string)null);
                });

            modelBuilder.Entity("Travels.Domain.HotelsRooms.HotelsRoomsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("hotel_id");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("room_id");

                    b.HasKey("Id")
                        .HasName("pk_hotels_rooms");

                    b.HasIndex("HotelId")
                        .HasDatabaseName("ix_hotels_rooms_hotel_id");

                    b.HasIndex("RoomId")
                        .HasDatabaseName("ix_hotels_rooms_room_id");

                    b.ToTable("hotels_rooms", (string)null);
                });

            modelBuilder.Entity("Travels.Domain.Rooms.RoomEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("capacity");

                    b.Property<string>("Features")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("features");

                    b.Property<decimal?>("FeaturesPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("features_price");

                    b.Property<decimal?>("Maintenance")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("maintenance");

                    b.Property<int?>("NumberOfBeds")
                        .HasColumnType("int")
                        .HasColumnName("number_of_beds");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<decimal?>("PricePerPeriod")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price_per_period");

                    b.Property<int>("RoomType")
                        .HasColumnType("int")
                        .HasColumnName("room_type");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("total_price");

                    b.HasKey("Id")
                        .HasName("pk_rooms");

                    b.ToTable("rooms", (string)null);
                });

            modelBuilder.Entity("Travels.Domain.Users.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Apellido")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("apellido");

                    b.Property<string>("Email")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("nombre");

                    b.Property<int?>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email")
                        .HasFilter("[email] IS NOT NULL");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Travels.Domain.Bookings.BookingEntity", b =>
                {
                    b.HasOne("Travels.Domain.Hotels.HotelEntity", null)
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bookings_hotel_entity_hotel_id");

                    b.HasOne("Travels.Domain.Rooms.RoomEntity", null)
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bookings_room_entity_room_id");

                    b.HasOne("Travels.Domain.Users.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserIdBooking")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bookings_user_entity_user_id_booking");

                    b.OwnsOne("Travels.Domain.Bookings.DateRange", "Duration", b1 =>
                        {
                            b1.Property<Guid>("BookingEntityId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("id");

                            b1.Property<DateOnly>("End")
                                .HasColumnType("date")
                                .HasColumnName("duration_end");

                            b1.Property<DateOnly>("Start")
                                .HasColumnType("date")
                                .HasColumnName("duration_start");

                            b1.HasKey("BookingEntityId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingEntityId")
                                .HasConstraintName("fk_bookings_bookings_id");
                        });

                    b.Navigation("Duration");
                });

            modelBuilder.Entity("Travels.Domain.Hotels.HotelEntity", b =>
                {
                    b.OwnsOne("Travels.Domain.Hotels.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("HotelEntityId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("address_city");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("address_neighborhood");

                            b1.Property<string>("Numeration")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("address_numeration");

                            b1.Property<string>("Zone")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("address_zone");

                            b1.HasKey("HotelEntityId");

                            b1.ToTable("hotels");

                            b1.WithOwner()
                                .HasForeignKey("HotelEntityId")
                                .HasConstraintName("fk_hotels_hotels_id");
                        });

                    b.OwnsOne("Travels.Domain.Hotels.Business", "Business", b1 =>
                        {
                            b1.Property<Guid>("HotelEntityId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("id");

                            b1.Property<string>("BusinessName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("business_business_name");

                            b1.Property<string>("Nit")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("business_nit");

                            b1.HasKey("HotelEntityId");

                            b1.ToTable("hotels");

                            b1.WithOwner()
                                .HasForeignKey("HotelEntityId")
                                .HasConstraintName("fk_hotels_hotels_id");
                        });

                    b.OwnsOne("Travels.Domain.Hotels.TotalCapacity", "Capacity", b1 =>
                        {
                            b1.Property<Guid>("HotelEntityId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("id");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("capacity_value");

                            b1.HasKey("HotelEntityId");

                            b1.ToTable("hotels");

                            b1.WithOwner()
                                .HasForeignKey("HotelEntityId")
                                .HasConstraintName("fk_hotels_hotels_id");
                        });

                    b.Navigation("Address");

                    b.Navigation("Business");

                    b.Navigation("Capacity");
                });

            modelBuilder.Entity("Travels.Domain.HotelsRooms.HotelsRoomsEntity", b =>
                {
                    b.HasOne("Travels.Domain.Hotels.HotelEntity", null)
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_hotels_rooms_hotels_hotel_id");

                    b.HasOne("Travels.Domain.Rooms.RoomEntity", null)
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_hotels_rooms_room_entity_room_id");

                    b.OwnsOne("Travels.Domain.HotelsRooms.IsActive", "IsActive", b1 =>
                        {
                            b1.Property<Guid>("HotelsRoomsEntityId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("id");

                            b1.Property<bool>("value")
                                .HasColumnType("bit")
                                .HasColumnName("is_active_value");

                            b1.HasKey("HotelsRoomsEntityId");

                            b1.ToTable("hotels_rooms");

                            b1.WithOwner()
                                .HasForeignKey("HotelsRoomsEntityId")
                                .HasConstraintName("fk_hotels_rooms_hotels_rooms_id");
                        });

                    b.Navigation("IsActive")
                        .IsRequired();
                });

            modelBuilder.Entity("Travels.Domain.Rooms.RoomEntity", b =>
                {
                    b.OwnsOne("Travels.Domain.Rooms.Localization", "Localization", b1 =>
                        {
                            b1.Property<Guid>("RoomEntityId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("id");

                            b1.Property<int>("Floor")
                                .HasColumnType("int")
                                .HasColumnName("localization_floor");

                            b1.Property<int>("view")
                                .HasColumnType("int")
                                .HasColumnName("localization_view");

                            b1.HasKey("RoomEntityId");

                            b1.ToTable("rooms");

                            b1.WithOwner()
                                .HasForeignKey("RoomEntityId")
                                .HasConstraintName("fk_rooms_rooms_id");
                        });

                    b.Navigation("Localization");
                });
#pragma warning restore 612, 618
        }
    }
}
