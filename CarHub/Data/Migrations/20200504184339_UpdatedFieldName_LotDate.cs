using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarHub.Data.Migrations
{
    public partial class UpdatedFieldName_LotDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableOnDate",
                table: "InventoryList");

            migrationBuilder.AddColumn<DateTime>(
                name: "LotDate",
                table: "InventoryList",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "BodyTypeName",
                value: "Small Bus");

            migrationBuilder.UpdateData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "BodyTypeName",
                value: "Large Bus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LotDate",
                table: "InventoryList");

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableOnDate",
                table: "InventoryList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "BodyTypeName",
                value: "Bus");

            migrationBuilder.UpdateData(
                table: "BodyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "BodyTypeName",
                value: "Bus");
        }
    }
}
