using WebApi.Models.Entities;
using WebApi.Models.Interfaces;

namespace WebApi.Models.Schemas
{
    public class ProductSchema : IProductSchema
    {
        public string Name { get; set; } = null!;

        
        
        
        public static implicit operator ProductEntity(ProductSchema schema) 
        {
            if (schema != null)
                return new ProductEntity
                {
                    Name = schema.Name
                };

            return null!;    
        }
    }
}
