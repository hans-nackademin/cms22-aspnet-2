namespace WebApi.Models.Dtos
{
    public interface IProduct
    {
        int? Id { get; set; }
        string? Name { get; set; }
        decimal? Price { get; set; }
    }
}