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
    public class BodyTypeRepositoryTests
    {
        private Mock<ApplicationDbContext> _mockContext;

        public BodyTypeRepositoryTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();


            var bodyTypes = GetMockBodyTypes();
            var mockDbSetBodyTypes = bodyTypes.AsQueryable().BuildMockDbSet();

            _mockContext.SetupGet(x => x.BodyTypes).Returns(mockDbSetBodyTypes.Object);
        }

        public List<BodyType> GetMockBodyTypes()
        {
            return new List<BodyType>()
            {
                new BodyType()
                { Id = 1, BodyTypeName = "bodytype1" },
                new BodyType()
                { Id = 2, BodyTypeName = "bodytype2" },
                new BodyType()
                { Id = 3, BodyTypeName = "bodytype3" },
                new BodyType()
                { Id = 4, BodyTypeName = "bodytype4" },
                new BodyType()
                { Id = 5, BodyTypeName = "bodytype5" },
            };
        }

        [Fact]
        public void GetAllBodyTypes_ShouldReturnCorrectValues()
        {
            //Arrange
            var sut = new BodyTypeRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.GetAllBodyTypes();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<BodyType>>(returnedValue);
            Assert.Equal(GetMockBodyTypes().Count, returnedValue.ToList().Count);
            Assert.Equal(GetMockBodyTypes(), returnedValue.ToList(), new BodyTypeComparator());
        }


        [Fact]
        public void GetBodyTypeNameById_ShouldReturnCorrectValue()
        {
            //Arrange
            var sut = new BodyTypeRepository(_mockContext.Object);
            var id = 3;
            //Act
            var returnedValue = sut.GetBodyTypeById(id);

            //Assert
            Assert.Equal(GetMockBodyTypes().Where(x => x.Id == id).FirstOrDefault().BodyTypeName, returnedValue);
        }

        [Fact]
        public void ManageBodyType_CarObj_IsNull()
        {
            //Arrange
            var sut = new BodyTypeRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.ManageBodyType(null);

            //Assert
            Assert.Equal(0, returnedValue);
        }

        [Fact]
        public void ManageBodyType_CarObj_IsNotNull_Add_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new BodyTypeRepository(_mockContext.Object);

            //Act
            _ = sut.ManageBodyType(new BodyType() { BodyTypeName = "XYZ" });

            //Assert
            _mockContext.Verify(x => x.BodyTypes.Add(It.Is<BodyType>(x => x.BodyTypeName.Equals("XYZ"))), Times.Once);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ManageBodyType_CarObj_IsNotNull_Edit_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new BodyTypeRepository(_mockContext.Object);

            //Act
            _ = sut.ManageBodyType(new BodyType() { BodyTypeName = "bodytype1" });

            //Assert
            _mockContext.Verify(x => x.BodyTypes.Add(It.IsAny<BodyType>()), Times.Never);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
