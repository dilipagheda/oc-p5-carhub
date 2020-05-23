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
    public class CarMakeRepositoryTests
    {
        private Mock<ApplicationDbContext> _mockContext;

        public CarMakeRepositoryTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();


            var carMakes = GetMockCarMakes();
            var mockDbSetCarMakes = carMakes.AsQueryable().BuildMockDbSet();

            _mockContext.SetupGet(x => x.CarMakes).Returns(mockDbSetCarMakes.Object);
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

        [Fact]
        public void GetAllCarMakes_ShouldReturnCorrectValues()
        {
            //Arrange
            var sut = new CarMakeRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.GetAllCarMakes();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<CarMake>>(returnedValue);
            Assert.Equal(GetMockCarMakes().Count, returnedValue.ToList().Count);
            Assert.Equal(GetMockCarMakes(), returnedValue.ToList(), new CarMakeComparator());
        }


        [Fact]
        public void GetCarMakeNameById_ShouldReturnCorrectValue()
        {
            //Arrange
            var sut = new CarMakeRepository(_mockContext.Object);
            var id = 3;
            //Act
            var returnedValue = sut.GetCarMakeNameById(id);

            //Assert
            Assert.Equal(GetMockCarMakes().Where(x => x.Id == id).FirstOrDefault().MakeName, returnedValue);
        }

        [Fact]
        public void ManageCarMake_CarObj_IsNull()
        {
            //Arrange
            var sut = new CarMakeRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.ManageCarMake(null);

            //Assert
            Assert.Equal(0, returnedValue);
        }

        [Fact]
        public void ManageCarMake_CarObj_IsNotNull_Add_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new CarMakeRepository(_mockContext.Object);

            //Act
            _ = sut.ManageCarMake(new CarMake() { MakeName = "XYZ" });

            //Assert
            _mockContext.Verify(x => x.CarMakes.Add(It.Is<CarMake>(x => x.MakeName.Equals("XYZ"))), Times.Once);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ManageCarMake_CarObj_IsNotNull_Edit_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new CarMakeRepository(_mockContext.Object);

            //Act
            _ = sut.ManageCarMake(new CarMake() { MakeName = "Honda" });

            //Assert
            _mockContext.Verify(x => x.CarMakes.Add(It.IsAny<CarMake>()), Times.Never);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
