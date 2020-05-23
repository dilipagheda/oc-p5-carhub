using CarHub.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarHub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<BodyType> BodyTypes { get; set; }

        public virtual DbSet<CarMake> CarMakes { get; set; }

        public virtual DbSet<CarModel> CarModels { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<DriveType> DriveTypes { get; set; }

        public virtual DbSet<FuelType> FuelTypes { get; set; }

        public virtual DbSet<Inventory> InventoryList { get; set; }

        public virtual DbSet<InventoryMedia> InventoryMediaList { get; set; }

        public virtual DbSet<InventoryStatus> InventoryStatusList { get; set; }

        public virtual DbSet<Media> MediaList { get; set; }

        public virtual DbSet<PurchaseType> PurchaseTypes { get; set; }

        public virtual DbSet<Repair> Repairs { get; set; }

        public virtual DbSet<Trim> Trims { get; set; }

        public virtual DbSet<MakeModelTrim> MakeModelTrims { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<InventoryMedia>().HasKey(im => new { im.InventoryId, im.MediaId });

            builder.Entity<Car>()
                .HasOne(cm => cm.CarModel)
                .WithMany(cm => cm.Cars)
                .HasForeignKey(cm => cm.CarModelId)
                .OnDelete(DeleteBehavior.Cascade);

            //seed initial data
            builder.Entity<CarMake>()
                .HasData(new CarMake()
                { Id = 1, MakeName = "Toyota" },
                         new CarMake()
                { Id = 2, MakeName = "Honda" },
                         new CarMake()
                { Id = 3, MakeName = "Mazda" },
                         new CarMake()
                { Id = 4, MakeName = "Audi" },
                         new CarMake()
                { Id = 5, MakeName = "Nissan" },
                         new CarMake()
                { Id = 6, MakeName = "Holden" },
                         new CarMake()
                { Id = 7, MakeName = "BMW" },
                         new CarMake()
                { Id = 8, MakeName = "Mitsubishi" },
                         new CarMake()
                { Id = 9, MakeName = "Hyundai" },
                         new CarMake()
                { Id = 10, MakeName = "Mercedes-Benz" });


            builder.Entity<CarModel>()
                .HasData(
                    //Toyota 1
                    new CarModel()
                { Id = 1, ModelName = "Camry" },
                    new CarModel()
                { Id = 2, ModelName = "Corolla" },
                    new CarModel()
                { Id = 3, ModelName = "Hiace" },
                    new CarModel()
                { Id = 4, ModelName = "Hilux" },
                    new CarModel()
                { Id = 5, ModelName = "Kluger" },
                    new CarModel()
                { Id = 6, ModelName = "Landcruiser" },
                    //Honda 2
                    new CarModel()
                { Id = 7, ModelName = "Accord" },
                    new CarModel()
                { Id = 8, ModelName = "Accord Euro" },
                    new CarModel()
                { Id = 9, ModelName = "City" },
                    new CarModel()
                { Id = 10, ModelName = "Civic" },
                    new CarModel()
                { Id = 11, ModelName = "CR-V" },
                    new CarModel()
                { Id = 12, ModelName = "HR-V" },
                    new CarModel()
                { Id = 13, ModelName = "Jazz" },
                    new CarModel()
                { Id = 14, ModelName = "Odyssey" },
                    new CarModel()
                { Id = 15, ModelName = "Integra" },
                    //Mazda 3
                    new CarModel()
                { Id = 16, ModelName = "2" },
                    new CarModel()
                { Id = 17, ModelName = "3" },
                    new CarModel()
                { Id = 18, ModelName = "6" },
                    new CarModel()
                { Id = 19, ModelName = "BT-50" },
                    new CarModel()
                { Id = 20, ModelName = "CX-3" },
                    new CarModel()
                { Id = 21, ModelName = "CX-5" },
                    new CarModel()
                { Id = 22, ModelName = "CX-7" },
                    new CarModel()
                { Id = 23, ModelName = "CX-9" },
                    new CarModel()
                { Id = 24, ModelName = "MX-5" },
                    //Audi 4
                    new CarModel()
                { Id = 25, ModelName = "A1" },
                    new CarModel()
                { Id = 26, ModelName = "A3" },
                    new CarModel()
                { Id = 27, ModelName = "A4" },
                    new CarModel()
                { Id = 28, ModelName = "A5" },
                    new CarModel()
                { Id = 29, ModelName = "A6" },
                    //Nissan 5
                    new CarModel()
                { Id = 30, ModelName = "370Z" },
                    new CarModel()
                { Id = 31, ModelName = "Dualis" },
                    new CarModel()
                { Id = 32, ModelName = "Elgrand" },
                    new CarModel()
                { Id = 33, ModelName = "JUKE" },
                    new CarModel()
                { Id = 34, ModelName = "Navara" },
                    new CarModel()
                { Id = 35, ModelName = "Pathfinder" },
                    new CarModel()
                { Id = 36, ModelName = "Patrol" },
                    new CarModel()
                { Id = 37, ModelName = "Pulsar" },
                    //Holden 6
                    new CarModel()
                { Id = 38, ModelName = "Acadia" },
                    new CarModel()
                { Id = 39, ModelName = "Astra" },
                    new CarModel()
                { Id = 40, ModelName = "Calais" },
                    new CarModel()
                { Id = 41, ModelName = "Captiva" },
                    new CarModel()
                { Id = 42, ModelName = "Colorado" },
                    new CarModel()
                { Id = 43, ModelName = "Commodore" },
                    new CarModel()
                { Id = 44, ModelName = "Cruze" },
                    //BMW 7
                    new CarModel()
                { Id = 45, ModelName = "1 Series" },
                    new CarModel()
                { Id = 46, ModelName = "2 Series" },
                    new CarModel()
                { Id = 47, ModelName = "3 Series" },
                    new CarModel()
                { Id = 48, ModelName = "4 Series" },
                    //Mitsubishi 8
                    new CarModel()
                { Id = 49, ModelName = "ASX" },
                    new CarModel()
                { Id = 50, ModelName = "Challenger" },
                    new CarModel()
                { Id = 51, ModelName = "Lancer" },
                    //Hyundai 9
                    new CarModel()
                { Id = 52, ModelName = "Accent" },
                    new CarModel()
                { Id = 53, ModelName = "Elantra" },
                    new CarModel()
                { Id = 54, ModelName = "i30" },
                    //Mercedes-Benz 10
                    new CarModel()
                { Id = 55, ModelName = "A-Class" },
                    new CarModel()
                { Id = 56, ModelName = "C-Class" },
                    new CarModel()
                { Id = 57, ModelName = "CLA-Class" },
                    new CarModel()
                { Id = 58, ModelName = "E-Class" },
                    new CarModel()
                { Id = 59, ModelName = "GLA-Class" });

            builder.Entity<Trim>()
                .HasData(
                    //Toyota , model-1
                    new Trim()
                { Id = 1, TrimName = "Altise" },
                    new Trim()
                { Id = 2, TrimName = "Ascent" },
                    new Trim()
                { Id = 3, TrimName = "Ascent Sport" },
                    new Trim()
                { Id = 4, TrimName = "Atara S" },
                    new Trim()
                { Id = 5, TrimName = "Atara SL" },
                    new Trim()
                { Id = 6, TrimName = "CSi" },
                    new Trim()
                { Id = 7, TrimName = "RZ" },
                    new Trim()
                { Id = 8, TrimName = "SL" },
                    new Trim()
                { Id = 9, TrimName = "Sportivo" },

                    //Toyota , modelId-2
                    new Trim()
                { Id = 10, TrimName = "Ascent" },
                    new Trim()
                { Id = 11, TrimName = "Ascent Sport" },
                    new Trim()
                { Id = 12, TrimName = "Ascent Sport Hybrid" },
                    new Trim()
                { Id = 13, TrimName = "Conquest" },
                    new Trim()
                { Id = 14, TrimName = "Hybrid" },
                    new Trim()
                { Id = 15, TrimName = "Levin SX" },
                    new Trim()
                { Id = 16, TrimName = "Levin ZR" },
                    //Toyota , modelId-3
                    new Trim()
                { Id = 17, TrimName = "Commuter" },
                    new Trim()
                { Id = 18, TrimName = "Commuter GL" },
                    new Trim()
                { Id = 19, TrimName = "Grand Cabin GL" },
                    new Trim()
                { Id = 20, TrimName = "Super Custom" },
                    //Toyota , modelId-4
                    new Trim()
                { Id = 21, TrimName = "DX" },
                    new Trim()
                { Id = 22, TrimName = "Rogue" },
                    new Trim()
                { Id = 23, TrimName = "Rugged X" },
                    new Trim()
                { Id = 24, TrimName = "SR" },
                    new Trim()
                { Id = 25, TrimName = "SR5" },
                    new Trim()
                { Id = 26, TrimName = "SR5 Hi-Rider" },
                    //Toyota , modelId-5
                    new Trim()
                { Id = 27, TrimName = "Altitude" },
                    new Trim()
                { Id = 28, TrimName = "Black Edition" },
                    new Trim()
                { Id = 29, TrimName = "CV" },
                    new Trim()
                { Id = 30, TrimName = "CV Sport" },
                    new Trim()
                { Id = 31, TrimName = "CVX" },
                    new Trim()
                { Id = 32, TrimName = "Grande" },
                    //Toyota , modelId-6
                    new Trim()
                { Id = 33, TrimName = "Altitude" },
                    new Trim()
                { Id = 34, TrimName = "GX" },
                    new Trim()
                { Id = 35, TrimName = "GXL" },
                    new Trim()
                { Id = 36, TrimName = "GXL Troopcarrier" },
                    new Trim()
                { Id = 37, TrimName = "Sahara" },
                    new Trim()
                { Id = 38, TrimName = "Standard" },
                    new Trim()
                { Id = 39, TrimName = "VX" },
                    new Trim()
                { Id = 40, TrimName = "Workmate" },

                    //Honda modelId 7
                    new Trim()
                { Id = 41, TrimName = "EXi" },
                    new Trim()
                { Id = 42, TrimName = "Limited Edition" },
                    new Trim()
                { Id = 43, TrimName = "V6" },
                    new Trim()
                { Id = 44, TrimName = "V6L" },
                    //Honda modelId 8
                    new Trim()
                { Id = 45, TrimName = "Limited Edition" },
                    new Trim()
                { Id = 46, TrimName = "Luxury" },
                    new Trim()
                { Id = 47, TrimName = "Luxury Navi" },
                    new Trim()
                { Id = 48, TrimName = "Sport" },
                    //Honda modelId 9
                    new Trim()
                { Id = 49, TrimName = "VTi" },
                    new Trim()
                { Id = 50, TrimName = "VTi-L" },
                    //Honda modelId 10
                    new Trim()
                { Id = 51, TrimName = "GLi" },
                    new Trim()
                { Id = 52, TrimName = "RS" },
                    new Trim()
                { Id = 53, TrimName = "Si" },
                    new Trim()
                { Id = 54, TrimName = "Sport" },
                    //Honda modelId 11
                    new Trim()
                { Id = 55, TrimName = "Limited Edition" },
                    new Trim()
                { Id = 56, TrimName = "Luxury" },
                    new Trim()
                { Id = 57, TrimName = "Sport" },
                    //Honda modelId 12
                    new Trim()
                { Id = 58, TrimName = "50 Years Edition" },
                    new Trim()
                { Id = 59, TrimName = "Limited Edition" },
                    new Trim()
                { Id = 60, TrimName = "RS" },
                    new Trim()
                { Id = 61, TrimName = "Sport" },
                    //Honda modelId 13
                    new Trim()
                { Id = 62, TrimName = "GLi" },
                    new Trim()
                { Id = 63, TrimName = "GLi Limited Edition" },
                    new Trim()
                { Id = 64, TrimName = "GLi Vibe" },
                    new Trim()
                { Id = 65, TrimName = "Vibe" },
                    //Honda modelId 14
                    new Trim()
                { Id = 66, TrimName = "Luxury" },
                    new Trim()
                { Id = 67, TrimName = "V6-L" },
                    new Trim()
                { Id = 68, TrimName = "VTi" },
                    //Honda modelId 15
                    new Trim()
                { Id = 69, TrimName = "GSi" },
                    new Trim()
                { Id = 70, TrimName = "Luxury" },
                    new Trim()
                { Id = 71, TrimName = "Type R" },
                    new Trim()
                { Id = 72, TrimName = "Type S" });


            builder.Entity<MakeModelTrim>()
                .HasData(new MakeModelTrim()
                { Id = 1, CarMakeId = 1, CarModelId = 1, TrimId = 1 },
                         new MakeModelTrim()
                { Id = 2, CarMakeId = 1, CarModelId = 1, TrimId = 2 },
                         new MakeModelTrim()
                { Id = 3, CarMakeId = 1, CarModelId = 1, TrimId = 3 },
                         new MakeModelTrim()
                { Id = 4, CarMakeId = 1, CarModelId = 1, TrimId = 4 },
                         new MakeModelTrim()
                { Id = 5, CarMakeId = 1, CarModelId = 1, TrimId = 5 },
                         new MakeModelTrim()
                { Id = 6, CarMakeId = 1, CarModelId = 1, TrimId = 6 },
                         new MakeModelTrim()
                { Id = 7, CarMakeId = 1, CarModelId = 1, TrimId = 7 },
                         new MakeModelTrim()
                { Id = 8, CarMakeId = 1, CarModelId = 1, TrimId = 8 },
                         new MakeModelTrim()
                { Id = 9, CarMakeId = 1, CarModelId = 1, TrimId = 9 },

                         new MakeModelTrim()
                { Id = 10, CarMakeId = 1, CarModelId = 2, TrimId = 10 },
                         new MakeModelTrim()
                { Id = 11, CarMakeId = 1, CarModelId = 2, TrimId = 11 },
                         new MakeModelTrim()
                { Id = 12, CarMakeId = 1, CarModelId = 2, TrimId = 12 },
                         new MakeModelTrim()
                { Id = 13, CarMakeId = 1, CarModelId = 2, TrimId = 13 },
                         new MakeModelTrim()
                { Id = 14, CarMakeId = 1, CarModelId = 2, TrimId = 14 },
                         new MakeModelTrim()
                { Id = 15, CarMakeId = 1, CarModelId = 2, TrimId = 15 },
                         new MakeModelTrim()
                { Id = 16, CarMakeId = 1, CarModelId = 2, TrimId = 16 },

                         new MakeModelTrim()
                { Id = 17, CarMakeId = 1, CarModelId = 3, TrimId = 17 },
                         new MakeModelTrim()
                { Id = 18, CarMakeId = 1, CarModelId = 3, TrimId = 18 },
                         new MakeModelTrim()
                { Id = 19, CarMakeId = 1, CarModelId = 3, TrimId = 19 },
                         new MakeModelTrim()
                { Id = 20, CarMakeId = 1, CarModelId = 3, TrimId = 20 },

                         new MakeModelTrim()
                { Id = 21, CarMakeId = 1, CarModelId = 4, TrimId = 21 },
                         new MakeModelTrim()
                { Id = 22, CarMakeId = 1, CarModelId = 4, TrimId = 22 },
                         new MakeModelTrim()
                { Id = 23, CarMakeId = 1, CarModelId = 4, TrimId = 23 },
                         new MakeModelTrim()
                { Id = 24, CarMakeId = 1, CarModelId = 4, TrimId = 24 },
                         new MakeModelTrim()
                { Id = 25, CarMakeId = 1, CarModelId = 4, TrimId = 25 },
                         new MakeModelTrim()
                { Id = 26, CarMakeId = 1, CarModelId = 4, TrimId = 26 },


                         new MakeModelTrim()
                { Id = 27, CarMakeId = 1, CarModelId = 5, TrimId = 27 },
                         new MakeModelTrim()
                { Id = 28, CarMakeId = 1, CarModelId = 5, TrimId = 28 },
                         new MakeModelTrim()
                { Id = 29, CarMakeId = 1, CarModelId = 5, TrimId = 29 },
                         new MakeModelTrim()
                { Id = 30, CarMakeId = 1, CarModelId = 5, TrimId = 30 },
                         new MakeModelTrim()
                { Id = 31, CarMakeId = 1, CarModelId = 5, TrimId = 31 },
                         new MakeModelTrim()
                { Id = 32, CarMakeId = 1, CarModelId = 5, TrimId = 32 },


                         new MakeModelTrim()
                { Id = 33, CarMakeId = 1, CarModelId = 6, TrimId = 33 },
                         new MakeModelTrim()
                { Id = 34, CarMakeId = 1, CarModelId = 6, TrimId = 34 },
                         new MakeModelTrim()
                { Id = 35, CarMakeId = 1, CarModelId = 6, TrimId = 35 },
                         new MakeModelTrim()
                { Id = 36, CarMakeId = 1, CarModelId = 6, TrimId = 36 },
                         new MakeModelTrim()
                { Id = 37, CarMakeId = 1, CarModelId = 6, TrimId = 37 },
                         new MakeModelTrim()
                { Id = 38, CarMakeId = 1, CarModelId = 6, TrimId = 38 },
                         new MakeModelTrim()
                { Id = 39, CarMakeId = 1, CarModelId = 6, TrimId = 39 },
                         new MakeModelTrim()
                { Id = 40, CarMakeId = 1, CarModelId = 6, TrimId = 40 },

                         //////
                         new MakeModelTrim()
                { Id = 41, CarMakeId = 2, CarModelId = 7, TrimId = 41 },
                         new MakeModelTrim()
                { Id = 42, CarMakeId = 2, CarModelId = 7, TrimId = 42 },
                         new MakeModelTrim()
                { Id = 43, CarMakeId = 2, CarModelId = 7, TrimId = 43 },
                         new MakeModelTrim()
                { Id = 44, CarMakeId = 2, CarModelId = 7, TrimId = 44 },

                         new MakeModelTrim()
                { Id = 45, CarMakeId = 2, CarModelId = 8, TrimId = 45 },
                         new MakeModelTrim()
                { Id = 46, CarMakeId = 2, CarModelId = 8, TrimId = 46 },
                         new MakeModelTrim()
                { Id = 47, CarMakeId = 2, CarModelId = 8, TrimId = 47 },
                         new MakeModelTrim()
                { Id = 48, CarMakeId = 2, CarModelId = 8, TrimId = 48 },

                         new MakeModelTrim()
                { Id = 49, CarMakeId = 2, CarModelId = 9, TrimId = 49 },
                         new MakeModelTrim()
                { Id = 50, CarMakeId = 2, CarModelId = 9, TrimId = 50 },

                         new MakeModelTrim()
                { Id = 51, CarMakeId = 2, CarModelId = 10, TrimId = 51 },
                         new MakeModelTrim()
                { Id = 52, CarMakeId = 2, CarModelId = 10, TrimId = 52 },
                         new MakeModelTrim()
                { Id = 53, CarMakeId = 2, CarModelId = 10, TrimId = 53 },
                         new MakeModelTrim()
                { Id = 54, CarMakeId = 2, CarModelId = 10, TrimId = 54 },

                         new MakeModelTrim()
                { Id = 55, CarMakeId = 2, CarModelId = 11, TrimId = 55 },
                         new MakeModelTrim()
                { Id = 56, CarMakeId = 2, CarModelId = 11, TrimId = 56 },
                         new MakeModelTrim()
                { Id = 57, CarMakeId = 2, CarModelId = 11, TrimId = 57 },

                         new MakeModelTrim()
                { Id = 58, CarMakeId = 2, CarModelId = 12, TrimId = 58 },
                         new MakeModelTrim()
                { Id = 59, CarMakeId = 2, CarModelId = 12, TrimId = 59 },
                         new MakeModelTrim()
                { Id = 60, CarMakeId = 2, CarModelId = 12, TrimId = 60 },
                         new MakeModelTrim()
                { Id = 61, CarMakeId = 2, CarModelId = 12, TrimId = 61 },

                         new MakeModelTrim()
                { Id = 62, CarMakeId = 2, CarModelId = 13, TrimId = 62 },
                         new MakeModelTrim()
                { Id = 63, CarMakeId = 2, CarModelId = 13, TrimId = 63 },
                         new MakeModelTrim()
                { Id = 64, CarMakeId = 2, CarModelId = 13, TrimId = 64 },
                         new MakeModelTrim()
                { Id = 65, CarMakeId = 2, CarModelId = 13, TrimId = 65 },

                         new MakeModelTrim()
                { Id = 66, CarMakeId = 2, CarModelId = 14, TrimId = 66 },
                         new MakeModelTrim()
                { Id = 67, CarMakeId = 2, CarModelId = 14, TrimId = 67 },
                         new MakeModelTrim()
                { Id = 68, CarMakeId = 2, CarModelId = 14, TrimId = 68 },

                         new MakeModelTrim()
                { Id = 69, CarMakeId = 2, CarModelId = 15, TrimId = 69 },
                         new MakeModelTrim()
                { Id = 70, CarMakeId = 2, CarModelId = 15, TrimId = 70 },
                         new MakeModelTrim()
                { Id = 71, CarMakeId = 2, CarModelId = 15, TrimId = 71 },
                         new MakeModelTrim()
                { Id = 72, CarMakeId = 2, CarModelId = 15, TrimId = 72 },

                         /////
                         new MakeModelTrim()
                { Id = 73, CarMakeId = 3, CarModelId = 16 },
                         new MakeModelTrim()
                { Id = 74, CarMakeId = 3, CarModelId = 17 },
                         new MakeModelTrim()
                { Id = 75, CarMakeId = 3, CarModelId = 18 },
                         new MakeModelTrim()
                { Id = 76, CarMakeId = 3, CarModelId = 19 },
                         new MakeModelTrim()
                { Id = 77, CarMakeId = 3, CarModelId = 20 },
                         new MakeModelTrim()
                { Id = 78, CarMakeId = 3, CarModelId = 21 },
                         new MakeModelTrim()
                { Id = 79, CarMakeId = 3, CarModelId = 22 },
                         new MakeModelTrim()
                { Id = 80, CarMakeId = 3, CarModelId = 23 },
                         new MakeModelTrim()
                { Id = 81, CarMakeId = 3, CarModelId = 24 },

                         new MakeModelTrim()
                { Id = 82, CarMakeId = 4, CarModelId = 25 },
                         new MakeModelTrim()
                { Id = 83, CarMakeId = 4, CarModelId = 26 },
                         new MakeModelTrim()
                { Id = 84, CarMakeId = 4, CarModelId = 27 },
                         new MakeModelTrim()
                { Id = 85, CarMakeId = 4, CarModelId = 28 },
                         new MakeModelTrim()
                { Id = 86, CarMakeId = 4, CarModelId = 29 },

                         new MakeModelTrim()
                { Id = 87, CarMakeId = 5, CarModelId = 30 },
                         new MakeModelTrim()
                { Id = 88, CarMakeId = 5, CarModelId = 31 },
                         new MakeModelTrim()
                { Id = 89, CarMakeId = 5, CarModelId = 32 },
                         new MakeModelTrim()
                { Id = 90, CarMakeId = 5, CarModelId = 33 },
                         new MakeModelTrim()
                { Id = 91, CarMakeId = 5, CarModelId = 34 },
                         new MakeModelTrim()
                { Id = 92, CarMakeId = 5, CarModelId = 35 },
                         new MakeModelTrim()
                { Id = 93, CarMakeId = 5, CarModelId = 36 },
                         new MakeModelTrim()
                { Id = 94, CarMakeId = 5, CarModelId = 37 },

                         new MakeModelTrim()
                { Id = 95, CarMakeId = 6, CarModelId = 38 },
                         new MakeModelTrim()
                { Id = 96, CarMakeId = 6, CarModelId = 39 },
                         new MakeModelTrim()
                { Id = 97, CarMakeId = 6, CarModelId = 40 },
                         new MakeModelTrim()
                { Id = 98, CarMakeId = 6, CarModelId = 41 },
                         new MakeModelTrim()
                { Id = 99, CarMakeId = 6, CarModelId = 42 },
                         new MakeModelTrim()
                { Id = 100, CarMakeId = 6, CarModelId = 43 },
                         new MakeModelTrim()
                { Id = 101, CarMakeId = 6, CarModelId = 44 },

                         new MakeModelTrim()
                { Id = 102, CarMakeId = 7, CarModelId = 45 },
                         new MakeModelTrim()
                { Id = 103, CarMakeId = 7, CarModelId = 46 },
                         new MakeModelTrim()
                { Id = 104, CarMakeId = 7, CarModelId = 47 },
                         new MakeModelTrim()
                { Id = 105, CarMakeId = 7, CarModelId = 48 },

                         new MakeModelTrim()
                { Id = 106, CarMakeId = 8, CarModelId = 49 },
                         new MakeModelTrim()
                { Id = 107, CarMakeId = 8, CarModelId = 50 },
                         new MakeModelTrim()
                { Id = 108, CarMakeId = 8, CarModelId = 51 },

                         new MakeModelTrim()
                { Id = 109, CarMakeId = 9, CarModelId = 52 },
                         new MakeModelTrim()
                { Id = 110, CarMakeId = 9, CarModelId = 53 },
                         new MakeModelTrim()
                { Id = 111, CarMakeId = 9, CarModelId = 54 },

                         new MakeModelTrim()
                { Id = 112, CarMakeId = 10, CarModelId = 55 },
                         new MakeModelTrim()
                { Id = 113, CarMakeId = 10, CarModelId = 56 },
                         new MakeModelTrim()
                { Id = 114, CarMakeId = 10, CarModelId = 57 },
                         new MakeModelTrim()
                { Id = 115, CarMakeId = 10, CarModelId = 58 },
                         new MakeModelTrim()
                { Id = 116, CarMakeId = 10, CarModelId = 59 }

                );
            //Body type
            builder.Entity<BodyType>()
                .HasData(new BodyType()
                { Id = 1, BodyTypeName = "Small Bus" },
                         new BodyType()
                { Id = 2, BodyTypeName = "Large Bus" },
                         new BodyType()
                { Id = 3, BodyTypeName = "Cab Chassis" },
                         new BodyType()
                { Id = 4, BodyTypeName = "Convertible" },
                         new BodyType()
                { Id = 5, BodyTypeName = "Coupe" },
                         new BodyType()
                { Id = 6, BodyTypeName = "Hatch" },
                         new BodyType()
                { Id = 7, BodyTypeName = "Light Truck" },
                         new BodyType()
                { Id = 8, BodyTypeName = "People Mover" },
                         new BodyType()
                { Id = 9, BodyTypeName = "Sedan" },
                         new BodyType()
                { Id = 10, BodyTypeName = "SUV" },
                         new BodyType()
                { Id = 11, BodyTypeName = "Ute" },
                         new BodyType()
                { Id = 12, BodyTypeName = "Van" },
                         new BodyType()
                { Id = 13, BodyTypeName = "Wagon" });

            //Drive type
            builder.Entity<DriveType>()
                .HasData(new DriveType()
                { Id = 1, DriveTypeName = "4x2" },
                         new DriveType()
                { Id = 2, DriveTypeName = "4x4" },
                         new DriveType()
                { Id = 3, DriveTypeName = "6x2" },
                         new DriveType()
                { Id = 4, DriveTypeName = "6x4" },
                         new DriveType()
                { Id = 5, DriveTypeName = "6x6" },
                         new DriveType()
                { Id = 6, DriveTypeName = "Front Wheel Drive" },
                         new DriveType()
                { Id = 7, DriveTypeName = "Rear Wheel Drive" });

            //Fuel type
            builder.Entity<FuelType>()
                .HasData(new FuelType()
                { Id = 1, FuelTypeName = "Diesel" },
                         new FuelType()
                { Id = 2, FuelTypeName = "Electric" },
                         new FuelType()
                { Id = 3, FuelTypeName = "Hybrid" },
                         new FuelType()
                { Id = 4, FuelTypeName = "LPG only" },
                         new FuelType()
                { Id = 5, FuelTypeName = "Petrol" },
                         new FuelType()
                { Id = 6, FuelTypeName = "Petrol - Premium ULP" });

            //Purchase type
            builder.Entity<PurchaseType>()
                .HasData(new PurchaseType()
                { Id = 1, PurchaseTypeName = "Private Sale" },
                         new PurchaseType()
                { Id = 2, PurchaseTypeName = "Auction" });

            //Color
            builder.Entity<Color>()
                .HasData(new Color()
                { Id = 1, ColorName = "Beige" },
                         new Color()
                { Id = 2, ColorName = "Black" },
                         new Color()
                { Id = 3, ColorName = "Blue" },
                         new Color()
                { Id = 4, ColorName = "Bronze" },
                         new Color()
                { Id = 5, ColorName = "Brown" },
                         new Color()
                { Id = 6, ColorName = "Burgundy" },
                         new Color()
                { Id = 7, ColorName = "Gold" },
                         new Color()
                { Id = 8, ColorName = "Green" },
                         new Color()
                { Id = 9, ColorName = "Grey" },
                         new Color()
                { Id = 10, ColorName = "Magenta" },
                         new Color()
                { Id = 11, ColorName = "Maroon" },
                         new Color()
                { Id = 12, ColorName = "Orange" },
                         new Color()
                { Id = 13, ColorName = "Pink" },
                         new Color()
                { Id = 14, ColorName = "Purple" },
                         new Color()
                { Id = 15, ColorName = "Red" },
                         new Color()
                { Id = 16, ColorName = "Silver" },
                         new Color()
                { Id = 18, ColorName = "White" },
                         new Color()
                { Id = 19, ColorName = "Yellow" });

            //Inventory Status
            builder.Entity<InventoryStatus>()
                .HasData(new InventoryStatus()
                { Id = 1, Status = "Purchased" },
                         new InventoryStatus()
                { Id = 2, Status = "InRepair" },
                         new InventoryStatus()
                { Id = 3, Status = "Sold" },
                         new InventoryStatus()
                { Id = 4, Status = "Available" });
        }
    }
}
