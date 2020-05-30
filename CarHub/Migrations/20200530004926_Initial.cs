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
                    { new Guid("e31cae4e-42f4-4657-b17e-48267dd00442"), "caption", "img", "c795771ef3ee406fa35dfecbc8939a9b.jpg" },
                    { new Guid("f171dcfc-df89-444a-a635-d65801f2e0aa"), "caption", "img", "8c6ee53a141643269b88691a1b447d4e.jpg" },
                    { new Guid("dab44ef4-c630-45e3-81e3-63c5377841a2"), "caption", "img", "9c223d45e9234d3e9930bf5073348e6a.jpg" },
                    { new Guid("cc5600ed-98af-440e-a8fd-0d528c8adf8a"), "caption", "img", "6e159fea5e5148458642e302a69076ca.jpg" },
                    { new Guid("73bb3398-eb46-4f4a-b22d-12e287bf7732"), "caption", "img", "c516452c82d24564ab014fb98bf3d191.jpg" },
                    { new Guid("3288763e-24d8-43b3-9123-425a2eeb7e39"), "caption", "img", "ce354b68bbe549db863e019f935f59d2.jpg" },
                    { new Guid("989bca3f-4da6-44a2-9c69-57cbdfe2fb2a"), "caption", "img", "d9415e772ad947ffa77b5e83a3c39780.jpg" },
                    { new Guid("92c16b0a-2443-4a35-9033-36a3c2dcd477"), "caption", "img", "e7cc52f3e382453195cc5a7923735419.jpg" },
                    { new Guid("424e5724-1909-49c6-b50d-0d1223b523e0"), "caption", "img", "ee4c80918c304467b7c030e8fbed5f29.jpg" },
                    { new Guid("c6bd33b9-3ef3-4b2d-bf10-91dd4e7149af"), "caption", "img", "ca9fe65dba0047a5900f8cb8f7f0d583.jpg" }
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
                    { new Guid("080abbbb-17ee-4f81-850b-53ed2ffffb46"), 1, 2, 7, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(3580), "ZBD65F", "A", 43, 2011 },
                    { new Guid("bfc298f4-902f-4593-b539-b8ede6572352"), 1, 2, 15, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(3567), "DBD65F", "A", 72, 2011 },
                    { new Guid("4d4d1588-ad73-46ef-a5e9-ec1a8a651dcd"), 1, 2, 8, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(3584), "SBD65F", "A", 45, 2011 },
                    { new Guid("b483e94b-c500-427e-9c61-921bcea33d99"), 1, 1, 2, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(3558), "CBD65F", "A", 13, 2011 },
                    { new Guid("5c53626c-2a19-4e10-a711-fdf74af71b01"), 1, 1, 6, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(3574), "GBD65F", "A", 40, 2011 },
                    { new Guid("8d0ae456-3bc3-4b60-9405-adf712852e34"), 1, 1, 2, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(3564), "CBD65F", "A", 11, 2011 },
                    { new Guid("5264fe97-ba9e-405b-a400-a35f24e32c6a"), 1, 1, 1, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 30, 10, 49, 25, 566, DateTimeKind.Local).AddTicks(4303), "ABD65F", "A", 1, 2011 },
                    { new Guid("0a274930-06c8-4054-9003-87182f240de5"), 1, 1, 6, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(3577), "XBD65F", "A", 39, 2011 },
                    { new Guid("a3b626cb-3491-4fde-aec1-646bfe0b74a3"), 1, 2, 9, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(3483), "BBD65F", "A", 50, 2011 },
                    { new Guid("e376f7af-687d-4993-9fea-0a96680db475"), 1, 2, 13, 1, "This is a great car! very good condition", 1, 1, 10000, 4, 4, 4, new DateTime(2020, 11, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(3570), "EBD65F", "A", 62, 2011 }
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
                    { new Guid("fa02b609-f01b-4da6-ac11-7fd080590925"), new Guid("5264fe97-ba9e-405b-a400-a35f24e32c6a"), 1, false, new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(6578), new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(5323), 5000m, 1, null, 0m },
                    { new Guid("e53b8946-0e9a-41a1-9e3e-b513679e87e2"), new Guid("8d0ae456-3bc3-4b60-9405-adf712852e34"), 1, false, new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8443), new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8440), 9000m, 1, null, 0m },
                    { new Guid("8e95eb45-c543-4031-9cef-39d4f5be38c4"), new Guid("e376f7af-687d-4993-9fea-0a96680db475"), 1, false, new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8453), new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8450), 3000m, 1, null, 0m },
                    { new Guid("1548431f-6c94-403f-a45f-75cdeed06aa6"), new Guid("b483e94b-c500-427e-9c61-921bcea33d99"), 1, false, new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8437), new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8435), 7000m, 1, null, 0m },
                    { new Guid("702dd0bf-7d0f-4c09-ba91-e6fd4d459834"), new Guid("0a274930-06c8-4054-9003-87182f240de5"), 1, false, new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8463), new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8461), 2000m, 1, null, 0m },
                    { new Guid("dd3c7a85-a94d-4d48-b172-29b8f009e915"), new Guid("a3b626cb-3491-4fde-aec1-646bfe0b74a3"), 1, false, new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8412), new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8387), 6000m, 1, null, 0m },
                    { new Guid("d87ce513-e037-4b07-a74e-c3d8400a716c"), new Guid("5c53626c-2a19-4e10-a711-fdf74af71b01"), 1, false, new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8458), new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8455), 1000m, 1, null, 0m },
                    { new Guid("3e324ecc-7401-4d9d-ae63-78660a23566f"), new Guid("bfc298f4-902f-4593-b539-b8ede6572352"), 1, false, new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8447), new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8445), 8000m, 1, null, 0m },
                    { new Guid("afded9de-8704-4047-8d3f-ad125d9da7b7"), new Guid("080abbbb-17ee-4f81-850b-53ed2ffffb46"), 1, false, new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8468), new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8465), 5400m, 1, null, 0m },
                    { new Guid("926f9611-ffad-4097-87de-5cb306605470"), new Guid("4d4d1588-ad73-46ef-a5e9-ec1a8a651dcd"), 1, false, new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8472), new DateTime(2020, 5, 30, 10, 49, 25, 569, DateTimeKind.Local).AddTicks(8470), 5800m, 1, null, 0m }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "CarId", "Cost", "Description" },
                values: new object[,]
                {
                    { 6, new Guid("e376f7af-687d-4993-9fea-0a96680db475"), 500m, "Tires" },
                    { 2, new Guid("a3b626cb-3491-4fde-aec1-646bfe0b74a3"), 500m, "New engine, new gearbox" },
                    { 10, new Guid("4d4d1588-ad73-46ef-a5e9-ec1a8a651dcd"), 500m, "Front wheel bearings" },
                    { 7, new Guid("5c53626c-2a19-4e10-a711-fdf74af71b01"), 500m, "AC, brakes" },
                    { 8, new Guid("0a274930-06c8-4054-9003-87182f240de5"), 500m, "Tires, brakes" },
                    { 3, new Guid("b483e94b-c500-427e-9c61-921bcea33d99"), 500m, "New suspensions, repainting" },
                    { 4, new Guid("8d0ae456-3bc3-4b60-9405-adf712852e34"), 500m, "Wheels replacements, new tyres" },
                    { 1, new Guid("5264fe97-ba9e-405b-a400-a35f24e32c6a"), 500m, "Full restoration" },
                    { 9, new Guid("080abbbb-17ee-4f81-850b-53ed2ffffb46"), 500m, "Radiator, brakes" },
                    { 5, new Guid("bfc298f4-902f-4593-b539-b8ede6572352"), 500m, "Tires, brakes, AC" }
                });

            migrationBuilder.InsertData(
                table: "InventoryMediaList",
                columns: new[] { "InventoryId", "MediaId", "IsCoverMedia" },
                values: new object[,]
                {
                    { new Guid("fa02b609-f01b-4da6-ac11-7fd080590925"), new Guid("424e5724-1909-49c6-b50d-0d1223b523e0"), true },
                    { new Guid("e53b8946-0e9a-41a1-9e3e-b513679e87e2"), new Guid("3288763e-24d8-43b3-9123-425a2eeb7e39"), true },
                    { new Guid("1548431f-6c94-403f-a45f-75cdeed06aa6"), new Guid("989bca3f-4da6-44a2-9c69-57cbdfe2fb2a"), true },
                    { new Guid("702dd0bf-7d0f-4c09-ba91-e6fd4d459834"), new Guid("73bb3398-eb46-4f4a-b22d-12e287bf7732"), true },
                    { new Guid("d87ce513-e037-4b07-a74e-c3d8400a716c"), new Guid("e31cae4e-42f4-4657-b17e-48267dd00442"), true },
                    { new Guid("afded9de-8704-4047-8d3f-ad125d9da7b7"), new Guid("dab44ef4-c630-45e3-81e3-63c5377841a2"), true },
                    { new Guid("926f9611-ffad-4097-87de-5cb306605470"), new Guid("f171dcfc-df89-444a-a635-d65801f2e0aa"), true },
                    { new Guid("dd3c7a85-a94d-4d48-b172-29b8f009e915"), new Guid("92c16b0a-2443-4a35-9033-36a3c2dcd477"), true },
                    { new Guid("8e95eb45-c543-4031-9cef-39d4f5be38c4"), new Guid("cc5600ed-98af-440e-a8fd-0d528c8adf8a"), true },
                    { new Guid("3e324ecc-7401-4d9d-ae63-78660a23566f"), new Guid("c6bd33b9-3ef3-4b2d-bf10-91dd4e7149af"), true }
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
