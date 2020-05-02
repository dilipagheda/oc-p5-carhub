using Microsoft.EntityFrameworkCore.Migrations;

namespace CarHub.Data.Migrations
{
    public partial class SeedCarModelAndTrim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarMakes",
                columns: new[] { "Id", "MakeName" },
                values: new object[,]
                {
                    { 5, "Nissan" },
                    { 6, "Holden" },
                    { 7, "BMW" },
                    { 8, "Mitsubishi" },
                    { 9, "Hyundai" },
                    { 10, "Mercedes-Benz" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "CarMakeId", "ModelName" },
                values: new object[,]
                {
                    { 17, 3, "3" },
                    { 18, 3, "6" },
                    { 19, 3, "BT-50" },
                    { 20, 3, "CX-3" },
                    { 21, 3, "CX-5" },
                    { 24, 3, "MX-5" },
                    { 23, 3, "CX-9" },
                    { 16, 3, "2" },
                    { 25, 4, "A1" },
                    { 26, 4, "A3" },
                    { 27, 4, "A4" },
                    { 22, 3, "CX-7" },
                    { 15, 2, "Integra" },
                    { 12, 2, "HR-V" },
                    { 13, 2, "Jazz" },
                    { 28, 4, "A5" },
                    { 11, 2, "CR-V" },
                    { 10, 2, "Civic" },
                    { 9, 2, "City" },
                    { 8, 2, "Accord Euro" },
                    { 7, 2, "Accord" },
                    { 6, 1, "Landcruiser" },
                    { 5, 1, "Kluger" },
                    { 4, 1, "Hilux" },
                    { 3, 1, "Hiace" },
                    { 2, 1, "Corolla" },
                    { 1, 1, "Camry" },
                    { 14, 2, "Odyssey" },
                    { 29, 4, "A6" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "CarMakeId", "ModelName" },
                values: new object[,]
                {
                    { 30, 5, "370Z" },
                    { 59, 10, "GLA-Class" },
                    { 58, 10, "E-Class" },
                    { 57, 10, "CLA-Class" },
                    { 56, 10, "C-Class" },
                    { 55, 10, "A-Class" },
                    { 54, 9, "i30" },
                    { 53, 9, "Elantra" },
                    { 51, 8, "Lancer" },
                    { 50, 8, "Challenger" },
                    { 49, 8, "ASX" },
                    { 48, 7, "4 Series" },
                    { 47, 7, "3 Series" },
                    { 46, 7, "2 Series" },
                    { 45, 7, "1 Series" },
                    { 52, 9, "Accent" },
                    { 43, 6, "Commodore" },
                    { 44, 6, "Cruze" },
                    { 31, 5, "Dualis" },
                    { 32, 5, "Elgrand" },
                    { 33, 5, "JUKE" },
                    { 35, 5, "Pathfinder" },
                    { 36, 5, "Patrol" },
                    { 34, 5, "Navara" },
                    { 38, 6, "Acadia" },
                    { 39, 6, "Astra" },
                    { 40, 6, "Calais" },
                    { 41, 6, "Captiva" },
                    { 42, 6, "Colorado" },
                    { 37, 5, "Pulsar" }
                });

            migrationBuilder.InsertData(
                table: "Trims",
                columns: new[] { "Id", "CarModelId", "TrimName" },
                values: new object[,]
                {
                    { 51, 10, "GLi" },
                    { 46, 8, "Luxury" },
                    { 50, 9, "VTi-L" },
                    { 49, 9, "VTi" },
                    { 48, 8, "Sport" },
                    { 47, 8, "Luxury Navi" },
                    { 45, 8, "Limited Edition" },
                    { 38, 6, "Standard" },
                    { 43, 7, "V6" },
                    { 42, 7, "Limited Edition" },
                    { 41, 7, "EXi" },
                    { 40, 6, "Workmate" },
                    { 39, 6, "VX" },
                    { 52, 10, "RS" },
                    { 44, 7, "V6L" },
                    { 53, 10, "Si" },
                    { 68, 14, "VTi" },
                    { 55, 11, "Limited Edition" },
                    { 70, 15, "Luxury" },
                    { 69, 15, "GSi" },
                    { 37, 6, "Sahara" },
                    { 67, 14, "V6-L" },
                    { 66, 14, "Luxury" },
                    { 65, 13, "Vibe" },
                    { 64, 13, "GLi Vibe" },
                    { 63, 13, "GLi Limited Edition" },
                    { 62, 13, "GLi" },
                    { 61, 12, "Sport" },
                    { 60, 12, "RS" },
                    { 59, 12, "Limited Edition" },
                    { 58, 12, "50 Years Edition" },
                    { 57, 11, "Sport" },
                    { 56, 11, "Luxury" },
                    { 54, 10, "Sport" },
                    { 36, 6, "GXL Troopcarrier" },
                    { 21, 4, "DX" },
                    { 34, 6, "GX" },
                    { 14, 2, "Hybrid" },
                    { 13, 2, "Conquest" },
                    { 12, 2, "Ascent Sport Hybrid" },
                    { 11, 2, "Ascent Sport" },
                    { 10, 2, "Ascent" },
                    { 9, 1, "Sportivo" },
                    { 15, 2, "Levin SX" },
                    { 8, 1, "SL" },
                    { 6, 1, "CSi" },
                    { 5, 1, "Atara SL" },
                    { 4, 1, "Atara S" },
                    { 3, 1, "Ascent Sport" },
                    { 2, 1, "Ascent" },
                    { 1, 1, "Altise" },
                    { 7, 1, "RZ" },
                    { 16, 2, "Levin ZR" },
                    { 17, 3, "Commuter" },
                    { 18, 3, "Commuter GL" },
                    { 33, 6, "Altitude" },
                    { 32, 5, "Grande" },
                    { 31, 5, "CVX" },
                    { 30, 5, "CV Sport" },
                    { 29, 5, "CV" },
                    { 28, 5, "Black Edition" },
                    { 27, 5, "Altitude" },
                    { 26, 4, "SR5 Hi-Rider" },
                    { 25, 4, "SR5" },
                    { 24, 4, "SR" },
                    { 23, 4, "Rugged X" },
                    { 22, 4, "Rogue" },
                    { 71, 15, "Type R" },
                    { 20, 3, "Super Custom" },
                    { 19, 3, "Grand Cabin GL" },
                    { 35, 6, "GXL" },
                    { 72, 15, "Type S" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "CarMakes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarMakes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarMakes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarMakes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarMakes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarMakes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
