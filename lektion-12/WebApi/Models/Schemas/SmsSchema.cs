using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Schemas
{
    public class SmsSchema
    {
        [Required]
        public string To { get; set; } = null!;

        [Required]
        public string Message { get; set; } = null!;
    }
}
