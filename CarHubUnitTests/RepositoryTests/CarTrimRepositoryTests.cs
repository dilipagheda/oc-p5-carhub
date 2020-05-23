using CarHub.Data;
using CarHub.Data.Models;
using CarHub.Data.Repositories;
using CarHubUnitTests.Comparators;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CarHubUnitTests.RepositoryTests
{
    //Arrange

    //Act

    //Assert

    public class TrimRepositoryTests
    {
        private Mock<ApplicationDbContext> _mockContext;

        public TrimRepositoryTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();


            var carMakes = GetMockCarMakes();
            var carModels = GetMockCarModels();
            var carTrims = GetMockTrims();
            var makeModelTrims = GetMockMakeModelTrims();

            var mockDbSetCarMakes = carMakes.AsQueryable().BuildMockDbSet();
            var mockDbSetCarModels = carModels.AsQueryable().BuildMockDbSet();
            var mockDbSetTrims = carTrims.AsQueryable().BuildMockDbSet();
            var mockDbSetMakeModelTrims = makeModelTrims.AsQueryable().BuildMockDbSet();

            _mockContext.SetupGet(x => x.CarMakes).Returns(mockDbSetCarMakes.Object);
            _mockContext.SetupGet(x => x.CarModels).Returns(mockDbSetCarModels.Object);
            _mockContext.SetupGet(x => x.Trims).Returns(mockDbSetTrims.Object);
            _mockContext.SetupGet(x => x.MakeModelTrims).Returns(mockDbSetMakeModelTrims.Object);
        }

        public List<CarMake> GetMockCarMakes()
        {
            return new List<CarMake>()
            {
                new CarMake()
                { Id = 1, MakeName = "Toyota" },
                new CarMake()
                { Id = 2, MakeName = "Honda" },
                new CarMake()
                { Id = 3, MakeName = "Mazda" },
                new CarMake()
                { Id = 4, MakeName = "Audi" },
                new CarMake()
                { Id = 5, MakeName = "BMW" },
            };
        }

        public List<CarModel> GetMockCarModels()
        {
            return new List<CarModel>()
            {
                new CarModel()
                { Id = 1, ModelName = "m1" },
                new CarModel()
                { Id = 2, ModelName = "m2" },
                new CarModel()
                { Id = 3, ModelName = "m3" },
                new CarModel()
                { Id = 4, ModelName = "m4" }
            };
        }

        public List<Trim> GetMockTrims()
        {
            return new List<Trim>()
            {
                new Trim()
                { Id = 1, TrimName = "trim1" },
                new Trim()
                { Id = 2, TrimName = "trim2" },
                new Trim()
                { Id = 3, TrimName = "trim3" }
            };
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

        [Fact]
        public void GetAllModelsByMake_ShouldReturnCorrectValue()
        {
            //Arrange
            var sut = new TrimRepository(_mockContext.Object);

            var expectedTrims = new List<Trim>() { new Trim() { Id = 2, TrimName = "trim2" }, };

            //Act
            var returnedValue = sut.GetAllTrimsByModel(2);

            //Assert
            Assert.IsType<List<Trim>>(returnedValue);
            Assert.Equal(expectedTrims.Count, returnedValue.Count);
            Assert.Equal(expectedTrims, returnedValue, new CarTrimComparator());
        }

        [Fact]
        public void GetTrimNameById_ShouldReturnCorrectValue()
        {
            //Arrange
            var sut = new TrimRepository(_mockContext.Object);
            var id = 3;
            //Act
            var returnedValue = sut.GetTrimById(id);

            //Assert
            Assert.Equal(GetMockTrims().Where(x => x.Id == id).FirstOrDefault().TrimName, returnedValue);
        }

        [Fact]
        public void ManageTrim_CarObj_IsNull()
        {
            //Arrange
            var sut = new TrimRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.ManageTrim(null);

            //Assert
            Assert.Equal(0, returnedValue);
        }

        [Fact]
        public void ManageTrim_CarObj_IsNotNull_Add_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new TrimRepository(_mockContext.Object);

            //Act
            _ = sut.ManageTrim(new Trim() { TrimName = "trim10" });

            //Assert
            _mockContext.Verify(x => x.Trims.Add(It.Is<Trim>(x => x.TrimName.Equals("trim10"))), Times.Once);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ManageTrim_CarObj_IsNotNull_Edit_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new TrimRepository(_mockContext.Object);

            //Act
            _ = sut.ManageTrim(new Trim() { TrimName = "trim1" });

            //Assert
            _mockContext.Verify(x => x.Trims.Add(It.IsAny<Trim>()), Times.Never);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
