namespace RS.Identidade.API.Models.Extentions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public double ExpirateHours { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
