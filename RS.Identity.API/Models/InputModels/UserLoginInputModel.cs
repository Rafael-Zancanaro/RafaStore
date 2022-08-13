using System.ComponentModel.DataAnnotations;

namespace RS.Identity.API.Models.InputModels
{
    public class UserLoginInputModel
    {
        [Required(ErrorMessage = "Field must be filled!")]
        [EmailAddress(ErrorMessage = "Email field is in invalid format!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field must be filled!")]
        public string Password { get; set; }
    }
}
