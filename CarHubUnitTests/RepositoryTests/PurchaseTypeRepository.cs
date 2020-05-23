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
    public class PurchaseTypeRepositoryTests
    {
        private Mock<ApplicationDbContext> _mockContext;

        public PurchaseTypeRepositoryTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();


            var PurchaseTypes = GetMockPurchaseTypes();
            var mockDbSetPurchaseTypes = PurchaseTypes.AsQueryable().BuildMockDbSet();

            _mockContext.SetupGet(x => x.PurchaseTypes).Returns(mockDbSetPurchaseTypes.Object);
        }

        public List<PurchaseType> GetMockPurchaseTypes()
        {
            return new List<PurchaseType>()
            {
                new PurchaseType()
                { Id = 1, PurchaseTypeName = "d1" },
                new PurchaseType()
                { Id = 2, PurchaseTypeName = "d2" },
                new PurchaseType()
                { Id = 3, PurchaseTypeName = "d3" },
                new PurchaseType()
                { Id = 4, PurchaseTypeName = "d4" },
                new PurchaseType()
                { Id = 5, PurchaseTypeName = "d5" },
            };
        }

        [Fact]
        public void GetAllPurchaseTypes_ShouldReturnCorrectValues()
        {
            //Arrange
            var sut = new PurchaseTypeRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.GetAllPurchaseTypes();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<PurchaseType>>(returnedValue);
            Assert.Equal(GetMockPurchaseTypes().Count, returnedValue.ToList().Count);
            Assert.Equal(GetMockPurchaseTypes(), returnedValue.ToList(), new PurchaseTypeComparator());
        }


        [Fact]
        public void GetPurchaseTypeNameById_ShouldReturnCorrectValue()
        {
            //Arrange
            var sut = new PurchaseTypeRepository(_mockContext.Object);
            var id = 3;
            //Act
            var returnedValue = sut.GetPurchaseTypeById(id);

            //Assert
            Assert.Equal(GetMockPurchaseTypes().Where(x => x.Id == id).FirstOrDefault().PurchaseTypeName, returnedValue);
        }

        [Fact]
        public void ManagePurchaseType_CarObj_IsNull()
        {
            //Arrange
            var sut = new PurchaseTypeRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.ManagePurchaseType(null);

            //Assert
            Assert.Equal(0, returnedValue);
        }

        [Fact]
        public void ManagePurchaseType_CarObj_IsNotNull_Add_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new PurchaseTypeRepository(_mockContext.Object);

            //Act
            _ = sut.ManagePurchaseType(new PurchaseType() { PurchaseTypeName = "XYZ" });

            //Assert
            _mockContext.Verify(x => x.PurchaseTypes.Add(It.Is<PurchaseType>(x => x.PurchaseTypeName.Equals("XYZ"))),
                                Times.Once);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ManagePurchaseType_CarObj_IsNotNull_Edit_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new PurchaseTypeRepository(_mockContext.Object);

            //Act
            _ = sut.ManagePurchaseType(new PurchaseType() { PurchaseTypeName = "d1" });

            //Assert
            _mockContext.Verify(x => x.PurchaseTypes.Add(It.IsAny<PurchaseType>()), Times.Never);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
