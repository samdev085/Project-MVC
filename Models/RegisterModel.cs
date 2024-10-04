using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVCv._2.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Enter your name!")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Enter your email!")]
        [EmailAddress(ErrorMessage = "This e-mail is not valid!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Enter your password!")]
        public required string Password { get; set; }
    }
}
