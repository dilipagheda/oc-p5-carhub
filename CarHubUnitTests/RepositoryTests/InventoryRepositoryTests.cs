using AutoMapper;
using CarHub.Data;
using CarHub.Data.Models;
using CarHub.Data.Repositories;
using CarHubUnitTests.Comparators;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

//Arrange

//Act

//Assert

namespace CarHubUnitTests.RepositoryTests
{
    public class InventoryRepositoryTests
    {
        private Mock<ApplicationDbContext> _mockContext;
        private Mock<IMapper> _mockMapper;
        private List<Inventory> _mockInventory;

        public InventoryRepositoryTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();
            _mockMapper = new Mock<IMapper>();

            _mockInventory = GetMockInventory();
            var mockDbSetInventory = _mockInventory.AsQueryable().BuildMockDbSet();

            _mockContext.SetupGet(x => x.InventoryList).Returns(mockDbSetInventory.Object);
        }

        public List<Inventory> GetMockInventory()
        {
            var carId1 = Guid.NewGuid();
            var carId2 = Guid.NewGuid();
            var carId3 = Guid.NewGuid();

            return new List<Inventory>()
            {
                new Inventory()
                {
                    Id = Guid.NewGuid(),
                    CarId = carId1,
                    SaleDate = new DateTime(2020, 10, 05),
                    SalePrice = 10000,
                    PurchaseDate = new DateTime(2020, 10, 05),
                    PurchasePrice = 5000,
                    PurchaseTypeId = 1,
                    InventoryStatusId = 1,
                    LotDate = new DateTime(2020, 10, 10),
                    IsFeatured = false,
                    Car =
                    new Car()
                        {
                            Id = carId1,
                            Year = 2019,
                            CarMakeId = 1,
                            CarModelId = 2,
                            TrimId = 1,
                            Kms = 15000,
                            TransmissionType = 'A',
                            RegoNumber = "XYZ",
                            RegoExpiry = new DateTime(2019, 12, 12),
                            Description = "Ok Car",
                            ColorId = 1,
                            BodyTypeId = 3,
                            NoOfSeats = 4,
                            NoOfCylinders = 4,
                            NoOfDoors = 5,
                            DriveTypeId = 2,
                            FuelTypeId = 3
                        },
                    InventoryStatus = new InventoryStatus() { Id = 1, Status = "Available" }
                },
                new Inventory()
                {
                    Id = Guid.NewGuid(),
                    CarId = carId2,
                    SaleDate = new DateTime(2020, 10, 06),
                    SalePrice = 15000,
                    PurchaseDate = new DateTime(2020, 10, 06),
                    PurchasePrice = 7000,
                    PurchaseTypeId = 1,
                    InventoryStatusId = 1,
                    LotDate = new DateTime(2020, 10, 10),
                    IsFeatured = false,
                    Car =
                    new Car()
                        {
                            Id = carId2,
                            Year = 2019,
                            CarMakeId = 1,
                            CarModelId = 2,
                            TrimId = 1,
                            Kms = 15000,
                            TransmissionType = 'A',
                            RegoNumber = "XYZ",
                            RegoExpiry = new DateTime(2019, 12, 12),
                            Description = "Ok Car",
                            ColorId = 1,
                            BodyTypeId = 3,
                            NoOfSeats = 4,
                            NoOfCylinders = 4,
                            NoOfDoors = 5,
                            DriveTypeId = 2,
                            FuelTypeId = 3
                        },
                    InventoryStatus = new InventoryStatus() { Id = 1, Status = "Available" }
                },
                new Inventory()
                {
                    Id = Guid.NewGuid(),
                    CarId = carId3,
                    SaleDate = new DateTime(2020, 10, 06),
                    SalePrice = 17000,
                    PurchaseDate = new DateTime(2020, 10, 06),
                    PurchasePrice = 9000,
                    PurchaseTypeId = 1,
                    InventoryStatusId = 3,
                    LotDate = new DateTime(2020, 10, 10),
                    IsFeatured = false,
                    Car =
                    new Car()
                        {
                            Id = carId3,
                            Year = 2019,
                            CarMakeId = 1,
                            CarModelId = 2,
                            TrimId = 1,
                            Kms = 15000,
                            TransmissionType = 'A',
                            RegoNumber = "XYZ",
                            RegoExpiry = new DateTime(2019, 12, 12),
                            Description = "Ok Car",
                            ColorId = 1,
                            BodyTypeId = 3,
                            NoOfSeats = 4,
                            NoOfCylinders = 4,
                            NoOfDoors = 5,
                            DriveTypeId = 2,
                            FuelTypeId = 3
                        },
                    InventoryStatus = new InventoryStatus() { Id = 3, Status = "Sold" }
                }
            };
        }

        [Fact]
        public void GetAllInventoryItems_ShouldReturnCorrectValues()
        {
            //Arrange
            var sut = new InventoryRepository(_mockContext.Object, _mockMapper.Object);

            //Act
            var returnedValue = sut.GetAllInventoryItems();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<Inventory>>(returnedValue);
            Assert.Equal(_mockInventory.Count, returnedValue.ToList().Count);
            Assert.Equal(_mockInventory, returnedValue.ToList(), new InventoryComparator());
        }

        [Fact]
        public void GetUnSoldInventoryItems_ShouldFilterOutSold()
        {
            //Arrange
            var sut = new InventoryRepository(_mockContext.Object, _mockMapper.Object);

            //Act
            var returnedValue = sut.GetUnSoldInventoryItems();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<Inventory>>(returnedValue);
            Assert.Equal(_mockInventory.Count - 1, returnedValue.ToList().Count);
            var soldItems = returnedValue.Where(x => x.InventoryStatusId == 3).ToList();
            Assert.Empty(soldItems);
        }

        [Fact]
        public void AddInventory_ParamNull()
        {
            //Arrange
            var sut = new InventoryRepository(_mockContext.Object, _mockMapper.Object);

            //Act
            var returnedValue = sut.AddInventory(null);

            //Assert
            Assert.Null(returnedValue);
            _mockContext.Verify(x => x.SaveChanges(), Times.Never);
        }

        [Fact]
        public void AddInventory_ParamNotNull()
        {
            //Arrange
            var sut = new InventoryRepository(_mockContext.Object, _mockMapper.Object);
            var carId = Guid.NewGuid();
            var itemToAdd = new Inventory()
            {
                CarId = carId,
                SaleDate = new DateTime(2020, 10, 06),
                SalePrice = 15000,
                PurchaseDate = new DateTime(2020, 10, 06),
                PurchasePrice = 7000,
                PurchaseTypeId = 1,
                InventoryStatusId = 1,
                LotDate = new DateTime(2020, 10, 10),
                IsFeatured = false,
                Car =
                new Car()
                    {
                        Id = carId,
                        Year = 2019,
                        CarMakeId = 1,
                        CarModelId = 2,
                        TrimId = 1,
                        Kms = 15000,
                        TransmissionType = 'A',
                        RegoNumber = "XYZ",
                        RegoExpiry = new DateTime(2019, 12, 12),
                        Description = "Ok Car",
                        ColorId = 1,
                        BodyTypeId = 3,
                        NoOfSeats = 4,
                        NoOfCylinders = 4,
                        NoOfDoors = 5,
                        DriveTypeId = 2,
                        FuelTypeId = 3
                    },
                InventoryStatus = new InventoryStatus() { Id = 1, Status = "Available" }
            };
            //Act
            var returnedValue = sut.AddInventory(itemToAdd);

            //Assert
            Assert.NotNull(returnedValue);
            Assert.IsType<Guid>(returnedValue);
            _mockContext.Verify(x => x.InventoryList.Add(It.IsAny<Inventory>()), Times.Once);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
