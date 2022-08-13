using HelperExtentions;
using RS.Identity.API.Models.InputModels;
using RS.Identity.API.Models.JwtToken;
using System.Threading.Tasks;

namespace RS.Identity.API.Models.Interfaces
{
    public interface IJwtServices
    {
        Task<ResultViewModel<UserAswerLogin>> UserRegistration(UserRegistrationInputModel userRegistration);
        Task<ResultViewModel<UserAswerLogin>> UserLoginAsync(UserLoginInputModel userLogin);
    }
}
