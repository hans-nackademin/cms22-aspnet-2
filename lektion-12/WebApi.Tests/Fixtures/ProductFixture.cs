using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Tests.Fixtures
{
    public class ProductFixture
    {
        public static List<ProductSchema> Schemas = new()
        {
            new ProductSchema { Name = "Product 1", Price = 100 },
            new ProductSchema { Name = "Product 2", Price = 200 },
            new ProductSchema { Name = "Product 3", Price = 300 }
        };

        public static List<ProductEntity> Entities = new()
        {
            new ProductEntity { Id = 1, Name = "Product 1", Price = 100 },
            new ProductEntity { Id = 2, Name = "Product 2", Price = 200 },
            new ProductEntity { Id = 3, Name = "Product 3", Price = 300 }
        };

        public static List<Product> Dtos = new()
        {
            new Product { Id = 1, Name = "Product 1", Price = 100 },
            new Product { Id = 2, Name = "Product 2", Price = 200 },
            new Product { Id = 3, Name = "Product 3", Price = 300 }
        };
    }
}
