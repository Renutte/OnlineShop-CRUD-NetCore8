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
    public class ProductControllerTests
    {
        [Fact]
        public void GetProducts_ReturnsOkObjectResult_WithListOfProducts()
        {
            var productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.GetAllProducts())
                              .Returns(new List<ProductDto>
                              {
                                  new ProductDto { Name = "Product 1", Size = "", Color = "", Price = "10", Description = "" },
                                  new ProductDto { Name = "Product 2", Size = "", Color = "", Price = "10", Description = "" },
                              });

            var controller = new ProductController(productServiceMock.Object);

            var result = controller.GetProducts();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var products = Assert.IsAssignableFrom<IEnumerable<ProductDto>>(okResult.Value);
            Assert.NotNull(products);
            if (products != null)
            {
                Assert.Equal(2, products.Count());
            }


        }

        [Fact]
        public void GetProduct_WithValidId_ReturnsOkObjectResult_WithProduct()
        {
            var productServiceMock = new Mock<IProductService>();
            var expectedProduct = new ProductDto { Name = "Product 3", Size = "", Color = "", Price = "10", Description = "" };
            productServiceMock.Setup(service => service.GetProductById(1))
                              .Returns(expectedProduct);

            var controller = new ProductController(productServiceMock.Object);

            var result = controller.GetProduct(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var product = Assert.IsType<ProductDto>(okResult.Value);
            Assert.Equal(expectedProduct, product);
        }

        [Fact]
        public void CreateProduct_WithValidProduct_ReturnsCreatedAtActionResult()
        {
            var productServiceMock = new Mock<IProductService>();
            var productDto = new ProductDto { Name = "Product 3", Size = "", Color = "", Price = "10", Description = "" };
            productServiceMock.Setup(service => service.CreateProduct(productDto));

            var controller = new ProductController(productServiceMock.Object);

            var result = controller.CreateProduct(productDto);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetProduct", createdAtActionResult.ActionName);
            Assert.Equal(productDto.Id, createdAtActionResult.RouteValues["id"]);
        }

        [Fact]
        public void UpdateProduct_WithValidId_ReturnsNoContentResult()
        {
            var productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.UpdateProduct(It.IsAny<int>(), It.IsAny<ProductDto>()));

            var controller = new ProductController(productServiceMock.Object);

            var result = controller.UpdateProduct(1, new ProductDto());

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteProduct_WithValidId_ReturnsNoContentResult()
        {
            var productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.DeleteProduct(It.IsAny<int>()));

            var controller = new ProductController(productServiceMock.Object);

            var result = controller.DeleteProduct(1);

            Assert.IsType<NoContentResult>(result);
        }

    }
}
