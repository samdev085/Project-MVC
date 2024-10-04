using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjectMVCv._2.Helpers;

namespace ProjectMVCv._2.Models
{
    public class User
    {
        [ForeignKey("Id")]
        [Column("Id")]
        public int Id { get; set; }

        
        [MaxLength(250)]
        [Column("Name")]
        [Required(ErrorMessage = "Enter the user's name")]
        public required string Name { get; set; }

       
        [MaxLength(50)]
        [Column("Password")]
        [Required(ErrorMessage = "Enter the user's password")]
        
        public required string Password { get; set; }

     
        [MaxLength(250)]
        [Column("Email")]
        [Required(ErrorMessage = "Enter the user's e-mail")]
        [EmailAddress(ErrorMessage = "The email entered is not valid!")]
        public required string Email { get; set; }

        public bool CheckPassword(string password)
        {
            return Password == password.GeneratePassword();
        }

        public void SetHashPassword ()
        {
            Password = Password.GeneratePassword();
        }

        public string CreateNewPassword() 
        { 
            string newPass = Guid.NewGuid().ToString().Substring(0, 8);
            Password = newPass.GeneratePassword();
            return newPass;
        }
    }
}
