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
    public class ColorRepositoryTests
    {
        private Mock<ApplicationDbContext> _mockContext;

        public ColorRepositoryTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();


            var colors = GetMockColors();
            var mockDbSetColors = colors.AsQueryable().BuildMockDbSet();

            _mockContext.SetupGet(x => x.Colors).Returns(mockDbSetColors.Object);
        }

        public List<Color> GetMockColors()
        {
            return new List<Color>()
            {
                new Color()
                { Id = 1, ColorName = "color1" },
                new Color()
                { Id = 2, ColorName = "color2" },
                new Color()
                { Id = 3, ColorName = "color3" },
                new Color()
                { Id = 4, ColorName = "color4" },
                new Color()
                { Id = 5, ColorName = "color5" },
            };
        }

        [Fact]
        public void GetAllColors_ShouldReturnCorrectValues()
        {
            //Arrange
            var sut = new ColorRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.GetAllColors();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<Color>>(returnedValue);
            Assert.Equal(GetMockColors().Count, returnedValue.ToList().Count);
            Assert.Equal(GetMockColors(), returnedValue.ToList(), new ColorComparator());
        }


        [Fact]
        public void GetColorNameById_ShouldReturnCorrectValue()
        {
            //Arrange
            var sut = new ColorRepository(_mockContext.Object);
            var id = 3;
            //Act
            var returnedValue = sut.GetColorById(id);

            //Assert
            Assert.Equal(GetMockColors().Where(x => x.Id == id).FirstOrDefault().ColorName, returnedValue);
        }

        [Fact]
        public void ManageColor_CarObj_IsNull()
        {
            //Arrange
            var sut = new ColorRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.ManageColor(null);

            //Assert
            Assert.Equal(0, returnedValue);
        }

        [Fact]
        public void ManageColor_CarObj_IsNotNull_Add_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new ColorRepository(_mockContext.Object);

            //Act
            _ = sut.ManageColor(new Color() { ColorName = "XYZ" });

            //Assert
            _mockContext.Verify(x => x.Colors.Add(It.Is<Color>(x => x.ColorName.Equals("XYZ"))), Times.Once);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ManageColor_CarObj_IsNotNull_Edit_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new ColorRepository(_mockContext.Object);

            //Act
            _ = sut.ManageColor(new Color() { ColorName = "color1" });

            //Assert
            _mockContext.Verify(x => x.Colors.Add(It.IsAny<Color>()), Times.Never);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
