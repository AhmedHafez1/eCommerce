using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [RegularExpression("^(?=[^\\d_].*?\\d)\\w(\\w|[!@#$%]){7,20}", ErrorMessage = " Password is weak!")]
        public string Password { get; set; } = null!;
        [Required]
        public string DisplayName { get; set; } = null!;
    }
}
