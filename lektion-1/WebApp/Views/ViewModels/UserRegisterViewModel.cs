using System.ComponentModel.DataAnnotations;
using WebApp.Models.Dtos;

namespace WebApp.Views.ViewModels
{
    public class UserRegisterViewModel
    {
        [Display(Name = "First Name *")]
        [Required(ErrorMessage = "You must enter a first name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name *")]
        [Required(ErrorMessage = "You must enter a last name")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Street Name *")]
        [Required(ErrorMessage = "You must enter a street name")]
        public string StreetName { get; set; } = null!;

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "You must enter a postal code")]
        public string PostalCode { get; set; } = null!;

        [Display(Name = "City *")]
        [Required(ErrorMessage = "You must enter a city name")]
        public string City { get; set; } = null!;

        [Display(Name = "Mobile (optional)")]
        public string? Mobile { get; set; }

        [Display(Name = "Company (optional)")]
        public string? CompanyName { get; set; }


        [Display(Name = "E-mail *")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You must enter an e-mail address")]
        public string Email { get; set; } = null!;

        [Display(Name = "Password *")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must enter a password")]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm Password *")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must confirm your password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "Upload Profile Image (optional)")]
        public IFormFile? ProfileImage { get; set; }

        [Display(Name = "I have read an accepts the terms and conditions *")]
        [Required(ErrorMessage = "Your must aggree to the terms and conditions")]
        public bool TermsAndConditions { get; set; }
        public string ReturnUrl { get; set; } = "/";


        public static implicit operator UserRegisterModel(UserRegisterViewModel viewModel)
        {
            return new UserRegisterModel
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                Password = viewModel.Password,
                StreetName = viewModel.StreetName,
                PostalCode = viewModel.PostalCode,
                City = viewModel.City,
                CompanyName = viewModel.CompanyName,
                ProfileImage = viewModel.ProfileImage,
                Mobile = viewModel.Mobile,
            };
        }
    }
}
