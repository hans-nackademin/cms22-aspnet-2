namespace WebApi.Models.Schemas
{
    public interface IProductSchema
    {
        string Name { get; set; }
        decimal Price { get; set; }
    }
}