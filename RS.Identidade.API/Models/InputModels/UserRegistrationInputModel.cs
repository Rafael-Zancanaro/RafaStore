namespace RS.Identidade.API.Models.InputModels
{
    public class UserRegistrationInputModel : UserLoginInputModel
    {
        public string PasswordConfirmation { get; set; }
    }
}