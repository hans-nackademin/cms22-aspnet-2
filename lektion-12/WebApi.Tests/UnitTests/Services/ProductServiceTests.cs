using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.Helpers.Repositories;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Tests.UnitTests.Services
{
    public class ProductServiceTests
    {
        // Arrange - Skapa mocks och förbered testdata
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductService _service;
        private readonly List<ProductEntity> _productList;

        public ProductServiceTests()
        {
            // Skapa en mock för IProductRepository
            _mockRepo = new Mock<IProductRepository>();

            // Skapa en instans av ProductService med den mocked IProductRepository
            _service = new ProductService(_mockRepo.Object);

            // Skapa en lista med dummyprodukter
            _productList = new List<ProductEntity>()
            {
                new ProductEntity() { Id = 1, Name = "Product 1", Price = 10.00m },
                new ProductEntity() { Id = 2, Name = "Product 2", Price = 20.00m },
                new ProductEntity() { Id = 3, Name = "Product 3", Price = 30.00m }
            };
        }

        [Fact]
        public async Task ProductExistsAsync_ReturnsTrue_WhenProductExists()
        {
            // Arrange - Inställningar för mock
            _mockRepo.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>()))
                .ReturnsAsync(true);

            // Act - Kalla på metoden som ska testas
            var result = await _service.ProductExistsAsync(x => x.Name == "Product 1");

            // Assert - Kontrollera att resultatet blev som förväntat
            Assert.True(result);
        }

        [Fact]
        public async Task CreateAsync_ReturnsNewProduct_WhenProductDoesNotExists()
        {
            // Arrange - Inställningar för mock
            _mockRepo.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>()))
                .ReturnsAsync(false);

            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<ProductEntity>()))
                .ReturnsAsync((ProductEntity pe) => pe);

            var newProduct = new ProductSchema { Name = "New Product", Price = 40.00m };

            // Act - Kalla på metoden som ska testas
            var result = await _service.CreateAsync(newProduct);

            // Assert - Kontrollera att resultatet blev som förväntat
            Assert.Equal("New Product", result.Name);
            Assert.Equal(40.00m, result.Price);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllProducts()
        {
            // Arrange - Inställningar för mock
            _mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(_productList);

            // Act - Kalla på metoden som ska testas
            var result = await _service.GetAllAsync();

            // Assert - Kontrollera att resultatet blev som förväntat
            Assert.Equal(3, result.Count());
            Assert.Equal(_productList[0].Name, result.First().Name);
            Assert.Equal(_productList[2].Name, result.Last().Name);
        }
    }
}
