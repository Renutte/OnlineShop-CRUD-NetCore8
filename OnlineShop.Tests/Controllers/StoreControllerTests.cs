using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShop.Api.Controllers;
using OnlineShop.Api.Dtos;
using OnlineShop.Api.Services;
using Xunit;

namespace OnlineShop.Api.Tests
{
    public class StoreControllerTests
    {
        [Fact]
        public void GetStores_ReturnsOkObjectResult_WithListOfStores()
        {
            var storeServiceMock = new Mock<IStoreService>();
            storeServiceMock.Setup(service => service.GetAllStores())
                            .Returns(new List<StoreDto>
                            {
                                new StoreDto { Id = 1, Name = "Store 1", Location = "Location 1" },
                                new StoreDto { Id = 2, Name = "Store 2", Location = "Location 2" }
                            });

            var controller = new StoreController(storeServiceMock.Object);

            var result = controller.GetStores();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var stores = Assert.IsAssignableFrom<IEnumerable<StoreDto>>(okResult.Value);
            Assert.NotNull(stores);
            if (stores != null)
            {
                Assert.Equal(2, stores.Count());
            }
        }

        [Fact]
        public void GetStore_WithValidId_ReturnsOkObjectResult_WithStore()
        {
            var storeServiceMock = new Mock<IStoreService>();
            var expectedStore = new StoreDto { Id = 1, Name = "Store 1", Location = "Location 1" };
            storeServiceMock.Setup(service => service.GetStoreById(1))
                            .Returns(expectedStore);

            var controller = new StoreController(storeServiceMock.Object);

            var result = controller.GetStore(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var store = Assert.IsType<StoreDto>(okResult.Value);
            Assert.Equal(expectedStore, store);
        }

        [Fact]
        public void CreateStore_WithValidStore_ReturnsCreatedAtActionResult()
        {
            var storeServiceMock = new Mock<IStoreService>();
            var storeDto = new StoreDto { Id = 1, Name = "Store 1", Location = "Location 1" };
            storeServiceMock.Setup(service => service.CreateStore(storeDto));

            var controller = new StoreController(storeServiceMock.Object);

            var result = controller.CreateStore(storeDto);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetStore", createdAtActionResult.ActionName);
            Assert.Equal(storeDto.Id, createdAtActionResult.RouteValues["id"]);
        }

        [Fact]
        public void UpdateStore_WithValidId_ReturnsNoContentResult()
        {
            var storeServiceMock = new Mock<IStoreService>();
            storeServiceMock.Setup(service => service.UpdateStore(It.IsAny<int>(), It.IsAny<StoreDto>()));

            var controller = new StoreController(storeServiceMock.Object);

            var result = controller.UpdateStore(1, new StoreDto());

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteStore_WithValidId_ReturnsNoContentResult()
        {
            var storeServiceMock = new Mock<IStoreService>();
            storeServiceMock.Setup(service => service.DeleteStore(It.IsAny<int>()));

            var controller = new StoreController(storeServiceMock.Object);

            var result = controller.DeleteStore(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
