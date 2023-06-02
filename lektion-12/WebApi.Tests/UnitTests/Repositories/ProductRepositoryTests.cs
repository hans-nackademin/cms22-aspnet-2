using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Helpers.Repositories;
using WebApi.Models.Entities;
using WebApi.Tests.Fixtures;

namespace WebApi.Tests.UnitTests.Repositories
{
    public class ProductRepositoryTests
    {
        private DataContext _context;
        private IProductRepository _productRepo;

        public ProductRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
                
            _context = new DataContext(options);
            _productRepo = new ProductRepository(_context);
        }

        [Fact]
        public async Task AnyAsync_GetTrueWhenProductExistsInDatabase_ReuturnTrue()
        {
            // arrange
            var entity = ProductFixture.Entities.First();
            await _productRepo.AddAsync(entity);

            // act
            var result = await _productRepo.AnyAsync(x => x.Id == entity.Id);

            // assert
            Assert.True(result);
        }

        [Fact]
        public async Task AnyAsync_GetFalseWhenProductNotExistsInDatabase_ReuturnFalse()
        {
            // arrange
            var entity = ProductFixture.Entities.First();

            // act
            var result = await _productRepo.AnyAsync(x => x.Id == entity.Id);

            // assert
            Assert.False(result);
        }

        [Fact]
        public async Task AddAsync_AddProductToDatabase_ReturnCreatedProduct()
        {
            // arrange
            var entity = ProductFixture.Entities.First();

            // act
            var result = await _productRepo.AddAsync(entity);

            // assert
            Assert.NotNull(result);
            var data = Assert.IsType<ProductEntity>(result);
            Assert.Equal(entity.Id, data.Id);

        }

        [Fact]
        public async Task AddAsync_FailWhenAddingIncorrectProductToDatabase_ReturnNull()
        {
            // arrange
            var entity = new ProductEntity();

            // act
            var result = await _productRepo.AddAsync(entity);

            // assert
            Assert.Null(result);

        }

        [Fact]
        public async Task AddAsync_FailWhenAddingDuplicateProduct_ReturnNull()
        {
            // arrange
            var duplicateEntity = ProductFixture.Entities.First();
            foreach (var entity in ProductFixture.Entities)
                await _productRepo.AddAsync(entity);

            // act
            var result = await _productRepo.AddAsync(duplicateEntity);

            // assert
            Assert.Null(result);

        }

        [Fact]
        public async Task GetAllAsync_GetAllProductsFromDatabase_ReturnAllProducts()
        {
            // arrange
            foreach (var entity in ProductFixture.Entities)
                await _productRepo.AddAsync(entity);

            // act
            var result = await _productRepo.GetAllAsync();

            // assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<ProductEntity>>(result);
            Assert.Equal(ProductFixture.Entities.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_GetSpecificProductFromDatabase_ReturnSpecificProduct()
        {
            // arrange
            var entity = ProductFixture.Entities.First();
            await _productRepo.AddAsync(entity);

            // act
            var result = await _productRepo.GetAsync(x => x.Id == entity.Id);

            // assert
            Assert.NotNull(result);
            var data = Assert.IsType<ProductEntity>(result);
            Assert.Equal(entity.Id, result.Id);
        }

        [Fact]
        public async Task GetAsync_FailGetSpecificProductFromDatabase_ReturnNull()
        {
            // arrange
            var entity = ProductFixture.Entities.First();

            // act
            var result = await _productRepo.GetAsync(x => x.Id == entity.Id);

            // assert
            Assert.Null(result);

        }
    }
}
