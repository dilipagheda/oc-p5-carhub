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
    public class CarRepositoryTests
    {
        private Mock<ApplicationDbContext> _mockContext;
        private Mock<IMapper> _mockMapper;
        private List<Car> _mockCars;

        public CarRepositoryTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();
            _mockMapper = new Mock<IMapper>();

            _mockCars = GetMockCars();
            var mockDbSetCars = _mockCars.AsQueryable().BuildMockDbSet();

            var makeModelTrims = GetMockMakeModelTrims();
            var mockDbSetMakeModelTrims = makeModelTrims.AsQueryable().BuildMockDbSet();

            _mockContext.SetupGet(x => x.MakeModelTrims).Returns(mockDbSetMakeModelTrims.Object);
            _mockContext.SetupGet(x => x.Cars).Returns(mockDbSetCars.Object);
        }


        public List<MakeModelTrim> GetMockMakeModelTrims()
        {
            return new List<MakeModelTrim>()
            {
                new MakeModelTrim()
                { Id = 1, CarMakeId = 1, CarModelId = 1, TrimId = 1 },
                new MakeModelTrim()
                { Id = 2, CarMakeId = 2, CarModelId = 2, TrimId = 2 },
                new MakeModelTrim()
                { Id = 3, CarMakeId = 3, CarModelId = 3, TrimId = 3 },
                new MakeModelTrim()
                { Id = 4, CarMakeId = 2, CarModelId = 4, TrimId = 2 }
            };
        }

        public List<Car> GetMockCars()
        {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            return new List<Car>()
            {
                new Car()
                {
                    Id = id1,
                    Year = 2020,
                    CarMakeId = 1,
                    CarModelId = 2,
                    TrimId = 1,
                    Kms = 10000,
                    TransmissionType = 'A',
                    RegoNumber = "ABCD",
                    RegoExpiry = new DateTime(2020, 12, 12),
                    Description = "Great Car",
                    ColorId = 1,
                    BodyTypeId = 3,
                    NoOfSeats = 4,
                    NoOfCylinders = 4,
                    NoOfDoors = 5,
                    DriveTypeId = 2,
                    FuelTypeId = 3
                },
                new Car()
                {
                    Id = id2,
                    Year = 2019,
                    CarMakeId = 1,
                    CarModelId = 2,
                    TrimId = 1,
                    Kms = 15000,
                    TransmissionType = 'A',
                    RegoNumber = "EFGH",
                    RegoExpiry = new DateTime(2019, 12, 12),
                    Description = "Ok Car",
                    ColorId = 1,
                    BodyTypeId = 3,
                    NoOfSeats = 4,
                    NoOfCylinders = 4,
                    NoOfDoors = 5,
                    DriveTypeId = 2,
                    FuelTypeId = 3
                }
            };
        }

        [Fact]
        public void GetAllCars_ShouldReturnCorrectValues()
        {
            //Arrange
            var sut = new CarRepository(_mockContext.Object, _mockMapper.Object);

            //Act
            var returnedValue = sut.GetAllCars();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<Car>>(returnedValue);
            Assert.Equal(_mockCars.Count, returnedValue.ToList().Count);
            Assert.Equal(_mockCars, returnedValue.ToList(), new CarComparator());
        }


        [Fact]
        public void GetCarById_ParamNull()
        {
            //Arrange
            var sut = new CarRepository(_mockContext.Object, _mockMapper.Object);
            //Act
            var returnedValue = sut.GetCarById(null);

            //Assert
            Assert.Null(returnedValue);
        }

        [Fact]
        public void GetCarById_ParamNotNull()
        {
            //Arrange
            var sut = new CarRepository(_mockContext.Object, _mockMapper.Object);
            var expected = _mockCars.First();
            //Act
            var returnedValue = sut.GetCarById(expected.Id.ToString());

            //Assert
            Assert.Equal(expected, returnedValue, new CarComparator());
        }

        [Fact]
        public void AddNewCar_CarObj_IsNull()
        {
            //Arrange
            var sut = new CarRepository(_mockContext.Object, _mockMapper.Object);

            //Act
            var returnedValue = sut.AddNewCar(null);

            //Assert
            Assert.Null(returnedValue);
            _mockContext.Verify(x => x.Cars.Add(It.IsAny<Car>()), Times.Never);
            _mockContext.Verify(x => x.SaveChanges(), Times.Never);
        }

        [Fact]
        public void AddNewCar_CarObj_IsNotNull()
        {
            //Arrange
            var sut = new CarRepository(_mockContext.Object, _mockMapper.Object);
            var expected = new Car()
            {
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
            };

            //Act
            var returnedValue = sut.AddNewCar(expected);

            //Assert
            Assert.IsType<Guid>(returnedValue);
            Assert.NotNull(returnedValue);
            _mockContext.Verify(x => x.Cars.Add(It.IsAny<Car>()), Times.Once);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void EditCar_CarObj_IsNull()
        {
            //Arrange
            var sut = new CarRepository(_mockContext.Object, _mockMapper.Object);

            //Act
            sut.EditCar("something random", null);

            //Assert
            _mockContext.Verify(x => x.SaveChanges(), Times.Never);
        }

        [Fact]
        public void EditCar_CarObj_IsNotNull_IdNotFound()
        {
            //Arrange
            var sut = new CarRepository(_mockContext.Object, _mockMapper.Object);

            //Act
            sut.EditCar("something random", It.IsAny<Car>());

            //Assert
            _mockMapper.Verify(x => x.Map(It.IsAny<Car>(), It.IsAny<Car>(), typeof(Car), typeof(Car)), Times.Never);
            _mockContext.Verify(x => x.SaveChanges(), Times.Never);
        }

        [Fact]
        public void EditCar_CarObj_IsNotNull_IdFound()
        {
            //Arrange
            var sut = new CarRepository(_mockContext.Object, _mockMapper.Object);
            var itemToEdit = _mockCars.First();
            var itemToEditWith = new Car()
            {
                Year = 2019,
                CarMakeId = 1,
                CarModelId = 2,
                TrimId = 1,
                Kms = 50000,
                TransmissionType = 'A',
                RegoNumber = "XYZD",
                RegoExpiry = new DateTime(2019, 12, 12),
                Description = "Fine Car",
                ColorId = 1,
                BodyTypeId = 3,
                NoOfSeats = 4,
                NoOfCylinders = 4,
                NoOfDoors = 5,
                DriveTypeId = 2,
                FuelTypeId = 3
            };
            _mockMapper.Setup(x => x.Map<Car, Car>(It.IsAny<Car>())).Returns(itemToEditWith);
            var iStateManager = new Mock<IStateManager>();
            var model = new Mock<Model>();

            var carEntityEntry = new Mock<EntityEntry<Car>>(new InternalShadowEntityEntry(iStateManager.Object,
                                                                                          new EntityType("Car",
                                                                                                         model.Object,
                                                                                                         ConfigurationSource.Convention)));

            carEntityEntry.SetupGet(m => m.Entity).Returns(itemToEditWith);

            _mockContext.Setup(x => x.Entry<Car>(It.IsAny<Car>())).Returns(carEntityEntry.Object);
            //Act
            sut.EditCar(itemToEdit.Id.ToString(), itemToEditWith);

            //Assert
            _mockMapper.Verify(x => x.Map(It.IsAny<Car>(), It.IsAny<Car>(), typeof(Car), typeof(Car)), Times.Once);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void AddMakeModelTrim_BadParams()
        {
            //Arrange
            var sut = new CarRepository(_mockContext.Object, _mockMapper.Object);

            //Act
            sut.AddMakeModelTrim(-1, 0, -1);

            //Assert
            _mockContext.Verify(x => x.MakeModelTrims.Add(It.IsAny<MakeModelTrim>()), Times.Never);
            _mockContext.Verify(x => x.SaveChanges(), Times.Never);
        }

        [Fact]
        public void AddMakeModelTrim_ValidParams_NotFound()
        {
            //Arrange
            var sut = new CarRepository(_mockContext.Object, _mockMapper.Object);

            //Act
            sut.AddMakeModelTrim(10, 1, 1);

            //Assert
            _mockContext.Verify(x => x.MakeModelTrims.Add(It.IsAny<MakeModelTrim>()), Times.Once);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void AddMakeModelTrim_ValidParams_Found()
        {
            //Arrange
            var sut = new CarRepository(_mockContext.Object, _mockMapper.Object);

            //Act
            sut.AddMakeModelTrim(1, 1, 1);

            //Assert
            _mockContext.Verify(x => x.MakeModelTrims.Add(It.IsAny<MakeModelTrim>()), Times.Never);
            _mockContext.Verify(x => x.SaveChanges(), Times.Never);
        }
    }
}
