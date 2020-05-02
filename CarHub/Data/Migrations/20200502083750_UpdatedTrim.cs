using Microsoft.EntityFrameworkCore.Migrations;

namespace CarHub.Data.Migrations
{
    public partial class UpdatedTrim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trims_CarModels_CarModelId",
                table: "Trims");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Trims");

            migrationBuilder.AlterColumn<int>(
                name: "CarModelId",
                table: "Trims",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trims_CarModels_CarModelId",
                table: "Trims",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trims_CarModels_CarModelId",
                table: "Trims");

            migrationBuilder.AlterColumn<int>(
                name: "CarModelId",
                table: "Trims",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Trims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Trims_CarModels_CarModelId",
                table: "Trims",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
