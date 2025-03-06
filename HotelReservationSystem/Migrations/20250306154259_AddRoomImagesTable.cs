using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dc3ecbb-da47-4c76-9772-ca2cff313371");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59db40a4-e398-47a5-ab64-8117218309d4");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 795, DateTimeKind.Utc).AddTicks(9959),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 17, DateTimeKind.Utc).AddTicks(8098));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "RoomOffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 797, DateTimeKind.Utc).AddTicks(6849),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 18, DateTimeKind.Utc).AddTicks(5199));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "RoomFacilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 797, DateTimeKind.Utc).AddTicks(288),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 18, DateTimeKind.Utc).AddTicks(2438));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 794, DateTimeKind.Utc).AddTicks(899),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 17, DateTimeKind.Utc).AddTicks(234));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "ReservationRooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReservationRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 794, DateTimeKind.Utc).AddTicks(9309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 17, DateTimeKind.Utc).AddTicks(3584));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 793, DateTimeKind.Utc).AddTicks(3584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 16, DateTimeKind.Utc).AddTicks(7007));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Invoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 792, DateTimeKind.Utc).AddTicks(6583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 16, DateTimeKind.Utc).AddTicks(3990));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Feedbacks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 791, DateTimeKind.Utc).AddTicks(9397),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 16, DateTimeKind.Utc).AddTicks(589));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Facilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Facilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 791, DateTimeKind.Utc).AddTicks(2188),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 15, DateTimeKind.Utc).AddTicks(6957));

            migrationBuilder.CreateTable(
                name: "RoomImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomImages_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "805ed019-5df8-4803-a0b5-39aceb7486f6", null, "Customer", "CUSTOMER" },
                    { "b5fcb9a2-ad12-4009-a747-9c40b1dd0073", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomID",
                table: "RoomImages",
                column: "RoomID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomImages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "805ed019-5df8-4803-a0b5-39aceb7486f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5fcb9a2-ad12-4009-a747-9c40b1dd0073");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 17, DateTimeKind.Utc).AddTicks(8098),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 795, DateTimeKind.Utc).AddTicks(9959));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "RoomOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 18, DateTimeKind.Utc).AddTicks(5199),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 797, DateTimeKind.Utc).AddTicks(6849));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "RoomFacilities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 18, DateTimeKind.Utc).AddTicks(2438),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 797, DateTimeKind.Utc).AddTicks(288));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 17, DateTimeKind.Utc).AddTicks(234),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 794, DateTimeKind.Utc).AddTicks(899));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "ReservationRooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReservationRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 17, DateTimeKind.Utc).AddTicks(3584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 794, DateTimeKind.Utc).AddTicks(9309));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 16, DateTimeKind.Utc).AddTicks(7007),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 793, DateTimeKind.Utc).AddTicks(3584));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 16, DateTimeKind.Utc).AddTicks(3990),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 792, DateTimeKind.Utc).AddTicks(6583));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 16, DateTimeKind.Utc).AddTicks(589),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 791, DateTimeKind.Utc).AddTicks(9397));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Facilities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Facilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 1, 23, 10, 53, 15, DateTimeKind.Utc).AddTicks(6957),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 791, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2dc3ecbb-da47-4c76-9772-ca2cff313371", null, "Employee", "EMPLOYEE" },
                    { "59db40a4-e398-47a5-ab64-8117218309d4", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
