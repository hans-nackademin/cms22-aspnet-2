using WebApp.Helpers.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class UserCompanyRepository : Repository<UserCompanyEntity>
    {
        public UserCompanyRepository(IdentityContext context) : base(context)
        {
        }
    }
}
