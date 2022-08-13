using System.ComponentModel.DataAnnotations;

namespace RS.Web.MVC.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Field must be filled!")]
        [EmailAddress(ErrorMessage = "Email field is in invalid format!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field must be filled!")]
        public string Password { get; set; }
    }

    public class RegisterUser : LoginUser
    {
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string PasswordConfirmation { get; set; }
    }
}