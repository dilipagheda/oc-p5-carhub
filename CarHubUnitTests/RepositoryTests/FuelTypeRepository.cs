using CarHub.Data;
using CarHub.Data.Models;
using CarHub.Data.Repositories;
using CarHubUnitTests.Comparators;
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
    public class FuelTypeRepositoryTests
    {
        private Mock<ApplicationDbContext> _mockContext;

        public FuelTypeRepositoryTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();


            var FuelTypes = GetMockFuelTypes();
            var mockDbSetFuelTypes = FuelTypes.AsQueryable().BuildMockDbSet();

            _mockContext.SetupGet(x => x.FuelTypes).Returns(mockDbSetFuelTypes.Object);
        }

        public List<FuelType> GetMockFuelTypes()
        {
            return new List<FuelType>()
            {
                new FuelType()
                { Id = 1, FuelTypeName = "d1" },
                new FuelType()
                { Id = 2, FuelTypeName = "d2" },
                new FuelType()
                { Id = 3, FuelTypeName = "d3" },
                new FuelType()
                { Id = 4, FuelTypeName = "d4" },
                new FuelType()
                { Id = 5, FuelTypeName = "d5" },
            };
        }

        [Fact]
        public void GetAllFuelTypes_ShouldReturnCorrectValues()
        {
            //Arrange
            var sut = new FuelTypeRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.GetAllFuelTypes();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<FuelType>>(returnedValue);
            Assert.Equal(GetMockFuelTypes().Count, returnedValue.ToList().Count);
            Assert.Equal(GetMockFuelTypes(), returnedValue.ToList(), new FuelTypeComparator());
        }


        [Fact]
        public void GetFuelTypeNameById_ShouldReturnCorrectValue()
        {
            //Arrange
            var sut = new FuelTypeRepository(_mockContext.Object);
            var id = 3;
            //Act
            var returnedValue = sut.GetFuelTypeById(id);

            //Assert
            Assert.Equal(GetMockFuelTypes().Where(x => x.Id == id).FirstOrDefault().FuelTypeName, returnedValue);
        }

        [Fact]
        public void ManageFuelType_CarObj_IsNull()
        {
            //Arrange
            var sut = new FuelTypeRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.ManageFuelType(null);

            //Assert
            Assert.Equal(0, returnedValue);
        }

        [Fact]
        public void ManageFuelType_CarObj_IsNotNull_Add_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new FuelTypeRepository(_mockContext.Object);

            //Act
            _ = sut.ManageFuelType(new FuelType() { FuelTypeName = "XYZ" });

            //Assert
            _mockContext.Verify(x => x.FuelTypes.Add(It.Is<FuelType>(x => x.FuelTypeName.Equals("XYZ"))), Times.Once);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ManageFuelType_CarObj_IsNotNull_Edit_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new FuelTypeRepository(_mockContext.Object);

            //Act
            _ = sut.ManageFuelType(new FuelType() { FuelTypeName = "d1" });

            //Assert
            _mockContext.Verify(x => x.FuelTypes.Add(It.IsAny<FuelType>()), Times.Never);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
