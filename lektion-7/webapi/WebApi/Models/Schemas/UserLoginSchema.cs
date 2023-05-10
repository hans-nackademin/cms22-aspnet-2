using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Schemas;

public class UserLoginSchema
{
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
