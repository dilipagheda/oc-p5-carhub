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
                
        }
    }
}
