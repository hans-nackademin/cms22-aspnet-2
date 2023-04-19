using WebApp.Helpers.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class AddressRepository : Repository<AddressEntity>
    {
        public AddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
