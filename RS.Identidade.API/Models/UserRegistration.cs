namespace RS.Identidade.API.Models
{
    public class UserRegistration : UserLogin
    {
        public string PasswordConfirmation { get; set; }
    }
}