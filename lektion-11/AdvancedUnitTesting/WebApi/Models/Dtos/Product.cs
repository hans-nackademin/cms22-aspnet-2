using WebApi.Models.Interfaces;

namespace WebApi.Models.Dtos
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
