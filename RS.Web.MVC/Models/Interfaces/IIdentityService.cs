using HelperExtentions;
using RS.Identity.API.Models.JwtToken;
using System.Threading.Tasks;

namespace RS.Web.MVC.Models.Interfaces
{
    public interface IAuthenticationApiService
    {
        Task<ResultViewModel<UserAswerLogin>> Login(LoginUser loginUser);
        Task<ResultViewModel<UserAswerLogin>> Register(RegisterUser registerUser);
    }
}