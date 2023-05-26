using Moq;
using System.Linq.Expressions;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Interfaces;
using WebApi.Models.Schemas;

namespace WebApi.Tests.UnitTests
{
    public class ProductManager_Tests
    {
        private Mock<IProductRepository> _productRepo;
        private IProductManager _productManager;

        public ProductManager_Tests()
        {
            _productRepo = new Mock<IProductRepository>();
            _productManager = new ProductManager(_productRepo.Object);
        }


        [Fact]
        public async Task CreateAsync__Should_Create_New_ProductEntity_And_Return_Product()
        {
            // Arrange
            ProductSchema schema = new ProductSchema { Name = "Product 1" };
            ProductEntity entity = new ProductEntity { Id = 1, Name = "Product 1" };
            _productRepo.Setup(x => x.AddAsync(It.IsAny<ProductEntity>())).ReturnsAsync(entity);


            // Act
            var result = await _productManager.CreateAsync(schema);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Product>(result);
        }


        [Fact]
        public async Task GetAsync__Should_Return_Specific_Product()
        {
            // Arrange
            ProductEntity entity = new ProductEntity { Id = 1, Name = "Product 1" };
            _productRepo.Setup(x => x.GetAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>())).ReturnsAsync(entity);


            // Act
            var result = await _productManager.GetAsync(x => x.Id == 1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Product>(result);
            Assert.Equal(entity.Id, result.Id);

        }

        [Fact]
        public async Task GetAllAsync__Should_Return_All_Products()
        {
            // Arrange
            var products = new List<ProductEntity>
            {
                new ProductEntity { Id = 1, Name = "Product 1" },
                new ProductEntity { Id = 2, Name = "Product 2" },
                new ProductEntity { Id = 3, Name = "Product 3" }
            };
            _productRepo.Setup(x => x.GetAsync()).ReturnsAsync(products);


            // Act
            var result = await _productManager.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Product>>(result);
            Assert.Equal(products.Count, result.Count());

        }
    }
}