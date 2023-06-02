namespace WebApi.Models.Entities
{
    public interface IProductEntity
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}