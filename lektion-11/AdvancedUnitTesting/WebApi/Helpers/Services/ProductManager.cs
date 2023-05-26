using System.Diagnostics;
using System.Linq.Expressions;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Interfaces;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services
{
    public class ProductManager : IProductManager
    {
        #region constructors and private fields

        private readonly IProductRepository _productRepo;

        public ProductManager(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        #endregion


        public async Task<Product> CreateAsync(ProductSchema schema)
        {
            try
            {
                if (schema != null)
                    return await _productRepo.AddAsync(schema);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<Product> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            try
            {
                var entity = await _productRepo.GetAsync(expression);
                if (entity != null)
                    return entity!;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                var items = new List<Product>();
                var products = await _productRepo.GetAsync();
                foreach (var entity in products)
                    items.Add(entity);

                if (items.Count > 0)
                    return items;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }
    }
}
