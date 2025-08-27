using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Kosplay.API.Vmodels.Auth;

namespace Kosplay.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ResponseAuthViewModel> LoginAsync(RequestAuthViewModel request);
        Task<ResponseRegisterUserViewModel?> RegisterAsync(RequestRegisterUserViewModel request);

        Task<ResponseRefreshTokenViewModel> RefreshTokenAsync(RequestRefreshTokenViewModel request);
    }
}
