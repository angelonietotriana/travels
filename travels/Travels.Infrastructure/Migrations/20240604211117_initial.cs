using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travels.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    email = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    business_business_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    business_nit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_zone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_numeration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    capacity_value = table.Column<int>(type: "int", nullable: true),
                    starts = table.Column<int>(type: "int", nullable: true),
                    state = table.Column<int>(type: "int", nullable: true),
                    date_created = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hotels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    localization_floor = table.Column<int>(type: "int", nullable: true),
                    localization_view = table.Column<int>(type: "int", nullable: true),
                    number_of_beds = table.Column<int>(type: "int", nullable: true),
                    capacity = table.Column<int>(type: "int", nullable: true),
                    features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    room_type = table.Column<int>(type: "int", nullable: false),
                    price_per_period = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    maintenance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    features_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rooms", x => x.id);
                });



            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    hotel_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    room_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id_booking = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id_vendor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    duration_start = table.Column<DateOnly>(type: "date", nullable: true),
                    duration_end = table.Column<DateOnly>(type: "date", nullable: true),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    confirm_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reject_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    complete_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    cancelation_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bookings", x => x.id);
                    table.ForeignKey(
                        name: "fk_bookings_hotel_entity_hotel_id",
                        column: x => x.hotel_id,
                        principalTable: "hotels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bookings_room_entity_room_id",
                        column: x => x.room_id,
                        principalTable: "rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bookings_user_entity_user_id_booking",
                        column: x => x.user_id_booking,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_bookings_hotel_id",
                table: "bookings",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "ix_bookings_room_id",
                table: "bookings",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "ix_bookings_user_id_booking",
                table: "bookings",
                column: "user_id_booking");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "hotels");

            migrationBuilder.DropTable(
                name: "rooms");

        }
    }
}
