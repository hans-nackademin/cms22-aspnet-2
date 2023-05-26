using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Models.Dtos;
using WebApi.Models.Interfaces;

namespace WebApi.Tests.UnitTests
{
    public class ProductsController_Tests
    {
        private ProductsController _controller;
        private Mock<IProductManager> _productManager;

        public ProductsController_Tests()
        {
            _productManager = new Mock<IProductManager>();
            _controller = new ProductsController(_productManager.Object);
        }

        [Fact]
        public async Task GetAll_Should_Reuturn_OkResult_WithProducts()
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" },
                new Product { Id = 3, Name = "Product 3" }
            };

            _productManager.Setup(x => x.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(products.Count, value.Count);
        }
    }
}
