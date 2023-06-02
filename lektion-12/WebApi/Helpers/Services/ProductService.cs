using System.Diagnostics;
using System.Linq.Expressions;
using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }


        public async Task<bool> ProductExistsAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            return await _repo.AnyAsync(expression);
        }

        public async Task<Product> CreateAsync(ProductSchema schema)
        {
            try
            {
                if (!await ProductExistsAsync(x => x.Name == schema.Name))
                    return await _repo.AddAsync(schema);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                var products = new List<Product>();
                foreach (var entity in await _repo.GetAllAsync())
                    products.Add(entity);

                return products;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<Product> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            try
            {
                return await _repo.GetAsync(expression);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }
    }
}
