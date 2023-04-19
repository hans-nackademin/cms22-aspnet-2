using WebApp.Helpers.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class CompanyRepository : Repository<CompanyEntity>
    {
        public CompanyRepository(IdentityContext context) : base(context)
        {
        }
    }
}
