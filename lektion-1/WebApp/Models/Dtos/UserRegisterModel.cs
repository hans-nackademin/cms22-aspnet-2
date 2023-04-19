using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Models.Dtos
{
    public class UserRegisterModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string? StreetName { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? CompanyName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public static implicit operator CustomIdentityUser(UserRegisterModel model)
        {
            return new CustomIdentityUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.Mobile,
                ProfileImage = model.ProfileImage?.FileName,
            };
        }

        public static implicit operator AddressEntity(UserRegisterModel model)
        {
            return new AddressEntity
            {
                StreetName = model.StreetName!,
                PostalCode = model.PostalCode!,
                City = model.City!,
            };
        }

        public static implicit operator CompanyEntity(UserRegisterModel model)
        {
            return new CompanyEntity
            {
                CompanyName = model.CompanyName!
            };
        }
    }
}
