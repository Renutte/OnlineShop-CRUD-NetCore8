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
    public class StoreProductsControllerTests
    {
        [Fact]
        public void GetStoreProducts_ReturnsOkObjectResult_WithListOfStoreProducts()
        {
            var storeProductServiceMock = new Mock<IStoreProductService>();
            storeProductServiceMock.Setup(service => service.GetAllStoreProducts())
                                    .Returns(new List<StoreProductDto>
                                    {
                                        new StoreProductDto { StoreId = 1, ProductId = 1, Stock = 10 },
                                        new StoreProductDto { StoreId = 2, ProductId = 2, Stock = 20 }
                                    });

            var controller = new StoreProductsController(storeProductServiceMock.Object);

            var result = controller.GetStoreProducts();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var storeProducts = Assert.IsAssignableFrom<IEnumerable<StoreProductDto>>(okResult.Value);
            Assert.NotNull(storeProducts);
            if (storeProducts != null)
            {
                Assert.Equal(2, storeProducts.Count());
            }
        }

        [Fact]
        public void GetStoreProduct_WithValidIds_ReturnsOkObjectResult_WithStoreProduct()
        {
            var storeProductServiceMock = new Mock<IStoreProductService>();
            var expectedStoreProduct = new StoreProductDto { StoreId = 1, ProductId = 1, Stock = 10 };
            storeProductServiceMock.Setup(service => service.GetStoreProductById(1, 1))
                                    .Returns(expectedStoreProduct);

            var controller = new StoreProductsController(storeProductServiceMock.Object);

            var result = controller.GetStoreProduct(1, 1);
            
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var storeProduct = Assert.IsType<StoreProductDto>(okResult.Value);
            Assert.Equal(expectedStoreProduct, storeProduct);
        }

        [Fact]
        public void PostStoreProduct_WithValidStoreProduct_ReturnsCreatedAtActionResult()
        {
            var storeProductServiceMock = new Mock<IStoreProductService>();
            var storeProductDto = new StoreProductDto { StoreId = 1, ProductId = 1, Stock = 10 };
            storeProductServiceMock.Setup(service => service.StoreProductExists(storeProductDto.StoreId, storeProductDto.ProductId))
                                    .Returns(false);

            var controller = new StoreProductsController(storeProductServiceMock.Object);

            var result = controller.PostStoreProduct(storeProductDto);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetStoreProduct", createdAtActionResult.ActionName);
            Assert.Equal(storeProductDto.StoreId, createdAtActionResult.RouteValues["storeId"]);
            Assert.Equal(storeProductDto.ProductId, createdAtActionResult.RouteValues["productId"]);
        }

        [Fact]
        public void PutStoreProduct_WithValidIds_ReturnsNoContentResult()
        {
            var storeProductServiceMock = new Mock<IStoreProductService>();
            storeProductServiceMock.Setup(service => service.StoreProductExists(1, 1))
                                    .Returns(true);

            var controller = new StoreProductsController(storeProductServiceMock.Object);

            var result = controller.PutStoreProduct(1, 1, new StoreProductDto());

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteStoreProduct_WithValidIds_ReturnsNoContentResult()
        {
            var storeProductServiceMock = new Mock<IStoreProductService>();

            var controller = new StoreProductsController(storeProductServiceMock.Object);

            var result = controller.DeleteStoreProduct(1, 1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
