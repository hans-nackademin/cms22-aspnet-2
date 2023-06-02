using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;
using WebApi.Models.Schemas;
using WebApi.Tests.Fixtures;

namespace WebApi.Tests.UnitTests.Controllers
{
    public class ProductControllerTests
    {
        private Mock<IProductService> _productService;
        private ProductController _controller;

        public ProductControllerTests()
        {
            _productService = new Mock<IProductService>();
            _controller = new ProductController(_productService.Object);
        }

        [Fact]
        public async Task Create_CreateNewProductIfNotExists_ReturnStatusCodeCreatedWithProduct()
        {
            // arrange
            var schema = ProductFixture.Schemas.First();
            var product = ProductFixture.Dtos.First();
            _productService.Setup(x => x.ProductExistsAsync(x => x.Name == schema.Name)).ReturnsAsync(false);
            _productService.Setup(x => x.CreateAsync(schema)).ReturnsAsync(product);    

            // act
            var result = await _controller.Create(schema);

            // assert
            Assert.NotNull(result);
            var data = Assert.IsType<CreatedResult>(result);
            var value = Assert.IsType<Product>(data.Value);
            Assert.Equal(schema.Name, value.Name);
        }

        [Fact]
        public async Task Create_FailToCreateProductIfAlreadyExists_ReturnStatusCodeConflict()
        {
            // arrange
            var schema = ProductFixture.Schemas.First();
            var product = ProductFixture.Dtos.First();
            _productService.Setup(x => x.ProductExistsAsync(x => x.Name == schema.Name)).ReturnsAsync(true);
            _productService.Setup(x => x.CreateAsync(schema)).ReturnsAsync(product);

            // act
            var result = await _controller.Create(schema);

            // assert
            Assert.NotNull(result);
            var data = Assert.IsType<ConflictObjectResult>(result);
            var value = Assert.IsType<string>(data.Value);
            Assert.Equal("A product with the same name already exists.", value);
        }

        [Fact]
        public async Task Create_FailToCreateProductIfModelStateIsNotValid_ReturnStatusCodeBadRequest()
        {
            // arrange
            var schema = ProductFixture.Schemas.First();
            _controller.ModelState.AddModelError("error", "");

            // act
            var result = await _controller.Create(schema);

            // assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
