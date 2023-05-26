using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Helpers.Contexts;
using WebApi.Helpers.Repositories;
using WebApi.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Tests.UnitTests
{
    public class ProductRepository_Tests
    {
        private DataContext _context;
        private IProductRepository _productRepo;

        public ProductRepository_Tests()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new DataContext(options);
            _productRepo = new ProductRepository(_context);
        }

        [Fact]
        public async Task AddAsync__Should_Create_ProductEntity_And_Return_ProductEntity()
        {
            // Arrange
            var entity = new ProductEntity { Id = 1, Name = "Product 1" };

            // Act
            var result = await _productRepo.AddAsync(entity);


            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProductEntity>(result);
            Assert.Equal(entity.Id, result.Id);
        }
    }
}
