using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
