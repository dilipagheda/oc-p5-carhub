using System;
using System.Collections.Generic;
using System.Text;
using CarHub.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarHub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<DriveType> DriveTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Inventory> InventoryList { get; set; }
        public DbSet<InventoryMedia> InventoryMediaList { get; set; }
        public DbSet<InventoryStatus> InventoryStatusList { get; set; }
        public DbSet<Media> MediaList { get; set; }
        public DbSet<PurchaseType> PurchaseTypes { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Trim> Trims { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<InventoryMedia>()
                .HasKey(im => new { im.CarId, im.MediaId });

            builder.Entity<CarMake>()
                .HasMany(cm => cm.CarModels)
                .WithOne(cm => cm.CarMake)
                .HasForeignKey(cm => cm.CarMakeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CarModel>()
                .HasOne(cm => cm.CarMake)
                .WithMany(cm => cm.CarModels)
                .HasForeignKey(cm => cm.CarMakeId)
                .OnDelete(DeleteBehavior.Cascade);

            //seed initial data
            builder.Entity<CarMake>()
                .HasData(
                    new CarMake() { Id = 1, MakeName = "Toyota" },
                    new CarMake() { Id = 2, MakeName = "Honda" },
                    new CarMake() { Id = 3, MakeName = "Mazda" },
                    new CarMake() { Id = 4, MakeName = "Audi" },
                    new CarMake() { Id = 5, MakeName = "Nissan" },
                    new CarMake() { Id = 6, MakeName = "Holden" },
                    new CarMake() { Id = 7, MakeName = "BMW" },
                    new CarMake() { Id = 8, MakeName = "Mitsubishi" },
                    new CarMake() { Id = 9, MakeName = "Hyundai" },
                    new CarMake() { Id = 10, MakeName = "Mercedes-Benz" }
                 );

            builder.Entity<CarModel>()
                .HasData(
                    //Toyota
                    new CarModel() { Id = 1, CarMakeId = 1, ModelName = "Camry" },
                    new CarModel() { Id = 2, CarMakeId = 1, ModelName = "Corolla" },
                    new CarModel() { Id = 3, CarMakeId = 1, ModelName = "Hiace" },
                    new CarModel() { Id = 4, CarMakeId = 1, ModelName = "Hilux" },
                    new CarModel() { Id = 5, CarMakeId = 1, ModelName = "Kluger" },
                    new CarModel() { Id = 6, CarMakeId = 1, ModelName = "Landcruiser" },
                    //Honda
                    new CarModel() { Id = 7, CarMakeId = 2, ModelName = "Accord" },
                    new CarModel() { Id = 8, CarMakeId = 2, ModelName = "Accord Euro" },
                    new CarModel() { Id = 9, CarMakeId = 2, ModelName = "City" },
                    new CarModel() { Id = 10, CarMakeId = 2, ModelName = "Civic" },
                    new CarModel() { Id = 11, CarMakeId = 2, ModelName = "CR-V" },
                    new CarModel() { Id = 12, CarMakeId = 2, ModelName = "HR-V" },
                    new CarModel() { Id = 13, CarMakeId = 2, ModelName = "Jazz" },
                    new CarModel() { Id = 14, CarMakeId = 2, ModelName = "Odyssey" },
                    new CarModel() { Id = 15, CarMakeId = 2, ModelName = "Integra" },
                    //Mazda
                    new CarModel() { Id = 16, CarMakeId = 3, ModelName = "2" },
                    new CarModel() { Id = 17, CarMakeId = 3, ModelName = "3" },
                    new CarModel() { Id = 18, CarMakeId = 3, ModelName = "6" },
                    new CarModel() { Id = 19, CarMakeId = 3, ModelName = "BT-50" },
                    new CarModel() { Id = 20, CarMakeId = 3, ModelName = "CX-3" },
                    new CarModel() { Id = 21, CarMakeId = 3, ModelName = "CX-5" },
                    new CarModel() { Id = 22, CarMakeId = 3, ModelName = "CX-7" },
                    new CarModel() { Id = 23, CarMakeId = 3, ModelName = "CX-9" },
                    new CarModel() { Id = 24, CarMakeId = 3, ModelName = "MX-5" },
                    //Audi
                    new CarModel() { Id = 25, CarMakeId = 4, ModelName = "A1" },
                    new CarModel() { Id = 26, CarMakeId = 4, ModelName = "A3" },
                    new CarModel() { Id = 27, CarMakeId = 4, ModelName = "A4" },
                    new CarModel() { Id = 28, CarMakeId = 4, ModelName = "A5" },
                    new CarModel() { Id = 29, CarMakeId = 4, ModelName = "A6" },
                    //Nissan
                    new CarModel() { Id = 30, CarMakeId = 5, ModelName = "370Z" },
                    new CarModel() { Id = 31, CarMakeId = 5, ModelName = "Dualis" },
                    new CarModel() { Id = 32, CarMakeId = 5, ModelName = "Elgrand" },
                    new CarModel() { Id = 33, CarMakeId = 5, ModelName = "JUKE" },
                    new CarModel() { Id = 34, CarMakeId = 5, ModelName = "Navara" },
                    new CarModel() { Id = 35, CarMakeId = 5, ModelName = "Pathfinder" },
                    new CarModel() { Id = 36, CarMakeId = 5, ModelName = "Patrol" },
                    new CarModel() { Id = 37, CarMakeId = 5, ModelName = "Pulsar" },
                    //Holden
                    new CarModel() { Id = 38, CarMakeId = 6, ModelName = "Acadia" },
                    new CarModel() { Id = 39, CarMakeId = 6, ModelName = "Astra" },
                    new CarModel() { Id = 40, CarMakeId = 6, ModelName = "Calais" },
                    new CarModel() { Id = 41, CarMakeId = 6, ModelName = "Captiva" },
                    new CarModel() { Id = 42, CarMakeId = 6, ModelName = "Colorado" },
                    new CarModel() { Id = 43, CarMakeId = 6, ModelName = "Commodore" },
                    new CarModel() { Id = 44, CarMakeId = 6, ModelName = "Cruze" },
                    //BMW
                    new CarModel() { Id = 45, CarMakeId = 7, ModelName = "1 Series" },
                    new CarModel() { Id = 46, CarMakeId = 7, ModelName = "2 Series" },
                    new CarModel() { Id = 47, CarMakeId = 7, ModelName = "3 Series" },
                    new CarModel() { Id = 48, CarMakeId = 7, ModelName = "4 Series" },
                    //Mitsubishi
                    new CarModel() { Id = 49, CarMakeId = 8, ModelName = "ASX" },
                    new CarModel() { Id = 50, CarMakeId = 8, ModelName = "Challenger" },
                    new CarModel() { Id = 51, CarMakeId = 8, ModelName = "Lancer" },
                    //Hyundai
                    new CarModel() { Id = 52, CarMakeId = 9, ModelName = "Accent" },
                    new CarModel() { Id = 53, CarMakeId = 9, ModelName = "Elantra" },
                    new CarModel() { Id = 54, CarMakeId = 9, ModelName = "i30" },
                    //Mercedes-Benz
                    new CarModel() { Id = 55, CarMakeId = 10, ModelName = "A-Class" },
                    new CarModel() { Id = 56, CarMakeId = 10, ModelName = "C-Class" },
                    new CarModel() { Id = 57, CarMakeId = 10, ModelName = "CLA-Class" },
                    new CarModel() { Id = 58, CarMakeId = 10, ModelName = "E-Class" },
                    new CarModel() { Id = 59, CarMakeId = 10, ModelName = "GLA-Class" }
                );

            builder.Entity<Trim>()
                .HasData(
                    //Toyota
                    new Trim() { Id=1, CarModelId= 1, TrimName="Altise"},
                    new Trim() { Id =2, CarModelId = 1, TrimName = "Ascent" },
                    new Trim() { Id = 3, CarModelId = 1, TrimName = "Ascent Sport" },
                    new Trim() { Id = 4, CarModelId = 1, TrimName = "Atara S" },
                    new Trim() { Id = 5, CarModelId = 1, TrimName = "Atara SL" },
                    new Trim() { Id = 6, CarModelId = 1, TrimName = "CSi" },
                    new Trim() { Id = 7, CarModelId = 1, TrimName = "RZ" },
                    new Trim() { Id = 8, CarModelId = 1, TrimName = "SL" },
                    new Trim() { Id = 9, CarModelId = 1, TrimName = "Sportivo" },
                    new Trim() { Id = 10, CarModelId = 2, TrimName = "Ascent" },
                    new Trim() { Id = 11, CarModelId = 2, TrimName = "Ascent Sport" },
                    new Trim() { Id = 12, CarModelId = 2, TrimName = "Ascent Sport Hybrid" },
                    new Trim() { Id = 13, CarModelId = 2, TrimName = "Conquest" },
                    new Trim() { Id = 14, CarModelId = 2, TrimName = "Hybrid" },
                    new Trim() { Id = 15, CarModelId = 2, TrimName = "Levin SX" },
                    new Trim() { Id = 16, CarModelId = 2, TrimName = "Levin ZR" },
                    new Trim() { Id = 17, CarModelId = 3, TrimName = "Commuter" },
                    new Trim() { Id = 18, CarModelId = 3, TrimName = "Commuter GL" },
                    new Trim() { Id = 19, CarModelId = 3, TrimName = "Grand Cabin GL" },
                    new Trim() { Id = 20, CarModelId = 3, TrimName = "Super Custom" },
                    new Trim() { Id = 21, CarModelId = 4, TrimName = "DX" },
                    new Trim() { Id = 22, CarModelId = 4, TrimName = "Rogue" },
                    new Trim() { Id = 23, CarModelId = 4, TrimName = "Rugged X" },
                    new Trim() { Id = 24, CarModelId = 4, TrimName = "SR" },
                    new Trim() { Id = 25, CarModelId = 4, TrimName = "SR5" },
                    new Trim() { Id = 26, CarModelId = 4, TrimName = "SR5 Hi-Rider" },
                    new Trim() { Id = 27, CarModelId = 5, TrimName = "Altitude" },
                    new Trim() { Id = 28, CarModelId = 5, TrimName = "Black Edition" },
                    new Trim() { Id = 29, CarModelId = 5, TrimName = "CV" },
                    new Trim() { Id = 30, CarModelId = 5, TrimName = "CV Sport" },
                    new Trim() { Id = 31, CarModelId = 5, TrimName = "CVX" },
                    new Trim() { Id = 32, CarModelId = 5, TrimName = "Grande" },
                    new Trim() { Id = 33, CarModelId = 6, TrimName = "Altitude" },
                    new Trim() { Id = 34, CarModelId = 6, TrimName = "GX" },
                    new Trim() { Id = 35, CarModelId = 6, TrimName = "GXL" },
                    new Trim() { Id = 36, CarModelId = 6, TrimName = "GXL Troopcarrier" },
                    new Trim() { Id = 37, CarModelId = 6, TrimName = "Sahara" },
                    new Trim() { Id = 38, CarModelId = 6, TrimName = "Standard" },
                    new Trim() { Id = 39, CarModelId = 6, TrimName = "VX" },
                    new Trim() { Id = 40, CarModelId = 6, TrimName = "Workmate" },
                    //Honda
                    new Trim() { Id = 41, CarModelId = 7, TrimName = "EXi" },
                    new Trim() { Id = 42, CarModelId = 7, TrimName = "Limited Edition" },
                    new Trim() { Id = 43, CarModelId = 7, TrimName = "V6" },
                    new Trim() { Id = 44, CarModelId = 7, TrimName = "V6L" },
                    new Trim() { Id = 45, CarModelId = 8, TrimName = "Limited Edition" },
                    new Trim() { Id = 46, CarModelId = 8, TrimName = "Luxury" },
                    new Trim() { Id = 47, CarModelId = 8, TrimName = "Luxury Navi" },
                    new Trim() { Id = 48, CarModelId = 8, TrimName = "Sport" },
                    new Trim() { Id = 49, CarModelId = 9, TrimName = "VTi" },
                    new Trim() { Id = 50, CarModelId = 9, TrimName = "VTi-L" },
                    new Trim() { Id = 51, CarModelId = 10, TrimName = "GLi" },
                    new Trim() { Id = 52, CarModelId = 10, TrimName = "RS" },
                    new Trim() { Id = 53, CarModelId = 10, TrimName = "Si" },
                    new Trim() { Id = 54, CarModelId = 10, TrimName = "Sport" },
                    new Trim() { Id = 55, CarModelId = 11, TrimName = "Limited Edition" },
                    new Trim() { Id = 56, CarModelId = 11, TrimName = "Luxury" },
                    new Trim() { Id = 57, CarModelId = 11, TrimName = "Sport" },
                    new Trim() { Id = 58, CarModelId = 12, TrimName = "50 Years Edition" },
                    new Trim() { Id = 59, CarModelId = 12, TrimName = "Limited Edition" },
                    new Trim() { Id = 60, CarModelId = 12, TrimName = "RS" },
                    new Trim() { Id = 61, CarModelId = 12, TrimName = "Sport" },
                    new Trim() { Id = 62, CarModelId = 13, TrimName = "GLi" },
                    new Trim() { Id = 63, CarModelId = 13, TrimName = "GLi Limited Edition" },
                    new Trim() { Id = 64, CarModelId = 13, TrimName = "GLi Vibe" },
                    new Trim() { Id = 65, CarModelId = 13, TrimName = "Vibe" },
                    new Trim() { Id = 66, CarModelId = 14, TrimName = "Luxury" },
                    new Trim() { Id = 67, CarModelId = 14, TrimName = "V6-L" },
                    new Trim() { Id = 68, CarModelId = 14, TrimName = "VTi" },
                    new Trim() { Id = 69, CarModelId = 15, TrimName = "GSi" },
                    new Trim() { Id = 70, CarModelId = 15, TrimName = "Luxury" },
                    new Trim() { Id = 71, CarModelId = 15, TrimName = "Type R" },
                    new Trim() { Id = 72, CarModelId = 15, TrimName = "Type S" }
                );

            //Body type
            builder.Entity<BodyType>()
                .HasData(
                    new BodyType() { Id = 1, BodyTypeName="Small Bus"},
                    new BodyType() { Id = 2, BodyTypeName = "Large Bus" },
                    new BodyType() { Id = 3, BodyTypeName = "Cab Chassis" },
                    new BodyType() { Id = 4, BodyTypeName = "Convertible" },
                    new BodyType() { Id = 5, BodyTypeName = "Coupe" },
                    new BodyType() { Id = 6, BodyTypeName = "Hatch" },
                    new BodyType() { Id = 7, BodyTypeName = "Light Truck" },
                    new BodyType() { Id = 8, BodyTypeName = "People Mover" },
                    new BodyType() { Id = 9, BodyTypeName = "Sedan" },
                    new BodyType() { Id = 10, BodyTypeName = "SUV" },
                    new BodyType() { Id = 11, BodyTypeName = "Ute" },
                    new BodyType() { Id = 12, BodyTypeName = "Van" },
                    new BodyType() { Id = 13, BodyTypeName = "Wagon" }
                );

            //Drive type
            builder.Entity<DriveType>()
                .HasData(
                    new DriveType() { Id = 1, DriveTypeName = "4x2" },
                    new DriveType() { Id = 2, DriveTypeName = "4x4" },
                    new DriveType() { Id = 3, DriveTypeName = "6x2" },
                    new DriveType() { Id = 4, DriveTypeName = "6x4" },
                    new DriveType() { Id = 5, DriveTypeName = "6x6" },
                    new DriveType() { Id = 6, DriveTypeName = "Front Wheel Drive" },
                    new DriveType() { Id = 7, DriveTypeName = "Rear Wheel Drive" }
                );

            //Fuel type
            builder.Entity<FuelType>()
                .HasData(
                    new FuelType() { Id = 1, FuelTypeName = "Diesel"},
                    new FuelType() { Id = 2, FuelTypeName = "Electric" },
                    new FuelType() { Id = 3, FuelTypeName = "Hybrid" },
                    new FuelType() { Id = 4, FuelTypeName = "LPG only" },
                    new FuelType() { Id = 5, FuelTypeName = "Petrol" },
                    new FuelType() { Id = 6, FuelTypeName = "Petrol - Premium ULP" }
                );

            //Purchase type
            builder.Entity<PurchaseType>()
                .HasData(
                    new PurchaseType() { Id = 1,PurchaseTypeName="Private Sale"},
                    new PurchaseType() { Id = 2, PurchaseTypeName = "Auction" }
                );

            //Color
            builder.Entity<Color>()
                .HasData(
                    new Color() { Id = 1, ColorName = "Beige"},
                    new Color() { Id = 2, ColorName = "Black" },
                    new Color() { Id = 3, ColorName = "Blue" },
                    new Color() { Id = 4, ColorName = "Bronze" },
                    new Color() { Id = 5, ColorName = "Brown" },
                    new Color() { Id = 6, ColorName = "Burgundy" },
                    new Color() { Id = 7, ColorName = "Gold" },
                    new Color() { Id = 8, ColorName = "Green" },
                    new Color() { Id = 9, ColorName = "Grey" },
                    new Color() { Id = 10, ColorName = "Magenta" },
                    new Color() { Id = 11, ColorName = "Maroon" },
                    new Color() { Id = 12, ColorName = "Orange" },
                    new Color() { Id = 13, ColorName = "Pink" },
                    new Color() { Id = 14, ColorName = "Purple" },
                    new Color() { Id = 15, ColorName = "Red" },
                    new Color() { Id = 16, ColorName = "Silver" },
                    new Color() { Id = 18, ColorName = "White" },
                    new Color() { Id = 19, ColorName = "Yellow" }
                );

            //Inventory Status
            builder.Entity<InventoryStatus>()
                .HasData(
                    new InventoryStatus() { Id=1, Status="Purchased"},
                    new InventoryStatus() { Id = 2, Status = "InRepair" },
                    new InventoryStatus() { Id = 3, Status = "Sold" },
                    new InventoryStatus() { Id = 4, Status = "Available" }
                );
        }
    }
}
