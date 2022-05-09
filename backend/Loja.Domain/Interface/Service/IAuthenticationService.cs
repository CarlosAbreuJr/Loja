using Loja.Domain.Models.Authentication;
using System.Threading.Tasks;

namespace Loja.Domain.Interface.Service
{
    public interface IAuthenticationService
    {
        Task<TokenResponse> CreateAccessTokenAsync(string email, string password);
        Task<AccessToken> RefreshTokenAsync(string refreshToken, string userEmail);
        void RevokeRefreshToken(string refreshToken);
    }
}
