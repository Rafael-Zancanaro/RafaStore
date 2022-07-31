using HelperExtentions;
using RS.Identidade.API.Models.InputModels;
using RS.Identidade.API.Models.JwtToken;
using System.Threading.Tasks;

namespace RS.Identidade.API.Models.Interfaces
{
    public interface IJwtServices
    {
        Task<ResultViewModel<UserAswerLogin>> UserRegistration(UserRegistrationInputModel userRegistration);
        Task<ResultViewModel<UserAswerLogin>> UserLoginAsync(UserLoginInputModel userLogin);
    }
}
