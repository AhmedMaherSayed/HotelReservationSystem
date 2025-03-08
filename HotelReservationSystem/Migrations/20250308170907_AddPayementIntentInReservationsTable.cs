using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddPayementIntentInReservationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "805ed019-5df8-4803-a0b5-39aceb7486f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5fcb9a2-ad12-4009-a747-9c40b1dd0073");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 520, DateTimeKind.Utc).AddTicks(8295),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 795, DateTimeKind.Utc).AddTicks(9959));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 522, DateTimeKind.Utc).AddTicks(6559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 797, DateTimeKind.Utc).AddTicks(6849));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 521, DateTimeKind.Utc).AddTicks(9345),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 797, DateTimeKind.Utc).AddTicks(288));

            migrationBuilder.AddColumn<int>(
                name: "FacilityCount",
                table: "RoomFacilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "FacilityPrice",
                table: "RoomFacilities",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 518, DateTimeKind.Utc).AddTicks(7058),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 794, DateTimeKind.Utc).AddTicks(899));

            migrationBuilder.AddColumn<string>(
                name: "ClientSecret",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReservationRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 519, DateTimeKind.Utc).AddTicks(5671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 794, DateTimeKind.Utc).AddTicks(9309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 518, DateTimeKind.Utc).AddTicks(53),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 793, DateTimeKind.Utc).AddTicks(3584));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 517, DateTimeKind.Utc).AddTicks(2843),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 792, DateTimeKind.Utc).AddTicks(6583));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 516, DateTimeKind.Utc).AddTicks(5937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 791, DateTimeKind.Utc).AddTicks(9397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Facilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 515, DateTimeKind.Utc).AddTicks(9127),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 791, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54d2aea0-5e6e-45eb-970b-68b3338ea2eb", null, "Employee", "EMPLOYEE" },
                    { "a3b4701c-89fb-4209-ab11-3ef2137cc6ac", null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54d2aea0-5e6e-45eb-970b-68b3338ea2eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3b4701c-89fb-4209-ab11-3ef2137cc6ac");

            migrationBuilder.DropColumn(
                name: "FacilityCount",
                table: "RoomFacilities");

            migrationBuilder.DropColumn(
                name: "FacilityPrice",
                table: "RoomFacilities");

            migrationBuilder.DropColumn(
                name: "ClientSecret",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "Reservations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 795, DateTimeKind.Utc).AddTicks(9959),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 520, DateTimeKind.Utc).AddTicks(8295));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 797, DateTimeKind.Utc).AddTicks(6849),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 522, DateTimeKind.Utc).AddTicks(6559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 797, DateTimeKind.Utc).AddTicks(288),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 521, DateTimeKind.Utc).AddTicks(9345));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 794, DateTimeKind.Utc).AddTicks(899),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 518, DateTimeKind.Utc).AddTicks(7058));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReservationRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 794, DateTimeKind.Utc).AddTicks(9309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 519, DateTimeKind.Utc).AddTicks(5671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 793, DateTimeKind.Utc).AddTicks(3584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 518, DateTimeKind.Utc).AddTicks(53));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 792, DateTimeKind.Utc).AddTicks(6583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 517, DateTimeKind.Utc).AddTicks(2843));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 791, DateTimeKind.Utc).AddTicks(9397),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 516, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Facilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 6, 15, 42, 56, 791, DateTimeKind.Utc).AddTicks(2188),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 515, DateTimeKind.Utc).AddTicks(9127));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "805ed019-5df8-4803-a0b5-39aceb7486f6", null, "Customer", "CUSTOMER" },
                    { "b5fcb9a2-ad12-4009-a747-9c40b1dd0073", null, "Employee", "EMPLOYEE" }
                });
        }
    }
}
