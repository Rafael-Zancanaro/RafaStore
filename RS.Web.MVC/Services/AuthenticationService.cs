using HelperExtentions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RS.Identity.API.Models.JwtToken;
using RS.Web.MVC.Models;
using RS.Web.MVC.Models.Interfaces;
using RS.Web.MVC.Models.Settings;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RS.Web.MVC.Services
{
    public class AuthenticationService : IAuthenticationApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IdentitySettings _identitySettings;

        public AuthenticationService(HttpClient httpClient, IOptions<IdentitySettings> identitySettings)
        {
            _identitySettings = identitySettings.Value;
            _httpClient = httpClient;
        }

        public async Task<ResultViewModel<UserAswerLogin>> Login(LoginUser loginUser)
        {
            var result = new ResultViewModel<UserAswerLogin>();

            var response = await _httpClient.PostAsJsonAsync(_identitySettings.EndpointLogin, loginUser);

            var objJson = await response.Content.ReadAsStringAsync();
            var objDeserializado = JsonConvert.DeserializeObject<ResultViewModel<UserAswerLogin>>(objJson);

            return objDeserializado.ValidOperation
                    ? result.AddResult(objDeserializado.Result)
                    : result.AddError(objDeserializado.Errors);
        }

        public async Task<ResultViewModel<UserAswerLogin>> Register(RegisterUser registerUser)
        {
            var result = new ResultViewModel<UserAswerLogin>();

            var response = await _httpClient.PostAsJsonAsync(_identitySettings.EndpointRegistration, registerUser);

            var objJson = response.Content.ReadAsStringAsync().Result;
            var objDeserializado = JsonConvert.DeserializeObject<ResultViewModel<UserAswerLogin>>(objJson);

            return objDeserializado.ValidOperation
                    ? result.AddResult(objDeserializado.Result)
                    : result.AddError(objDeserializado.Errors);
        }
    }
}
