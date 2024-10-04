using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVCv._2.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter your email!")]
        [EmailAddress(ErrorMessage = "This e-mail is not valid!")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Enter your password!")]
        public required string Password { get; set; }
    }
}
