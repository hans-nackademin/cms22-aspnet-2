using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Net.Http.Json;
using WebApi.Controllers;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;
using WebApi.Tests.Fixtures;

namespace WebApi.Tests.IntegrationTests.Controllers
{
    public class ProductControllerTests : IDisposable
    {
        private Mock<IProductService> _productService;
        private ProductController _controller;
        private CustomWebApplicationFactory _factory;
        private HttpClient _client;

        public ProductControllerTests()
        {
            _productService = new Mock<IProductService>();
            _controller = new ProductController(_productService.Object);
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        public void Dispose()
        {
            _factory.Dispose(); 
            _client.Dispose();
        }

        [Fact]
        public async Task Create_FailToCreateProductIfModelStateIsNotValid_ReturnStatusCodeBadRequest()
        {
            // arrange
            var schema = new ProductSchema();

            // act
            var result = await _client.PostAsync("/api/products", JsonContent.Create(schema));

            // assert
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
