using System.Diagnostics;
using WebApi.Models.Dtos;

namespace WebApi.Models.Entities
{
    public class ProductEntity : IProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }


        public static implicit operator Product(ProductEntity entity)
        {
            try
            {
                if (entity != null)
                    return new Product
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Price = entity.Price
                    };
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;

        }
    }
}
