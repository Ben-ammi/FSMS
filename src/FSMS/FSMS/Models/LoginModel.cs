using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FSMS.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please provide your username")]
        [Display(Name = "Username")]
        [MinLength(8, ErrorMessage = "Username must be at least 8 characters long")]
        [RegularExpression(@"^[A-Za-z]+\.[A-Za-z]+$", ErrorMessage = "Use the format Lastname.Firstname")]
        public string Username { get; set; } = string.Empty;

        [PasswordPropertyText]
        [Required(ErrorMessage = "Please provide your password")]
        [MinLength(12, ErrorMessage = "Password must be at least 12 characters long")]
        public string Password { get; set; } = string.Empty;
    }
}
