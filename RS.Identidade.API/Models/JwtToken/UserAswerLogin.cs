namespace RS.Identidade.API.Models.JwtToken
{
    public class UserAswerLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken UserToken { get; set; }
    }
}