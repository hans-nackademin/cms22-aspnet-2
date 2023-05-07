using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModels;

public class LoginViewModel
{
    [Display(Name = "E-mail Address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; } = false;
}
