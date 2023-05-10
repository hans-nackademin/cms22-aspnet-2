using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
    public class UserRegisterSchema
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

        public static implicit operator UserEntity(UserRegisterSchema schema) 
        { 
            return new UserEntity
            {
                FirstName = schema.FirstName,
                LastName = schema.LastName,
                Email = schema.Email,
                PhoneNumber = schema.PhoneNumber
            };
        }
    }
}
