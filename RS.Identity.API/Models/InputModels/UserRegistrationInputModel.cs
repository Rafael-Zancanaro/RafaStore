using System.ComponentModel.DataAnnotations;

namespace RS.Identity.API.Models.InputModels
{
    public class UserRegistrationInputModel : UserLoginInputModel
    {
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string PasswordConfirmation { get; set; }
    }
}