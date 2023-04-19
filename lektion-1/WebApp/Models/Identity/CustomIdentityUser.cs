using Microsoft.AspNetCore.Identity;
using WebApp.Models.Entities;

namespace WebApp.Models.Identity
{
    public class CustomIdentityUser : IdentityUser
    {
        [ProtectedPersonalData]
        public string? FirstName { get; set; }
        
        
        [ProtectedPersonalData]
        public string? LastName { get; set; }


        [ProtectedPersonalData] 
        public string? ProfileImage { get; set; }


        public ICollection<UserAddressEntity> UserAddresses { get; set; } = new HashSet<UserAddressEntity>();
        public ICollection<UserCompanyEntity> UserCompanies { get; set; } = new HashSet<UserCompanyEntity>();
    }
}
