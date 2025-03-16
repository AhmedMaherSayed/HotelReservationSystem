using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationRoomStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54d2aea0-5e6e-45eb-970b-68b3338ea2eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3b4701c-89fb-4209-ab11-3ef2137cc6ac");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 698, DateTimeKind.Utc).AddTicks(7797),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 520, DateTimeKind.Utc).AddTicks(8295));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 699, DateTimeKind.Utc).AddTicks(8876),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 522, DateTimeKind.Utc).AddTicks(6559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 699, DateTimeKind.Utc).AddTicks(5314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 521, DateTimeKind.Utc).AddTicks(9345));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 697, DateTimeKind.Utc).AddTicks(7091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 518, DateTimeKind.Utc).AddTicks(7058));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReservationRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 698, DateTimeKind.Utc).AddTicks(1935),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 519, DateTimeKind.Utc).AddTicks(5671));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ReservationRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 697, DateTimeKind.Utc).AddTicks(3318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 518, DateTimeKind.Utc).AddTicks(53));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 696, DateTimeKind.Utc).AddTicks(8073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 517, DateTimeKind.Utc).AddTicks(2843));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 696, DateTimeKind.Utc).AddTicks(985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 516, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Facilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 695, DateTimeKind.Utc).AddTicks(6546),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 515, DateTimeKind.Utc).AddTicks(9127));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bab0b80b-9f4d-41a0-9873-c38f78adf4c2", null, "Customer", "CUSTOMER" },
                    { "f0f45cf8-d884-4c9c-9874-2b53b851e158", null, "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab0b80b-9f4d-41a0-9873-c38f78adf4c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0f45cf8-d884-4c9c-9874-2b53b851e158");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ReservationRooms");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 520, DateTimeKind.Utc).AddTicks(8295),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 698, DateTimeKind.Utc).AddTicks(7797));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 522, DateTimeKind.Utc).AddTicks(6559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 699, DateTimeKind.Utc).AddTicks(8876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 521, DateTimeKind.Utc).AddTicks(9345),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 699, DateTimeKind.Utc).AddTicks(5314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 518, DateTimeKind.Utc).AddTicks(7058),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 697, DateTimeKind.Utc).AddTicks(7091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReservationRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 519, DateTimeKind.Utc).AddTicks(5671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 698, DateTimeKind.Utc).AddTicks(1935));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 518, DateTimeKind.Utc).AddTicks(53),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 697, DateTimeKind.Utc).AddTicks(3318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 517, DateTimeKind.Utc).AddTicks(2843),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 696, DateTimeKind.Utc).AddTicks(8073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 516, DateTimeKind.Utc).AddTicks(5937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 696, DateTimeKind.Utc).AddTicks(985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Facilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 515, DateTimeKind.Utc).AddTicks(9127),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 14, 12, 30, 2, 695, DateTimeKind.Utc).AddTicks(6546));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54d2aea0-5e6e-45eb-970b-68b3338ea2eb", null, "Employee", "EMPLOYEE" },
                    { "a3b4701c-89fb-4209-ab11-3ef2137cc6ac", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
