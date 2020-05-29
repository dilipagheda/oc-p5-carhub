using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarHub.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarMakes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriveTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriveTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryStatusList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryStatusList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrimName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    CarMakeId = table.Column<int>(nullable: false),
                    CarModelId = table.Column<int>(nullable: false),
                    TrimId = table.Column<int>(nullable: false),
                    Kms = table.Column<int>(nullable: false),
                    TransmissionType = table.Column<string>(nullable: false),
                    RegoNumber = table.Column<string>(nullable: true),
                    RegoExpiry = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ColorId = table.Column<int>(nullable: false),
                    BodyTypeId = table.Column<int>(nullable: false),
                    NoOfSeats = table.Column<int>(nullable: false),
                    NoOfDoors = table.Column<int>(nullable: false),
                    NoOfCylinders = table.Column<int>(nullable: false),
                    DriveTypeId = table.Column<int>(nullable: false),
                    FuelTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_BodyTypes_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_CarMakes_CarMakeId",
                        column: x => x.CarMakeId,
                        principalTable: "CarMakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_DriveTypes_DriveTypeId",
                        column: x => x.DriveTypeId,
                        principalTable: "DriveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Trims_TrimId",
                        column: x => x.TrimId,
                        principalTable: "Trims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MakeModelTrims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarMakeId = table.Column<int>(nullable: false),
                    CarModelId = table.Column<int>(nullable: true),
                    TrimId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakeModelTrims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MakeModelTrims_CarMakes_CarMakeId",
                        column: x => x.CarMakeId,
                        principalTable: "CarMakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MakeModelTrims_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MakeModelTrims_Trims_TrimId",
                        column: x => x.TrimId,
                        principalTable: "Trims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    SaleDate = table.Column<DateTime>(nullable: true),
                    SalePrice = table.Column<decimal>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PurchasePrice = table.Column<decimal>(nullable: false),
                    PurchaseTypeId = table.Column<int>(nullable: false),
                    InventoryStatusId = table.Column<int>(nullable: false),
                    LotDate = table.Column<DateTime>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryList_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryList_InventoryStatusList_InventoryStatusId",
                        column: x => x.InventoryStatusId,
                        principalTable: "InventoryStatusList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryList_PurchaseTypes_PurchaseTypeId",
                        column: x => x.PurchaseTypeId,
                        principalTable: "PurchaseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryMediaList",
                columns: table => new
                {
                    InventoryId = table.Column<Guid>(nullable: false),
                    MediaId = table.Column<Guid>(nullable: false),
                    IsCoverMedia = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMediaList", x => new { x.InventoryId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_InventoryMediaList_InventoryList_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "InventoryList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryMediaList_MediaList_MediaId",
                        column: x => x.MediaId,
                        principalTable: "MediaList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BodyTypes",
                columns: new[] { "Id", "BodyTypeName" },
                values: new object[,]
                {
                    { 1, "Small Bus" },
                    { 13, "Wagon" },
                    { 12, "Van" },
                    { 11, "Ute" },
                    { 10, "SUV" },
                    { 8, "People Mover" },
                    { 9, "Sedan" },
                    { 6, "Hatch" },
                    { 5, "Coupe" },
                    { 4, "Convertible" },
                    { 3, "Cab Chassis" },
                    { 2, "Large Bus" },
                    { 7, "Light Truck" }
                });

            migrationBuilder.InsertData(
                table: "CarMakes",
                columns: new[] { "Id", "MakeName" },
                values: new object[,]
                {
                    { 7, "BMW" },
                    { 10, "Mercedes-Benz" },
                    { 9, "Hyundai" },
                    { 8, "Mitsubishi" },
                    { 6, "Holden" },
                    { 5, "Nissan" },
                    { 4, "Audi" },
                    { 3, "Mazda" },
                    { 2, "Honda" },
                    { 1, "Toyota" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "ModelName" },
                values: new object[,]
                {
                    { 43, "Commodore" },
                    { 42, "Colorado" },
                    { 41, "Captiva" },
                    { 40, "Calais" },
                    { 39, "Astra" },
                    { 37, "Pulsar" },
                    { 44, "Cruze" },
                    { 36, "Patrol" },
                    { 35, "Pathfinder" },
                    { 34, "Navara" },
                    { 33, "JUKE" },
                    { 38, "Acadia" },
                    { 45, "1 Series" },
                    { 57, "CLA-Class" },
                    { 47, "3 Series" },
                    { 48, "4 Series" },
                    { 49, "ASX" },
                    { 50, "Challenger" },
                    { 51, "Lancer" },
                    { 52, "Accent" },
                    { 53, "Elantra" },
                    { 54, "i30" },
                    { 55, "A-Class" },
                    { 56, "C-Class" },
                    { 32, "Elgrand" },
                    { 58, "E-Class" },
                    { 59, "GLA-Class" },
                    { 46, "2 Series" },
                    { 31, "Dualis" },
                    { 29, "A6" },
                    { 5, "Kluger" },
                    { 1, "Camry" },
                    { 2, "Corolla" },
                    { 3, "Hiace" },
                    { 4, "Hilux" },
                    { 30, "370Z" },
                    { 7, "Accord" },
                    { 8, "Accord Euro" },
                    { 9, "City" },
                    { 10, "Civic" },
                    { 11, "CR-V" },
                    { 12, "HR-V" },
                    { 13, "Jazz" },
                    { 14, "Odyssey" },
                    { 6, "Landcruiser" },
                    { 16, "2" },
                    { 15, "Integra" },
                    { 28, "A5" },
                    { 27, "A4" },
                    { 26, "A3" },
                    { 24, "MX-5" },
                    { 23, "CX-9" },
                    { 25, "A1" },
                    { 21, "CX-5" },
                    { 20, "CX-3" },
                    { 19, "BT-50" },
                    { 18, "6" },
                    { 17, "3" },
                    { 22, "CX-7" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "ColorName" },
                values: new object[,]
                {
                    { 16, "Silver" },
                    { 10, "Magenta" },
                    { 15, "Red" },
                    { 14, "Purple" },
                    { 13, "Pink" },
                    { 12, "Orange" },
                    { 11, "Maroon" },
                    { 9, "Grey" },
                    { 2, "Black" },
                    { 7, "Gold" },
                    { 6, "Burgundy" },
                    { 5, "Brown" },
                    { 4, "Bronze" },
                    { 3, "Blue" },
                    { 1, "Beige" },
                    { 18, "White" },
                    { 8, "Green" },
                    { 19, "Yellow" }
                });

            migrationBuilder.InsertData(
                table: "DriveTypes",
                columns: new[] { "Id", "DriveTypeName" },
                values: new object[,]
                {
                    { 6, "Front Wheel Drive" },
                    { 7, "Rear Wheel Drive" },
                    { 5, "6x6" },
                    { 1, "4x2" },
                    { 3, "6x2" },
                    { 2, "4x4" },
                    { 4, "6x4" }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "FuelTypeName" },
                values: new object[,]
                {
                    { 5, "Petrol" },
                    { 4, "LPG only" },
                    { 6, "Petrol - Premium ULP" },
                    { 2, "Electric" },
                    { 1, "Diesel" },
                    { 3, "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "InventoryStatusList",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Purchased" },
                    { 2, "In Repair" },
                    { 3, "Sold" },
                    { 4, "Available" }
                });

            migrationBuilder.InsertData(
                table: "MediaList",
                columns: new[] { "Id", "Caption", "ContentType", "FileName" },
                values: new object[,]
                {
                    { new Guid("035a7781-e4f6-4519-aa17-904c263494cf"), "caption", "img", "5752029a253e4ff4ae14abcc1a300cd5.jpg" },
                    { new Guid("07cd7427-a411-47a4-ae79-4985be4fac39"), "caption", "img", "7083a10366af463cb621af35baad1043.jpg" },
                    { new Guid("0343a78c-4e8b-4148-922a-c1eb6ae24f50"), "caption", "img", "6ef4b3c9c6c847f3aa8c9c10d647daea.jpg" },
                    { new Guid("dc69c058-3f56-450c-8ebb-d724572b673c"), "caption", "img", "41f8b966532d4dbda20b848a1d5f8c12.jpg" },
                    { new Guid("69d07fbc-d879-4e1a-b704-34cc0c196f29"), "caption", "img", "69619222e71b477989ec6fd2b54227ff.jpg" },
                    { new Guid("26f810af-204b-491c-a7a4-1ecc5327f45e"), "caption", "img", "19c341d8932c49abaebc34b5d50d8296.jpg" },
                    { new Guid("a401e7d0-b5d0-476c-a357-1f58c6f1ec64"), "caption", "img", "1941da49ad4c47f68f2599bc988a0f14.jpg" },
                    { new Guid("f2d91b2e-ce00-4cbe-83f6-5b48ee1b5a87"), "caption", "img", "15b6d7528c174ebc9a683c8a13f12922.jpg" },
                    { new Guid("fc19c017-bdc4-4152-bf28-9a38fbb50b18"), "caption", "img", "0b58cd3dba9c43ad9439c1c835c2a389.jpg" },
                    { new Guid("0af1b05f-e352-485f-95b7-49e9ed3a9d8e"), "caption", "img", "29d31758302f4a2d8974f700d7c95677.jpg" }
                });

            migrationBuilder.InsertData(
                table: "PurchaseTypes",
                columns: new[] { "Id", "PurchaseTypeName" },
                values: new object[,]
                {
                    { 1, "Private Sale" },
                    { 2, "Auction" }
                });

            migrationBuilder.InsertData(
                table: "Trims",
                columns: new[] { "Id", "TrimName" },
                values: new object[,]
                {
                    { 51, "GLi" },
                    { 50, "VTi-L" },
                    { 49, "VTi" },
                    { 48, "Sport" },
                    { 47, "Luxury Navi" },
                    { 38, "Standard" },
                    { 46, "Luxury" },
                    { 43, "V6" },
                    { 44, "V6L" },
                    { 42, "Limited Edition" },
                    { 41, "EXi" },
                    { 40, "Workmate" },
                    { 39, "VX" },
                    { 52, "RS" },
                    { 45, "Limited Edition" },
                    { 53, "Si" },
                    { 65, "Vibe" },
                    { 55, "Limited Edition" },
                    { 70, "Luxury" },
                    { 69, "GSi" },
                    { 68, "VTi" },
                    { 67, "V6-L" },
                    { 66, "Luxury" },
                    { 37, "Sahara" },
                    { 64, "GLi Vibe" },
                    { 63, "GLi Limited Edition" },
                    { 62, "GLi" },
                    { 61, "Sport" },
                    { 60, "RS" },
                    { 59, "Limited Edition" },
                    { 58, "50 Years Edition" },
                    { 57, "Sport" },
                    { 56, "Luxury" },
                    { 54, "Sport" },
                    { 36, "GXL Troopcarrier" },
                    { 24, "SR" },
                    { 34, "GX" },
                    { 13, "Conquest" },
                    { 12, "Ascent Sport Hybrid" },
                    { 11, "Ascent Sport" },
                    { 10, "Ascent" },
                    { 9, "Sportivo" },
                    { 8, "SL" },
                    { 14, "Hybrid" },
                    { 7, "RZ" },
                    { 5, "Atara SL" },
                    { 4, "Atara S" },
                    { 3, "Ascent Sport" },
                    { 2, "Ascent" },
                    { 1, "Altise" },
                    { 71, "Type R" },
                    { 6, "CSi" },
                    { 15, "Levin SX" },
                    { 16, "Levin ZR" },
                    { 17, "Commuter" },
                    { 33, "Altitude" },
                    { 32, "Grande" },
                    { 31, "CVX" },
                    { 30, "CV Sport" },
                    { 29, "CV" },
                    { 28, "Black Edition" },
                    { 27, "Altitude" },
                    { 26, "SR5 Hi-Rider" },
                    { 25, "SR5" },
                    { 23, "Rugged X" },
                    { 22, "Rogue" },
                    { 21, "DX" },
                    { 20, "Super Custom" },
                    { 19, "Grand Cabin GL" },
                    { 18, "Commuter GL" },
                    { 35, "GXL" },
                    { 72, "Type S" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BodyTypeId", "CarMakeId", "CarModelId", "ColorId", "Description", "DriveTypeId", "FuelTypeId", "Kms", "NoOfCylinders", "NoOfDoors", "NoOfSeats", "RegoExpiry", "RegoNumber", "TransmissionType", "TrimId", "Year" },
                values: new object[,]
                {
                    { new Guid("87fd097d-4655-4c42-83d5-e183eb123617"), 1, 2, 7, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(662), "ZBD65F", "A", 43, 2011 },
                    { new Guid("c75b1e51-fca5-42c0-97d2-2c31020a181d"), 1, 2, 15, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(647), "DBD65F", "A", 72, 2011 },
                    { new Guid("8fec643d-175f-4e8b-9a24-a4f5900cd617"), 1, 2, 8, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(665), "SBD65F", "A", 45, 2011 },
                    { new Guid("ad19ed29-46e7-4fb2-b02c-0ea914d371c3"), 1, 1, 2, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(638), "CBD65F", "A", 13, 2011 },
                    { new Guid("f54a0f27-bd3c-46d7-a664-e2a0ce1092de"), 1, 1, 6, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(654), "GBD65F", "A", 40, 2011 },
                    { new Guid("d824c18a-60c0-4327-9e80-074f5be8a885"), 1, 1, 2, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(644), "CBD65F", "A", 11, 2011 },
                    { new Guid("824c1c11-b0ff-4a82-9463-8abfed31cbae"), 1, 1, 1, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 29, 21, 19, 8, 799, DateTimeKind.Local).AddTicks(5093), "ABD65F", "A", 1, 2011 },
                    { new Guid("dfe5f497-b18b-47e3-9195-57dd17541977"), 1, 1, 6, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(659), "XBD65F", "A", 39, 2011 },
                    { new Guid("4691d428-6b8a-4141-89e0-0ddc21bd1c64"), 1, 2, 9, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(568), "BBD65F", "A", 50, 2011 },
                    { new Guid("a4374a59-cdaf-4117-adcc-928935859fdb"), 1, 2, 13, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(650), "EBD65F", "A", 62, 2011 }
                });

            migrationBuilder.InsertData(
                table: "MakeModelTrims",
                columns: new[] { "Id", "CarMakeId", "CarModelId", "TrimId" },
                values: new object[,]
                {
                    { 35L, 1, 6, 35 },
                    { 36L, 1, 6, 36 },
                    { 37L, 1, 6, 37 },
                    { 39L, 1, 6, 39 },
                    { 40L, 1, 6, 40 },
                    { 41L, 2, 7, 41 },
                    { 38L, 1, 6, 38 },
                    { 34L, 1, 6, 34 },
                    { 32L, 1, 5, 32 },
                    { 42L, 2, 7, 42 },
                    { 31L, 1, 5, 31 },
                    { 30L, 1, 5, 30 },
                    { 29L, 1, 5, 29 },
                    { 28L, 1, 5, 28 },
                    { 27L, 1, 5, 27 },
                    { 26L, 1, 4, 26 },
                    { 25L, 1, 4, 25 },
                    { 24L, 1, 4, 24 },
                    { 23L, 1, 4, 23 },
                    { 22L, 1, 4, 22 },
                    { 21L, 1, 4, 21 },
                    { 20L, 1, 3, 20 },
                    { 33L, 1, 6, 33 },
                    { 73L, 3, 16, null },
                    { 44L, 2, 7, 44 },
                    { 45L, 2, 8, 45 },
                    { 71L, 2, 15, 71 },
                    { 70L, 2, 15, 70 },
                    { 69L, 2, 15, 69 },
                    { 68L, 2, 14, 68 },
                    { 67L, 2, 14, 67 },
                    { 66L, 2, 14, 66 },
                    { 65L, 2, 13, 65 },
                    { 64L, 2, 13, 64 },
                    { 63L, 2, 13, 63 },
                    { 62L, 2, 13, 62 },
                    { 61L, 2, 12, 61 },
                    { 60L, 2, 12, 60 },
                    { 43L, 2, 7, 43 },
                    { 59L, 2, 12, 59 },
                    { 57L, 2, 11, 57 },
                    { 56L, 2, 11, 56 },
                    { 55L, 2, 11, 55 },
                    { 54L, 2, 10, 54 },
                    { 53L, 2, 10, 53 },
                    { 52L, 2, 10, 52 },
                    { 51L, 2, 10, 51 },
                    { 50L, 2, 9, 50 },
                    { 49L, 2, 9, 49 },
                    { 48L, 2, 8, 48 },
                    { 47L, 2, 8, 47 },
                    { 46L, 2, 8, 46 },
                    { 58L, 2, 12, 58 },
                    { 19L, 1, 3, 19 },
                    { 16L, 1, 2, 16 },
                    { 17L, 1, 3, 17 },
                    { 100L, 6, 43, null },
                    { 99L, 6, 42, null },
                    { 98L, 6, 41, null },
                    { 97L, 6, 40, null },
                    { 96L, 6, 39, null },
                    { 95L, 6, 38, null },
                    { 94L, 5, 37, null },
                    { 93L, 5, 36, null },
                    { 92L, 5, 35, null },
                    { 91L, 5, 34, null },
                    { 90L, 5, 33, null },
                    { 89L, 5, 32, null },
                    { 88L, 5, 31, null },
                    { 87L, 5, 30, null },
                    { 86L, 4, 29, null },
                    { 85L, 4, 28, null },
                    { 84L, 4, 27, null },
                    { 83L, 4, 26, null },
                    { 82L, 4, 25, null },
                    { 81L, 3, 24, null },
                    { 80L, 3, 23, null },
                    { 79L, 3, 22, null },
                    { 78L, 3, 21, null },
                    { 77L, 3, 20, null },
                    { 76L, 3, 19, null },
                    { 75L, 3, 18, null },
                    { 74L, 3, 17, null },
                    { 101L, 6, 44, null },
                    { 18L, 1, 3, 18 },
                    { 102L, 7, 45, null },
                    { 104L, 7, 47, null },
                    { 15L, 1, 2, 15 },
                    { 14L, 1, 2, 14 },
                    { 13L, 1, 2, 13 },
                    { 12L, 1, 2, 12 },
                    { 11L, 1, 2, 11 },
                    { 10L, 1, 2, 10 },
                    { 9L, 1, 1, 9 },
                    { 8L, 1, 1, 8 },
                    { 7L, 1, 1, 7 },
                    { 6L, 1, 1, 6 },
                    { 5L, 1, 1, 5 },
                    { 4L, 1, 1, 4 },
                    { 3L, 1, 1, 3 },
                    { 2L, 1, 1, 2 },
                    { 1L, 1, 1, 1 },
                    { 116L, 10, 59, null },
                    { 115L, 10, 58, null },
                    { 114L, 10, 57, null },
                    { 113L, 10, 56, null },
                    { 112L, 10, 55, null },
                    { 111L, 9, 54, null },
                    { 110L, 9, 53, null },
                    { 109L, 9, 52, null },
                    { 108L, 8, 51, null },
                    { 107L, 8, 50, null },
                    { 106L, 8, 49, null },
                    { 105L, 7, 48, null },
                    { 103L, 7, 46, null },
                    { 72L, 2, 15, 72 }
                });

            migrationBuilder.InsertData(
                table: "InventoryList",
                columns: new[] { "Id", "CarId", "InventoryStatusId", "IsFeatured", "LotDate", "PurchaseDate", "PurchasePrice", "PurchaseTypeId", "SaleDate", "SalePrice" },
                values: new object[,]
                {
                    { new Guid("0cd1274d-2207-4e6a-b8aa-80b3271ee33e"), new Guid("824c1c11-b0ff-4a82-9463-8abfed31cbae"), 1, false, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(2818), 5000m, 1, null, 0m },
                    { new Guid("d8905fdb-287a-4f91-b95c-3460c0ec212b"), new Guid("d824c18a-60c0-4327-9e80-074f5be8a885"), 1, false, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(5310), 9000m, 1, null, 0m },
                    { new Guid("65d0d6ec-2a8e-4079-af13-ef7baaa8d5b4"), new Guid("a4374a59-cdaf-4117-adcc-928935859fdb"), 1, false, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(5316), 3000m, 1, null, 0m },
                    { new Guid("ceb49267-9e47-4b9a-8f6d-66b448793432"), new Guid("ad19ed29-46e7-4fb2-b02c-0ea914d371c3"), 1, false, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(5306), 7000m, 1, null, 0m },
                    { new Guid("4968afc4-b349-4241-a9f2-dd352c9bd39d"), new Guid("dfe5f497-b18b-47e3-9195-57dd17541977"), 1, false, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(5323), 2000m, 1, null, 0m },
                    { new Guid("9f4699d0-3b54-417a-a7e9-497341ab0aa4"), new Guid("4691d428-6b8a-4141-89e0-0ddc21bd1c64"), 1, false, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(5261), 6000m, 1, null, 0m },
                    { new Guid("c80ba6c8-a90e-48ef-a306-a6ceb7aca6ef"), new Guid("f54a0f27-bd3c-46d7-a664-e2a0ce1092de"), 1, false, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(5319), 1000m, 1, null, 0m },
                    { new Guid("6c07b806-20d8-4477-9046-69c54ad43202"), new Guid("c75b1e51-fca5-42c0-97d2-2c31020a181d"), 1, false, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(5313), 8000m, 1, null, 0m },
                    { new Guid("b85ca1e5-15b4-40b7-8a60-e7d933897eff"), new Guid("87fd097d-4655-4c42-83d5-e183eb123617"), 1, false, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(5326), 5400m, 1, null, 0m },
                    { new Guid("b088e8df-5384-4960-af53-f1c383bad84b"), new Guid("8fec643d-175f-4e8b-9a24-a4f5900cd617"), 1, false, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 21, 19, 8, 802, DateTimeKind.Local).AddTicks(5329), 5800m, 1, null, 0m }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "CarId", "Cost", "Description" },
                values: new object[,]
                {
                    { 6, new Guid("a4374a59-cdaf-4117-adcc-928935859fdb"), 500m, "Tires" },
                    { 2, new Guid("4691d428-6b8a-4141-89e0-0ddc21bd1c64"), 500m, "New engine, new gearbox" },
                    { 10, new Guid("8fec643d-175f-4e8b-9a24-a4f5900cd617"), 500m, "Front wheel bearings" },
                    { 7, new Guid("f54a0f27-bd3c-46d7-a664-e2a0ce1092de"), 500m, "AC, brakes" },
                    { 8, new Guid("dfe5f497-b18b-47e3-9195-57dd17541977"), 500m, "Tires, brakes" },
                    { 3, new Guid("ad19ed29-46e7-4fb2-b02c-0ea914d371c3"), 500m, "New suspensions, repainting" },
                    { 4, new Guid("d824c18a-60c0-4327-9e80-074f5be8a885"), 500m, "Wheels replacements, new tyres" },
                    { 1, new Guid("824c1c11-b0ff-4a82-9463-8abfed31cbae"), 500m, "Full restoration" },
                    { 9, new Guid("87fd097d-4655-4c42-83d5-e183eb123617"), 500m, "Radiator, brakes" },
                    { 5, new Guid("c75b1e51-fca5-42c0-97d2-2c31020a181d"), 500m, "Tires, brakes, AC" }
                });

            migrationBuilder.InsertData(
                table: "InventoryMediaList",
                columns: new[] { "InventoryId", "MediaId", "IsCoverMedia" },
                values: new object[,]
                {
                    { new Guid("0cd1274d-2207-4e6a-b8aa-80b3271ee33e"), new Guid("fc19c017-bdc4-4152-bf28-9a38fbb50b18"), true },
                    { new Guid("d8905fdb-287a-4f91-b95c-3460c0ec212b"), new Guid("26f810af-204b-491c-a7a4-1ecc5327f45e"), true },
                    { new Guid("ceb49267-9e47-4b9a-8f6d-66b448793432"), new Guid("a401e7d0-b5d0-476c-a357-1f58c6f1ec64"), true },
                    { new Guid("4968afc4-b349-4241-a9f2-dd352c9bd39d"), new Guid("69d07fbc-d879-4e1a-b704-34cc0c196f29"), true },
                    { new Guid("c80ba6c8-a90e-48ef-a306-a6ceb7aca6ef"), new Guid("035a7781-e4f6-4519-aa17-904c263494cf"), true },
                    { new Guid("b85ca1e5-15b4-40b7-8a60-e7d933897eff"), new Guid("0343a78c-4e8b-4148-922a-c1eb6ae24f50"), true },
                    { new Guid("b088e8df-5384-4960-af53-f1c383bad84b"), new Guid("07cd7427-a411-47a4-ae79-4985be4fac39"), true },
                    { new Guid("9f4699d0-3b54-417a-a7e9-497341ab0aa4"), new Guid("f2d91b2e-ce00-4cbe-83f6-5b48ee1b5a87"), true },
                    { new Guid("65d0d6ec-2a8e-4079-af13-ef7baaa8d5b4"), new Guid("dc69c058-3f56-450c-8ebb-d724572b673c"), true },
                    { new Guid("6c07b806-20d8-4477-9046-69c54ad43202"), new Guid("0af1b05f-e352-485f-95b7-49e9ed3a9d8e"), true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BodyTypeId",
                table: "Cars",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarMakeId",
                table: "Cars",
                column: "CarMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DriveTypeId",
                table: "Cars",
                column: "DriveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TrimId",
                table: "Cars",
                column: "TrimId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryList_CarId",
                table: "InventoryList",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryList_InventoryStatusId",
                table: "InventoryList",
                column: "InventoryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryList_PurchaseTypeId",
                table: "InventoryList",
                column: "PurchaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMediaList_MediaId",
                table: "InventoryMediaList",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MakeModelTrims_CarMakeId",
                table: "MakeModelTrims",
                column: "CarMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_MakeModelTrims_CarModelId",
                table: "MakeModelTrims",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MakeModelTrims_TrimId",
                table: "MakeModelTrims",
                column: "TrimId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_CarId",
                table: "Repairs",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "InventoryMediaList");

            migrationBuilder.DropTable(
                name: "MakeModelTrims");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "InventoryList");

            migrationBuilder.DropTable(
                name: "MediaList");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "InventoryStatusList");

            migrationBuilder.DropTable(
                name: "PurchaseTypes");

            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.DropTable(
                name: "CarMakes");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "DriveTypes");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "Trims");
        }
    }
}
