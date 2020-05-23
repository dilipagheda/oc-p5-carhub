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
    public class DriveTypeRepositoryTests
    {
        private Mock<ApplicationDbContext> _mockContext;

        public DriveTypeRepositoryTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();


            var DriveTypes = GetMockDriveTypes();
            var mockDbSetDriveTypes = DriveTypes.AsQueryable().BuildMockDbSet();

            _mockContext.SetupGet(x => x.DriveTypes).Returns(mockDbSetDriveTypes.Object);
        }

        public List<DriveType> GetMockDriveTypes()
        {
            return new List<DriveType>()
            {
                new DriveType()
                { Id = 1, DriveTypeName = "d1" },
                new DriveType()
                { Id = 2, DriveTypeName = "d2" },
                new DriveType()
                { Id = 3, DriveTypeName = "d3" },
                new DriveType()
                { Id = 4, DriveTypeName = "d4" },
                new DriveType()
                { Id = 5, DriveTypeName = "d5" },
            };
        }

        [Fact]
        public void GetAllDriveTypes_ShouldReturnCorrectValues()
        {
            //Arrange
            var sut = new DriveTypeRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.GetAllDriveTypes();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<DriveType>>(returnedValue);
            Assert.Equal(GetMockDriveTypes().Count, returnedValue.ToList().Count);
            Assert.Equal(GetMockDriveTypes(), returnedValue.ToList(), new DriveTypeComparator());
        }


        [Fact]
        public void GetDriveTypeNameById_ShouldReturnCorrectValue()
        {
            //Arrange
            var sut = new DriveTypeRepository(_mockContext.Object);
            var id = 3;
            //Act
            var returnedValue = sut.GetDriveTypeById(id);

            //Assert
            Assert.Equal(GetMockDriveTypes().Where(x => x.Id == id).FirstOrDefault().DriveTypeName, returnedValue);
        }

        [Fact]
        public void ManageDriveType_CarObj_IsNull()
        {
            //Arrange
            var sut = new DriveTypeRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.ManageDriveType(null);

            //Assert
            Assert.Equal(0, returnedValue);
        }

        [Fact]
        public void ManageDriveType_CarObj_IsNotNull_Add_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new DriveTypeRepository(_mockContext.Object);

            //Act
            _ = sut.ManageDriveType(new DriveType() { DriveTypeName = "XYZ" });

            //Assert
            _mockContext.Verify(x => x.DriveTypes.Add(It.Is<DriveType>(x => x.DriveTypeName.Equals("XYZ"))), Times.Once);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ManageDriveType_CarObj_IsNotNull_Edit_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new DriveTypeRepository(_mockContext.Object);

            //Act
            _ = sut.ManageDriveType(new DriveType() { DriveTypeName = "d1" });

            //Assert
            _mockContext.Verify(x => x.DriveTypes.Add(It.IsAny<DriveType>()), Times.Never);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
