using WebApi.Models.Dtos;
using WebApi.Models.Interfaces;
using WebApi.Models.Schemas;

namespace WebApi.Models.Entities
{
    public class ProductEntity : IProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;


        public static implicit operator Product(ProductEntity entity)
        {
            if (entity != null)
                return new Product
                {
                    Id = entity.Id,
                    Name = entity.Name
                };

            return null!;
        }
    }
}
