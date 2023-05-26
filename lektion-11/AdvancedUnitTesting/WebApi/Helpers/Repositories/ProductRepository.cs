using WebApi.Helpers.Contexts;
using WebApi.Models.Entities;
using WebApi.Models.Interfaces;

namespace WebApi.Helpers.Repositories
{
    public class ProductRepository : Repo<ProductEntity>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }
}
