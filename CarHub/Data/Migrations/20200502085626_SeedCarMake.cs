using Microsoft.EntityFrameworkCore.Migrations;

namespace CarHub.Data.Migrations
{
    public partial class SeedCarMake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarMakes",
                columns: new[] { "Id", "MakeName" },
                values: new object[,]
                {
                    { 1, "Toyota" },
                    { 2, "Honda" },
                    { 3, "Mazda" },
                    { 4, "Audi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarMakes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarMakes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarMakes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarMakes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
