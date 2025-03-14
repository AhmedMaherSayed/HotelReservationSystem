using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class NullableRoomFacility : Migration
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 21, DateTimeKind.Utc).AddTicks(3807),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 520, DateTimeKind.Utc).AddTicks(8295));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 22, DateTimeKind.Utc).AddTicks(1869),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 522, DateTimeKind.Utc).AddTicks(6559));

            migrationBuilder.AlterColumn<decimal>(
                name: "FacilityPrice",
                table: "RoomFacilities",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "FacilityCount",
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
                defaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 21, DateTimeKind.Utc).AddTicks(8595),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 521, DateTimeKind.Utc).AddTicks(9345));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 20, DateTimeKind.Utc).AddTicks(4834),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 518, DateTimeKind.Utc).AddTicks(7058));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReservationRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 20, DateTimeKind.Utc).AddTicks(8694),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 519, DateTimeKind.Utc).AddTicks(5671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 20, DateTimeKind.Utc).AddTicks(1015),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 518, DateTimeKind.Utc).AddTicks(53));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 19, DateTimeKind.Utc).AddTicks(7023),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 517, DateTimeKind.Utc).AddTicks(2843));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 19, DateTimeKind.Utc).AddTicks(3441),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 516, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Facilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 18, DateTimeKind.Utc).AddTicks(9557),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 515, DateTimeKind.Utc).AddTicks(9127));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36f6c400-f3d1-4136-bc32-db6598fd41a2", null, "Employee", "EMPLOYEE" },
                    { "b479308d-27fd-4e35-bd74-f92ca2512040", null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36f6c400-f3d1-4136-bc32-db6598fd41a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b479308d-27fd-4e35-bd74-f92ca2512040");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 520, DateTimeKind.Utc).AddTicks(8295),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 21, DateTimeKind.Utc).AddTicks(3807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RoomOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 522, DateTimeKind.Utc).AddTicks(6559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 22, DateTimeKind.Utc).AddTicks(1869));

            migrationBuilder.AlterColumn<decimal>(
                name: "FacilityPrice",
                table: "RoomFacilities",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacilityCount",
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
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 521, DateTimeKind.Utc).AddTicks(9345),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 21, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 518, DateTimeKind.Utc).AddTicks(7058),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 20, DateTimeKind.Utc).AddTicks(4834));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReservationRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 519, DateTimeKind.Utc).AddTicks(5671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 20, DateTimeKind.Utc).AddTicks(8694));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 518, DateTimeKind.Utc).AddTicks(53),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 20, DateTimeKind.Utc).AddTicks(1015));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 517, DateTimeKind.Utc).AddTicks(2843),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 19, DateTimeKind.Utc).AddTicks(7023));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 516, DateTimeKind.Utc).AddTicks(5937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 19, DateTimeKind.Utc).AddTicks(3441));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Facilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 8, 17, 9, 6, 515, DateTimeKind.Utc).AddTicks(9127),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 10, 22, 5, 24, 18, DateTimeKind.Utc).AddTicks(9557));

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
