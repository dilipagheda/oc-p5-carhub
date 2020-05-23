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
    public class InventoryStatusRepositoryTests
    {
        private Mock<ApplicationDbContext> _mockContext;

        public InventoryStatusRepositoryTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();


            var InventoryStatus = GetMockInventoryStatus();
            var mockDbSetInventoryStatus = InventoryStatus.AsQueryable().BuildMockDbSet();

            _mockContext.SetupGet(x => x.InventoryStatusList).Returns(mockDbSetInventoryStatus.Object);
        }

        public List<InventoryStatus> GetMockInventoryStatus()
        {
            return new List<InventoryStatus>()
            {
                new InventoryStatus()
                { Id = 1, Status = "d1" },
                new InventoryStatus()
                { Id = 2, Status = "d2" },
                new InventoryStatus()
                { Id = 3, Status = "d3" },
                new InventoryStatus()
                { Id = 4, Status = "d4" },
                new InventoryStatus()
                { Id = 5, Status = "d5" },
            };
        }

        [Fact]
        public void GetAllInventoryStatus_ShouldReturnCorrectValues()
        {
            //Arrange
            var sut = new InventoryStatusRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.GetAllInventoryStatus();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<InventoryStatus>>(returnedValue);
            Assert.Equal(GetMockInventoryStatus().Count, returnedValue.ToList().Count);
            Assert.Equal(GetMockInventoryStatus(), returnedValue.ToList(), new InventoryStatusComparator());
        }


        [Fact]
        public void GetInventoryStatusNameById_ShouldReturnCorrectValue()
        {
            //Arrange
            var sut = new InventoryStatusRepository(_mockContext.Object);
            var id = 3;
            //Act
            var returnedValue = sut.GetInventoryStatusById(id);

            //Assert
            Assert.Equal(GetMockInventoryStatus().Where(x => x.Id == id).FirstOrDefault().Status, returnedValue);
        }

        [Fact]
        public void ManageInventoryStatus_CarObj_IsNull()
        {
            //Arrange
            var sut = new InventoryStatusRepository(_mockContext.Object);

            //Act
            var returnedValue = sut.ManageInventoryStatus(null);

            //Assert
            Assert.Equal(0, returnedValue);
        }

        [Fact]
        public void ManageInventoryStatus_CarObj_IsNotNull_Add_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new InventoryStatusRepository(_mockContext.Object);

            //Act
            _ = sut.ManageInventoryStatus(new InventoryStatus() { Status = "XYZ" });

            //Assert
            _mockContext.Verify(x => x.InventoryStatusList.Add(It.Is<InventoryStatus>(x => x.Status.Equals("XYZ"))),
                                Times.Once);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ManageInventoryStatus_CarObj_IsNotNull_Edit_ShouldCallCorrectMethods()
        {
            //Arrange
            var sut = new InventoryStatusRepository(_mockContext.Object);

            //Act
            _ = sut.ManageInventoryStatus(new InventoryStatus() { Status = "d1" });

            //Assert
            _mockContext.Verify(x => x.InventoryStatusList.Add(It.IsAny<InventoryStatus>()), Times.Never);
            _mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
