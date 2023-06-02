using System.Linq.Expressions;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services
{
    public interface IProductService
    {
        Task<Product> CreateAsync(ProductSchema schema);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(Expression<Func<ProductEntity, bool>> expression);
        Task<bool> ProductExistsAsync(Expression<Func<ProductEntity, bool>> expression);
    }
}