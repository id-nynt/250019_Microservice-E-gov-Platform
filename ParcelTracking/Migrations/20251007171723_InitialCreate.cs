using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParcelTracking.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parcels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrackingNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Eta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    History = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Parcels",
                columns: new[] { "Id", "Eta", "History", "Location", "Status", "TrackingNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 10, 8, 0, 0, 0, DateTimeKind.Utc), "[]", "Sydney Facility", "Dispatched", "AP100001" },
                    { 2, new DateTime(2025, 10, 11, 8, 0, 0, 0, DateTimeKind.Utc), "[]", "Sydney Hub", "In Transit", "AP100002" },
                    { 3, new DateTime(2025, 10, 11, 12, 0, 0, 0, DateTimeKind.Utc), "[]", "Sydney Hub", "Processed", "AP100003" },
                    { 4, new DateTime(2025, 10, 8, 14, 0, 0, 0, DateTimeKind.Utc), "[]", "Wollongong Depot", "Out for Delivery", "AP100004" },
                    { 5, new DateTime(2025, 10, 7, 10, 0, 0, 0, DateTimeKind.Utc), "[]", "Wollongong", "Delivered", "AP100005" },
                    { 6, new DateTime(2025, 10, 13, 9, 0, 0, 0, DateTimeKind.Utc), "[]", "Melbourne Hub", "Delayed", "AP100006" },
                    { 7, new DateTime(2025, 10, 12, 16, 0, 0, 0, DateTimeKind.Utc), "[]", "Sydney Airport", "Held at Customs", "AP100007" },
                    { 8, new DateTime(2025, 10, 9, 11, 0, 0, 0, DateTimeKind.Utc), "[]", "Canberra Facility", "In Transit", "AP100008" },
                    { 9, new DateTime(2025, 10, 10, 15, 0, 0, 0, DateTimeKind.Utc), "[]", "Brisbane Hub", "Processed", "AP100009" },
                    { 10, new DateTime(2025, 10, 8, 18, 0, 0, 0, DateTimeKind.Utc), "[]", "Canberra Depot", "Out for Delivery", "AP100010" },
                    { 11, new DateTime(2025, 10, 6, 9, 0, 0, 0, DateTimeKind.Utc), "[]", "Canberra", "Delivered", "AP100011" },
                    { 12, new DateTime(2025, 10, 12, 10, 0, 0, 0, DateTimeKind.Utc), "[]", "Perth Hub", "Processing", "AP100012" },
                    { 13, new DateTime(2025, 10, 11, 14, 0, 0, 0, DateTimeKind.Utc), "[]", "Adelaide Hub", "In Transit", "AP100013" },
                    { 14, new DateTime(2025, 10, 11, 16, 0, 0, 0, DateTimeKind.Utc), "[]", "Adelaide Hub", "Processed", "AP100014" },
                    { 15, new DateTime(2025, 10, 14, 8, 0, 0, 0, DateTimeKind.Utc), "[]", "Darwin Hub", "Delayed", "AP100015" },
                    { 16, new DateTime(2025, 10, 10, 13, 0, 0, 0, DateTimeKind.Utc), "[]", "Melbourne Facility", "Dispatched", "AP100016" },
                    { 17, new DateTime(2025, 10, 8, 12, 0, 0, 0, DateTimeKind.Utc), "[]", "Sydney Depot", "Out for Delivery", "AP100017" },
                    { 18, new DateTime(2025, 10, 7, 12, 0, 0, 0, DateTimeKind.Utc), "[]", "Sydney", "Delivered", "AP100018" },
                    { 19, new DateTime(2025, 10, 13, 10, 0, 0, 0, DateTimeKind.Utc), "[]", "Hobart Hub", "Processing", "AP100019" },
                    { 20, new DateTime(2025, 10, 11, 9, 0, 0, 0, DateTimeKind.Utc), "[]", "Gold Coast Hub", "In Transit", "AP100020" },
                    { 21, new DateTime(2025, 10, 11, 11, 0, 0, 0, DateTimeKind.Utc), "[]", "Gold Coast Hub", "Processed", "AP100021" },
                    { 22, new DateTime(2025, 10, 8, 17, 0, 0, 0, DateTimeKind.Utc), "[]", "Melbourne Depot", "Out for Delivery", "AP100022" },
                    { 23, new DateTime(2025, 10, 6, 14, 0, 0, 0, DateTimeKind.Utc), "[]", "Melbourne", "Delivered", "AP100023" },
                    { 24, new DateTime(2025, 10, 12, 15, 0, 0, 0, DateTimeKind.Utc), "[]", "Perth Facility", "Held at Facility", "AP100024" },
                    { 25, new DateTime(2025, 10, 9, 10, 0, 0, 0, DateTimeKind.Utc), "[]", "Sydney Hub", "In Transit", "AP100025" },
                    { 26, new DateTime(2025, 10, 9, 12, 0, 0, 0, DateTimeKind.Utc), "[]", "Sydney Hub", "Processed", "AP100026" },
                    { 27, new DateTime(2025, 10, 13, 16, 0, 0, 0, DateTimeKind.Utc), "[]", "Canberra Hub", "Delayed", "AP100027" },
                    { 28, new DateTime(2025, 10, 10, 10, 0, 0, 0, DateTimeKind.Utc), "[]", "Brisbane Hub", "Processing", "AP100028" },
                    { 29, new DateTime(2025, 10, 8, 20, 0, 0, 0, DateTimeKind.Utc), "[]", "Brisbane Depot", "Out for Delivery", "AP100029" },
                    { 30, new DateTime(2025, 10, 5, 9, 0, 0, 0, DateTimeKind.Utc), "[]", "Brisbane", "Delivered", "AP100030" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcels");
        }
    }
}
